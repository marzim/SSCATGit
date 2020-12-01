// <copyright file="UIValidationEventCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UIValidationEventCommand class
    /// </summary>
    public class UIValidationEventCommand : AbstractEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the UIValidationEventCommand class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">UI auto test event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public UIValidationEventCommand(IScotLogHook hook, IUIValidationEvents item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
            ScriptEventItem = item;
        }

        /// <summary>
        /// Gets the auto test event item
        /// </summary>
        public IUIValidationEvents Item
        {
            get { return ScriptEventItem as IUIValidationEvents; }
        }
    }
}
