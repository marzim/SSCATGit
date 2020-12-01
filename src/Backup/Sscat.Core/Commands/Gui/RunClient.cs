// <copyright file="RunClient.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the RunClient class
    /// </summary>
    public class RunClient : AbstractCommand
    {
        /// <summary>
        /// Gets a value indicating whether the sscat client exists and can run
        /// </summary>
        public override bool CanRun
        {
            get
            {
                return FileHelper.Exists("Sscat.WinForms.exe");
            }
        }

        /// <summary>
        /// Runs the SSCAT client
        /// </summary>
        public override void Run()
        {
            try
            {
                ProcessUtility.Start("Sscat.WinForms.exe");
            }
            catch (Exception ex)
            {
                LoggingService.Warning(ex.ToString());
                MessageService.ShowWarning(ex.Message + ". Please check if client is installed and try again.");
            }
        }
    }
}
