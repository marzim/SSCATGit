// <copyright file="RunServer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the RunServer class
    /// </summary>
    public class RunServer : AbstractCommand
    {
        /// <summary>
        /// Gets a value indicating whether the SSCAT server can run
        /// </summary>
        public override bool CanRun
        {
            get
            {
                return FileHelper.Exists("Sscat.Server.exe");
            }
        }

        /// <summary>
        /// Runs the SSCAT server if it hasn't already been started
        /// </summary>
        public override void Run()
        {
            try
            {
                if (!ProcessUtility.HasStarted("Sscat.Server"))
                {
                    ProcessUtility.Start("Sscat.Server.exe");
                }
                else
                {
                    MessageService.ShowInfo("Another instance is running");
                }
            }
            catch (Exception ex)
            {
                LoggingService.Warning(ex.ToString());
                MessageService.ShowWarning(ex.Message + ". Please check if the server is installed on this machine.");
            }
        }
    }
}
