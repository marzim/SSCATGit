// <copyright file="LaunchPadPsxChangeFocus.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.LaunchPadPsx
{
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the LaunchPadPsxChangeFocus class
    /// </summary>
    public class LaunchPadPsxChangeFocus : LaunchPadPsxEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the LaunchPadPsxChangeFocus class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">launch pad psx event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public LaunchPadPsxChangeFocus(IScotLogHook hook, ILaunchPadPsxEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, null, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the launch pad change focus event
        /// </summary>
        public override void Run()
        {
            if (Item.ExemptedLaunchPadPsxEvent)
            {
                LoggingService.Info(string.Format("Skipping this LaunchPadPsx event {0}, {1}, {2}", Item.Control, Item.Context, Item.Event));
                Result = new Result(ResultType.Skipped, "Invalid LaunchPadPsx");
            }
            else
            {
                OnRunning(string.Format("LaunchPad PSX changing focus to {0}", Item.Context));
                base.Run();
            }
        }
    }
}
