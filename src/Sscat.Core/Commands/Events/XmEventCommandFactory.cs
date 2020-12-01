// <copyright file="XmEventCommandFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Sscat.Core.Commands.Events;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the XmEventCommandFactory class
    /// </summary>
    public class XmEventCommandFactory : EventCommandFactory
    {
        /// <summary>
        /// Interface for the cash management event item
        /// </summary>
        private IXmEvent _item;

        /// <summary>
        /// Initializes a new instance of the XmEventCommandFactory class
        /// </summary>
        /// <param name="item">cash management event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="hooks">scot log hook</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public XmEventCommandFactory(IXmEvent item, SscatLane lane, Dictionary<string, IScotLogHook> hooks, int timeout, bool enableHook)
            : base(lane, hooks, timeout, enableHook)
        {
            _item = item;
        }

        /// <summary>
        /// Creates the cash management event command
        /// </summary>
        /// <returns>Returns event command</returns>
        public override IEventCommand CreateCommand()
        {
            try
            {
                switch (_item.Id)
                {
                    case Constants.XmEvent.XM_PRINT_DATA:
                        return new CheckXmPrintData(Hooks[ScotLogHook.Xmode], _item, Lane, Timeout, EnableHook);
                    case Constants.XmEvent.XM_COUNT_CHANGES:
                        return new CheckXmCountChanges(Hooks[ScotLogHook.Xmode], _item, Lane, Timeout, EnableHook);
                    default:
                        throw new NotSupportedException(string.Format("Xm command '{0}' not supported.", _item.Id));
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
