// <copyright file="PLAMatchingItemResponse.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the PLAMatchingItemResponse class
    /// </summary>
    public class PLAMatchingItemResponse : DeviceEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the PLAMatchingItemResponse class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public PLAMatchingItemResponse(IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
        }

        /// <summary>
        /// Runs the PLA Matching Item Response
        /// </summary>
        public override void Run()
        {
            base.Run();
        }
    }
}
