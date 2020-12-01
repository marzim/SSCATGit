// <copyright file="DirectoryManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.IO;
    
    /// <summary>
    /// Initializes a new instance of the DirectoryManager class
    /// </summary>
    public class DirectoryManager : IDirectoryManager
    {
        /// <summary>
        /// Get files from path with given search pattern
        /// </summary>
        /// <param name="path">path name</param>
        /// <param name="searchPattern">search pattern</param>
        /// <returns>Returns the files from the path with the given search pattern</returns>
        public string[] GetFiles(string path, string searchPattern)
        {
            if (!Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return Directory.GetFiles(path, searchPattern);
        }

        /// <summary>
        /// Create directory
        /// </summary>
        /// <param name="dir">directory to create</param>
        public void CreateDirectory(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        /// <summary>
        /// Set current directory
        /// </summary>
        /// <param name="dir">current directory</param>
        public void SetCurrentDirectory(string dir)
        {
            Directory.SetCurrentDirectory(dir);
        }

        /// <summary>
        /// Check for directory's existence
        /// </summary>
        /// <param name="dir">directory to check</param>
        /// <returns>Returns true if it exists, false otherwise</returns>
        public bool Exists(string dir)
        {
            return Directory.Exists(dir);
        }

        /// <summary>
        /// Delete directory
        /// </summary>
        /// <param name="dir">directory to delete</param>
        public void DeleteDirectory(string dir)
        {
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }
        }

        /// <summary>
        /// Get the current directory
        /// </summary>
        /// <returns>Returns the current directory</returns>
        public string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Get directories from given path
        /// </summary>
        /// <param name="path">directories path</param>
        /// <returns>Returns the directories</returns>
        public string[] GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }
    }
}
