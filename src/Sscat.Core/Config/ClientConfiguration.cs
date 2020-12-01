// <copyright file="ClientConfiguration.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the ClientConfiguration class
    /// </summary>
    [XmlRoot("Configuration"), Serializable()]
    public class ClientConfiguration : BaseModel<ClientConfiguration>
    {
        /// <summary>
        /// Generator configuration
        /// </summary>
        private GeneratorConfiguration _generatorConfig;

        /// <summary>
        /// Player configuration
        /// </summary>
        private PlayerConfiguration _playerConfig;

        /// <summary>
        /// File name
        /// </summary>
        private string _fileName;

        /// <summary>
        /// Configuration files
        /// </summary>
        private ConfigFiles _files = new ConfigFiles();

        /// <summary>
        /// Initializes a new instance of the ClientConfiguration class
        /// </summary>
        public ClientConfiguration()
            : this(string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ClientConfiguration class
        /// </summary>
        /// <param name="file">client configuration file</param>
        public ClientConfiguration(string file)
        {
            FileName = file;
            _generatorConfig = new GeneratorConfiguration();
            _playerConfig = new PlayerConfiguration();
        }

        /// <summary>
        /// Gets or sets the configuration file
        /// </summary>
        [XmlElement("Files")]
        public ConfigFiles Files
        {
            get { return _files; }
            set { _files = value; }
        }

        /// <summary>
        /// Gets or sets the configuration file name
        /// </summary>
        [XmlIgnoreAttribute]
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// Gets or sets the player configuration
        /// </summary>
        [XmlElement("Player")]
        public PlayerConfiguration PlayerConfiguration
        {
            get { return _playerConfig; }
            set { _playerConfig = value; }
        }

        /// <summary>
        /// Gets or sets the script generator
        /// </summary>
        [XmlElement("ScriptGenerator")]
        public GeneratorConfiguration GeneratorConfiguration
        {
            get { return _generatorConfig; }
            set { _generatorConfig = value; }
        }

        /// <summary>
        /// Validates the player configuration
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            ValidateIf(PlayerConfiguration, PlayerConfiguration != null);
        }
    }   
}
