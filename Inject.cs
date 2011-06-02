using System;

namespace Dependency 
{ 
	/**
	* This code is from my mock crm implementation where we optionally
	* look for the mockcrm library. This is the very simplest form of
	* dependency injection, need to adapt it for more general use.
	*/
	public class Inject
	{
		/*
		 * Version of method that returns an implementation of ICrmService
		 */
		public static Microsoft.Crm.Sdk.ICrmService GetCrmService( string in_bizorg, MSCrmConfigurationSection in_config ) {
			
			if( in_config.UseMock == true && !String.IsNullOrEmpty( in_config.MockDataFile ) ) {
				string dataFile = in_config.MockDataFile;
				bool persistData = in_config.PersistMockData;

				// I didn't want to create a dependency on the Mock, and an IoC container
				// seems like overkill for this (it would be another dependency itself)
				// so we probe using LoadFrom and instantiate using reflection. 
				// Note that we use CodeBase rather than GetExecutingAssembly so that it
				// works with asp.net.
				string path = Assembly.GetExecutingAssembly().CodeBase;
				path = path.Substring( 0, path.LastIndexOf( "/" ) );
				Assembly mockCrmService = Assembly.LoadFrom( path + "/" + "MockCrmService.dll" );
				ICrmService service = ( ICrmService )mockCrmService.CreateInstance( 
					"Djn.Testing.MockCrmService", false, BindingFlags.CreateInstance, 
					null, new object[] { dataFile, persistData }, null, null 
				);
				
				return service;
			}
			else {
				CrmService service = new CrmService();
				service.CrmAuthenticationTokenValue = GetCrmAuthToken( in_bizorg );
				service.Url = in_config.CrmServiceUrl;
				service.Credentials = GetCredentials( in_config );
				service.PreAuthenticate = true;

				Microsoft.Crm.Sdk.ICrmService serviceAdapter = new CrmServiceAdapter4( service );
				return serviceAdapter;
			}
		}
	}
}
