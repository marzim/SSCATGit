// <copyright file="IlogFormatter.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the ILogFormatter interface
    /// </summary>
    public interface ILogFormatter
    {
        /// <summary>
        /// Format the log
        /// </summary>
        /// <param name="log">log to format</param>
        /// <param name="level">log level</param>
        /// <returns>Returns formatted log</returns>
        string Format(string log, LogLevel level);

        /// <summary>
        /// Format the log
        /// </summary>
        /// <param name="log">log to format</param>
        /// <returns>Returns formatted log</returns>
        string Format(string log);
    }
}
