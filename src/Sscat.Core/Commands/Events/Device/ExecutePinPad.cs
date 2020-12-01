// <copyright file="ExecutePinPad.cs" company="NCR">
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
    /// Initializes a new instance of the ExecutePinPad class
    /// </summary>
    public class ExecutePinPad : EmulatorEventCommand
    {
        /// <summary>
        /// Interface for the pin pad
        /// </summary>
        private IPinPad _pinpad;

        /// <summary>
        /// Initializes a new instance of the ExecutePinPad class
        /// </summary>
        /// <param name="pinpad">interface for the pin pad</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public ExecutePinPad(IPinPad pinpad, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, pinpad, lane, timeout, enableHook)
        {
            if (pinpad == null)
            {
                throw new ArgumentNullException("PinPad");
            }

            _pinpad = pinpad;
        }

        /// <summary>
        /// Runs the pin pad for the given value for the duration of the timeout
        /// </summary>
        public override void Run()
        {
            try
            {
                _pinpad.Execute(Item.Value, Timeout);
                base.Run();
            }
            catch
            {
                throw;
            }
        }
    }
}
