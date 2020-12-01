// <copyright file="ApplicationLauncher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Initializes a new instance of the ApplicationLauncher class
    /// </summary>
    public class ApplicationLauncher : IApplicationLauncher
    {
        /// <summary>
        /// Double quote constant
        /// </summary>
        private const char DOUBLE_QUOTE = '"';

        /// <summary>
        /// Initializes a new instance of the ApplicationLauncher class
        /// </summary>
        public ApplicationLauncher()
        {
        }

        /// <summary>
        /// Launch application
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="path">path name</param>
        public virtual void LaunchApplication(string host, string path)
        {
        }
        
        /// <summary>
        /// Run application
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="path">path name</param>
        /// <returns>Returns true if application run is successful, false otherwise</returns>
        public bool RunApplication(string host, string path)
        {
            bool success = false;
            //// Added to enable user specify the admin user account to be use when remoting a machine
            string settingsFilePath = @"C:\sscat\config\Settings.ini"; ////TODO: improved this, it should not be hardcoded
            string username = FileHelper.GetIniValue("ApplicationLauncherLoginCredentials", "Username", settingsFilePath);
            string password = FileHelper.GetIniValue("ApplicationLauncherLoginCredentials", "Password", settingsFilePath);

            if (CanRunOnRemoteHost(host, path))
            {
                string remoteHost = "\\\\" + DnsHelper.GetIPAddress(host);
                string param = string.Empty;
                string appExtension = FileHelper.GetExtension(path);
                if (appExtension == ".reg")
                {
                    string tempRegBat1 = @"C:\temp\TempRegScripts.bat";
                    string tempRegBat2 = @"Q:\temp\TempRegScripts.bat";
                    FileHelper.Delete(tempRegBat2); // Note: Delete first because sometimes it fails if file is already at remote host
                    FileHelper.Create(tempRegBat2, string.Format("regedit.exe /s {0}{1}{2}", DOUBLE_QUOTE, path, DOUBLE_QUOTE));
                    param = string.Format("{0} -i -d {1}{2}{3} -accepteula -u {4} {5}", remoteHost, DOUBLE_QUOTE, tempRegBat1, DOUBLE_QUOTE, username, password);
                    ProcessUtility.GetStandardOutput(@"C:\SSCAT\Tools\PsTools\psexec.exe", param);
                    FileHelper.Delete(tempRegBat2);
                    success = true;
                }
                else
                {
                    LoggingService.Info(string.Format("remoteHost: {0}", remoteHost));
                    LoggingService.Info(string.Format("path: {0}", path));

                    string filename = "C:\\SSCAT\\Tools\\PsTools\\psexec.exe";
                    param = string.Format("{0} -i -d \"{1}\" -accepteula -u {2} {3}", remoteHost, path, username, password);
                    Process.Start(path);
                    success = true;
                }
            }

            ProcessUtility.GetStandardOutput("net.exe", @"use Q: /delete");
            return success;
        }

        /// <summary>
        /// Checks if application launcher can run on remote host
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="path">path name</param>
        /// <returns>Returns true if can run on remote host, false otherwise</returns>
        public bool CanRunOnRemoteHost(string host, string path)
        {
            bool success = false;
            ProcessUtility.GetStandardOutput("net.exe", @"use Q: /delete");
            if (ProcessUtility.CanPing(host))
            {
                host = DnsHelper.GetIPAddress(host);

                // Added to enable user specify the admin user account to be use when remoting a machine
                string settingsFilePath = @"C:\sscat\config\Settings.ini"; ////TODO: improved this, it should not be hardcoded
                string username = FileHelper.GetIniValue("ApplicationLauncherLoginCredentials", "Username", settingsFilePath);
                string password = FileHelper.GetIniValue("ApplicationLauncherLoginCredentials", "Password", settingsFilePath);

                string query = ProcessUtility.GetStandardOutput("net.exe", string.Format(@"use Q: \\{0}\C$ /user:{1} {2}", host, username, password));
                LoggingService.Info(string.Format("query: {0}", query));
                if (query.Contains("The command completed successfully."))
                {
                    string[] tempPath = path.Split(':');
                    string remotePath = "Q:" + tempPath[1];
                    if (FileHelper.Exists(remotePath))
                    {
                        success = true;
                    }
                    else
                    {
                        throw new Exception("File cannot be found at remote host");
                    }
                }
                else
                {
                    throw new Exception("Unable to log in into remote host, please uncheck simple file sharing in windows folder options or make you could connect manually to the remote host");
                }
            }
            else
            {
                throw new Exception("Unable to locate remote host");
            }

            return success;
        }
    }
}
