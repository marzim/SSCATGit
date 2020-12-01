// <copyright file="MessageContent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;

    /// <summary>
    /// Initializes a new instance of the MessageContent class
    /// </summary>
    [Serializable]
    public class MessageContent : IContent
    {
        /// <summary>
        /// Message to check
        /// </summary>
        private string _message;

        /// <summary>
        /// Initializes a new instance of the MessageContent class
        /// </summary>
        /// <param name="message">message to check</param>
        public MessageContent(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Gets or sets the message
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        /// <summary>
        /// Dispose of the message
        /// </summary>
        public virtual void Dispose()
        {
            Message = string.Empty;
        }
    }
}
