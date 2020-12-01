// <copyright file="AbstractLogger.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the AbstractLogger class
    /// </summary>
    public abstract class AbstractLogger : ILogger
    {
        /// <summary>
        /// Log formatter interface
        /// </summary>
        private ILogFormatter _formatter;

        /// <summary>
        /// Initializes a new instance of the AbstractLogger class
        /// </summary>
        /// <param name="formatter">log formatter</param>
        public AbstractLogger(ILogFormatter formatter)
        {
            Formatter = formatter;
        }

        /// <summary>
        /// Gets or sets the log formatter
        /// </summary>
        public ILogFormatter Formatter
        {
            get { return _formatter; }
            set { _formatter = value; }
        }

        /// <summary>
        /// Debug logger
        /// </summary>
        /// <param name="message">message to log</param>
        public abstract void Debug(string message);

        /// <summary>
        /// Error logger
        /// </summary>
        /// <param name="message">message to log</param>
        public abstract void Error(string message);

        /// <summary>
        /// Information logger
        /// </summary>
        /// <param name="message">message to log</param>
        public abstract void Info(string message);

        /// <summary>
        /// Warning logger
        /// </summary>
        /// <param name="message">message to log</param>
        public abstract void Warning(string message);

        /// <summary>
        /// Exists logger
        /// </summary>
        /// <param name="message">message to log</param>
        public abstract void Exists(string message);

        /// <summary>
        /// Create logger
        /// </summary>
        /// <param name="message">message to log</param>
        public abstract void Create(string message);
    }
}
