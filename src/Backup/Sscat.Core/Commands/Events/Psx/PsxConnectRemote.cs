// <copyright file="PsxConnectRemote.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Ncr.Core.Emulators;
    using Ncr.Core.Models;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the PsxConnectRemote class
    /// </summary>
    public class PsxConnectRemote : PsxEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the PsxConnectRemote class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">psx event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public PsxConnectRemote(IScotLogHook hook, IPsxEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the PSX Remote connect event
        /// </summary>
        public override void Run()
        {
            if (!Lane.PsxConnections.ContainsKey(Item.RemoteConnection))
            {
                OnConnectionAdding(new PsxWrapperEventArgs(DnsHelper.GetLocalIPAddress(), "FastLaneRemoteServer", Item.RemoteConnection, Timeout));
                base.Run();
            }
            else
            {
                Result = new Result(ResultType.Skipped, string.Format("PSX Connection {0} exists", Item.RemoteConnection));
            }
        }
    }
}
