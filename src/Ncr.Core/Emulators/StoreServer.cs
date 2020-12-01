// <copyright file="StoreServer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System.IO;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the StoreServer class
    /// </summary>
    public class StoreServer : Emulator
    {
        /// <summary>
        /// Initializes a new instance of the StoreServer class
        /// </summary>
        public StoreServer()
            : base(string.Empty)
        {
        }

        /// <summary>
        /// Gets the installed directory
        /// </summary>
        public string InstalledDirectory
        {
            get { return @"C:\scot\bin"; }
        }

        /// <summary>
        /// Gets the process name
        /// </summary>
        public override string ProcessName
        {
            get { return "java"; }
        }

        /// <summary>
        /// Gets the file name
        /// </summary>
        public override string FileName
        {
            get { return Path.Combine(InstalledDirectory, "SSCOStoreServer.bat"); }
        }

        /// <summary>
        /// Gets the timeout
        /// </summary>
        private int Timeout
        {
            get { return 5000; }
        }

        /// <summary>
        /// Kills the store server
        /// </summary>
        public override void Kill()
        {
            if (Exists)
            {
                OnEmulating("Store server exists. Stopping Store Server");
                base.Kill();
            }
        }

        /// <summary>
        /// Starts the store server
        /// </summary>
        public override void Start()
        {
            if (Exists)
            {
                OnEmulating("Store server exists. Starting Store Server");
                DirectoryHelper.SetCurrentDirectory(InstalledDirectory);
                ProcessUtility.Start(FileName);
                ThreadHelper.Sleep(Timeout);
            }
        }
    }
}
