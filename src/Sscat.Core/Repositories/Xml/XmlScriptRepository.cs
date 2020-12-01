// <copyright file="XmlScriptRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories.Xml
{
    using System.Collections.Generic;
    using System.IO;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the XmlScriptRepository class
    /// </summary>
    public class XmlScriptRepository : XmlSSCATScriptRepository
    {
        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>Returns the script</returns>
        public override IScript Read(string file)
        {
            return CreateXmlSerializer().Deserialize(file);
        }

        /// <summary>
        /// Read scripts
        /// </summary>
        /// <param name="dir">script directory</param>
        /// <param name="searchPattern">search patterns</param>
        /// <param name="scripts">sscat scripts</param>
        public override void ReadScripts(string dir, string searchPattern, IList<IScript> scripts)
        {
            foreach (string d in Directory.GetDirectories(dir))
            {
                foreach (string filename in Directory.GetFiles(d, searchPattern))
                {
                    scripts.Add(CreateXmlSerializer().Deserialize(filename));
                }

                ReadScripts(d, searchPattern, scripts);
            }
        }

        /// <summary>
        /// Create XML serializer
        /// </summary>
        /// <returns>Returns the XML serializer</returns>
        protected new XmlSerializer<SSCATScript> CreateXmlSerializer()
        {
            return new XmlSerializer<SSCATScript>();
        }
    }
}
