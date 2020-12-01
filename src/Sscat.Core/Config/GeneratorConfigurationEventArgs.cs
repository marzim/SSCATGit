// <copyright file="GeneratorConfigurationEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;

    /// <summary>
    /// Initializes a new instance of the GeneratorConfigurationEventArgs class
    /// </summary>
    public class GeneratorConfigurationEventArgs : EventArgs
    {
        /// <summary>
        /// Generator configuration
        /// </summary>
        private GeneratorConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the GeneratorConfigurationEventArgs class
        /// </summary>
        /// <param name="config">generator configuration</param>
        public GeneratorConfigurationEventArgs(GeneratorConfiguration config)
        {
            Config = config;
        }

        /// <summary>
        /// Gets or sets the generator configuration
        /// </summary>
        public GeneratorConfiguration Config
        {
            get { return _config; }
            set { _config = value; }
        }
    }
}
