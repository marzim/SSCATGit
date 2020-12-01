// <copyright file="KillSsco.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;

    /// <summary>
    /// Initializes a new instance of the KillSsco class
    /// </summary>
    public class KillSsco : AbstractCommand
    {
        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Initializes a new instance of the KillSsco class
        /// </summary>
        public KillSsco()
            : this(SscatContext.Lane)
        {
        }

        /// <summary>
        /// Initializes a new instance of the KillSsco class
        /// </summary>
        /// <param name="lane">sscat lane</param>
        public KillSsco(SscatLane lane)
        {
            _lane = lane;
        }

        /// <summary>
        /// Gets a value indicating whether the lane can run
        /// </summary>
        public override bool CanRun
        {
            get { return _lane.Exists; }
        }

        /// <summary>
        /// Terminates SSCO if it is running
        /// </summary>
        public override void Run()
        {
            try
            {
                if (_lane.HasStarted || ProcessUtility.HasStarted("LaunchpadNet"))
                {
                    _lane.Kill();
                    MessageService.ShowInfo("SSCO terminated.");
                }
                else
                {
                    MessageService.ShowInfo("SSCO is not running.");
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
