// <copyright file="ExtendedStringReader.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Util
{
    using System;
    using System.IO;

    /// <summary>
    /// Initializes a new instance of the ExtendedStringReader class
    /// </summary>
    public class ExtendedStringReader : StringReader, IExtendedTextReader
    {
        /// <summary>
        /// String position
        /// </summary>
        private long _position = 0;

        /// <summary>
        /// String length
        /// </summary>
        private long _length = 0;

        /// <summary>
        /// Initializes a new instance of the ExtendedStringReader class
        /// </summary>
        /// <param name="str">string to check</param>
        public ExtendedStringReader(string str)
            : base(str)
        {
            _length = str.Length;
        }

        /// <summary>
        /// Gets the string length
        /// </summary>
        public long Length
        {
            get { return _length; }
        }

        /// <summary>
        /// Gets the string position
        /// </summary>
        public long Position
        {
            get { return _position; }
        }

        /// <summary>
        /// Reads the next character from the input string and advances the character position by one character.
        /// </summary>
        /// <returns>The next character from the underlying string, or -1 if no more characters are available.</returns>
        public override int Read()
        {
            _position++;
            return base.Read();
        }
    }
}
