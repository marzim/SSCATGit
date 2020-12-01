// <copyright file="ConfigFileListViewItem.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System.Windows.Forms;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the ConfigFileListViewItem class
    /// </summary>
    public class ConfigFileListViewItem : ListViewItem
    {
        /// <summary>
        /// Configuration File
        /// </summary>
        private ConfigFile _configFile;

        /// <summary>
        /// Initializes a new instance of the ConfigFileListViewItem class
        /// </summary>
        /// <param name="configFile">configuration file</param>
        public ConfigFileListViewItem(ConfigFile configFile)
        {
            File = configFile;
        }

        /// <summary>
        /// Finalizes an instance of the ConfigFileListViewItem class
        /// </summary>
        ~ConfigFileListViewItem()
        {
        }

        /// <summary>
        /// Gets or sets the configuration file
        /// </summary>
        public ConfigFile File
        {
            get
            {
                return _configFile;
            }

            set
            {
                _configFile = value;
                Text = _configFile.Name;

                SubItems.Add(string.Empty);
                SubItems.Add(string.Empty);
                SubItems.Add(string.Empty);
                SubItems.Add(string.Empty);
            }
        }
    }
}
