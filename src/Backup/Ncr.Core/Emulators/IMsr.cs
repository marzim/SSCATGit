// <copyright file="IMsr.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the IMsr interface
    /// </summary>
    public interface IMsr : IEmulator
    {
        /// <summary>
        /// Swipe the MSR card
        /// </summary>
        /// <param name="value">card code</param>
        /// <param name="timeout">timeout amount</param>
        void Swipe(string value, int timeout);
    }
}
