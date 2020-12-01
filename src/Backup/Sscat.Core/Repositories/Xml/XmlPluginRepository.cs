// <copyright file="XmlPluginRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories.Xml
{
    using Ncr.Core.Plugins;

    /// <summary>
    /// Initializes a new instance of the XmlPluginRepository class
    /// </summary>
    public class XmlPluginRepository : BaseXmlRepository<Plugin>, IPluginRepository
    {
        /// <summary>
        /// Initializes a new instance of the XmlPluginRepository class
        /// </summary>
        public XmlPluginRepository()
        {
        }

        /// <summary>
        /// Loads the file
        /// </summary>
        /// <param name="file">file to load</param>
        /// <returns>Returns the plugin</returns>
        public Plugin Load(string file)
        {
            return Deserialize(file);
        }
    }
}
