// <copyright file="ScannerDeviceErrorEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ScannerDeviceErrorEventAdder class
    /// </summary>
    public class ScannerDeviceErrorEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the ScannerDeviceErrorEventAdder class
        /// </summary>
        public ScannerDeviceErrorEventAdder()
            : base(Constants.DeviceType.SCANNER_ERROR)
        {
        }
    }
}
