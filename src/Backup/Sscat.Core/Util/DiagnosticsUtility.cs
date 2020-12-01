// <copyright file="DiagnosticsUtility.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;
    using System.IO;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the DiagnosticsUtility class
    /// </summary>
    public class DiagnosticsUtility
    {
        /// <summary>
        /// Diagnostics file
        /// </summary>
        private string _diagFile = @"C:\scot\config\DiagFile.ini";

        /// <summary>
        /// Diagnostics file backup
        /// </summary>
        private string _diagFileBak = @"C:\scot\config\DiagFile.ini.sscat";

        /// <summary>
        /// Diagnostics path
        /// </summary>
        private string _diagPath = @"C:\SSCAT\Tools\DiagFile.ini";

        /// <summary>
        /// Diagnostics temporary path
        /// </summary>
        private string _diagPathTemp = @"C:\SSCAT\Tools\DiagFile.ini.sscat";

        /// <summary>
        /// Event handler for diagnostics in process
        /// </summary>
        public event EventHandler<SscatEventArgs> DiagnosticsInProcess;

        /// <summary>
        /// Get diagnostics
        /// </summary>
        /// <param name="diagpath">diagnostics path</param>
        /// <param name="screenshotpath">screenshot path</param>
        /// <param name="temppath">temporary path</param>
        /// <returns>Returns the diagnostics</returns>
        public string GetDiag(string diagpath, string screenshotpath, string temppath)
        {
            string temp = string.Empty;
            string diagfilescreen = @"C:\SSCAT\Tools\DiagFileScreenshot.ini";

            try
            {
                FileHelper.Copy(_diagPath, _diagPathTemp);
                WindowAppHelper.DiagnosticsInProcess += new EventHandler<SscatEventArgs>(WindowAppHelper_DiagnosticsInProcess);
                WindowAppHelper.WriteFile(_diagPath, diagfilescreen, string.Format(@"Name={0}\*.*", screenshotpath));
                temp = GetDiag(diagpath, temppath);
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                throw;
            }
            finally
            {
                FileHelper.Copy(_diagPathTemp, _diagPath);
                FileHelper.Delete(_diagPathTemp);
                WindowAppHelper.DiagnosticsInProcess -= new EventHandler<SscatEventArgs>(WindowAppHelper_DiagnosticsInProcess);
            }

            return temp;
        }

        /// <summary>
        /// Get diagnostics
        /// </summary>
        /// <param name="diagpath">diagnostics path</param>
        /// <param name="temppath">temporary path</param>
        /// <returns>Returns the diagnostics</returns>
        public string GetDiag(string diagpath, string temppath)
        {
            string temp = string.Empty;

            try
            {
                FileHelper.Copy(_diagFile, _diagFileBak);
                WindowAppHelper.DiagnosticsInProcess += new EventHandler<SscatEventArgs>(WindowAppHelper_DiagnosticsInProcess);
                WindowAppHelper.WriteFile(_diagFile, _diagPath, string.Empty);
                WindowAppHelper.AutoPushDiagFiles();
                LoggingService.Info(string.Format("path is in {0}.", temppath));
                temp = WindowAppHelper.GetLastWrittenFile(temppath, "*.zip");

                FileHelper.Copy(temp, string.Format(@"{0}\{1}", diagpath, Path.GetFileName(temp)));
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                throw;
            }
            finally
            {
                FileHelper.Copy(_diagFileBak, _diagFile);
                FileHelper.Delete(_diagFileBak);
                WindowAppHelper.DiagnosticsInProcess -= new EventHandler<SscatEventArgs>(WindowAppHelper_DiagnosticsInProcess);
            }

            return temp;
        }

        /// <summary>
        /// Event for on diagnostics in process
        /// </summary>
        /// <param name="e">sscat event arguments</param>
        protected virtual void OnDiagnosticsInProcess(SscatEventArgs e)
        {
            if (DiagnosticsInProcess != null)
            {
                DiagnosticsInProcess(this, e);
            }
        }

        /// <summary>
        /// Event for window application helper diagnostics in process
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">sscat event arguments</param>
        private void WindowAppHelper_DiagnosticsInProcess(object sender, SscatEventArgs e)
        {
            OnDiagnosticsInProcess(e);
        }
    }
}
