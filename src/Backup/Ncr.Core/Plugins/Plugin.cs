// <copyright file="Plugin.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Plugins
{
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the Plugin class
    /// </summary>
    [XmlRoot("Plugin")]
    public class Plugin : BaseSerializable<Plugin>
    {
        /// <summary>
        /// Plugin name
        /// </summary>
        private string _name;

        /// <summary>
        /// Plugin author
        /// </summary>
        private string _author;

        /// <summary>
        /// Plugin main menu
        /// </summary>
        private PluginMainMenu _mainMenu;

        /// <summary>
        /// Plugin description
        /// </summary>
        private string _description;

        /// <summary>
        /// Plugin tool bar
        /// </summary>
        private PluginToolBar _toolBar;

        /// <summary>
        /// Plugin status bar
        /// </summary>
        private PluginStatusBar _statusBar;

        /// <summary>
        /// Initializes a new instance of the Plugin class
        /// </summary>
        public Plugin()
        {
        }

        /// <summary>
        /// Gets or sets the status bar
        /// </summary>
        [XmlElement("StatusBar")]
        public PluginStatusBar StatusBar
        {
            get { return _statusBar; }
            set { _statusBar = value; }
        }

        /// <summary>
        /// Gets or sets the tool bar
        /// </summary>
        [XmlElement("ToolBar")]
        public PluginToolBar ToolBar
        {
            get { return _toolBar; }
            set { _toolBar = value; }
        }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        [XmlAttribute("Description")]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Gets or sets the main menu
        /// </summary>
        [XmlElement("MainMenu")]
        public PluginMainMenu MainMenu
        {
            get { return _mainMenu; }
            set { _mainMenu = value; }
        }

        /// <summary>
        /// Gets or sets the author
        /// </summary>
        [XmlAttribute("Author")]
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Load the plugin file
        /// </summary>
        /// <param name="file">file to load</param>
        /// <returns>Returns the plugin</returns>
        public static Plugin Load(string file)
        {
            return Load(new StreamReader(file));
        }

        /// <summary>
        /// Loads the plugin text reader
        /// </summary>
        /// <param name="reader">text reader</param>
        /// <returns>Returns the plugin</returns>
        public static Plugin Load(TextReader reader)
        {
            return Deserialize(reader);
        }

        /// <summary>
        /// Create the menu
        /// </summary>
        /// <returns>Returns the menu strip</returns>
        public MenuStrip CreateMenu()
        {
            if (_mainMenu != null)
            {
                return _mainMenu.Create();
            }

            return null;
        }

        /// <summary>
        /// Create the tool bar
        /// </summary>
        /// <returns>Returns the control</returns>
        public Control CreateToolBar()
        {
            if (_toolBar != null)
            {
                return _toolBar.Create();
            }

            return null;
        }

        /// <summary>
        /// Create status bar
        /// </summary>
        /// <returns>Returns the control</returns>
        public Control CreateStatusBar()
        {
            if (_statusBar != null)
            {
                return _statusBar.Create();
            }

            return null;
        }
    }
}
