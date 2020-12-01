// <copyright file="ConfigFileEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ConfigFileEventArgs class
    /// </summary>
    public class ConfigFileEventArgs : EventArgs
    {
        /// <summary>
        /// Configuration file
        /// </summary>
        private ConfigFile _file;

        /// <summary>
        /// Source path
        /// </summary>
        private string _sourcePath;

        /// <summary>
        /// Destination path
        /// </summary>
        private string _destinationPath;

        /// <summary>
        /// Initializes a new instance of the ConfigFileEventArgs class
        /// </summary>
        /// <param name="file">configuration file</param>
        public ConfigFileEventArgs(ConfigFile file)
            : this(file, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ConfigFileEventArgs class
        /// </summary>
        /// <param name="file">configuration file</param>
        /// <param name="sourcePath">source path</param>
        /// <param name="destinationPath">destination path</param>
        public ConfigFileEventArgs(ConfigFile file, string sourcePath, string destinationPath)
        {
            File = file;
            SourcePath = sourcePath;
            DestinationPath = destinationPath;
        }

        /// <summary>
        /// Gets or sets the source path
        /// </summary>
        public string SourcePath
        {
            get { return _sourcePath; }
            set { _sourcePath = value; }
        }

        /// <summary>
        /// Gets or sets the destination path
        /// </summary>
        public string DestinationPath
        {
            get { return _destinationPath; }
            set { _destinationPath = value; }
        }

        /// <summary>
        /// Gets or sets the configuration file
        /// </summary>
        public ConfigFile File
        {
            get { return _file; }
            set { _file = value; }
        }
    }
}
