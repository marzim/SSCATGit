// <copyright file="IniFileManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Initializes a new instance of the IniFileManager class
    /// </summary>
    public class IniFileManager : IIniFileManager
    {
        /// <summary>
        /// Max section size
        /// </summary>
        private const int MAX_SECTION_SIZE = 32767; // 32 KB

        /// <summary>
        /// Default value
        /// </summary>
        private string _defaultValue = string.Empty;

        /// <summary>
        /// Get the string from the path
        /// </summary>
        /// <param name="pathName">path name</param>
        /// <param name="sectionName">section name</param>
        /// <param name="keyName">key name</param>
        /// <returns>Returns the string from the path</returns>
        public string GetString(string pathName, string sectionName, string keyName)
        {
            pathName = Path.GetFullPath(pathName);
            if (sectionName == null)
            {
                throw new ArgumentNullException("sectionName");
            }

            if (keyName == null)
            {
                throw new ArgumentNullException("keyName");
            }

            StringBuilder retval = new StringBuilder(MAX_SECTION_SIZE);

            NativeMethods.GetPrivateProfileString(sectionName, keyName, _defaultValue, retval, MAX_SECTION_SIZE, pathName);

            return retval.ToString();
        }

        /// <summary>
        /// Write the string from the path
        /// </summary>
        /// <param name="pathName">path name</param>
        /// <param name="sectionName">section name</param>
        /// <param name="keyName">key name</param>
        /// <param name="value">string value to write</param>
        public void SetString(string pathName, string sectionName, string keyName, string value)
        {
            NativeMethods.WritePrivateProfileString(sectionName, keyName, value, pathName);
        }
    }
}