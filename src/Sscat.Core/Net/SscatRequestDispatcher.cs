// <copyright file="SscatRequestDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using Ncr.Core.Models;
    using Ncr.Core.Net;

    /// <summary>
    /// Initializes a new instance of the SscatRequestDispatcher class
    /// </summary>
    public abstract class SscatRequestDispatcher : RequestDispatcher, ISscatRequestDispatcher
    {
        /// <summary>
        /// SSCAT server
        /// </summary>
        private SscatServer _server;

        /// <summary>
        /// Initializes a new instance of the SscatRequestDispatcher class
        /// </summary>
        /// <param name="name">dispatcher name</param>
        public SscatRequestDispatcher(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Event handler for connection adding
        /// </summary>
        public event EventHandler<PsxWrapperEventArgs> ConnectionAdding;

        /// <summary>
        /// Event handler for log hook initialize
        /// </summary>
        public event EventHandler LogHookInitialize;

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
        /// Gets or sets the SSCAT server
        /// </summary>
        public SscatServer Server
        {
            get { return _server; }
            set { _server = value; }
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
        /// Event for on connection adding
        /// </summary>
        /// <param name="e">psx event arguments</param>
        protected virtual void OnConnectionAdding(PsxWrapperEventArgs e)
        {
            if (ConnectionAdding != null)
            {
                ConnectionAdding(this, e);
            }
        }
    }
}
