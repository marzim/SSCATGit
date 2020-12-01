// <copyright file="XmlLaunchPadConfigRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Core.Config
{
    using Sscat.Core.Repositories;

    /// <summary>
    /// Initializes a new instance of the XmlLaunchPadConfigRepository class
    /// </summary>
    public class XmlLaunchPadConfigRepository : BaseXmlRepository<LaunchPadConfig>, ILaunchPadConfigRepository
    {
        /// <summary>
        /// Reads the launch pad configuration file
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>Returns the configuration</returns>
        public LaunchPadConfig Read(string file)
        {
            return Deserialize(file);
        }
    }
}
