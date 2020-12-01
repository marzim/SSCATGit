// <copyright file="EasyClientEngine.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;
    using System.Net;
    using JadBenAutho.EasySocket;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the EasyClientEngine class
    /// </summary>
    public class EasyClientEngine : AbstractClientEngine, IClientEngine
    {
        /// <summary>
        /// Easy Client
        /// </summary>
        private EasyClient _client = null;

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public override string Server
        {
            get
            {
                return base.Server;
            }

            set
            {
                if (!value.Equals(string.Empty))
                {
                    base.Server = value;

                    base.Server = DnsHelper.GetIPAddress(value);
                    ServerInfo serverInfo = new ServerInfo(IPAddress.Parse(base.Server), Port, true);
                    _client = new EasyClient(serverInfo, "NCR Client");
                    _client.Connected += new Connected_EventHandler(ClientConnected);
                    _client.Disconnected += new Disconnected_EventHandler(ClientDisconnected);
                    _client.DataSent += new DataSent_EventHandler(ClientDataSent);
                    _client.DataArrived += new DataArrived2Client_EventHandler(ClientDataArrived);
                    _client.ConnectionTimeOut += new ConnectionTimeOutError_EventHandler(ClientConnectionTimeOut);
                    _client.ConnectionRejecting += new EventHandler(ClientConnectionRejecting);
                    _client.ConnectionRejected += new EventHandler(ClientConnectionRejected);
                }
            }
        }

        /// <summary>
        /// Sends the request
        /// </summary>
        /// <param name="request">request to send</param>
        public override void SendRequest(Request request)
        {
            _client.SendData(request);
            OnDataSent(new NetworkEventArgs(request));
        }

        /// <summary>
        /// Connect the client engine
        /// </summary>
        public override void Connect()
        {
            base.Connect();
            _client.ConnectToServerAsync();
            _client.TestCommunication();
        }

        /// <summary>
        /// Disconnect the client engine
        /// </summary>
        public override void Disconnect()
        {
            _client.DisconnectFromServer();
            _client.Dispose();
        }

        /// <summary>
        /// Event on client connection rejected
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientConnectionRejected(object sender, EventArgs e)
        {
            OnConnectionRejected(e);
        }

        /// <summary>
        /// Event on client connection rejecting
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientConnectionRejecting(object sender, EventArgs e)
        {
            OnConnectionRejecting(e);
        }

        /// <summary>
        /// Client connection time out
        /// </summary>
        private void ClientConnectionTimeOut()
        {
            OnConnectionTimeOut();
        }

        /// <summary>
        /// Client data arrived
        /// </summary>
        /// <param name="data">data object</param>
        private void ClientDataArrived(object data)
        {
            OnDataArrived(new NetworkEventArgs(data as Response));
        }

        /// <summary>
        /// Client data sent
        /// </summary>
        /// <param name="data">data object</param>
        private void ClientDataSent(object data)
        {
            OnDataSent(new NetworkEventArgs(data.ToString()));
        }

        /// <summary>
        /// Client disconnected
        /// </summary>
        private void ClientDisconnected()
        {
            OnDisconnected(new NetworkEventArgs(string.Format("Disconnected from remote device server. IP Address: {0}", ServerName)));
            _client.Dispose();
        }

        /// <summary>
        /// Client connected
        /// </summary>
        private void ClientConnected()
        {
            OnConnected(new NetworkEventArgs(string.Format("Connected to: {0}", ServerName)));
        }
    }
}
