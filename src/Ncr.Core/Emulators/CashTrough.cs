// <copyright file="CashTrough.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the CashTrough class
    /// </summary>
    public class CashTrough : Emulator, ICashTrough
    {
        /// <summary>
        /// Initializes a new instance of the CashTrough class
        /// </summary>
        public CashTrough()
            : base(Emulator.CashTroughCaption)
        {
            Controls.Add("CashTroughDialog", 0x000);
            Controls.Add("Remove", 0xc71);
        }

        /// <summary>
        /// Cash Trough Remove
        /// </summary>
        /// <param name="deviceValue">device value</param>
        /// <param name="timeout">timeout amount</param>
        public virtual void Remove(string deviceValue, int timeout)
        {
            if (deviceValue.Equals("2"))
            {
                ClickButton("CashTroughDialog", "Remove", timeout);
            }
        }
    }
}
