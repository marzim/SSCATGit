// <copyright file="AbstractServerEngine.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;

    /// <summary>
    /// Initializes a new instance of the AbstractServerEngine class
    /// </summary>
    public abstract class AbstractServerEngine : IServerEngine
    {
        /// <summary>
        /// Request parser interface
        /// </summary>
        private IRequestParser _requestParser;

        /// <summary>
        /// Initializes a new instance of the AbstractServerEngine class
        /// </summary>
        /// <param name="requestParser">request parser</param>
        public AbstractServerEngine(IRequestParser requestParser)
        {
            RequestParser = requestParser;
        }
        
        /// <summary>
        /// Event handler for data sent
        /// </summary>
        public event EventHandler<NetworkEventArgs> DataSent;
        
        /// <summary>
        /// Event handler for data arrived
        /// </summary>
        public event EventHandler<NetworkEventArgs> DataArrived;
        
        /// <summary>
        /// Event handler for client adding
        /// </summary>
        public event EventHandler<NetworkEventArgs> ClientAdding;
        
        /// <summary>
        /// Event handler for stopping
        /// </summary>
        public event EventHandler Stopping;
        
        /// <summary>
        /// Gets or sets the request parser
        /// </summary>
        public IRequestParser RequestParser
        {
            get { return _requestParser; }
            set { _requestParser = value; }
        }
        
        /// <summary>
        /// Server engine is listening
        /// </summary>
        public abstract void Listen();

        /// <summary>
        /// Stop the server engine
        /// </summary>
        public abstract void Stop();

        /// <summary>
        /// Dispose of the server engine
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Send response
        /// </summary>
        /// <param name="response">response to send</param>
        public abstract void SendResponse(Response response);

        /// <summary>
        /// Get client index
        /// </summary>
        /// <param name="client">client to check</param>
        /// <returns>Returns the client index</returns>
        protected abstract int GetClientIndex(string client);

        /// <summary>
        /// Event for on stopping
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
        /// Event for on client adding
        /// </summary>
        /// <param name="e">network event arguments</param>
        protected virtual void OnClientAdding(NetworkEventArgs e)
        {
            if (ClientAdding != null)
            {
                ClientAdding(this, e);
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
