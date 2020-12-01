// <copyright file="PlaylistScriptEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;

    /// <summary>
    /// Initializes a new instance of the PlaylistScriptEventArgs class
    /// </summary>
    public class PlaylistScriptEventArgs : EventArgs
    {
        /// <summary>
        /// Playlist script
        /// </summary>
        private PlaylistScript _script;

        /// <summary>
        /// Initializes a new instance of the PlaylistScriptEventArgs class
        /// </summary>
        /// <param name="script">playlist script</param>
        public PlaylistScriptEventArgs(PlaylistScript script)
        {
            Script = script;
        }

        /// <summary>
        /// Gets or sets the playlist script
        /// </summary>
        public PlaylistScript Script
        {
            get { return _script; }
            set { _script = value; }
        }
    }
}
