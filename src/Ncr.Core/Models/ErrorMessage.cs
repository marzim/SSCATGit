// <copyright file="ErrorMessage.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Models
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ErrorMessage class
    /// </summary>
    [Serializable]
    public class ErrorMessage
    {
        /// <summary>
        /// Error message
        /// </summary>
        private string _message;

        /// <summary>
        /// Initializes a new instance of the ErrorMessage class
        /// </summary>
        /// <param name="message">error message</param>
        public ErrorMessage(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        /// <summary>
        /// Outputs the message in the string format
        /// </summary>
        /// <returns>Returns the formatted string</returns>
        public override string ToString()
        {
            return Message;
        }
    }
}
