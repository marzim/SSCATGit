// <copyright file="FileManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Initializes a new instance of the FileManager class
    /// </summary>
    public class FileManager : IFileManager
    {
        /// <summary>
        /// Checks if path exists
        /// </summary>
        /// <param name="path">path name</param>
        /// <returns>Returns true if exists, false otherwise</returns>
        public virtual bool Exists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Create the path
        /// </summary>
        /// <param name="path">path to create</param>
        /// <param name="content">path content</param>
        public virtual void Create(string path, string content)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }

            using (StreamWriter w = new StreamWriter(path))
            {
                w.Write(content);
            }
        }

        /// <summary>
        /// Get the file version
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the file version</returns>
        public virtual Version GetFileVersion(string filename)
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(filename);
            return new Version(versionInfo.FileVersion == null ? "0.0.0.0" : versionInfo.FileVersion);
        }

        /// <summary>
        /// Read to end of the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the file content</returns>
        public virtual string ReadToEnd(string filename)
        {
            string text = string.Empty;
            using (StreamReader reader = new StreamReader(filename))
            {
                text = reader.ReadToEnd();
            }

            return text;
        }

        /// <summary>
        /// Get extension of file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <returns>Returns the file extension</returns>
        public virtual string GetExtension(string filePath)
        {
            return Path.GetExtension(filePath);
        }

        /// <summary>
        /// Get the INI value
        /// </summary>
        /// <param name="section">section name</param>
        /// <param name="keyName">key name</param>
        /// <param name="filePath">file path</param>
        /// <returns>Returns the INI value</returns>
        public virtual string GetIniValue(string section, string keyName, string filePath)
        {
            StringBuilder keyValue = new StringBuilder(255);
            int i = GetPrivateProfileString(section, keyName, string.Empty, keyValue, 255, filePath);
            return keyValue.ToString();
        }

        /// <summary>
        /// Write INI value
        /// </summary>
        /// <param name="section">section name</param>
        /// <param name="keyName">key name</param>
        /// <param name="keyValue">key value</param>
        /// <param name="filePath">file path</param>
        public virtual void WriteIniValue(string section, string keyName, string keyValue, string filePath)
        {
            WritePrivateProfileString(section, keyName, keyValue, filePath);
        }

        /// <summary>
        /// Create the path
        /// </summary>
        /// <param name="path">path to create</param>
        public virtual void Create(string path)
        {
            Create(path, string.Empty);
        }

        /// <summary>
        /// Copy from source to destination
        /// </summary>
        /// <param name="source">source to copy from</param>
        /// <param name="destination">destination to copy to</param>
        public virtual void Copy(string source, string destination)
        {
            if (!Directory.Exists(Path.GetDirectoryName(destination)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(destination));
            }

            if (File.Exists(source))
            {
                File.Copy(source, destination, true);
            }
            else
            {
                throw new Exception(string.Format("FileHelper.Copy :: Source file {0} does not exist", source));
            }
        }

        /// <summary>
        /// Delete given path
        /// </summary>
        /// <param name="path">path name</param>
        public virtual void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Delete all files in given directory
        /// </summary>
        /// <param name="directory">directory to check</param>
        public virtual void DeleteAll(string directory)
        {
            if (Directory.Exists(directory))
            {
                foreach (string file in Directory.GetFiles(directory, "*"))
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }
            }
        }

        /// <summary>
        /// Checks if file name is valid
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns valid file name</returns>
        public virtual bool ValidFileName(string filename)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                if (filename.IndexOf(c) >= 0)
                {
                    return false;
                }
            }

            return true;
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string keyName, string keyValue, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string keyName, string def, StringBuilder retVal, int size, string filePath);
    }
}
