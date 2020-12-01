// <copyright file="NumericComparer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System.Collections;

    /// <summary>
    /// Initializes a new instance of the NumericComparer class
    /// </summary>
    public class NumericComparer : IComparer
    {
        /// <summary>
        /// Initializes a new instance of the NumericComparer class
        /// </summary>
        public NumericComparer()
        {
        }

        /// <summary>
        /// Compare two objects to see if they are both strings
        /// </summary>
        /// <param name="x">object one</param>
        /// <param name="y">object two</param>
        /// <returns>Returns true if both are strings and match, false otherwise</returns>
        public int Compare(object x, object y)
        {
            if ((x is string) && (y is string))
            {
                return StringLogicalComparer.Compare((string)x, (string)y);
            }

            return -1;
        }
    }
}