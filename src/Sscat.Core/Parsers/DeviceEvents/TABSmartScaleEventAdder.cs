// <copyright file="TABSmartScaleEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the TABSmartScaleEventAdder class
    /// </summary>
    public class TABSmartScaleEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the TABSmartScaleEventAdder class
        /// </summary>
        public TABSmartScaleEventAdder()
            : base(Constants.DeviceType.TAB_SMART_SCALE)
        {
        }
    }
}
