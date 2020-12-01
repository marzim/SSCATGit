// <copyright file="UIAutoTestSwipeRight.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Commands.Events.UIAutoTest;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UIAutoTestSwipeRight class
    /// </summary>
    public class UIAutoTestSwipeRight : UIAutoTestEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the UIAutoTestSwipeRight class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">ngui automated event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public UIAutoTestSwipeRight(IScotLogHook hook, IUIAutoTestEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the automated next gen UI swipe right event
        /// </summary>
        public override void Run()
        {
            NextGenUITestClient.Instance.SwipeRight(Item.ControlName, Item.ContextName);

            base.Run();
        }
    }
}