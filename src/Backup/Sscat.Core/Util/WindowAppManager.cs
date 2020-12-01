// <copyright file="WindowAppManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using Ncr.Core.PInvoke;
    using Ncr.Core.Util;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the WindowAppManager class
    /// </summary>
    public class WindowAppManager : IWindowAppManager
    {
        /// <summary>
        /// Interface for launch pad configuration repository
        /// </summary>
        private ILaunchPadConfigRepository _launchPadRepository;

        /// <summary>
        /// Initializes a new instance of the WindowAppManager class
        /// </summary>
        /// <param name="launchPadRepository">launch pad repository</param>
        public WindowAppManager(ILaunchPadConfigRepository launchPadRepository)
        {
            _launchPadRepository = launchPadRepository;
        }

        /// <summary>
        /// Event handler for in process
        /// </summary>
        public event EventHandler<SscatEventArgs> InProcess;

        /// <summary>
        /// Window Application exit
        /// </summary>
        /// <param name="windowTitle">window title</param>
        public virtual void WindowAppExit(string windowTitle)
        {
            IntPtr handle = ApiHelper.FindWindow(null, windowTitle);
            if (handle != IntPtr.Zero)
            {
                while (handle != IntPtr.Zero)
                {
                    ApiHelper.SetForegroundWindow(handle);
                    ThreadHelper.Sleep(100);
                    ApiHelper.SendWait("%{F4}");
                    ThreadHelper.Sleep(2000);
                    handle = ApiHelper.FindWindow(null, windowTitle);
                }

                return;
            }
            else
            {
                throw new Exception(string.Format("{0} does not exist", windowTitle));
            }
        }

        /// <summary>
        /// Get text
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the text</returns>
        public virtual string GetText(string filename)
        {
            if (FileHelper.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        return line;
                    }
                }
            }

            throw new Exception(filename + " not found");
        }

        /// <summary>
        /// Check the diagnostic file
        /// </summary>
        /// <param name="time">diagnostics time</param>
        /// <param name="timeout">time out</param>
        /// <returns>Returns the file path</returns>
        public virtual string CheckDiagnosticFile(int time, int timeout)
        {
            // time where generating diags takes place.
            ThreadHelper.Sleep(time);
            string filePath;
            System.Text.StringBuilder diagPath = new System.Text.StringBuilder();
            IntPtr getDiagResultWindow;

            // generating diags should be done.
            int tickCount = Environment.TickCount;

            while ((Environment.TickCount - tickCount) < timeout)
            {
                // handler for "Get Diagnostics Files Results" Parent Window
                // LoggingService.Info("Generating Diags 2");
                OnProcess("Getting Diagnostics Files Results...");
                getDiagResultWindow = ApiHelper.FindWindow(null, "Get Diagnostics Files Results");

                if (getDiagResultWindow != IntPtr.Zero)
                {
                    // LoggingService.Info("Generating Diags --- inside diag result window");
                    // handler for "Get Diagnostics Files Results" Child Window (Message)
                    IntPtr getDiagResultWindowText = ApiHelper.ChiledWindowFromPoint(getDiagResultWindow, new Point(157, 44));

                    if (getDiagResultWindowText != IntPtr.Zero)
                    {
                        User32.GetWindowText(getDiagResultWindowText, diagPath, 500);
                    }

                    // handler for "Get Diagnostics Files Results" Child Window (Button)
                    IntPtr getDiagResultWindowButton = ApiHelper.FindWindowEx(getDiagResultWindow, 0, "Button", "OK");

                    if (getDiagResultWindowButton != IntPtr.Zero)
                    {
                        ApiHelper.SetForegroundWindow(getDiagResultWindowButton);
                        int param = (10 * 0x10000) + 10;
                        ApiHelper.SendMessage(getDiagResultWindowButton, 0x21, 0, 0);

                        // clicks the ok button
                        ApiHelper.SendMessage(getDiagResultWindowButton, 0x201, 0, param);
                        ThreadHelper.Sleep(10);
                        ApiHelper.SendMessage(getDiagResultWindowButton, 0x201, 0, param);
                    }

                    try
                    {
                        filePath = diagPath.ToString().Split('\n')[2].ToString();
                    }
                    catch
                    {
                        filePath = diagPath.ToString();
                    }

                    LoggingService.Info(filePath.ToString());
                    
                    if (FileHelper.Exists(filePath))
                    {
                        LoggingService.Info("@@@@@ true");
                        return filePath.ToString();
                    }
                }
            }

            throw new Exception("Diags Not Found.");
        }

        /// <summary>
        /// Writes message to file
        /// </summary>
        /// <param name="writeFile">write file</param>
        /// <param name="readFile">read file</param>
        /// <param name="message">message to write</param>
        public virtual void WriteFile(string writeFile, string readFile, string message)
        {
            using (StreamWriter sw = new StreamWriter(writeFile, true, EncodingUtility.GetFileEncoding(writeFile)))
            {
                sw.WriteLine();

                using (StreamReader sr = new StreamReader(readFile))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        sw.WriteLine(line);
                    }

                    sw.WriteLine(message);
                }
            }
        }

        /// <summary>
        /// Get last written file
        /// </summary>
        /// <param name="path">file path</param>
        /// <param name="pattern">pattern to check for</param>
        /// <returns>Returns the last written file</returns>
        public virtual string GetLastWrittenFile(string path, string pattern)
        {
            string temp = string.Empty;
            foreach (string f in DirectoryHelper.GetFiles(path, pattern))
            {
                if (temp.Equals(string.Empty) || (File.GetLastWriteTime(temp) < File.GetLastWriteTime(f)))
                {
                    temp = f;
                }
            }

            return temp;
        }

        /// <summary>
        /// Automatically push the diagnostic files
        /// </summary>
        public virtual void AutoPushDiagFiles()
        {
            string filename = new GetDiagLocation(@"C:\scot\config\LaunchPadConfig_XP.xml", _launchPadRepository).GetFilename();
            if (FileHelper.Exists(filename))
            {
                ProcessUtility.Start(filename, "/p", ProcessWindowStyle.Hidden, true);
                ThreadHelper.Sleep(50000);
                OnProcess("Getting Diagnostics Files Results...");
                IntPtr getDiagResultWindow = ApiHelper.FindWindow(null, "Get Diagnostics Files Results");

                while (getDiagResultWindow == IntPtr.Zero)
                {
                    ThreadHelper.Sleep(1000);
                    OnProcess("Getting Diagnostics Files Results...");
                    getDiagResultWindow = ApiHelper.FindWindow(null, "Get Diagnostics Files Results");
                }

                GetDiagnosticFilesResults();
            }
        }

        /// <summary>
        /// Get diagnostic files results
        /// </summary>
        public virtual void GetDiagnosticFilesResults()
        {
            ThreadHelper.Sleep(100);
            IntPtr getDiagResultWindow = ApiHelper.FindWindow(null, "Get Diagnostics Files Results");

            if (getDiagResultWindow != IntPtr.Zero)
            {
                IntPtr getDiagResultWindowButton = ApiHelper.FindWindowEx(getDiagResultWindow, 0, "Button", "OK");

                if (getDiagResultWindowButton != IntPtr.Zero)
                {
                    ApiHelper.SetForegroundWindow(getDiagResultWindowButton);
                    int param = (10 * 0x10000) + 10;
                    ApiHelper.SendMessage(getDiagResultWindowButton, 0x21, 0, 0);
                    ApiHelper.SendMessage(getDiagResultWindowButton, 0x201, 0, param);
                    ThreadHelper.Sleep(10);
                    ApiHelper.SendMessage(getDiagResultWindowButton, 0x202, 0, param);
                }
                else
                {
                    throw new Exception("Get Diags failed\n");
                }
            }
            else
            {
                throw new Exception("Get Diags failed\n");
            }
        }

        /// <summary>
        /// Event for on process
        /// </summary>
        /// <param name="message">message to send</param>
        protected virtual void OnProcess(string message)
        {
            OnProcess(new SscatEventArgs(message));
        }

        /// <summary>
        /// Event for on process
        /// </summary>
        /// <param name="e">sscat event arguments</param>
        protected virtual void OnProcess(SscatEventArgs e)
        {
            if (InProcess != null)
            {
                InProcess(this, e);
            }
        }
    }
}
