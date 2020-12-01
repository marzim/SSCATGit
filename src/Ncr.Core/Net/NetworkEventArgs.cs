// <copyright file="NetworkEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;

    /// <summary>
    /// Initializes a new instance of the NetworkEventArgs class
    /// </summary>
    public class NetworkEventArgs : EventArgs
    {
        /// <summary>
        /// Event message
        /// </summary>
        private string _message;

        /// <summary>
        /// Event request
        /// </summary>
        private Request _request;

        /// <summary>
        /// Event response
        /// </summary>
        private Response _response;

        /// <summary>
        /// Whether or not to cancel event
        /// </summary>
        private bool _cancel;

        /// <summary>
        /// Initializes a new instance of the NetworkEventArgs class
        /// </summary>
        /// <param name="request">Event request</param>
        public NetworkEventArgs(Request request)
        {
            Request = request;
        }

        /// <summary>
        /// Initializes a new instance of the NetworkEventArgs class
        /// </summary>
        /// <param name="response">event response</param>
        public NetworkEventArgs(Response response)
        {
            Response = response;
        }

        /// <summary>
        /// Initializes a new instance of the NetworkEventArgs class
        /// </summary>
        /// <param name="message">event message</param>
        public NetworkEventArgs(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not to cancel
        /// </summary>
        public bool Cancel
        {
            get { return _cancel; }
            set { _cancel = value; }
        }

        /// <summary>
        /// Gets or sets the event response
        /// </summary>
        public Response Response
        {
            get { return _response; }
            set { _response = value; }
        }

        /// <summary>
        /// Gets or sets the event request
        /// </summary>
        public Request Request
        {
            get { return _request; }
            set { _request = value; }
        }

        /// <summary>
        /// Gets or sets the event message
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
