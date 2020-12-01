// <copyright file="ResetTABSmartScale.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Ncr.Core.Emulators;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ResetTABSmartScale class
    /// </summary>
    public class ResetTABSmartScale : EmulatorEventCommand
    {
        /// <summary>
        /// Interface for the bag scale
        /// </summary>
        private IBagScale _scale;

        /// <summary>
        /// Initializes a new instance of the ResetTABSmartScale class
        /// </summary>
        /// <param name="scale">bag scale</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public ResetTABSmartScale(IBagScale scale, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, scale, lane, timeout, enableHook)
        {
            if (scale == null)
            {
                throw new ArgumentNullException("BagScale");
            }

            _scale = scale;
        }

        /// <summary>
        /// Runs the bag scale with a weight of 0
        /// </summary>
        public override void Run()
        {
            _scale.Weigh(0, Timeout);
            base.Run();
        }
    }
}