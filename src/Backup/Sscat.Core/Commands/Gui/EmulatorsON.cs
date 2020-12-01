// <copyright file="EmulatorsON.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;

    /// <summary>
    /// Initializes a new instance of the EmulatorsON class
    /// </summary>
    public class EmulatorsON : AbstractCommand
    {
        /// <summary>
        /// SSCAT Lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Initializes a new instance of the EmulatorsON class
        /// </summary>
        public EmulatorsON()
            : this(SscatContext.Lane)
        {
        }

        /// <summary>
        /// Initializes a new instance of the EmulatorsON class
        /// </summary>
        /// <param name="lane">sscat lane</param>
        public EmulatorsON(SscatLane lane)
        {
            _lane = lane;
        }

        /// <summary>
        /// Gets a value indicating whether the emulators can run
        /// </summary>
        public override bool CanRun
        {
            get
            {
                bool hasCADDConfigure = FileHelper.Exists(@"c:\scot\bin\CADDConfigure.exe");
                if (hasCADDConfigure && _lane.IsCADD)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Terminates SSCO and then turns on the emulators
        /// </summary>
        public override void Run()
        {
            try
            {
                SscatLane lane = SscatContext.Lane;
                if (lane.HasStarted)
                {
                    DialogResult dialogResult = MessageService.ShowYesNoCancel("SSCAT will terminate SSCO before turning ON the emulators. Would you like to re-launch the SSCO after turning ON the emulators?");
                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            lane.ForceKill();
                            ProcessUtility.Start(new ProcessStartInfo(Path.Combine(ApplicationUtility.ToolsDirectory, "ConfigEmulatorsON.bat")), true);
                            lane.Start();
                            break;
                        case DialogResult.No:
                            lane.ForceKill();
                            ProcessUtility.Start(new ProcessStartInfo(Path.Combine(ApplicationUtility.ToolsDirectory, "ConfigEmulatorsON.bat")), true);
                            MessageService.ShowInfo("Done turning ON the emulators.");
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
                else
                {
                    ProcessUtility.Start(new ProcessStartInfo(Path.Combine(ApplicationUtility.ToolsDirectory, "ConfigEmulatorsON.bat")), true);
                    MessageService.ShowInfo("Done turning ON the emulators.");
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
        }
    }
}
