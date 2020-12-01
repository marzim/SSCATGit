// <copyright file="IScanner.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    /// <summary>
    /// Initializes a new instance of the IScanner interface
    /// </summary>
    public interface IScanner : IEmulator
    {
        /// <summary>
        /// Scans the code
        /// </summary>
        /// <param name="code">scan code</param>
        /// <param name="timeout">timeout amount</param>
        void Scan(string code, int timeout);

        /// <summary>
        /// Scanner invoking error
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        void Error(int timeout);
    }
}
