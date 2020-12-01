// <copyright file="DetectCoupon.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Ncr.Core.Emulators;
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the DetectCoupon class
    /// </summary>
    public class DetectCoupon : EmulatorEventCommand
    {
        /// <summary>
        /// Interface for the coupon motion sensor
        /// </summary>
        private IMotionSensorCoupon _sensor;

        /// <summary>
        /// Initializes a new instance of the DetectCoupon class
        /// </summary>
        /// <param name="sensor">motion sensor coupon</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public DetectCoupon(IMotionSensorCoupon sensor, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, sensor, lane, timeout, enableHook)
        {
            if (sensor == null)
            {
                throw new ArgumentNullException("MotionSensor");
            }

            _sensor = sensor;
        }

        /// <summary>
        /// Runs the sensor during the duration of the timeout
        /// </summary>
        public override void Run()
        {
            try
            {
                _sensor.Detect(Timeout);
                base.Run();
            }
            catch
            {
                throw;
            }
        }
    }
}