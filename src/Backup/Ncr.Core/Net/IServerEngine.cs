// <copyright file="IServerEngine.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;

    /// <summary>
    /// Initializes a new instance of the IServerEngine interface
    /// </summary>
    public interface IServerEngine : IDisposable
    {
        /// <summary>
        /// Event handler for data arrived
        /// </summary>
        event EventHandler<NetworkEventArgs> DataArrived;

        /// <summary>
        /// Event handler for data sent
        /// </summary>
        event EventHandler<NetworkEventArgs> DataSent;

        /// <summary>
        /// Event handler for client adding
        /// </summary>
        event EventHandler<NetworkEventArgs> ClientAdding;

        /// <summary>
        /// Event handler for stopping server
        /// </summary>
        event EventHandler Stopping;

        /// <summary>
        /// Start listening on the server
        /// </summary>
        void Listen();

        /// <summary>
        /// Stop listening on the server
        /// </summary>
        void Stop();

        /// <summary>
        /// Send the response
        /// </summary>
        /// <param name="response">response to send</param>
        void SendResponse(Response response);
    }
}
