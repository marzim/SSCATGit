// <copyright file="PCSignatureCapture.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the PCSignatureCapture class
    /// </summary>
    public class PCSignatureCapture : Emulator, IPCSignatureCapture
    {
        /// <summary>
        /// PC signature capture failure
        /// </summary>
        private const string FAILURE = "OPOS_E_FAILURE";

        /// <summary>
        /// PC signature capture has no hardware
        /// </summary>
        private const string NOHARDWARE = "OPOS_E_NOHARDWARE";
        
        /// <summary>
        /// PC signature capture offline
        /// </summary>
        private const string OFFLINE = "OPOS_E_OFFLINE";

        /// <summary>
        /// Initializes a new instance of the PCSignatureCapture class
        /// </summary>
        public PCSignatureCapture()
            : base(Emulator.PCSignatureCaptureCaption)
        {
            Controls.Add("0", 0x3f4);
            Controls.Add("1", 0x3ef);

            Controls.Add("2", 0x3f3);
            Controls.Add("3", 0x3e9);
        }

        /// <summary>
        /// Sign signature
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public virtual void Sign(int timeout)
        {
            OnEmulating(string.Format("Signing Signature"));
            ClickButton("0", timeout);
            ClickButton("1", timeout);
        }

        /// <summary>
        /// Signature failure
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void Fail(int timeout)
        {
            SelectIndex("3", FAILURE, timeout);
            ClickButton("2", timeout);
        }

        /// <summary>
        /// Has no hardware
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void NoHardware(int timeout)
        {
            SelectIndex("3", NOHARDWARE, timeout);
            ClickButton("2", timeout);
        }

        /// <summary>
        /// signature capture is offline
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void Offline(int timeout)
        {
            SelectIndex("3", OFFLINE, timeout);
            ClickButton("2", timeout);
        }
    }
}
