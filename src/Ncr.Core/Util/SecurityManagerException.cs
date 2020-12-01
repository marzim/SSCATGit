// <copyright file="SecurityManagerException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the SecurityManagerException class
    /// </summary>
    public class SecurityManagerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the SecurityManagerException class
        /// </summary>
        /// <param name="message">exception message</param>
        public SecurityManagerException(string message)
            : base(message)
        {
        }
    }
}
