// <copyright file="NXTUIProduceScaleZero.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    
    /// <summary>
    /// Initializes a new instance of the NXTUIProduceScaleZero class
    /// </summary>
    public class NXTUIProduceScaleZero : LaneCommand
    {
        /// <summary>
        /// Runs the Scale Tear
        /// </summary>
        public override void Run()
        {
            try
            {
                Scale scale = new Scale();
                scale.Tear();
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
            }            
        }
    }
}
