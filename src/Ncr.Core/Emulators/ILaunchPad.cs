// <copyright file="ILaunchPad.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ILaunchPad interface
    /// </summary>
    public interface ILaunchPad : IEmulator
    {
        /// <summary>
        /// Event handler for started
        /// </summary>
        event EventHandler Started;

        /// <summary>
        /// Gets or sets the application
        /// </summary>
        IApplication Application { get; set; }

        /// <summary>
        /// Gets a value indicating whether or not the launch pad has application
        /// </summary>
        bool HasApplication { get; }

        /// <summary>
        /// Gets or sets the store server
        /// </summary>
        StoreServer StoreServer { get; set; }
    }
}
