// <copyright file="PlaylistEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;

    /// <summary>
    /// Initializes a new instance of the PlaylistEventArgs class
    /// </summary>
    public class PlaylistEventArgs : EventArgs
    {
        /// <summary>
        /// Current Playlist
        /// </summary>
        private Playlist _playlist;

        /// <summary>
        /// Initializes a new instance of the PlaylistEventArgs class
        /// </summary>
        /// <param name="playlist">current playlist</param>
        public PlaylistEventArgs(Playlist playlist)
        {
            Playlist = playlist;
        }

        /// <summary>
        /// Gets or sets the playlist
        /// </summary>
        public Playlist Playlist
        {
            get { return _playlist; }
            set { _playlist = value; }
        }
    }
}
