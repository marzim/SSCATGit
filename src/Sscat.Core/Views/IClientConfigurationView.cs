// <copyright file="IClientConfigurationView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System;
    using Ncr.Core.Views;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the IClientConfigurationView interface
    /// </summary>
    public interface IClientConfigurationView : IView
    {
        /// <summary>
        /// Event handler for configuration save
        /// </summary>
        event EventHandler<ClientConfigurationEventArgs> ConfigurationSave;

        /// <summary>
        /// Event handler for configuration default restore
        /// </summary>
        event EventHandler ConfigurationDefaultRestore;

        /// <summary>
        /// Event handler for configuration changed
        /// </summary>
        event EventHandler<ClientConfigurationEventArgs> ConfigurationChanged;

        /// <summary>
        /// Gets or sets the client configuration
        /// </summary>
        ClientConfiguration Configuration { get; set; }

        /// <summary>
        /// Saves the configuration
        /// </summary>
        void Save();

        /// <summary>
        /// Restores the configuration
        /// </summary>
        void Restore();
    }
}
