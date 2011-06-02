using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altai.Logging
{
	class ExceptionLogger
	{
		/**
		 * TryAndLog for code that returns a value
		 */
		public static object TryAndLog( Func<object> in_function, ILogger in_logger ) {
			try {
				return in_function();
			}
			catch( Exception e ) {
				in_logger.Debug( e );
				throw;
			}
		}

		/*
		* TryAndLog for code that does not return a value
		*/ 
		public static void TryAndLog( Action in_function, ILogger in_logger ) {
			try {
				in_function();
			}
			catch( Exception e ) {
				in_logger.Debug( e );
				throw;
			}
		}

	}
}
