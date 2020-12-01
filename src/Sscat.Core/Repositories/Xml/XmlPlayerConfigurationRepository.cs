// <copyright file="XmlPlayerConfigurationRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories.Xml
{
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the XmlPlayerConfigurationRepository class
    /// </summary>
    public class XmlPlayerConfigurationRepository : BaseXmlRepository<PlayerConfiguration>, IPlayerConfigurationRepository
    {
        /// <summary>
        /// Initializes a new instance of the XmlPlayerConfigurationRepository class
        /// </summary>
        public XmlPlayerConfigurationRepository()
        {
        }
        
        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the deserialized player configuration</returns>
        public PlayerConfiguration Read(string filename)
        {
            return Deserialize(filename);
        }
    }
}
