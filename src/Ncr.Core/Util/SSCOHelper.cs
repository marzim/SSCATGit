﻿// <copyright file="SSCOHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes static members of the SSCOHelper class
    /// </summary>
    public static class SSCOHelper
    {
        /// <summary>
        /// SSCO manager
        /// </summary>
        private static ISSCOManager manager;

        /// <summary>
        /// Initializes static members of the SSCOHelper class
        /// </summary>
        static SSCOHelper()
        {
            Attach(new SSCOManager());
        }

        /// <summary>
        /// Attach the SSCO manager
        /// </summary>
        /// <param name="manager">SSCO manager</param>
        public static void Attach(ISSCOManager manager)
        {
            SSCOHelper.manager = manager;
        }

        /// <summary>
        /// Get ADK version
        /// </summary>
        /// <returns>Returns ADK version</returns>
        public static string GetADKVersion()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.GetADKVersion();
        }
        
        /// <summary>
        /// Get ADD version
        /// </summary>
        /// <returns>Returns ADD version</returns>
        public static string GetADDVersion()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.GetADDVersion();
        }

        /// <summary>
        /// Checks if Next Gen UI
        /// </summary>
        /// <returns>Returns true if NGUI, false otherwise</returns>
        public static bool IsNGUI()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsNGUI();
        }

        /// <summary>
        /// Checks if Next Gen UI
        /// </summary>
        /// <param name="adkVersion">ADK version</param>
        /// <returns>Returns true if NGUI, false otherwise</returns>
        public static bool IsNGUI(string adkVersion)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsNGUI(adkVersion);
        }

        /// <summary>
        /// Checks if CADD
        /// </summary>
        /// <returns>Returns if CADD, false otherwise</returns>
        public static bool IsCADD()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsCADD();
        }

        /// <summary>
        /// Checks if operator numeric key pad is configured
        /// </summary>
        /// <returns>Returns true if using operator numeric key pad, false otherwise</returns>
        public static bool IsOperatorNumericKeyPad()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsOperatorNumericKeyPad();
        }

        /// <summary>
        /// Checks if screen is the lane start screen
        /// </summary>
        /// <param name="screen">lane screen</param>
        /// <returns>Returns true if start screen, false otherwise</returns>
        public static bool IsLaneStartScreen(string screen)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsLaneStartScreen(screen);
        }

        /// <summary>
        /// Checks if screen is the operator login screen
        /// </summary>
        /// <param name="screen">lane screen</param>
        /// <returns>Returns true if operator login screen, false otherwise</returns>
        public static bool IsOperatorLoginScreen(string screen)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsOperatorLoginScreen(screen);
        }

        /// <summary>
        /// Checks if 64 bit operating system
        /// </summary>
        /// <returns>Returns true if using 64 bit operating system, false otherwise</returns>
        public static bool Is64BitOperatingSystem()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.Is64BitOperatingSystem();
        }

        /// <summary>
        /// Checks if SSCO types matches
        /// </summary>
        /// <param name="type">type of SSCO</param>
        /// <returns>Returns true if SSCO type matches</returns>
        public static bool IsSSCOType(string type)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsSSCOType(type);
        }

        /// <summary>
        /// Checks if Coin Recycler Emulator is Enabled
        /// </summary>
        /// <returns>Returns true if Coin Recycler is Enabled</returns>
        public static bool IsCoinRecyclerEmulatorEnabled()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsCoinRecyclerEmulatorEnabled();
        }

        /// <summary>
        /// Checks if Coin Acceptor Emulator is Enabled
        /// </summary>
        /// <returns>Returns true if Coin Acceptor is Enabled</returns>
        public static bool IsCoinAcceptorEmulatorEnabled()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsCoinAcceptorEmulatorEnabled();
        }

        /// <summary>
        /// Checks if a Device is Enabled in CADD Configuration
        /// </summary>
        /// <param name="section">registry section</param>
        /// <param name="key">registry key</param>
        /// <returns>Returns true if a Device is Enabled</returns>
        public static bool IsDeviceEnabled(string section, string key)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsDeviceEnabled(section, key);
        }

        /// <summary>
        /// Get INI Configuration value
        /// </summary>
        /// <param name="section">registry section</param>
        /// <param name="key">registry key</param>
        /// <param name="filename">file name</param>
        /// <param name="fileformat">file format</param>
        /// <returns>Returns INI Configuration value</returns>
        public static string GetINIConfigurationValue(string section, string key, string filename, string fileformat)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.GetINIConfigurationValue(section, key, filename, fileformat);
        }

        /// <summary>
        /// Check PALicense Config
        /// </summary>
        /// <returns>returns the value given by the IsPLALicense</returns>
        public static bool IsPALicense()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsPALicense();
        }

        /// <summary>
        /// Check PLALicense Config
        /// </summary>
        /// <returns>returns the value given by the IsPLALicense</returns>
        public static bool IsPLALicense()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsPLALicense();
        }

        /// <summary>
        /// Check ESA Simulator Config
        /// </summary>
        /// <returns>returns the value given by the ESA Simulator</returns>
        public static bool IsESASimulator()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsESASimulator();
        }

        /// <summary>
        /// Check Packet Size of Pipe Server
        /// </summary>
        /// <returns>returns the value if packet size is maximum for Pipe Server</returns>
        public static bool IsPipeServerPacketSizeMaximum()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsPipeServerPacketSizeInMaximum();
        }

        /// <summary>
        /// Check PLALicense Config
        /// </summary>
        /// <param name="section">refers to the header of settings</param>
        /// <param name="keyName">points to the specific key that needs to be checked </param>
        /// <param name="folderName"> script config folder name as to where PAPLASettings.ini is stored </param>
        /// <returns>returns the value given by the CheckSSBConfig</returns>
        public static bool CheckSSBConfig(string section, string keyName, string folderName)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.CheckSSBConfig(section, keyName, folderName);
        }

        /// <summary>
        /// Checks if NGUI uses NetTCP
        /// </summary>
        /// <returns>Returns true if NGUI uses NetTCP</returns>
        public static bool IsNetTCP()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsNetTCP();
        }

        /// <summary>
        /// Checks if hostname or ipaddress provided is valid
        /// </summary>
        /// <returns>Returns true if valid</returns>
        public static bool IsValidHostNameOrIpaddress(string address)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsValidHostNameOrIpaddress(address);
        }

        /// <summary>
        /// Checks if port provided is valid
        /// </summary>
        /// <returns>Returns true if valid</returns>
        public static bool IsValidPort(string port)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return manager.IsValidPort(port);
        }
    }
}