// <copyright file="IPinPad.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the IPinPad interface
    /// </summary>
    public interface IPinPad : IEmulator
    {
        /// <summary>
        /// Execute the pin pad
        /// </summary>
        /// <param name="value">device value</param>
        /// <param name="timeout">timeout amount</param>
        void Execute(string @value, int timeout);
    }
}
