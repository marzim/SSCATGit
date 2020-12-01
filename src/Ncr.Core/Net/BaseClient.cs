// <copyright file="BaseClient.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;
    using System.Collections;
    using Ncr.Core.Models;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the BaseClient class
    /// </summary>
    public class BaseClient : BaseModel<BaseClient>, IClient
    {
        /// <summary>
        /// last sent date time locker
        /// </summary>
        private readonly object lastSentDateTimeLocker = new object();

        /// <summary>
        /// Response parser interface
        /// </summary>
        private IResponseParser _responseParser;

        /// <summary>
        /// Client dispatchers
        /// </summary>
        private Hashtable _dispatchers;

        /// <summary>
        /// Whether or not client is rejected
        /// </summary>
        private volatile bool _rejected;

        /// <summary>
        /// Date time now
        /// </summary>
        private volatile int _now;

        /// <summary>
        /// Client engine interface
        /// </summary>
        private IClientEngine _engine;

        /// <summary>
        /// Initializes a new instance of the BaseClient class
        /// </summary>
        /// <param name="port">port number</param>
        /// <param name="responseParser">response parser</param>
        /// <param name="engine">client engine</param>
        public BaseClient(int port, IResponseParser responseParser, IClientEngine engine)
            : this(string.Empty, port, responseParser, engine)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BaseClient class
        /// </summary>
        /// <param name="server">server name</param>
        /// <param name="port">port number</param>
        /// <param name="responseParser">response parser</param>
        /// <param name="engine">client engine</param>
        public BaseClient(string server, int port, IResponseParser responseParser, IClientEngine engine)
        {
            Dispatchers = new Hashtable();
            _engine = engine;

            Server = server;
            Port = port;
            ResponseParser = responseParser;

            engine.Connected += new EventHandler<NetworkEventArgs>(EngineConnected);
            engine.ConnectionTimeOut += new EventHandler<NetworkEventArgs>(EngineConnectionTimeOut);
            engine.DataSent += new EventHandler<NetworkEventArgs>(EngineDataSent);
            engine.DataArrived += new EventHandler<NetworkEventArgs>(EngineDataArrived);
            engine.ConnectionRejecting += new EventHandler(EngineConnectionRejecting);
            engine.ConnectionRejected += new EventHandler(EngineConnectionRejected);
            engine.Disconnected += new EventHandler<NetworkEventArgs>(EngineDisconnected);

            DataArrived += new EventHandler<NetworkEventArgs>(ClientDataArrived);
        }

        /// <summary>
        /// Event handler for connected
        /// </summary>
        public event EventHandler<NetworkEventArgs> Connected;

        /// <summary>
        /// Event handler for data arrived
        /// </summary>
        public event EventHandler<NetworkEventArgs> DataArrived;

        /// <summary>
        /// Event handler for data sent
        /// </summary>
        public event EventHandler<NetworkEventArgs> DataSent;

        /// <summary>
        /// Event handler for disconnected
        /// </summary>
        public event EventHandler<NetworkEventArgs> Disconnected;

        /// <summary>
        /// Event handler for connection time out
        /// </summary>
        public event EventHandler<NetworkEventArgs> ConnectionTimeOut;

        /// <summary>
        /// Event handler for response dispatching
        /// </summary>
        public event EventHandler<NcrEventArgs> ResponseDispatching;

        /// <summary>
        /// Event handler for error dispatched
        /// </summary>
        public event EventHandler ErrorDispatched;

        /// <summary>
        /// Event handler for connection rejecting
        /// </summary>
        public event EventHandler ConnectionRejecting;

        /// <summary>
        /// Event handler for connection rejected
        /// </summary>
        public event EventHandler ConnectionRejected;

        /// <summary>
        /// Gets the timeout
        /// </summary>
        public int Timeout
        {
            get { return 60000 * 5; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the client has timed out
        /// </summary>
        public bool HasTimedOut
        {
            get { return (Environment.TickCount - _now) > Timeout; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the client has rejected
        /// </summary>
        public bool Rejected
        {
            get { return _rejected; }
            set { _rejected = value; }
        }

        /// <summary>
        /// Gets the host name
        /// </summary>
        public string HostName
        {
            get { return DnsHelper.GetLocalIPAddress(); }
        }

        /// <summary>
        /// Gets the server name
        /// </summary>
        public string ServerName
        {
            get { return _engine.ServerName; }
        }

        /// <summary>
        /// Gets or sets the dispatchers
        /// </summary>
        public Hashtable Dispatchers
        {
            get { return _dispatchers; }
            set { _dispatchers = value; }
        }

        /// <summary>
        /// Gets or sets the response parser
        /// </summary>
        public IResponseParser ResponseParser
        {
            get { return _responseParser; }
            set { _responseParser = value; }
        }

        /// <summary>
        /// Gets or sets the server name
        /// </summary>
        public virtual string Server
        {
            get { return _engine.Server; }
            set { _engine.Server = value; }
        }

        /// <summary>
        /// Gets or sets the port number
        /// </summary>
        public int Port
        {
            get { return _engine.Port; }
            set { _engine.Port = value; }
        }

        /// <summary>
        /// Validates the server name
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            AddErrorIf("Server name should not be blank", ServerName == null || ServerName == string.Empty);
        }

        /// <summary>
        /// Add dispatcher
        /// </summary>
        /// <param name="dispatcher">response dispatcher</param>
        public virtual void AddDispatcher(IResponseDispatcher dispatcher)
        {
            AddDispatcher(dispatcher.Name, dispatcher);
        }

        /// <summary>
        /// Add dispatcher
        /// </summary>
        /// <param name="key">dispatcher key</param>
        /// <param name="dispatcher">response dispatcher</param>
        public virtual void AddDispatcher(string key, IResponseDispatcher dispatcher)
        {
            Dispatchers.Add(key, dispatcher);
        }

        /// <summary>
        /// Connect the client engine
        /// </summary>
        public virtual void Connect()
        {
            Rejected = false;
            _engine.Connect();
        }

        /// <summary>
        /// Disconnect the client engine
        /// </summary>
        public virtual void Disconnect()
        {
            _engine.Disconnect();
        }

        /// <summary>
        /// Send request
        /// </summary>
        /// <param name="request">request to send</param>
        public virtual void SendRequest(Request request)
        {
            request.Client = HostName;
            _engine.SendRequest(request);
        }

        /// <summary>
        /// Receive response
        /// </summary>
        /// <param name="response">response to receive</param>
        public void ReceiveResponse(Response response)
        {
            OnDataArrived(new NetworkEventArgs(response));
        }

        /// <summary>
        /// Perform connection timeout
        /// </summary>
        public void PerformConnectionTimeOut()
        {
            OnConnectionTimeOut();
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
        /// Event on connection rejecting
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConnectionRejecting(EventArgs e)
        {
            _rejected = true;
            if (ConnectionRejecting != null)
            {
                ConnectionRejecting(this, e);
            }
        }

        /// <summary>
        /// Event on error dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnErrorDispatched(EventArgs e)
        {
            if (ErrorDispatched != null)
            {
                ErrorDispatched(this, e);
            }
        }

        /// <summary>
        /// Event on response dispatching
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnResponseDispatching(NcrEventArgs e)
        {
            if (ResponseDispatching != null)
            {
                ResponseDispatching(this, e);
            }
        }

        /// <summary>
        /// Event on connection timeout
        /// </summary>
        protected virtual void OnConnectionTimeOut()
        {
            OnConnectionTimeOut(string.Format("Connection Timeout. Connection attempted to the server has failed. IP Address: {0}, Port: {1}", Server, Port));
        }

        /// <summary>
        /// Event on connection timeout
        /// </summary>
        /// <param name="message">timeout message</param>
        protected virtual void OnConnectionTimeOut(string message)
        {
            OnConnectionTimeOut(new NetworkEventArgs(message));
        }

        /// <summary>
        /// Event on connection timeout
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
        /// Event on data sent
        /// </summary>
        /// <param name="e">network event arguments</param>
        protected virtual void OnDataSent(NetworkEventArgs e)
        {
            _now = Environment.TickCount;
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
            _now = Environment.TickCount;
            if (DataArrived != null)
            {
                DataArrived(this, e);
            }
        }

        /// <summary>
        /// Event on connected
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
        /// Event on Client data arrived
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        protected virtual void ClientDataArrived(object sender, NetworkEventArgs e)
        {
            if (_dispatchers.ContainsKey(e.Response.Type))
            {
                IResponseDispatcher dispatcher = _dispatchers[e.Response.Type] as IResponseDispatcher;
                try
                {
                    dispatcher.Dispatching += new EventHandler<NcrEventArgs>(DispatcherDispatching);
                    dispatcher.ErrorDispatched += new EventHandler(DispatcherErrorDispatched);
                    dispatcher.Dispatch(e.Response);
                }
                catch (Exception ex)
                {
                    LoggingService.Error(ex.ToString());
                    MessageService.ShowError(ex.Message);
                }
                finally
                {
                    dispatcher.Dispatching -= new EventHandler<NcrEventArgs>(DispatcherDispatching);
                    dispatcher.ErrorDispatched -= new EventHandler(DispatcherErrorDispatched);
                }
            }
            else
            {
                throw new NotSupportedException(string.Format("Response dispatcher for type '{0}' not supported", e.Response.Type));
            }
        }

        /// <summary>
        /// Event on engine connection rejected
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void EngineConnectionRejected(object sender, EventArgs e)
        {
            OnConnectionRejected(e);
        }

        /// <summary>
        /// Event on engine connection rejecting
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void EngineConnectionRejecting(object sender, EventArgs e)
        {
            OnConnectionRejecting(e);
        }

        /// <summary>
        /// Event on engine data arrived
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void EngineDataArrived(object sender, NetworkEventArgs e)
        {
            OnDataArrived(e);
        }

        /// <summary>
        /// Event on engine data sent
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void EngineDataSent(object sender, NetworkEventArgs e)
        {
            OnDataSent(e);
        }

        /// <summary>
        /// Event on engine connection timeout
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void EngineConnectionTimeOut(object sender, NetworkEventArgs e)
        {
            OnConnectionTimeOut(e);
        }

        /// <summary>
        /// Event on engine disconnected
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void EngineDisconnected(object sender, NetworkEventArgs e)
        {
            OnDisconnected(e);
        }

        /// <summary>
        /// Event on engine connected
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void EngineConnected(object sender, NetworkEventArgs e)
        {
            OnConnected(e);
        }

        /// <summary>
        /// Event on dispatcher error dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherErrorDispatched(object sender, EventArgs e)
        {
            OnErrorDispatched(e);
        }

        /// <summary>
        /// Event on dispatcher dispatching
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherDispatching(object sender, NcrEventArgs e)
        {
            OnResponseDispatching(e);
        }
    }
}
