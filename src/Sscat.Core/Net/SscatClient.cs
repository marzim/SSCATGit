// <copyright file="SscatClient.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Net
{
    using System;
    using System.Collections.Generic;
    using Ncr.Core;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the SscatClient class
    /// </summary>
    public class SscatClient : BaseClient
    {
        /// <summary>
        /// Whether or not client Has stopped
        /// </summary>
        private volatile bool _hasStopped;

        /// <summary>
        /// Client configuration
        /// </summary>
        private ClientConfiguration _clientConfiguration;

        /// <summary>
        /// Whether or not client Scripts dispatched
        /// </summary>
        private volatile bool _scriptsDispatched;

        /// <summary>
        /// Whether or not client Error dispatched
        /// </summary>
        private volatile bool _errorDispatched;

        /// <summary>
        /// Whether or not client Report dispatched
        /// </summary>
        private volatile bool _reportDispatched;

        /// <summary>
        /// Client worker
        /// </summary>
        private SscatClientWorker _clientWorker;

        /// <summary>
        /// Initializes a new instance of the SscatClient class
        /// </summary>
        /// <param name="responseParser">response parser</param>
        /// <param name="engine">client engine</param>
        public SscatClient(IResponseParser responseParser, IClientEngine engine)
            : this(30000, responseParser, engine)
        {
            _clientWorker = new SscatClientWorker(this);
        }

        /// <summary>
        /// Initializes a new instance of the SscatClient class
        /// </summary>
        /// <param name="port">port number</param>
        /// <param name="responseParser">response parser</param>
        /// <param name="engine">client engine</param>
        public SscatClient(int port, IResponseParser responseParser, IClientEngine engine)
            : this(string.Empty, port, responseParser, engine)
        {
            _clientWorker = new SscatClientWorker(this);
        }

        /// <summary>
        /// Initializes a new instance of the SscatClient class
        /// </summary>
        /// <param name="server">sscat server</param>
        /// <param name="port">port number</param>
        /// <param name="responseParser">response parser</param>
        /// <param name="engine">client engine</param>
        public SscatClient(string server, int port, IResponseParser responseParser, IClientEngine engine)
            : base(server, port, responseParser, engine)
        {
            _clientWorker = new SscatClientWorker(this);
        }

        /// <summary>
        /// Event handler for the script event result dispatched
        /// </summary>
        public event EventHandler<ScriptEventEventArgs> ScriptEventResultDispatched;
        
        /// <summary>
        /// Event handler for the script warning dispatched
        /// </summary>
        public event EventHandler<WarningEventArgs> ScriptWarningDispatched;

        /// <summary>
        /// Event handler for script result dispatched
        /// </summary>
        public event EventHandler<ScriptEventArgs> ScriptResultDispatched;

        /// <summary>
        /// Event handler for report dispatched
        /// </summary>
        public event EventHandler<ReportEventArgs> ReportDispatched;

        /// <summary>
        /// Event handler for scripts dispatched
        /// </summary>
        public event EventHandler ScriptsDispatched;

        /// <summary>
        /// Event handler for configurations changed
        /// </summary>
        public event EventHandler ConfigurationChanged;

        /// <summary>
        /// Event handler for stopping
        /// </summary>
        public event EventHandler Stopping;

        /// <summary>
        /// Event handler for stopped
        /// </summary>
        public event EventHandler Stopped;

        /// <summary>
        /// Event handler for script file name check
        /// </summary>
        public event EventHandler<GeneratorConfigurationEventArgs> ScriptFileNameCheck;

        /// <summary>
        /// Event handler for playing
        /// </summary>
        public event EventHandler Playing;

        /// <summary>
        /// Event handler for configuration loaded dispatched
        /// </summary>
        public event EventHandler ConfigLoadedDispatched;

        /// <summary>
        /// Event handler for configuration checked dispatched
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> ConfigCheckedDispatched;

        /// <summary>
        /// Event handler for configuration dispatched
        /// </summary>
        public event EventHandler<ConfigFileEventArgs> ConfigDispatched;

        /// <summary>
        /// Event handler for cache initiate
        /// </summary>
        public event EventHandler<ScriptEventArgs> CacheInitiate;

        /// <summary>
        /// Event handler for view clear
        /// </summary>
        public event EventHandler ViewClear;

        /// <summary>
        /// Event handler for player configuration prepare
        /// </summary>
        public event EventHandler<PlayerConfigurationEventArgs> PlayerConfigurationPrepare;

        /// <summary>
        /// Event handler for logger start
        /// </summary>
        public event EventHandler LoggerStart;

        /// <summary>
        /// Event handler for logger stop
        /// </summary>
        public event EventHandler LoggerStop;

        /// <summary>
        /// Event handler for stop dispatched
        /// </summary>
        public event EventHandler StopDispatched;

        /// <summary>
        /// Event handler for response dispatched
        /// </summary>
        public event EventHandler<NcrEventArgs> ResponseDispatched;

        /// <summary>
        /// Event handler for configuration changed dispatched
        /// </summary>
        public event EventHandler ConfigurationChangedDispatched;

        /// <summary>
        /// Gets or sets the client configuration
        /// </summary>
        public ClientConfiguration Configuration
        {
            get
            {
                return _clientConfiguration;
            }

            set
            {
                _clientConfiguration = value;
                OnConfigurationChanged(null);
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not the client has stopped
        /// </summary>
        public bool HasStopped
        {
            get { return _errorDispatched || _scriptsDispatched || _hasStopped || HasTimedOut; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the client has report dispatched
        /// </summary>
        public bool HasReportDispatched
        {
            get { return _errorDispatched || _reportDispatched || HasTimedOut || HasTimedOut; }
        }

        /// <summary>
        /// Gets the configuration name
        /// </summary>
        public string ConfigurationName
        {
            get { return "ClientConfiguration." + Server + ".xml"; }
        }

        /// <summary>
        /// Gets the default configuration name
        /// </summary>
        public string DefaultConfigurationName
        {
            get { return "ClientConfiguration.default.xml"; }
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
        /// Adds the given dispatcher
        /// </summary>
        /// <param name="dispatcher">dispatcher to add</param>
        public void AddDispatcher(ISscatResponseDispatcher dispatcher)
        {
            Dispatchers.Add(dispatcher.Name, dispatcher);
        }

        /// <summary>
        /// Perform stopping
        /// </summary>
        public void PerformStopping()
        {
            OnStopping(null);
        }

        /// <summary>
        /// Perform playing
        /// </summary>
        public void PerformPlaying()
        {
            OnPlaying(null);
        }

        /// <summary>
        /// Stop client worker and player
        /// </summary>
        public virtual void Stop()
        {
            _hasStopped = true;
            SendRequest(new Request(SscatRequest.STOP_PLAYER, new MessageContent(string.Empty)));
            _clientWorker.Stop();
            OnStopped(null);
        }

        /// <summary>
        /// Initiate cache
        /// </summary>
        /// <param name="script">script file</param>
        public void InitiateCache(ScriptFile script)
        {
            OnCacheInitiate(new ScriptEventArgs(script));
        }

        /// <summary>
        /// Clears the view
        /// </summary>
        public void ClearView()
        {
            OnClearView(new EventArgs());
        }

        /// <summary>
        /// Prepares the player configuration
        /// </summary>
        /// <param name="script">script file</param>
        public void PreparePlayerConfiguration(ScriptFile script)
        {
            OnPlayerConfigurationPrepare(new PlayerConfigurationEventArgs(Configuration.PlayerConfiguration, script));
        }

        /// <summary>
        /// Generate configuration
        /// </summary>
        /// <param name="generatorConfiguration">generator configuration</param>
        public virtual void Generate(GeneratorConfiguration generatorConfiguration)
        {
            generatorConfiguration.Files = _clientConfiguration.Files;
            generatorConfiguration.Validate();
            if (!generatorConfiguration.HasErrors)
            {
                OnScriptFileNameCheck(new GeneratorConfigurationEventArgs(generatorConfiguration));
                if (!generatorConfiguration.HasErrors)
                {
                    _clientWorker.GeneratorConfiguration = generatorConfiguration;
                    ThreadHelper.Start(_clientWorker.Generate);
                }
                else
                {
                    PerformStopping();
                    MessageService.ShowWarning(generatorConfiguration.Errors.ToString());
                }
            }
            else
            {
                PerformStopping();
                MessageService.ShowWarning(generatorConfiguration.Errors.ToString());
            }
        }

        /// <summary>
        /// Play scripts
        /// </summary>
        /// <param name="scripts">scripts to play</param>
        public virtual void Play(List<ScriptFile> scripts)
        {
            _clientConfiguration.PlayerConfiguration.ConfigFiles = _clientConfiguration.Files;
            _clientConfiguration.PlayerConfiguration.Validate();
            if (!_clientConfiguration.PlayerConfiguration.HasErrors)
            {
                _clientWorker.ScriptFiles = scripts;
                ThreadHelper.Start(_clientWorker.Play);
            }
            else
            {
                PerformStopping();
                MessageService.ShowWarning(_clientConfiguration.PlayerConfiguration.Errors.ToString());
            }
        }

        /// <summary>
        /// Stop client worker
        /// </summary>
        public void StopWorker()
        {
            _clientWorker.Stop();
        }

        /// <summary>
        /// Disconnect client worker
        /// </summary>
        public override void Disconnect()
        {
            _clientWorker.Stop();
            base.Disconnect();
        }

        /// <summary>
        /// Event for logger start
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
        /// Event for logger stop
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
        /// Event for on player configuration prepare
        /// </summary>
        /// <param name="e">player configuration event arguments</param>
        protected virtual void OnPlayerConfigurationPrepare(PlayerConfigurationEventArgs e)
        {
            if (PlayerConfigurationPrepare != null)
            {
                PlayerConfigurationPrepare(this, e);
            }
        }

        /// <summary>
        /// Event for on configuration checked dispatched
        /// </summary>
        /// <param name="e">configuration file event arguments</param>
        protected virtual void OnConfigCheckedDispatched(ConfigFileEventArgs e)
        {
            if (ConfigCheckedDispatched != null)
            {
                ConfigCheckedDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on configuration dispatched
        /// </summary>
        /// <param name="e">configuration file event arguments</param>
        protected virtual void OnConfigDispatched(ConfigFileEventArgs e)
        {
            if (ConfigDispatched != null)
            {
                ConfigDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on configuration loaded dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConfigLoadedDispatched(EventArgs e)
        {
            if (ConfigLoadedDispatched != null)
            {
                ConfigLoadedDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on script file name check
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
        /// Event for on playing
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnPlaying(EventArgs e)
        {
            _hasStopped = false;
            if (Playing != null)
            {
                Playing(this, e);
            }
        }

        /// <summary>
        /// Event for on stopped
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStopped(EventArgs e)
        {
            if (Stopped != null)
            {
                Stopped(this, e);
            }
        }

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
        /// Event for on configuration changedS
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConfigurationChanged(EventArgs e)
        {
            if (ConfigurationChanged != null)
            {
                ConfigurationChanged(this, e);
            }
        }

        /// <summary>
        /// Event for on error dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected override void OnErrorDispatched(EventArgs e)
        {
            base.OnErrorDispatched(e);
            _errorDispatched = true;
        }

        /// <summary>
        /// Event for on data sent
        /// </summary>
        /// <param name="e">network event arguments</param>
        protected override void OnDataSent(NetworkEventArgs e)
        {
            _scriptsDispatched = false;
            _errorDispatched = false;
            _reportDispatched = false;
            base.OnDataSent(e);
        }

        /// <summary>
        /// Event for on script event result dispatched
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnScriptEventResultDispatched(ScriptEventEventArgs e)
        {
            if (ScriptEventResultDispatched != null)
            {
                ScriptEventResultDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on script warning dispatched
        /// </summary>
        /// <param name="e">warning event arguments</param>
        protected virtual void OnDispatcherScriptWarningDispatched(WarningEventArgs e)
        {
            if (ScriptWarningDispatched != null)
            {
                ScriptWarningDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on script result dispatched
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnScriptResultDispatched(ScriptEventArgs e)
        {
            if (ScriptResultDispatched != null)
            {
                ScriptResultDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on report dispatched
        /// </summary>
        /// <param name="e">report event arguments</param>
        protected virtual void OnReportDispatched(ReportEventArgs e)
        {
            if (ReportDispatched != null)
            {
                ReportDispatched(this, e);
            }

            _reportDispatched = true;
        }

        /// <summary>
        /// Event for on scripts dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnScriptsDispatched(EventArgs e)
        {
            if (ScriptsDispatched != null)
            {
                ScriptsDispatched(this, e);
            }

            _scriptsDispatched = true;
        }

        /// <summary>
        /// Event for on cache initiate
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnCacheInitiate(ScriptEventArgs e)
        {
            if (CacheInitiate != null)
            {
                CacheInitiate(this, e);
            }
        }

        /// <summary>
        /// Event for on clear view
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnClearView(EventArgs e)
        {
            if (ViewClear != null)
            {
                ViewClear(this, e);
            }
        }

        /// <summary>
        /// Event for on response dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnResponseDispatched(NcrEventArgs e)
        {
            if (ResponseDispatched != null)
            {
                ResponseDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on stop dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStopDispatched(EventArgs e)
        {
            if (StopDispatched != null)
            {
                StopDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for on configuration changed dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConfigurationChangedDispatched(EventArgs e)
        {
            if (ConfigurationChangedDispatched != null)
            {
                ConfigurationChangedDispatched(this, e);
            }
        }

        /// <summary>
        /// Event for client data arrived
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">network event arguments</param>
        protected override void ClientDataArrived(object sender, NetworkEventArgs e)
        {
            if (Dispatchers.ContainsKey(e.Response.Type))
            {
                ISscatResponseDispatcher dispatcher = Dispatchers[e.Response.Type] as ISscatResponseDispatcher;
                try
                {
                    dispatcher.Dispatching += new EventHandler<NcrEventArgs>(DispatcherDispatching);
                    dispatcher.ScriptsDispatched += new EventHandler(DispatcherScriptsDispatched);
                    dispatcher.ScriptEventResultDispatched += new EventHandler<ScriptEventEventArgs>(DispatcherScriptEventResultDispatched);
                    dispatcher.ScriptResultDispatched += new EventHandler<ScriptEventArgs>(DispatcherScriptResultDispatched);
                    dispatcher.ScriptWarningEventResultDispatched += new EventHandler<WarningEventArgs>(DispatcherScriptWarningDispatched);
                    dispatcher.ReportDispatched += new EventHandler<ReportEventArgs>(DispatcherReportDispatched);
                    dispatcher.ErrorDispatched += new EventHandler(DispatcherErrorDispatched);
                    dispatcher.ConfigLoadedDispatched += new EventHandler(DispatcherConfigLoadedDispatched);
                    dispatcher.ConfigCheckedDispatched += new EventHandler<ConfigFileEventArgs>(DispatcherConfigCheckedDispatched);
                    dispatcher.ConfigDispatched += new EventHandler<ConfigFileEventArgs>(DispatcherConfigDispatched);
                    dispatcher.StopDispatched += new EventHandler(DispatcherStopDispatched);
                    dispatcher.ResponseDispatched += new EventHandler<NcrEventArgs>(DispatcherResponseDispatched);
                    dispatcher.ConfigurationChangedDispatched += new EventHandler(DispatcherConfigurationChangedDispatch);
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
                    dispatcher.ScriptsDispatched -= new EventHandler(DispatcherScriptsDispatched);
                    dispatcher.ScriptEventResultDispatched -= new EventHandler<ScriptEventEventArgs>(DispatcherScriptEventResultDispatched);
                    dispatcher.ScriptResultDispatched -= new EventHandler<ScriptEventArgs>(DispatcherScriptResultDispatched);
                    dispatcher.ScriptWarningEventResultDispatched -= new EventHandler<WarningEventArgs>(DispatcherScriptWarningDispatched);
                    dispatcher.ReportDispatched -= new EventHandler<ReportEventArgs>(DispatcherReportDispatched);
                    dispatcher.ErrorDispatched -= new EventHandler(DispatcherErrorDispatched);
                    dispatcher.ConfigLoadedDispatched -= new EventHandler(DispatcherConfigLoadedDispatched);
                    dispatcher.ConfigCheckedDispatched -= new EventHandler<ConfigFileEventArgs>(DispatcherConfigCheckedDispatched);
                    dispatcher.ConfigDispatched -= new EventHandler<ConfigFileEventArgs>(DispatcherConfigDispatched);
                    dispatcher.StopDispatched -= new EventHandler(DispatcherStopDispatched);
                    dispatcher.ResponseDispatched -= new EventHandler<NcrEventArgs>(DispatcherResponseDispatched);
                    dispatcher.ConfigurationChangedDispatched -= new EventHandler(DispatcherConfigurationChangedDispatch);
                }
            }
            else
            {
                string msg = string.Format("Response dispatcher for type '{0}' not supported", e.Response.Type);
                LoggingService.Error(msg);
                MessageService.ShowError(msg);
            }
        }

        /// <summary>
        /// Event for dispatcher configuration changed dispatch
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherConfigurationChangedDispatch(object sender, EventArgs e)
        {
            OnConfigurationChangedDispatched(e);
        }

        /// <summary>
        /// Event for dispatcher stop dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherStopDispatched(object sender, EventArgs e)
        {
            OnStopDispatched(e);
        }

        /// <summary>
        /// Event for dispatcher response dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherResponseDispatched(object sender, NcrEventArgs e)
        {
            OnResponseDispatched(e);
        }

        /// <summary>
        /// Event for dispatcher configuration checked dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration file event arguments</param>
        private void DispatcherConfigCheckedDispatched(object sender, ConfigFileEventArgs e)
        {
            OnConfigCheckedDispatched(e);
        }

        /// <summary>
        /// Event for dispatcher configuration dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration file event arguments</param>
        private void DispatcherConfigDispatched(object sender, ConfigFileEventArgs e)
        {
            OnConfigDispatched(e);
        }

        /// <summary>
        /// Event for dispatcher configuration loaded dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherConfigLoadedDispatched(object sender, EventArgs e)
        {
            OnConfigLoadedDispatched(e);
        }

        /// <summary>
        /// Event for dispatcher scripts dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherScriptsDispatched(object sender, EventArgs e)
        {
            OnScriptsDispatched(e);
        }

        /// <summary>
        /// Event for dispatcher error dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherErrorDispatched(object sender, EventArgs e)
        {
            OnErrorDispatched(e);
        }

        /// <summary>
        /// Event for dispatcher report dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">report event arguments</param>
        private void DispatcherReportDispatched(object sender, ReportEventArgs e)
        {
            OnReportDispatched(e);
        }

        /// <summary>
        /// Event for dispatcher script result dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void DispatcherScriptResultDispatched(object sender, ScriptEventArgs e)
        {
            OnScriptResultDispatched(e);
        }

        /// <summary>
        /// Event for dispatcher script event result dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void DispatcherScriptEventResultDispatched(object sender, ScriptEventEventArgs e)
        {
            OnScriptEventResultDispatched(e);
        }
        
        /// <summary>
        /// Event for dispatcher script warning dispatched
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">warnings event arguments</param>
        private void DispatcherScriptWarningDispatched(object sender, WarningEventArgs e)
        {
            OnDispatcherScriptWarningDispatched(e);
        }

        /// <summary>
        /// Event for dispatcher dispatching
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void DispatcherDispatching(object sender, NcrEventArgs e)
        {
            OnResponseDispatching(e);
        }
    }
}
