// <copyright file="IWindowAppManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the IWindowAppManager interface
    /// </summary>
    public interface IWindowAppManager
    {
        /// <summary>
        /// Event handler for in process
        /// </summary>
        event EventHandler<SscatEventArgs> InProcess;

        /// <summary>
        /// Window Application exit
        /// </summary>
        /// <param name="windowTitle">window title</param>
        void WindowAppExit(string windowTitle);

        /// <summary>
        /// Get text
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the text</returns>
        string GetText(string filename); // TODO: Transfer to a different helper

        /// <summary>
        /// Check the diagnostic file
        /// </summary>
        /// <param name="time">diagnostics time</param>
        /// <param name="timeout">time out</param>
        /// <returns>Returns the file path</returns>
        string CheckDiagnosticFile(int time, int timeout);

        /// <summary>
        /// Writes message to file
        /// </summary>
        /// <param name="writeFile">write file</param>
        /// <param name="readFile">read file</param>
        /// <param name="message">message to write</param>
        void WriteFile(string writeFile, string readFile, string message);

        /// <summary>
        /// Get last written file
        /// </summary>
        /// <param name="path">file path</param>
        /// <param name="pattern">pattern to check for</param>
        /// <returns>Returns the last written file</returns>
        string GetLastWrittenFile(string path, string pattern);

        /// <summary>
        /// Automatically push the diagnostic files
        /// </summary>
        void AutoPushDiagFiles();

        /// <summary>
        /// Get diagnostic files results
        /// </summary>
        void GetDiagnosticFilesResults();
    }
}
