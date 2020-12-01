// <copyright file="CoinErrorEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the CoinErrorEventAdder class
    /// </summary>
    public class CoinErrorEventAdder : CashOrCoinErrorEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the CoinErrorEventAdder class
        /// </summary>
        public CoinErrorEventAdder()
            : base(Constants.DeviceType.COIN_ACCEPTOR_ERROR)
        {
        }

        /// <summary>
        /// Checks for if the value is valid
        /// </summary>
        /// <param name="val">value to check</param>
        /// <returns>Returns true if valid, false otherwise</returns>
        protected override bool IsValidValue(string val)
        {
            return val == Constants.CoinAcceptorError.FAIL ||
                val == Constants.CoinAcceptorError.JAM ||
                val == Constants.CoinAcceptorError.RESET ||
                val == Constants.CoinAcceptorError.FAIL_G2 ||
                val == Constants.CoinAcceptorError.JAM_G2 ||
                val == Constants.CoinAcceptorError.RESET_G2;
        }
    }
}
