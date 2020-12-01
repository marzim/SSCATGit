// <copyright file="ILogger.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the ILogger interface
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Gets or sets the log formatter
        /// </summary>
        ILogFormatter Formatter { get; set; }

        /// <summary>
        /// Debug logger
        /// </summary>
        /// <param name="message">message to log</param>
        void Debug(string message);

        /// <summary>
        /// Error logger
        /// </summary>
        /// <param name="message">message to log</param>
        void Error(string message);

        /// <summary>
        /// Information logger
        /// </summary>
        /// <param name="message">message to log</param>
        void Info(string message);

        /// <summary>
        /// Warning logger
        /// </summary>
        /// <param name="message">message to log</param>
        void Warning(string message);

        /// <summary>
        /// Exists logger
        /// </summary>
        /// <param name="message">message to log</param>
        void Exists(string message);

        /// <summary>
        /// Create logger
        /// </summary>
        /// <param name="message">message to log</param>
        void Create(string message);
    }
}
