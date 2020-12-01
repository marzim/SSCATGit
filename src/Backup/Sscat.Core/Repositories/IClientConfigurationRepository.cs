// <copyright file="IClientConfigurationRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the IClientConfigurationRepository interface
    /// </summary>
    public interface IClientConfigurationRepository : IRepository
    {
        /// <summary>
        /// Save the client configuration
        /// </summary>
        /// <param name="config">client configuration to save</param>
        void Save(ClientConfiguration config);

        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>Returns the client configuration</returns>
        ClientConfiguration Read(string file);

        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="file">file to read</param>
        /// <param name="fileNameToOverwrite">file name to overwrite</param>
        /// <returns>Returns the client configuration</returns>
        ClientConfiguration Read(string file, string fileNameToOverwrite);
    }
}
