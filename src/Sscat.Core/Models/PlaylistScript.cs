// <copyright file="PlaylistScript.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System.Xml.Serialization;

    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the PlaylistScript class
    /// </summary>
    public class PlaylistScript : IPlaylistScript
    {
        /// <summary>
        /// Playlist script file
        /// </summary>
        private string _file;

        /// <summary>
        /// Interface for the script
        /// </summary>
        private IScript _script;

        /// <summary>
        /// Initializes a new instance of the PlaylistScript class
        /// </summary>
        public PlaylistScript()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PlaylistScript class
        /// </summary>
        /// <param name="script">script to play</param>
        public PlaylistScript(IScript script)
        {
            File = script.FileName;
            Script = script;
        }

        /// <summary>
        /// Initializes a new instance of the PlaylistScript class
        /// </summary>
        /// <param name="file">script file</param>
        public PlaylistScript(string file)
        {
            File = file;
        }

        /// <summary>
        /// Gets or sets the script
        /// </summary>
        [XmlIgnore]
        public IScript Script
        {
            get
            {
                if (_script == null)
                {
                    return SSCATScript.Deserialize(File);
                }

                return _script;
            }

            set
            {
                _script = value;
            }
        }

        /// <summary>
        /// Gets or sets the file
        /// </summary>
        [XmlAttribute("File")]
        public string File
        {
            get { return _file; }
            set { _file = value; }
        }
    }
}
