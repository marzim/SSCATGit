// <copyright file="ScriptConfig.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Sscat.Core.Config;

    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptConfig class
    /// </summary>
    [Serializable]
    public class ScriptConfig : BaseSerializable<ScriptConfig>
    {
        /// <summary>
        /// SSCAT script
        /// </summary>
        private SSCATScript _script;

        /// <summary>
        /// Configuration files
        /// </summary>
        private ConfigFiles _files;

        /// <summary>
        /// Initializes a new instance of the ScriptConfig class
        /// </summary>
        public ScriptConfig()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScriptConfig class
        /// </summary>
        /// <param name="script">sscat script</param>
        /// <param name="files">configuration files</param>
        public ScriptConfig(SSCATScript script, ConfigFiles files)
        {
            Script = script;
            Files = files;
        }

        /// <summary>
        /// Gets or sets the configuration files
        /// </summary>
        [XmlElement("Config")]
        public ConfigFiles Files
        {
            get { return _files; }
            set { _files = value; }
        }

        /// <summary>
        /// Gets or sets the script
        /// </summary>
        [XmlElement("Script")]
        public SSCATScript Script
        {
            get { return _script; }
            set { _script = value; }
        }

        /// <summary>
        /// Clears the script
        /// </summary>
        public void Clear()
        {
            _script = null;
        }
    }
}
