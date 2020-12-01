// <copyright file="CashTroughEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the CashTroughEventAdder class
    /// </summary>
    public class CashTroughEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the CashTroughEventAdder class
        /// </summary>
        public CashTroughEventAdder()
            : base(Constants.DeviceType.CASH_TROUGH)
        {
        }
    }
}
