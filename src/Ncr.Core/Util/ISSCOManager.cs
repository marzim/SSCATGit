// <copyright file="ISSCOManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the ISSCOManager interface
    /// </summary>
    public interface ISSCOManager
    {
        /// <summary>
        /// Get ADK version
        /// </summary>
        /// <returns>Returns ADK version</returns>
        string GetADKVersion();

        /// <summary>
        /// Get ADD version
        /// </summary>
        /// <returns>Returns ADD version</returns>
        string GetADDVersion();

        /// <summary>
        /// Checks if Next Gen UI
        /// </summary>
        /// <returns>Returns true if NGUI, false otherwise</returns>
        bool IsNGUI();

        /// <summary>
        /// Checks if Next Gen UI
        /// </summary>
        /// <param name="adkVersion">ADK version</param>
        /// <returns>Returns true if NGUI, false otherwise</returns>
        bool IsNGUI(string adkVersion);

        /// <summary>
        /// Checks if CADD
        /// </summary>
        /// <returns>Returns if CADD, false otherwise</returns>
        bool IsCADD();

        /// <summary>
        /// Checks if operator numeric key pad is configured
        /// </summary>
        /// <returns>Returns true if using operator numeric key pad, false otherwise</returns>
        bool IsOperatorNumericKeyPad();

        /// <summary>
        /// Checks if screen is the lane start screen
        /// </summary>
        /// <param name="screen">lane screen</param>
        /// <returns>Returns true if start screen, false otherwise</returns>
        bool IsLaneStartScreen(string screen);

        /// <summary>
        /// Checks if screen is the operator login screen
        /// </summary>
        /// <param name="screen">lane screen</param>
        /// <returns>Returns true if operator login screen, false otherwise</returns>
        bool IsOperatorLoginScreen(string screen);

        /// <summary>
        /// Checks if 64 bit operating system
        /// </summary>
        /// <returns>Returns true if using 64 bit operating system, false otherwise</returns>
        bool Is64BitOperatingSystem();

        /// <summary>
        /// Checks if SSCO type matches
        /// </summary>
        /// <param name="type">the type</param>
        /// <returns>Returns true if SSCO type matches</returns>
        bool IsSSCOType(string type);

        /// <summary>
        /// Checks if Coin Recycler Emulator is Enabled
        /// </summary>
        /// <returns>Returns true if Coin Recycler is Enabled</returns>
        bool IsCoinRecyclerEmulatorEnabled();

        /// <summary>
        /// Checks if Coin Acceptor Emulator is Enabled
        /// </summary>
        /// <returns>Returns true if Coin Acceptor is Enabled</returns>
        bool IsCoinAcceptorEmulatorEnabled();

        /// <summary>
        /// Checks if a Device is Enabled in CADD Configuration
        /// </summary>
        /// <param name="section">registry section</param>
        /// <param name="key">registry key</param>
        /// <returns>Returns true if a Device is Enabled</returns>
        bool IsDeviceEnabled(string section, string key);

        /// <summary>
        /// Get INI Configuration value
        /// </summary>
        /// <param name="section">registry section</param>
        /// <param name="key">registry key</param>
        /// <param name="filename">file name</param>
        /// <param name="fileformat">file format</param>
        /// <returns>Returns INI Configuration value</returns>
        string GetINIConfigurationValue(string section, string key, string filename, string fileformat);

        /// <summary>
        /// Checks config if PALicense is set to Y
        /// </summary>
        /// <returns>returns true if PALicense is set to Y otherwise returns false</returns>
        bool IsPALicense();

        /// <summary>
        /// Checks config if PLALicense is set to Y
        /// </summary>
        /// <returns>returns true if PLALicense is set to Y otherwise returns false</returns>
        bool IsPLALicense();
        
        /// <summary>
        /// Checks config if 
        /// </summary>
        /// <param name="section"> refers to the section header inside the file</param>
        /// <param name="keyName"> refers to the specific key to be checked</param>
        /// <param name="folderName"> scripts config folder name as to which the PAPLASetting.ini is stored</param>
        /// <returns>returns true if specific key is yet to Y otherwise returns false </returns>
        bool CheckSSBConfig(string section, string keyName, string folderName);

        /// <summary>
        /// Checks if NGUI uses NetTCP
        /// </summary>
        /// <returns>Returns true if NGUI uses NetTCP</returns>
        bool IsNetTCP();

        /// <summary>
        /// Checks config if ESA Simulator is set to Y
        /// </summary>
        /// <returns>returns true if ESA Simulator is set to Y otherwise returns false</returns>
        bool IsESASimulator();

        /// <summary>
        /// Checks if Packet Size of PipeServer is in MAXIMUM
        /// </summary>
        /// <returns>Returns true if Packet Size of PipeServer is in MAXIMUM, false otherwise</returns>
        bool IsPipeServerPacketSizeInMaximum();

        /// <summary>
        /// Checks if hostname or ipaddress provided is valid
        /// </summary>
        /// <returns>Returns true if valid</returns>
        bool IsValidHostNameOrIpaddress(string address);

        /// <summary>
        /// Checks if port provided is valid
        /// </summary>
        /// <returns>Returns true if valid</returns>
        bool IsValidPort(string port);

    }
}
