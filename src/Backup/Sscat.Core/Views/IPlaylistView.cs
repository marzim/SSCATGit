// <copyright file="IPlaylistView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System;
    using Ncr.Core.Views;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the IPlaylistView interface
    /// </summary>
    public interface IPlaylistView : IView
    {
        /// <summary>
        /// Event handler for playlist save
        /// </summary>
        event EventHandler<PlaylistEventArgs> PlaylistSave;

        /// <summary>
        /// Event handler for playlist playing
        /// </summary>
        event EventHandler<PlaylistEventArgs> Playing;

        /// <summary>
        /// Event handler for playlist playing on server
        /// </summary>
        event EventHandler<PlaylistEventArgs> PlayingOnServer;

        /// <summary>
        /// Event handler for generating 
        /// </summary>
        event EventHandler Generating;

        /// <summary>
        /// Event handler for generating on server
        /// </summary>
        event EventHandler GeneratingOnServer;

        /// <summary>
        /// Event handler for connecting
        /// </summary>
        event EventHandler Connecting;

        /// <summary>
        /// Gets or sets the playlist
        /// </summary>
        Playlist Playlist { get; set; }

        /// <summary>
        /// Connect the playlist
        /// </summary>
        void Connect();

        /// <summary>
        /// Save the playlist
        /// </summary>
        void Save();

        /// <summary>
        /// Play the playlist
        /// </summary>
        void Play();

        /// <summary>
        /// Generate the playlist
        /// </summary>
        void Generate();

        /// <summary>
        /// Play on the server
        /// </summary>
        void PlayOnServer();

        /// <summary>
        /// Generate on the server
        /// </summary>
        void GenerateOnServer();

        /// <summary>
        /// Write the given text
        /// </summary>
        /// <param name="text">text to write</param>
        void WriteLine(string text);
    }
}
