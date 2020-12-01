// <copyright file="IFileManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the IFileManager interface
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Checks if path exists
        /// </summary>
        /// <param name="path">path name</param>
        /// <returns>Returns true if exists, false otherwise</returns>
        bool Exists(string path);

        /// <summary>
        /// Copy from source to destination
        /// </summary>
        /// <param name="source">source to copy from</param>
        /// <param name="destination">destination to copy to</param>
        void Copy(string source, string destination);

        /// <summary>
        /// Delete given path
        /// </summary>
        /// <param name="path">path name</param>
        void Delete(string path);

        /// <summary>
        /// Delete all files in given directory
        /// </summary>
        /// <param name="directory">directory to check</param>
        void DeleteAll(string directory);

        /// <summary>
        /// Create the path
        /// </summary>
        /// <param name="path">path to create</param>
        void Create(string path);

        /// <summary>
        /// Create the path
        /// </summary>
        /// <param name="path">path to create</param>
        /// <param name="content">path content</param>
        void Create(string path, string content);

        /// <summary>
        /// Write INI value
        /// </summary>
        /// <param name="section">section name</param>
        /// <param name="keyName">key name</param>
        /// <param name="keyValue">key value</param>
        /// <param name="filePath">file path</param>
        void WriteIniValue(string section, string keyName, string keyValue, string filePath);

        /// <summary>
        /// Checks if file name is valid
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns valid file name</returns>
        bool ValidFileName(string filename);

        /// <summary>
        /// Read to end of the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the file content</returns>
        string ReadToEnd(string filename);

        /// <summary>
        /// Get extension of file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>Returns the file extension</returns>
        string GetExtension(string filePath);

        /// <summary>
        /// Get the INI value
        /// </summary>
        /// <param name="section">section name</param>
        /// <param name="keyName">key name</param>
        /// <param name="filePath">file path</param>
        /// <returns>Returns the INI value</returns>
        string GetIniValue(string section, string keyName, string filePath);

        /// <summary>
        /// Get the file version
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the file version</returns>
        Version GetFileVersion(string filename);
    }
}
