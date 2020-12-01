// <copyright file="IApplication.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the IApplication interface
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// Gets a value indicating whether the application has started or not
        /// </summary>
        bool HasStarted { get; }

        /// <summary>
        /// Gets a value indicating whether the application exists or not
        /// </summary>
        bool Exists { get; }

        /// <summary>
        /// Gets the file name
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Gets the process name
        /// </summary>
        string ProcessName { get; }

        /// <summary>
        /// Gets or sets the launch pad
        /// </summary>
        ILaunchPad LaunchPad { get; set; }

        /// <summary>
        /// Start the process
        /// </summary>
        void Start();

        /// <summary>
        /// Kill the process
        /// </summary>
        void Kill();

        /// <summary>
        /// Force Kill the process
        /// </summary>
        void ForceKill();
    }
}
