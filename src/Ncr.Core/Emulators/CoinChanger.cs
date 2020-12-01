// <copyright file="CoinChanger.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the CoinChanger class
    /// </summary>
    public class CoinChanger : Emulator, ICoinChanger
    {
        /// <summary>
        /// Initializes a new instance of the CoinChanger class
        /// </summary>
        public CoinChanger()
            : this(Emulator.CoinChangerCaption)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CoinChanger class
        /// </summary>
        /// <param name="caption">caption text</param>
        public CoinChanger(string caption)
            : base(caption)
        {
            Controls.Add("Bin", 0x40a); // comboBoxBin
            Controls.Add("Count", 0x408); // textBoxCount
            Controls.Add("BinStatus", 0x409); // comboBoxStatus
            Controls.Add("DispenseStatus", 0x40e); // comboBoxDispenseStatus
            Controls.Add("Primaryexit", 0x3f0); // textBoxPrimaryExit
            Controls.Add("Take", 0x3f2); // buttonTake
        }

        /// <summary>
        /// Bin count
        /// </summary>
        /// <param name="denomination">coin denomination</param>
        /// <returns>Returns the bin count</returns>
        public virtual string BinCount(string denomination)
        {
            SelectIndex("Bin", denomination, 3000);
            return GetText("Count", 3000);
        }
    }
}
