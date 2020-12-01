// <copyright file="IServer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Initializes a new instance of the IServer interface
    /// </summary>
    public interface IServer : IDisposable
    {
        /// <summary>
        /// Event handler for serving
        /// </summary>
        event EventHandler<NcrEventArgs> Serving;

        /// <summary>
        /// Event handler for data arrived
        /// </summary>
        event EventHandler<NetworkEventArgs> DataArrived;

        /// <summary>
        /// Event handler for data sent
        /// </summary>
        event EventHandler<NetworkEventArgs> DataSent;

        /// <summary>
        /// Event handler for stopping
        /// </summary>
        event EventHandler Stopping;

        /// <summary>
        /// Event handler for starting
        /// </summary>
        event EventHandler Starting;

        /// <summary>
        /// Gets or sets the request dispatchers
        /// </summary>
        IDictionary<string, IRequestDispatcher> Dispatchers { get; set; }

        /// <summary>
        /// Gets or sets the port number
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// Gets or sets the request parser
        /// </summary>
        IRequestParser RequestParser { get; set; }

        /// <summary>
        /// Listening on the server
        /// </summary>
        void Listen();

        /// <summary>
        /// Stop the server
        /// </summary>
        void Stop();

        /// <summary>
        /// Add request dispatcher
        /// </summary>
        /// <param name="dispatcher">request dispatcher</param>
        void AddDispatcher(IRequestDispatcher dispatcher);

        /// <summary>
        /// Send the response
        /// </summary>
        /// <param name="response">response to send</param>
        void SendResponse(Response response);

        /// <summary>
        /// Receive the request
        /// </summary>
        /// <param name="request">request to receive</param>
        void ReceiveRequest(Request request);
    }
}
