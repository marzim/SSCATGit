// <copyright file="ILaunchPadConfigRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using Sscat.Core.Repositories;

    /// <summary>
    /// Initializes a new instance of the ILaunchPadConfigRepository interface
    /// </summary>
    public interface ILaunchPadConfigRepository : IRepository
    {
        /// <summary>
        /// Reads the launch pad configuration file
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>Returns the configuration</returns>
        LaunchPadConfig Read(string file);
    }
}
