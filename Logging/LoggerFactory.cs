using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Altai.Logging
{
	public class LoggerFactory
	{
		public static LoggingConfigurationSection ms_loggingConfig =
				( LoggingConfigurationSection )ConfigurationManager.GetSection( "Altai.Logging" );

		public static ILogger GetLogger( string in_name ) {
			ILogger logger;

			// default to flog if there is no configuration section
			if( ms_loggingConfig == null ) {
				return new FlogLogger( in_name );
			}

			switch( ms_loggingConfig.LoggingLibrary ) { 
				case "flog":
					logger = new FlogLogger( in_name );
					break;
				case "log4net":
					// logger = new Log4NetLogger( log4net.LogManager.GetLogger( in_name ) );
					throw new NotImplementedException( "log4net is stubbed out" );
					// break;
				default:
					logger = new FlogLogger( in_name );
					break;
			}
			return logger;
		}
		public static ILogger GetLogger( Type in_type ) {
			return GetLogger( in_type.Name );
		}
		// public static ILogger GetSimpleLogger( string in_name ) {}
	}
}
