// <copyright file="InsertCoin.cs" company="NCR">
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
    /// Initializes a new instance of the InsertCoin class
    /// </summary>
    public class InsertCoin : EmulatorEventCommand
    {
        /// <summary>
        /// Interface for the coin acceptor
        /// </summary>
        private ICoinAcceptor _acceptor;

        /// <summary>
        /// Initializes a new instance of the InsertCoin class
        /// </summary>
        /// <param name="acceptor">coin acceptor</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public InsertCoin(ICoinAcceptor acceptor, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, acceptor, lane, timeout, enableHook)
        {
            if (acceptor == null)
            {
                throw new ArgumentNullException("CoinAcceptor");
            }

            _acceptor = acceptor;
        }

        /// <summary>
        /// Runs the coin acceptor
        /// </summary>
        public override void Run()
        {
            try
            {
                _acceptor.Insert(Item.Value, Timeout);
                base.Run();
            }
            catch
            {
                throw;
            }
        }
    }    
}
