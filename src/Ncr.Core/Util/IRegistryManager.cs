// <copyright file="IRegistryManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Collections.Generic;
    using Microsoft.Win32;

    /// <summary>
    /// Initializes a new instance of the IRegistryManager interface
    /// </summary>
    public interface IRegistryManager
    {
        /// <summary>
        /// Checks if registry key exists
        /// </summary>
        /// <param name="key">key name</param>
        /// <param name="subKey">registry sub key</param>
        /// <returns>Returns true if exists, false otherwise</returns>
        bool Exists(string key, RegistryKey subKey);

        /// <summary>
        /// Get value from registry
        /// </summary>
        /// <param name="key">key name</param>
        /// <param name="subKey">registry sub key</param>
        /// <returns>Returns registry value</returns>
        string GetValue(string key, RegistryKey subKey);

        /// <summary>
        /// Get value from registry
        /// </summary>
        /// <param name="key">key name</param>
        /// <param name="subKey">registry sub key</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>Returns registry value</returns>
        string GetValue(string key, RegistryKey subKey, string defaultValue);

        /// <summary>
        /// Get value from registry
        /// </summary>
        /// <param name="key">key name</param>
        /// <param name="subKey">registry sub key</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="disregardComments">whether or not to disregard comments</param>
        /// <returns>Returns registry value</returns>
        string GetValue(string key, RegistryKey subKey, string defaultValue, bool disregardComments);

        /// <summary>
        /// Set string value
        /// </summary>
        /// <param name="keyName">key name</param>
        /// <param name="keyValueName">key value name</param>
        /// <param name="keyValueData">key value data</param>
        void SetStringValue(string keyName, string keyValueName, string keyValueData);

        /// <summary>
        /// Set string value
        /// </summary>
        /// <param name="keyName">key name</param>
        /// <param name="keyValueName">key value name</param>
        /// <param name="keyValueData">key value data</param>
        /// <param name="overwrite">whether or not to overwrite previous value</param>
        void SetStringValue(string keyName, string keyValueName, string keyValueData, bool overwrite);

        /// <summary>
        /// Delete the sub key
        /// </summary>
        /// <param name="subKey">sub key</param>
        void DeleteSubKey(string subKey);

        /// <summary>
        /// Get the sub key names
        /// </summary>
        /// <param name="key">key name</param>
        /// <returns>Returns the sub key names</returns>
        string[] GetSubKeyNames(string key);

        /// <summary>
        /// Get the sub key names
        /// </summary>
        /// <param name="key">key name</param>
        /// <param name="subKeyNameContains">sub key name contains</param>
        /// <returns>Returns the sub key names</returns>
        List<string> GetSubKeyNames(string key, string subKeyNameContains);

        /// <summary>
        /// Open sub key
        /// </summary>
        /// <param name="key">registry key</param>
        /// <param name="name">key name</param>
        /// <returns>Returns the registry key</returns>
        RegistryKey OpenSubKey(RegistryKey key, string name);
    }
}
