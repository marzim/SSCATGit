// <copyright file="CsvLogFormatter.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the AbstractLogger class
    /// </summary>
    public class CsvLogFormatter : ILogFormatter
    {
        /// <summary>
        /// Format the log
        /// </summary>
        /// <param name="log">log to format</param>
        /// <param name="level">log level</param>
        /// <returns>Returns formatted log</returns>
        public string Format(string log, LogLevel level)
        {
            return string.Format("{0}, {1}", DateTimeUtility.Now(), log);
        }

        /// <summary>
        /// Format the log
        /// </summary>
        /// <param name="log">log to format</param>
        /// <returns>Returns formatted log</returns>
        public string Format(string log)
        {
            return string.Format("{0}, {1}", DateTimeUtility.Now(), log);
        }
    }
}
