// <copyright file="PsxKeyDown.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the PsxKeyDown class
    /// </summary>
    public class PsxKeyDown : PsxEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the PsxKeyDown class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="item">psx event</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public PsxKeyDown(IScotLogHook hook, SscatLane lane, IPsxEvent item, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the PSX Key down event
        /// </summary>
        public override void Run()
        {
            try
            {
                Lane.Emulating += new EventHandler<EmulatorEventArgs>(ScotEmulating);
                if (Item.IsExempted)
                {
                    LoggingService.Info(string.Format("Skipping keydown {0}", Item.Param));
                    Result = new Result(ResultType.Skipped, "Invalid Keydown");
                }
                else
                {
                    Lane.Fire(ConvertUtility.ToInt32(Item.Param));
                    base.Run();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Lane.Emulating -= new EventHandler<EmulatorEventArgs>(ScotEmulating);
            }
        }

        /// <summary>
        /// Runs the scot emulator event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">emulator event arguments</param>
        private void ScotEmulating(object sender, EmulatorEventArgs e)
        {
            OnRunning(e.Message);
        }
    }
}
