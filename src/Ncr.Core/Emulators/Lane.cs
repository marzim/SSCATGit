// <copyright file="Lane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Emulators
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Threading;
    using Microsoft.Win32;
    using Ncr.Core.Models;
    using Ncr.Core.Util;

    /// <summary>
    /// Lane state
    /// </summary>
    public enum LaneState
    {
        /// <summary>
        /// Lane state Attract
        /// </summary>
        Attract,

        /// <summary>
        /// Lane state SMS Authorization
        /// </summary>
        SmsAuthorization,

        /// <summary>
        /// Lane state Stopped
        /// </summary>
        Stopped,

        /// <summary>
        /// Lane state Failed
        /// </summary>
        Failed
    }

    /// <summary>
    /// Initializes a new instance of the Lane class
    /// </summary>
    public class Lane : Emulator
    {
        /// <summary>
        /// Security manager interface
        /// </summary>
        private ISecurityManager _securityManager;

        /// <summary>
        /// PSX connections
        /// </summary>
        private PsxCollection _connections;

        /// <summary>
        /// Timeout amount
        /// </summary>
        private int _timeout;

        /// <summary>
        /// Whether or not lane has stopped
        /// </summary>
        private volatile bool _hasStopped;

        /// <summary>
        /// Lane worker
        /// </summary>
        private LaneWorker _worker = new LaneWorker();

        /// <summary>
        /// Whether or not to check for store login
        /// </summary>
        private bool _checkForStoreLogin;

        /// <summary>
        /// Lane emulators
        /// </summary>
        private IDictionary<string, IEmulator> _emulators;

        /// <summary>
        /// Checks whether or not lane is a custom generate
        /// </summary>
        private bool _isCustomGenerate = false;

        /// <summary>
        /// Initializes a new instance of the Lane class
        /// </summary>
        public Lane()
            : this(60000 * 10, true)
        {
        }

#if NET40
        /// <summary>
        /// Initializes a new instance of the Lane class
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        /// <param name="checkForStoreLogin">whether or not to check for store login</param>
        public Lane(int timeout, bool checkForStoreLogin)
            : base("UIControlWindowClass", Emulator.NextGenUICaption)
        {
            Emulators = new Dictionary<string, IEmulator>();
            PsxConnections = new PsxCollection();
            _timeout = timeout;
            _checkForStoreLogin = checkForStoreLogin;
        }
#else        
        /// <summary>
        /// Initializes a new instance of the Lane class
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        /// <param name="checkForStoreLogin">whether or not to check for store login</param>
		public Lane(int timeout, bool checkForStoreLogin) : base("UIControlWindowClass", Emulator.LaneCaption)
		{
			Emulators = new Dictionary<string, IEmulator>();
			PsxConnections = new PsxCollection();
			_timeout = timeout;
			_checkForStoreLogin = checkForStoreLogin;
		}
#endif
        /// <summary>
        /// Event handler for connection adding
        /// </summary>
        public event EventHandler<PsxWrapperEventArgs> ConnectionAdding;

        /// <summary>
        /// Gets or sets the lane emulators
        /// </summary>
        public IDictionary<string, IEmulator> Emulators
        {
            get { return _emulators; }
            set { _emulators = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not to check for store login
        /// </summary>
        public bool CheckForStoreLogin
        {
            get { return _checkForStoreLogin; }
            set { _checkForStoreLogin = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the lane has stopped
        /// </summary>
        public bool HasStopped
        {
            get { return _hasStopped; }
            set { _hasStopped = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the lane is a custom generate
        /// </summary>
        public bool IsCustomGenerate
        {
            get { return _isCustomGenerate; }
            set { _isCustomGenerate = value; }
        }

        /// <summary>
        /// Gets the current PSX
        /// </summary>
        public IPsx CurrentPsx
        {
            get
            {
                if (_connections.ContainsKey("AUTOMATION"))
                {
                    return _connections["AUTOMATION"] as IPsx;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the current context
        /// </summary>
        public string CurrentContext
        {
            get
            {
                if (CurrentPsx != null)
                {
                    return CurrentPsx.GetContext(1);
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the file name
        /// </summary>
        public override string FileName
        {
            get
            {
                return string.Format(@"C:\scot\bin\{0}.exe", ProcessName);
            }
        }

        /// <summary>
        /// Gets or sets the security manager
        /// </summary>
        public virtual ISecurityManager SecurityManager
        {
            get { return _securityManager; }
            set { _securityManager = value; }
        }

        /// <summary>
        /// Gets or sets the PSX connections
        /// </summary>
        public PsxCollection PsxConnections
        {
            get { return _connections; }
            set { _connections = value; }
        }

        /// <summary>
        /// Gets the timeout
        /// </summary>
        public virtual int Timeout
        {
            get { return _timeout; }
        }

        /// <summary>
        /// Gets the absolute log files
        /// </summary>
        public IList<string> AbsoluteLogFiles
        {
            get
            {
                return new List<string>(
                    new string[]
                    {
                        PsxLogFile,
                        "psx_LaunchPadNet.log",
                        "Traces.log",
                        "SM.log",
                        string.Format("{0}.bak", PsxLogFile),
                        "psx_LaunchPadNet.log.bak",
                        "Traces.log.bak",
                        "SM.log.BAK",
                        "xmode.log",
                        "xmode.log.bak",
                        "posm.log",
                        "posm.log.bak",
                        "flm.log",
                        "flm.log.bak",
                        "Takeawaybelt.log",
                        "Takeawaybelt.log.bak",
                        "SSCOUI.log",
                        "SSCOUI.log.BAK",
                    });
            }
        }

        /// <summary>
        /// Gets the log files
        /// </summary>
        public virtual IList<string> LogFiles
        {
            get
            {
                IList<string> logFiles = new List<string>();
                foreach (string f in AbsoluteLogFiles)
                {
                    logFiles.Add(Path.Combine(LogsDirectory, f));
                }

                return logFiles;
            }
        }

        /// <summary>
        /// Gets the product version
        /// </summary>
        public virtual string ProductVersion
        {
            get
            {
                if (_isCustomGenerate)
                {
                    return FileHelper.GetDumpProductVersion();
                }

                return SSCOHelper.GetADKVersion();
            }
        }

        /// <summary>
        /// Gets the ADD version
        /// </summary>
        public string ADDVersion
        {
            get
            {
                return SSCOHelper.GetADDVersion();
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not lane is CADD
        /// </summary>
        public virtual bool IsCADD
        {
            get
            {
                return SSCOHelper.IsCADD();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the lane is NGUI
        /// </summary>
        public virtual bool IsNGUI
        {
            get
            {
                return SSCOHelper.IsNGUI();
            }
        }

        /// <summary>
        /// Gets a value indicating whether the lane is set to use the operator numeric keypad
        /// </summary>
        public virtual bool IsOperatorNumericKeyPad
        {
            get
            {
                return SSCOHelper.IsOperatorNumericKeyPad();
            }
        }

        /// <summary>
        /// Gets the process name
        /// </summary>
        public override string ProcessName
        {
            get
            {
                return IsUnicode ? "SCOTAppU" : "SCOTApp";
            }
        }

        /// <summary>
        /// Gets the application handle
        /// </summary>
        public override IntPtr Handle
        {
            get
            {
#if NET40
                if (IsNGUI)
                {
                    Process proc = Process.GetProcessesByName("SSCOUI")[0];
                    return proc.MainWindowHandle;
                }
                else
                {
                    return ApiHelper.FindWindow(Type, Caption);
                }
#else
                return ApiHelper.FindWindow(Type, Caption); 
#endif
            }
        }

        /// <summary>
        /// Gets the PSX log file
        /// </summary>
        public string PsxLogFile
        {
            get
            {
                string file = IsUnicode ? "psx_ScotAppU.log" : "psx_ScotApp.log";
                return file;
            }
        }

        /// <summary>
        /// Gets the log directory
        /// </summary>
        public string LogsDirectory
        {
            get { return @"C:\scot\logs"; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the lane is ready
        /// </summary>
        public virtual bool IsReady
        {
            get
            {
                int now = Environment.TickCount;
                bool ready = false;
                while ((Environment.TickCount - now) < Timeout && !ready)
                {
                    if (HasStopped)
                    {
                        OnEmulating("Playback will stop after starting the lane. Please wait..");
                    }

                    OnEmulating("Getting Lane State...");
                    try
                    {
                        if (_checkForStoreLogin)
                        {
                            if (!PsxConnections.ContainsKey("AUTOMATION"))
                            {
                                OnConnectionAdding(new PsxWrapperEventArgs(DnsHelper.GetLocalIPAddress(), "FastLaneRemoteServer", "AUTOMATION", 3000));
                            }

                            LoggingService.Info("Checking for start screen...");
                            IPsx psx = PsxConnections["AUTOMATION"];
                            if (CurrentContext.Contains("Attract") || (psx.IsClickable("CMButton1StoreLogIn") && CurrentContext.Contains("LaneClosed")))
                            {
                                LoggingService.Info(string.Format("CurrentContext: {0}", CurrentContext.ToString()));
                                LoggingService.Info(string.Format("IsClickable CMButton1StoreLogIn: {0}", psx.IsClickable("CMButton1StoreLogIn").ToString()));
                                ready = true;
                            }
                            else
                            {
                                ThreadHelper.Sleep(3000);
                            }
                        }
                        else
                        {
                            ready = true;
                        }
                    }
                    catch
                    {
                        ThreadHelper.Sleep(3000);
                    }
                }

                return ready;
            }
        }

        /// <summary>
        /// Gets the currency code
        /// </summary>
        public string CurrencyCode
        {
            get { return TrimCurrencyCode(); }
        }

        /// <summary>
        /// Gets the full currency code
        /// </summary>
        public string FullCurrencyCode
        {
            get { return GetFullCurrencyCode(); }
        }

        /// <summary>
        /// Gets the current coin and bill count
        /// </summary>
        public string CurrentCoinAndBillCount
        {
            get { return string.Format("{0};{1}", CurrentCoinCount, CurrentBillCount); }
        }
        
        /// <summary>
        /// Gets the current coin count
        /// </summary>
        public string CurrentCoinCount
        {
            get { return GetCurrentCointCount(); }
        }

        /// <summary>
        /// Gets the current bill count
        /// </summary>
        public string CurrentBillCount
        {
            get { return GetCurrentBillCount(); }
        }

        /// <summary>
        /// Gets the terminal number
        /// </summary>
        public string TerminalNumber
        {
            get { return GetTerminalNumber(); }
        }

        /// <summary>
        /// Gets the cash value list
        /// </summary>
        public string CashValueList
        {
            get { return GetCashValueList(); }
        }

        /// <summary>
        /// Gets a value indicating whether or not application type is unicode
        /// </summary>
        private bool IsUnicode
        {
            get
            {
                string applicationType = GetApplicationType();
                if (applicationType == null || applicationType == string.Empty)
                {
                    throw new LaneException("SSCAT is unable to determined the application type of your system.");
                }

                return applicationType.ToLower().Equals("unicode");
            }
        }

        /// <summary>
        /// Gets the SCOT opts files
        /// </summary>
        private IList<string> ScotoptsFiles
        {
            get
            {
                IList<string> scotoptsFiles = new List<string>();
                foreach (string s in AbsoluteScotoptsFiles)
                {
                    // TODO: Please find a way to make the scot config generic so that it could be easily replace in unit testing.
                    scotoptsFiles.Add(Path.Combine(@"C:\scot\config", s)); 
                }

                return scotoptsFiles;
            }
        }

        /// <summary>
        /// Gets the absolute SCOT opts files
        /// </summary>
        private IList<string> AbsoluteScotoptsFiles
        {
            get
            {
                return new List<string>(new string[] { string.Format("Scotopts.{0}", TerminalNumber), "Scotopts.000", "Scotopts.dat", });
            }
        }

        /// <summary>
        /// Gets the PSX log file
        /// </summary>
        /// <returns>Returns the PSX log file</returns>
        public string GetPsxLogFile()
        {
            return Path.Combine(LogsDirectory, PsxLogFile);
        }

        /// <summary>
        /// Adds the emulators
        /// </summary>
        /// <param name="emulators">emulators to add</param>
        public virtual void AddEmulator(params IEmulator[] emulators)
        {
            foreach (IEmulator emulator in emulators)
            {
                Emulators.Add(emulator.Caption, emulator);
            }
        }

        /// <summary>
        /// Delete logs
        /// </summary>
        public virtual void DeleteLogs()
        {
            foreach (string log in LogFiles)
            {
                FileHelper.Delete(log);
            }
        }

        /// <summary>
        /// Revert lane settings
        /// </summary>
        public void RevertLaneSettings()
        {
            string filename = @"C:\SSCAT\Bin\ScotFiles\revertreg.bat";

            if (FileHelper.Exists(filename))
            {
                ProcessUtility.Start(filename, true, 3000);
            }
        }

        /// <summary>
        /// Stops the lane
        /// </summary>
        public virtual void Stop()
        {
            HasStopped = true;
            _worker.Stop();
        }

        /// <summary>
        /// Starts the lane
        /// </summary>
        public override void Start()
        {
            Start(false);
        }

        /// <summary>
        /// Starts the lane
        /// </summary>
        /// <param name="throwOnException">whether or not to throw on exception</param>
        public void Start(bool throwOnException)
        {
            if (!ProcessUtility.HasStarted(ProcessName) && !ProcessUtility.HasStarted("LaunchpadNet"))
            {
                OnEmulating("Starting SSCO");
                ProcessUtility.Start(new ProcessStartInfo(ApplicationUtility.SscoStartupPath), false);
            }

            if (IsReady)
            {
                OnEmulating("Lane is now ready");
            }
            else if (throwOnException)
            {
                throw new LaneException("Lane not found");
            }
        }

        /// <summary>
        /// Kill the process
        /// </summary>
        public override void Kill()
        {
            ProcessUtility.Start(new ProcessStartInfo(Path.Combine(ApplicationUtility.ToolsDirectory, "stoplane.bat")), true);
        }

        /// <summary>
        /// Force kill the process
        /// </summary>
        public override void ForceKill()
        {
            OnEmulating("Force stopping lane...");
            _worker.Done = false;
            _worker.IsNGUI = IsNGUI;
            ThreadHelper.Start(_worker.ForceKill);
            while (!_worker.Done)
            {
                ThreadHelper.Sleep(3000);
                OnEmulating("Force stopping lane...");
            }
        }

        /// <summary>
        /// Revert the lane
        /// </summary>
        public void RevertLane()
        {
            ProcessUtility.Start(new ProcessStartInfo(Path.Combine(ApplicationUtility.ToolsDirectory, "revertreg.bat")), true);
        }

        /// <summary>
        /// Fire up the lane
        /// </summary>
        /// <param name="param">parameter amount</param>
        public virtual void Fire(int param)
        {
            OnEmulating(string.Format("SCOT firing {0}", param));
            if (Handle != IntPtr.Zero)
            {
                ApiHelper.SetForegroundWindow(Handle);
                ApiHelper.SendMessage(Handle, 7, 0, 0);
                Thread.Sleep(10);

                ApiHelper.KeyboardEvent(param, 0x45, 0x1, 0);
                Thread.Sleep(100);
                ApiHelper.KeyboardEvent(param, 0x45, 0x1 | 0x02, 0);

                ApiHelper.SendMessage(Handle, 8, 0, 0);
            }
        }

        /// <summary>
        /// Capture image window
        /// </summary>
        /// <returns>Returns the captured image</returns>
        public Image CaptureImageWindow()
        {
            if (Available())
            {
                Activate();
                return ApiHelper.CaptureImageWindow(Handle);
            }
            else
            {
                OnEmulating("Unable to find Window");
                throw new LaneException("SSCO has not started");
            }
        }

        /// <summary>
        /// Capture screen
        /// </summary>
        /// <returns>Returns the captured image</returns>
        public Image CaptureScreen()
        {
            if (Available())
            {
                Activate();
                return ApiHelper.CaptureImageDesktop();
            }
            else
            {
                OnEmulating("Unable to find Window");
                throw new LaneException("SSCO has not started");
            }
        }

        /// <summary>
        /// Set the emulator count
        /// </summary>
        /// <param name="emulatorSubKey">emulator subkey</param>
        /// <param name="count">emulator count</param>
        public void SetEmulatorCount(string emulatorSubKey, string count)
        {
            string emulatorKey = string.Empty;
            if (IsCADD)
            {
                if (emulatorSubKey == "Coin")
                {
                    emulatorKey = RegistryAddress.CADDEmulatorCoinKey;
                }
                else
                {
                    emulatorKey = RegistryAddress.CADDEmulatorBillKey;
                }
            }
            else
            {
                emulatorKey = RegistryAddress.ADDEmulatorCoinKey;
            }

            OnEmulating(string.Format("Setting cash changer emulator {0} counts: {1}", emulatorSubKey, count));
            List<string> emulatorSubKeyNames = new List<string>(RegistryHelper.GetSubKeyNames(emulatorKey, emulatorSubKey));
            emulatorSubKeyNames.Sort();
            foreach (string subKey in emulatorSubKeyNames)
            {
                RegistryHelper.DeleteSubKey(string.Format(@"{0}\{1}", emulatorKey, subKey));
            }

            string[] splitCount = count.Split(',');
            for (int i = 0; i < splitCount.Length; i++)
            {
                string[] denoCount = splitCount[i].Split(':');
                string keyName = string.Format(@"HKEY_LOCAL_MACHINE\{0}\{1}{2}", emulatorKey, emulatorSubKey, i + 1);
                RegistryHelper.SetStringValue(keyName, "CashCount", denoCount[1]);
                RegistryHelper.SetStringValue(keyName, "CashUnit", denoCount[0]);
                RegistryHelper.SetStringValue(keyName, "CurrencyCode", CurrencyCode);
                RegistryHelper.SetStringValue(keyName, "LowThreshold", "0");
                RegistryHelper.SetStringValue(keyName, "Name", denoCount[0]);
                RegistryHelper.SetStringValue(keyName, "Valid", "TRUE");
            }

            RegistryHelper.SetStringValue(string.Format(@"HKEY_LOCAL_MACHINE\{0}", emulatorKey), "CurrencyCode", CurrencyCode);
        }

        /// <summary>
        /// Event for on connection adding
        /// </summary>
        /// <param name="e">psx wrapper event arguments</param>
        protected virtual void OnConnectionAdding(PsxWrapperEventArgs e)
        {
            if (ConnectionAdding != null)
            {
                ConnectionAdding(this, e);
            }
        }

        /// <summary>
        /// Activate the application handle
        /// </summary>
        private void Activate()
        {
            ApiHelper.SetForegroundWindow(Handle);
            Thread.Sleep(50);
            ApiHelper.SendMessage(Handle, 7, 0, 0);
            Thread.Sleep(10);
            ApiHelper.ShowWindow(Handle, 5);
            Thread.Sleep(50);
        }

        /// <summary>
        /// Get the application type value
        /// </summary>
        /// <param name="key">application key</param>
        /// <returns>Returns the application type value</returns>
        private string GetApplicationTypeValue(string key)
        {
            if (key.Contains("ObservedOptions"))
            {
                return RegistryHelper.GetValue("ApplicationType", Registry.LocalMachine.OpenSubKey(key));
            }
            else
            {
                return RegistryHelper.GetValue("Configure", Registry.LocalMachine.OpenSubKey(key));
            }
        }

        /// <summary>
        /// Get the application type
        /// </summary>
        /// <returns>Returns the application type</returns>
        private string GetApplicationType()
        {
            string type = null;
            List<string> keyList = new List<string>();
            keyList.Add(RegistryAddress.SSCOApplicationType);
            keyList.Add(RegistryAddress.SSCOApplicationType2);

            foreach (string key in keyList)
            {
                if (RegistryHelper.Exists(key, Registry.LocalMachine))
                {
                    type = GetApplicationTypeValue(key);
                }

                if (type != null && type != string.Empty)
                {
                    LoggingService.Info(string.Format("Application Type: {0}", type.ToString()));
                    return type;
                }
            }

            return type;
        }

        /// <summary>
        /// Get the current coin count
        /// </summary>
        /// <returns>Returns the current coin count</returns>
        private string GetCurrentCointCount()
        {
            if (!HasStarted)
            {
                OnEmulating("SSCO is not running checking current coin count in coin emulator registry...");

                string emulatorCoinKey = string.Empty;
                if (IsCADD)
                {
                    emulatorCoinKey = RegistryAddress.CADDEmulatorCoinKey;
                }
                else
                {
                    emulatorCoinKey = RegistryAddress.ADDEmulatorCoinKey;
                }

                List<string> emulatorCoinSubKeyNames = new List<string>(RegistryHelper.GetSubKeyNames(emulatorCoinKey, "Coin"));
                emulatorCoinSubKeyNames.Sort();

                List<string> coinCounts = new List<string>();
                foreach (string subKey in emulatorCoinSubKeyNames)
                {
                    string cashUnit = RegistryHelper.GetValue("CashUnit", Registry.LocalMachine.OpenSubKey(string.Format(@"{0}\{1}", emulatorCoinKey, subKey)), string.Empty, true);
                    string cashCount = RegistryHelper.GetValue("CashCount", Registry.LocalMachine.OpenSubKey(string.Format(@"{0}\{1}", emulatorCoinKey, subKey)), string.Empty, true);
                    coinCounts.Add(string.Format("-{0}:{1}", cashUnit, cashCount));
                }

                return string.Join(",", coinCounts.ToArray());
            }
            else
            {
                OnEmulating("SSCO is running checking current coin count in cash changer coin emulator application...");

                List<string> emulatorDenominations = new List<string>();
                if (IsCADD)
                {
                    emulatorDenominations = GetEmulatorDenominations(RegistryAddress.CADDEmulatorCoinKey, "Coin");
                }
                else
                {
                    emulatorDenominations = GetEmulatorDenominations(RegistryAddress.ADDEmulatorCoinKey, "Coin");
                }

                List<string> coinCounts = new List<string>();

                CoinChanger coinChanger = new CoinChanger();
                foreach (string denomination in emulatorDenominations)
                {
                    string coinCount = coinChanger.BinCount(denomination);
                    LoggingService.Info(string.Format("{0}:{1}", denomination, coinCount));
                    coinCounts.Add(string.Format("-{0}:{1}", denomination, coinCount));
                }

                return string.Join(",", coinCounts.ToArray());
            }
        }

        /// <summary>
        /// Get emulator denominations
        /// </summary>
        /// <param name="emulatorKey">emulator key</param>
        /// <param name="emulatorName">emulator name</param>
        /// <returns>Returns the emulator denominations</returns>
        private List<string> GetEmulatorDenominations(string emulatorKey, string emulatorName)
        {
            List<string> emulatorSubKeyNames = new List<string>(RegistryHelper.GetSubKeyNames(emulatorKey, emulatorName));
            emulatorSubKeyNames.Sort();

            List<string> denominations = new List<string>();
            foreach (string subKey in emulatorSubKeyNames)
            {
                denominations.Add(RegistryHelper.GetValue("CashUnit", Registry.LocalMachine.OpenSubKey(string.Format(@"{0}\{1}", emulatorKey, subKey)), string.Empty, true));
            }

            return denominations;
        }

        /// <summary>
        /// Get the current bill count
        /// </summary>
        /// <returns>Returns the current bill count</returns>
        private string GetCurrentBillCount()
        {
            if (RegistryHelper.Exists(RegistryAddress.CashCountKey, Registry.LocalMachine))
            {
                string dispenserCounts = RegistryHelper.GetValue("DispenserCounts", Registry.LocalMachine.OpenSubKey(RegistryAddress.CashCountKey));
                string[] splitDispenserCounts = dispenserCounts.Split(';');
                return splitDispenserCounts[1];
            }
            else
            {
                LoggingService.Warning("No Dispenser count found in registry");
                return "NoCashCount";
            }
        }

        /// <summary>
        /// Trim the currency code
        /// </summary>
        /// <returns>Returns the trimmed currency code</returns>
        private string TrimCurrencyCode()
        {
            return FullCurrencyCode.Contains("GBP") ? "GBP" : FullCurrencyCode;
        }

        /// <summary>
        /// Get the full currency code
        /// </summary>
        /// <returns>Returns the full currency code</returns>
        private string GetFullCurrencyCode()
        {
            if (RegistryHelper.Exists(RegistryAddress.CountryCodeKey, Registry.LocalMachine))
            {
                return RegistryHelper.GetValue("CountryCode", Registry.LocalMachine.OpenSubKey(RegistryAddress.CountryCodeKey));
            }
            else if (RegistryHelper.Exists(RegistryAddress.CurrencyTypeKey, Registry.LocalMachine))
            {
                return RegistryHelper.GetValue("CurrencyType", Registry.LocalMachine.OpenSubKey(RegistryAddress.CurrencyTypeKey));
            }
            else
            {
                LoggingService.Warning("No Currency Code found in registry");
                return "NoCurrencyCode";
            }
        }

        /// <summary>
        /// Get terminal number
        /// </summary>
        /// <returns>Returns terminal number</returns>
        private string GetTerminalNumber()
        {
            return RegistryHelper.GetValue("TerminalNumber", Registry.LocalMachine.OpenSubKey(RegistryAddress.TerminalNumberKey));
        }

        /// <summary>
        /// Get the cash value list
        /// </summary>
        /// <returns>Returns the cash value list</returns>
        private string GetCashValueList()
        {
            string cashValueList = string.Empty;
            foreach (string s in ScotoptsFiles)
            {
                cashValueList = FileHelper.GetIniValue("Locale", "CashValueList", s);
                if (cashValueList != string.Empty)
                {
                    return cashValueList;
                }
            }

            return cashValueList;
        }
    }
}
