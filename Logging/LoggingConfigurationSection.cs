using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Altai.Logging
{
	public class LoggingConfigurationSection : ConfigurationSection
	{
		// only log4net or flog currently supported
		[ConfigurationProperty( "loggingLibrary" )]
		public string LoggingLibrary {
			get {
				return this[ "loggingLibrary" ].ToString();
			}
			set {
				this[ "loggingLibrary" ] = value;
			}
		}
	} // class
} // namespace
