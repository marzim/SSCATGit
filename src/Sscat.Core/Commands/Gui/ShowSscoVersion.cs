// <copyright file="ShowSscoVersion.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;

    /// <summary>
    /// Initializes a new instance of the ShowSscoVersion class
    /// </summary>
    public class ShowSscoVersion : AbstractCommand
    {
        /// <summary>
        /// Initializes a new instance of the ShowSscoVersion class
        /// </summary>
        public ShowSscoVersion()
        {
        }

        /// <summary>
        /// Displays the SSCO product version
        /// </summary>
        public override void Run()
        {
            try
            {
                SscatLane lane = SscatContext.Lane;
                MessageService.ShowInfo(lane.ProductVersion);
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
        }
    }
}
