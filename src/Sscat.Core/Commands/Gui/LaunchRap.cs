// <copyright file="LaunchRap.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using Ncr.Core.Commands;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the LaunchRap class
    /// </summary>
    public class LaunchRap : AbstractCommand
    {
        /// <summary>
        /// The RAP to launch
        /// </summary>
        private Rap _rap;

        /// <summary>
        /// Initializes a new instance of the LaunchRap class
        /// </summary>
        public LaunchRap()
            : this(new Rap())
        {
        }

        /// <summary>
        /// Initializes a new instance of the LaunchRap class
        /// </summary>
        /// <param name="rap">the RAP</param>
        public LaunchRap(Rap rap)
        {
            _rap = rap;
        }

        /// <summary>
        /// Gets a value indicating whether the RAP net exists
        /// </summary>
        public override bool CanRun
        {
            get { return FileHelper.Exists(@"C:\scot\bin\RapNet.exe"); }
        }

        /// <summary>
        /// Launches the RAP
        /// </summary>
        public override void Run()
        {
            try
            {
                LaunchPad pad = new LaunchPad(new DefaultLaunchPadLauncher(), _rap, new StoreServer());
                pad.Start();
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowInfo(ex.Message);
            }
        }
    }
}
