// <copyright file="PlayScriptRequestDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using System.IO;
    using System.Threading;
    using Ncr.Core;
    using Ncr.Core.Emulators;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Models.Report;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Parsers;
    using Sscat.Core.Services;

    /// <summary>
    /// Initializes a new instance of the PlayScriptRequestDispatcher class
    /// </summary>
    public class PlayScriptRequestDispatcher : SscatRequestDispatcher
    {
        /// <summary>
        /// SSCAT client
        /// </summary>
        private SscatClient _client;

        /// <summary>
        /// Whether or not dispatcher is connected
        /// </summary>
        private bool _connected;

        /// <summary>
        /// Whether or not dispatcher has timed out
        /// </summary>
        private volatile bool _hasTimedOut;

        /// <summary>
        /// Whether or not dispatch has a response
        /// </summary>
        private volatile bool _hasResponse;

        /// <summary>
        /// Whether or not Scot configuration differs
        /// </summary>
        private bool _differs;

        /// <summary>
        /// Lane service
        /// </summary>
        private LaneService _laneService;

        /// <summary>
        /// Initializes a new instance of the PlayScriptRequestDispatcher class
        /// </summary>
        /// <param name="service">lane service</param>
        public PlayScriptRequestDispatcher(LaneService service)
            : base(SscatRequest.PLAY_SCRIPT)
        {
            _laneService = service;
        }

        /// <summary>
        /// Gets or sets the SSCAT client
        /// </summary>
        public SscatClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        /// <summary>
        /// Dispatch request
        /// </summary>
        /// <param name="request">request to dispatch</param>
        public override void Dispatch(Request request)
        {
            base.Dispatch(request);
            Report report = null;
            SscatLane lane = Server.Lane;
            try
            {
                PlayerConfiguration config = request.Content as PlayerConfiguration;
                lane.Configuration.PlayerConfiguration = config;
                lane.ValidateForPlay();
                if (!lane.HasErrors)
                {
                    lane.LogHookInitialize += new EventHandler(LaneLogHookInitialize);
                    lane.ConfigurationLoad += new EventHandler<ConfigFilesEventArgs>(ServerLaneConfigurationLoad);
                    lane.ScriptEventChanged += new EventHandler<ScriptEventEventArgs>(PlayerScriptEventChanged);
                    lane.Playing += new EventHandler<ProgressEventArgs>(PlayerScriptPlaying);
                    lane.ScriptChanged += new EventHandler<ScriptEventArgs>(PlayerScriptChanged);
                    lane.ScriptWarningChanged += new EventHandler<WarningEventArgs>(PlayerScriptWarningEventChanged);
                    lane.Emulating += new EventHandler<EmulatorEventArgs>(LaneEmulating);
                    lane.StopDispatch += new EventHandler(LaneStopDispatch);
                    lane.LoggerStart += new EventHandler(Lane_LoggerStart);
                    lane.LoggerStop += new EventHandler(Lane_LoggerStop);

                    config.SetProperScripts();
                    report = lane.Play(config.ScriptConfigs, config.LogHookTimeout, config.WarningTimeout, config.EnableLogHook, config.ConfigFiles.RepetitionIndex);
                    Request.Clear();
                }
                else
                {
                    LoggingService.Error(lane.Errors.ToString());
                    OnDispatching(lane.Errors.ToString());
                }
            }
            catch (LaneException ex)
            {
                LoggingService.Error(ex.Message);
                OnDispatching(ex.Message);
                OnDispatched(request.CreateResponse(SscatResponse.ERROR, ex.Message));
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                OnDispatching(ex.Message);
                OnDispatched(request.CreateResponse(SscatResponse.ERROR, ex.Message));
            }
            finally
            {
                try
                {
                    if (report != null)
                    {
                        OnDispatched(request.CreateResponse(SscatResponse.PLAYBACK, report));
                    }
                }
                catch (Exception ex)
                {
                    LoggingService.Error(ex.ToString());
                    OnDispatching(ex.Message);
                }
                finally
                {
                    lane.LogHookInitialize -= new EventHandler(LaneLogHookInitialize);
                    lane.ConfigurationLoad -= new EventHandler<ConfigFilesEventArgs>(ServerLaneConfigurationLoad);
                    lane.ScriptEventChanged -= new EventHandler<ScriptEventEventArgs>(PlayerScriptEventChanged);
                    lane.Playing -= new EventHandler<ProgressEventArgs>(PlayerScriptPlaying);
                    lane.ScriptChanged -= new EventHandler<ScriptEventArgs>(PlayerScriptChanged);
                    lane.ScriptWarningChanged -= new EventHandler<WarningEventArgs>(PlayerScriptWarningEventChanged);
                    lane.Emulating -= new EventHandler<EmulatorEventArgs>(LaneEmulating);
                    lane.StopDispatch -= new EventHandler(LaneStopDispatch);
                    lane.LoggerStart -= new EventHandler(Lane_LoggerStart);
                    lane.LoggerStop -= new EventHandler(Lane_LoggerStop);
                }
            }
        }

        /// <summary>
        /// Event for lane logger stop
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void Lane_LoggerStop(object sender, EventArgs e)
        {
            OnLoggerStop(e);
        }

        /// <summary>
        /// Event for lane logger start
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void Lane_LoggerStart(object sender, EventArgs e)
        {
            OnLoggerStart(e);
        }

        /// <summary>
        /// Event for lane stop dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void LaneStopDispatch(object sender, EventArgs e)
        {
            OnDispatching("Stopped");
            OnDispatched(Request.CreateResponse(SscatResponse.STOPPED, string.Empty));
        }

        /// <summary>
        /// Event for lane log hook initialized
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void LaneLogHookInitialize(object sender, EventArgs e)
        {
            OnLogHookInitialize(e);
        }

        /// <summary>
        /// Event for lane emulating
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">emulator event arguments</param>
        private void LaneEmulating(object sender, EmulatorEventArgs e)
        {
            OnDispatching(e.Message);
            OnDispatched(Request.CreateResponse(SscatResponse.MESSAGE, e.Message));
        }

        /// <summary>
        /// Event for server lane configuration loaded
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration files event arguments</param>
        private void ServerLaneConfigurationLoad(object sender, ConfigFilesEventArgs e)
        {
            try
            {
                _laneService.Servicing += new EventHandler<NcrEventArgs>(ServiceServicing);
                _laneService.CheckConfigOnServer += new EventHandler<ConfigFileEventArgs>(PlayerLaneCheckConfigOnServer);
                _laneService.LoadConfigOnServer += new EventHandler<ConfigFileEventArgs>(PlayerLaneLoadConfigOnServer);
                _laneService.LoadConfiguration(e.Files, e.ForceStop);
            }
            catch
            {
                throw;
            }
            finally
            {
                _laneService.Servicing -= new EventHandler<NcrEventArgs>(ServiceServicing);
                _laneService.CheckConfigOnServer -= new EventHandler<ConfigFileEventArgs>(PlayerLaneCheckConfigOnServer);
                _laneService.LoadConfigOnServer -= new EventHandler<ConfigFileEventArgs>(PlayerLaneLoadConfigOnServer);
            }
        }

        /// <summary>
        /// Event for service serving
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServiceServicing(object sender, NcrEventArgs e)
        {
            OnDispatching(e.Message);
            OnDispatched(Request.CreateResponse(SscatResponse.MESSAGE, e.Message));
        }

        /// <summary>
        /// Event for configuration files repository accessing
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ConfigFilesRepositoryAccessing(object sender, NcrEventArgs e)
        {
            OnDispatching(e.Message);
        }

        /// <summary>
        /// Event for player lane check configuration on server
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void PlayerLaneCheckConfigOnServer(object sender, ConfigFileEventArgs e)
        {
            try
            {
                OnClientInitialize(null);
                Client.ConnectionTimeOut += new EventHandler<NetworkEventArgs>(ClientConnectionTimeOut);
                Client.Connected += new EventHandler<NetworkEventArgs>(ClientConnected);
                Client.ConfigCheckedDispatched += new EventHandler<ConfigFileEventArgs>(ClientConfigCheckedDispatched);
                Client.Server = e.File.Host;
                _connected = false;
                Client.Connect();
                int now = Environment.TickCount;

                while (((Environment.TickCount - now) < 5000) && !_hasTimedOut && !_connected)
                {
                    Thread.Sleep(200);
                }

                if (_connected)
                {
                    string msg = string.Format("Checking {0} request to {1}", Path.Combine(e.File.Source, e.File.Name), Client.ServerName);
                    OnDispatching(msg);
                    OnDispatched(Request.CreateResponse(SscatResponse.MESSAGE, msg));
                    Client.SendRequest(new Request(SscatRequest.CHECK_CONFIG, e.File));
                    while (((Environment.TickCount - now) < (60000 * 1)) && !_hasResponse)
                    {
                        Thread.Sleep(200);
                    }
                }

                if (!_hasResponse)
                {
                    string msg = string.Format("Checking file '{0}' at '{1}' timed out.", Path.Combine(e.File.Source, e.File.Name), e.File.Host);
                    OnDispatching(msg);
                    OnDispatched(Request.CreateResponse(SscatResponse.ERROR, msg));
                }

                e.File.DifferentFromScotConfig = _differs;
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
            finally
            {
                Client.Connected -= new EventHandler<NetworkEventArgs>(ClientConnected);
                Client.ConnectionTimeOut -= new EventHandler<NetworkEventArgs>(ClientConnectionTimeOut);
                Client.ConfigCheckedDispatched -= new EventHandler<ConfigFileEventArgs>(ClientConfigCheckedDispatched);
                Client.Disconnect();
                _hasResponse = false;
                _differs = true;
            }
        }

        /// <summary>
        /// Event for Player Lane Load Configuration on Server
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void PlayerLaneLoadConfigOnServer(object sender, ConfigFileEventArgs e)
        {
            try
            {
                OnClientInitialize(null);
                Client.ConnectionTimeOut += new EventHandler<NetworkEventArgs>(ClientConnectionTimeOut);
                Client.Connected += new EventHandler<NetworkEventArgs>(ClientConnected);
                Client.ConfigLoadedDispatched += new EventHandler(ClientConfigLoadedDispatched);
                Client.Server = e.File.Host;
                _connected = false;
                Client.Connect();
                int now = Environment.TickCount;

                while (((Environment.TickCount - now) < 5000) && !_hasTimedOut && !_connected)
                {
                    Thread.Sleep(200);
                }

                if (_connected)
                {
                    string msg = string.Format("Loading {0} request to {1}", Path.Combine(e.File.Destination, e.File.Name), Client.ServerName);
                    OnDispatching(msg);
                    OnDispatched(Request.CreateResponse(SscatResponse.MESSAGE, msg));
                    Client.SendRequest(new Request(SscatRequest.LOAD_CONFIG, e.File));
                    while (((Environment.TickCount - now) < (60000 * 3)) && !_hasResponse)
                    {
                        Thread.Sleep(200);
                    }
                }

                if (!_hasResponse)
                {
                    string msg = string.Format("Loading file '{0}' at '{1}' timed out.", Path.Combine(e.File.Destination, e.File.Name), e.File.Host);
                    OnDispatching(msg);
                    OnDispatched(Request.CreateResponse(SscatResponse.ERROR, msg));
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
            finally
            {
                Client.Connected -= new EventHandler<NetworkEventArgs>(ClientConnected);
                Client.ConnectionTimeOut -= new EventHandler<NetworkEventArgs>(ClientConnectionTimeOut);
                Client.ConfigLoadedDispatched -= new EventHandler(ClientConfigLoadedDispatched);
                Client.Disconnect();
                _hasResponse = false;
            }
        }

        /// <summary>
        /// Event for Client Configuration Checked Dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration file event arguments</param>
        private void ClientConfigCheckedDispatched(object sender, ConfigFileEventArgs e)
        {
            _hasResponse = true;
            _differs = e.File.DifferentFromScotConfig;
        }

        /// <summary>
        /// Event for client Configuration loaded dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ClientConfigLoadedDispatched(object sender, EventArgs e)
        {
            _hasResponse = true;
        }

        /// <summary>
        /// Event for client connected
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void ClientConnected(object sender, NetworkEventArgs e)
        {
            _connected = true;
        }

        /// <summary>
        /// Event for client connection time out
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void ClientConnectionTimeOut(object sender, NetworkEventArgs e)
        {
            _hasTimedOut = true;
        }

        /// <summary>
        /// Event for player script changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void PlayerScriptChanged(object sender, ScriptEventArgs e)
        {
            OnDispatching(e.Script.Result.ToRepresentation());
            OnDispatched(Request.CreateResponse(SscatResponse.SCRIPT_RESULT, e.Script));
        }

        /// <summary>
        /// Event for player script event changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void PlayerScriptEventChanged(object sender, ScriptEventEventArgs e)
        {
            OnDispatching(e.Event.Result.ToRepresentation());
            OnDispatched(Request.CreateResponse(SscatResponse.EVENT_RESULT, e.Event));
        }

        /// <summary>
        /// Event for player script warning event changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">warning event arguments</param>
        private void PlayerScriptWarningEventChanged(object sender, WarningEventArgs e)
        {
            OnDispatched(Request.CreateResponse(SscatResponse.WARNING_EVENT_RESULT, e.Event));
        }

        /// <summary>
        /// Event for player script playing
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">progress event arguments</param>
        private void PlayerScriptPlaying(object sender, ProgressEventArgs e)
        {
            OnDispatching(e.Message);
            OnDispatched(Request.CreateResponse(SscatResponse.MESSAGE, e.Message));
        }
    }
}
