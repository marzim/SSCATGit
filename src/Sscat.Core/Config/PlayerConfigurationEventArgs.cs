// <copyright file="PlayerConfigurationEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the PlayerConfigurationEventArgs class
    /// </summary>
    public class PlayerConfigurationEventArgs : EventArgs
    {
        /// <summary>
        /// Player configuration
        /// </summary>
        private PlayerConfiguration _config;

        /// <summary>
        /// Script file
        /// </summary>
        private ScriptFile _script;

        /// <summary>
        /// Initializes a new instance of the PlayerConfigurationEventArgs class
        /// </summary>
        /// <param name="config">player configuration</param>
        /// <param name="script">script file</param>
        public PlayerConfigurationEventArgs(PlayerConfiguration config, ScriptFile script)
        {
            Config = config;
            Script = script;
        }

        /// <summary>
        /// Gets or sets the script file
        /// </summary>
        public ScriptFile Script
        {
            get { return _script; }
            set { _script = value; }
        }

        /// <summary>
        /// Gets or sets the player configuration
        /// </summary>
        public PlayerConfiguration Config
        {
            get { return _config; }
            set { _config = value; }
        }
    }
}
