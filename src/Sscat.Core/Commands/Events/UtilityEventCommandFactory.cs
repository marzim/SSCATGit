// <copyright file="UtilityEventCommandFactory.cs" company="NCR">
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
    /// Initializes a new instance of the UtilityEventCommandFactory class
    /// </summary>
    public class UtilityEventCommandFactory : EventCommandFactory
    {
        /// <summary>
        /// Interface for the auto test event item
        /// </summary>
        private IUtilityEvent _item;

        /// <summary>
        /// Initializes a new instance of the UtilityEventCommandFactory class
        /// </summary>
        /// <param name="item">auto pos emulator event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="hooks">scot log hook</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public UtilityEventCommandFactory(IUtilityEvent item, SscatLane lane, Dictionary<string, IScotLogHook> hooks, int timeout, bool enableHook)
            : base(lane, hooks, timeout, enableHook)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _item = item;
        }

        /// <summary>
        /// Creates the UI auto test event command
        /// </summary>
        /// <returns>Returns event command</returns>
        public override IEventCommand CreateCommand()
        {
            switch (_item.EventType)
            {
                case Constants.UtilityEvent.UTILITY_SLEEP:
                    return new UtilitySleep(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
                default:
                    throw new NotSupportedException(string.Format("UI auto test command '{0}' not supported.", _item.EventType));
            }
        }
    }
}