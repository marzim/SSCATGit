// <copyright file="IGeneratorConfigurationRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the IGeneratorConfigurationRepository interface
    /// </summary>
    public interface IGeneratorConfigurationRepository
    {
        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the generator configuration</returns>
        GeneratorConfiguration Read(string filename);
    }
}
