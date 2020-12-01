// <copyright file="ToggleEmulators.cs" company="NCR">
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
    /// Initializes a new instance of the ToggleEmulators class
    /// </summary>
    public class ToggleEmulators : AbstractCommand
    {
        /// <summary>
        /// Gets a value indicating whether the scot app can run
        /// </summary>
        public override bool CanRun
        {
            get { return FileHelper.Exists(@"c:\scot\bin\scotapp.exe"); }
        }

        /// <summary>
        /// Toggles the emulators on or off depending on the current setting
        /// </summary>
        public override void Run()
        {
            try
            {
                SscatLane lane = SscatContext.Lane;
                if (lane.HasStarted)
                {
                    lane.ForceKill();
                }

                string filename;
                ToolStripMenuItem item = Owner as ToolStripMenuItem;
                if (item != null && !item.Checked)
                {
                    filename = Path.Combine(ApplicationUtility.ToolsDirectory, "ConfigEmulatorsON.bat");
                }
                else
                {
                    filename = Path.Combine(ApplicationUtility.ToolsDirectory, "Config_EmulatorsOFF.bat");
                }

                ProcessUtility.Start(new ProcessStartInfo(filename), true);
                if (item != null)
                {
                    item.Checked = !item.Checked;
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
