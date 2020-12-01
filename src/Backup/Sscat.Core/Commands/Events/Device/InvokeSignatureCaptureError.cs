// <copyright file="InvokeSignatureCaptureError.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events.Device
{
    using System;
    using Ncr.Core.Emulators;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the InvokeSignatureCaptureError class
    /// </summary>
    public class InvokeSignatureCaptureError : DeviceEventCommand
    {
        /// <summary>
        /// Interface for the signature capture
        /// </summary>
        private IPCSignatureCapture _sigcap;

        /// <summary>
        /// Initializes a new instance of the InvokeSignatureCaptureError class
        /// </summary>
        /// <param name="sigcap">signature capture</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public InvokeSignatureCaptureError(IPCSignatureCapture sigcap, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
            if (sigcap == null)
            {
                throw new ArgumentNullException("Signature Capture");
            }

            _sigcap = sigcap;
        }

        /// <summary>
        /// Runs the signature capture failure for the duration of the given timeout time
        /// </summary>
        public override void Run()
        {
            try
            {
                if (Item.Value == Constants.SignatureCaptureError.FAILURE)
                {
                    _sigcap.Fail(Timeout);
                }
                else if (Item.Value == Constants.SignatureCaptureError.NO_HARDWARE)
                {
                    _sigcap.NoHardware(Timeout);
                }
                else if (Item.Value == Constants.SignatureCaptureError.OFFLINE)
                {
                    _sigcap.Offline(Timeout);
                }
                else
                {
                    throw new NotSupportedException(string.Format("Signature capture error '{0}' not supported.", Item.Value));
                }

                base.Run();
            }
            catch
            {
                throw;
            }
        }
    }
}
