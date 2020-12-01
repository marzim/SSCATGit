// <copyright file="AutoTestException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events.UIAutoTest
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Exceptions for the UI Automated test events
    /// </summary>
    [Serializable]
    public class AutoTestException : Exception, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the AutoTestException class
        /// </summary>
        public AutoTestException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AutoTestException class
        /// </summary>
        /// <param name="message">exception message</param>
        public AutoTestException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the AutoTestException class
        /// </summary>
        /// <param name="orderId">the order ID</param>
        /// <param name="message">exception message</param>
        /// <param name="innerException">inner exception</param>
        public AutoTestException(int orderId, string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
