// <copyright file="NcrEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core
{
    using System;

    /// <summary>
    /// Initializes a new instance of the NcrEventArgs class
    /// </summary>
    public class NcrEventArgs : EventArgs
    {
        /// <summary>
        /// Event message
        /// </summary>
        private string _message;
        
        /// <summary>
        /// Initializes a new instance of the NcrEventArgs class
        /// </summary>
        /// <param name="message">event message</param>
        public NcrEventArgs(string message)
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
    }
}
