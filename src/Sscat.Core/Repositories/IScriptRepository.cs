// <copyright file="IScriptRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using System.Collections.Generic;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the IScriptRepository interface
    /// </summary>
    public interface IScriptRepository : IRepository
    {
        /// <summary>
        /// Saves the script
        /// </summary>
        /// <param name="script">script to save</param>
        void Save(IScript script);

        /// <summary>
        /// Saves the scripts
        /// </summary>
        /// <param name="scripts">scripts to save</param>
        void Save(IScript[] scripts);

        /// <summary>
        /// Reads the file and creates a script
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>Returns the script</returns>
        IScript Read(string file);

        /// <summary>
        /// Get scripts
        /// </summary>
        /// <param name="args">script arguments</param>
        /// <returns>Returns the script files</returns>
        List<ScriptFile> GetScripts(string[] args);

        /// <summary>
        /// Get scripts
        /// </summary>
        /// <param name="args">script arguments</param>
        /// <param name="length">length of arguments</param>
        /// <returns>Returns the script files</returns>
        List<ScriptFile> GetScripts(string[] args, int length);

        /// <summary>
        /// Read scripts
        /// </summary>
        /// <param name="dir">script directory</param>
        /// <param name="searchPattern">search pattern</param>
        /// <param name="scripts">scripts to read</param>
        void ReadScripts(string dir, string searchPattern, IList<IScript> scripts);
    }
}
