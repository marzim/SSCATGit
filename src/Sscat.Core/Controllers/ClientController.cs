// <copyright file="ClientController.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Controllers
{
    using System;
    using System.IO;
    using Ncr.Core;
    using Ncr.Core.Controllers;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Core.Config;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Net;
    using Sscat.Core.Services;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ClientController class
    /// </summary>
    public class ClientController : AbstractController
    {
        /// <summary>
        /// SSCAT client
        /// </summary>
        private SscatClient _client;

        /// <summary>
        /// Interface for the client view
        /// </summary>
        private IClientView _clientView;

        /// <summary>
        /// Client service
        /// </summary>
        private ClientService _service;

        /// <summary>
        /// Initializes a new instance of the ClientController class
        /// </summary>
        /// <param name="client">sscat client</param>
        /// <param name="service">client service</param>
        /// <param name="clientView">client view</param>
        public ClientController(SscatClient client, ClientService service, IClientView clientView)
        {
            _client = client;
            _service = service;

            _clientView = clientView;

            clientView.Client = client;

            client.Connected += new EventHandler<NetworkEventArgs>(ClientConnectionConnected);
            client.Disconnected += new EventHandler<NetworkEventArgs>(ClientConnectionDisconnected);
            client.ConnectionTimeOut += new EventHandler<NetworkEventArgs>(ClientConnectionTimeOut);
            client.ConnectionRejecting += new EventHandler(ClientConnectionRejecting);

            client.DataSent += new EventHandler<NetworkEventArgs>(ClientDataSent);

            client.ResponseDispatching += new EventHandler<NcrEventArgs>(ClientResponseDispatching);
            client.ScriptsDispatched += new EventHandler(ClientStopping);
            client.ScriptEventResultDispatched += new EventHandler<ScriptEventEventArgs>(ClientScriptEventResultDispatched);
            client.ScriptResultDispatched += new EventHandler<ScriptEventArgs>(ClientScriptResultDispatched);
            client.ScriptWarningDispatched += new EventHandler<WarningEventArgs>(ClientScriptWarningDispatched);
            client.ErrorDispatched += new EventHandler(ClientStopping);
            client.Stopping += new EventHandler(ClientStopping);
            client.Stopped += new EventHandler(ClientForcedStopping);

            client.ScriptFileNameCheck += new EventHandler<GeneratorConfigurationEventArgs>(ClientScriptFileNameCheck);

            client.CacheInitiate += new EventHandler<ScriptEventArgs>(ClientCacheInitiate);
            client.Playing += new EventHandler(ClientPlaying);
            client.PlayerConfigurationPrepare += new EventHandler<PlayerConfigurationEventArgs>(ClientPlayerConfigurationPrepare);
            client.LoggerStart += new EventHandler(ClientLoggerStart);
            client.LoggerStop += new EventHandler(ClientLoggerStop);
            client.ViewClear += new EventHandler(ClearView);

            client.StopDispatched += new EventHandler(ClientStopDispatched);

            client.ResponseDispatched += new EventHandler<NcrEventArgs>(ClientResponseDispatched);
            client.ConfigurationChangedDispatched += new EventHandler(ClientViewConfigurationChange);

            clientView.Generate += new EventHandler<GeneratorConfigurationEventArgs>(ClientViewGenerating);
            clientView.Play += new EventHandler<SscatLaneEventArgs>(ClientViewPlay);
            clientView.Stop += new EventHandler(ClientViewStop);
            clientView.ConfigurationSave += new EventHandler<ClientConfigurationEventArgs>(ClientViewConfigurationSave);
            clientView.ConfigurationRestore += new EventHandler(ClientViewConfigurationRestore);
            clientView.ViewClose += new EventHandler(ClientViewViewClose);
        }

        /// <summary>
        /// Finalizes an instance of the ClientController class
        /// </summary>
        ~ClientController()
        {
            _client.Connected -= new EventHandler<NetworkEventArgs>(ClientConnectionConnected);
            _client.Disconnected -= new EventHandler<NetworkEventArgs>(ClientConnectionDisconnected);
            _client.ConnectionTimeOut -= new EventHandler<NetworkEventArgs>(ClientConnectionTimeOut);
            _client.ConnectionRejecting -= new EventHandler(ClientConnectionRejecting);

            _client.DataSent -= new EventHandler<NetworkEventArgs>(ClientDataSent);

            _client.ResponseDispatching -= new EventHandler<NcrEventArgs>(ClientResponseDispatching);
            _client.ScriptsDispatched -= new EventHandler(ClientStopping);
            _client.ScriptEventResultDispatched -= new EventHandler<ScriptEventEventArgs>(ClientScriptEventResultDispatched);
            _client.ScriptResultDispatched -= new EventHandler<ScriptEventArgs>(ClientScriptResultDispatched);
            _client.ScriptWarningDispatched -= new EventHandler<WarningEventArgs>(ClientScriptWarningDispatched);
            _client.ErrorDispatched -= new EventHandler(ClientStopping);
            _client.Stopping -= new EventHandler(ClientStopping);
            _client.Stopped -= new EventHandler(ClientForcedStopping);

            _client.ScriptFileNameCheck -= new EventHandler<GeneratorConfigurationEventArgs>(ClientScriptFileNameCheck);

            _client.CacheInitiate -= new EventHandler<ScriptEventArgs>(ClientCacheInitiate);
            _client.Playing -= new EventHandler(ClientPlaying);
            _client.PlayerConfigurationPrepare -= new EventHandler<PlayerConfigurationEventArgs>(ClientPlayerConfigurationPrepare);
            _client.LoggerStart -= new EventHandler(ClientLoggerStart);
            _client.LoggerStop -= new EventHandler(ClientLoggerStop);
            _client.ViewClear -= new EventHandler(ClearView);

            _client.StopDispatched -= new EventHandler(ClientStopDispatched);

            _client.ResponseDispatched -= new EventHandler<NcrEventArgs>(ClientResponseDispatched);
            _client.ConfigurationChangedDispatched -= new EventHandler(ClientViewConfigurationChange);

            _clientView.Generate -= new EventHandler<GeneratorConfigurationEventArgs>(ClientViewGenerating);
            _clientView.Play -= new EventHandler<SscatLaneEventArgs>(ClientViewPlay);
            _clientView.Stop -= new EventHandler(ClientViewStop);
            _clientView.ConfigurationSave -= new EventHandler<ClientConfigurationEventArgs>(ClientViewConfigurationSave);
            _clientView.ConfigurationRestore -= new EventHandler(ClientViewConfigurationRestore);
            _clientView.ViewClose -= new EventHandler(ClientViewViewClose);
        }

        /// <summary>
        /// Event handler for the client connection
        /// </summary>
        public event EventHandler<NetworkEventArgs> ClientConnected;

        /// <summary>
        /// Event handler for the client disconnection
        /// </summary>
        public event EventHandler<NetworkEventArgs> ClientDisconnected;

        /// <summary>
        /// Event handler for the script file name check
        /// </summary>
        public event EventHandler<GeneratorConfigurationEventArgs> ScriptFileNameCheck;

        /// <summary>
        /// Event handler for the client timeout
        /// </summary>
        public event EventHandler<NetworkEventArgs> ClientTimeout;

        /// <summary>
        /// Event handler for the client rejecting
        /// </summary>
        public event EventHandler ClientRejecting;

        /// <summary>
        /// Client view
        /// </summary>
        /// <returns>Returns the client view</returns>
        public IView Index()
        {
            return _clientView;
        }

        /// <summary>
        /// Client rejecting event
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnClientRejecting(EventArgs e)
        {
            if (ClientRejecting != null)
            {
                ClientRejecting(this, e);
            }
        }

        /// <summary>
        /// Script file name check event
        /// </summary>
        /// <param name="e">generator configuration event arguments</param>
        protected virtual void OnScriptFileNameCheck(GeneratorConfigurationEventArgs e)
        {
            if (ScriptFileNameCheck != null)
            {
                ScriptFileNameCheck(this, e);
            }
        }

        /// <summary>
        /// Client timeout event
        /// </summary>
        /// <param name="e">network event arguments</param>
        protected virtual void OnClientTimeout(NetworkEventArgs e)
        {
            if (ClientTimeout != null)
            {
                ClientTimeout(this, e);
            }
        }

        /// <summary>
        /// Client disconnected event
        /// </summary>
        /// <param name="e">network event arguments</param>
        protected virtual void OnClientDisconnected(NetworkEventArgs e)
        {
            if (ClientDisconnected != null)
            {
                ClientDisconnected(this, e);
            }
        }

        /// <summary>
        /// Client connected event
        /// </summary>
        /// <param name="e">network event arguments</param>
        protected virtual void OnClientConnected(NetworkEventArgs e)
        {
            if (ClientConnected != null)
            {
                ClientConnected(this, e);
            }
        }

        /// <summary>
        /// Client stop dispatched event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientStopDispatched(object sender, EventArgs e)
        {
            _clientView.PerformStopping();
            _client.StopWorker();
        }

        /// <summary>
        /// Client response dispatched event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientResponseDispatched(object sender, NcrEventArgs e)
        {
            _clientView.PerformDisable();
            _client.ReceiveResponse(new Response(SscatResponse.MESSAGE, new MessageContent(e.Message)));
        }

        /// <summary>
        /// Client logger stop event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientLoggerStop(object sender, EventArgs e)
        {
            _service.StopLogger();
        }

        /// <summary>
        /// Client logger start event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientLoggerStart(object sender, EventArgs e)
        {
            _service.StartLogger();
        }

        /// <summary>
        /// Client view close event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientViewViewClose(object sender, EventArgs e)
        {
            _client.Disconnect();
        }

        /// <summary>
        /// Client view configuration restore event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientViewConfigurationRestore(object sender, EventArgs e)
        {
            _client.Configuration = _service.ReadClientConfiguration(Path.Combine(ApplicationUtility.ConfigDirectory, _client.DefaultConfigurationName));
        }

        /// <summary>
        /// Client view configuration save event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientViewConfigurationSave(object sender, ClientConfigurationEventArgs e)
        {
            e.Configuration.FileName = Path.Combine(ApplicationUtility.ConfigDirectory, _client.ConfigurationName);
            e.Configuration.Validate();
            if (!e.Configuration.HasErrors)
            {
                _service.SaveClientConfiguration(e.Configuration);
                MessageService.ShowInfo("Configuration saved.");
            }
            else
            {
                MessageService.ShowWarning(e.Configuration.Errors.ToString());
            }
        }

        /// <summary>
        /// Client view configuration change event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientViewConfigurationChange(object sender, EventArgs e)
        {
            try
            {
                _client.Configuration = _service.ReadClientConfiguration(Path.Combine(ApplicationUtility.ConfigDirectory, _client.ConfigurationName));
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                MessageService.ShowInfo(ex.ToString());
            }
        }

        /// <summary>
        /// Client view stop event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientViewStop(object sender, EventArgs e)
        {
            _clientView.PerformDisable();
            _client.Stop();
        }

        /// <summary>
        /// Client view play event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">sscat lane event arguments</param>
        private void ClientViewPlay(object sender, SscatLaneEventArgs e)
        {
            if (e.ScriptFiles.Count > 0)
            {
                _client.Play(e.ScriptFiles);
            }
            else
            {
                _clientView.PerformStopping();
                MessageService.ShowWarning("There should be at least 1 script to be played.");
            }
        }

        /// <summary>
        /// Client view generating event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">generator configuration event arguments</param>
        private void ClientViewGenerating(object sender, GeneratorConfigurationEventArgs e)
        {
            if (e != null)
            {
                _client.Generate(e.Config);
            }
        }

        /// <summary>
        /// Client player configuration prepare event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">player configuration event arguments</param>
        private void ClientPlayerConfigurationPrepare(object sender, PlayerConfigurationEventArgs e)
        {
            _clientView.SelectScript(e.Script);
            _service.PreparePlayerConfiguration(e.Config, e.Script);
        }

        /// <summary>
        /// Client connection event 
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void ClientConnectionConnected(object sender, NetworkEventArgs e)
        {
            ThreadHelper.Sleep(2500);
            if (!_client.Rejected)
            {
                _clientView.SetTitle(_client.ServerName);
                _client.Configuration = _service.ReadClientConfiguration(Path.Combine(ApplicationUtility.ConfigDirectory, _client.ConfigurationName));
                OnClientConnected(e);
            }
            else
            {
                _client.Disconnect();
            }
        }

        /// <summary>
        /// Client connection rejecting event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientConnectionRejecting(object sender, EventArgs e)
        {
            MessageService.ShowWarning("Your connection is rejected. Please check if there is other client connected to server and try again.");
            OnClientRejecting(e);
        }

        /// <summary>
        /// Client script file name check event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">generator configuration event arguments</param>
        private void ClientScriptFileNameCheck(object sender, GeneratorConfigurationEventArgs e)
        {
            OnScriptFileNameCheck(e);
        }

        /// <summary>
        /// Client playing event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientPlaying(object sender, EventArgs e)
        {
            _clientView.ClearResults();
        }

        /// <summary>
        /// Client forced stopping event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientForcedStopping(object sender, EventArgs e)
        {
            _clientView.PerformDisable();
        }

        /// <summary>
        /// Client stopping event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientStopping(object sender, EventArgs e)
        {
            _clientView.PerformStopping();
        }

        /// <summary>
        /// Client data sent event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void ClientDataSent(object sender, NetworkEventArgs e)
        {
            if ((e.Request != null) && e.Request.Type.Equals("GENERATE_SCRIPTS"))
            {
                _clientView.PerformGenerating();
            }
            else
            {
                _clientView.PerformPlaying();
            }
        }

        /// <summary>
        /// Client cache initiate event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void ClientCacheInitiate(object sender, ScriptEventArgs e)
        {
            _clientView.InitiateCache(e);
        }

        /// <summary>
        /// Clear view event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClearView(object sender, EventArgs e)
        {
            _clientView.ClearView();
        }

        /// <summary>
        /// Client script result dispatched event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void ClientScriptResultDispatched(object sender, ScriptEventArgs e)
        {
            _clientView.UpdateResult(e.Script);
            _clientView.PerformStopping();
        }

        /// <summary>
        /// Client script event result dispatched event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void ClientScriptEventResultDispatched(object sender, ScriptEventEventArgs e)
        {
            _clientView.UpdateResult(e.Event);
        }

        /// <summary>
        /// Client script warning dispatched event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">warning event arguments</param>
        private void ClientScriptWarningDispatched(object sender, WarningEventArgs e)
        {
            _clientView.UpdateWarning(e.Event);
        }

        /// <summary>
        /// Client response dispatching event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientResponseDispatching(object sender, NcrEventArgs e)
        {
            _clientView.WriteLine(string.Format("{0} {1}", DateTimeUtility.Now(), e.Message));
            LoggingService.Info(e.Message);
        }

        /// <summary>
        /// Client connection timeout event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void ClientConnectionTimeOut(object sender, NetworkEventArgs e)
        {
            _clientView.UpdateViewOnConnectionTimeout(e.Message);
            MessageService.ShowWarning(e.Message);
            LoggingService.Warning(e.Message);
            _client.PerformStopping();
            OnClientTimeout(e);
        }

        /// <summary>
        /// Client connection disconnected event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void ClientConnectionDisconnected(object sender, NetworkEventArgs e)
        {
            if (!_client.Rejected)
            {
                OnClientDisconnected(e);
            }
        }
    }
}
