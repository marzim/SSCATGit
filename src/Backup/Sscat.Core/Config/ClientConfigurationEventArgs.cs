// <copyright file="ClientConfigurationEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the ClientConfigurationEventArgs class
    /// </summary>
    public class ClientConfigurationEventArgs : EventArgs
    {
        /// <summary>
        /// Client configuration
        /// </summary>
        private ClientConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the ClientConfigurationEventArgs class
        /// </summary>
        /// <param name="configuration">client configuration</param>
        public ClientConfigurationEventArgs(ClientConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets or sets the client configuration
        /// </summary>
        public ClientConfiguration Configuration
        {
            get { return _configuration; }
            set { _configuration = value; }
        }
    }
}
