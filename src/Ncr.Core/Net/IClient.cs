// <copyright file="IClient.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;
    using System.Collections;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the IClient interface
    /// </summary>
    public interface IClient : IBaseModel
    {
        /// <summary>
        /// Event handler for connected
        /// </summary>
        event EventHandler<NetworkEventArgs> Connected;

        /// <summary>
        /// Event handler for data arrived
        /// </summary>
        event EventHandler<NetworkEventArgs> DataArrived;

        /// <summary>
        /// Event handler for data sent
        /// </summary>
        event EventHandler<NetworkEventArgs> DataSent;

        /// <summary>
        /// Event handler for disconnected
        /// </summary>
        event EventHandler<NetworkEventArgs> Disconnected;

        /// <summary>
        /// Event handler for connection time out
        /// </summary>
        event EventHandler<NetworkEventArgs> ConnectionTimeOut;

        /// <summary>
        /// Event handler for connection rejecting
        /// </summary>
        event EventHandler ConnectionRejecting;

        /// <summary>
        /// Event handler for response dispatching
        /// </summary>
        event EventHandler<NcrEventArgs> ResponseDispatching;

        /// <summary>
        /// Event handler for error dispatched
        /// </summary>
        event EventHandler ErrorDispatched;

        /// <summary>
        /// Gets or sets the response parser
        /// </summary>
        IResponseParser ResponseParser { get; set; }

        /// <summary>
        /// Gets or sets the dispatchers
        /// </summary>
        Hashtable Dispatchers { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        string Server { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not the client was rejected
        /// </summary>
        bool Rejected { get; set; }

        /// <summary>
        /// Gets the server name
        /// </summary>
        string ServerName { get; }

        /// <summary>
        /// Gets the host name
        /// </summary>
        string HostName { get; }

        /// <summary>
        /// Gets or sets the port number
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// Gets a value indicating whether or not the client has timed out
        /// </summary>
        bool HasTimedOut { get; }

        /// <summary>
        /// Connect the client engine
        /// </summary>
        void Connect();

        /// <summary>
        /// Add response dispatcher
        /// </summary>
        /// <param name="dispatcher">response dispatcher</param>
        void AddDispatcher(IResponseDispatcher dispatcher);

        /// <summary>
        /// Disconnect the client engine
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Sends the request
        /// </summary>
        /// <param name="request">request to send</param>
        void SendRequest(Request request);

        /// <summary>
        /// Receive the response
        /// </summary>
        /// <param name="response">response to receive</param>
        void ReceiveResponse(Response response);

        /// <summary>
        /// Perform the connection time out
        /// </summary>
        void PerformConnectionTimeOut();
    }
}
