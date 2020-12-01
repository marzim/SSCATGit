// <copyright file="IPlaylistListView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using Ncr.Core.Views;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the IPlaylistListView interface
    /// </summary>
    public interface IPlaylistListView : IView
    {
        /// <summary>
        /// Add the given playlist
        /// </summary>
        /// <param name="playlist">playlist to add</param>
        void AddPlaylist(IPlaylist playlist);
    }
}
