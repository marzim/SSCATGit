// <copyright file="PinPad.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using System.Text.RegularExpressions;
    using System.Threading;

    /// <summary>
    /// Initializes a new instance of the PinPad class
    /// </summary>
    public class PinPad : Emulator, IPinPad
    {
        /// <summary>
        /// Initializes a new instance of the PinPad class
        /// </summary>
        public PinPad()
            : base(Emulator.PinPadCaption)
        {
            Controls.Add("0", 0x3ec);
            Controls.Add("1", 0x3ed);
            Controls.Add("2", 0x3ee);
            Controls.Add("3", 0x3ef);
            Controls.Add("4", 0x3e8);
            Controls.Add("5", 0x3e9);
            Controls.Add("6", 0x3ea);
            Controls.Add("7", 0x3eb);
            Controls.Add("8", 0x3f0);
            Controls.Add("9", 0x3f1);
            Controls.Add("10", 0x3f2);
            Controls.Add("11", 0x401);
        }

        /// <summary>
        /// Execute the pin pad
        /// </summary>
        /// <param name="deviceValue">device value</param>
        /// <param name="timeout">timeout amount</param>
        public void Execute(string deviceValue, int timeout)
        {
            OnEmulating(string.Format("Executing {0}", deviceValue));
            if (!deviceValue.Equals("Cancel"))
            {
                Match match;
                string pattern = @"(?<=[<][A-Z]*)[\d]*(?=[>])";
                if ((match = Regex.Match(deviceValue, pattern)).Success)
                {
                }
                else
                {
                    ClickButton("0", timeout);
                    ClickButton("1", timeout);
                    ClickButton("2", timeout);
                    ClickButton("3", timeout);
                    ClickButton("10", timeout);
                    Thread.Sleep(100);
                }
            }
            else
            {
                ClickButton("11", timeout);
            }
        }
    }
}
