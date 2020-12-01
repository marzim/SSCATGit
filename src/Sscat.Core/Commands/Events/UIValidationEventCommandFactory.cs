// <copyright file="UIValidationEventCommandFactory.cs" company="NCR">
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
    /// Initializes a new instance of the UIValidationEventCommandFactory class
    /// </summary>
    public class UIValidationEventCommandFactory : EventCommandFactory
    {
        /// <summary>
        /// Interface for the psx event item
        /// </summary>
        private IUIValidationEvents _item;

        /// <summary>
        /// Initializes a new instance of the UIValidationEventCommandFactory class
        /// </summary>
        /// <param name="item">ui validation event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="hooks">scot log hook</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public UIValidationEventCommandFactory(IUIValidationEvents item, SscatLane lane, Dictionary<string, IScotLogHook> hooks, int timeout, bool enableHook)
            : base(lane, hooks, timeout, enableHook)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            _item = item;
        }
        
        /// <summary>
        /// Creates the ui validation event command
        /// </summary>
        /// <returns>Returns the event command</returns>
        public override IEventCommand CreateCommand()
        {
            return new UIValidationPropertyChange(Hooks[ScotLogHook.UIAutoTest], _item, Lane, Timeout, EnableHook);
        }
    }
}