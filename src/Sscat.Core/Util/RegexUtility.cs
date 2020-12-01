// <copyright file="RegexUtility.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Initializes a new instance of the RegexUtility class
    /// </summary>
    public static class RegexUtility
    {
        /// <summary>
        /// Get the match
        /// </summary>
        /// <param name="line">line to check</param>
        /// <param name="pattern">pattern to check for</param>
        /// <returns>Returns a match if found</returns>
        public static Match Match(string line, string pattern)
        {
            return Regex.Match(line, pattern, RegexOptions.IgnoreCase);
        }
    }
}
