// <copyright file="SscatServerWorker.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using Ncr.Core;
    using Ncr.Core.Models;
    using Ncr.Core.Net;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the SscatServerWorker class
    /// </summary>
    public class SscatServerWorker
    {
        /// <summary>
        /// SSCAT server
        /// </summary>
        private SscatServer _server;

        /// <summary>
        /// Server request
        /// </summary>
        private Request _request;

        /// <summary>
        /// Initializes a new instance of the SscatServerWorker class
        /// </summary>
        /// <param name="server">sscat server</param>
        public SscatServerWorker(SscatServer server)
        {
            _server = server;
        }

        /// <summary>
        /// Gets or sets the request
        /// </summary>
        public Request Request
        {
            get { return _request; }
            set { _request = value; }
        }

        /// <summary>
        /// Gets or sets the dispatch request
        /// </summary>
        public void DispatchRequest()
        {
            _server.StartDispatching();
            if (_server.Dispatchers.ContainsKey(Request.Type))
            {
                ISscatRequestDispatcher dispatcher = _server.Dispatchers[Request.Type] as ISscatRequestDispatcher;
                try
                {
                    dispatcher.Dispatching += new EventHandler<NcrEventArgs>(DispatcherDispatching);
                    dispatcher.Dispatched += new EventHandler<ResponseEventArgs>(DispatcherDispatched);
                    dispatcher.LogHookInitialize += new EventHandler(DispatcherLogHookInitialize);
                    dispatcher.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(DispatcherConnectionAdding);
                    dispatcher.ParserInitialize += new EventHandler(DispatcherParserInitialize);
                    dispatcher.ClientInitialize += new EventHandler(DispatcherClientInitialize);
                    dispatcher.LoggerStart += new EventHandler(DispatcherLoggerStart);
                    dispatcher.LoggerStop += new EventHandler(DispatcherLoggerStop);

                    dispatcher.Dispatch(Request);
                }
                catch (ClientDisconnectedException ex)
                {
                    LoggingService.Error(ex.ToString());
                    MessageService.ShowError("Unable to locate SSCAT Client.");
                }
                catch (Exception ex)
                {
                    LoggingService.Error(ex.ToString());
                    MessageService.ShowError(ex.Message);
                }
                finally
                {
                    dispatcher.Dispatching -= new EventHandler<NcrEventArgs>(DispatcherDispatching);
                    dispatcher.Dispatched -= new EventHandler<ResponseEventArgs>(DispatcherDispatched);
                    dispatcher.LogHookInitialize -= new EventHandler(DispatcherLogHookInitialize);
                    dispatcher.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(DispatcherConnectionAdding);
                    dispatcher.ParserInitialize -= new EventHandler(DispatcherParserInitialize);
                    dispatcher.ClientInitialize -= new EventHandler(DispatcherClientInitialize);
                    dispatcher.LoggerStart -= new EventHandler(DispatcherLoggerStart);
                    dispatcher.LoggerStop -= new EventHandler(DispatcherLoggerStop);
                }
            }
            else
            {
                string msg = string.Format("No dispatcher for request type '{0}'", Request.Type);
                LoggingService.Error(msg);
                MessageService.ShowError(msg);
            }
        }

        /// <summary>
        /// Stop dispatching
        /// </summary>
        public void Stop()
        {
            _server.StopDispatching();
        }

        /// <summary>
        /// Event for stopping the logger dispatcher
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherLoggerStop(object sender, EventArgs e)
        {
            _server.StopLogger();
        }
        
        /// <summary>
        /// Event for starting the logger dispatcher
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherLoggerStart(object sender, EventArgs e)
        {
            _server.StartLogger();
        }

        /// <summary>
        /// Event for initializing the parser dispatcher
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherParserInitialize(object sender, EventArgs e)
        {
            _server.InitializeParsers();
        }

        /// <summary>
        /// Event for initializing the client dispatcher
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherClientInitialize(object sender, EventArgs e)
        {
            _server.InitializeClient();
        }

        /// <summary>
        /// Event for connecting adding dispatcher
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherConnectionAdding(object sender, PsxWrapperEventArgs e)
        {
            _server.AddPsxConnection(e.HostName, e.ServiceName, e.ConnectionName, e.Timeout);
        }

        /// <summary>
        /// Event for log hook initialize dispatcher
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherLogHookInitialize(object sender, EventArgs e)
        {
            _server.InitializeLogHook();
        }

        /// <summary>
        /// Event for dispatched dispatcher
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">response event arguments</param>
        private void DispatcherDispatched(object sender, ResponseEventArgs e)
        {
            _server.SendResponse(e.Response);
        }

        /// <summary>
        /// Event for dispatching dispatcher
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherDispatching(object sender, NcrEventArgs e)
        {
            _server.PerformServing(e.Message);
        }
    }
}
