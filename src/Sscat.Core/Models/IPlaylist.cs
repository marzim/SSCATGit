// <copyright file="IPlaylist.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    /// <summary>
    /// Interface for the playlist
    /// </summary>
    public interface IPlaylist
    {
        /// <summary>
        /// Gets or sets the Playlist description
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the Playlist name
        /// </summary>
        string Name { get; set; }
    }
}
