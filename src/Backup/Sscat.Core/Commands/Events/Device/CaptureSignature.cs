// <copyright file="CaptureSignature.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Ncr.Core.Emulators;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the CaptureSignature class
    /// </summary>
    public class CaptureSignature : DeviceEventCommand
    {
        /// <summary>
        /// Interface for the signature capture
        /// </summary>
        private IPCSignatureCapture _sigcap;

        /// <summary>
        /// Initializes a new instance of the CaptureSignature class
        /// </summary>
        /// <param name="sigcap">signature capture</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public CaptureSignature(IPCSignatureCapture sigcap, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
            if (sigcap == null)
            {
                throw new ArgumentNullException("Signature Capture");
            }

            _sigcap = sigcap;
        }

        /// <summary>
        /// Runs the signature capture for the duration of the given timeout time
        /// </summary>
        public override void Run()
        {
            try
            {
                _sigcap.Sign(Timeout);
                Result = new Result(ResultType.Passed, "OK");
            }
            catch
            {
                throw;
            }
        }
    }    
}
