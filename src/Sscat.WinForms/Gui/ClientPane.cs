// <copyright file="ClientPane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Gui
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Gui;
    using Ncr.Core.Views;
    using Sscat.Core.Config;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Net;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ClientPane class
    /// </summary>
    public partial class ClientPane : BaseUserControl, IClientView
    {
        /// <summary>
        /// SSCAT client
        /// </summary>
        private SscatClient _client;

        /// <summary>
        /// Interface for the client configuration view
        /// </summary>
        private IClientConfigurationView _configView;

        /// <summary>
        /// Interface for the script generator view
        /// </summary>
        private IScriptGeneratorView _generatorView;

        /// <summary>
        /// Interface for the player view 
        /// </summary>
        private IPlayerView _playerView;

        /// <summary>
        /// Initializes a new instance of the ClientPane class
        /// </summary>
        /// <param name="generatorView">generator view</param>
        /// <param name="playerView">player view</param>
        /// <param name="configView">configuration view</param>
        public ClientPane(IScriptGeneratorView generatorView, IPlayerView playerView, IClientConfigurationView configView)
        {
            InitializeComponent();
            SetTitle("Client");
            _generatorView = generatorView;
            _playerView = playerView;
            _configView = configView;

            generatorView.Generate += delegate(object sender, GeneratorConfigurationEventArgs e) { OnGenerate(e); };
            generatorView.Stop += delegate { OnStop(null); };

            playerView.Play += delegate(object sender, SscatLaneEventArgs e) { OnPlay(e); };
            playerView.Stop += delegate { OnStop(null); };

            configView.ConfigurationSave += delegate(object sender, ClientConfigurationEventArgs e) { OnConfigurationSave(e); };
            configView.ConfigurationDefaultRestore += delegate { OnConfigurationRestore(null); };
            configView.ConfigurationChanged += delegate { };

            toolStripButtonGenerateScripts.PerformClick();
        }

        /// <summary>
        /// Event handler for configuration save
        /// </summary>
        public event EventHandler<ClientConfigurationEventArgs> ConfigurationSave;

        /// <summary>
        /// Event handler for configuration restore
        /// </summary>
        public event EventHandler ConfigurationRestore;

        /// <summary>
        /// Event handler for play script
        /// </summary>
        public event EventHandler<SscatLaneEventArgs> Play;

        /// <summary>
        /// Event handler for generate script
        /// </summary>
        public event EventHandler<GeneratorConfigurationEventArgs> Generate;

        /// <summary>
        /// Event handler for stop script
        /// </summary>
        public event EventHandler Stop;

        /// <summary>
        /// Gets or sets the SSCAT client
        /// </summary>
        public SscatClient Client
        {
            get
            {
                return _client;
            }

            set
            {
                _client = value;
                _client.ConfigurationChanged += delegate
                {
                    _configView.Configuration = _client.Configuration;
                    _generatorView.Configuration = _client.Configuration.GeneratorConfiguration;
                };
            }
        }

        /// <summary>
        /// Gets the output view
        /// </summary>
        public IOutputView OutputView
        {
            get { return outputPane1; }
        }

        /// <summary>
        /// Select the given script
        /// </summary>
        /// <param name="script">script to select</param>
        public void SelectScript(ScriptFile script)
        {
            _playerView.SelectScript(script);
        }
        
        /// <summary>
        /// Update the warning events
        /// </summary>
        /// <param name="e">warning event</param>
        public void UpdateWarning(IWarningEvent e)
        {
            _playerView.UpdateWarningEventResult(e);
        }

        /// <summary>
        /// Update the event result
        /// </summary>
        /// <param name="e">script event</param>
        public void UpdateResult(IScriptEvent e)
        {
            _playerView.UpdateEventResult(e);
        }

        /// <summary>
        /// Update the script result
        /// </summary>
        /// <param name="s">script to update</param>
        public void UpdateResult(IScript s)
        {
            _playerView.UpdateScriptResult(s);
        }

        /// <summary>
        /// Update the view on connection timeout
        /// </summary>
        /// <param name="error">error message</param>
        public void UpdateViewOnConnectionTimeout(string error)
        {
            _playerView.UpdateViewOnConnectionTimeout(error);
        }

        /// <summary>
        /// Clear the player view results
        /// </summary>
        public void ClearResults()
        {
            _playerView.ClearResults();
        }

        /// <summary>
        /// Write the given text to the output view
        /// </summary>
        /// <param name="text">text to write</param>
        public void WriteLine(string text)
        {
            OutputView.WriteLine(text);
        }

        /// <summary>
        /// Perform the script generation
        /// </summary>
        public void PerformGenerate()
        {
            OnGenerate(new GeneratorConfigurationEventArgs(_client.Configuration.GeneratorConfiguration));
        }

        /// <summary>
        /// Perform the script playing
        /// </summary>
        public void PerformPlaying()
        {
            _playerView.PerformPlaying();
            _generatorView.PerformDisable();
        }

        /// <summary>
        /// Perform the script generation
        /// </summary>
        public void PerformGenerating()
        {
            _generatorView.PerformGenerating();
            _playerView.PerformDisable();
        }

        /// <summary>
        /// Perform the script stopping
        /// </summary>
        public void PerformStopping()
        {
            _playerView.PerformStopping();
            _generatorView.PerformStopping();
        }

        /// <summary>
        /// Perform the script disable
        /// </summary>
        public void PerformDisable()
        {
            _playerView.PerformDisable();
            _generatorView.PerformDisable();
        }

        /// <summary>
        /// Initiate the cache
        /// </summary>
        /// <param name="e">script event arguments</param>
        public void InitiateCache(ScriptEventArgs e)
        {
            _playerView.InitiateCache(e);
        }

        /// <summary>
        /// Clear the player view
        /// </summary>
        public void ClearView()
        {
            _playerView.ClearView();
        }

        /// <summary>
        /// Add to panel
        /// </summary>
        /// <param name="view">view to add</param>
        public void AddToPanel(IView view)
        {
            Control control = view as Control;
            control.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Clear();
            splitContainer1.Panel1.Controls.Add(control);
        }

        /// <summary>
        /// Event for on stop
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStop(EventArgs e)
        {
            if (Stop != null)
            {
                Stop(this, e);
            }
        }

        /// <summary>
        /// Event for on configuration restore
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConfigurationRestore(EventArgs e)
        {
            if (ConfigurationRestore != null)
            {
                ConfigurationRestore(this, e);
            }
        }

        /// <summary>
        /// Event for save configuration
        /// </summary>
        /// <param name="e">client configuration event arguments</param>
        protected virtual void OnConfigurationSave(ClientConfigurationEventArgs e)
        {
            if (ConfigurationSave != null)
            {
                ConfigurationSave(this, e);
            }
        }

        /// <summary>close view
        /// Event for 
        /// </summary>
        /// <param name="e">event arguments</param>
        protected override void OnViewClose(EventArgs e)
        {
            _client.Disconnect();
            base.OnViewClose(e);
        }

        /// <summary>
        /// Event for on generate
        /// </summary>
        /// <param name="e">generator configuration event arguments</param>
        protected virtual void OnGenerate(GeneratorConfigurationEventArgs e)
        {
            if (Generate != null)
            {
                Generate(this, e);
            }
        }

        /// <summary>
        /// Event for on play
        /// </summary>
        /// <param name="e">sscat lane event arguments</param>
        protected virtual void OnPlay(SscatLaneEventArgs e)
        {
            if (Play != null)
            {
                Play(this, e);
            }
        }

        /// <summary>
        /// Event for clicking the generate scripts button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ToolStripButtonGenerateScriptsClick(object sender, EventArgs e)
        {
            CheckSelectedToolStripButton(sender as ToolStripButton);
            AddToPanel(_generatorView);
        }

        /// <summary>
        /// Event for clicking the run scripts button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ToolStripButtonRunScriptsClick(object sender, EventArgs e)
        {
            CheckSelectedToolStripButton(sender as ToolStripButton);
            AddToPanel(_playerView);
        }

        /// <summary>
        /// Event for clicking the settings button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ToolStripButtonSettingsClick(object sender, EventArgs e)
        {
            CheckSelectedToolStripButton(sender as ToolStripButton);
            AddToPanel(_configView);
        }

        /// <summary>
        /// Check the selected tool strip button
        /// </summary>
        /// <param name="button">selected button</param>
        private void CheckSelectedToolStripButton(ToolStripButton button)
        {
            foreach (ToolStripButton b in new ToolStripButton[] { toolStripButtonGenerateScripts, toolStripButtonRunScripts, toolStripButtonSettings })
            {
                b.Checked = false;
            }

            button.Checked = true;
        }
    }
}
