// <copyright file="PluginMenu.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Plugins
{
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Ncr.Core.Gui;

    /// <summary>
    /// Initializes a new instance of the PluginMenu class
    /// </summary>
    public class PluginMenu : PluginControl
    {
        /// <summary>
        /// Plugin menus
        /// </summary>
        private PluginMenu[] _menus;

        /// <summary>
        /// Plugin text
        /// </summary>
        private string _text;

        /// <summary>
        /// Plugin image
        /// </summary>
        private string _image;

        /// <summary>
        /// Plugin shortcut
        /// </summary>
        private string _shortcut;

        /// <summary>
        /// Gets or sets the shortcut
        /// </summary>
        [XmlAttribute("Shortcut")]
        public string Shortcut
        {
            get { return _shortcut; }
            set { _shortcut = value; }
        }

        /// <summary>
        /// Gets or sets the image
        /// </summary>
        [XmlAttribute("Image")]
        public string Image
        {
            get { return _image != null ? _image : string.Empty; }
            set { _image = value; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the plugin has menus
        /// </summary>
        public bool HasMenus
        {
            get { return _menus != null && _menus.Length > 0; }
        }

        /// <summary>
        /// Gets or sets the text
        /// </summary>
        [XmlAttribute("Text")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// Gets or sets the menus
        /// </summary>
        [XmlElement("Menu")]
        public PluginMenu[] Menus
        {
            get { return _menus; }
            set { _menus = value; }
        }

        /// <summary>
        /// Create the tool strip item
        /// </summary>
        /// <returns>Returns the new tool strip item</returns>
        public ToolStripItem Create()
        {
            if (_text.Equals("-"))
            {
                return new NToolStripSeparator();
            }
            else
            {
                return new NToolStripMenuItem(Text, CreateCommand(), Image, Shortcut);
            }
        }
    }
}
