// <copyright file="IIniFileManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the IIniFileManager interface
    /// </summary>
    public interface IIniFileManager
    {
        /// <summary>
        /// Get the string from the path
        /// </summary>
        /// <param name="pathName">path name</param>
        /// <param name="sectionName">section name</param>
        /// <param name="keyName">key name</param>
        /// <returns>Returns the string from the path</returns>
        string GetString(string pathName, string sectionName, string keyName);
    }
}
