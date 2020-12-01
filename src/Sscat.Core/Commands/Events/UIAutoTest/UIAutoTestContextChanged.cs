// <copyright file="UIAutoTestContextChanged.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Models;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UIAutoTestContextChanged class
    /// </summary>
    public class UIAutoTestContextChanged : UIAutoTestEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the UIAutoTestContextChanged class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">ngui automated event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public UIAutoTestContextChanged(IScotLogHook hook, IUIAutoTestEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the automated next gen UI context changed event
        /// </summary>
        public override void Run()
        {
            base.Run();
        }
    }
}