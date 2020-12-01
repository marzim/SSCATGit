// <copyright file="LaunchPadPsxEventCommandFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System.Collections.Generic;
    using Sscat.Core.Commands.Events;
    using Sscat.Core.Commands.LaunchPadPsx;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Repositories.Xml;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the LaunchPadPsxEventCommandFactory class
    /// </summary>
    public class LaunchPadPsxEventCommandFactory : EventCommandFactory
    {
        /// <summary>
        /// Interface for the launch pad psx event item
        /// </summary>
        private ILaunchPadPsxEvent _item;

        /// <summary>
        /// Initializes a new instance of the LaunchPadPsxEventCommandFactory class
        /// </summary>
        /// <param name="item">launch pad psx event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="hooks">scot log hooks</param>
        /// <param name="timeout">timeout amount</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public LaunchPadPsxEventCommandFactory(ILaunchPadPsxEvent item, SscatLane lane, Dictionary<string, IScotLogHook> hooks, int timeout, bool enableHook)
            : base(lane, hooks, timeout, enableHook)
        {
            _item = item;
        }

        /// <summary>
        /// Creates a lunch pad event command
        /// </summary>
        /// <returns>Returns the event command</returns>
        public override IEventCommand CreateCommand()
        {
            switch (_item.Event)
            {
                case Constants.LaunchPadEvent.CHANGE_CONTEXT:
                    return new LaunchPadPsxChangeContext(Hooks[ScotLogHook.LaunchPadPsx], _item, Lane, Timeout, EnableHook);
                case Constants.LaunchPadEvent.CHANGE_FOCUS:
                    return new LaunchPadPsxChangeFocus(Hooks[ScotLogHook.LaunchPadPsx], _item, Lane, Timeout, EnableHook);
                case Constants.LaunchPadEvent.CLICK:
                    return new LaunchPadPsxClick(Hooks[ScotLogHook.LaunchPadPsx], Lane.LaunchPad, _item, Lane, new XmlPsxDisplayRepository(), Timeout, EnableHook);
                default:
                    return new LaunchPadPsxUnsupportedEvent(Hooks[ScotLogHook.LaunchPadPsx], _item, Lane, Timeout, EnableHook);
            }
        }
    }
}
