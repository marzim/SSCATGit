// <copyright file="FileHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.IO;

    /// <summary>
    /// Initializes static members of the FileHelper class
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// File manager interface
        /// </summary>
        private static IFileManager _manager;

        /// <summary>
        /// Dump product version
        /// </summary>
        private static string _dumpProductVersion;

        /// <summary>
        /// Initializes static members of the FileHelper class
        /// </summary>
        static FileHelper()
        {
            Attach(new FileManager());
        }

        /// <summary>
        /// Gets or sets the dump product version
        /// </summary>
        public static string DumpProductVersion
        {
            get { return _dumpProductVersion; }
            set { _dumpProductVersion = value; }
        }

        /// <summary>
        /// Attach file manager
        /// </summary>
        /// <param name="manager">file manager</param>
        public static void Attach(IFileManager manager)
        {
            FileHelper._manager = manager;
        }

        /// <summary>
        /// Get the file version
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the file version</returns>
        public static Version GetFileVersion(string filename)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("FileManager");
            }

            return _manager.GetFileVersion(filename);
        }

        /// <summary>
        /// Read to end of the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the file content</returns>
        public static string ReadToEnd(string filename)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("FileManager");
            }

            return _manager.ReadToEnd(filename);
        }

        /// <summary>
        /// Get extension of file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>Returns the file extension</returns>
        public static string GetExtension(string filePath)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("FileManager");
            }

            return _manager.GetExtension(filePath);
        }

        /// <summary>
        /// Get the INI value
        /// </summary>
        /// <param name="section">section name</param>
        /// <param name="keyName">key name</param>
        /// <param name="filePath">file path</param>
        /// <returns>Returns the INI value</returns>
        public static string GetIniValue(string section, string keyName, string filePath)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("FileManager");
            }

            return _manager.GetIniValue(section, keyName, filePath);
        }

        /// <summary>
        /// Write INI value
        /// </summary>
        /// <param name="section">section name</param>
        /// <param name="keyName">key name</param>
        /// <param name="keyValue">key value</param>
        /// <param name="filePath">file path</param>
        public static void WriteIniValue(string section, string keyName, string keyValue, string filePath)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("FileManager");
            }

            _manager.WriteIniValue(section, keyName, keyValue, filePath);
        }

        /// <summary>
        /// Create the path
        /// </summary>
        /// <param name="path">path to create</param>
        public static void Create(string path)
        {
            Create(path, string.Empty);
        }

        /// <summary>
        /// Create the path
        /// </summary>
        /// <param name="path">path to create</param>
        /// <param name="content">path content</param>
        public static void Create(string path, string content)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("FileManager");
            }

            _manager.Create(path, content);
        }

        /// <summary>
        /// Checks if path exists
        /// </summary>
        /// <param name="path">path name</param>
        /// <returns>Returns true if exists, false otherwise</returns>
        public static bool Exists(string path)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("FileManager");
            }

            return _manager.Exists(path);
        }

        /// <summary>
        /// Delete given path
        /// </summary>
        /// <param name="path">path name</param>
        public static void Delete(string path)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("FileManager");
            }

            _manager.Delete(path);
        }

        /// <summary>
        /// Delete all files in given directory
        /// </summary>
        /// <param name="directory">directory to check</param>
        public static void DeleteAll(string directory)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("FileManager");
            }

            _manager.DeleteAll(directory);
        }
        
        /// <summary>
        /// Checks if file name is valid
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns valid file name</returns>
        public static bool ValidFileName(string filename)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("FileManager");
            }

            return _manager.ValidFileName(filename);
        }

        /// <summary>
        /// Copy from source to destination
        /// </summary>
        /// <param name="source">source to copy from</param>
        /// <param name="destination">destination to copy to</param>
        public static void Copy(string source, string destination)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("FileManager");
            }

            _manager.Copy(source, destination);
        }

        /// <summary>
        /// Reads the NCR Registry Dump File File and parses out the release version
        /// </summary>
        /// <param name="fileToRead">file to read</param>
        public static void SetDumpProductVersion(string fileToRead)
        {
            using (FileStream fs = File.Open(fileToRead, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("Release Version"))
                    {
                        _dumpProductVersion = line.Replace("\"", string.Empty).Replace("Release Version=", string.Empty);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the product version from the NCR Registry Dump File
        /// </summary>
        /// <returns>Returns the product version from the NCR Registry Dump File</returns>
        public static string GetDumpProductVersion()
        {
            return _dumpProductVersion;
        }
    }
}
