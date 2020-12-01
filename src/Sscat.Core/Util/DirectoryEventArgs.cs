// <copyright file="DirectoryEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the DirectoryEventArgs class
    /// </summary>
    public class DirectoryEventArgs : EventArgs
    {
        /// <summary>
        /// Directory name
        /// </summary>
        private string _directory;

        /// <summary>
        /// Initializes a new instance of the DirectoryEventArgs class
        /// </summary>
        /// <param name="directory">directory name</param>
        public DirectoryEventArgs(string directory)
        {
            Directory = directory;
        }

        /// <summary>
        /// Gets or sets the directory
        /// </summary>
        public string Directory
        {
            get { return _directory; }
            set { _directory = value; }
        }
    }
}
