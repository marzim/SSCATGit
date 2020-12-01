// <copyright file="SscatLaunchPad.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the SscatLaunchPad class
    /// </summary>
    public class SscatLaunchPad : LaunchPad, ISscatLaunchPad
    {
        /// <summary>
        /// Launchpad event path
        /// </summary>
        private readonly string _launchpadEventPath = @"c:\sscat\bin\launchpadpsxevent.txt";

        /// <summary>
        /// Initializes a new instance of the SscatLaunchPad class
        /// </summary>
        /// <param name="launcher">launchpad launcher</param>
        /// <param name="application">the application</param>
        /// <param name="storeServer">store server</param>
        public SscatLaunchPad(ILaunchPadLauncher launcher, IApplication application, StoreServer storeServer)
            : base(launcher, application, storeServer)
        {
        }

        /// <summary>
        /// Events beyond PSX Clicks
        /// - Checks if Generate Diagnostic Log Files is property working
        /// - Closes Volume Control
        /// - Closes Event Viewer
        /// - Closes Terminal Information
        /// </summary>
        /// <param name="item">PSX Event</param>
        public virtual void PerformLaunchPadEvent(IPsxEvent item)
        {
            switch (item.Control)
            {
                case "RunADDButton":
                case "GenerateLogButton":
                case "EventViewerButton":
                case "StopStartFastLaneButton":
                    FileHelper.Create(_launchpadEventPath, item.Control);
                    break;
                case "TerminalInfoButton":
                    ThreadHelper.Sleep(2000);
                    WindowAppHelper.WindowAppExit("TerminalInfo");
                    break;
                case "VolumeButton":
                    ThreadHelper.Sleep(2000);
                    WindowAppHelper.WindowAppExit("Volume Control");
                    break;
                case "ConfirmYes":
                    switch (WindowAppHelper.GetText(_launchpadEventPath))
                    {
                        case "GenerateLogButton":
                            WindowAppHelper.CheckDiagnosticFile(0, 600000);
                            ThreadHelper.Sleep(2000);
                            WindowAppHelper.WindowAppExit("Get Diagnostics Files Results");
                            break;
                        case "EventViewerButton":
                            ThreadHelper.Sleep(2000);
                            WindowAppHelper.WindowAppExit("Event Viewer");
                            break;
                        case "StopStartFastLaneButton":
                            ThreadHelper.Sleep(60000);
                            break;
                        case "RunADDButton":
                            ThreadHelper.Sleep(5000);
                            break;
                    }

                    FileHelper.Delete(_launchpadEventPath);
                    break;
                case "ConfirmNo":
                    FileHelper.Delete(_launchpadEventPath);
                    break;
            }
        }
    }
}
