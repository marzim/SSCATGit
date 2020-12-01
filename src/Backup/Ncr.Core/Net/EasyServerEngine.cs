// <copyright file="EasyServerEngine.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;
    using System.Net.Sockets;
    using JadBenAutho.EasySocket;

    /// <summary>
    /// Initializes a new instance of the EasyServerEngine class
    /// </summary>
    public class EasyServerEngine : AbstractServerEngine, IServerEngine
    {
        /// <summary>
        /// Easy server
        /// </summary>
        private EasyServer _server;

        /// <summary>
        /// Initializes a new instance of the EasyServerEngine class
        /// </summary>
        /// <param name="portNumber">port number</param>
        /// <param name="serverName">server name</param>
        /// <param name="requestParser">request parser</param>
        public EasyServerEngine(int portNumber, string serverName, IRequestParser requestParser)
            : base(requestParser)
        {
            _server = new EasyServer(portNumber, serverName, false);
            _server.DataArrived += new DataArrived2Server_EventHandler(EasyServerDataArrived);
            _server.ClientAdding += new EventHandler<ClientEventArgs>(ServerClientAdding);
            _server.ClientRejected += new ClientRejected_EventHandler(ServerClientRejected);
        }

        /// <summary>
        /// Event handler for client rejected
        /// </summary>
        public event EventHandler ClientRejected;

        /// <summary>
        /// Start listening on the server
        /// </summary>
        public override void Listen()
        {
            _server.StartListen();
        }

        /// <summary>
        /// Stop listening on the server
        /// </summary>
        public override void Stop()
        {
            _server.StopListen();
        }
        
        /// <summary>
        /// Send the response
        /// </summary>
        /// <param name="response">response to send</param>
        public override void SendResponse(Response response)
        {
            if (_server != null && !_server.IsDisposed)
            {
                int index = GetClientIndex(response.Client);
                if (index >= 0)
                {
                    _server.SendData(response, index);
                    OnDataSent(new NetworkEventArgs(response));
                }
                else
                {
                    throw new ClientDisconnectedException(string.Format("Client {0} not found or disconnected.", response.Client));
                }
            }
        }

        /// <summary>
        /// Dispose of the server
        /// </summary>
        public override void Dispose()
        {
            _server.DataArrived -= new DataArrived2Server_EventHandler(EasyServerDataArrived);
            _server.ClientAdding -= new EventHandler<ClientEventArgs>(ServerClientAdding);
            _server.ClientRejected -= new ClientRejected_EventHandler(ServerClientRejected);

            _server.StopListen();
            _server.Dispose();
        }

        /// <summary>
        /// Get the client index
        /// </summary>
        /// <param name="client">client to check</param>
        /// <returns>Returns the client index if found, -1 otherwise</returns>
        protected override int GetClientIndex(string client)
        {
            if (_server != null && !_server.IsDisposed)
            {
                foreach (SocketStream s in _server.ClientsList)
                {
                    string endPoint = s.GetSocket.RemoteEndPoint.ToString();
                    if (client == endPoint.Substring(0, endPoint.IndexOf(':')))
                    {
                        return _server.ClientsList.IndexOf(s);
                    }
                }
            }

            return -1;
        }

        /// <summary>
        /// Event on client rejected
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnClientRejected(EventArgs e)
        {
            if (ClientRejected != null)
            {
                ClientRejected(this, e);
            }
        }

        /// <summary>
        /// Event on easy server data arrived
        /// </summary>
        /// <param name="data">object data</param>
        /// <param name="dataSender">data sender</param>
        private void EasyServerDataArrived(object data, SocketStream dataSender)
        {
            OnDataArrived(new NetworkEventArgs(data as Request));
        }

        /// <summary>
        /// Event on server client rejected
        /// </summary>
        /// <param name="rejectedClientSocket">rejected client socket</param>
        private void ServerClientRejected(Socket rejectedClientSocket)
        {
            OnClientRejected(null);
        }

        /// <summary>
        /// Event on server client adding
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">client event arguments</param>
        private void ServerClientAdding(object sender, ClientEventArgs e)
        {
            if (_server.ClientsList.Count > 0)
            {
                NetworkEventArgs n = new NetworkEventArgs(string.Empty);
                OnClientAdding(n);
                e.Cancel = n.Cancel;
            }
        }
    }
}
