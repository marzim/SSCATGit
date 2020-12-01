// <copyright file="ICashTrough.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ICashTrough class
    /// </summary>
    public interface ICashTrough : IEmulator
    {
        /// <summary>
        /// Cash trough remove
        /// </summary>
        /// <param name="deviceValue">device value</param>
        /// <param name="timeout">timeout amount</param>
        void Remove(string deviceValue, int timeout);
    }
}
