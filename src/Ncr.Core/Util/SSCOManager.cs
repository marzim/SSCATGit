// <copyright file="SSCOManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Versioning;
    using Microsoft.Win32;
    using System.Net;
    using System.Net.Sockets;

    /// <summary>
    /// Initializes a new instance of the SSCOManager class
    /// </summary>
    public class SSCOManager : ISSCOManager
    {
        /// <summary>
        /// Get ADK version
        /// </summary>
        /// <returns>Returns ADK version</returns>
        public string GetADKVersion()
        {
            if (RegistryHelper.Exists(RegistryAddress.CurrentVersionKey, Registry.LocalMachine))
            {
                return RegistryHelper.GetValue("Release Version", Registry.LocalMachine.OpenSubKey(RegistryAddress.CurrentVersionKey));
            }
            else
            {
                LoggingService.Error(string.Format("Failure in finding: {0}", RegistryAddress.CurrentVersionKey));
                return "NoProductVersionFound";
            }
        }

        /// <summary>
        /// Get ADD version
        /// </summary>
        /// <returns>Returns ADD version</returns>
        public string GetADDVersion()
        {
            if (RegistryHelper.Exists(RegistryAddress.ADDVersionKey, Registry.LocalMachine))
            {
                return RegistryHelper.GetValue("PackageVersion", Registry.LocalMachine.OpenSubKey(RegistryAddress.ADDVersionKey));
            }
            else
            {
                return "NoADDVersionFound";
            }
        }

        /// <summary>
        /// Checks if Next Gen UI
        /// </summary>
        /// <returns>Returns true if NGUI, false otherwise</returns>
        public bool IsNGUI()
        {
            string[] version = GetADKVersion().Split('.');
            return (Convert.ToInt32(version[0]) >= 6) && ((Convert.ToInt32(version[2]) >= 3) || (Convert.ToInt32(version[1]) >= 1));
        }

        /// <summary>
        /// Checks if Next Gen UI
        /// </summary>
        /// <param name="adkVersion">ADK version</param>
        /// <returns>Returns true if NGUI, false otherwise</returns>
        public bool IsNGUI(string adkVersion)
        {
            string[] version = adkVersion.Split('.');
            return (Convert.ToInt32(version[0]) >= 6) && ((Convert.ToInt32(version[2]) >= 3) || (Convert.ToInt32(version[1]) >= 1));
        }

        /// <summary>
        /// Checks if CADD
        /// </summary>
        /// <returns>Returns if CADD, false otherwise</returns>
        public bool IsCADD()
        {
            string[] packageVersion = GetADDVersion().Split('.');
            if (packageVersion[0] == "30")
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if operator numeric key pad is configured
        /// </summary>
        /// <returns>Returns true if using operator numeric key pad, false otherwise</returns>
        public bool IsOperatorNumericKeyPad()
        {
            string section = "Operations";
            string key = "OperatorNumericKeyPad";
            string filename = "scotopts";
            string fileformat = "dat";

            string value = GetINIConfigurationValue(section, key, filename, fileformat);

            switch (value)
            {
                case "N":
                    return false;
                case "Y":
                    return true;
            }

            return true;
        }

        /// <summary>
        /// Checks if screen is the lane start screen
        /// </summary>
        /// <param name="screen">lane screen</param>
        /// <returns>Returns true if start screen, false otherwise</returns>
        public bool IsLaneStartScreen(string screen)
        {
            return screen.ToLower().Contains("attract") || screen.ToLower().Contains("welcome") || screen.ToLower().Contains("closed") || screen.ToLower().Contains("laneclosed");
        }

        /// <summary>
        /// Checks if screen is the operator login screen
        /// </summary>
        /// <param name="screen">lane screen</param>
        /// <returns>Returns true if operator login screen, false otherwise</returns>
        public bool IsOperatorLoginScreen(string screen)
        {
            return screen.ToLower().Contains("operatorkeyboard") || screen.ToLower().Contains("enterid");
        }

        /// <summary>
        /// Checks if 64 bit operating system
        /// </summary>
        /// <returns>Returns true if using 64 bit operating system, false otherwise</returns>
        public bool Is64BitOperatingSystem()
        {
#if NET40
            return Environment.Is64BitOperatingSystem;
#else
            return false;
#endif
        }

        /// <summary>
        /// Checks if SSCO types matches
        /// </summary>
        /// <param name="type">type of SSCO</param>
        /// <returns>Returns true if SSCO type matches</returns>
        public bool IsSSCOType(string type)
        {
            string sscoType = FileHelper.GetIniValue("SSCOApplication", "SSCOType", ApplicationUtility.SettingsFileName);

            return sscoType.Equals(type);
        }

        /// <summary>
        /// Checks if Coin Recycler Emulator is Enabled
        /// </summary>
        /// <returns>Returns true if Coin Recycler is Enabled</returns>
        public bool IsCoinRecyclerEmulatorEnabled()
        {
            string section = "SCOT5.NonDetectableDevices";
            string key = "NCRCoinRecycler.Emulator";
            return IsDeviceEnabled(section, key);
        }

        /// <summary>
        /// Checks if Coin Acceptor Emulator is Enabled
        /// </summary>
        /// <returns>Returns true if Coin Acceptor is Enabled</returns>
        public bool IsCoinAcceptorEmulatorEnabled()
        {
            string section = "SCOT5.NonDetectableDevices";
            string key = "CoinAcceptor.Emulator";
            return IsDeviceEnabled(section, key);
        }

        /// <summary>
        /// Checks if a Device is Enabled in CADD Configuration
        /// </summary>
        /// <param name="section">registry section</param>
        /// <param name="key">registry key</param>
        /// <returns>Returns true if a Device is Enabled</returns>
        public bool IsDeviceEnabled(string section, string key)
        {
            string filename = "CADD";
            string fileformat = "INI";

            string value = GetINIConfigurationValue(section, key, filename, fileformat);

            return value.Contains("Enabled");
        }

        /// <summary>
        /// Get INI Configuration value
        /// </summary>
        /// <param name="section">registry section</param>
        /// <param name="key">registry key</param>
        /// <param name="filename">file name</param>
        /// <param name="fileformat">file format</param>
        /// <returns>Returns INI Configuration value</returns>
        public string GetINIConfigurationValue(string section, string key, string filename, string fileformat)
        {
            string SCOTPATH = string.Format(@"{0}\{1}", Environment.GetEnvironmentVariable("APP_DRIVE"), Environment.GetEnvironmentVariable("APP_DIR"));

            List<string> filenames = new List<string>();
            string s1 = string.Empty;

            filenames.Add(string.Format(@"{0}\config\{1}.{2}", SCOTPATH, filename, RegistryHelper.GetValue("TerminalNumber", Registry.LocalMachine.OpenSubKey(RegistryAddress.TerminalNumberKey))));
            filenames.Add(string.Format(@"{0}\config\{1}.000", SCOTPATH, filename));
            filenames.Add(string.Format(@"{0}\config\{1}.{2}", SCOTPATH, filename, fileformat));

            foreach (string file in filenames)
            {
                if (FileHelper.Exists(file))
                {
                    s1 = IniFileHelper.GetString(file, section, key).ToUpper();
                    if (!s1.Equals(string.Empty))
                    {
                        LoggingService.Info(string.Format("Value='{0}' found in Key:{1} Section:{2} File:{3}", s1, key, section, file));
                        return s1;
                    }
                }

                LoggingService.Info(string.Format("Value='{0}' found in Key:{1} Section:{2} File:{3}", s1, key, section, file));
            }

            return string.Empty;
        }

        /// <summary>
        /// Checks if ESA Simulator is configured
        /// </summary>
        /// <returns>Returns true if ESA Simulator has been set to Y, false otherwise</returns>
        public bool IsESASimulator()
        {
            string section = "Operations";
            string key = "SecureCamEnable";
            string filename = "scotopts";
            string fileformat = "dat";

            string value = GetINIConfigurationValue(section, key, filename, fileformat);

            switch (value)
            {
                case "N":
                    return false;
                case "Y":
                    return true;
            }

            return true;
        }

        /// <summary>
        /// Checks if Packet Size of PipeServer is in MAXIMUM
        /// </summary>
        /// <returns>Returns true if Packet Size of PipeServer is in MAXIMUM, false otherwise</returns>
        public bool IsPipeServerPacketSizeInMaximum()
        {
            int maximumPacketSize = 10485760;

            if (RegistryHelper.Exists(RegistryAddress.PipeServerKey, Registry.LocalMachine))
            {
                int currentPacketSize = Convert.ToInt32(RegistryHelper.GetValue("MaxPacketSize", Registry.LocalMachine.OpenSubKey(RegistryAddress.PipeServerKey)));
                LoggingService.Info(string.Format("CurrentPacketSize value : {0}", currentPacketSize.ToString()));
                LoggingService.Info(RegistryHelper.GetValue("MaxPacketSize", Registry.LocalMachine.OpenSubKey(RegistryAddress.PipeServerKey)));
                if (currentPacketSize < maximumPacketSize)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if PLALicense is configured
        /// </summary>
        /// <returns>Returns true if PLA License has been set to Y, false otherwise</returns>
        public bool IsPLALicense()
        {
            string section = "Operations";
            string key = "PLALicense";
            string filename = "scotopts";
            string fileformat = "dat";

            string value = GetINIConfigurationValue(section, key, filename, fileformat);

            switch (value)
            {
                case "N":
                    return false;
                case "Y":
                    return true;
            }

            return true;
        }

        /// <summary>
        /// Checks if PALicense is configured
        /// </summary>
        /// <returns>Returns true if PA License has been set to Y, false otherwise</returns>
        public bool IsPALicense()
        {
            string section = "Operations";
            string key = "PALicense";
            string filename = "scotopts";
            string fileformat = "dat";

            string value = GetINIConfigurationValue(section, key, filename, fileformat);

            switch (value)
            {
                case "N":
                    return false;
                case "Y":
                    return true;
            }

            return true;
        }
        
        /// <summary>
        /// Checks configuration in PAPLASettings.ini
        /// </summary>
        /// <param name="section">file section</param>
        /// <param name="keyName">file key</param>
        /// <param name="folderName">config folder where PLPLASettings.ini is stored</param>
        /// <returns>Returns true if keyName has been enabled, false otherwise</returns>
        public bool CheckSSBConfig(string section, string keyName, string folderName)
        {
            try
            {
                string settingsFilePath = string.Format(@"C:\sscat\scripts\{0}\PAPLASettings.ini", folderName); ////TODO: improve this, it should not be hardcoded
                string value = FileHelper.GetIniValue(section, keyName, settingsFilePath);

                switch (value)
                {
                    case "N":
                        return false;
                    case "Y":
                        return true;
                }

                return true;
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.Message.ToString());
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checks if NGUI uses NetTCP
        /// </summary>
        /// <returns>Returns true if NGUI uses NetTCP</returns>
        public bool IsNetTCP()
        {
            string networkBinding = FileHelper.GetIniValue("NGUIConnection", "NetworkBinding", ApplicationUtility.SettingsFileName).ToLower();
            LoggingService.Info("NetworkBinding: {0}", networkBinding);
            return networkBinding.Equals("nettcp") ? true : false;
        }

        /// <summary>
        /// Checks if hostname or ipaddress provided is valid
        /// </summary>
        /// <returns>Returns true if valid</returns>
        public bool IsValidHostNameOrIpaddress(string address)
        {
            
            if (address != null)
            {
                UriHostNameType nameType = Uri.CheckHostName(address);

                switch (nameType)
                {
                    case UriHostNameType.IPv4:
                        return true;
                    case UriHostNameType.Dns:
                        try
                        {
                            IPHostEntry ipHost = Dns.GetHostEntry(address);
                            return true;
                        }
                        catch (SocketException ex)
                        {
                            LoggingService.Error("Cannot find address: {0}. Excepton:{1}", address, ex.ToString());
                            return false;
                        }
                }

                LoggingService.Error("Invalid address provided: {0}", address);
            }
            
            return false;
        }

        /// <summary>
        /// Checks if port provided is valid
        /// </summary>
        /// <returns>Returns true if valid</returns>
        public bool IsValidPort(string portConfig)
        {
            int port = 0;
            
            if (Int32.TryParse(portConfig, out port))
            {
                if (port > 1 && port <= 65535)
                {
                    return true;
                }

            }
            LoggingService.Error("Invalid port for net tcp connection. port:{0}", port.ToString());
            return false;
        }
    }
}
