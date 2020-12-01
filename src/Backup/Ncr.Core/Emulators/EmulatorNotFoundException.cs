// <copyright file="EmulatorNotFoundException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the EmulatorNotFoundException class
    /// </summary>
    [Serializable]
    public class EmulatorNotFoundException : EmulatorException
    {
        /// <summary>
        /// Initializes a new instance of the EmulatorNotFoundException class
        /// </summary>
        /// <param name="emulator">event emulator</param>
        public EmulatorNotFoundException(string emulator)
            : base(string.Format("{0} not found", emulator))
        {
        }
    }
}
