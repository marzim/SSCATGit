// <copyright file="ScriptEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptEventArgs class
    /// </summary>
    public class ScriptEventArgs : EventArgs
    {
        /// <summary>
        /// Interface for the script
        /// </summary>
        private IScript _script;

        /// <summary>
        /// Script file
        /// </summary>
        private ScriptFile _scriptFile;

        /// <summary>
        /// Initializes a new instance of the ScriptEventArgs class
        /// </summary>
        /// <param name="scriptFile">script file</param>
        public ScriptEventArgs(ScriptFile scriptFile)
        {
            ScriptFile = scriptFile;
        }

        /// <summary>
        /// Initializes a new instance of the ScriptEventArgs class
        /// </summary>
        /// <param name="script">script interface</param>
        public ScriptEventArgs(IScript script)
        {
            Script = script;
        }

        /// <summary>
        /// Gets or sets the script file
        /// </summary>
        public ScriptFile ScriptFile
        {
            get { return _scriptFile; }
            set { _scriptFile = value; }
        }

        /// <summary>
        /// Gets or sets the script
        /// </summary>
        public IScript Script
        {
            get { return _script; }
            set { _script = value; }
        }
    }
}
