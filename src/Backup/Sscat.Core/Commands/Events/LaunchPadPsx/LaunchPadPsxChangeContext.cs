// <copyright file="LaunchPadPsxChangeContext.cs" company="NCR">
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
    /// Initializes a new instance of the LaunchPadPsxChangeContext class
    /// </summary>
    public class LaunchPadPsxChangeContext : LaunchPadPsxEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the LaunchPadPsxChangeContext class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">launch pad psx event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public LaunchPadPsxChangeContext(IScotLogHook hook, ILaunchPadPsxEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, null, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the launch pad change context event
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
                OnRunning(string.Format("LaunchPad PSX changing context to {0}", Item.Context));
                base.Run();
            }
        }
    }
}
