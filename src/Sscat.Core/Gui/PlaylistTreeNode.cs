// <copyright file="PlaylistTreeNode.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System.Windows.Forms;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the PlaylistTreeNode class
    /// </summary>
    public class PlaylistTreeNode : TreeNode
    {
        /// <summary>
        /// Playlist image index
        /// </summary>
        public const int PLAYLIST_IMAGE_INDEX = 0;

        /// <summary>
        /// Script image index
        /// </summary>
        public const int SCRIPT_IMAGE_INDEX = 1;

        /// <summary>
        /// Script event image index
        /// </summary>
        public const int SCRIPT_EVENT_IMAGE_INDEX = 2;

        /// <summary>
        /// Play list
        /// </summary>
        private Playlist _playlist;

        /// <summary>
        /// Initializes a new instance of the PlaylistTreeNode class
        /// </summary>
        /// <param name="playlist">play list</param>
        /// <param name="imageIndex">image index</param>
        public PlaylistTreeNode(Playlist playlist, int imageIndex)
        {
            Playlist = playlist;
            ImageIndex = SelectedImageIndex = imageIndex;
        }

        /// <summary>
        /// Gets or sets the play list
        /// </summary>
        public Playlist Playlist
        {
            get
            {
                return _playlist;
            }

            set
            {
                _playlist = value;
                Text = _playlist.Name;
            }
        }
    }
}
