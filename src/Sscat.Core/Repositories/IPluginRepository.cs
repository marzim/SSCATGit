// <copyright file="IPluginRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using Ncr.Core.Plugins;

    /// <summary>
    /// Initializes a new instance of the IPluginRepository interface
    /// </summary>
    public interface IPluginRepository : IRepository
    {
        /// <summary>
        /// Load the file
        /// </summary>
        /// <param name="file">file to load</param>
        /// <returns>Return the plugin</returns>
        Plugin Load(string file);
    }
}
