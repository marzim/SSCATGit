// <copyright file="IClientEngine.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;

    /// <summary>
    /// Initializes a new instance of the IClientEngine interface
    /// </summary>
    public interface IClientEngine
    {
        /// <summary>
        /// Event handler for connected
        /// </summary>
        event EventHandler<NetworkEventArgs> Connected;

        /// <summary>
        /// Event handler for connection time out
        /// </summary>
        event EventHandler<NetworkEventArgs> ConnectionTimeOut;

        /// <summary>
        /// Event handler for disconnected
        /// </summary>
        event EventHandler<NetworkEventArgs> Disconnected;

        /// <summary>
        /// Event handler for data sent
        /// </summary>
        event EventHandler<NetworkEventArgs> DataSent;

        /// <summary>
        /// Event handler for data arrived
        /// </summary>
        event EventHandler<NetworkEventArgs> DataArrived;

        /// <summary>
        /// Event handler for connection rejecting
        /// </summary>
        event EventHandler ConnectionRejecting;

        /// <summary>
        /// Event handler for connection rejected
        /// </summary>
        event EventHandler ConnectionRejected;

        /// <summary>
        /// Gets or sets the port number
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        string Server { get; set; }

        /// <summary>
        /// Gets the server name
        /// </summary>
        string ServerName { get; }

        /// <summary>
        /// Connect the client engine
        /// </summary>
        void Connect();

        /// <summary>
        /// Disconnect the client engine
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Sends the request
        /// </summary>
        /// <param name="request">request to send</param>
        void SendRequest(Request request);
    }
}
