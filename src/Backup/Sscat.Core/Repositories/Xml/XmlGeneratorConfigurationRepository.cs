// <copyright file="XmlGeneratorConfigurationRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories.Xml
{
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the XmlGeneratorConfigurationRepository class
    /// </summary>
    public class XmlGeneratorConfigurationRepository : BaseXmlRepository<GeneratorConfiguration>, IGeneratorConfigurationRepository
    {
        /// <summary>
        /// Initializes a new instance of the XmlGeneratorConfigurationRepository class
        /// </summary>
        public XmlGeneratorConfigurationRepository()
        {
        }

        /// <summary>
        /// Read the configuration
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the deserialized generator configuration</returns>
        public GeneratorConfiguration Read(string filename)
        {
            return Deserialize(filename);
        }
    }
}
