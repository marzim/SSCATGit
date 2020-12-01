// <copyright file="BaseLaunchPadLauncher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the BaseLaunchPadLauncher class
    /// </summary>
    public class BaseLaunchPadLauncher : ILaunchPadLauncher
    {
        /// <summary>
        /// Application interface
        /// </summary>
        private IApplication _application;

        /// <summary>
        /// Gets or sets the application
        /// </summary>
        public IApplication Application
        {
            get { return _application; }
            set { _application = value; }
        }

        /// <summary>
        /// Start the process
        /// </summary>
        public virtual void Start()
        {
            ProcessUtility.Start(Application.FileName);
        }

        /// <summary>
        /// Kill the process
        /// </summary>
        public virtual void Kill()
        {
            ProcessUtility.Kill(Application.ProcessName, true);
        }
    }
}
