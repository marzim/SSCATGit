// <copyright file="UIAutoTestEventCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UIAutoTestEventCommand class
    /// </summary>
    public class UIAutoTestEventCommand : AbstractEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the UIAutoTestEventCommand class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">UI auto test event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public UIAutoTestEventCommand(IScotLogHook hook, IUIAutoTestEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
            if (item == null)
            {
                throw new System.ArgumentNullException("item");
            }

            ScriptEventItem = item;
        }

        /// <summary>
        /// Gets the auto test event item
        /// </summary>
        public IUIAutoTestEvent Item
        {
            get { return ScriptEventItem as IUIAutoTestEvent; }
        }
    }
}
