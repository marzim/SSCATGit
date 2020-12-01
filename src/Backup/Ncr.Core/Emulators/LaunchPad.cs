// <copyright file="LaunchPad.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the LaunchPad class
    /// </summary>
    public class LaunchPad : Emulator, ILaunchPad
    {
        /// <summary>
        /// Application interface
        /// </summary>
        private IApplication _application;

        /// <summary>
        /// Store server
        /// </summary>
        private StoreServer _storeServer;

        /// <summary>
        /// Launch pad launcher interface
        /// </summary>
        private ILaunchPadLauncher _launcher;

        /// <summary>
        /// Initializes a new instance of the LaunchPad class
        /// </summary>
        /// <param name="launcher">Launch pad launcher</param>
        /// <param name="application">Application interface</param>
        /// <param name="storeServer">Store server</param>
        public LaunchPad(ILaunchPadLauncher launcher, IApplication application, StoreServer storeServer)
            : base("UIControlWindowClass", Emulator.LaunchPadNetCaption)
        {
            Application = application;
            StoreServer = storeServer;
            Launcher = launcher;

            storeServer.Emulating += new EventHandler<EmulatorEventArgs>(StoreServerEmulating);
        }

        /// <summary>
        /// Finalizes an instance of the LaunchPad class
        /// </summary>
        ~LaunchPad()
        {
            StoreServer.Emulating -= new EventHandler<EmulatorEventArgs>(StoreServerEmulating);
        }

        /// <summary>
        /// Event handler for started
        /// </summary>
        public event EventHandler Started;

        /// <summary>
        /// Gets or sets the store server
        /// </summary>
        public StoreServer StoreServer
        {
            get { return _storeServer; }
            set { _storeServer = value; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the launch pad has application
        /// </summary>
        public bool HasApplication
        {
            get { return Application != null; }
        }

        /// <summary>
        /// Gets or sets the launch pad launcher
        /// </summary>
        public ILaunchPadLauncher Launcher
        {
            get
            {
                return _launcher;
            }

            set
            {
                _launcher = value;
                _launcher.Application = this;
            }
        }

        /// <summary>
        /// Gets or sets the application
        /// </summary>
        public IApplication Application
        {
            get { return _application; }
            set { _application = value; }
        }

        /// <summary>
        /// Gets the file name
        /// </summary>
        public override string FileName
        {
            get { return @"C:\scot\bin\LaunchPadNet.exe"; }
        }

        /// <summary>
        /// Starts the launch pad
        /// </summary>
        public override void Start()
        {
            OnEmulating("Starting LaunchPad");
            Launcher.Start();
            OnStarted(null);
        }

        /// <summary>
        /// Kills the launch pad
        /// </summary>
        public override void Kill()
        {
            OnEmulating("Stopping LaunchPad");
            Launcher.Kill();
        }

        /// <summary>
        /// Event for on started
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStarted(EventArgs e)
        {
            if (Started != null)
            {
                Started(this, e);
            }
        }

        /// <summary>
        /// Event for store server emulating
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">emulator event arguments</param>
        private void StoreServerEmulating(object sender, EmulatorEventArgs e)
        {
            OnEmulating(e);
        }
    }
}
