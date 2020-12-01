// <copyright file="IDirectoryManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the IDirectoryManager interface
    /// </summary>
    public interface IDirectoryManager
    {
        /// <summary>
        /// Get files from path with given search pattern
        /// </summary>
        /// <param name="path">path name</param>
        /// <param name="searchPattern">search pattern</param>
        /// <returns>Returns the files from the path with the given search pattern</returns>
        string[] GetFiles(string path, string searchPattern);

        /// <summary>
        /// Create directory
        /// </summary>
        /// <param name="dir">directory to create</param>
        void CreateDirectory(string dir);

        /// <summary>
        /// Delete directory
        /// </summary>
        /// <param name="dir">directory to delete</param>
        void DeleteDirectory(string dir);

        /// <summary>
        /// Check for directory's existence
        /// </summary>
        /// <param name="dir">directory to check</param>
        /// <returns>Returns true if it exists, false otherwise</returns>
        bool Exists(string dir);

        /// <summary>
        /// Set current directory
        /// </summary>
        /// <param name="dir">current directory</param>
        void SetCurrentDirectory(string dir);

        /// <summary>
        /// Get the current directory
        /// </summary>
        /// <returns>Returns the current directory</returns>
        string GetCurrentDirectory();

        /// <summary>
        /// Get directories from given path
        /// </summary>
        /// <param name="path">directories path</param>
        /// <returns>Returns the directories</returns>
        string[] GetDirectories(string path);
    }
}
