using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Altai.Logging
{
	// Simplified logging interface
	public interface ISimpleLogger
	{
		/* Log a message object */
		void Log( LogLevel in_level, object message );
	}
}
