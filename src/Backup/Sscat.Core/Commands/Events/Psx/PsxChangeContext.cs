// <copyright file="PsxChangeContext.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Ncr.Core.Emulators;
    using Ncr.Core.Models;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the PsxChangeContext class
    /// </summary>
    public class PsxChangeContext : PsxEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the PsxChangeContext class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">psx event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public PsxChangeContext(IScotLogHook hook, IPsxEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the PSX change context event
        /// </summary>
        public override void Run()
        {
            try
            {
                Hook.Checking += new EventHandler<SscatEventArgs>(HookChecking);
                if (Item.Control.Equals("Display") && (Item.Context.Contains("Attract") || Item.Context.StartsWith("LaneClosed")))
                {
                    string param = string.Empty;
                    if (Lane.PsxConnections.ContainsKey("AUTOMATION"))
                    {
                        IPsx psx = Lane.PsxConnections["AUTOMATION"] as IPsx;
                        if (Item.SeqId.Equals(1) && !Lane.ContextEquals(Item.Context, Timeout))
                        {
                            throw new PsxOutOfContextException(Item.Context, Item.SeqId);
                        }

                        psx.GenerateEvent("AUTOMATION", Item.Control, Item.Context, Item.Event, param);
                    }
                    else
                    {
                        throw new NoPsxAttachedException();
                    }
                }
                else if (Item.HasRapConnection && !Item.IsExempted)
                {
                    string param = string.Empty;
                    try
                    {
                        if (!Lane.PsxConnections.ContainsKey(Item.RemoteConnection))
                        {
                            OnConnectionAdding(new PsxWrapperEventArgs(DnsHelper.GetLocalIPAddress(), "FastLaneRemoteServer", Item.RemoteConnection, Timeout));
                        }

                        IPsx psx = Lane.PsxConnections[Item.RemoteConnection] as IPsx;
                        psx.GenerateEvent(Item.RemoteConnection, Item.Control, Item.Context, Item.Event, param);
                    }
                    catch
                    {
                        throw new NoPsxAttachedException();
                    }
                }

                if (!Item.IsExempted)
                {
                    if (EnableHook)
                    {
                        Result = Hook.Check(Item.CreateEvent(), Timeout);
                    }
                    else
                    {
                        Result = new Result(ResultType.Passed, "Log Hook Disabled");
                    }
                }
                else
                {
                    LoggingService.Info(string.Format("Skipping ChangeContext {0}", Item.Context));
                    Result = new Result(ResultType.Skipped, "Invalid ChangeContext");
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Hook.Checking -= new EventHandler<SscatEventArgs>(HookChecking);
            }
        }

        /// <summary>
        /// Hook checking event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">sscat event arguments</param>
        private void HookChecking(object sender, SscatEventArgs e)
        {
            OnRunning(e.Message);
        }
    }
}
