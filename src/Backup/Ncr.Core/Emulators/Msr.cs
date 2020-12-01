// <copyright file="Msr.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Initializes a new instance of the Msr class
    /// </summary>
    public class Msr : Emulator, IMsr
    {
        /// <summary>
        /// Initializes a new instance of the Msr class
        /// </summary>
        public Msr()
            : base(Emulator.MsrCaption)
        {
            Controls.Add("Track1", 0x43B);
            Controls.Add("Track2", 0x43C);
            Controls.Add("Track3", 0x43D);
            Controls.Add("Swipe", 0x3fd);
            Controls.Add("CardDescription", 0x43e);
            Controls.Add("Checkbox", 0x440);
        }

        /// <summary>
        /// Swipe the MSR card
        /// </summary>
        /// <param name="code">card code</param>
        /// <param name="timeout">timeout amount</param>
        public void Swipe(string code, int timeout)
        {
            OnEmulating(string.Format("Swiping {0}", code));
            Dictionary<string, string> data = DecodeMsr(code);
            SetText("CardDescription", "NCR Card", timeout);
            CheckBox("Checkbox", timeout);
            SetText("Track1", data["Track1"].ToString(), timeout);
            SetText("Track2", data["Track2"].ToString(), timeout);
            SetText("Track3", data["Track3"].ToString(), timeout);
            ClickButton("Swipe", timeout);
        }

        /// <summary>
        /// Decode the MSR
        /// </summary>
        /// <param name="encodedMSR">encoded MSR</param>
        /// <returns>Returns the decoded MSR</returns>
        private Dictionary<string, string> DecodeMsr(string encodedMSR)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] strArray = encodedMSR.Split('~');
            int i = 1;
            foreach (string data in strArray)
            {
                dictionary.Add("Track" + i.ToString(), data);
                i++;
            }

            return dictionary;
        }
    }
}
