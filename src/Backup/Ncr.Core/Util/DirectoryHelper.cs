// <copyright file="DirectoryHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the DirectoryHelper class
    /// </summary>
    public static class DirectoryHelper
    {
        /// <summary>
        /// Directory manager interface
        /// </summary>
        private static IDirectoryManager manager;

        /// <summary>
        /// Initializes static members of the DirectoryHelper class
        /// </summary>
        static DirectoryHelper()
        {
            Attach(new DirectoryManager());
        }

        /// <summary>
        /// Attach directory manager
        /// </summary>
        /// <param name="manager">directory manager</param>
        public static void Attach(IDirectoryManager manager)
        {
            DirectoryHelper.manager = manager;
        }

        /// <summary>
        /// Get directories from given path
        /// </summary>
        /// <param name="path">directories path</param>
        /// <returns>Returns the directories</returns>
        public static string[] GetDirectories(string path)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("DirectoryManager");
            }

            return manager.GetDirectories(path);
        }

        /// <summary>
        /// Get the current directory
        /// </summary>
        /// <returns>Returns the current directory</returns>
        public static string GetCurrentDirectory()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("DirectoryManager");
            }

            return manager.GetCurrentDirectory();
        }

        /// <summary>
        /// Set current directory
        /// </summary>
        /// <param name="dir">current directory</param>
        public static void SetCurrentDirectory(string dir)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("DirectoryManager");
            }

            manager.SetCurrentDirectory(dir);
        }

        /// <summary>
        /// Get files
        /// </summary>
        /// <param name="path">path name</param>
        /// <param name="searchPattern">search pattern</param>
        /// <returns>Returns the files from the path with given search pattern</returns>
        public static string[] GetFiles(string path, string searchPattern)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("DirectoryManager");
            }

            return manager.GetFiles(path, searchPattern);
        }

        /// <summary>
        /// Create directory
        /// </summary>
        /// <param name="dir">directory to create</param>
        public static void CreateDirectory(string dir)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("DirectoryManager");
            }

            manager.CreateDirectory(dir);
        }

        /// <summary>
        /// Check for directory's existence
        /// </summary>
        /// <param name="dir">directory to check</param>
        /// <returns>Returns true if it exists, false otherwise</returns>
        public static bool Exists(string dir)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("DirectoryManager");
            }

            return manager.Exists(dir);
        }

        /// <summary>
        /// Delete directory
        /// </summary>
        /// <param name="dir">directory to delete</param>
        public static void DeleteDirectory(string dir)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("DirectoryManager");
            }

            manager.DeleteDirectory(dir);
        }
    }
}
