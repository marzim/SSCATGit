// <copyright file="IntExtensions.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.ExtensionMethods
{
    using System;

    /// <summary>
    /// Initializes a new instance of the IntExtensions class
    /// </summary>
    public static class IntExtensions
    {
#if NET40
        /// <summary>
        /// Converts milliseconds to a seconds string.
        /// </summary>
        /// <param name="x">Number of milliseconds.</param>
        /// <returns>Number of seconds in 3 decimal places.</returns>
        public static string MillisecondsToSeconds(this int x)
        {
            decimal seconds = (decimal)x / 1000m;

            return seconds.ToString("N3");
        }
#endif
    }    
}
