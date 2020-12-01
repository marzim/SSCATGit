// <copyright file="ClientDisconnectedException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ClientDisconnectedException class
    /// </summary>
    [Serializable]
    public class ClientDisconnectedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the ClientDisconnectedException class
        /// </summary>
        /// <param name="message">exception message</param>
        public ClientDisconnectedException(string message)
            : base(message)
        {
        }
    }
}
