// <copyright file="SscatServer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using Ncr.Core.Models;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;

    /// <summary>
    /// Initializes a new instance of the SscatServer class
    /// </summary>
    public class SscatServer : BaseServer
    {
        /// <summary>
        /// Whether or not server stop dispatched
        /// </summary>
        private volatile bool _stopDispatch;

        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// SSCAT client
        /// </summary>
        private SscatClient _client;

        /// <summary>
        /// SSCAT server worker
        /// </summary>
        private SscatServerWorker _worker;

        /// <summary>
        /// Initializes a new instance of the SscatServer class
        /// </summary>
        /// <param name="port">port number</param>
        /// <param name="requestParser">request parser</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="engine">server engine</param>
        public SscatServer(int port, IRequestParser requestParser, SscatLane lane, IServerEngine engine)
            : base(port, "SSCAT Server", requestParser, engine)
        {
            Lane = lane;
            MultipleClients = false;

            _worker = new SscatServerWorker(this);
        }

        /// <summary>
        /// Event handler for log hook initialize
        /// </summary>
        public event EventHandler LogHookInitialize;

        /// <summary>
        /// Event handler for connection adding
        /// </summary>
        public event EventHandler<PsxWrapperEventArgs> ConnectionAdding;

        /// <summary>
        /// Event handler for parser initialize
        /// </summary>
        public event EventHandler ParserInitialize;

        /// <summary>
        /// Event handler for client initialize
        /// </summary>
        public event EventHandler ClientInitialize;

        /// <summary>
        /// Event handler for logger start
        /// </summary>
        public event EventHandler LoggerStart;

        /// <summary>
        /// Event handler for logger stop 
        /// </summary>
        public event EventHandler LoggerStop;

        /// <summary>
        /// Gets or sets the SSCAT client
        /// </summary>
        public SscatClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        /// <summary>
        /// Gets or sets the SSCAT lane
        /// </summary>
        public SscatLane Lane
        {
            get { return _lane; }
            set { _lane = value; }
        }

        /// <summary>
        /// Starts the logger
        /// </summary>
        public void StartLogger()
        {
            OnLoggerStart(null);
        }

        /// <summary>
        /// Stops the logger
        /// </summary>
        public void StopLogger()
        {
            OnLoggerStop(null);
        }

        /// <summary>
        /// Adds the dispatcher
        /// </summary>
        /// <param name="dispatcher">dispatcher to add</param>
        public override void AddDispatcher(IRequestDispatcher dispatcher)
        {
            if (dispatcher is ISscatRequestDispatcher)
            {
                AddDispatcher(dispatcher as ISscatRequestDispatcher);
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Adds the dispatcher
        /// </summary>
        /// <param name="dispatcher">dispatcher to add</param>
        public virtual void AddDispatcher(ISscatRequestDispatcher dispatcher)
        {
            dispatcher.Server = this;
            Dispatchers.Add(dispatcher.Name, dispatcher);
        }

        /// <summary>
        /// Stops dispatching
        /// </summary>
        public void StopDispatching()
        {
            _stopDispatch = true;
            Lane.Stop();
        }

        /// <summary>
        /// Starts dispatching
        /// </summary>
        public void StartDispatching()
        {
            _stopDispatch = false;
        }

        /// <summary>
        /// Adds the PSX connection
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="service">service name</param>
        /// <param name="connection">connection name</param>
        /// <param name="timeout">timeout amount</param>
        public void AddPsxConnection(string host, string service, string connection, int timeout)
        {
            OnConnectionAdding(new PsxWrapperEventArgs(host, service, connection, timeout));
        }

        /// <summary>
        /// Initializes the log hook
        /// </summary>
        public void InitializeLogHook()
        {
            OnLogHookInitialize(null);
        }

        /// <summary>
        /// Performs the serving
        /// </summary>
        /// <param name="message">message to send</param>
        public void PerformServing(string message)
        {
            OnServing(message);
        }

        /// <summary>
        /// Initialize the parsers
        /// </summary>
        public void InitializeParsers()
        {
            OnParserInitialize(null);
        }

        /// <summary>
        /// Initializes the client
        /// </summary>
        public void InitializeClient()
        {
            OnClientInitialize(null);
        }

        /// <summary>
        /// Event for on logger start
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnLoggerStart(EventArgs e)
        {
            if (LoggerStart != null)
            {
                LoggerStart(this, e);
            }
        }

        /// <summary>
        /// Event for on logger stop
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnLoggerStop(EventArgs e)
        {
            if (LoggerStop != null)
            {
                LoggerStop(this, e);
            }
        }

        /// <summary>
        /// Event for on parser initialize
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnParserInitialize(EventArgs e)
        {
            if (ParserInitialize != null)
            {
                ParserInitialize(this, e);
            }
        }

        /// <summary>
        /// Event for on client initialize
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnClientInitialize(EventArgs e)
        {
            if (ClientInitialize != null)
            {
                ClientInitialize(this, e);
            }
        }

        /// <summary>
        /// Event for on connection adding
        /// </summary>
        /// <param name="e">psx wrapper event arguments</param>
        protected virtual void OnConnectionAdding(PsxWrapperEventArgs e)
        {
            if (ConnectionAdding != null)
            {
                ConnectionAdding(this, e);
            }
        }

        /// <summary>
        /// Event for on log hook initialize
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnLogHookInitialize(EventArgs e)
        {
            if (LogHookInitialize != null)
            {
                LogHookInitialize(this, e);
            }
        }

        /// <summary>
        /// Event for server data arrived
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        protected override void ServerDataArrived(object sender, NetworkEventArgs e)
        {
            _worker.Request = e.Request;
            ThreadHelper.Start(_worker.DispatchRequest);
        }
    }
}
