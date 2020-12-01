// <copyright file="IExtendedTextReader.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the IExtendedTextReader interface
    /// </summary>
    public interface IExtendedTextReader
    {
        /// <summary>
        /// Gets the string length
        /// </summary>
        long Length { get; }

        /// <summary>
        /// Gets the string position
        /// </summary>
        long Position { get; }

        /// <summary>
        /// Read the line
        /// </summary>
        /// <returns>Returns the line</returns>
        string ReadLine();

        /// <summary>
        /// Close the reader
        /// </summary>
        void Close();
    }
}
