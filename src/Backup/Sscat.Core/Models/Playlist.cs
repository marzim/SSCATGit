// <copyright file="Playlist.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the Playlist class
    /// </summary>
    public class Playlist : BaseSerializable<Playlist>, IPlaylist
    {
        /// <summary>
        /// Playlist count
        /// </summary>
        private static int _count = 0;

        /// <summary>
        /// Playlist name
        /// </summary>
        private string _name;

        /// <summary>
        /// Playlist scripts
        /// </summary>
        private PlaylistScript[] _scripts;

        /// <summary>
        /// Playlist description
        /// </summary>
        private string _description;

        /// <summary>
        /// Initializes a new instance of the Playlist class
        /// </summary>
        public Playlist()
            : this("Untitled" + (_count++).ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the Playlist class
        /// </summary>
        /// <param name="name">playlist name</param>
        public Playlist(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Event handler for adding a script
        /// </summary>
        public event EventHandler<PlaylistScriptEventArgs> ScriptAdded;

        /// <summary>
        /// Gets or sets the playlist description
        /// </summary>
        [XmlAttribute("Description")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Gets or sets the playlist scripts
        /// </summary>
        [XmlElement("Script")]
        public PlaylistScript[] Scripts
        {
            get
            {
                if (_scripts == null)
                {
                    return new PlaylistScript[0];
                }

                return _scripts;
            }

            set
            {
                _scripts = value;
            }
        }

        /// <summary>
        /// Gets or sets the playlist name
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Adds the scripts
        /// </summary>
        /// <param name="files">scripts to add</param>
        public void AddScript(string[] files)
        {
            foreach (string file in files)
            {
                AddScript(file);
            }
        }

        /// <summary>
        /// Adds a script
        /// </summary>
        /// <param name="file">script to add</param>
        public void AddScript(string file)
        {
            AddScript(new PlaylistScript(file));
        }

        /// <summary>
        /// Adds a script
        /// </summary>
        /// <param name="script">script to add</param>
        public void AddScript(IScript script)
        {
            AddScript(new PlaylistScript(script));
        }

        /// <summary>
        /// Adds a script
        /// </summary>
        /// <param name="script">script to add</param>
        public void AddScript(PlaylistScript script)
        {
            List<PlaylistScript> a = new List<PlaylistScript>(Scripts);
            a.Add(script);
            _scripts = new PlaylistScript[a.Count];
            a.CopyTo(_scripts);
            OnScriptAdded(new PlaylistScriptEventArgs(script));
        }

        /// <summary>
        /// Event for adding a script
        /// </summary>
        /// <param name="e">playlist script event arguments</param>
        protected virtual void OnScriptAdded(PlaylistScriptEventArgs e)
        {
            if (ScriptAdded != null)
            {
                ScriptAdded(this, e);
            }
        }
    }
}
