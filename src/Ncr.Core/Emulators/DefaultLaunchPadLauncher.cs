// <copyright file="DefaultLaunchPadLauncher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the DefaultLaunchPadLauncher class
    /// </summary>
    public class DefaultLaunchPadLauncher : BaseLaunchPadLauncher
    {
        /// <summary>
        /// Gets the launchpad
        /// </summary>
        public ILaunchPad LaunchPad
        {
            get { return Application as ILaunchPad; }
        }

        /// <summary>
        /// Starts the launch process
        /// </summary>
        public override void Start()
        {
            if (!ProcessUtility.HasStarted("LaunchPadNet") && !(ProcessUtility.HasStarted("ScotAppU") || ProcessUtility.HasStarted("SCOTApp") || ProcessUtility.HasStarted("RapNet")))
            {
                LaunchPad.Application.Start();
            }
            else if (!ProcessUtility.HasStarted("LaunchPadNet") && (ProcessUtility.HasStarted("ScotAppU") || ProcessUtility.HasStarted("SCOTApp") || ProcessUtility.HasStarted("RapNet")))
            {
                Kill();
                LaunchPad.Application.Start();
            }
            else if (ProcessUtility.HasStarted("LaunchPadNet") && !(ProcessUtility.HasStarted("ScotAppU") || ProcessUtility.HasStarted("SCOTApp") || ProcessUtility.HasStarted("RapNet")))
            {
                int now = Environment.TickCount;
                while ((Environment.TickCount - now) < 80000)
                {
                    if (ProcessUtility.HasStarted("ScotAppU"))
                    {
                        break;
                    }

                    LoggingService.Info("Waiting for ScotAppu to start...");
                    ThreadHelper.Sleep(5000);
                }

                Kill();
                LaunchPad.Application.Start();
            }

            if (LaunchPad.StoreServer.Exists && !LaunchPad.StoreServer.HasStarted)
            {
                ProcessUtility.Start(new ProcessStartInfo(Path.Combine(ApplicationUtility.ToolsDirectory, "startsec45.bat")), true);
                LaunchPad.StoreServer.Start();
            }
        }

        /// <summary>
        /// Kill the processes
        /// </summary>
        public override void Kill()
        {
            ProcessUtility.Start(new ProcessStartInfo(Path.Combine(ApplicationUtility.ToolsDirectory, "stoplane.bat")), true);
            if (LaunchPad.StoreServer.Exists)
            {
                ProcessUtility.Start(new ProcessStartInfo(Path.Combine(ApplicationUtility.ToolsDirectory, "stopsec45.bat")), true);
                LaunchPad.StoreServer.Kill();
            }
        }
    }
}
