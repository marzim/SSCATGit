// <copyright file="CashErrorEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the CashErrorEventAdder class
    /// </summary>
    public class CashErrorEventAdder : CashOrCoinErrorEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the CashErrorEventAdder class
        /// </summary>
        public CashErrorEventAdder()
            : base(Constants.DeviceType.CASH_ACCEPTOR_ERROR)
        {
        }

        /// <summary>
        /// Checks for if the value is valid
        /// </summary>
        /// <param name="val">value to check</param>
        /// <returns>Returns true if valid, false otherwise</returns>
        protected override bool IsValidValue(string val)
        {
            return val == Constants.CashAcceptorError.CASSETTE_OUT ||
                val == Constants.CashAcceptorError.FAIL ||
                val == Constants.CashAcceptorError.JAM ||
                val == Constants.CashAcceptorError.RESET ||
                val == Constants.CashAcceptorError.CASSETTE_OUT_G2 ||
                val == Constants.CashAcceptorError.FAIL_G2 ||
                val == Constants.CashAcceptorError.JAM_G2 ||
                val == Constants.CashAcceptorError.RESET_G2;
        }
    }
}
