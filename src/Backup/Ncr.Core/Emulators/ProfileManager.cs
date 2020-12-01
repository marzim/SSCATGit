// <copyright file="ProfileManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ProfileManager class
    /// </summary>
    public class ProfileManager : Emulator
    {
        /// <summary>
        /// Initializes a new instance of the ProfileManager class
        /// </summary>
        public ProfileManager()
            : base("Profile Manager Lite - Login-in")
        {
            Controls.Add("q", 0x52a);
            Controls.Add("w", 0x527);
            Controls.Add("e", 0x522);
            Controls.Add("r", 0x521);
            Controls.Add("t", 0x525);
            Controls.Add("y", 0x523);
            Controls.Add("u", 0x529);
            Controls.Add("i", 0x524);
            Controls.Add("o", 0x526);
            Controls.Add("p", 0x528);
            Controls.Add("Shift", 0x50c);
            Controls.Add("Backspace", 0x53d);
            Controls.Add("Enter", 0x508);
            Controls.Add("Exit", 0x53e);
        }
    }
}
