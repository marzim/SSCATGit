// <copyright file="StringArray.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the StringArray class
    /// </summary>
    public class StringArray
    {
        /// <summary>
        /// String array
        /// </summary>
        private string[] _stringArray;

        /// <summary>
        /// Initializes a new instance of the StringArray class
        /// </summary>
        /// <param name="array">string array</param>
        public StringArray(string[] array)
        {
            _stringArray = array;
        }

        /// <summary>
        /// Gets the index
        /// </summary>
        /// <param name="index">index number</param>
        /// <returns>Returns the value at given index</returns>
        public string this[int index]
        {
            get
            {
                if (index < _stringArray.Length)
                {
                    return _stringArray[index];
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the array
        /// </summary>
        /// <returns>Returns the string array</returns>
        public string[] ToArray()
        {
            return _stringArray;
        }
    }
}
