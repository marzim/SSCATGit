// <copyright file="PlayerConfiguration.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the PlayerConfiguration class
    /// </summary>
    [XmlRoot("Configuration"), Serializable()]
    public class PlayerConfiguration : BaseModel<PlayerConfiguration>, IDisposable, IContent
    {
        /// <summary>
        /// The log hook timeout
        /// </summary>
        private int _logHookTimeout;

        /// <summary>
        /// The warning timeout
        /// </summary>
        private int _warningTimeout;

        /// <summary>
        /// The playback repetition
        /// </summary>
        private int _playbackRepetition;

        /// <summary>
        /// Screen Capture Shots
        /// </summary>
        private int _screenCaptureShots;

        /// <summary>
        /// Screen Capture Delay in milliseconds
        /// </summary>
        private int _screenCaptureDelay;

        /// <summary>
        /// Screen Capture Delay in milliseconds
        /// </summary>
        private int _screenCaptureIntervalDelay;

        /// <summary>
        /// Whether or not to override the RAP name
        /// </summary>
        private bool _overrideRapName;

        /// <summary>
        /// Whether or not to capture the screenshot
        /// </summary>
        private bool _captureScreenShot;

        /// <summary>
        /// Whether or not to capture multiple shots
        /// </summary>
        private bool _multipleShots;

        /// <summary>
        /// Whether or not to display the results after playback
        /// </summary>
        private bool _displayResultsAfterPlayback;

        /// <summary>
        /// Whether or not to get the diagnostics when an error occurs
        /// </summary>
        private bool _getDiagsOnError;

        /// <summary>
        /// Whether or not to automatically get the diagnostics after a playback
        /// </summary>
        private bool _autoGetDiagsAfterPlayback;

        /// <summary>
        /// Whether or not to have user intervention when an error occurs
        /// </summary>
        private bool _userInterventionOnError;

        /// <summary>
        /// Whether or not to lock a screenshot
        /// </summary>
        private bool _lockedScreenshot;

        /// <summary>
        /// Whether or not to load the configuration
        /// </summary>
        private bool _loadConfiguration;

        /// <summary>
        /// Whether or not to simulate the user time
        /// </summary>
        private bool _simulateUserTime;

        /// <summary>
        /// Whether or not to save the report in the server
        /// </summary>
        private bool _saveReportInServer;

        /// <summary>
        /// Whether or not to override security server
        /// </summary>
        private bool _overrideSecurityServer;

        /// <summary>
        /// Whether or not to stop when an error occurs
        /// </summary>
        private bool _stopOnError;

        /// <summary>
        /// Whether or not to use Smart Exit
        /// </summary>
        private bool _useSmartExit;

        /// <summary>
        /// The RAP name
        /// </summary>
        private string _rapName;

        /// <summary>
        /// The log files path
        /// </summary>
        private string _logFilesPath;

        /// <summary>
        /// The report file path
        /// </summary>
        private string _reportFilePath;

        /// <summary>
        /// SCOT configuration path
        /// </summary>
        private string _scotConfigPath;

        /// <summary>
        /// Screenshot path
        /// </summary>
        private string _screenshotPath;

        /// <summary>
        /// Diagnostic path
        /// </summary>
        private string _diagnosticPath;

        /// <summary>
        /// Diagnostics temporary path
        /// </summary>
        private string _diagTempPath;

        /// <summary>
        /// The password
        /// </summary>
        private string _password;

        /// <summary>
        /// Security server
        /// </summary>
        private string _securityServer;

        /// <summary>
        /// Login ID
        /// </summary>
        private string _loginId;

        /// <summary>
        /// Start context
        /// </summary>
        private string _startContext;

        /// <summary>
        /// Whether or not to use scanner login
        /// </summary>
        private bool _useScannerLogin;

        /// <summary>
        /// Operator barcode
        /// </summary>
        private string _operatorBarcode;

        /// <summary>
        /// Whether or not to override the login
        /// </summary>
        private bool _overrideLogin;

        /// <summary>
        /// Whether or not to enable skip forgivable events
        /// </summary>
        private bool _enableSkipForgivableEvents;

        /// <summary>
        /// Configuration files
        /// </summary>
        private ConfigFiles _configFiles = new ConfigFiles();

        /// <summary>
        /// Script configurations
        /// </summary>
        private ScriptConfigs _configs = new ScriptConfigs();

        /// <summary>
        /// Walmart MSR cards
        /// </summary>
        private MSRCards _walmartcards;
#if NET40
        /// <summary>
        /// Automated login configuration
        /// </summary>
        private AutomatedLoginConfiguration _automatedLoginConfig;
#endif
        /// <summary>
        /// Initializes a new instance of the PlayerConfiguration class
        /// </summary>
        public PlayerConfiguration()
        {
            _warningTimeout = 15000;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable the log hook
        /// </summary>
        [XmlAttribute("EnableLogHook")]
        public bool EnableLogHook
        {
            get { return true; }
            set { }
        }

        /// <summary>
        /// Gets or sets the log hook timeout
        /// </summary>
        [XmlAttribute("LogHookTimeout")]
        public int LogHookTimeout
        {
            get { return _logHookTimeout; }
            set { _logHookTimeout = value; }
        }

        /// <summary>
        /// Gets or sets the warning timeout
        /// </summary>
        [XmlAttribute("WarningTimeout")]
        public int WarningTimeout
        {
            get { return _warningTimeout; }
            set { _warningTimeout = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to override the security server
        /// </summary>
        [XmlAttribute("OverrideSecurityServer")]
        public bool OverrideSecurityServer
        {
            get { return _overrideSecurityServer; }
            set { _overrideSecurityServer = value; }
        }

        /// <summary>
        /// Gets or sets the security server
        /// </summary>
        [XmlAttribute("SecurityServer")]
        public string SecurityServer
        {
            get { return _securityServer; }
            set { _securityServer = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to override the RAP name
        /// </summary>
        [XmlAttribute("OverrideRapName")]
        public bool OverrideRapName
        {
            get { return _overrideRapName; }
            set { _overrideRapName = value; }
        }

        /// <summary>
        /// Gets or sets the RAP name
        /// </summary>
        [XmlAttribute("RapName")]
        public string RapName
        {
            get { return _rapName; }
            set { _rapName = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to capture a screenshot
        /// </summary>
        [XmlAttribute("CaptureScreenShot")]
        public bool CaptureScreenShot
        {
            get { return _captureScreenShot; }
            set { _captureScreenShot = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to capture multiple shots
        /// </summary>
        [XmlAttribute("MultipleShots")]
        public bool MultipleShots
        {
            get { return _multipleShots; }
            set { _multipleShots = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating the number of milliseconds delay before capturing a screenshot
        /// </summary>
        [XmlAttribute("ScreenCaptureDelay")]
        public int ScreenCaptureDelay
        {
            get { return _screenCaptureDelay; }
            set { _screenCaptureDelay = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating the number of milliseconds delay in between shots
        /// </summary>
        [XmlAttribute("ScreenCaptureIntervalDelay")]
        public int ScreenCaptureIntervalDelay
        {
            get { return _screenCaptureIntervalDelay; }
            set { _screenCaptureIntervalDelay = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to capture a screenshot
        /// </summary>
        [XmlAttribute("ScreenCaptureShots")]
        public int ScreenCaptureShots
        {
            get { return _screenCaptureShots; }
            set { _screenCaptureShots = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to get the diagnostics when an error occurs
        /// </summary>
        [XmlAttribute("GetDiagsOnError")]
        public bool GetDiagsOnError
        {
            get { return _getDiagsOnError; }
            set { _getDiagsOnError = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to load the configuration
        /// </summary>
        [XmlAttribute("LoadConfiguration")]
        public bool LoadConfiguration
        {
            get { return _loadConfiguration; }
            set { _loadConfiguration = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to simulate user time
        /// </summary>
        [XmlAttribute("SimulateUserTime")]
        public bool SimulateUserTime
        {
            get { return _simulateUserTime; }
            set { _simulateUserTime = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the screenshot is locked
        /// </summary>
        [XmlAttribute("LockedScreenshot")]
        public bool LockedScreenshot
        {
            get { return _lockedScreenshot; }
            set { _lockedScreenshot = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to stop when an error occurs
        /// </summary>
        [XmlAttribute("StopOnError")]
        public bool StopOnError
        {
            get { return _stopOnError; }
            set { _stopOnError = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use the smart exit
        /// </summary>
        [XmlAttribute("UseSmartExit")]
        public bool UseSmartExit
        {
            get { return _useSmartExit; }
            set { _useSmartExit = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to override the login
        /// </summary>
        [XmlAttribute("OverrideLogin")]
        public bool OverrideLogin
        {
            get { return _overrideLogin; }
            set { _overrideLogin = value; }
        }

        /// <summary>
        /// Gets or sets the start context
        /// </summary>
        [XmlAttribute("StartContext")]
        public string StartContext
        {
            get { return _startContext; }
            set { _startContext = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use scanner operator barcode in smart exit
        /// </summary>
        [XmlAttribute("UseScannerLogin")]
        public bool UseScannerLogin
        {
            get { return _useScannerLogin; }
            set { _useScannerLogin = value; }
        }

        /// <summary>
        /// Gets or sets the login ID
        /// </summary>
        [XmlAttribute("LoginId")]
        public string LoginId
        {
            get { return _loginId; }
            set { _loginId = value; }
        }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        [XmlAttribute("Password")]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// Gets or sets the operator barcode
        /// </summary>
        [XmlAttribute("OperatorBarcode")]
        public string OperatorBarcode
        {
            get { return _operatorBarcode; }
            set { _operatorBarcode = value; }
        }

        /// <summary>
        /// Gets or sets the diagnostics temporary path
        /// </summary>
        [XmlAttribute("DiagTempPath")]
        public string DiagTempPath
        {
            get { return _diagTempPath; }
            set { _diagTempPath = value; }
        }

        /// <summary>
        /// Gets or sets the playback repetition
        /// </summary>
        [XmlAttribute("PlaybackRepetition")]
        public int PlaybackRepetition
        {
            get { return _playbackRepetition; }
            set { _playbackRepetition = value; }
        }

        /// <summary>
        /// Gets or sets the SCOT configuration path
        /// </summary>
        [XmlAttribute("ScotConfigPath")]
        public string ScotConfigPath
        {
            get { return _scotConfigPath; }
            set { _scotConfigPath = value; }
        }

        /// <summary>
        /// Gets or sets log files path
        /// </summary>
        [XmlAttribute("LogFilesPath")]
        public string LogFilesPath
        {
            get { return _logFilesPath; }
            set { _logFilesPath = value; }
        }

        /// <summary>
        /// Gets or sets the report file path
        /// </summary>
        [XmlAttribute("ReportFilePath")]
        public string ReportFilePath
        {
            get { return _reportFilePath; }
            set { _reportFilePath = value; }
        }

        /// <summary>
        /// Gets or sets the screenshot path
        /// </summary>
        [XmlAttribute("ScreenshotPath")]
        public string ScreenshotPath
        {
            get { return _screenshotPath; }
            set { _screenshotPath = value; }
        }

        /// <summary>
        /// Gets or sets the diagnostic path
        /// </summary>
        [XmlAttribute("DiagnosticPath")]
        public string DiagnosticPath
        {
            get { return _diagnosticPath; }
            set { _diagnosticPath = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display results after playback
        /// </summary>
        [XmlAttribute("DisplayResultsAfterPlayback")]
        public bool DisplayResultsAfterPlayback
        {
            get { return _displayResultsAfterPlayback; }
            set { _displayResultsAfterPlayback = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to automatically get the diagnostics after playback
        /// </summary>
        [XmlAttribute("AutoGetDiagsAfterPlayback")]
        public bool AutoGetDiagsAfterPlayback
        {
            get { return _autoGetDiagsAfterPlayback; }
            set { _autoGetDiagsAfterPlayback = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to save the report in server
        /// </summary>
        [XmlAttribute("SaveReportInServer")]
        public bool SaveReportInServer
        {
            get { return _saveReportInServer; }
            set { _saveReportInServer = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to have user intervention when an error occurs
        /// </summary>
        [XmlAttribute("UserInterventionOnError")]
        public bool UserInterventionOnError
        {
            get { return _userInterventionOnError; }
            set { _userInterventionOnError = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to enable skip forgivable events
        /// </summary>
        [XmlAttribute("EnableSkipForgivableEvents")]
        public bool EnableSkipForgivableEvents
        {
            get { return _enableSkipForgivableEvents; }
            set { _enableSkipForgivableEvents = value; }
        }

        /// <summary>
        /// Gets or sets the script configurations
        /// </summary>
        [XmlElement("ScriptConfigs")]
        public ScriptConfigs ScriptConfigs
        {
            get { return _configs; }
            set { _configs = value; }
        }

        /// <summary>
        /// Gets or sets the configuration files
        /// </summary>
        [XmlElement("Files")]
        public ConfigFiles ConfigFiles
        {
            get { return _configFiles; }
            set { _configFiles = value; }
        }

        /// <summary>
        /// Gets or sets the Walmart cards
        /// </summary>
        [XmlElement("MSRCards")]
        public MSRCards WalmartCards
        {
            get { return _walmartcards; }
            set { _walmartcards = value; }
        }

#if NET40
        /// <summary>
        /// Gets or sets the automated login
        /// </summary>
        [XmlElement("AutomatedLogin")]
        public AutomatedLoginConfiguration AutomatedLoginConfig
        {
            get { return _automatedLoginConfig; }
            set { _automatedLoginConfig = value; }
        }
#endif
        /// <summary>
        /// Clears the configuration
        /// </summary>
        public void Clear()
        {
            _configs.Clear();
        }

        /// <summary>
        /// Disposes the configuration
        /// </summary>
        public override void Dispose()
        {
            Clear();
        }

        /// <summary>
        /// Sets the proper script
        /// </summary>
        public void SetProperScripts()
        {
            foreach (ScriptConfig c in _configs.ScriptConfigurations)
            {
                c.Script = c.Script is SSCATScript ? SSCATScript.Deserialize(new StringReader(c.Script.Serialize())) : c.Script;
            }
        }

        /// <summary>
        /// Validates the player configuration
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            bool isRapNameEmpty = RapName == null || RapName == string.Empty;
            bool isRapNameNotExist = !DnsHelper.ValidHostName(RapName) && !ProcessUtility.CanPing(RapName);
            bool isValidRapName = !isRapNameEmpty && !isRapNameNotExist;

            bool isSecurityServerEmpty = SecurityServer == null || SecurityServer == string.Empty;
            bool isSecurityServerNotExist = !DnsHelper.ValidHostName(SecurityServer) && !ProcessUtility.CanPing(SecurityServer);
            bool isValidSecurityServer = !isSecurityServerEmpty && !isSecurityServerNotExist;

            if (OverrideRapName && OverrideSecurityServer)
            {
                AddErrorIf("Override RAP name and Security Server is empty, please enter a valid RAP name and Security Server.", isRapNameEmpty && isSecurityServerEmpty);
                AddErrorIf("Override RAP name and Security Server does not exist in the network domain, please enter the correct RAP Name and Security Server name.", isRapNameNotExist && isSecurityServerNotExist);
                AddErrorIf("Override RAP name is empty, please enter a valid RAP name.", isRapNameEmpty && (isValidSecurityServer || isSecurityServerNotExist));
                AddErrorIf("Override RAP name does not exist in the network domain, please enter the correct RAP Name.", isRapNameNotExist && (isValidSecurityServer || isSecurityServerEmpty));
                AddErrorIf("Override Security Server name is empty, please enter a valid Security Server name.", (isValidRapName || isRapNameNotExist) && isSecurityServerEmpty);
                AddErrorIf("Override Security Server name does not exist in the network domain, please enter the correct Security Server name.", (isValidRapName || isRapNameEmpty) && isSecurityServerNotExist);
            }
            else if (OverrideRapName && !OverrideSecurityServer)
            {
                AddErrorIf("Override RAP name is empty, please enter a valid RAP name.", isRapNameEmpty);
                AddErrorIf("Override RAP name does not exist in the network domain, please enter the correct RAP Name.", isRapNameNotExist);
            }
            else if (!OverrideRapName && OverrideSecurityServer)
            {
                AddErrorIf("Override Security Server name is empty, please enter a valid Security Server name.", isSecurityServerEmpty);
                AddErrorIf("Override Security Server name does not exist in the network domain, please enter the correct Security Server name.", isSecurityServerNotExist);
            }

            if (UseSmartExit || OverrideLogin)
            {
                AddErrorIf("LoginID is empty", LoginId.Equals(string.Empty) || (LoginId == null));
                AddErrorIf("Password is empty", Password.Equals(string.Empty) || (Password == null));
            }
        }
    }
}
