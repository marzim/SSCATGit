// <copyright file="EmulatorEventCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using System.Text.RegularExpressions;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the EmulatorEventCommand class
    /// </summary>
    public class EmulatorEventCommand : DeviceEventCommand
    {
        /// <summary>
        /// Interface for the emulator
        /// </summary>
        private IEmulator _emulator;

        /// <summary>
        /// Initializes a new instance of the EmulatorEventCommand class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event item</param>
        /// <param name="emulator">emulator interface</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public EmulatorEventCommand(IScotLogHook hook, IDeviceEvent item, IEmulator emulator, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
            if (emulator == null)
            {
                throw new ArgumentNullException("emulator");
            }

            _emulator = emulator;
        }

        /// <summary>
        /// Runs the emulator event command
        /// </summary>
        public override void Run()
        {
            try
            {
                Hook.Checking += new EventHandler<SscatEventArgs>(HookChecking);
                if (EnableHook)
                {
                    Result = Hook.Check(Item.CreateEvent(), Timeout);
                }
                else
                {
                    Result = new Result(ResultType.Passed, "Log Hook Disabled");
                }

                if (!_emulator.Available())
                {
                    string msg = string.Format("{0} not started! Probably killed by this event command, please check.", _emulator.Caption);
                    LoggingService.Warning(msg);
                    throw new EmulatorException(msg);
                }
            }
            catch (EmulatorItemNotFoundException ex)
            {
                Result = new Result(ResultType.Failed, string.Format("{0} at {1}", Regex.Replace(ex.Message, @"\t|\n|\r", "; "), Lane.CurrentContext));
            }
            catch (EmulatorNotFoundException ex)
            {
                Result = new Result(ResultType.Failed, string.Format("{0} at {1}", Regex.Replace(ex.Message, @"\t|\n|\r", "; "), Lane.CurrentContext));
            }
            catch (EmulatorTimeoutException ex)
            {
                Result = new Result(ResultType.Failed, string.Format("{0} at {1}", Regex.Replace(ex.Message, @"\t|\n|\r", "; "), Lane.CurrentContext));
            }
            finally
            {
                Hook.Checking -= new EventHandler<SscatEventArgs>(HookChecking);
            }
        }

        /// <summary>
        /// Event that checks the hook
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">sscat event arguments</param>
        private void HookChecking(object sender, SscatEventArgs e)
        {
            OnRunning(e.Message);
        }
    }
}
