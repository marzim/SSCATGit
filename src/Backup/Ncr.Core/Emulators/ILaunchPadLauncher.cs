// <copyright file="ILaunchPadLauncher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the ILaunchPadLauncher interface
    /// </summary>
    public interface ILaunchPadLauncher
    {
        /// <summary>
        /// Gets or sets the application
        /// </summary>
        IApplication Application { get; set; }

        /// <summary>
        /// Start the process
        /// </summary>
        void Start();

        /// <summary>
        /// Kill the process
        /// </summary>
        void Kill();
    }
}
