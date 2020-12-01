// <copyright file="NextGenUIAutoTest.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;
    using Ncr.Core.PInvoke;

    /// <summary>
    /// Initializes a new instance of the NextGenUIAutoTest class
    /// </summary>
    public class NextGenUIAutoTest : Emulator
    {
        /// <summary>
        /// Initializes a new instance of the NextGenUIAutoTest class
        /// </summary>
        public NextGenUIAutoTest()
            : base(string.Empty, Emulator.NextGenUICaption)
        {
        }
       
        /// <summary>
        /// Set the screen to Next Gen UI
        /// </summary>
        /// <param name="nextGenHandle">next gen application handle</param>
        public void SetScreen(IntPtr nextGenHandle)
        {
            User32.ShowWindow(nextGenHandle, User32.SW_RESTORE);
            User32.SetForegroundWindow(nextGenHandle);
        }
    }
}
