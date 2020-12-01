// <copyright file="EmulatorItemNotFoundException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the EmulatorItemNotFoundException class
    /// </summary>
    [Serializable]
    public class EmulatorItemNotFoundException : EmulatorException
    {
        /// <summary>
        /// Initializes a new instance of the EmulatorItemNotFoundException class
        /// </summary>
        /// <param name="emulator">event emulator</param>
        /// <param name="control">emulator control</param>
        public EmulatorItemNotFoundException(string emulator, string control)
            : base(string.Format("{0} not found in {1}", control, emulator))
        {
        }
    }
}
