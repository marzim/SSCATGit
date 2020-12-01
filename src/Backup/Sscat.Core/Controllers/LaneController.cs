// <copyright file="LaneController.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Ncr.Core;
    using Ncr.Core.Controllers;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Core.Config;
    using Sscat.Core.Emulators;
    using Sscat.Core.Gui;
    using Sscat.Core.Models;
    using Sscat.Core.Models.Report;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Parsers;
    using Sscat.Core.Services;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the LaneController class
    /// </summary>
    public class LaneController : AbstractController
    {
        /// <summary>
        /// Interface for the player view
        /// </summary>
        private IPlayerView _playerView;

        /// <summary>
        /// Interface for the generator view
        /// </summary>
        private IScriptGeneratorView _generatorView;

        /// <summary>
        /// Interface for the custom generator view
        /// </summary>
        private ICustomGeneratorView _customGeneratorView;

        /// <summary>
        /// Interface for the script list view
        /// </summary>
        private IScriptListView _scriptListView;

        /// <summary>
        /// Lane service
        /// </summary>
        private LaneService _service;

        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Initializes a new instance of the LaneController class
        /// </summary>
        /// <param name="customGeneratorView">custom generator view</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="service">lane service</param>
        public LaneController(ICustomGeneratorView customGeneratorView, SscatLane lane, LaneService service)
        {
            _customGeneratorView = customGeneratorView;
            _lane = lane;
            _service = service;

            service.Servicing += new EventHandler<NcrEventArgs>(ServiceServicing);
            customGeneratorView.CustomGenerate += new EventHandler<GeneratorConfigurationEventArgs>(CustomerGeneratorViewGenerating);
        }

        /// <summary>
        /// Initializes a new instance of the LaneController class
        /// </summary>
        /// <param name="lane">sscat lane</param>
        /// <param name="service">lane service</param>
        /// <param name="playerView">player view</param>
        /// <param name="generatorView">generator view</param>
        /// <param name="scriptListView">script list view</param>
        public LaneController(SscatLane lane, LaneService service, IPlayerView playerView, IScriptGeneratorView generatorView, IScriptListView scriptListView)
        {
            _lane = lane;
            _service = service;
            _playerView = playerView;
            _generatorView = generatorView;
            _customGeneratorView = null;
            _scriptListView = scriptListView;

            service.Servicing += new EventHandler<NcrEventArgs>(ServiceServicing);
            generatorView.Generate += new EventHandler<GeneratorConfigurationEventArgs>(GeneratorViewGenerating);
            playerView.Play += new EventHandler<SscatLaneEventArgs>(PlayerViewPlay);
            scriptListView.ScriptsList += new EventHandler<SscatLaneEventArgs>(ScriptListViewScriptsList);
        }

        /// <summary>
        /// Finalizes an instance of the LaneController class
        /// </summary>
        ~LaneController()
        {
            _service.Servicing -= new EventHandler<NcrEventArgs>(ServiceServicing);
            if (_customGeneratorView == null)
            {
                _generatorView.Generate -= new EventHandler<GeneratorConfigurationEventArgs>(GeneratorViewGenerating);
                _playerView.Play -= new EventHandler<SscatLaneEventArgs>(PlayerViewPlay);
                _scriptListView.ScriptsList -= new EventHandler<SscatLaneEventArgs>(ScriptListViewScriptsList);
            }
            else
            {
                _customGeneratorView.CustomGenerate -= new EventHandler<GeneratorConfigurationEventArgs>(CustomerGeneratorViewGenerating);
            }
        }

        /// <summary>
        /// Play view
        /// </summary>
        /// <returns>Returns player view</returns>
        public IView Play()
        {
            return _playerView;
        }

        /// <summary>
        /// Generate view
        /// </summary>
        /// <returns>Returns generator view</returns>
        public IView Generate()
        {
            return _generatorView;
        }

        /// <summary>
        /// Custom generate view
        /// </summary>
        /// <returns>Returns custom generator view</returns>
        public IView CustomGenerate()
        {
            return _customGeneratorView;
        }

        /// <summary>
        /// Show view
        /// </summary>
        /// <returns>Returns script list view</returns>
        public IView Show()
        {
            return _scriptListView;
        }

        /// <summary>
        /// Generate a script
        /// </summary>
        /// <param name="name">script name</param>
        /// <param name="description">script description</param>
        /// <param name="diagpath">diagnostics path</param>
        /// <param name="sscoBuild">ssco build</param>
        /// <param name="build">the build</param>
        /// <param name="segmented">whether or not to segment a script</param>
        /// <param name="scriptsOutputDirectory">scripts output directory</param>
        /// <param name="generateLast">whether or not to generate last</param>
        /// <param name="lastScriptsNumber">last scripts number</param>
        /// <param name="dontShowMSCardEditor">whether or not to show the MS card editor</param>
        /// <param name="defaultMSCard">default ms card</param>
        /// <param name="enableUIValidation">whether UI Validation is enabled</param>
        public void Generate(string name, string description, string diagpath, string sscoBuild, string build, bool segmented, string scriptsOutputDirectory, bool generateLast, int lastScriptsNumber, bool dontShowMSCardEditor, string defaultMSCard, bool enableUIValidation)
        {
            try
            {
                // FIXME: Why should we assign it here. There also a code like this in client woker's generate. Please check!
                _lane.Configuration.Files.SourceDirectory = @"C:\scot\config";
                _lane.Configuration.Files.DestinationDirectory = scriptsOutputDirectory;
                _lane.Configuration.GeneratorConfiguration.DiagPath = diagpath;

                _lane.ConfigurationGet += new EventHandler<ConfigFilesEventArgs>(LaneConfigurationGet);
                _lane.ParserInitialize += new EventHandler(LaneParserInitialize);
                _lane.Parse += new EventHandler<ProgressEventArgs>(LaneParse);
                _lane.Generating += new EventHandler<ProgressEventArgs>(LaneGenerating);

                _lane.ValidateScriptname(ref name, scriptsOutputDirectory);
                IScript[] scripts = _lane.Generate(name, description, sscoBuild, build, segmented, scriptsOutputDirectory, generateLast, lastScriptsNumber, defaultMSCard, enableUIValidation);
                _service.SaveConfigFiles(_lane.Configuration.Files.Files);
                if (!(_customGeneratorView == null) && CardEventEditor.ContainsMSCard(scripts) == true && dontShowMSCardEditor == false)
                {
                    ShowMSRForm(scripts);
                }
                else if (CardEventEditor.ContainsMSCard(scripts) == false && dontShowMSCardEditor == false)
                {
                    OnDoingSomething("No MS Card(s) was/were found on the script(s)! The MS Card Editor will not be shown.");
                }

                _service.SaveScripts(scripts);
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                throw;
            }
            finally
            {
                _lane.ConfigurationGet -= new EventHandler<ConfigFilesEventArgs>(LaneConfigurationGet);
                _lane.ParserInitialize -= new EventHandler(LaneParserInitialize);
                _lane.Parse -= new EventHandler<ProgressEventArgs>(LaneParse);
                _lane.Generating -= new EventHandler<ProgressEventArgs>(LaneGenerating);
            }
        }

        /// <summary>
        /// Play script
        /// </summary>
        /// <param name="scriptFiles">script files</param>
        /// <param name="repeat">repeat times</param>
        /// <param name="customReportFile">custom report file to optionally create</param>
        public void Play(List<ScriptFile> scriptFiles, int repeat, string customReportFile)
        {
            try
            {
                // For creating the Report Playback Summary
                ReportPlayback reportPlayback = new ReportPlayback();

                // If report file name is specified, use that name, otherwise create default name with time date stamp
                if (!string.IsNullOrEmpty(customReportFile))
                {
                    reportPlayback.CreateReportPlaybackFormat(
                        string.Format(
                        @"C:\SSCAT\Reports\{0}",
                        customReportFile));
                }
                else
                {
                    reportPlayback.CreateReportPlaybackFormat(
                        string.Format(
                        @"C:\SSCAT\Reports\ReportPlayback-{0}.csv",
                        DateTime.Now.ToString("yyyyMMdd-HHmmss")));
                }

                List<IScript> scripts = new List<IScript>();
                foreach (ScriptFile s in scriptFiles)
                {
                    scripts.Add(_service.ReadScript(s.File));
                }

                _lane.LogHookInitialize += new EventHandler(PlayerLogHookInitialize);
                _lane.ConfigurationLoad += new EventHandler<ConfigFilesEventArgs>(LaneConfigurationLoad);
                _lane.Playing += new EventHandler<ProgressEventArgs>(PlayerPlaying);
                _lane.ScriptEventChanged += new EventHandler<ScriptEventEventArgs>(LaneScriptEventChanged);
                _lane.ScriptWarningChanged += new EventHandler<WarningEventArgs>(LaneScriptWarningChanged);
                _lane.Emulating += new EventHandler<EmulatorEventArgs>(LaneEmulating);
                _lane.ConfigFilesRead += new EventHandler<ScriptEventArgs>(LaneConfigFilesRead);

                for (int i = 0; i < repeat; i++)
                {
                    Report report = _lane.Play(
                        scripts,
                        _lane.Configuration.PlayerConfiguration.LogHookTimeout,
                        _lane.Configuration.PlayerConfiguration.WarningTimeout,
                        _lane.Configuration.PlayerConfiguration.EnableLogHook,
                        i);

                    string text = @"type='text/xsl' href='C:\SSCAT\Config\SSCATPlayback.xsl'";
                    _service.SaveReport(report, text);
                }

                OnDoingSomething(string.Format("Playback report save to {0}", reportPlayback.ReportPlaybackFile.ToString()));
            }
            catch
            {
                throw;
            }
            finally
            {
                _lane.LogHookInitialize -= new EventHandler(PlayerLogHookInitialize);
                _lane.ConfigurationLoad -= new EventHandler<ConfigFilesEventArgs>(LaneConfigurationLoad);
                _lane.Playing -= new EventHandler<ProgressEventArgs>(PlayerPlaying);
                _lane.ScriptEventChanged -= new EventHandler<ScriptEventEventArgs>(LaneScriptEventChanged);
                _lane.ScriptWarningChanged -= new EventHandler<WarningEventArgs>(LaneScriptWarningChanged);
                _lane.Emulating -= new EventHandler<EmulatorEventArgs>(LaneEmulating);
                _lane.ConfigFilesRead -= new EventHandler<ScriptEventArgs>(LaneConfigFilesRead);
            }
        }

        /// <summary>
        /// Show date time info
        /// </summary>
        /// <param name="message">message to log</param>
        public virtual void OnDoingSomething(string message)
        {
            if (_customGeneratorView != null)
            {
                _customGeneratorView.WriteLine(string.Format("{0}: {1}", DateTimeUtility.Now(), message));
            }
            else
            {
                MessageService.ShowInfo(string.Format("{0}: {1}", DateTimeUtility.Now(), message));
            }

            LoggingService.Info(message);
        }

        /// <summary>
        /// Show MSR form
        /// </summary>
        /// <param name="scripts">scripts list</param>
        private void ShowMSRForm(IScript[] scripts)
        {
            CardEventEditor form = new CardEventEditor();
            _lane.Configuration.FileName = ApplicationUtility.LaneConfigurationFileName;
            form.AddScriptsToScriptListView(new List<IScript>(scripts));
            form.AddConfig(_lane.Configuration);
            if (!form.IsDisposed)
            {
                form.ShowDialog();
            }

            form.Dispose();
        }

        /// <summary>
        /// Add scripts to scripts list
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">sscat lane event arguments</param>
        private void ScriptListViewScriptsList(object sender, SscatLaneEventArgs e)
        {
            List<IScript> scripts = new List<IScript>();
            foreach (ScriptFile f in e.ScriptFiles)
            {
                scripts.Add(_service.ReadScript(f.File));
            }

            _scriptListView.Scripts = scripts;
        }

        /// <summary>
        /// Custom generator view generating event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void CustomerGeneratorViewGenerating(object sender, GeneratorConfigurationEventArgs e)
        {
            Generate(e.Config.ScriptName, e.Config.ScriptDescription, e.Config.DiagPath, _lane.ProductVersion, ApplicationUtility.ProductVersion, e.Config.SegmentedScripts, e.Config.ScriptOutputDirectory, e.Config.GenerateLast, e.Config.LastScriptsNumber, e.Config.DontShowMSCardEditor, e.Config.DefaultMSCard, e.Config.UIValidation);
        }

        /// <summary>
        /// Get lane configuration event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration files event arguments</param>
        private void LaneConfigurationGet(object sender, ConfigFilesEventArgs e)
        {
            _service.GetConfiguration(e.Files, e.ConfigName);
        }

        /// <summary>
        /// Lane configuration load event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">configuration files event arguments</param>
        private void LaneConfigurationLoad(object sender, ConfigFilesEventArgs e)
        {
            _service.LoadConfiguration(e.Files, e.ForceStop);
        }

        /// <summary>
        /// Lane configuration files read event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void LaneConfigFilesRead(object sender, ScriptEventArgs e)
        {
            string dir = Path.GetDirectoryName(e.Script.FileName);
            _lane.Configuration.PlayerConfiguration.ConfigFiles = _lane.Configuration.Files;
            _service.ReadConfigFiles(Path.Combine(dir, e.Script.Name), _lane.Configuration.PlayerConfiguration.ConfigFiles);
        }

        /// <summary>
        /// Lane emulating event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">emulator event arguments</param>
        private void LaneEmulating(object sender, EmulatorEventArgs e)
        {
            OnDoingSomething(e.Message);
        }

        /// <summary>
        /// Servicing event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServiceServicing(object sender, NcrEventArgs e)
        {
            OnDoingSomething(e.Message);
        }

        /// <summary>
        /// Lane parse event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">progress event arguments</param>
        private void LaneParse(object sender, ProgressEventArgs e)
        {
            OnDoingSomething(e.Message);
        }

        /// <summary>
        /// Lane generating event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">progress event arguments</param>
        private void LaneGenerating(object sender, ProgressEventArgs e)
        {
            OnDoingSomething(e.Message);
        }

        /// <summary>
        /// Lane parser initialize event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void LaneParserInitialize(object sender, EventArgs e)
        {
            _lane.Parsers = _service.CreateParsers();
        }

        /// <summary>
        /// Generator view event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">generator configuration event arguments</param>
        private void GeneratorViewGenerating(object sender, GeneratorConfigurationEventArgs e)
        {
            Generate(e.Config.ScriptName, e.Config.ScriptDescription, e.Config.DiagPath, _lane.ProductVersion, ApplicationUtility.ProductVersion, e.Config.SegmentedScripts, e.Config.ScriptOutputDirectory, e.Config.GenerateLast, e.Config.LastScriptsNumber, e.Config.DontShowMSCardEditor, e.Config.DefaultMSCard, e.Config.UIValidation);
        }

        /// <summary>
        /// Lane script event changed event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void LaneScriptEventChanged(object sender, ScriptEventEventArgs e)
        {
            if (e.Event.Result.Type == ResultType.Passed)
            {
                OnDoingSomething(e.Event.Result.ToString());
            }
            else
            {
                OnDoingSomething(string.Format("{0} : {1}", e.Event.Result.ToString(), e.Event.ToRepresentation()));
            }
        }

        /// <summary>
        /// Lane script warning changed event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">warning event arguments</param>
        private void LaneScriptWarningChanged(object sender, WarningEventArgs e)
        {
            OnDoingSomething(string.Format("{0} : {1}", e.Event.ToString(), e.Event.ToRepresentation()));
        }

        /// <summary>
        /// Player view play event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">sscat lane event arguments</param>
        private void PlayerViewPlay(object sender, SscatLaneEventArgs e)
        {
            Play(e.ScriptFiles, e.Repeat, e.CustomReportFileName);
        }

        /// <summary>
        /// Player log hook initialize event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void PlayerLogHookInitialize(object sender, EventArgs e)
        {
            _lane.Hooks = _service.CreateHooks();
        }

        /// <summary>
        /// Player playing event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">progress event arguments</param>
        private void PlayerPlaying(object sender, ProgressEventArgs e)
        {
            OnDoingSomething(e.Message);
        }
    }
}
