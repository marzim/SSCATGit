// <copyright file="IPosPrinter.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the IPosPrinter interface
    /// </summary>
    public interface IPosPrinter : IEmulator
    {
        /// <summary>
        /// Printing receipt
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void Printing(int timeout);

        /// <summary>
        /// Printer cover open
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void CoverOpen(int timeout);
    }
}
