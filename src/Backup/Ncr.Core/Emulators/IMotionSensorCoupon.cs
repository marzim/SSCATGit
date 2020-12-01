// <copyright file="IMotionSensorCoupon.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the IMotionSensorCoupon interface
    /// </summary>
    public interface IMotionSensorCoupon : IEmulator
    {
        /// <summary>
        /// Detect the coupon insertion
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void Detect(int timeout);
    }
}
