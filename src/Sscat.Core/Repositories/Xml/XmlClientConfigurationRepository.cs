// <copyright file="XmlClientConfigurationRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories.Xml
{
    using System.IO;
    using Ncr.Core.Util;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the XmlClientConfigurationRepository class
    /// </summary>
    public class XmlClientConfigurationRepository : BaseXmlRepository<ClientConfiguration>, IClientConfigurationRepository
    {
        /// <summary>
        /// Save configuration
        /// </summary>
        /// <param name="config">client configuration</param>
        public void Save(ClientConfiguration config)
        {
            Serialize(config.FileName, config);
        }

        /// <summary>
        /// Read configuration file
        /// </summary>
        /// <param name="file">configuration file</param>
        /// <returns>Returns the client configuration</returns>
        public ClientConfiguration Read(string file)
        {
            return Read(file, string.Empty);
        }

        /// <summary>
        /// Read configuration file
        /// </summary>
        /// <param name="file">configuration file</param>
        /// <param name="fileNameToOverwrite">file name to overwrite</param>
        /// <returns>Returns the client configuration</returns>
        public ClientConfiguration Read(string file, string fileNameToOverwrite)
        {
            if (!FileHelper.Exists(file))
            {
                FileHelper.Copy(Path.Combine(ApplicationUtility.ConfigDirectory, "ClientConfiguration.default.xml"), file);
            }

            ClientConfiguration config = Deserialize(file);
            config.FileName = fileNameToOverwrite != null && !fileNameToOverwrite.Equals(string.Empty) ? fileNameToOverwrite : file;
            return config;
        }
    }
}
