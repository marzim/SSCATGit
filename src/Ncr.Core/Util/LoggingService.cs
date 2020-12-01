// <copyright file="LoggingService.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Collections.Generic;

    /// <summary>
    /// Log levels
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Log level None
        /// </summary>
        None = 0,

        /// <summary>
        /// Log level Info
        /// </summary>
        Info = 1,

        /// <summary>
        /// Log level Warning
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Log level Error
        /// </summary>
        Error = 4,

        /// <summary>
        /// Log level Create
        /// </summary>
        Create = 8,

        /// <summary>
        /// Log level Exists
        /// </summary>
        Exists = 16,

        /// <summary>
        /// Log level Debug
        /// </summary>
        Debug = 32
    }

    /// <summary>
    /// Initializes static members of the LoggingService class
    /// </summary>
    public static class LoggingService
    {
        /// <summary>
        /// list of loggers
        /// </summary>
        private static IList<ILogger> loggers = new List<ILogger>();
#if DEBUG        
        /// <summary>
        /// Log level
        /// </summary>
		private static LogLevel level = LogLevel.Info | LogLevel.Warning | LogLevel.Error | LogLevel.Create | LogLevel.Exists | LogLevel.Debug;
#else
        /// <summary>
        /// Log level
        /// </summary>
        private static LogLevel level = LogLevel.Info | LogLevel.Warning | LogLevel.Error | LogLevel.Create | LogLevel.Exists;
#endif
        /// <summary>
        /// Gets or sets the log level
        /// </summary>
        public static LogLevel Level
        {
            get { return level; }
            set { level = value; }
        }

        /// <summary>
        /// Clears the loggers
        /// </summary>
        public static void ClearLoggers()
        {
            loggers.Clear();
        }

        /// <summary>
        /// Attach the logger
        /// </summary>
        /// <param name="logger">logger to add</param>
        public static void Attach(ILogger logger)
        {
            loggers.Add(logger);
        }

        /// <summary>
        /// Detach all loggers
        /// </summary>
        public static void DetachAll()
        {
            loggers.Clear();
        }

        /// <summary>
        /// Debug the logger
        /// </summary>
        /// <param name="message">logger message</param>
        /// <param name="param">logger parameters</param>
        public static void Debug(string message, params string[] param)
        {
            if ((Level & LogLevel.Debug) == LogLevel.Debug)
            {
                foreach (ILogger logger in loggers)
                {
                    logger.Debug(string.Format(message, param));
                }
            }
        }

        /// <summary>
        /// Get logger information
        /// </summary>
        /// <param name="message">logger message</param>
        /// <param name="param">logger parameters</param>
        public static void Info(string message, params string[] param)
        {
            if ((Level & LogLevel.Info) == LogLevel.Info)
            {
                foreach (ILogger logger in loggers)
                {
                    logger.Info(string.Format(message, param));
                }
            }
        }

        /// <summary>
        /// Check if logger exists
        /// </summary>
        /// <param name="message">logger message</param>
        /// <param name="param">logger parameters</param>
        public static void Exists(string message, params string[] param)
        {
            if ((Level & LogLevel.Exists) == LogLevel.Exists)
            {
                foreach (ILogger logger in loggers)
                {
                    logger.Exists(string.Format(message, param));
                }
            }
        }

        /// <summary>
        /// Create the logger
        /// </summary>
        /// <param name="message">logger message</param>
        /// <param name="param">logger parameters</param>
        public static void Create(string message, params string[] param)
        {
            if ((Level & LogLevel.Create) == LogLevel.Create)
            {
                foreach (ILogger logger in loggers)
                {
                    logger.Create(string.Format(message, param));
                }
            }
        }

        /// <summary>
        /// Logger warning
        /// </summary>
        /// <param name="message">logger message</param>
        /// <param name="param">logger parameters</param>
        public static void Warning(string message, params string[] param)
        {
            if ((Level & LogLevel.Warning) == LogLevel.Warning)
            {
                foreach (ILogger logger in loggers)
                {
                    logger.Warning(string.Format(message, param));
                }
            }
        }

        /// <summary>
        /// Logger error
        /// </summary>
        /// <param name="message">logger message</param>
        /// <param name="param">logger parameters</param>
        public static void Error(string message, params string[] param)
        {
            if ((Level & LogLevel.Error) == LogLevel.Error)
            {
                foreach (ILogger logger in loggers)
                {
                    logger.Error(string.Format(message, param));
                }
            }
        }
    }
}
