// <copyright file="IPlayerConfigurationRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the IPlayerConfigurationRepository interface
    /// </summary>
    public interface IPlayerConfigurationRepository
    {
        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the player configuration</returns>
        PlayerConfiguration Read(string filename);
    }
}
