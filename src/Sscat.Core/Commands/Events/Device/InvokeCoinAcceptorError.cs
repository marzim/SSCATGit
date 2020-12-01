// <copyright file="InvokeCoinAcceptorError.cs" company="NCR">
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
    /// Initializes a new instance of the InvokeCoinAcceptorError class
    /// </summary>
    public class InvokeCoinAcceptorError : EmulatorEventCommand
    {
        /// <summary>
        /// Interface for the coin acceptor
        /// </summary>
        private ICoinAcceptor _acceptor;

        /// <summary>
        /// Initializes a new instance of the InvokeCoinAcceptorError class
        /// </summary>
        /// <param name="acceptor">coin acceptor</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public InvokeCoinAcceptorError(ICoinAcceptor acceptor, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, acceptor, lane, timeout, enableHook)
        {
            if (acceptor == null)
            {
                throw new ArgumentNullException("CoinAcceptor");
            }

            _acceptor = acceptor;
        }

        /// <summary>
        /// Runs to check the coin acceptor failure cases
        /// </summary>
        public override void Run()
        {
            try
            {
                if (Item.Value == Constants.CoinAcceptorError.JAM || Item.Value == Constants.CoinAcceptorError.JAM_G2)
                {
                    _acceptor.Jam(Timeout);
                }
                else if (Item.Value == Constants.CoinAcceptorError.RESET || Item.Value == Constants.CoinAcceptorError.RESET_G2)
                {
                    _acceptor.Reset(Timeout);
                }
                else if (Item.Value == Constants.CoinAcceptorError.FAIL || Item.Value == Constants.CoinAcceptorError.FAIL_G2)
                {
                    _acceptor.Fail(Timeout);
                }
                else
                {
                    throw new NotSupportedException(string.Format("Coin acceptor error value {} not supported", Item.Value));
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
