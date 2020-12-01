// <copyright file="LaunchCaddConfigure.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using Ncr.Core.Commands;
    using Ncr.Core.PInvoke;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;

    /// <summary>
    /// Initializes a new instance of the LaunchCaddConfigure class
    /// </summary>
    public class LaunchCaddConfigure : AbstractCommand
    {
        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Initializes a new instance of the LaunchCaddConfigure class
        /// </summary>
        public LaunchCaddConfigure()
            : this(SscatContext.Lane)
        {
        }

        /// <summary>
        /// Initializes a new instance of the LaunchCaddConfigure class
        /// </summary>
        /// <param name="lane">sscat lane</param>
        public LaunchCaddConfigure(SscatLane lane)
        {
            _lane = lane;
        }

        /// <summary>
        /// Gets a value indicating whether cadd configure exists
        /// </summary>
        public override bool CanRun
        {
            get
            {
                bool hasCADDConfigure = FileHelper.Exists(@"c:\scot\bin\CADDConfigure.exe");
                if (hasCADDConfigure && _lane.IsCADD)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Runs the CADD configuration process
        /// </summary>
        public override void Run()
        {
            if (ProcessUtility.HasStarted("CADDConfigure"))
            {
                IntPtr handle = ApiHelper.FindWindow("Afx:00400000:3:00010003:00000006:001E0183", "CADDConfigure Setup");
                ApiHelper.SetForegroundWindow(handle);
                ApiHelper.SendMessage(handle, User32.WM_SETFOCUS, 0, 0);
            }
            else
            {
                ProcessUtility.Start(@"c:\scot\bin\CADDConfigure.exe");
            }
        }
    }
}
