// <copyright file="ResponseEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ResponseEventArgs class
    /// </summary>
    public class ResponseEventArgs : EventArgs
    {
        /// <summary>
        /// Event response
        /// </summary>
        private Response _response;

        /// <summary>
        /// Initializes a new instance of the ResponseEventArgs class
        /// </summary>
        /// <param name="response">Event response</param>
        public ResponseEventArgs(Response response)
        {
            Response = response;
        }

        /// <summary>
        /// Gets or sets the response
        /// </summary>
        public Response Response
        {
            get { return _response; }
            set { _response = value; }
        }
    }
}
