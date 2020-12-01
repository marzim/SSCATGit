// <copyright file="IConfigFileRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using System;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the IConfigFileRepository interface
    /// </summary>
    public interface IConfigFileRepository : IRepository
    {
        /// <summary>
        /// Event handler for load on server
        /// </summary>
        event EventHandler<ConfigFileEventArgs> LoadOnServer;

        /// <summary>
        /// Event handler for check on server
        /// </summary>
        event EventHandler<ConfigFileEventArgs> CheckOnServer;

        /// <summary>
        /// Create configuration file
        /// </summary>
        /// <param name="file">configuration file</param>
        void Create(ConfigFile file);

        /// <summary>
        /// Read the configuration file
        /// </summary>
        /// <param name="file">configuration file</param>
        void Read(ConfigFile file);

        /// <summary>
        /// Read the configuration file
        /// </summary>
        /// <param name="name">name of the file</param>
        /// <param name="file">configuration file</param>
        void Read(string name, ConfigFile file);

        /// <summary>
        /// Copies the file from source to destination and deletes the original
        /// </summary>
        /// <param name="source">source of file</param>
        /// <param name="dest">destination of file</param>
        void Rename(string source, string dest);

        /// <summary>
        /// Checks if file exists
        /// </summary>
        /// <param name="file">file to check</param>
        /// <returns>Returns true if exist, false otherwise</returns>
        bool Exists(string file);

        /// <summary>
        /// Read the configuration file
        /// </summary>
        /// <param name="file">configuration file</param>
        /// <returns>Returns the configuration file</returns>
        ConfigFile Read(string file);

        /// <summary>
        /// Checks if the file differs
        /// </summary>
        /// <param name="file">file to check</param>
        /// <param name="source">file source</param>
        /// <param name="destination">file destination</param>
        /// <returns>Returns true if different, false otherwise</returns>
        bool Differs(ConfigFile file, string source, string destination);

        /// <summary>
        /// Loads the configuration file
        /// </summary>
        /// <param name="file">configuration file</param>
        /// <param name="source">file source</param>
        /// <param name="destination">file destination</param>
        void Load(ConfigFile file, string source, string destination);
    }
}
