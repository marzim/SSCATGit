// <copyright file="PsxEventCommandFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Sscat.Core.Commands.Events;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the PsxEventCommandFactory class
    /// </summary>
    public class PsxEventCommandFactory : EventCommandFactory
    {
        /// <summary>
        /// Interface for the psx event item
        /// </summary>
        private IPsxEvent _item;

        /// <summary>
        /// Initializes a new instance of the PsxEventCommandFactory class
        /// </summary>
        /// <param name="item">psx event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="hooks">scot log hook</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public PsxEventCommandFactory(IPsxEvent item, SscatLane lane, Dictionary<string, IScotLogHook> hooks, int timeout, bool enableHook)
            : base(lane, hooks, timeout, enableHook)
        {
            _item = item;
        }

        /// <summary>
        /// Validates the psx connection
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            AddErrorIf("PSX Connections shouldn't be null", Lane.PsxConnections == null);
        }

        /// <summary>
        /// Creates the psx event command
        /// </summary>
        /// <returns>Returns the event command</returns>
        public override IEventCommand CreateCommand()
        {
            Validate();
            if (!HasErrors)
            {
                switch (_item.Event)
                {
                    case Constants.PsxEvent.CHANGE_CONTEXT:
                        return new PsxChangeContext(Hooks[ScotLogHook.Psx], _item, Lane, Timeout, EnableHook);
                    case Constants.PsxEvent.CLICK:
                        return new PsxClick(Hooks[ScotLogHook.Psx], _item, Lane, Timeout, EnableHook);
                    case Constants.PsxEvent.KEY_PRESS:
                        return new PsxKeyPress(Hooks[ScotLogHook.Psx], Lane, _item, Timeout, EnableHook);
                    case Constants.PsxEvent.KEY_DOWN:
                        return new PsxKeyDown(Hooks[ScotLogHook.Psx], Lane, _item, Timeout, EnableHook);
                    case Constants.PsxEvent.CONNECT_REMOTE:
                        return new PsxConnectRemote(Hooks[ScotLogHook.Psx], _item, Lane, Timeout, EnableHook);
                    case Constants.PsxEvent.CHANGE_THEME:
                        return new PsxChangeTheme(Hooks[ScotLogHook.Psx], _item, Lane, Timeout, EnableHook);
                    default:
                        return new PsxUnsupportedEvent(Hooks[ScotLogHook.Psx], _item, Lane, Timeout, EnableHook);
                }
            }
            else
            {
                throw new Exception(Errors.ToString());
            }
        }
    }
}
