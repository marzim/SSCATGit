// <copyright file="UIAutoTestSignSignature.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Commands.Events.UIAutoTest;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UIAutoTestSignSignature class
    /// </summary>
    public class UIAutoTestSignSignature : UIAutoTestEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the UIAutoTestSignSignature class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">ngui automated event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public UIAutoTestSignSignature(IScotLogHook hook, IUIAutoTestEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the automated next gen UI sign signature event
        /// </summary>
        public override void Run()
        {
            NextGenUITestClient.Instance.SignSignature(Item.ControlName, Item.ContextName);

            base.Run();
        }
    }
}