using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Djn;

namespace Altai.Logging
{
	/**
	 * Wrapper around Flog logger
	 */
	public class FlogLogger : ILogger
	{
		private string m_loggerName;

		public FlogLogger( string in_loggerName ) {
			m_loggerName = in_loggerName;
		}

		/* Test if a level is enabled for logging */
		public bool IsDebugEnabled { get { return true; } }
		public bool IsInfoEnabled { get { return true; } }
		public bool IsWarnEnabled { get { return true; } }
		public bool IsErrorEnabled { get { return true; } }
		public bool IsFatalEnabled { get { return true; } }

		/* Log a message object */
		public void Debug( object message ) { Flog.Log( "Debug", m_loggerName, message.ToString() ); }
		public void Info( object message ) { Flog.Log( "Info", m_loggerName, message.ToString() ); }
		public void Warn( object message ) { Flog.Log( "Warn", m_loggerName, message.ToString() ); }
		public void Error( object message ) { Flog.Log( "Error", m_loggerName, message.ToString() ); }
		public void Fatal( object message ) { Flog.Log( "Fatal", m_loggerName, message.ToString() ); }

		/* Log a message object and exception */
		public void Debug( object message, Exception t ) { Flog.Log( "Debug", m_loggerName, message.ToString() + " " + t.ToString() ); }
		public void Info( object message, Exception t ) { Flog.Log( "Info", m_loggerName, message.ToString() + " " + t.ToString() ); }
		public void Warn( object message, Exception t ) { Flog.Log( "Warn", m_loggerName, message.ToString() + " " + t.ToString() ); }
		public void Error( object message, Exception t ) { Flog.Log( "Error", m_loggerName, message.ToString() + " " + t.Message ); }
		public void Fatal( object message, Exception t ) { Flog.Log( "Fatal", m_loggerName, message.ToString() + " " + t.ToString() ); }

		/* Log a message string using the System.String.Format syntax */
		public void DebugFormat( string format, params object[] args ) { Flog.Log( "Debug", m_loggerName, String.Format( format, args ) ); }
		public void InfoFormat( string format, params object[] args ) { Flog.Log( "Info", m_loggerName, String.Format( format, args ) ); }
		public void WarnFormat( string format, params object[] args ) { Flog.Log( "Warn", m_loggerName, String.Format( format, args ) ); }
		public void ErrorFormat( string format, params object[] args ) { Flog.Log( "Error", m_loggerName, String.Format( format, args ) ); }
		public void FatalFormat( string format, params object[] args ) { Flog.Log( "Fatal", m_loggerName, String.Format( format, args ) ); }

		/* Log a message string using the System.String.Format syntax */
		public void DebugFormat( IFormatProvider provider, string format, params object[] args ) { Flog.Log( "Debug", m_loggerName, String.Format( provider, format, args ) ); }
		public void InfoFormat( IFormatProvider provider, string format, params object[] args ) { Flog.Log( "Info", m_loggerName, String.Format( provider, format, args ) ); }
		public void WarnFormat( IFormatProvider provider, string format, params object[] args ) { Flog.Log( "Warn", m_loggerName, String.Format( provider, format, args ) ); }
		public void ErrorFormat( IFormatProvider provider, string format, params object[] args ) { Flog.Log( "Error", m_loggerName, String.Format( provider, format, args ) ); }
		public void FatalFormat( IFormatProvider provider, string format, params object[] args ) { Flog.Log( "Fatal", m_loggerName, String.Format( provider, format, args ) ); }
	}
}
