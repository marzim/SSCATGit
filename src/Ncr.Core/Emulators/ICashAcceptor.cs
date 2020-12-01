// <copyright file="ICashAcceptor.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ICashAcceptor class
    /// </summary>
    public interface ICashAcceptor : IEmulator
    {
        /// <summary>
        /// Cash acceptor escrow
        /// </summary>
        /// <param name="deviceValue">device value</param>
        /// <param name="timeout">timeout amount</param>
        void Escrow(string deviceValue, int timeout);

        /// <summary>
        /// Cash acceptor cassette out
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void CassetteOut(int timeout);

        /// <summary>
        /// Cash acceptor resetting
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void Reset(int timeout);

        /// <summary>
        /// Cash acceptor jamming
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void Jam(int timeout);

        /// <summary>
        /// Cash acceptor failing
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void Fail(int timeout);
    }
}
