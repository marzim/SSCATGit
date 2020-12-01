// <copyright file="Log4NetLogger.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Reflection;
    using log4net;
    using log4net.Config;

    /// <summary>
    /// Initializes a new instance of the Log4NetLogger class
    /// </summary>
    public class Log4NetLogger : AbstractLogger
    {
        /// <summary>
        /// Log interface
        /// </summary>
        private ILog _log = null;

        /// <summary>
        /// Initializes a new instance of the Log4NetLogger class
        /// </summary>
        public Log4NetLogger()
            : base(new DateLogFormatter())
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="message">log message</param>
        public override void Warning(string message)
        {
            _log.Warn(message);
        }

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="message">log message</param>
        public override void Info(string message)
        {
            _log.Info(message);
        }

        /// <summary>
        /// Log exists
        /// </summary>
        /// <param name="message">log message</param>
        public override void Exists(string message)
        {
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="message">log message</param>
        public override void Error(string message)
        {
            _log.Error(message);
        }

        /// <summary>
        /// Log debug
        /// </summary>
        /// <param name="message">log message</param>
        public override void Debug(string message)
        {
            _log.Debug(message);
        }

        /// <summary>
        /// Log create
        /// </summary>
        /// <param name="message">log message</param>
        public override void Create(string message)
        {
        }
    }
}
