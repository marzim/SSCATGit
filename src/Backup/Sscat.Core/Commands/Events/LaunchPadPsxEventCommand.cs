// <copyright file="LaunchPadPsxEventCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the LaunchPadPsxEventCommand class
    /// </summary>
    public class LaunchPadPsxEventCommand : AbstractEventCommand
    {
        /// <summary>
        /// Interface for the SSCAT launch pad
        /// </summary>
        private ISscatLaunchPad _launchPad;

        /// <summary>
        /// Initializes a new instance of the LaunchPadPsxEventCommand class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="launchPad">sscat launch pad</param>
        /// <param name="item">launch pad PSX event item</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public LaunchPadPsxEventCommand(IScotLogHook hook, ISscatLaunchPad launchPad, ILaunchPadPsxEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
            LaunchPad = launchPad;
        }

        /// <summary>
        /// Gets or sets the launch pad
        /// </summary>
        public ISscatLaunchPad LaunchPad
        {
            get { return _launchPad; }
            set { _launchPad = value; }
        }

        /// <summary>
        /// Gets the launch pad PSX event item
        /// </summary>
        public ILaunchPadPsxEvent Item
        {
            get
            {
                return ScriptEventItem as ILaunchPadPsxEvent;
            }
        }
    }
}
