// <copyright file="ConfigFilesEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ConfigFilesEventArgs class
    /// </summary>
    public class ConfigFilesEventArgs : EventArgs
    {
        /// <summary>
        /// Configuration files
        /// </summary>
        private ConfigFiles _files;

        /// <summary>
        /// Whether or not a force stop is needed
        /// </summary>
        private bool _forceStop;

        /// <summary>
        /// Configuration name
        /// </summary>
        private string _configName;

        /// <summary>
        /// Initializes a new instance of the ConfigFilesEventArgs class
        /// </summary>
        /// <param name="files">configuration files</param>
        public ConfigFilesEventArgs(ConfigFiles files)
        {
            Files = files;
        }

        /// <summary>
        /// Initializes a new instance of the ConfigFilesEventArgs class
        /// </summary>
        /// <param name="files">configuration files</param>
        /// <param name="forceStop">whether or not a force stop is needed</param>
        public ConfigFilesEventArgs(ConfigFiles files, bool forceStop)
            : this(files)
        {
            ForceStop = forceStop;
        }

        /// <summary>
        /// Initializes a new instance of the ConfigFilesEventArgs class
        /// </summary>
        /// <param name="files">configuration files</param>
        /// <param name="configName">configuration name</param>
        public ConfigFilesEventArgs(ConfigFiles files, string configName)
            : this(files)
        {
            ConfigName = configName;
        }

        /// <summary>
        /// Gets or sets the configuration name
        /// </summary>
        public string ConfigName
        {
            get { return _configName; }
            set { _configName = value; }
        }

        /// <summary>
        /// Gets or sets the configuration file
        /// </summary>
        public ConfigFiles Files
        {
            get { return _files; }
            set { _files = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a force stop is needed
        /// </summary>
        public bool ForceStop
        {
            get { return _forceStop; }
            set { _forceStop = value; }
        }
    }
}
