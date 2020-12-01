// <copyright file="XmlSSCATScriptRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories.Xml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Ncr.Core;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the XmlSSCATScriptRepository class
    /// </summary>
    public class XmlSSCATScriptRepository : BaseXmlRepository<IScript>, IScriptRepository
    {
        /// <summary>
        /// Initializes a new instance of the XmlSSCATScriptRepository class
        /// </summary>
        public XmlSSCATScriptRepository()
            : base()
        {
        }

        /// <summary>
        /// Save script
        /// </summary>
        /// <param name="script">script to save</param>
        public virtual void Save(IScript script)
        {
            OnAccessing(new NcrEventArgs(script.FileName));
            Serialize(script.FileName, script);
        }

        /// <summary>
        /// Save scripts
        /// </summary>
        /// <param name="scripts">scripts to save</param>
        public void Save(IScript[] scripts)
        {
            foreach (IScript script in scripts)
            {
                Save(script);
            }

            OnAccessing(new NcrEventArgs(string.Format("{0} script(s) created/updated", scripts.Length)));
        }

        /// <summary>
        /// Read script
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the script</returns>
        public virtual IScript Read(string filename)
        {
            IScript script = null;

            try
            {
                script = Read(new StreamReader(filename));
                script.FileName = filename;
            }
            catch
            {
                throw new Exception(string.Format("Could not find file '{0}'! ", filename));
            }

            return script;
        }

        /// <summary>
        /// Read script
        /// </summary>
        /// <param name="reader">text reader</param>
        /// <returns>Returns the script</returns>
        public IScript Read(TextReader reader)
        {
            SSCATScript script = CreateXmlSerializer().Deserialize(reader);
            script.Events.AddEvents(script.ScriptEvents);
            return script;
        }

        /// <summary>
        /// Get scripts
        /// </summary>
        /// <param name="args">method arguments</param>
        /// <returns>Returns the script files</returns>
        public List<ScriptFile> GetScripts(string[] args)
        {
            return GetScripts(args, 2);
        }

        /// <summary>
        /// Get scripts
        /// </summary>
        /// <param name="args">method arguments</param>
        /// <param name="scriptsStartIndex">minimum length of arguments to get scripts</param>
        /// <returns>Returns the script files</returns>
        public List<ScriptFile> GetScripts(string[] args, int scriptsStartIndex)
        {
            List<ScriptFile> scripts = new List<ScriptFile>();
            List<string> filenames = new List<string>();
            
            if (args.Length > scriptsStartIndex)
            {
                filenames.AddRange(DirectoryHelper.GetFiles(DirectoryHelper.GetCurrentDirectory(), "*.xml"));
                if (args[scriptsStartIndex] == "*")
                {
                    foreach (string filename in filenames)
                    {
                        scripts.Add(new ScriptFile(filename));
                    }
                }
                else
                {
                    for (int i = scriptsStartIndex; i < args.Length; i++)
                    {
                        string filename;

                        if (!FileHelper.Exists(args[i]) && ConvertUtility.ValidInteger(args[i]))
                        {
                            filename = filenames[ConvertUtility.ToInt32(args[i])];
                        }
                        else
                        {
                            filename = args[i];
                        }

                        scripts.Add(new ScriptFile(filename));
                    }
                }
            }

            return scripts;
        }

        /// <summary>
        /// Read scripts
        /// </summary>
        /// <param name="directory">script directory</param>
        /// <param name="searchPattern">search pattern</param>
        /// <param name="scripts">sscat scripts</param>
        public virtual void ReadScripts(string directory, string searchPattern, IList<IScript> scripts)
        {
            foreach (string currentDirectory in Directory.GetDirectories(directory))
            {
                foreach (string filename in Directory.GetFiles(currentDirectory, searchPattern))
                {
                    scripts.Add(CreateXmlSerializer().Deserialize(filename));
                }

                ReadScripts(currentDirectory, searchPattern, scripts);
            }
        }

        /// <summary>
        /// Creates the XML Serializer
        /// </summary>
        /// <returns>Returns the XML serializer</returns>
        protected virtual XmlSerializer<SSCATScript> CreateXmlSerializer()
        {
            return new XmlSerializer<SSCATScript>();
        }
    }
}
