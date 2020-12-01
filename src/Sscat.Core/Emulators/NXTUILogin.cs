// <copyright file="NXTUILogin.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    
    /// <summary>
    /// Initializes a new instance of the Login class
    /// </summary>
    public class NXTUILogin : LaneCommand
    {
        /// <summary>
        /// Runs the lane login
        /// </summary>
        public override void Run()
        {
            try
            {
                Scanner scan = new Scanner();
                scan.Scan(Lane.Configuration.PlayerConfiguration.OperatorBarcode, 5000);
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
            }            
        }
    }
}
