// <copyright file="EmulatorException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the EmulatorException class
    /// </summary>
    [Serializable]
    public class EmulatorException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the EmulatorException class
        /// </summary>
        /// <param name="message">Emulator message</param>
        public EmulatorException(string message)
            : base(message)
        {
        }
    }
}
