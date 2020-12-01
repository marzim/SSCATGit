// <copyright file="GenerateScriptsRequestDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Threading;
    using Ncr.Core;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Parsers;
    using Sscat.Core.Repositories;

    /// <summary>
    /// Initializes a new instance of the GenerateScriptsRequestDispatcher class
    /// </summary>
    public class GenerateScriptsRequestDispatcher : SscatRequestDispatcher
    {
        /// <summary>
        /// Generator configuration
        /// </summary>
        private GeneratorConfiguration _generatorConfiguration;

        /// <summary>
        /// SSCAT client
        /// </summary>
        private SscatClient _client;

        /// <summary>
        /// Whether or not dispatcher has a response
        /// </summary>
        private bool _hasResponse;

        /// <summary>
        /// Response configuration file
        /// </summary>
        private ConfigFile _responseConfigFile;

        /// <summary>
        /// Configuration files repository
        /// </summary>
        private IConfigFilesRepository _configFilesRepository;

        /// <summary>
        /// Whether or not dispatcher is connected
        /// </summary>
        private bool _isConnected;

        /// <summary>
        /// Whether or not dispatcher is timed out
        /// </summary>
        private bool _hasTimedOut;

        /// <summary>
        /// Initializes a new instance of the GenerateScriptsRequestDispatcher class
        /// </summary>
        /// <param name="client">sscat client</param>
        /// <param name="configFilesRepository">configuration files repository</param>
        public GenerateScriptsRequestDispatcher(SscatClient client, IConfigFilesRepository configFilesRepository)
            : base(SscatRequest.GENERATE_SCRIPTS)
        {
            _client = client;
            _configFilesRepository = configFilesRepository;
        }

        /// <summary>
        /// Dispatch request
        /// </summary>
        /// <param name="request">request to dispatch</param>
        public override void Dispatch(Request request)
        {
            SscatLane lane = Server.Lane;
            try
            {
                base.Dispatch(request);
                _configFilesRepository.Accessing += new EventHandler<NcrEventArgs>(ConfigFileRepositoryAccessing);
                lane.Parse += new EventHandler<ProgressEventArgs>(GeneratorParse);
                lane.Stopping += new EventHandler(ServerLaneStopping);
                lane.ConfigurationGet += new EventHandler<ConfigFilesEventArgs>(ServerLaneConfigurationGet);
                lane.StopDispatch += new EventHandler(LaneStopDispatch);

                _generatorConfiguration = request.Content as GeneratorConfiguration;
                lane.Configuration.Files = _generatorConfiguration.Files;
                lane.Configuration.GeneratorConfiguration = _generatorConfiguration;
                OnParserInitialize(null);
                lane.ValidateForGenerate();
                if (!lane.HasErrors)
                {
                    OnLoggerStart(null);
                    IScript[] scripts = lane.Generate(_generatorConfiguration.ScriptName, _generatorConfiguration.ScriptDescription, Server.Lane.ProductVersion, ApplicationUtility.ProductVersion, _generatorConfiguration.SegmentedScripts, _generatorConfiguration.ScriptOutputDirectory, _generatorConfiguration.GenerateLast, _generatorConfiguration.LastScriptsNumber, _generatorConfiguration.DefaultMSCard, _generatorConfiguration.UIValidation);
                    if (!lane.HasStopped)
                    {
                        _generatorConfiguration.Scripts.AddScripts(scripts);
                        OnDispatching(string.Format("Sending {0} script(s) with configuration.", _generatorConfiguration.Scripts.Scripts.Length));
                        OnDispatched(request.CreateResponse(SscatResponse.SCRIPTS, _generatorConfiguration));
                    }
                }
                else
                {
                    OnDispatched(request.CreateResponse(SscatResponse.ERROR, lane.Errors.ToString()));
                    OnDispatching(lane.Errors.ToString());
                }
            }
            catch (FileNotFoundException ex)
            {
                LoggingService.Error(ex.Message.ToString());
                OnDispatched(request.CreateResponse(SscatResponse.ERROR, "Unable to generate scripts, please make sure the required ScotApp logs for SSCAT script generation are found in the test system."));
                OnDispatching(string.Format("Unable to generate scripts, please make sure the required ScotApp logs for SSCAT script generation are found in the test system."));
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                OnDispatched(request.CreateResponse(SscatResponse.ERROR, ex.Message));
                OnDispatching(ex.Message);
            }
            finally
            {
                OnLoggerStop(null);
                _configFilesRepository.Accessing -= new EventHandler<NcrEventArgs>(ConfigFileRepositoryAccessing);
                lane.Parse -= new EventHandler<ProgressEventArgs>(GeneratorParse);
                lane.Stopping -= new EventHandler(ServerLaneStopping);
                lane.ConfigurationGet -= new EventHandler<ConfigFilesEventArgs>(ServerLaneConfigurationGet);
                lane.StopDispatch -= new EventHandler(LaneStopDispatch);
            }
        }

        /// <summary>
        /// Event for when the lane logger stops
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void LaneLoggerStop(object sender, EventArgs e)
        {
            OnLoggerStop(e);
        }

        /// <summary>
        /// Event for the lane logger start
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void LaneLoggerStart(object sender, EventArgs e)
        {
            OnLoggerStart(e);
        }

        /// <summary>
        /// Event for the server lane stopping
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServerLaneStopping(object sender, EventArgs e)
        {
            _configFilesRepository.Stop();
        }

        /// <summary>
        /// Event for getting the server lane configuration
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration files event arguments</param>
        private void ServerLaneConfigurationGet(object sender, ConfigFilesEventArgs e)
        {
            try
            {
                _configFilesRepository.CopyConfigOnServer += new EventHandler<ConfigFileEventArgs>(GeneratorCopyFileOnServer);
                _configFilesRepository.Get(e.Files, e.ConfigName);
            }
            catch
            {
                throw;
            }
            finally
            {
                _configFilesRepository.CopyConfigOnServer -= new EventHandler<ConfigFileEventArgs>(GeneratorCopyFileOnServer);
            }
        }

        /// <summary>
        /// Event for when the client connection is timed out
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void ClientConnectionTimeOut(object sender, NetworkEventArgs e)
        {
            OnDispatching(e.Message);
            _hasTimedOut = true;
        }

        /// <summary>
        /// Event for when client is connected
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        private void ClientConnected(object sender, NetworkEventArgs e)
        {
            OnDispatching(string.Format("Connected to {0}", _client.ServerName));
            OnDispatched(Request.CreateResponse(SscatResponse.MESSAGE, e.Message));
            _isConnected = true;
        }

        /// <summary>
        /// Event for when lane stops dispatch
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void LaneStopDispatch(object sender, EventArgs e)
        {
            OnDispatching("Stopping...");
            OnDispatched(Request.CreateResponse(SscatResponse.STOPPED, string.Empty));
        }

        /// <summary>
        /// Event for generator parse
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">progress event arguments</param>
        private void GeneratorParse(object sender, ProgressEventArgs e)
        {
            OnDispatching(e.Message);
            OnDispatched(Request.CreateResponse(SscatResponse.MESSAGE, e.Message));
        }

        /// <summary>
        /// Event for configuration file repository being accessed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ConfigFileRepositoryAccessing(object sender, NcrEventArgs e)
        {
            OnDispatching(e);
            OnDispatched(Request.CreateResponse(SscatResponse.MESSAGE, e.Message));
        }

        /// <summary>
        /// Event for generator copy file on server
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration file event arguments</param>
        private void GeneratorCopyFileOnServer(object sender, ConfigFileEventArgs e)
        {
            try
            {
                _client.Connected += new EventHandler<NetworkEventArgs>(ClientConnected);
                _client.ConnectionTimeOut += new EventHandler<NetworkEventArgs>(ClientConnectionTimeOut);
                _client.ConfigDispatched += new EventHandler<ConfigFileEventArgs>(ClientConfigDispatched);
                _isConnected = false;
                _client.Server = e.File.Host;
                _client.Connect();
                int now = Environment.TickCount;
                while (((Environment.TickCount - now) < 5000) && !_hasTimedOut && !_isConnected)
                {
                    Thread.Sleep(200);
                }

                if (_isConnected)
                {
                    string msg = string.Format("Requesting {0} request to {1}", Path.Combine(e.File.Source, e.File.Name), _client.ServerName);
                    OnDispatching(msg);
                    OnDispatched(Request.CreateResponse(SscatResponse.MESSAGE, msg));
                    _client.SendRequest(new Request(SscatRequest.GET_CONFIG, new ConfigFiles(e.File)));
                    while (((Environment.TickCount - now) < (60000 * 3)) && !_hasResponse)
                    {
                        Thread.Sleep(200);
                    }
                }

                if (_hasResponse)
                {
                    e.File.Exists = _responseConfigFile.Exists;
                    e.File.Content = _responseConfigFile.Content;
                }
                else
                {
                    OnDispatched(Request.CreateResponse(SscatResponse.MESSAGE, string.Format("Getting file '{0}' at '{1}' timed out.", Path.Combine(e.File.Source, e.File.Name), e.File.Host)));
                }

                _hasResponse = false;
            }
            catch (SocketException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _client.Connected -= new EventHandler<NetworkEventArgs>(ClientConnected);
                _client.ConnectionTimeOut -= new EventHandler<NetworkEventArgs>(ClientConnectionTimeOut);
                _client.ConfigDispatched -= new EventHandler<ConfigFileEventArgs>(ClientConfigDispatched);
                _client.Disconnect();
            }
        }

        /// <summary>
        /// Event for client configuration dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration file event arguments</param>
        private void ClientConfigDispatched(object sender, ConfigFileEventArgs e)
        {
            _hasResponse = true;
            _responseConfigFile = e.File;
        }
    }
}
