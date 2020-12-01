// <copyright file="SscatLane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Ncr.Core;
    using Ncr.Core.Emulators;
    using Ncr.Core.ExtensionMethods;
    using Ncr.Core.Models;
    using Ncr.Core.Util;
    using PsxNet;
    using Sscat.Core.Commands;
    using Sscat.Core.Commands.Events;
#if NET40
    using Sscat.Core.Commands.Events.UIAutoTest;
#endif
    using Sscat.Core.Config;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.PsxDisplay;
    using Sscat.Core.Models.Report;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Parsers;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the SscatLane class
    /// </summary>
    public class SscatLane : Lane
    {
        /// <summary>
        /// Scot log hooks
        /// </summary>
        private Dictionary<string, IScotLogHook> _hooks;

        /// <summary>
        /// Interface for SSCAT security manager
        /// </summary>
        private ISscatSecurityManager _securityManager;

        /// <summary>
        /// Interface for SSCAT launch pad
        /// </summary>
        private ISscatLaunchPad _launchPad;

        /// <summary>
        /// Interface for SSCAT application launcher
        /// </summary>
        private ISscatApplicationLauncher _applicationLauncher;

        /// <summary>
        /// Interface for the parsers
        /// </summary>
        private List<IParser> _parsers;

        /// <summary>
        /// Back commands
        /// </summary>
        private IDictionary<string, LaneCommand> _backCommands;

        /// <summary>
        /// Back commands
        /// </summary>
        private IDictionary<string, LaneCommand> _nxtuiBackCommands;

        /// <summary>
        /// Lane configuration
        /// </summary>
        private LaneConfiguration _config;

        /// <summary>
        /// Script resource folder
        /// </summary>
        private string _scriptResourceFolder;

        /// <summary>
        /// Screenshot path
        /// </summary>
        private string _screenshotPath;

        /// <summary>
        /// Network screenshot link
        /// </summary>
        private string _networkScreenshotLink;

        /// <summary>
        /// Network screenshot path
        /// </summary>
        private string _networkScreenshotPath;

        /// <summary>
        /// Script cash count
        /// </summary>
        private string _scriptCashCount;

        /// <summary>
        /// Script start screen
        /// </summary>
        private string _scriptStartScreen;

        /// <summary>
        /// PSX screen
        /// </summary>
        private int _psxScreen = 0;

        /// <summary>
        /// Number of warnings
        /// </summary>
        private int _numberOfWarnings = 0;

        /// <summary>
        /// Start Duration Timer
        /// </summary>
        private int _startDurationTimer = 0;

        /// <summary>
        /// Whether or not previous script failed
        /// </summary>
        private bool _previousScriptFailed;

        /// <summary>
        /// Whether or not to use the console
        /// </summary>
        private bool _console;

        /// <summary>
        /// Undefined context in NXTUIBackCommands 
        /// which caused the SSCAT encounter an error
        /// </summary>
        private string _undefinedNXTUICommand;

        /// <summary>
        /// Whether or not to use the console
        /// </summary>
        private List<ReportWarningEvent> _reportWarningApplicationEvent = new List<ReportWarningEvent>();

        /// <summary>
        /// Initializes a new instance of the SscatLane class
        /// </summary>
        public SscatLane()
            : base()
        {
            _config = new LaneConfiguration();
            BackCommands = new Dictionary<string, LaneCommand>();
            NXTUIBackCommands = new Dictionary<string, LaneCommand>();
        }

        /// <summary>
        /// Initializes a new instance of the SscatLane class
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        /// <param name="console">whether or not it is console</param>
        /// <param name="checkForStoreLogin">whether or not to check for store login</param>
        public SscatLane(int timeout, bool console, bool checkForStoreLogin)
            : base(timeout, checkForStoreLogin)
        {
            _console = console;
            Hooks = new Dictionary<string, IScotLogHook>();

            _config = new LaneConfiguration();
            BackCommands = new Dictionary<string, LaneCommand>();
            NXTUIBackCommands = new Dictionary<string, LaneCommand>();
        }

        /// <summary>
        /// Event handler for playing
        /// </summary>
        public event EventHandler<ProgressEventArgs> Playing;

        /// <summary>
        /// Event handler for initializing the log hook
        /// </summary>
        public event EventHandler LogHookInitialize;

        /// <summary>
        /// Event handler for when scripts change
        /// </summary>
        public event EventHandler<ScriptEventArgs> ScriptChanged;

        /// <summary>
        /// Event handler for when script events change
        /// </summary>
        public event EventHandler<ScriptEventEventArgs> ScriptEventChanged;

        /// <summary>
        /// Event handler for when script warning change
        /// </summary>
        public event EventHandler<WarningEventArgs> ScriptWarningChanged;

        /// <summary>
        /// Event handler for parsing
        /// </summary>
        public event EventHandler<ProgressEventArgs> Parse;

        /// <summary>
        /// Event handler for generating
        /// </summary>
        public event EventHandler<ProgressEventArgs> Generating;

        /// <summary>
        /// Event handler for initializing the parser
        /// </summary>
        public event EventHandler ParserInitialize;

        /// <summary>
        /// Event handler for reading configuration files
        /// </summary>
        public event EventHandler<ScriptEventArgs> ConfigFilesRead;

        /// <summary>
        /// Event handler for loading the configuration
        /// </summary>
        public event EventHandler<ConfigFilesEventArgs> ConfigurationLoad;

        /// <summary>
        /// Event handler for getting the configuration
        /// </summary>
        public event EventHandler<ConfigFilesEventArgs> ConfigurationGet;

        /// <summary>
        /// Event handler for stopping
        /// </summary>
        public event EventHandler Stopping;

        /// <summary>
        /// Event handler for requesting RAP events
        /// </summary>
        public event EventHandler RequestRapEvents;

        /// <summary>
        /// Event handler for dispatching the stop
        /// </summary>
        public event EventHandler StopDispatch;

        /// <summary>
        /// Event handler for starting the logger
        /// </summary>
        public event EventHandler LoggerStart;

        /// <summary>
        /// Event handler for stopping the logger
        /// </summary>
        public event EventHandler LoggerStop;

        /// <summary>
        /// Gets or sets the back commands
        /// </summary>
        public IDictionary<string, LaneCommand> BackCommands
        {
            get { return _backCommands; }
            set { _backCommands = value; }
        }

        /// <summary>
        /// Gets or sets the back commands
        /// </summary>
        public IDictionary<string, LaneCommand> NXTUIBackCommands
        {
            get { return _nxtuiBackCommands; }
            set { _nxtuiBackCommands = value; }
        }

        /// <summary>
        /// Gets or sets the lane configuration
        /// </summary>
        public LaneConfiguration Configuration
        {
            get
            {
                return _config;
            }

            set
            {
                _config = value;

#if NET40
                AddCommands(_config.NXTUICreateBackCommands());
#else
                AddCommands(_config.CreateBackCommands());
#endif
            }
        }

        /// <summary>
        /// Gets or sets the parsers 
        /// </summary>
        public List<IParser> Parsers
        {
            get { return _parsers; }
            set { _parsers = value; }
        }

        /// <summary>
        /// Gets or sets the sscat launch pad 
        /// </summary>
        public new ISscatLaunchPad LaunchPad
        {
            get { return _launchPad; }
            set { _launchPad = value; }
        }

        /// <summary>
        /// Gets or sets the sscat security manager
        /// </summary>
        public new ISscatSecurityManager SecurityManager
        {
            get { return _securityManager; }
            set { _securityManager = value; }
        }

        /// <summary>
        /// Gets or sets the sscat application launcher
        /// </summary>
        public ISscatApplicationLauncher ApplicationLauncher
        {
            get { return _applicationLauncher; }
            set { _applicationLauncher = value; }
        }

        /// <summary>
        /// Gets or sets the scot log hooks
        /// </summary>
        public Dictionary<string, IScotLogHook> Hooks
        {
            get { return _hooks; }
            set { _hooks = value; }
        }

        /// <summary>
        /// Generate a script
        /// </summary>
        /// <param name="name">script name</param>
        /// <param name="description">script description</param>
        /// <param name="sscoBuild">ssco build</param>
        /// <param name="build">the build</param>
        /// <param name="segmented">whether or not to segment a script</param>
        /// <param name="scriptsOutputDirectory">scripts output directory</param>
        /// <param name="generateLast">whether or not to generate last</param>
        /// <param name="lastScriptsNumber">last scripts number</param>
        /// <param name="defaultMSCard">default ms card</param>
        /// <param name="enableUIValidation">whether UI Validation is enabled</param>
        /// <returns>Returns the script generated</returns>
        public IScript[] Generate(string name, string description, string sscoBuild, string build, bool segmented, string scriptsOutputDirectory, bool generateLast, int lastScriptsNumber, string defaultMSCard, bool enableUIValidation)
        {
            if (!HasErrors)
            {
                SSCATScript[] scripts = null;
                try
                {
                    HasStopped = false;
                    OnParserInitialize(null);
                    OnConfigurationGet(new ConfigFilesEventArgs(Configuration.Files, name));
                    if (Configuration.GeneratorConfiguration.RapName != string.Empty)
                    {
                        OnRequestRapEvents(null);
                    }

                    List<IScriptEvent> events = new List<IScriptEvent>();
                    List<string> missingParser = new List<string>();

                    foreach (IParser parser in Parsers)
                    {
                        if (HasStopped)
                        {
                            OnGenerating(new ProgressEventArgs("Stop Parsing..."));
                            OnStopDispatcher(null);
                            break;
                        }

                        try
                        {
                            parser.Parse += new EventHandler<ProgressEventArgs>(GeneratorParse);
                            if (parser.IsBinary)
                            {
                                events.AddRange(parser.PerformBinaryParse());
                            }
                            else
                            {
                                events.AddRange(parser.PerformParse());
                            }
                        }
                        catch
                        {
                            throw;
                        }
                        finally
                        {
                            parser.Parse -= new EventHandler<ProgressEventArgs>(GeneratorParse);
                        }
                    }

                    if (!HasStopped)
                    {
                        OnGenerating(new ProgressEventArgs("Sorting Events..."));
                        List<IScript> s = SSCATScript.CreateScripts(name, description, scriptsOutputDirectory, sscoBuild, build, defaultMSCard, events, segmented, generateLast, lastScriptsNumber, Configuration.GeneratorConfiguration.UIValidation, Configuration.GeneratorConfiguration.StoreModeKeyboardAutomatedLogin);
                        scripts = new SSCATScript[s.Count];
                        s.CopyTo(scripts);
                        BackupLogFiles(name);
                    }
                    else
                    {
                        OnStopDispatcher(null);
                    }
                }
                catch (Exception ex)
                {
                    Environment.ExitCode = 1;
                    LoggingService.Error("Fatal error occurred! " + ex.Message + "." +
                                         "STACK TRACE: " + ex.StackTrace);
                    throw ex;
                }
                finally
                {
                    DisposeParsers();
                }

                return scripts;
            }
            else
            {
                throw new Exception(Errors.ToString());
            }
        }

        /// <summary>
        /// Plays the script and generates a report
        /// </summary>
        /// <param name="configs">script configuration</param>
        /// <param name="timeout">timeout amount</param>
        /// <param name="warningTimeout">warning timeout</param>
        /// <param name="enableHook">whether or not to enable hooks</param>
        /// <param name="repeat">repeat times</param>
        /// <returns>Returns the report</returns>
        public Report Play(ScriptConfigs configs, int timeout, int warningTimeout, bool enableHook, int repeat)
        {
            HasStopped = false;
            Report report = new Report(repeat);
            foreach (ScriptConfig c in configs.ScriptConfigurations)
            {
                Configuration.PlayerConfiguration.ConfigFiles = c.Files;
                report.AddScript(Play(c.Script, timeout, warningTimeout, enableHook, repeat).Scripts);
            }

            report.FileName = Path.Combine(@"C:\SSCAT\Reports", report.FileName);
            return report;
        }

        /// <summary>
        /// Plays the script and generates a report
        /// </summary>
        /// <param name="scripts">sscat scripts</param>
        /// <param name="timeout">timeout amount</param>
        /// <param name="warningTimeout">warning timeout</param>
        /// <param name="enableHook">whether or not to enable hooks</param>
        /// <param name="repeat">repeat times</param>
        /// <returns>Returns the report</returns>
        public Report Play(List<IScript> scripts, int timeout, int warningTimeout, bool enableHook, int repeat)
        {
            HasStopped = false;
            Report report = new Report(repeat);
            foreach (IScript script in scripts)
            {
                if (HasStopped)
                {
                    break;
                }

                report.AddScript(Play(script, timeout, warningTimeout, enableHook, repeat).Scripts);
            }

            report.FileName = Path.Combine(@"C:\SSCAT\Reports", report.FileName);
            return report;
        }

        /// <summary>
        /// Plays the script and generates a report
        /// </summary>
        /// <param name="script">sscat script</param>
        /// <param name="timeout">timeout amount</param>
        /// <param name="warningTimeout">warning timeout</param>
        /// <param name="enableHook">whether or not to enable hooks</param>
        /// <param name="repeat">repeat times</param>
        /// <returns>Returns the report</returns>
        public Report Play(IScript script, int timeout, int warningTimeout, bool enableHook, int repeat)
        {
            PreScriptStart();
            if (CheckEventMispells(script))
            {
                Report rep = new Report(repeat);
                ReportScript repScript = new ReportScript(script.Name, script.FileName, repeat);
                script.Result = new Result(ResultType.Stopped, "Stopped due to mispelled event(s)");
                LoggingService.Info("Stopped due to mispelled event(s)");
                OnScriptChanged(new ScriptEventArgs(script));
                OnStopDispatcher(null);
                return rep;
            }

            OnLoggerStart(null);
            OnPlaying("-----------------------------------------------------");
            OnPlaying(string.Format("Playing '{0}' with Index {1}; Repetition={2} {3}Load Configuration process starting {3}Checking system's configuration and script's save configuration for differences", script.FileName, script.Index, repeat, Environment.NewLine));

            if (!PsxConnections.ContainsKey("AUTOMATION"))
            {
                OnConnectionAdding(new PsxWrapperEventArgs(DnsHelper.GetLocalIPAddress(), "FastLaneRemoteServer", "AUTOMATION", timeout));
            }

#if NET40
            NextGenUITestClient.Instance.CheckConnection();
            int lastEventIndex = script.Events.Events.Length;
            while (lastEventIndex > 0)
            {
                lastEventIndex--;
                IScriptEventItem lastEvent = script.Events.Events[lastEventIndex].Item as IScriptEventItem;
                if (lastEvent is IUIAutoTestEvent && (lastEvent as IUIAutoTestEvent).EventType.Equals(Constants.UIAutoTestEvent.CONTEXT_CHANGED))
                {
                    IUIAutoTestEvent lastUIEvent = lastEvent as IUIAutoTestEvent;
                    _scriptStartScreen = lastEvent == null ? string.Empty : lastUIEvent.ContextName;
                    break;
                }
            }
#endif

            Report report = new Report(repeat);
            ReportScript reportScript = new ReportScript(script.Name, script.FileName, repeat);
            IPsx psx = PsxConnections["AUTOMATION"] as IPsx;
            _numberOfWarnings = 0;
            IScriptEvent evnt = null;

            script.Result = new Result(ResultType.Running, "Running...", _numberOfWarnings, repeat);

            try
            {
                OnConfigFilesRead(new ScriptEventArgs(script));
                _scriptResourceFolder = Path.GetFileNameWithoutExtension(script.FileName) + DateTime.Now.ToString("_MMddhhmm");

                PlayLoadConfiguration(LoadCashChangerCount(script));

                if (!IsScriptStartLogin(script.Events.Events.OfType<ScriptEvent>().ToList()))
                {
                    PlaySmartExit(timeout, script.Events.Events[0]);
                }

                if (HasStopped)
                {
                    script.Result = new Result(ResultType.Stopped, "Stopped");
                    LoggingService.Info("Stopped");
                    OnScriptChanged(new ScriptEventArgs(script));
                    OnStopDispatcher(null);
                    return report;
                }

                _networkScreenshotLink = _networkScreenshotPath = string.Empty;
                if (Configuration.PlayerConfiguration.CaptureScreenShot)
                {
                    _psxScreen = 0;
#if NET40
                    NextGenUITestClient.Instance.OnUpdateContext += AutoTestEventContextReady;
#else
                    psx.PsxEvent += new PsxEventHandler(PsxEventReceived);
#endif
                }

                long oldTime = (script.Events.Events.Length > 0) ? script.Events.Events[0].Time : 0;
                long processingTime = 0;
                int startWarningTime = 0;
                _previousScriptFailed = false;

                if (Configuration.PlayerConfiguration.EnableLogHook)
                {
                    OnLogHookInitialize(null);
                }

                foreach (IScotLogHook hook in Hooks.Values)
                {
                    hook.WarningEventFound += new EventHandler<WarningEventArgs>(WarningEventChanged);
                }

                SSBSimulatorHealthCheck(script.Name);
                ProduceScaleCheck();

                string ESAStatus = ESAHealthCheck();
                if (!string.IsNullOrEmpty(ESAStatus))
                {
                    OnPlaying(string.Format("Playback stopped. Message : {0} ", ESAStatus));
                    LoggingService.Info(ESAStatus);

                    if (_console)
                    {
                        script.Result = new Result(ResultType.Failed, ESAStatus);
                        ReportPlayback reportPlayback = new ReportPlayback();
                        reportPlayback.UpdateReportPlayback(script);
                    }

                    throw new Exception(ESAStatus);
                }

                    if (script.Events.Events.OfType<ScriptEvent>().ToList().Find(x => (x.Item is IUIAutoTestEvent) && (x.Item as IUIAutoTestEvent).ContextName.Equals("SmmPLAKeyInItemCode")) != null)
                    {
                        OnPlaying("SmmPLAKeyInItemCode detected in script. Enabling Image Security by performing empty transaction.");
                        SimulateScanPay();
                    }
                    else
                    {
                        OnPlaying("SmmPLAKeyInItemCode not detected in script. ");
                    }

                _reportWarningApplicationEvent.Clear();
                _startDurationTimer = Environment.TickCount;

                for (int i = 0; i < script.Events.Events.Length; i++)
                {
                    evnt = script.Events.Events[i];
                    evnt.ScriptIndex = script.Index;
                    evnt.Index = i;
                    evnt.Result = new Result(ResultType.Running, "Running...", _numberOfWarnings);

                    if (HasStopped)
                    {
                        evnt.Result = new Result(ResultType.Stopped, "Stopped");
                        script.Result = new Result(ResultType.Stopped, "Script result will not consider event-level results.", _numberOfWarnings);
                        break;
                    }

                    int now = Environment.TickCount;
                    if (Configuration.PlayerConfiguration.SimulateUserTime)
                    {
                        if (CurrentContext.Contains("Attract") || (CurrentContext.Contains("LaneClosed") && psx.IsClickable("CMButton1StoreLogIn")) ||
                            CurrentContext.Contains("ThankYou") || CurrentContext.Contains("TakeChange"))
                        {
                            oldTime = (i + 1 < script.Events.Events.Length) ? script.Events.Events[i + 1].Time : evnt.Time;
                        }
                        else
                        {
                            oldTime = Sleep(evnt.Time, oldTime, processingTime);
                        }
                    }

                    int timeoutToUse = timeout;
                    int warningTimeoutToUse = warningTimeout;
                    if ((evnt.Item as IScriptEventItem).IsForgivable)
                    {
                        startWarningTime = startWarningTime.Equals(0) ? Environment.TickCount : startWarningTime;
                        warningTimeoutToUse = warningTimeout - (Environment.TickCount - startWarningTime);
                        timeoutToUse = warningTimeoutToUse > 500 ? warningTimeoutToUse : 500;
                    }
                    else
                    {
                        startWarningTime = 0;
                    }

                    if (_config.PlayerConfiguration.UseSmartExit && Configuration.PlayerConfiguration.OverrideLogin)
                    {
                        #region OverrideLoginImplementation
                        int j = LoginEventCount(script.Events.Events, i);
                        if (i < j)
                        {
                            Login(timeoutToUse);
                            if (CurrentContext.Contains("OperatorPasswordStateInvalidPassword"))
                            {
                                throw new InvalidUserLoginException();
                            }

                            for (int cnt = i; cnt < j; cnt++)
                            {
                                evnt = script.Events.Events[cnt];
                                if (cnt > i)
                                {
                                    evnt.ScriptIndex = script.Index;
                                    evnt.Index = cnt;
                                }

                                evnt.Result = new Result(ResultType.Skipped, "Skipped for overridden user login", _numberOfWarnings);
                                OnPlaying(evnt.ToRepresentation());
                                OnScriptEventChanged(new ScriptEventEventArgs(evnt));
                                reportScript.AddEvent(new ReportScriptEvent(evnt));
                            }

                            i = j - 1;
                        }
                        else if (EventState(script.Events.Events[i]).Equals(Constants.EventState.SCANNER_OPERATOR) &&
                                 Upc.IsOperator(_config.PlayerConfiguration.OperatorBarcode) &&
                                 IsValidOperator(script.Events.Events, i))
                        {
                            (evnt.Item as IDeviceEvent).Value = _config.PlayerConfiguration.OperatorBarcode;
                            OnPlaying("Scanning overridden operator barcode " + evnt.Item.ToString());
                            evnt.Result.Notes = "Overridden Operator Barcode";
                            reportScript.AddEvent(Play(evnt, timeoutToUse, enableHook));
                            LoggingService.Info("override login - override operator barcode");
                        }
                        else
                        {
                            reportScript.AddEvent(Play(evnt, timeoutToUse, enableHook));
                        }
                        #endregion
                    }
                    else
                    {
                        reportScript.AddEvent(Play(evnt, timeoutToUse, enableHook));
                    }

                    script.Result = IdentifyScriptResult(evnt.Result, repeat);

                    if (HasStopped)
                    {
                        break;
                    }

                    if ((evnt.Result.IsFailure && _config.PlayerConfiguration.StopOnError) || evnt.Result.IsError)
                    {
                        break;
                    }
                    else if (evnt.Result.IsFailure)
                    {
                        _previousScriptFailed = true;
                        break;
                    }

                    processingTime = Environment.TickCount - now;
                }

                OnLoggerStop(null);
                ThreadHelper.Sleep(200);

                reportScript.DiagnosticPath = string.Empty;
                if (Configuration.PlayerConfiguration.GetDiagsOnError && _previousScriptFailed.Equals(true))
                {
                    reportScript.DiagnosticPath = GenerateDiags();
                }

                reportScript.WarningEvents = GetReportWarningList();
                reportScript.ScreenshotPath = _networkScreenshotPath;
                reportScript.WarningNumber = _numberOfWarnings;
                script.Result.NumberOfWarnings = _numberOfWarnings;
                script.Result.ScreenshotPath = reportScript.ScreenshotPath;
                script.Result.DiagnosticPath = reportScript.DiagnosticPath;
                script.Result.Duration = GetDuration(_startDurationTimer);
#if NET40
                reportScript.Duration = script.Result.Duration.MillisecondsToSeconds();
#endif
                report.AddScript(reportScript);
#if NET40
                OnPlaying(string.Format("Script:{0}, Result:{1}, Duration:{2}", Path.GetFileName(script.FileName), script.Result.Type.ToString(), script.Result.Duration.MillisecondsToSeconds()));
#else
                OnPlaying(string.Format("Script:{0}, Result:{1}, Duration:{2}", Path.GetFileName(script.FileName), script.Result.Type.ToString(), script.Result.Duration));
#endif
                OnPlaying("Done");
                OnScriptChanged(new ScriptEventArgs(script));

                if (script.Result.IsError)
                {
                    ForceKill();
                    Start();
                }
                else if (script.Result.IsFailure && _config.PlayerConfiguration.UseSmartExit)
                {
                    OnEmulating("Error Message : A Failed Script occurred. SSCAT is triggering Smart Exit Feature to go to Welcome Screen to proceed with the succeeding script to run.");
                    GoAllTheWayBack(timeout);
                }
                else if (script.Result.IsFailure && _config.PlayerConfiguration.StopOnError)
                {
                    HasStopped = true;
                    OnStopDispatcher(null);
                }

                if (_console)
                {
                    ReportPlayback reportPlayback = new ReportPlayback();
                    reportPlayback.UpdateReportPlayback(script);
                }
            }
            catch (SscoNotFoundException ex)
            {
                OnPlaying(ex.ToString());
                try
                {
                    if (Configuration.PlayerConfiguration.GetDiagsOnError)
                    {
                        reportScript.DiagnosticPath = GenerateDiags();
                    }

                    reportScript.WarningEvents = GetReportWarningList();
                    reportScript.ScreenshotPath = _networkScreenshotPath;
                    reportScript.WarningNumber = _numberOfWarnings;
                    script.Result.NumberOfWarnings = _numberOfWarnings;
                    script.Result.ScreenshotPath = reportScript.ScreenshotPath;
                    script.Result.DiagnosticPath = reportScript.DiagnosticPath;
                    script.Result.Duration = GetDuration(_startDurationTimer);

                    report.AddScript(reportScript);

                    OnEmulating("Restarting SSCO...");
                    ForceKill();
                    Start();

                    script.Result = new Result(ResultType.Failed, ex.Message, _numberOfWarnings, repeat);
                    OnScriptChanged(new ScriptEventArgs(script));
                }
                catch (Exception e)
                {
                    LoggingService.Error(e.ToString());
                }
            }
            catch (Exception exc)
            {
                LoggingService.Info(exc.ToString());
                try
                {
                    if (Configuration.PlayerConfiguration.GetDiagsOnError)
                    {
                        reportScript.DiagnosticPath = GenerateDiags();
                    }

                    reportScript.WarningEvents = GetReportWarningList();
                    reportScript.ScreenshotPath = _networkScreenshotPath;
                    reportScript.WarningNumber = _numberOfWarnings;
                    script.Result.NumberOfWarnings = _numberOfWarnings;
                    script.Result.ScreenshotPath = reportScript.ScreenshotPath;
                    script.Result.DiagnosticPath = reportScript.DiagnosticPath;
                    script.Result.Duration = GetDuration(_startDurationTimer);

                    report.AddScript(reportScript);

                    OnEmulating("Restarting SSCO...");
                    ForceKill();
                    Start();

                    script.Result = new Result(ResultType.Failed, Regex.Replace(exc.Message, @"\t|\n|\r", "; "), _numberOfWarnings, repeat);
                    OnScriptChanged(new ScriptEventArgs(script));
                }
                catch (Exception e)
                {
                    LoggingService.Error(e.ToString());
                }
            }
            finally
            {
                DisposeHooks();
                Configuration.PlayerConfiguration.Dispose();
#if NET40
                NextGenUITestClient.Instance.OnUpdateContext -= AutoTestEventContextReady;
#else
                psx.PsxEvent -= new PsxEventHandler(PsxEventReceived);
#endif
            }

            return report;
        }

        /// <summary>
        /// Plays the script and generates a report
        /// </summary>
        /// <param name="scriptEvent">sscat script event</param>
        /// <param name="timeout">timeout amount</param>
        /// <param name="enableHook">whether or not to enable hooks</param>
        /// <returns>Returns the report script event</returns>
        public ReportScriptEvent Play(IScriptEvent scriptEvent, int timeout, bool enableHook)
        {
            ReportScriptEvent playbackScriptEvent = null;
            IEventCommand command = null;
            try
            {
                OnPlaying(string.Format("Playing Event {0}: {1}", scriptEvent.Index + 1, scriptEvent.ToRepresentation()));
                command = EventCommandFactory.GetCommandFactory(scriptEvent, this, Hooks, timeout, enableHook).CreateCommand();
                command.Validate();
                if (!command.HasErrors)
                {
                    try
                    {
                        command.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(EventConnectionAdding);
                        command.Running += new EventHandler<NcrEventArgs>(CommandRunning);
                        command.PreRun();
                        command.Run();
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        command.Running -= new EventHandler<NcrEventArgs>(CommandRunning);
                    }

                    scriptEvent.Result = command.Result;
                    if (scriptEvent.Result.Type.Equals(ResultType.Warning))
                    {
                        OnPlaying(string.Format("Warning: Playing Event {0}: {1}", scriptEvent.Index + 1, scriptEvent.ToRepresentation()));
                        if (scriptEvent.Item is IApplicationLauncherEvent)
                        {
                            WarningEvent evt = new WarningEvent(Constants.WarningEvent.APPLICATION_EVENT_FAILURE, scriptEvent.Result.Notes);
                            _reportWarningApplicationEvent.Add(new ReportWarningEvent(evt));
                            OnScriptWarningChanged(new WarningEventArgs(evt));
                        }
                    }
                    else if (scriptEvent.Result.Type.Equals(ResultType.Failed))
                    {
                        scriptEvent.Result.Notes = string.Format("EventDetails = Event{0}:{1} {2} ", scriptEvent.Index + 1, scriptEvent.ToRepresentation(), command.Result.Notes);
                        LoggingService.Error(command.Result.Notes);
                        LoggingService.Error(scriptEvent.Result.Notes);
                    }
                    else
                    {
                        scriptEvent.Result.Notes = string.Format("EventDetails = Event{0}:{1} ", scriptEvent.Index + 1, scriptEvent.ToRepresentation());
                    }

                    scriptEvent.Result.NumberOfWarnings = _numberOfWarnings;
                }
                else
                {
                    scriptEvent.Result = new Result(ResultType.Failed, command.Errors.ToString());
                }

                if (scriptEvent.Result.Type == ResultType.Failed || scriptEvent.Result.Type == ResultType.Exception)
                {
                    Environment.ExitCode = 1;
                }
            }
            catch (Exception ex)
            {
                Environment.ExitCode = 1;
                LoggingService.Warning(ex.ToString());
                scriptEvent.Result = new Result(ResultType.Failed, Regex.Replace(ex.Message, @"\t|\n|\r", "; "));
                OnScriptEventChanged(new ScriptEventEventArgs(scriptEvent));
            }
            finally
            {
                command.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(EventConnectionAdding);
#if NET40
                if (command is UIValidationPropertyChange)
                {
                    playbackScriptEvent = new ReportScriptEvent(scriptEvent, (command as UIValidationPropertyChange).ReportUIVEvents);
                }
                else
                {
#endif
                    playbackScriptEvent = new ReportScriptEvent(scriptEvent);
#if NET40
                }
#endif

                playbackScriptEvent.ScreenshotLink = _networkScreenshotLink;
                scriptEvent.Result.ScreenshotLink = _networkScreenshotLink;
            }

            OnScriptEventChanged(new ScriptEventEventArgs(scriptEvent));
            return playbackScriptEvent;
        }

        /// <summary>
        /// Validates the script name
        /// </summary>
        /// <param name="scriptname">script name</param>
        /// <param name="scriptsOutputDirectory">scripts output directory</param>
        public void ValidateScriptname(ref string scriptname, string scriptsOutputDirectory)
        {
            Validate();
            if (scriptname.EndsWith(".xml", true, CultureInfo.CurrentCulture))
            {
                scriptname = scriptname.Remove(scriptname.Length - 4);
            }

            AddErrorIf("Script name provided is empty or blank! Please provide another script name.", scriptname.Trim().Equals(string.Empty));
            AddErrorIf("Script name already exists.", DirectoryHelper.GetFiles(scriptsOutputDirectory, scriptname + "_*.xml").Length > 0);
            AddErrorIf(string.Format(@"{1}Script Name - {0}.xml {1}You may have used the same script name before and forgot to delete the corresponding {0} configuration folder where SSCAT saves all the important SSCO config files.{1}{1}Troubleshooting Tips : {1}Please delete/rename the folder or choose another script filename.", scriptname, Environment.NewLine), Directory.Exists(scriptsOutputDirectory + "\\" + scriptname));
        }

        /// <summary>
        /// Validates for player configuration
        /// </summary>
        public void ValidateForPlay()
        {
            Validate();
            AddErrorIf("Player configuration should not be null", Configuration.PlayerConfiguration == null);
            ValidateIf(Configuration.PlayerConfiguration, Configuration.PlayerConfiguration != null);
        }

        /// <summary>
        /// Prior to starting the script
        /// </summary>
        public void PreScriptStart()
        {
            if (_console && !HasStarted && !_previousScriptFailed)
            {
                Start();
            }
            else if (!HasStarted)
            {
                throw new SscoNotFoundException();
            }
        }

        /// <summary>
        /// Identifies the script result
        /// </summary>
        /// <param name="eventResult">event result</param>
        /// <param name="repeat">repeat times</param>
        /// <returns>Returns the result</returns>
        public Result IdentifyScriptResult(Result eventResult, int repeat)
        {
            Result scriptResult = eventResult;

            switch (eventResult.Type)
            {
                case ResultType.Warning:
                    scriptResult.Type = ResultType.Passed;
                    scriptResult.Notes = "Result for this script contains warning(s).";
                    break;
                case ResultType.Skipped:
                    scriptResult.Type = ResultType.Passed;
                    scriptResult.Notes = "Some system responses were not found and was intentionally skipped.";
                    break;
                case ResultType.Passed:
                    scriptResult.Notes = "Ok";
                    break;
            }

            if (HasStopped)
            {
                scriptResult.Type = ResultType.Stopped;
                scriptResult.Notes = "Result for this script will not consider event-level results.";
            }

            scriptResult.NumberOfWarnings = _numberOfWarnings;
            scriptResult.RepetitionIndex = repeat;

            return scriptResult;
        }

        /// <summary>
        /// Capture screen shot
        /// </summary>
        /// <param name="eventName">event name</param>
        /// <param name="contextName">context name</param>
        public void CaptureScreen(string eventName, string contextName)
        {
            _screenshotPath = Configuration.PlayerConfiguration.ScreenshotPath + @"\" + _scriptResourceFolder;

            _psxScreen++;
            string imageFileName = _psxScreen + DateTime.Now.ToString("_MMdd-hhmm_") + contextName + ".png";
            string imageFilePath = _screenshotPath + @"\" + imageFileName;
            _networkScreenshotPath = string.Format(@"\\{0}\Screenshots\{1}", DnsHelper.GetHostName(), _scriptResourceFolder);
            _networkScreenshotLink = string.Format(@"\\{0}\Screenshots\{1}\{2}", DnsHelper.GetHostName(), _scriptResourceFolder, imageFileName);

            DirectoryHelper.CreateDirectory(_screenshotPath);

            if (_config.PlayerConfiguration.LockedScreenshot)
            {
                ImageHelper.Save(CaptureImageWindow(), imageFilePath, 30);
            }
            else
            {
                ImageHelper.Save(CaptureScreen(), imageFilePath, 30);
            }

            LoggingService.Info(string.Format("Image is now in {0}", imageFilePath));
        }

        /// <summary>
        /// Tears the emulators
        /// </summary>
        public void Tear()
        {
            foreach (IEmulator e in Emulators.Values)
            {
                if (e is ITear)
                {
                    (e as ITear).Tear();
                }
            }
        }

        /// <summary>
        /// Attempts login for duration of the timeout
        /// </summary>
        /// <param name="timeout">the timeout</param>
        public void Login(int timeout)
        {
            PlayerConfiguration p = Configuration.PlayerConfiguration;
            int start = Environment.TickCount;
            Login(p.LoginId, p.Password, timeout);
            while ((CurrentContext.Contains("EnterID") || CurrentContext.Contains("EnterAlphaNumericPassword")) &&
                   ((Environment.TickCount - start) < timeout))
            {
                ThreadHelper.Sleep(100);
            }
        }

        /// <summary>
        /// Alphanumeric password
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void AlphaNumericPassword(int timeout)
        {
            PlayerConfiguration p = Configuration.PlayerConfiguration;
            AlphaNumericPassword(p.LoginId, p.Password, timeout);
        }

        /// <summary>
        /// Clicks the control
        /// </summary>
        /// <param name="control">name of the control</param>
        /// <param name="param">the parameters</param>
        /// <param name="timeout">timeout amount</param>
        /// <param name="throwException">whether or not to throw exceptions</param>
        public void Click(string control, string param, int timeout, bool throwException)
        {
            IPsx psx = CurrentPsx;
            string type = psx.GetControlProperty(control, "ControlType").ToString();
            Rectangle rect;
            if (type.Equals("ButtonList"))
            {
                rect = GetButtonListPosition(control, param);
                OnEmulating(string.Format("Clicking {0} param = {1}", control, param));
            }
            else if (type.Equals("Grid"))
            {
                rect = GetGridPosition(control, param);
                OnEmulating(string.Format("Clicking {0} param = {1}", control, param));
            }
            else if (type.Equals("Receipt"))
            {
                rect = GetReceiptPosition(control, param);
                OnEmulating(string.Format("Clicking {0} param = {1}", control, param));
            }
            else
            {
                rect = GetElse(control, timeout, throwException);
            }

            ClickAt(rect.X + (rect.Width / 2), rect.Y + (rect.Height / 2));
        }

        /// <summary>
        /// Checks if the control is visible
        /// </summary>
        /// <param name="control">name of the control</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns true if visible, false otherwise</returns>
        public bool IsControlVisible(string control, int timeout)
        {
            IPsx psx = CurrentPsx;
            int now = Environment.TickCount;
            bool hasTimedOut = false;
            int i = 0;
            while ((!psx.IsControlVisible(control)) && !hasTimedOut)
            {
                if (i++ % (42 * 3) == 0)
                {
                    OnEmulating("Checking if the control is visible...");
                }

                hasTimedOut = (Environment.TickCount - now) > timeout;
                if (!hasTimedOut && !HasStopped)
                {
                    ThreadHelper.Sleep(20);
                }
                else if (HasStopped)
                {
                    break;
                }
            }

            if (hasTimedOut)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if given context is equal to current context
        /// </summary>
        /// <param name="context">name of the context</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns true if context matches, false otherwise</returns>
        public bool ContextEquals(string context, int timeout)
        {
            IPsx psx = CurrentPsx;
            int now = Environment.TickCount;
            bool hasTimedOut = false;
            int i = 0;
            while ((!psx.ContextEquals(context)) && !hasTimedOut)
            {
                if (i++ % (42 * 3) == 0)
                {
                    OnEmulating("Checking Context...");
                }

                hasTimedOut = (Environment.TickCount - now) > timeout;
                if (!hasTimedOut && !HasStopped)
                {
                    ThreadHelper.Sleep(20);
                }
                else if (HasStopped)
                {
                    break;
                }
            }

            if (hasTimedOut)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Loads player configuration
        /// </summary>
        public void LoadConfiguration()
        {
            OnConfigurationLoad(new ConfigFilesEventArgs(Configuration.PlayerConfiguration.ConfigFiles));
        }

#if NET40
        /// <summary>
        /// Clicks the NGUI Control
        /// </summary>
        /// <param name="control">name of the control</param>
        /// <param name="context">name of the context</param>
        /// <param name="param">name of the param</param>
        public void NXTUIClick(string control, string context, string param)
        {
            NextGenUITestClient.Instance.SmartExitClickButton(control, context, string.Empty);
        }
#endif

        /// <summary>
        /// Stops the PSX, parsers, and hooks
        /// </summary>
        public override void Stop()
        {
            base.Stop();
            OnStopping(null);

            StopPsx();
            StopParsers();
            StopHooks();
        }

        /// <summary>
        /// Validates the generator configuration
        /// </summary>
        public virtual void ValidateForGenerate()
        {
            Validate();
            AddErrorIf("Script Generator Configuration should not be null", Configuration.GeneratorConfiguration == null);
            ValidateIf(Configuration.GeneratorConfiguration, Configuration.GeneratorConfiguration != null);
            AddErrorIf("Parsers should not be null", Parsers == null);
        }

        /// <summary>
        /// Event for stopping the logger
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
        /// Event for starting the logger
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
        /// Event for requesting RAP events
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnRequestRapEvents(EventArgs e)
        {
            if (RequestRapEvents != null)
            {
                RequestRapEvents(this, e);
            }
        }

        /// <summary>
        /// Event for dispatching a stop
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStopDispatcher(EventArgs e)
        {
            if (StopDispatch != null)
            {
                StopDispatch(this, e);
            }
        }

        /// <summary>
        /// Event for getting configuration
        /// </summary>
        /// <param name="e">configuration files event arguments</param>
        protected virtual void OnConfigurationGet(ConfigFilesEventArgs e)
        {
            if (ConfigurationGet != null)
            {
                ConfigurationGet(this, e);
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
        /// Event for loading configuration
        /// </summary>
        /// <param name="e">configuration files event arguments</param>
        protected virtual void OnConfigurationLoad(ConfigFilesEventArgs e)
        {
            if (ConfigurationLoad != null)
            {
                ConfigurationLoad(this, e);
            }
        }

        /// <summary>
        /// Event for generating
        /// </summary>
        /// <param name="e">progress event arguments</param>
        protected virtual void OnGenerating(ProgressEventArgs e)
        {
            if (Generating != null)
            {
                Generating(this, e);
            }
        }

        /// <summary>
        /// Event for parsing
        /// </summary>
        /// <param name="e">progress event arguments</param>
        protected virtual void OnParse(ProgressEventArgs e)
        {
            if (Parse != null)
            {
                Parse(this, e);
            }
        }

        /// <summary>
        /// Event for initializing a log hook
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
        /// Plays with a given message
        /// </summary>
        /// <param name="message">message for on play</param>
        protected virtual void OnPlaying(string message)
        {
            OnPlaying(new ProgressEventArgs(message));
        }

        /// <summary>
        /// Event for playing script
        /// </summary>
        /// <param name="e">progress event arguments</param>
        protected virtual void OnPlaying(ProgressEventArgs e)
        {
            if (Playing != null)
            {
                Playing(this, e);
            }
        }

        /// <summary>
        /// Event for script changed
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnScriptChanged(ScriptEventArgs e)
        {
            if (ScriptChanged != null)
            {
                ScriptChanged(this, e);
            }
        }

        /// <summary>
        /// Event for script event changed
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnScriptEventChanged(ScriptEventEventArgs e)
        {
            if (ScriptEventChanged != null)
            {
                ScriptEventChanged(this, e);
            }
        }

        /// <summary>
        /// Event for initializing the parser
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
        /// Event for reading configuration files
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnConfigFilesRead(ScriptEventArgs e)
        {
            if (ConfigFilesRead != null)
            {
                ConfigFilesRead(this, e);
            }
        }

        /// <summary>
        /// Event for script warning changed
        /// </summary>
        /// <param name="e">warning event arguments</param>
        protected virtual void OnScriptWarningChanged(WarningEventArgs e)
        {
            if (ScriptWarningChanged != null)
            {
                ScriptWarningChanged(this, e);
            }
        }

        /// <summary>
        /// Warning Event Changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">warning event arguments</param>
        private void WarningEventChanged(object sender, WarningEventArgs e)
        {
            OnScriptWarningChanged(e);
        }

        /// <summary>
        /// Play Smart Exit
        /// </summary>
        /// <param name="timeout">timeout of the script</param>
        /// <param name="firstEvent">first Event</param>
        private void PlaySmartExit(int timeout, ScriptEvent firstEvent)
        {
            // TC 1.1
            // TC 3.1, 3.2, 4.2
#if NET40
            //// if (_config.PlayerConfiguration.UseSmartExit && !firstEvent.Type.Equals("ApplicationLauncher") && !firstEvent.Type.Equals("Wldb"))
            if (!firstEvent.Type.Equals("ApplicationLauncher") && !firstEvent.Type.Equals("Wldb"))
            {
#else
                if (_config.PlayerConfiguration.UseSmartExit && !firstEvent.Type.Equals("ApplicationLauncher")
                    && !firstEvent.Type.Equals("Wldb") && !CurrentContext.Contains((firstEvent.Item as IPsxEvent).Context))
                {
#endif
                LoggingService.Info("[SmartExit] Going to start context before playing the script.");
                GoAllTheWayBack(timeout);
#if NET40
                string context = NextGenUITestClient.Instance.GetCurrentContext();
                bool isStartScreen = context.Equals(string.Empty) || context.Contains("Startup") || context.Contains("Disconnected") ? CurrentContext.Contains("Attract") : context.Equals(_scriptStartScreen);

                if (!isStartScreen)
                {
                    OnEmulating(string.Format("[SmartExit] Current SSCO screen '{0}' is not the same with the start context: {1}", context, _scriptStartScreen));
#else
                    if (!CurrentContext.Contains("Attract"))
                    {
                        OnEmulating(string.Format("Current SSCO screen '{0}' is not the same with the start context: {1}", CurrentContext, _config.PlayerConfiguration.StartContext));
#endif
                    OnEmulating("[SmartExit] Restarting SSCO...");
                    ForceKill();
                    Start();
                }
#if !NET40
                    if (!CurrentContext.Contains((firstEvent.Item as IPsxEvent).Context))
                    {
                        OnEmulating("Going to laneclosed context before playing the script.");
                        if (!GoToLaneClosed(timeout))
                        {
                            ForceKill();
                            Start();
                            throw new InvalidUserLoginException();
                        }
                    }
#endif
            }
        }

        /// <summary>
        /// Plays OnConfigurationLoad based on LoadConfiguration Settings
        /// </summary>
        /// <param name="loadCashChangerCount">current script</param>
        private void PlayLoadConfiguration(bool loadCashChangerCount)
        {
            bool forceStop = _previousScriptFailed && !_config.PlayerConfiguration.UseSmartExit;

            if (Configuration.PlayerConfiguration.LoadConfiguration)
            {
                // TC 2.1, 2.2, 4.1, 4.2
                LoggingService.Info("Checking/loading of scot config files.");
                OnConfigurationLoad(new ConfigFilesEventArgs(Configuration.PlayerConfiguration.ConfigFiles, forceStop));
            }
            else if (forceStop && !Configuration.PlayerConfiguration.LoadConfiguration)
            {
                // TC 1.2
                LoggingService.Info("Previous script was failed and SSCAT is not using smart exit. Stopping and starting lane.");
                ForceKill();
                Start();
            }
            else if (loadCashChangerCount)
            {
                // TC 1.3, 1.4, 2.3, 2.4, 3.3, 3.4, 4.3, 4.4
                LoggingService.Info("Loading cash changer counts.");
                ForceKill();
                SetCurrentCoinAndBillCount();
                if (Configuration.PlayerConfiguration.LoadConfiguration)
                {
                    LoggingService.Info("Checking scot config files after loading cash changer counts.");
                    OnConfigurationLoad(new ConfigFilesEventArgs(Configuration.PlayerConfiguration.ConfigFiles, forceStop));
                }

                if (!HasStarted)
                {
                    LoggingService.Info("Starting lane after loading cash changer counts.");
                    Start();
                }
            }
        }

        /// <summary>
        /// Get Report Warning List
        /// </summary>
        /// <returns>an array of ReportWarningEvent</returns>
        private ReportWarningEvent[] GetReportWarningList()
        {
            List<ReportWarningEvent> reportWarningEvents = new List<ReportWarningEvent>();
            try
            {
                foreach (IScotLogHook hook in Hooks.Values)
                {
                    foreach (IWarningEvent evt in hook.WarningEvents)
                    {
                        reportWarningEvents.Add(new ReportWarningEvent(evt));
                        ++_numberOfWarnings;
                    }

                    hook.ClearWarningEvents();
                }

                if (_reportWarningApplicationEvent.Count > 0)
                {
                    reportWarningEvents.AddRange(_reportWarningApplicationEvent);
                }

                if (reportWarningEvents.Count > 0)
                {
                    OnPlaying("List of WarningEvents");
                    foreach (ReportWarningEvent evt in reportWarningEvents)
                    {
                        OnPlaying(evt.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                OnPlaying(ex.ToString());
            }

            return reportWarningEvents.ToArray();
        }

        /// <summary>
        /// Get Warning List
        /// </summary>
        /// <returns>an array of WarningEvent</returns>
        private SSCATScriptEvent[] GetWarningList()
        {
            List<SSCATScriptEvent> warningEvents = new List<SSCATScriptEvent>();
            try
            {
                foreach (IScotLogHook hook in Hooks.Values)
                {
                    foreach (IWarningEvent evt in hook.WarningEvents)
                    {
                        warningEvents.Add(new SSCATScriptEvent(evt));
                    }
                }
            }
            catch (Exception ex)
            {
                OnPlaying(ex.ToString());
            }

            return warningEvents.ToArray();
        }

        /// <summary>
        /// Checks whether or not to load the cash changer count
        /// </summary>
        /// <param name="script">current script</param>
        /// <returns>Returns true if script is cash management script with a count that differs, false otherwise</returns>
        private bool LoadCashChangerCount(IScript script)
        {
            return IsCashManagementScript(script) && CashChangerCountDiffers();
        }

        /// <summary>
        /// Checks if script is for cash management
        /// </summary>
        /// <param name="script">the script</param>
        /// <returns>Returns true if for cash management, false otherwise</returns>
        private bool IsCashManagementScript(IScript script)
        {
            IScriptEvent evnt = null;
            bool isCashManagementScript = false;
            bool foundCMCashCount = false;

            for (int i = 0; i < script.Events.Events.Length; i++)
            {
                evnt = script.Events.Events[i];
                if (!foundCMCashCount && evnt.Type == "Device" && evnt.Item.ToString().Contains("CMCashCount"))
                {
                    IDeviceEvent item = evnt.Item as IDeviceEvent;
                    _scriptCashCount = item.Value;
                    foundCMCashCount = true;
                }

                if (evnt.Type == "Psx" && evnt.Item.ToString().Contains("XMCashStatus"))
                {
                    isCashManagementScript = true;
                    break;
                }
            }

            return isCashManagementScript;
        }

        /// <summary>
        /// Checks if the cash changer count differs
        /// </summary>
        /// <returns>Returns true if count differs, false otherwise</returns>
        private bool CashChangerCountDiffers()
        {
            return !CurrentCoinAndBillCount.Equals(_scriptCashCount);
        }

        /// <summary>
        /// Gets the elapsed milliseconds from the starting TickCount.
        /// </summary>
        /// <param name="startTickCount">Starting TickCount in milliseconds.</param>
        /// <returns>Milliseconds elapsed.</returns>
        private int GetDuration(int startTickCount)
        {
            int duration = Environment.TickCount - startTickCount;

            if (duration < 0)
            {
                throw new ArgumentException("Start tickcount must be less than current tickcount.");
            }

            return duration;
        }

        /// <summary>
        /// Generates diagnostic files
        /// </summary>
        /// <returns>Returns the diagnostic location</returns>
        private string GenerateDiags()
        {
            string diagPath = string.Empty;
            DiagnosticsUtility gd = null;
            try
            {
                gd = new DiagnosticsUtility();
                gd.DiagnosticsInProcess += new EventHandler<SscatEventArgs>(GenerateDiagnosticsDoingSomething);
                diagPath = string.Format(@"{0}\{1}", Configuration.PlayerConfiguration.DiagnosticPath, _scriptResourceFolder);
                string s;
                if (Configuration.PlayerConfiguration.CaptureScreenShot)
                {
                    s = gd.GetDiag(diagPath, _screenshotPath, Configuration.PlayerConfiguration.DiagTempPath);
                }
                else
                {
                    s = gd.GetDiag(diagPath, Configuration.PlayerConfiguration.DiagTempPath);
                }

                OnPlaying(string.Format("Diags can be found in {0}\\{1}", diagPath, Path.GetFileName(s)));
            }
            catch
            {
                throw;
            }
            finally
            {
                gd.DiagnosticsInProcess -= new EventHandler<SscatEventArgs>(GenerateDiagnosticsDoingSomething);
            }

            return string.Format(@"\\{0}\Diags\{1}", DnsHelper.GetHostName(), _scriptResourceFolder);
        }

        /// <summary>
        /// Adds commands
        /// </summary>
        /// <param name="commands">lane commands</param>
        private void AddCommands(IDictionary<string, LaneCommand> commands)
        {
            foreach (string key in commands.Keys)
            {
                AddCommand(key, commands[key]);
            }
        }

        /// <summary>
        /// Adds a command
        /// </summary>
        /// <param name="context">lane context</param>
        /// <param name="command">lane command</param>
        private void AddCommand(string context, LaneCommand command)
        {
            command.Lane = this;
#if NET40
            _nxtuiBackCommands.Add(context, command);
#else
            _backCommands.Add(context, command);
#endif
        }

        /// <summary>
        /// Backup log files
        /// </summary>
        /// <param name="name">directory name</param>
        private void BackupLogFiles(string name)
        {
            string date = DateTimeUtility.Now("yyyy-MM-dd hh.mm.ss.fff");
            foreach (LaneParser p in Configuration.Parsers.Parsers)
            {
                if (p.HasFile)
                {
                    if (p.File.Equals(@"C:\scot\logs\psx_ScotAppU.log"))
                    {
                        p.File = p.GetFileName();
                    }

                    string sourceFile = p.File;
                    string log = Path.GetFileName(sourceFile);
                    if (FileHelper.Exists(sourceFile))
                    {
                        string dirName = string.Format("{0} - {1}", date, name);
                        string dir = Path.Combine(ApplicationUtility.LogsDirectory, dirName);
                        string destinationFile = Path.Combine(dir, log);
                        FileHelper.Copy(sourceFile, destinationFile);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the current coin and bill count
        /// </summary>
        private void SetCurrentCoinAndBillCount()
        {
            string dispenserCounts = _scriptCashCount.Replace("-", string.Empty);
            OnEmulating(string.Format("Setting XM Cash Count Dispenser Counts: {0}", dispenserCounts));
            string cashCountKey = string.Format(@"HKEY_LOCAL_MACHINE\{0}", RegistryAddress.CashCountKey);
            RegistryHelper.SetStringValue(cashCountKey, "DispenserCounts", dispenserCounts);

            string[] splitScriptCashCount = dispenserCounts.Split(';');
            string coinCount = splitScriptCashCount[0];
            string billCount = splitScriptCashCount[1];

            SetEmulatorCount("Coin", coinCount);
            SetEmulatorCount("Bill", billCount);
        }

        /// <summary>
        /// Login event count
        /// </summary>
        /// <param name="events">Script events</param>
        /// <param name="eventIndex">event index</param>
        /// <returns>Returns the event index based on the event state</returns>
        private int LoginEventCount(ScriptEvent[] events, int eventIndex)
        {
            if (!EventState(events[eventIndex]).Equals(Constants.EventState.DISPLAYING_LOGIN))
            {
                return eventIndex;
            }

            int j = eventIndex;
            while (j < events.Length)
            {
                switch (EventState(events[j]))
                {
                    case Constants.EventState.DISPLAYING_LOGIN:
                    case Constants.EventState.CLICKING_ENTER:
                    case Constants.EventState.CLICKING_CREDENTIALS:
                    case Constants.EventState.CLICKING_GO_BACK:
                    case Constants.EventState.DEVICE_EVENT_FORGIVABLE:
                    case Constants.EventState.LAUNCH_PAD_EVENT:
                        j++;
                        break;
                    case Constants.EventState.DISPLAYING_SCREEN_BEFORE_LOGIN:
                    case Constants.EventState.SCANNER_OPERATOR:
                    case Constants.EventState.NOT_PSX:
                    case Constants.EventState.INVALID_LOGIN:
                        return eventIndex;
                    case Constants.EventState.NOT_LOGIN_EVENT:
                        return j;
                }
            }

            return eventIndex;
        }

        /// <summary>
        /// Checks if event is a valid operator
        /// </summary>
        /// <param name="events">Script events</param>
        /// <param name="eventIndex">event index</param>
        /// <returns>Returns true if not a login event, false otherwise</returns>
        private bool IsValidOperator(ScriptEvent[] events, int eventIndex)
        {
            int j = eventIndex;
            while (j < events.Length)
            {
                switch (EventState(events[j]))
                {
                    case Constants.EventState.DISPLAYING_LOGIN:
                    case Constants.EventState.CLICKING_ENTER:
                    case Constants.EventState.CLICKING_CREDENTIALS:
                    case Constants.EventState.CLICKING_GO_BACK:
                    case Constants.EventState.DEVICE_EVENT_FORGIVABLE:
                    case Constants.EventState.SCANNER_OPERATOR:
                    case Constants.EventState.LAUNCH_PAD_EVENT:
                        return true;
                    ////j++;
                    //// break;
                    case Constants.EventState.DISPLAYING_SCREEN_BEFORE_LOGIN:
                    case Constants.EventState.NOT_PSX:
                    case Constants.EventState.INVALID_LOGIN:
                        return false;
                    case Constants.EventState.NOT_LOGIN_EVENT:
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Event state
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        /// <returns>Returns the current event state</returns>
        private string EventState(ScriptEvent scriptEvent)
        {
            switch (scriptEvent.Type)
            {
                case "Device":
                    IDeviceEvent d = scriptEvent.Item as IDeviceEvent;
                    if (d.IsForgivable)
                    {
                        return Constants.EventState.DEVICE_EVENT_FORGIVABLE;
                    }
                    else if (d.Id.Equals("Scanner") && Upc.IsOperator(d.Value))
                    {
                        return Constants.EventState.SCANNER_OPERATOR;
                    }

                    return Constants.EventState.NOT_PSX;
                case "LaunchPadPsx":
                    return Constants.EventState.LAUNCH_PAD_EVENT;
                case "Psx":
                    IPsxEvent e = scriptEvent.Item as IPsxEvent;
                    if (e.Context.Contains("EnterID") || e.Context.Contains("AlphaNumericPassword"))
                    {
                        if (e.Event.Contains("ChangeContext"))
                        {
                            return Constants.EventState.DISPLAYING_LOGIN;
                        }
                        else if (e.Event.Contains("Click"))
                        {
                            if (e.Control.Contains("ButtonGoBack"))
                            {
                                return Constants.EventState.CLICKING_GO_BACK;
                            }
                            else if (e.Control.Contains("NumericP4"))
                            {
                                return Constants.EventState.CLICKING_ENTER;
                            }

                            return Constants.EventState.CLICKING_CREDENTIALS;
                        }
                    }
                    else if (e.Context.Equals("OperatorPasswordStateInvalidPassword"))
                    {
                        return Constants.EventState.INVALID_LOGIN;
                    }
                    else if (e.Context.Contains("ContextHelp") || e.Context.Contains("WaitForApproval"))
                    {
                        return Constants.EventState.DISPLAYING_SCREEN_BEFORE_LOGIN;
                    }

                    return Constants.EventState.NOT_LOGIN_EVENT;
            }

            if (scriptEvent.Item is DeviceEvent)
            {
                IDeviceEvent d = scriptEvent.Item as IDeviceEvent;
                if (d.Id.Equals("Scanner") && Upc.IsOperator(d.Value))
                {
                    LoggingService.Info(string.Format("EventState - State is Device and scanner operator, Index :{0}", scriptEvent.Index));
                    return Constants.EventState.SCANNER_OPERATOR;
                }

                LoggingService.Info(string.Format("EventState - State is Device but not scanner operator, Index :{0}", scriptEvent.Index));
            }

            LoggingService.Info(string.Format("EventState - Index :{0}", scriptEvent.Index));

            return Constants.EventState.NOT_PSX;
        }

        /// <summary>
        /// Event for generating diagnostics
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">sscat event arguments</param>
        private void GenerateDiagnosticsDoingSomething(object sender, SscatEventArgs e)
        {
            OnPlaying(e.Message);
        }

        /// <summary>
        /// Event for received psx event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">psx event arguments</param>
        private void PsxEventReceived(object sender, PsxEventArgs e)
        {
            LoggingService.Info(string.Format("PSX Change Context to {0} {0}", e.ContextName));
            CaptureScreen(e.EventName, e.ContextName);
        }

#if NET40
        /// <summary>
        /// Event for received psx event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">psx event arguments</param>
        private void AutoTestEventContextReady(object sender, EventArgs e)
        {
            UpdateContextEventArgs args = e as UpdateContextEventArgs;

            if (args == null)
            {
                return;
            }

            ThreadHelper.Sleep(_config.PlayerConfiguration.ScreenCaptureDelay);

            int captureRepitition = _config.PlayerConfiguration.MultipleShots ? _config.PlayerConfiguration.ScreenCaptureShots : 1;

            for (int i = 0; i < captureRepitition; i++)
            {
                CaptureScreen(string.Empty, string.Format("{0}({1})", args.ContextName, i));
                ThreadHelper.Sleep(_config.PlayerConfiguration.ScreenCaptureIntervalDelay);
            }
        }
#endif

        /// <summary>
        /// Sleep for calculated sleep time between old time and current time
        /// </summary>
        /// <param name="newTime">new time</param>
        /// <param name="oldTime">old time</param>
        /// <param name="processingTime">processing time</param>
        /// <returns>Returns the new time</returns>
        private long Sleep(long newTime, long oldTime, long processingTime)
        {
            long sleepTime = newTime - oldTime - processingTime;
            sleepTime = sleepTime < 0 ? 0 : sleepTime;

            OnPlaying(string.Format("Sleeping for {0}ms", sleepTime));

            int now = Environment.TickCount;
            while ((Environment.TickCount - now) < sleepTime)
            {
                if (HasStopped)
                {
                    break;
                }

                OnPlaying("Sleeping...");
                ThreadHelper.Sleep(500);
            }

            return newTime;
        }

        #region RectangleMethods
        /// <summary>
        /// Get rectangle for controls
        /// </summary>
        /// <param name="control">control name</param>
        /// <param name="timeout">timeout amount</param>
        /// <param name="throwException">whether or not to throw the exception</param>
        /// <returns>Returns the rectangle of the control</returns>
        private Rectangle GetElse(string control, int timeout, bool throwException)
        {
            IPsx psx = CurrentPsx;
            if (!IsClickable(control, timeout) && throwException)
            {
                throw new PsxControlNotClickableException(control);
            }

            string[] position = ((string)psx.GetControlProperty(control, "Position")).Split(new char[] { ',' });
            return RectangleHelper.GetRectangle(position);
        }

        /// <summary>
        /// Gets the button list position
        /// </summary>
        /// <param name="control">name of the control</param>
        /// <param name="param">the parameters</param>
        /// <returns>Returns the rectangle of the button list</returns>
        private Rectangle GetButtonListPosition(string control, string param)
        {
            try
            {
                IPsx psx = CurrentPsx;
                object[] buttonList = (object[])psx.SendControlCommand(control, "GetButtonDataList");
                for (int i = 0; i < buttonList.Length; i++)
                {
                    object button = buttonList[i];
                    if (button.ToString().Trim().ToLower().Equals(param.Trim().ToLower()))
                    {
                        string[] position = ((string)psx.SendControlCommand(control, "GetButtonPosition", 1, new object[] { i })).Split(',');
                        return RectangleHelper.GetRectangle(position);
                    }
                }

                throw new PsxControlNotFoundException(param);
            }
            catch
            {
                throw new PsxControlNotFoundException(param);
            }
        }

        /// <summary>
        /// Gets the grid position
        /// </summary>
        /// <param name="control">name of the control</param>
        /// <param name="param">the parameters</param>
        /// <returns>Returns the rectangle of the grid</returns>
        private Rectangle GetGridPosition(string control, string param)
        {
            try
            {
                IPsx psx = CurrentPsx;
                for (int i = 0; i < 500; i++)
                {
                    string icontrol = control + '[' + i.ToString() + ']';
                    string sdata = psx.GetControlProperty(icontrol, "Data").ToString().Split('@')[0];
                    string sdata1 = psx.GetControlProperty(icontrol, "Data").ToString().Split('@')[2];
                    if (sdata.Equals(param.Split('@')[0]) && sdata1.Equals(param.Split('@')[2]))
                    {
                        string[] position = ((string)psx.GetControlProperty(icontrol, "Position")).Split(new char[] { ',' });
                        return RectangleHelper.GetRectangle(position);
                    }

                    ThreadHelper.Sleep(50);
                }

                throw new PsxControlNotFoundException(param.Split('@')[0]);
            }
            catch
            {
                throw new PsxControlNotFoundException(param.Split('@')[0]);
            }
        }

        /// <summary>
        /// Gets the receipt position
        /// </summary>
        /// <param name="control">control name</param>
        /// <param name="param">the parameters</param>
        /// <returns>Returns the rectangle of the receipt</returns>
        private Rectangle GetReceiptPosition(string control, string param)
        {
            IPsx psx = CurrentPsx;
            string[] position = ((string)psx.SendControlCommand(control, "GetItemPosition", 1, new object[] { param })).Split(',');
            return RectangleHelper.GetRectangle(position);
        }
        #endregion

        #region SmartExit
        /// <summary>
        /// Click the alphanumeric password
        /// </summary>
        /// <param name="alphanum">alphanumeric characters</param>
        /// <param name="alphaNumP1">psx control 1</param>
        /// <param name="alphaNumP4">psx control 4</param>
        /// <param name="alphaNumP2">psx control 2</param>
        /// <param name="timeout">timeout amount</param>
        private void ClickAlphaNumPassword(char[] alphanum, PsxControl alphaNumP1, PsxControl alphaNumP4, PsxControl alphaNumP2, int timeout)
        {
            foreach (char i in alphanum)
            {
                string s = i.ToString().ToUpper();
                switch (s)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "0":
                    case "Q":
                    case "W":
                    case "E":
                    case "R":
                    case "T":
                    case "Y":
                    case "U":
                    case "I":
                    case "O":
                    case "P":
                        PsxButton p1 = alphaNumP1.List.GetButton(s);
                        Click("AlphaNumP1", p1.Param, timeout, false);
                        break;
                    case "A":
                    case "S":
                    case "D":
                    case "F":
                    case "G":
                    case "H":
                    case "J":
                    case "K":
                    case "L":
                        PsxButton p4 = alphaNumP4.List.GetButton(s);
                        Click("AlphaNumP4", p4.Param, timeout, false);
                        break;
                    case "Z":
                    case "X":
                    case "C":
                    case "V":
                    case "B":
                    case "N":
                    case "M":
                        PsxButton p2 = alphaNumP2.List.GetButton(s);
                        Click("AlphaNumP2", p2.Param, timeout, false);
                        break;
                }

                ThreadHelper.Sleep(200);
            }
        }

        /// <summary>
        /// Clicks the alphanumeric enter key
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        private void ClickAlphaNumericEnter(int timeout)
        {
            Click("AlphaNumKey3", string.Empty, timeout, false);
            ThreadHelper.Sleep(200);
        }

        /// <summary>
        /// Click the number
        /// </summary>
        /// <param name="num">number character</param>
        /// <param name="psxControl">psx control</param>
        /// <param name="timeout">timeout amount</param>
        private void ClickNum(char[] num, PsxControl psxControl, int timeout)
        {
            foreach (char i in num)
            {
                PsxButton b = psxControl.List.GetButton(i.ToString());
                if (b != null)
                {
                    Click("NumericP1", b.Param, timeout, false);
                }
                else
                {
                    Click("NumericP2", string.Empty, timeout, false);
                }

                ThreadHelper.Sleep(200);
            }
        }

        /// <summary>
        /// Click enter
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        private void ClickEnter(int timeout)
        {
            Click("NumericP4", string.Empty, timeout, false);
            ThreadHelper.Sleep(200);
        }

        /// <summary>
        /// Attempts the login for the duration of the timeout
        /// </summary>
        /// <param name="id">login identifier</param>
        /// <param name="password">login password</param>
        /// <param name="timeout">timeout amount</param>
        private void Login(string id, string password, int timeout)
        {
            PsxControl psxControl = _config.Display.Controls.GetControl("NumericP1");

            ClickNum(id.ToCharArray(), psxControl, timeout);
            ClickEnter(timeout);

            if (!CurrentPsx.GetContext(1).Equals("EnterID"))
            {
                return;
            }

            ClickNum(password.ToCharArray(), psxControl, timeout);
            ClickEnter(timeout);
        }

        /// <summary>
        /// Alphanumeric password
        /// </summary>
        /// <param name="id">login identifier</param>
        /// <param name="password">login password</param>
        /// <param name="timeout">timeout amount</param>
        private void AlphaNumericPassword(string id, string password, int timeout)
        {
            PsxControl alphaNumP1 = _config.Display.Controls.GetControl("AlphaNumP1");
            PsxControl alphaNumP4 = _config.Display.Controls.GetControl("AlphaNumP4");
            PsxControl alphaNumP2 = _config.Display.Controls.GetControl("AlphaNumP2");

            ClickAlphaNumPassword(password.ToCharArray(), alphaNumP1, alphaNumP4, alphaNumP2, timeout);
            ClickAlphaNumericEnter(timeout);
        }

        /// <summary>
        /// Goes to the start context before starting the script
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        private void GoAllTheWayBack(int timeout)
        {
            int now = Environment.TickCount;
            PlayerConfiguration playerConfiguration = _config.PlayerConfiguration;
            bool hasTimeout = (Environment.TickCount - now) < timeout;
            string context = string.Empty;

#if NET40
            while (!(context = NextGenUITestClient.Instance.GetCurrentContext()).Equals(_scriptStartScreen) && hasTimeout)
            {
                if (SSCOHelper.IsLaneStartScreen(context) && !context.Contains("Closed"))
                {
                    break;
                }
                else if (context.Equals(string.Empty) || context.Contains("Startup") || context.Contains("Disconnected"))
                {
                    OnPlaying(string.Format("[SmartExit] Current Context is {0}. Unable to get current context from NextGenUITestClient.", context));
                    break;
                }

                NXTUIGoBack(context);
#else
            while (!(context = CurrentContext).Contains(playerConfiguration.StartContext) && hasTimeout)
            {
                GoBack(context);
#endif
                hasTimeout = (Environment.TickCount - now) < timeout;
                ThreadHelper.Sleep(1000);
                if (HasStopped || CurrentContext.Contains("OperatorPasswordStateInvalidPassword"))
                {
                    break;
                }
            }

            LoggingService.Info(string.Format("[SmartExit] Current Context is {0}", context));
        }

        /// <summary>
        /// Go back to given context
        /// </summary>
        /// <param name="context">name of the context</param>
        private void NXTUIGoBack(string context)
        {
            OnEmulating(string.Format("[SmartExit] Going back from {0}...", context));

            if (NXTUIBackCommands.ContainsKey(context))
            {
                NXTUIBackCommands[context].Run();
            }
            else
            {
                ThreadHelper.Sleep(200);
                _undefinedNXTUICommand = context;
                if (_undefinedNXTUICommand != null)
                {
                    OnEmulating(string.Format("[SmartExit]SSCAT encountered an error: '{0}' Context not defined in NXTUIBackCommands in LaneConfiguration.xml", _undefinedNXTUICommand));
                    OnEmulating(string.Format("{1}Troubleshooting tips: {1}In 'NXTUIBackCommands' Section in c:\\sscat\\config\\LaneConfiguration.xml, Kindly Add Context Name {0} and the Control Name that will lead the SSCO to Attract/Welcome Screen.{1}for example:{1}<Command Context = " + "''KeyInCode''" + " Control= " + "''GoBackButton''" + ">", _undefinedNXTUICommand, Environment.NewLine));
                }
            }
        }

        /// <summary>
        /// Go back to given context
        /// </summary>
        /// <param name="context">name of the context</param>
        private void GoBack(string context)
        {
            OnEmulating(string.Format("Going back from {0} Go Back...", context));
            if (BackCommands.ContainsKey(context))
            {
                BackCommands[context].Run();
            }
            else
            {
                ThreadHelper.Sleep(200);
                OnEmulating(string.Format("SSCAT Error: '{0}' Context not defined in BackCommands in LaneConfiguration.xml", context));
            }
        }

        /// <summary>
        /// Go to lane closed context
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns true if able to go back to lane closed, false otherwise</returns>
        private bool GoToLaneClosed(int timeout)
        {
            int now = Environment.TickCount;
            SafeClick("ButtonHelp", "Attract", timeout);
            SafeClick("CMButton2StoreLogIn", "ContextHelp", timeout);
            ThreadHelper.Sleep(200);
            Login(timeout);
            if (CurrentContext.Contains("OperatorPasswordStateInvalidPassword"))
            {
                return false;
            }

            SafeClick("SMButton1", "SmAuthorization", timeout);
            return true;
        }

        /// <summary>
        /// Safely clicks the control
        /// </summary>
        /// <param name="control">name of the control</param>
        /// <param name="context">name of the context</param>
        /// <param name="timeout">timeout amount</param>
        private void SafeClick(string control, string context, int timeout)
        {
            int now = Environment.TickCount;
            while (!CurrentContext.Contains(context) && ((Environment.TickCount - now) < timeout))
            {
                ThreadHelper.Sleep(200);
            }

            if (!CurrentContext.Contains(context) || !IsClickable(control, timeout - (Environment.TickCount - now)))
            {
                throw new Exception(string.Format("Unable to click {0} @ {1}", control, CurrentContext));
            }

            Click(control, string.Empty, timeout, true);
        }

        /// <summary>
        /// Check if script starts in Login
        /// </summary>
        /// <param name="evnts">scripts events</param>
        /// <returns>Returns true if script starts in Login</returns>
        private bool IsScriptStartLogin(List<ScriptEvent> evnts)
        {
            return evnts.Exists(x => ((x.Item is IUIAutoTestEvent) && (x.Item as UIAutoTestEvent).ContextName.ToLower().Contains("closed") && (x.Item as UIAutoTestEvent).ContextName.ToLower().Contains("closed")))
                && NextGenUITestClient.Instance.GetCurrentContext().ToLower().Contains("closed");
        }

        /// <summary>
        /// Checks if the control is clickable
        /// </summary>
        /// <param name="control">name of the control</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns true if clickable, false otherwise</returns>
        private bool IsClickable(string control, int timeout)
        {
            IPsx psx = CurrentPsx;
            int now = Environment.TickCount;
            bool hasTimedOut = false;
            int i = 0;
            if (control.Equals(string.Empty) || control == null)
            {
                throw new Exception("Unable to click an empty value");
            }

            while ((!psx.IsClickable(control)) && !hasTimedOut)
            {
                if (i++ % (42 * 3) == 0)
                {
                    OnEmulating(string.Format("Checking if the control ({0}) is clickable...", control));
                }

                hasTimedOut = (Environment.TickCount - now) > timeout;
                if (!hasTimedOut && !HasStopped)
                {
                    ThreadHelper.Sleep(20);
                }
                else if (HasStopped)
                {
                    break;
                }
            }

            if (hasTimedOut)
            {
                return false;
            }

            return true;
        }
        #endregion

        /// <summary>
        /// Checks Produce Scale Weight, Sets to Zero if weight is non-zero
        /// </summary>
        private void ProduceScaleCheck()
        {
            try
            {
                Scale scale = new Scale();
                int scaleWeight = scale.GetScaleWeight(Timeout);
                OnPlaying(string.Format("ProduceScale Health Check: {0}", scaleWeight));
                if (!scaleWeight.Equals(0))
                {
                    OnPlaying(string.Format("Setting ProduceScale to Zero"));
                    scale.Tear();
                }
            }
            catch (Exception ex)
            {
                OnPlaying(string.Format(ex.Message));
                OnPlaying(string.Format("Continue playing script."));
            }
        }

        /// <summary>
        /// Dispose all hooks and nullify hooks
        /// </summary>
        private void DisposeHooks()
        {
            if (_hooks != null)
            {
                OnEmulating("Disposing Hooks");

                foreach (IScotLogHook hook in _hooks.Values)
                {
                    hook.Dispose();
                }

                _hooks = null;
            }
        }

        /// <summary>
        /// Dispose all parsers and nullify parsers
        /// </summary>
        private void DisposeParsers()
        {
            if (_parsers != null)
            {
                OnEmulating("Disposing Parsers");
                foreach (IParser parser in Parsers)
                {
                    parser.Dispose();
                }

                _parsers = null;
            }
        }

        /// <summary>
        /// Stops the PSX
        /// </summary>
        private void StopPsx()
        {
            foreach (IPsx psx in PsxConnections.Values)
            {
                if (psx != null)
                {
                    psx.Stop();
                }
            }
        }

        /// <summary>
        /// Stops the parsers
        /// </summary>
        private void StopParsers()
        {
            if (Parsers != null)
            {
                foreach (IParser parser in Parsers)
                {
                    parser.Stop();
                }
            }
        }

        /// <summary>
        /// Stops the log hooks
        /// </summary>
        private void StopHooks()
        {
            if (_hooks != null)
            {
                foreach (IScotLogHook hook in _hooks.Values)
                {
                    hook.Stop();
                }
            }
        }

        /// <summary>
        /// Event for parse generator
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">progress event arguments</param>
        private void GeneratorParse(object sender, ProgressEventArgs e)
        {
            OnParse(e);
        }

        /// <summary>
        /// Event for running the command
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void CommandRunning(object sender, NcrEventArgs e)
        {
            OnPlaying(e.Message);
        }

        /// <summary>
        /// Event for connection adding
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">psx wrapper event arguments</param>
        private void EventConnectionAdding(object sender, PsxWrapperEventArgs e)
        {
            OnConnectionAdding(e);
        }

        /// <summary>
        /// Health Checker for ESA Simulator
        /// </summary>
        /// <returns>returns status of health check</returns>
        private string ESAHealthCheck()
        {
            var esaEmulatorExeFile = @"C:\scot\bin\ESAEmulator.exe";
            var errorMessage = string.Empty;
            string esaEmulatorProcessName = "ESAEmulator";
            string pipeServerProcessName = "pipeServer";
            
            if (SSCOHelper.IsESASimulator())
            {
                if (File.Exists(esaEmulatorExeFile))
                {
                    if (SSCOHelper.IsPipeServerPacketSizeMaximum())
                    {
                        if (!ProcessUtility.HasStarted(esaEmulatorProcessName))
                        {
                            LoggingService.Info("ESA is not running. Attempting to run.");

                            if (!ProcessUtility.HasStarted(pipeServerProcessName))
                            {
                                errorMessage = "Pipe Server has not started. Please make sure Pipe Server is running.";
                            }
                            else
                            {
                                ProcessUtility.Start(esaEmulatorExeFile);
                                do
                                {
                                    ThreadHelper.Sleep(5000);
                                    LoggingService.Info("Sleeping for 5 seconds");
                                } while (!ProcessUtility.HasStarted(esaEmulatorProcessName));

                                ThreadHelper.Sleep(3000);
                                LoggingService.Info("Sleeping for 3 seconds");
                                ESAEmulator esaEmulator = new ESAEmulator();
                                esaEmulator.SetEmulatorOn(Timeout);
                                
                            }
                        }
                        else
                        {
                            ProcessUtility.Kill(esaEmulatorProcessName);
                            ESAHealthCheck();
                        }
                    }
                    else
                    {
                        LoggingService.Info("Packet size of Pipe Server is not maximum. Attempting to set it to maximum.");
                        string pipeserverKey = string.Format(@"HKEY_LOCAL_MACHINE\{0}", RegistryAddress.PipeServerKey);
                        RegistryHelper.SetStringValue(pipeserverKey, Constants.RegistryConstants.PipeServerMaxPacketSizeKey, Constants.RegistryConstants.MaximumPacketSizeKeyValue);
                        ESAHealthCheck(); // Callback after setting maximum packetsize for Pipeserver
                    }
                }
                else
                {
                    errorMessage = "ESA Emulator is not existing in the current directory.";
                }
            }
        
            if (!string.IsNullOrEmpty(errorMessage))
            {
                LoggingService.Error(errorMessage);
            }

            return errorMessage;
        }

        /// <summary>
        /// Health Checker for SSB
        /// </summary>
        /// <param name="folderName"> script config folder name where PAPLASettings.ini is stored </param>
        private void SSBSimulatorHealthCheck(string folderName)
        {
            try
            {
                if (SSCOHelper.IsPALicense() || SSCOHelper.IsPLALicense())
                {
                    if (!SSCOHelper.CheckSSBConfig("SSBApplication", "SSBCommunicator", folderName))
                    {
                        OnPlaying("Killing SSB Communicator");
                        ProcessUtility.Kill("SSBCommunicator");
                        if (!ProcessUtility.HasStarted("SSBSimulator") && FileHelper.Exists(@"C:\scot\bin\SSBSimulator.exe"))
                        {
                            OnPlaying("Starting up SSB Simulator");
                            try
                            {
                                ProcessUtility.Start(@"C:\scot\bin\SSBSimulator.exe");
                            }
                            catch (Exception e)
                            {
                                LoggingService.Info(e.Message);
                            }

                            OnPlaying("Done starting SSB Simulator");
                            ThreadHelper.Sleep(1000);
                            SimulateScanPay(); ////this is only a temporary fix to accomodate checkbox enabling. This should be addressed in SSCOADK-11374
                        }
                        else if (!FileHelper.Exists(@"C:\scot\bin\SSBSimulator.exe"))
                        {
                            throw new Exception("Unable to play PAPLA test case. PA/PLA is enabled in scot options but SSB Simulator is not installed.");
                        }

                        OnPlaying("Checking Checkboxes in SSBSimulator.");
                        SSBSimulator ssbSimulator = new SSBSimulator();
                        ssbSimulator.SetCheckBox(Timeout, folderName);
                        OnPlaying("Done loading SSB configuration");
                        ThreadHelper.Sleep(1000);
                    }
                    else if (!ProcessUtility.HasStarted("SSBCommunicator"))
                    {
                        OnPlaying("Starting up SSB Communicator");
                        ProcessUtility.Start(@"C:\scot\bin\SSBCommunicator.exe");
                        OnPlaying("5 Seconds Delay to stabilize SSB Communicator.");
                        ThreadHelper.Sleep(5000);
                        if (ProcessUtility.HasStarted("SSBSimulator"))
                        {
                            ProcessUtility.Kill("SSBSimulator");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Simulates scan and pay to enable SSB Simulator
        /// </summary>
        private void SimulateScanPay()
        {
            try
            {
                OnPlaying("Simulating Scan Pay to enable buttons in SSBSimulator. Starting...");
                NextGenUITestClient.Instance.ClickButton("InstructionBox", "Welcome", string.Empty);
                ThreadHelper.Sleep(1000);
                NextGenUITestClient.Instance.ClickButton("PayButton", "Scan", string.Empty);
                OnPlaying("Simulating Scan Pay to enable buttons in SSBSimulator. Done.");
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// Validation for any mis spelled/unknown events
        /// </summary>
        /// <param name="script">the script</param>
        /// <returns>whether there are misspelled events</returns>
        private bool CheckEventMispells(IScript script)
        {
            try
            {
                foreach (IScriptEvent e in script.Events.Events)
                {
                    e.ToRepresentation();
                }
            }
            catch (NullReferenceException)
            {
                LoggingService.Info("Inside null reference in validation");
                return true;
            }
            catch (Exception)
            {
                return true;
            }

            return false;
        }
    }
}