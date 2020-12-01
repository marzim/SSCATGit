// <copyright file="XmlLaneConfigurationRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories.Xml
{
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the XmlLaneConfigurationRepository class
    /// </summary>
    public class XmlLaneConfigurationRepository : BaseXmlRepository<LaneConfiguration>, ILaneConfigurationRepository
    {
        /// <summary>
        /// Save the configuration
        /// </summary>
        /// <param name="config">lane configuration</param>
        public void Save(LaneConfiguration config)
        {
            Serialize(config.FileName, config);
        }

        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>Returns the deserialized lane configuration</returns>
        public LaneConfiguration Read(string file)
        {
            return Deserialize(file);
        }
    }
}
