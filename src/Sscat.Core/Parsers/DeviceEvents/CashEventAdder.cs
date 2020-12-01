// <copyright file="CashEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the CashEventAdder class
    /// </summary>
    public class CashEventAdder : CashOrCoinDeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the CashEventAdder class
        /// </summary>
        public CashEventAdder()
            : base(Constants.DeviceType.CASH_ACCEPTOR)
        {
        }
    }
}
