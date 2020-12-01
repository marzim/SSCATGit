// <copyright file="TABReverseEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the TABReverseEventAdder class
    /// </summary>
    public class TABReverseEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the TABReverseEventAdder class
        /// </summary>
        public TABReverseEventAdder()
            : base(Constants.DeviceType.TAB_REVERSE)
        {
        }
    }
}
