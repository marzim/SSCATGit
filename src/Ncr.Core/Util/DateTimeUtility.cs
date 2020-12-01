// <copyright file="DateTimeUtility.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the DateTimeUtility class
    /// </summary>
    public static class DateTimeUtility
    {
        /// <summary>
        /// Current date time
        /// </summary>
        /// <returns>Returns the current date time</returns>
        public static string Now()
        {
            return Now("MM-dd-yyyy hh:mm:ss.fff");
        }

        /// <summary>
        /// Current date time in given format
        /// </summary>
        /// <param name="format">date time format</param>
        /// <returns>Returns formatted current date time</returns>
        public static string Now(string format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}
