// <copyright file="BaseServer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;
    using System.Collections.Generic;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the BaseServer class
    /// </summary>
    public class BaseServer : IServer, IDisposable
    {
        /// <summary>
        /// Port number
        /// </summary>
        private int _port;

        /// <summary>
        /// Request parser
        /// </summary>
        private IRequestParser _requestParser;

        /// <summary>
        /// Server name
        /// </summary>
        private string _name;

        /// <summary>
        /// Whether or not the server has multiple clients
        /// </summary>
        private bool _multipleClients = true;

        /// <summary>
        /// Request dispatcher
        /// </summary>
        private IDictionary<string, IRequestDispatcher> _dispatchers;

        /// <summary>
        /// Server engine
        /// </summary>
        private IServerEngine _engine;

        /// <summary>
        /// Initializes a new instance of the BaseServer class
        /// </summary>
        /// <param name="port">port number</param>
        /// <param name="name">server name</param>
        /// <param name="requestParser">request parser</param>
        /// <param name="engine">server engine</param>
        public BaseServer(int port, string name, IRequestParser requestParser, IServerEngine engine)
        {
            Port = port;
            Name = name;
            RequestParser = requestParser;
            Dispatchers = new Dictionary<string, IRequestDispatcher>();

            _engine = engine;
            engine.DataArrived += new EventHandler<NetworkEventArgs>(EngineDataArrived);
            engine.DataSent += new EventHandler<NetworkEventArgs>(EngineDataSent);
            engine.ClientAdding += new EventHandler<NetworkEventArgs>(EngineClientAdding);
            engine.Stopping += new EventHandler(EngineStopping);

            DataArrived += new EventHandler<NetworkEventArgs>(ServerDataArrived);
        }

        /// <summary>
        /// Event handler on serving
        /// </summary>
        public event EventHandler<NcrEventArgs> Serving;

        /// <summary>
        /// Event handler on data arrived
        /// </summary>
        public event EventHandler<NetworkEventArgs> DataArrived;

        /// <summary>
        /// Event handler on data sent
        /// </summary>
        public event EventHandler<NetworkEventArgs> DataSent;

        /// <summary>
        /// Event handler on stopping
        /// </summary>
        public event EventHandler Stopping;

        /// <summary>
        /// Event handler on starting
        /// </summary>
        public event EventHandler Starting;

        /// <summary>
        /// Gets or sets the request dispatchers
        /// </summary>
        public IDictionary<string, IRequestDispatcher> Dispatchers
        {
            get { return _dispatchers; }
            set { _dispatchers = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the server has multiple clients
        /// </summary>
        public bool MultipleClients
        {
            get { return _multipleClients; }
            set { _multipleClients = value; }
        }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the request parser
        /// </summary>
        public IRequestParser RequestParser
        {
            get { return _requestParser; }
            set { _requestParser = value; }
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
        /// Listens for connections on the port
        /// </summary>
        public virtual void Listen()
        {
            OnServing(string.Format("{0} is starting", Name));
            _engine.Listen();
            OnStarting(null);
            OnServing(string.Format("Listening for connections on port {0}", Port));
        }

        /// <summary>
        /// Stops the server engine
        /// </summary>
        public virtual void Stop()
        {
            _engine.Stop();
        }

        /// <summary>
        /// Sends the response
        /// </summary>
        /// <param name="response">response to send</param>
        public virtual void SendResponse(Response response)
        {
            _engine.SendResponse(response);
        }

        /// <summary>
        /// Dispose of the server engine
        /// </summary>
        public virtual void Dispose()
        {
            _engine.DataArrived -= new EventHandler<NetworkEventArgs>(EngineDataArrived);
            _engine.DataSent -= new EventHandler<NetworkEventArgs>(EngineDataSent);
            _engine.ClientAdding -= new EventHandler<NetworkEventArgs>(EngineClientAdding);
            _engine.Stopping -= new EventHandler(EngineStopping);
            _engine.Dispose();

            DataArrived -= new EventHandler<NetworkEventArgs>(ServerDataArrived);
        }

        /// <summary>
        /// Add dispatcher
        /// </summary>
        /// <param name="dispatcher">request dispatcher</param>
        public virtual void AddDispatcher(IRequestDispatcher dispatcher)
        {
            Dispatchers.Add(dispatcher.Name, dispatcher);
        }

        /// <summary>
        /// Receive request
        /// </summary>
        /// <param name="request">request to receive</param>
        public void ReceiveRequest(Request request)
        {
            OnDataArrived(new NetworkEventArgs(request));
        }

        /// <summary>
        /// Event on starting
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStarting(EventArgs e)
        {
            if (Starting != null)
            {
                Starting(this, e);
            }
        }

        /// <summary>
        /// Event on stopping
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStopping(EventArgs e)
        {
            if (Stopping != null)
            {
                Stopping(this, e);
            }
        }

        /// <summary>
        /// Event on serving
        /// </summary>
        /// <param name="message">event message</param>
        protected virtual void OnServing(string message)
        {
            OnServing(new NcrEventArgs(message));
        }

        /// <summary>
        /// Event on serving
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnServing(NcrEventArgs e)
        {
            if (Serving != null)
            {
                Serving(this, e);
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

        /// <summary>
        /// Event on data arrived
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
        /// Event on server data arrived
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        protected virtual void ServerDataArrived(object sender, NetworkEventArgs e)
        {
            if (_dispatchers.ContainsKey(e.Request.Type))
            {
                IRequestDispatcher dispatcher = Dispatchers[e.Request.Type] as IRequestDispatcher;
                try
                {
                    dispatcher.Dispatching += new EventHandler<NcrEventArgs>(DispatcherDispatching);
                    dispatcher.Dispatched += new EventHandler<ResponseEventArgs>(DispatcherDispatched);
                    dispatcher.Dispatch(e.Request);
                }
                catch (Exception ex)
                {
                    LoggingService.Error(ex.ToString());
                    MessageService.ShowError(ex.Message);
                }
                finally
                {
                    dispatcher.Dispatched -= new EventHandler<ResponseEventArgs>(DispatcherDispatched);
                    dispatcher.Dispatching -= new EventHandler<NcrEventArgs>(DispatcherDispatching);
                }
            }
            else
            {
                string msg = string.Format("No dispatcher for request type '{0}'", e.Request.Type);
                LoggingService.Error(msg);
                MessageService.ShowError(msg);
            }
        }

        /// <summary>
        /// Event on engine stopping
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void EngineStopping(object sender, EventArgs e)
        {
            OnStopping(e);
        }

        /// <summary>
        /// Event on engine client adding
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void EngineClientAdding(object sender, NetworkEventArgs e)
        {
            if (!MultipleClients)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Event for engine data sent
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void EngineDataSent(object sender, NetworkEventArgs e)
        {
            OnDataSent(e);
        }

        /// <summary>
        /// Event for engine data arrived
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void EngineDataArrived(object sender, NetworkEventArgs e)
        {
            OnDataArrived(e);
        }

        /// <summary>
        /// Event on dispatcher dispatching
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherDispatching(object sender, NcrEventArgs e)
        {
            OnServing(e);
        }

        /// <summary>
        /// Event on dispatcher dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">response event arguments</param>
        private void DispatcherDispatched(object sender, ResponseEventArgs e)
        {
            SendResponse(e.Response);
        }
    }
}
