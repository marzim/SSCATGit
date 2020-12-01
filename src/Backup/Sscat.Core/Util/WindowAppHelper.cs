// <copyright file="WindowAppHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the WindowAppHelper class
    /// </summary>
    public static class WindowAppHelper
    {
        /// <summary>
        /// Interface for the Window Application Manager
        /// </summary>
        private static IWindowAppManager manager;

        /// <summary>
        /// Initializes static members of the WindowAppHelper class
        /// </summary>
        static WindowAppHelper()
        {
            Attach(new WindowAppManager(new XmlLaunchPadConfigRepository()));
        }

        /// <summary>
        /// Event handler for diagnostics in process
        /// </summary>
        public static event EventHandler<SscatEventArgs> DiagnosticsInProcess;

        /// <summary>
        /// Attach manager
        /// </summary>
        /// <param name="manager">Windows application manager</param>
        public static void Attach(IWindowAppManager manager)
        {
            WindowAppHelper.manager = manager;
        }

        /// <summary>
        /// Window Application exit
        /// </summary>
        /// <param name="windowTitle">window title</param>
        public static void WindowAppExit(string windowTitle)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("LaunchPadManager");
            }

            try
            {
                manager.InProcess += new EventHandler<SscatEventArgs>(ManagerInProcess);
                manager.WindowAppExit(windowTitle);
            }
            catch
            {
                throw;
            }
            finally
            {
                manager.InProcess -= new EventHandler<SscatEventArgs>(ManagerInProcess);
            }
        }
        
        /// <summary>
        /// Get text
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the text</returns>
        public static string GetText(string filename)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("LaunchPadManager");
            }

            string text = string.Empty;

            try
            {
                manager.InProcess += new EventHandler<SscatEventArgs>(ManagerInProcess);
                text = manager.GetText(filename);
            }
            catch
            {
                throw;
            }
            finally
            {
                manager.InProcess -= new EventHandler<SscatEventArgs>(ManagerInProcess);
            }

            return text;
        }

        /// <summary>
        /// Check the diagnostic file
        /// </summary>
        /// <param name="time">diagnostics time</param>
        /// <param name="timeout">time out</param>
        /// <returns>Returns the file path</returns>
        public static string CheckDiagnosticFile(int time, int timeout)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("LaunchPadManager");
            }

            string file = string.Empty;

            try
            {
                manager.InProcess += new EventHandler<SscatEventArgs>(ManagerInProcess);
                file = manager.CheckDiagnosticFile(time, timeout);
            }
            catch
            {
                throw;
            }
            finally
            {
                manager.InProcess -= new EventHandler<SscatEventArgs>(ManagerInProcess);
            }

            return file;
        }

        /// <summary>
        /// Writes message to file
        /// </summary>
        /// <param name="writeFile">write file</param>
        /// <param name="readFile">read file</param>
        /// <param name="message">message to write</param>
        public static void WriteFile(string writeFile, string readFile, string message)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("LaunchPadManager");
            }

            try
            {
                manager.InProcess += new EventHandler<SscatEventArgs>(ManagerInProcess);
                manager.WriteFile(writeFile, readFile, message);
            }
            catch
            {
                throw;
            }
            finally
            {
                manager.InProcess -= new EventHandler<SscatEventArgs>(ManagerInProcess);
            }
        }

        /// <summary>
        /// Get last written file
        /// </summary>
        /// <param name="path">file path</param>
        /// <param name="pattern">pattern to check for</param>
        /// <returns>Returns the last written file</returns>
        public static string GetLastWrittenFile(string path, string pattern)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("LaunchPadManager");
            }

            string file = string.Empty;

            try
            {
                manager.InProcess += new EventHandler<SscatEventArgs>(ManagerInProcess);
                file = manager.GetLastWrittenFile(path, pattern);
            }
            catch
            {
                throw;
            }
            finally
            {
                manager.InProcess -= new EventHandler<SscatEventArgs>(ManagerInProcess);
            }

            return file;
        }

        /// <summary>
        /// Automatically push the diagnostic files
        /// </summary>
        public static void AutoPushDiagFiles()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("LaunchPadManager");
            }

            try
            {
                manager.InProcess += new EventHandler<SscatEventArgs>(ManagerInProcess);
                manager.AutoPushDiagFiles();
            }
            catch
            {
                throw;
            }
            finally
            {
                manager.InProcess -= new EventHandler<SscatEventArgs>(ManagerInProcess);
            }
        }

        /// <summary>
        /// Get diagnostic files results
        /// </summary>
        public static void GetDiagnosticFilesResults()
        {
            if (manager == null)
            {
                throw new ArgumentNullException("LaunchPadManager");
            }

            try
            {
                manager.InProcess += new EventHandler<SscatEventArgs>(ManagerInProcess);
                manager.GetDiagnosticFilesResults();
            }
            catch
            {
                throw;
            }
            finally
            {
                manager.InProcess -= new EventHandler<SscatEventArgs>(ManagerInProcess);
            }
        }

        /// <summary>
        /// Event for on diagnostics in process
        /// </summary>
        /// <param name="e">sscat event arguments</param>
        private static void OnDiagnosticsInProcess(SscatEventArgs e)
        {
            if (DiagnosticsInProcess != null)
            {
                DiagnosticsInProcess(null, e);
            }
        }

        /// <summary>
        /// Event for manager in process
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">sscat event arguments</param>
        private static void ManagerInProcess(object sender, SscatEventArgs e)
        {
            OnDiagnosticsInProcess(e);
        }
    }
}
