// <copyright file="ConsoleClientConfigurationView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Views
{
    using System;
    using Ncr.Core.Views;
    using Sscat.Core.Config;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ConsoleClientConfigurationView class
    /// </summary>
    public class ConsoleClientConfigurationView : BaseConsoleView, IClientConfigurationView
    {
        /// <summary>
        /// Instance of the Client Configuration class
        /// </summary>
        private ClientConfiguration _config;

        /// <summary>
        /// Event handler for the save configuration
        /// </summary>
        public event EventHandler<ClientConfigurationEventArgs> ConfigurationSave;

        /// <summary>
        /// Event handler for default restore configuration
        /// </summary>
        public event EventHandler ConfigurationDefaultRestore;

        /// <summary>
        /// Event handler for changed configuration
        /// </summary>
        public event EventHandler<ClientConfigurationEventArgs> ConfigurationChanged;

        /// <summary>
        /// Gets or sets the client configuration
        /// </summary>
        public ClientConfiguration Configuration
        {
            get
            {
                return _config;
            }

            set
            {
                _config = value;
                OnConfigurationChanged(new ClientConfigurationEventArgs(_config));
            }
        }

        /// <summary>
        /// Restores configuration to default
        /// </summary>
        public void Restore()
        {
            OnConfigurationDefaultRestore(null);
        }

        /// <summary>
        /// Saves the current configuration
        /// </summary>
        public void Save()
        {
            OnConfigurationSave(new ClientConfigurationEventArgs(Configuration));
        }

        /// <summary>
        /// Handles configuration changed
        /// </summary>
        /// <param name="e">client configuration event arguments</param>
        protected virtual void OnConfigurationChanged(ClientConfigurationEventArgs e)
        {
            if (ConfigurationChanged != null)
            {
                ConfigurationChanged(this, e);
            }
        }

        /// <summary>
        /// Handles configuration save
        /// </summary>
        /// <param name="e">client configuration event arguments</param>
        protected virtual void OnConfigurationSave(ClientConfigurationEventArgs e)
        {
            if (ConfigurationSave != null)
            {
                ConfigurationSave(this, e);
            }
        }

        /// <summary>
        /// Handles configuration being restored to default
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConfigurationDefaultRestore(EventArgs e)
        {
            if (ConfigurationDefaultRestore != null)
            {
                ConfigurationDefaultRestore(this, e);
            }
        }
    }
}
