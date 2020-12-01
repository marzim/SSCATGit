// <copyright file="MotionSensorCoupon.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System.Threading;

    /// <summary>
    /// Initializes a new instance of the MotionSensorCoupon class
    /// </summary>
    public class MotionSensorCoupon : Emulator, IMotionSensorCoupon
    {
        /// <summary>
        /// Initializes a new instance of the MotionSensorCoupon class
        /// </summary>
        public MotionSensorCoupon()
            : base(Emulator.MotionSensorCaption)
        {
            Controls.Add("Insert", 0x3e8);
        }

        /// <summary>
        /// Detect the coupon insertion
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void Detect(int timeout)
        {
            OnEmulating(string.Format("Coupon Insertion"));
            ClickButton("Insert", timeout);
            Thread.Sleep(300);
            ClickButton("Insert", timeout);
        }
    }
}
