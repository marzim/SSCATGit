// <copyright file="SignatureCaptureErrorEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the SignatureCaptureErrorEventAdder class
    /// </summary>
    public class SignatureCaptureErrorEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the SignatureCaptureErrorEventAdder class
        /// </summary>
        public SignatureCaptureErrorEventAdder()
            : base(Constants.DeviceType.SIGNATURE_CAPTURE_ERROR)
        {
        }
    }
}
