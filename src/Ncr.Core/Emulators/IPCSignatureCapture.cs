// <copyright file="IPCSignatureCapture.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the IPCSignatureCapture interface
    /// </summary>
    public interface IPCSignatureCapture : IEmulator
    {
        /// <summary>
        /// Sign signature
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void Sign(int timeout);

        /// <summary>
        /// Signature failure
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void Fail(int timeout);

        /// <summary>
        /// Has no hardware
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void NoHardware(int timeout);

        /// <summary>
        /// signature capture is offline
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void Offline(int timeout);
    }
}
