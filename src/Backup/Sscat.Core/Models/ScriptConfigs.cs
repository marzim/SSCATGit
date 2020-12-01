// <copyright file="ScriptConfigs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the ScriptConfigs class
    /// </summary>
    [XmlRoot("ScriptConfigs"), Serializable()]
    public class ScriptConfigs : BaseSerializable<ScriptConfigs>
    {
        /// <summary>
        /// Script configurations
        /// </summary>
        private ScriptConfig[] _configs;

        /// <summary>
        /// Gets or sets the script configurations
        /// </summary>
        [XmlElement("ScriptConfig")]
        public ScriptConfig[] ScriptConfigurations
        {
            get
            {
                if (_configs == null)
                {
                    return new ScriptConfig[0];
                }

                return _configs;
            }

            set
            {
                _configs = value;
            }
        }

        /// <summary>
        /// Clears the script configurations
        /// </summary>
        public void Clear()
        {
            foreach (ScriptConfig c in ScriptConfigurations)
            {
                c.Clear();
            }

            _configs = new ScriptConfig[0];
        }

        /// <summary>
        /// Add a script configuration
        /// </summary>
        /// <param name="scriptConfiguration">script configuration to add</param>
        public void AddConfig(ScriptConfig scriptConfiguration)
        {
            List<ScriptConfig> configurations = new List<ScriptConfig>(ScriptConfigurations);
            configurations.Add(scriptConfiguration);
            ScriptConfigurations = new ScriptConfig[configurations.Count];
            configurations.CopyTo(ScriptConfigurations);
        }
    }   
}
