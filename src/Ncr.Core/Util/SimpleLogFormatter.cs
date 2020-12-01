// <copyright file="SimpleLogFormatter.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the SimpleLogFormatter class
    /// </summary>
    public class SimpleLogFormatter : ILogFormatter
    {
        /// <summary>
        /// Format log
        /// </summary>
        /// <param name="log">log text</param>
        /// <param name="level">log level</param>
        /// <returns>Returns the formatted log</returns>
        public string Format(string log, LogLevel level)
        {
            return string.Format("{0} {1}", level.ToString().ToLower().PadLeft(10), log);
        }

        /// <summary>
        /// Format log
        /// </summary>
        /// <param name="log">log text</param>
        /// <returns>Returns the formatted log</returns>
        public string Format(string log)
        {
            return string.Format("{0} {1}", string.Empty.PadLeft(10), log);
        }
    }
}
