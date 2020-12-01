// <copyright file="IScale.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the IScale interface
    /// </summary>
    public interface IScale : IEmulator
    {
        /// <summary>
        /// Gets the weight
        /// </summary>
        int Weight { get; }

        /// <summary>
        /// Scale weighing emulator
        /// </summary>
        /// <param name="weight">weight to weigh on scale emulator</param>
        /// <param name="timeout">timeout amount</param>
        void Weigh(int weight, int timeout);
    }
}
