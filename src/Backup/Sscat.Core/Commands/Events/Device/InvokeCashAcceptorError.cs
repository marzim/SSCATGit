// <copyright file="InvokeCashAcceptorError.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events.Device
{
    using System;
    using Ncr.Core.Emulators;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the InvokeCashAcceptorError class
    /// </summary>
    public class InvokeCashAcceptorError : EmulatorEventCommand
    {
        /// <summary>
        /// Interface for the cash acceptor
        /// </summary>
        private ICashAcceptor _acceptor;

        /// <summary>
        /// Initializes a new instance of the InvokeCashAcceptorError class
        /// </summary>
        /// <param name="acceptor">cash acceptor</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public InvokeCashAcceptorError(ICashAcceptor acceptor, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, acceptor, lane, timeout, enableHook)
        {
            if (acceptor == null)
            {
                throw new ArgumentNullException("CashAcceptor");
            }

            _acceptor = acceptor;
        }

        /// <summary>
        /// Runs the cash acceptor failure  checks
        /// </summary>
        public override void Run()
        {
            try
            {
                if (Item.Value == Constants.CashAcceptorError.JAM || Item.Value == Constants.CashAcceptorError.JAM_G2)
                {
                    _acceptor.Jam(Timeout);
                }
                else if (Item.Value == Constants.CashAcceptorError.RESET || Item.Value == Constants.CashAcceptorError.RESET_G2)
                {
                    _acceptor.Reset(Timeout);
                }
                else if (Item.Value == Constants.CashAcceptorError.FAIL || Item.Value == Constants.CashAcceptorError.FAIL_G2)
                {
                    _acceptor.Fail(Timeout);
                }
                else
                {
                    throw new NotSupportedException(string.Format("Cash acceptor error value {} not supported", Item.Value));
                }

                base.Run();
            }
            catch
            {
                throw;
            }
        }
    }
}
