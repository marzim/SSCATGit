// <copyright file="UtilitySleep.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using System.Threading;
    using Ncr.Core.ExtensionMethods;
    using Ncr.Core.Util;
    using Sscat.Core.Commands.Events.UIAutoTest;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UtilitySleep class
    /// </summary>
    public class UtilitySleep : UtilityEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the UtilitySleep class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">ngui automated event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public UtilitySleep(IScotLogHook hook, IUtilityEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the automated next gen UI button click event
        /// </summary>
        public override void Run()
        {
            int sleepTime = 0;
            try
            {
                sleepTime = Convert.ToInt32(Item.Value);
                Result = Sleep(sleepTime);
            }
            catch (FormatException e)
            {
                string message = string.Format("; Error Message = {1} {0}Troubleshooting tips:{0} Kindly set the value of the sleep event to a correct format. e.g. Value=5000(ms)", Environment.NewLine, e.Message);
                Result = new Result(ResultType.Failed, message);
                LoggingService.Info(message);
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                Result = new Result(ResultType.Failed, ex.Message);
            }
        }

        /// <summary>
        /// Sleeps for a period of time
        /// </summary>
        /// <param name="sleepTime">sleep time</param>
        /// <returns>script event result</returns>
        private Result Sleep(int sleepTime)
        {
            int wakeTime = Environment.TickCount + sleepTime;
            Result result = new Result(ResultType.Running);
            
            try
            {
                while (sleepTime > 0)
                {
                    OnRunning(string.Format("Playing Sleep Event... {0} seconds left", sleepTime.MillisecondsToSeconds()));

                    if (sleepTime > 1000)
                    {
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Thread.Sleep(sleepTime);
                        return new Result(ResultType.Passed);
                    }

                    sleepTime = wakeTime - Environment.TickCount;
                }              
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                return new Result(ResultType.Exception, ex.Message);
            }

            LoggingService.Info("SleepTime = " + sleepTime);
            if (sleepTime <= 0)
            {
                return new Result(ResultType.Passed);
            }
            
            return new Result(ResultType.Failed, "Sleep event did not end well.");
        }
    }
}