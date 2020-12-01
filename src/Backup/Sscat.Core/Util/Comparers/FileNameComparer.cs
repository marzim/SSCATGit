// <copyright file="FileNameComparer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System.Collections.Generic;
    
    /// <summary>
    /// Initializes a new instance of the FileNameComparer class
    /// </summary>
    public class FileNameComparer : IComparer<string>
    {
        /// <summary>
        /// Compare two strings
        /// </summary>
        /// <param name="x">first string</param>
        /// <param name="y">second string</param>
        /// <returns>Returns a numeric comparer result between the two strings</returns>
        public int Compare(string x, string y)
        {
            return new NumericComparer().Compare(x, y);
        }
    }
}
