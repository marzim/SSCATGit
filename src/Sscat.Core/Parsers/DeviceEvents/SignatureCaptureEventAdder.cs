// <copyright file="SignatureCaptureEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the SignatureCaptureEventAdder class
    /// </summary>
    public class SignatureCaptureEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the SignatureCaptureEventAdder class
        /// </summary>
        public SignatureCaptureEventAdder()
            : base(Constants.DeviceType.SIGNATURE_CAPTURE)
        {
        }
    }
}
