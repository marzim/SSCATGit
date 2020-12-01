// <copyright file="EscrowCash.cs" company="NCR">
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
    /// Initializes a new instance of the EscrowCash class
    /// </summary>
    public class EscrowCash : EmulatorEventCommand
    {
        /// <summary>
        /// Interface for the cash acceptor
        /// </summary>
        private ICashAcceptor _acceptor;

        /// <summary>
        /// Initializes a new instance of the EscrowCash class
        /// </summary>
        /// <param name="acceptor">cash acceptor</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public EscrowCash(ICashAcceptor acceptor, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, acceptor, lane, timeout, enableHook)
        {
            if (acceptor == null)
            {
                throw new ArgumentNullException("CashAcceptor");
            }

            _acceptor = acceptor;
        }

        /// <summary>
        /// Runs the cash acceptor with the escrow amount for the timeout duration
        /// </summary>
        public override void Run()
        {
            try
            {
                _acceptor.Escrow(Item.Value, Timeout);
                base.Run();
            }
            catch
            {
                throw;
            }
        }
    }    
}
