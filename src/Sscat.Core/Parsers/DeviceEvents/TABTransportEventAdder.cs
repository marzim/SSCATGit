// <copyright file="TABTransportEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the TABTransportEventAdder class
    /// </summary>
    public class TABTransportEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the TABTransportEventAdder class
        /// </summary>
        public TABTransportEventAdder()
            : base(Constants.DeviceType.TAB_TRANSPORT)
        {
        }
    }
}
