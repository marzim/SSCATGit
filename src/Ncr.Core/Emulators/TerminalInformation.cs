// <copyright file="TerminalInformation.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the TerminalInformation class
    /// </summary>
    public class TerminalInformation : Emulator
    {
        /// <summary>
        /// Initializes a new instance of the TerminalInformation class
        /// </summary>
        public TerminalInformation()
            : base("TerminalInfo")
        {
            Controls.Add("EditSystemInformation", 0x3e8);
            Controls.Add("ButtonUp", 0x3eb);
            Controls.Add("ButtonDown", 0x3ec);
            Controls.Add("ButtonOK", 0x1);
        }
    }
}
