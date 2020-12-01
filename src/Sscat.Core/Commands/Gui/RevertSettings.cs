// <copyright file="RevertSettings.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using System.Threading;
    using Ncr.Core.Commands;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;

    /// <summary>
    /// Initializes a new instance of the RevertSettings class
    /// </summary>
    public class RevertSettings : AbstractCommand
    {
        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Initializes a new instance of the RevertSettings class
        /// </summary>
        public RevertSettings()
            : this(SscatContext.Lane)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RevertSettings class
        /// </summary>
        /// <param name="lane">sscat lane</param>
        public RevertSettings(SscatLane lane)
        {
            _lane = lane;
        }

        /// <summary>
        /// Reverts the lane to original settings
        /// </summary>
        public override void Run()
        {
            _lane.LaunchPad = new SscatLaunchPad(new DefaultLaunchPadLauncher(), new Lane(), new StoreServer());
            try
            {
                if (_lane.HasStarted)
                {
                    MessageService.ShowInfo("SSCO is currently running and will be shutdown before reverting lane settings.");
                    _lane.ForceKill();
                    Thread.Sleep(100);
                    _lane.RevertLaneSettings();
                    MessageService.ShowInfo("Lane has reverted to its original settings.");
                }
                else
                {
                    _lane.RevertLaneSettings();
                    MessageService.ShowInfo("Lane has reverted to its original settings.");
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
