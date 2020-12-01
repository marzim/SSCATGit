// <copyright file="EmulatorTimeoutException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the EmulatorTimeoutException class
    /// </summary>
    [Serializable]
    public class EmulatorTimeoutException : EmulatorException
    {
        /// <summary>
        /// Initializes a new instance of the EmulatorTimeoutException class
        /// </summary>
        /// <param name="emulator">event emulator</param>
        public EmulatorTimeoutException(string emulator)
            : base(string.Format("{0} has timed out", emulator))
        {
        }
    }
}
