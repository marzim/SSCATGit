// <copyright file="ExtendedStreamReader.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.IO;
    using System.Text;

    /// <summary>
    /// Initializes a new instance of the ExtendedStreamReader class
    /// </summary>
    public class ExtendedStreamReader : StreamReader, IExtendedTextReader
    {
        /// <summary>
        /// Initializes a new instance of the ExtendedStreamReader class
        /// </summary>
        /// <param name="stream">stream to read</param>
        public ExtendedStreamReader(Stream stream)
            : base(stream)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ExtendedStreamReader class
        /// </summary>
        /// <param name="stream">stream to read</param>
        /// <param name="encoding">encoding type</param>
        public ExtendedStreamReader(Stream stream, Encoding encoding)
            : base(stream, encoding)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ExtendedStreamReader class
        /// </summary>
        /// <param name="path">path name</param>
        public ExtendedStreamReader(string path)
            : base(path)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ExtendedStreamReader class
        /// </summary>
        /// <param name="path">path name</param>
        /// <param name="encoding">encoding type</param>
        public ExtendedStreamReader(string path, Encoding encoding)
            : base(path, encoding)
        {
        }

        /// <summary>
        /// Gets the position
        /// </summary>
        public long Position
        {
            get { return this.BaseStream.Position; }
        }

        /// <summary>
        /// Gets the length
        /// </summary>
        public long Length
        {
            get { return this.BaseStream.Length; }
        }
    }
}
