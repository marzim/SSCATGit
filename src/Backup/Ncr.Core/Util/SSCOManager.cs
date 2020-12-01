// <copyright file="SSCOManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Win32;

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
            string settingsFilePath = @"C:\sscat\config\Settings.ini"; ////TODO: improved this, it should not be hardcoded
            string sscoType = FileHelper.GetIniValue("SSCOApplication", "SSCOType", settingsFilePath);

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
    }
}