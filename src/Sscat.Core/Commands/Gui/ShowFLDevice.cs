// <copyright file="ShowFLDevice.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System.IO;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ShowFLDevice class
    /// </summary>
    public class ShowFLDevice : AbstractCommand
    {
        /// <summary>
        /// Gets a value indicating whether scot application exists and can run
        /// </summary>
        public override bool CanRun
        {
            get
            {
                return FileHelper.Exists(@"C:\scot\bin\ScotApp.exe");
            }
        }

        /// <summary>
        /// Runs the fast lane device
        /// </summary>
        public override void Run()
        {
            ProcessUtility.Start(Path.Combine(ApplicationUtility.ToolsDirectory, "fldevice.exe"));
        }
    }
}
