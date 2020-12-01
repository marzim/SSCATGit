// <copyright file="SSCATScripts.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the SSCATScripts class
    /// </summary>
    [XmlRoot("SSCATScripts"), Serializable()]
    public class SSCATScripts : BaseSerializable<SSCATScripts>
    {
        /// <summary>
        /// SSCAT scripts
        /// </summary>
        private SSCATScript[] _scripts;

        /// <summary>
        /// Initializes a new instance of the SSCATScripts class
        /// </summary>
        public SSCATScripts()
        {
        }

        /// <summary>
        /// Initializes a new instance of the SSCATScripts class
        /// </summary>
        /// <param name="scripts">sscat scripts</param>
        public SSCATScripts(SSCATScript[] scripts)
        {
            Scripts = scripts;
        }

        /// <summary>
        /// Gets or sets the scripts
        /// </summary>
        [XmlElement("Script")]
        public SSCATScript[] Scripts
        {
            get
            {
                if (_scripts == null)
                {
                    _scripts = new SSCATScript[0];
                }

                return _scripts;
            }

            set
            {
                _scripts = value;
            }
        }

        /// <summary>
        /// Adds scripts
        /// </summary>
        /// <param name="scripts">script to add</param>
        public void AddScripts(IScript[] scripts)
        {
            foreach (IScript script in scripts)
            {
                AddScript(script);
            }
        }

        /// <summary>
        /// Adds a single script
        /// </summary>
        /// <param name="script">script to add</param>
        private void AddScript(IScript script)
        {
            List<IScript> a = new List<IScript>(Scripts);
            a.Add(script);
            _scripts = new SSCATScript[a.Count];
            a.CopyTo(_scripts);
        }
    }
}
