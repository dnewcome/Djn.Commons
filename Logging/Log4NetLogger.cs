using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
namespace Altai.Logging
{
	/**
	 * Wrapper around log4net logger
	 * TODO: move to separate assembly so we don't have direct dependency on log4net
	 */
	public class Log4NetLogger : ILogger 
	{
		private ILog m_log4netLogger;

		// read app.config in type initializer
		static Log4NetLogger() {
			log4net.Config.XmlConfigurator.Configure();
		}

		public Log4NetLogger( ILog in_log4netLogger ) {
			m_log4netLogger = in_log4netLogger;
		}

		/* Test if a level is enabled for logging */
		public bool IsDebugEnabled { get { return m_log4netLogger.IsDebugEnabled; } }
		public bool IsInfoEnabled { get { return m_log4netLogger.IsInfoEnabled; } }
		public bool IsWarnEnabled { get { return m_log4netLogger.IsWarnEnabled; } }
		public bool IsErrorEnabled { get { return m_log4netLogger.IsErrorEnabled; } }
		public bool IsFatalEnabled { get { return m_log4netLogger.IsFatalEnabled; } }

		/* Log a message object */
		public void Debug( object message ) { m_log4netLogger.Debug( message ); }
		public void Info( object message ) { m_log4netLogger.Info( message ); }
		public void Warn( object message ) { m_log4netLogger.Warn( message ); }
		public void Error( object message ) { m_log4netLogger.Error( message ); }
		public void Fatal( object message ) { m_log4netLogger.Fatal( message ); }

		/* Log a message object and exception */
		public void Debug( object message, Exception t ) { m_log4netLogger.Debug( message, t ); }
		public void Info( object message, Exception t ) { m_log4netLogger.Info( message, t ); }
		public void Warn( object message, Exception t ) { m_log4netLogger.Warn( message, t ); }
		public void Error( object message, Exception t ) { m_log4netLogger.Error( message, t ); }
		public void Fatal( object message, Exception t ) { m_log4netLogger.Fatal( message, t ); }

		/* Log a message string using the System.String.Format syntax */
		public void DebugFormat( string format, params object[] args ) { m_log4netLogger.DebugFormat( format, args ); }
		public void InfoFormat( string format, params object[] args ) { m_log4netLogger.InfoFormat( format, args ); }
		public void WarnFormat( string format, params object[] args ) { m_log4netLogger.WarnFormat( format, args ); }
		public void ErrorFormat( string format, params object[] args ) { m_log4netLogger.ErrorFormat( format, args ); }
		public void FatalFormat( string format, params object[] args ) { m_log4netLogger.FatalFormat( format, args ); }

		/* Log a message string using the System.String.Format syntax */
		public void DebugFormat( IFormatProvider provider, string format, params object[] args ) { m_log4netLogger.DebugFormat( provider, format, args ); }
		public void InfoFormat( IFormatProvider provider, string format, params object[] args ) { m_log4netLogger.InfoFormat( provider, format, args ); }
		public void WarnFormat( IFormatProvider provider, string format, params object[] args ) { m_log4netLogger.WarnFormat( provider, format, args ); }
		public void ErrorFormat( IFormatProvider provider, string format, params object[] args ) { m_log4netLogger.ErrorFormat( provider, format, args ); }
		public void FatalFormat( IFormatProvider provider, string format, params object[] args ) { m_log4netLogger.FatalFormat( provider, format, args ); }
	}
}
