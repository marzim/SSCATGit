// <copyright file="ICoinAcceptor.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the ICoinAcceptor interface
    /// </summary>
    public interface ICoinAcceptor : IEmulator
    {
        /// <summary>
        /// Coin acceptor inserting
        /// </summary>
        /// <param name="value">device value</param>
        /// <param name="timeout">timeout amount</param>
        void Insert(string @value, int timeout);

        /// <summary>
        /// Coin acceptor jamming
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void Jam(int timeout);

        /// <summary>
        /// Coin acceptor failing
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void Fail(int timeout);

        /// <summary>
        /// Coin acceptor resetting
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void Reset(int timeout);
    }
}
