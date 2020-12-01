// <copyright file="RemoveCashTrough.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Ncr.Core.Emulators;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the RemoveCashTrough class
    /// </summary>
    public class RemoveCashTrough : EmulatorEventCommand
    {
        /// <summary>
        /// Interface for the cash acceptor
        /// </summary>
        private ICashTrough _trough;

        /// <summary>
        /// Initializes a new instance of the RemoveCashTrough class
        /// </summary>
        /// <param name="trough">cash trough</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public RemoveCashTrough(ICashTrough trough, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, trough, lane, timeout, enableHook)
        {
            if (trough == null)
            {
                throw new ArgumentNullException("CashTrough");
            }

            _trough = trough;
        }

        /// <summary>
        /// Runs the cash acceptor with the escrow amount for the timeout duration
        /// </summary>
        public override void Run()
        {
            try
            {
                _trough.Remove(Item.Value, Timeout);
                base.Run();
            }
            catch
            {
                throw;
            }
        }
    }
}
