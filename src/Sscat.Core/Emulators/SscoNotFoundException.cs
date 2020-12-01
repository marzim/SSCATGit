// <copyright file="SscoNotFoundException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the SscoNotFoundException class
    /// </summary>
    public class SscoNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the SscoNotFoundException class
        /// </summary>
        public SscoNotFoundException()
            : base("SSCO not Found")
        {
        }
    }
}
