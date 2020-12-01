// <copyright file="RegistryHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Win32;

    /// <summary>
    /// Initializes static members of the RegistryHelper class
    /// </summary>
    public static class RegistryHelper
    {
        /// <summary>
        /// Registry manager interface
        /// </summary>
        private static IRegistryManager _manager;

        /// <summary>
        /// Initializes static members of the RegistryHelper class
        /// </summary>
        static RegistryHelper()
        {
            Attach(new RegistryManager());
        }

        /// <summary>
        /// Attach registry manager
        /// </summary>
        /// <param name="manager">registry manager</param>
        public static void Attach(IRegistryManager manager)
        {
            RegistryHelper._manager = manager;
        }

        /// <summary>
        /// Open sub key
        /// </summary>
        /// <param name="key">registry key</param>
        /// <param name="name">key name</param>
        /// <returns>Returns the registry key</returns>
        public static RegistryKey OpenSubKey(RegistryKey key, string name)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("RegistryManager");
            }

            return _manager.OpenSubKey(key, name);
        }

        /// <summary>
        /// Checks if registry key exists
        /// </summary>
        /// <param name="key">key name</param>
        /// <param name="subKey">registry sub key</param>
        /// <returns>Returns true if exists, false otherwise</returns>
        public static bool Exists(string key, RegistryKey subKey)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("RegistryManager");
            }

            return _manager.Exists(key, subKey);
        }

        /// <summary>
        /// Get value from registry
        /// </summary>
        /// <param name="name">key name</param>
        /// <param name="subKey">registry sub key</param>
        /// <returns>Returns registry value</returns>
        public static string GetValue(string name, RegistryKey subKey)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("RegistryManager");
            }

            return _manager.GetValue(name, subKey);
        }

        /// <summary>
        /// Get value from registry
        /// </summary>
        /// <param name="name">key name</param>
        /// <param name="subKey">registry sub key</param>
        /// <param name="defaultValue">default value</param>
        /// <returns>Returns registry value</returns>
        public static string GetValue(string name, RegistryKey subKey, string defaultValue)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("RegistryManager");
            }

            return _manager.GetValue(name, subKey, defaultValue);
        }

        /// <summary>
        /// Get value from registry
        /// </summary>
        /// <param name="key">key name</param>
        /// <param name="subKey">registry sub key</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="disregardComments">whether or not to disregard comments</param>
        /// <returns>Returns registry value</returns>
        public static string GetValue(string key, RegistryKey subKey, string defaultValue, bool disregardComments)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("RegistryManager");
            }

            return _manager.GetValue(key, subKey, defaultValue, disregardComments);
        }

        /// <summary>
        /// Set string value
        /// </summary>
        /// <param name="keyName">key name</param>
        /// <param name="keyValueName">key value name</param>
        /// <param name="keyValueData">key value data</param>
        public static void SetStringValue(string keyName, string keyValueName, string keyValueData)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("RegistryManager");
            }

            _manager.SetStringValue(keyName, keyValueName, keyValueData);
        }

        /// <summary>
        /// Set string value
        /// </summary>
        /// <param name="keyName">key name</param>
        /// <param name="keyValueName">key value name</param>
        /// <param name="keyValueData">key value data</param>
        /// <param name="overwrite">whether or not to overwrite previous value</param>
        public static void SetStringValue(string keyName, string keyValueName, string keyValueData, bool overwrite)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("RegistryManager");
            }

            _manager.SetStringValue(keyName, keyValueName, keyValueData, overwrite);
        }

        /// <summary>
        /// Delete the sub key
        /// </summary>
        /// <param name="subKey">sub key</param>
        public static void DeleteSubKey(string subKey)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("RegistryManager");
            }

            _manager.DeleteSubKey(subKey);
        }

        /// <summary>
        /// Get the sub key names
        /// </summary>
        /// <param name="key">key name</param>
        /// <returns>Returns the sub key names</returns>
        public static string[] GetSubKeyNames(string key)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("RegistryManager");
            }

            return _manager.GetSubKeyNames(key);
        }

        /// <summary>
        /// Get the sub key names
        /// </summary>
        /// <param name="key">key name</param>
        /// <param name="subKeyNameContains">sub key name contains</param>
        /// <returns>Returns the sub key names</returns>
        public static List<string> GetSubKeyNames(string key, string subKeyNameContains)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("RegistryManager");
            }

            return _manager.GetSubKeyNames(key, subKeyNameContains);
        }
    }
}
