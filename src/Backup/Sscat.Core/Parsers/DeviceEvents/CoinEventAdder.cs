// <copyright file="CoinEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the CoinEventAdder class
    /// </summary>
    public class CoinEventAdder : CashOrCoinDeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the CoinEventAdder class
        /// </summary>
        public CoinEventAdder()
            : base(Constants.DeviceType.COIN_ACCEPTOR)
        {
        }
    }
}
