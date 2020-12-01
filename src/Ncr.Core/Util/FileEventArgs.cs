// <copyright file="FileEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the FileEventArgs class
    /// </summary>
    public class FileEventArgs : EventArgs
    {
        /// <summary>
        /// File for the event
        /// </summary>
        private string _file;

        /// <summary>
        /// Initializes a new instance of the FileEventArgs class
        /// </summary>
        /// <param name="filename">file name</param>
        public FileEventArgs(string filename)
        {
            File = filename;
        }

        /// <summary>
        /// Gets or sets the file
        /// </summary>
        public string File
        {
            get { return _file; }
            set { _file = value; }
        }
    }
}
