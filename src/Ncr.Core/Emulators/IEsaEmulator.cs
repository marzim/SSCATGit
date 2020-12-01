// <copyright file="IEsaEmulator.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the IESA Emulator interface
    /// </summary>
    public interface IEsaEmulator : IEmulator
    {
        /// <summary>
        /// Performs the Intervention
        /// </summary>
        /// <param name="intervention">scan code</param>
        /// <param name="timeout">timeout amount</param>
        void Intervene(string intervention, int timeout);
    }
}
