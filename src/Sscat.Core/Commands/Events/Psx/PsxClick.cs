// <copyright file="PsxClick.cs" company="NCR">
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
    /// Initializes a new instance of the PsxClick class
    /// </summary>
    public class PsxClick : PsxEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the PsxClick class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">psx event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public PsxClick(IScotLogHook hook, IPsxEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the PSX Click event
        /// </summary>
        public override void Run()
        {
            if (Item.IsExempted)
            {
                LoggingService.Info(string.Format("Skipping click {0}", Item.Control));
                Result = new Result(ResultType.Skipped, "Invalid button click");
                return;
            }
            else if (Item.HasRapConnection)
            {
                object param = Item.Param;
                if (!Lane.PsxConnections.ContainsKey(Item.RemoteConnection))
                {
                    LoggingService.Info(string.Format("connectionadding to {0}", Item.RemoteConnection));
                    OnConnectionAdding(new PsxWrapperEventArgs(DnsHelper.GetLocalIPAddress(), "FastLaneRemoteServer", Item.RemoteConnection, Timeout));
                }

                Lane.PsxConnections[Item.RemoteConnection].GenerateEvent(Item.RemoteConnection, Item.Control, Item.Context, Item.Event, param);
            }
            else
            {
                if (Lane.CurrentPsx != null)
                {
                    if (!Lane.ContextEquals(Item.Context, Timeout))
                    {
                        throw new PsxOutOfContextException(Item.Context, Item.SeqId);
                    }

                    if (!Lane.IsControlVisible(Item.Control, Timeout))
                    {
                        throw new PsxControlNotFoundException(Item.Control);
                    }

                    Lane.Click(Item.Control, Item.Param, Timeout, true);
                }
                else
                {
                    throw new NoPsxAttachedException();
                }
            }

            if (Item.Param.ToLower().Equals("no"))
            {
                Result = new Result(ResultType.Skipped, "Skipped");
                return;
            }

            base.Run();
            if (Item.Context.Equals("SmRunReports") || Item.Context.Equals("SmReportsMenu"))
            {
                Lane.CaptureScreen(Item.Event, Item.Context);
            }
        }
    }
}
