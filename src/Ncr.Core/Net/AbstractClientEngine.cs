// <copyright file="AbstractClientEngine.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;

    /// <summary>
    /// Initializes a new instance of the AbstractClientEngine class
    /// </summary>
    public abstract class AbstractClientEngine : IClientEngine
    {
        /// <summary>
        /// Server name
        /// </summary>
        private string _server;

        /// <summary>
        /// Whether or not client is rejected
        /// </summary>
        private volatile bool _rejected;

        /// <summary>
        /// Server name
        /// </summary>
        private string _serverName;

        /// <summary>
        /// Port number
        /// </summary>
        private int _port;

        /// <summary>
        /// Initializes a new instance of the AbstractClientEngine class
        /// </summary>
        public AbstractClientEngine()
        {
        }

        /// <summary>
        /// Event handler for data sent
        /// </summary>
        public event EventHandler<NetworkEventArgs> DataSent;

        /// <summary>
        /// Event handler for connection rejecting
        /// </summary>
        public event EventHandler ConnectionRejecting;

        /// <summary>
        /// Event handler for connection rejected
        /// </summary>
        public event EventHandler ConnectionRejected;

        /// <summary>
        /// Event handler for connection time out
        /// </summary>
        public event EventHandler<NetworkEventArgs> ConnectionTimeOut;

        /// <summary>
        /// Event handler for data arrived
        /// </summary>
        public event EventHandler<NetworkEventArgs> DataArrived;

        /// <summary>
        /// Event handler for disconnected
        /// </summary>
        public event EventHandler<NetworkEventArgs> Disconnected;

        /// <summary>
        /// Event handler for connected
        /// </summary>
        public event EventHandler<NetworkEventArgs> Connected;

        /// <summary>
        /// Gets the server name
        /// </summary>
        public string ServerName
        {
            get { return _serverName; }
        }

        /// <summary>
        /// Gets or sets the port number
        /// </summary>
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public virtual string Server
        {
            get
            {
                return _server;
            }

            set
            {
                _server = value;
                _serverName = _server;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the client was rejected
        /// </summary>
        public bool Rejected
        {
            get { return _rejected; }
            set { _rejected = value; }
        }

        /// <summary>
        /// Disconnect the client engine
        /// </summary>
        public abstract void Disconnect();

        /// <summary>
        /// Sends the request
        /// </summary>
        /// <param name="request">request to send</param>
        public abstract void SendRequest(Request request);

        /// <summary>
        /// Connect the client engine
        /// </summary>
        public virtual void Connect()
        {
            Rejected = false;
        }

        /// <summary>
        /// Event for on connection rejecting
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConnectionRejecting(EventArgs e)
        {
            if (ConnectionRejecting != null)
            {
                ConnectionRejecting(this, e);
            }
        }

        /// <summary>
        /// Event for on connected
        /// </summary>
        /// <param name="e">network event arguments</param>
        protected virtual void OnConnected(NetworkEventArgs e)
        {
            if (Connected != null)
            {
                Connected(this, e);
            }
        }

        /// <summary>
        /// Event on disconnected
        /// </summary>
        /// <param name="e">network event arguments</param>
        protected virtual void OnDisconnected(NetworkEventArgs e)
        {
            if (Disconnected != null)
            {
                Disconnected(this, e);
            }
        }

        /// <summary>
        /// Event for on data arrived
        /// </summary>
        /// <param name="e">network event arguments</param>
        protected virtual void OnDataArrived(NetworkEventArgs e)
        {
            if (DataArrived != null)
            {
                DataArrived(this, e);
            }
        }

        /// <summary>
        /// On connection time out
        /// </summary>
        protected virtual void OnConnectionTimeOut()
        {
            OnConnectionTimeOut(string.Format("Connection Timeout. Connection attempted to the server is failed. IP Address: {0}, Port: {1}", Server, Port));
        }

        /// <summary>
        /// On connection time out
        /// </summary>
        /// <param name="message">timeout message</param>
        protected virtual void OnConnectionTimeOut(string message)
        {
            OnConnectionTimeOut(new NetworkEventArgs(message));
        }

        /// <summary>
        /// Event for on connection timeout
        /// </summary>
        /// <param name="e">network event arguments</param>
        protected virtual void OnConnectionTimeOut(NetworkEventArgs e)
        {
            if (ConnectionTimeOut != null)
            {
                ConnectionTimeOut(this, e);
            }
        }

        /// <summary>
        /// Event on connection rejected
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConnectionRejected(EventArgs e)
        {
            if (ConnectionRejected != null)
            {
                ConnectionRejected(this, e);
            }
        }

        /// <summary>
        /// Event on data sent
        /// </summary>
        /// <param name="e">network event arguments</param>
        protected virtual void OnDataSent(NetworkEventArgs e)
        {
            if (DataSent != null)
            {
                DataSent(this, e);
            }
        }
    }
}
