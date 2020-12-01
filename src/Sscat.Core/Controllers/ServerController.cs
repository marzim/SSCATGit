// <copyright file="ServerController.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Controllers
{
    using System;
    using Ncr.Core;
    using Ncr.Core.Controllers;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Core.Net;
    using Sscat.Core.Services;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ServerController class
    /// </summary>
    public class ServerController : AbstractController
    {
        /// <summary>
        /// Interface for the server view
        /// </summary>
        private IServerView _serverView;

        /// <summary>
        /// SSCAT server
        /// </summary>
        private SscatServer _server;

        /// <summary>
        /// Lane service
        /// </summary>
        private LaneService _service;

        /// <summary>
        /// Initializes a new instance of the ServerController class
        /// </summary>
        /// <param name="server">sscat server</param>
        /// <param name="service">lane service</param>
        /// <param name="serverView">server view</param>
        public ServerController(SscatServer server, LaneService service, IServerView serverView)
        {
            _server = server;
            _service = service;
            _serverView = serverView;
            serverView.Server = server;

            server.ParserInitialize += new EventHandler(ServerParserInitialize);
            server.LogHookInitialize += new EventHandler(ServerLogHookInitialize);
            server.Serving += new EventHandler<NcrEventArgs>(ServerServing);
            server.Stopping += new EventHandler(ServerStopping);
            server.LoggerStart += new EventHandler(ServerLoggerStart);
            server.LoggerStop += new EventHandler(ServerLoggerStop);
            server.ClientInitialize += new EventHandler(ServerClientInitialize);
        }

        /// <summary>
        /// Finalizes an instance of the ServerController class
        /// </summary>
        ~ServerController()
        {
            _server.ParserInitialize += new EventHandler(ServerParserInitialize);
            _server.LogHookInitialize -= new EventHandler(ServerLogHookInitialize);
            _server.Serving -= new EventHandler<NcrEventArgs>(ServerServing);
            _server.Stopping -= new EventHandler(ServerStopping);
            _server.LoggerStart -= new EventHandler(ServerLoggerStart);
            _server.LoggerStop -= new EventHandler(ServerLoggerStop);
            _server.ClientInitialize -= new EventHandler(ServerClientInitialize);
        }

        /// <summary>
        /// Index view
        /// </summary>
        /// <returns>Returns server view</returns>
        public IView Index()
        {
            return _serverView;
        }

        /// <summary>
        /// Initialize the client for the server
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServerClientInitialize(object sender, EventArgs e)
        {
            // TODO: This should initialize the client for server.
        }

        /// <summary>
        /// Server logger stop event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServerLoggerStop(object sender, EventArgs e)
        {
            _service.StopLogger();
            _service.StopScotLogger();
        }

        /// <summary>
        /// Server logger start event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServerLoggerStart(object sender, EventArgs e)
        {
            _service.StartLogger();
            _service.StartScotLogger();
        }

        /// <summary>
        /// Server parser initialize event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServerParserInitialize(object sender, EventArgs e)
        {
            _server.Lane.Parsers = _service.CreateParsers();
        }

        /// <summary>
        /// Server stopping event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServerStopping(object sender, EventArgs e)
        {
            _server.Lane.Stop();
        }

        /// <summary>
        /// Server serving event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServerServing(object sender, NcrEventArgs e)
        {
            LoggingService.Info(e.Message);
        }

        /// <summary>
        /// Server log hook initialize event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServerLogHookInitialize(object sender, EventArgs e)
        {
            _server.Lane.Hooks = _service.CreateHooks();
        }
    }
}
