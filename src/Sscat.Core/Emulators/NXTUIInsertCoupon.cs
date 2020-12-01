// <copyright file="NXTUIInsertCoupon.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    
    /// <summary>
    /// Initializes a new instance of the NXTUIInsertCoupon class
    /// </summary>
    public class NXTUIInsertCoupon : LaneCommand
    {
        /// <summary>
        /// Runs the Insert Coupon
        /// </summary>
        public override void Run()
        {
            try
            {
                MotionSensorCoupon coupon = new MotionSensorCoupon();
                coupon.Detect(2000);
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
            }            
        }
    }
}
