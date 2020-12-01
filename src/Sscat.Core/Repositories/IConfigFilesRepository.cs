// <copyright file="IConfigFilesRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using System;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the IConfigFilesRepository interface
    /// </summary>
    public interface IConfigFilesRepository : IRepository
    {
        /// <summary>
        /// Event handler for check configuration on server
        /// </summary>
        event EventHandler<ConfigFileEventArgs> CheckConfigOnServer;

        /// <summary>
        /// Event handler for load configuration on server
        /// </summary>
        event EventHandler<ConfigFileEventArgs> LoadConfigOnServer;

        /// <summary>
        /// Event handler for copy configuration on server
        /// </summary>
        event EventHandler<ConfigFileEventArgs> CopyConfigOnServer;

        /// <summary>
        /// Read the configuration files
        /// </summary>
        /// <param name="name">directory name</param>
        /// <param name="files">configuration files</param>
        void Read(string name, ConfigFiles files);

        /// <summary>
        /// Load the configuration files
        /// </summary>
        /// <param name="files">configuration files</param>
        void Load(ConfigFiles files);

        /// <summary>
        /// Get configuration files
        /// </summary>
        /// <param name="files">configuration files</param>
        /// <param name="configName">configuration name</param>
        void Get(ConfigFiles files, string configName);

        /// <summary>
        /// Checks if files differ from SCOT configuration
        /// </summary>
        /// <param name="files">configuration files</param>
        /// <returns>Returns true if different, false otherwise</returns>
        bool DiffersFromScotConfig(ConfigFiles files);

        /// <summary>
        /// Stops the repository
        /// </summary>
        void Stop();
    }
}
