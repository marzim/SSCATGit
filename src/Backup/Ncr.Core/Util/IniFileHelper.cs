// <copyright file="IniFileHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes static members of the IniFileHelper class
    /// </summary>
    public static class IniFileHelper
    {
        /// <summary>
        /// INI file manager interface
        /// </summary>
        private static IIniFileManager _manager;

        /// <summary>
        /// Initializes static members of the IniFileHelper class
        /// </summary>
        static IniFileHelper()
        {
            Attach(new IniFileManager());
        }

        /// <summary>
        /// Attach INI file manager
        /// </summary>
        /// <param name="manager">INI file manager</param>
        public static void Attach(IIniFileManager manager)
        {
            IniFileHelper._manager = manager;
        }

        /// <summary>
        /// Get the string from the path
        /// </summary>
        /// <param name="pathName">path name</param>
        /// <param name="sectionName">section name</param>
        /// <param name="keyName">key name</param>
        /// <returns>Returns the string from the path</returns>
        public static string GetString(string pathName, string sectionName, string keyName)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("SSCOManager");
            }

            return _manager.GetString(pathName, sectionName, keyName);
        }
    }
}
