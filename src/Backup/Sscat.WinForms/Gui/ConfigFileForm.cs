// <copyright file="ConfigFileForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Gui
{
    using System;
    using Ncr.Core.Gui;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the ConfigFileForm class
    /// </summary>
    public partial class ConfigFileForm : BaseForm
    {
        /// <summary>
        /// Configuration file
        /// </summary>
        private ConfigFile _file;

        /// <summary>
        /// Initializes a new instance of the ConfigFileForm class
        /// </summary>
        public ConfigFileForm()
            : this(new ConfigFile())
        {
        }

        /// <summary>
        /// Initializes a new instance of the ConfigFileForm class
        /// </summary>
        /// <param name="file">configuration file</param>
        public ConfigFileForm(ConfigFile file)
        {
            InitializeComponent();
            File = file;
        }

        /// <summary>
        /// Event handler for configuration save
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> ConfigSave;

        /// <summary>
        /// Gets or sets the configuration file
        /// </summary>
        public ConfigFile File
        {
            get
            {
                _file.Name = textBoxName.Text;
                _file.Host = textBoxHost.Text;
                _file.Path = textBoxPath.Text;
                return _file;
            }

            set
            {
                _file = value;
                textBoxName.Text = _file.Name;
                textBoxHost.Text = _file.Host;
                textBoxPath.Text = _file.Path;
            }
        }

        /// <summary>
        /// Click the save button
        /// </summary>
        public void Save()
        {
            ButtonOkClick(this, null);
        }

        /// <summary>
        /// Event for on configuration save
        /// </summary>
        /// <param name="e">configuration file event arguments</param>
        protected virtual void OnConfigSave(ConfigFileEventArgs e)
        {
            if (ConfigSave != null)
            {
                ConfigSave(this, e);
            }
        }

        /// <summary>
        /// Event for clicking the save configuration button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonOkClick(object sender, EventArgs e)
        {
            OnConfigSave(new ConfigFileEventArgs(File));
        }

        /// <summary>
        /// Event for clicking the cancel button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
