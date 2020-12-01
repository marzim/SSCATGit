// <copyright file="SecurityManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// Initializes a new instance of the SecurityManager class
    /// </summary>
    public class SecurityManager : ISecurityManager
    {
        /// <summary>
        /// Initializes a new instance of the SecurityManager class
        /// </summary>
        public SecurityManager()
        {
        }

        /// <summary>
        /// Update the weight learning database
        /// </summary>
        /// <param name="server">server name</param>
        /// <param name="wldbFile">wldb file</param>
        /// <param name="saConfigFile">security agent configuration file</param>
        /// <param name="user">user name</param>
        /// <param name="password">user password</param>
        public virtual void UpdateWldb(string server, string wldbFile, string saConfigFile, string user, string password)
        {
            if (DoTask(server, Path.Combine(ApplicationUtility.PSToolsDirectory, "updatedb.bat"), wldbFile, saConfigFile, user, password))
            {
                // OnWldbManage(new WldbEventArgs("Sucess in updating WLDB/SAConfig."));
            }
            else
            {
                // OnWldbManage(new WldbEventArgs("Failed in updating WLDB/SAConfig"));
            }
        }

        /// <summary>
        /// Do task
        /// </summary>
        /// <param name="server">server name</param>
        /// <param name="file">file name</param>
        /// <param name="wldbFile">wldb file</param>
        /// <param name="saConfigFile">security agent configuration file</param>
        /// <param name="user">user name</param>
        /// <param name="password">user password</param>
        /// <returns>Returns true if task is successful, false otherwise</returns>
        public bool DoTask(string server, string file, string wldbFile, string saConfigFile, string user, string password)
        {
            bool success = false;
            try
            {
                ValidateServer(server);
                ValidateLogin(server, user, password);
                ValidateSAServer(server);

                CreateSetupDirectory();

                EditFile(file, server, wldbFile, saConfigFile);
                EditFile(Path.Combine(ApplicationUtility.PSToolsDirectory, "updatedb.bat"), server, wldbFile, saConfigFile);
                ExecuteProcess(file);

                success = true;
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.Message);
                throw ex;
            }

            return success;
        }

        /// <summary>
        /// Checks for successful login
        /// </summary>
        /// <param name="server">server name</param>
        /// <param name="user">user name</param>
        /// <param name="password">user password</param>
        /// <returns>Returns true if successful, false otherwise</returns>
        public virtual bool IsSuccessfulLogin(string server, string user, string password)
        {
            ProcessUtility.GetStandardOutput("net.exe", @"use Q: /delete");
            string getStandardOutpout = ProcessUtility.GetStandardOutput("net.exe", string.Format(@"use Q: \\{0}\C$ /user:{1} {2}", server, user, password));
            if (getStandardOutpout.Contains("The command completed successfully."))
            {
                return true;
            }
            else
            {
                throw new SecurityManagerException(string.Format("Unable to sign on at {0}. {1}", server, getStandardOutpout));
            }
        }

        /// <summary>
        /// Validate server
        /// </summary>
        /// <param name="server">server name</param>
        public virtual void ValidateServer(string server)
        {
            if (!ProcessUtility.CanPing(server))
            {
                throw new SecurityManagerException(string.Format("Unable to ping server {0}", server));
            }
        }

        /// <summary>
        /// Validate login
        /// </summary>
        /// <param name="server">server name</param>
        /// <param name="user">user name</param>
        /// <param name="password">user password</param>
        public virtual void ValidateLogin(string server, string user, string password)
        {
            if (!IsSuccessfulLogin(server, user, password))
            {
                throw new SecurityManagerException(string.Format("Unable to sign on at {0}", server));
            }
        }

        /// <summary>
        /// Validate security agent server
        /// </summary>
        /// <param name="server">server name</param>
        public virtual void ValidateSAServer(string server)
        {
            if (!System.IO.File.Exists(@"Q:\scot\SecurityAgent\SAServer.exe"))
            {
                throw new SecurityManagerException(string.Format(@"Unable to locate in {0} C:\scot\SecurityAgent\SAServer.exe", server));
            }
        }

        /// <summary>
        /// Execute process
        /// </summary>
        /// <param name="file">file name</param>
        public virtual void ExecuteProcess(string file)
        {
            Process p = new Process();
            p.StartInfo.FileName = file;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.Start();
            p.WaitForExit();
        }

        /// <summary>
        /// Edit file
        /// </summary>
        /// <param name="file">file name</param>
        /// <param name="server">server name</param>
        /// <param name="wldbFile">weight learning database file</param>
        /// <param name="saConfigFile">security agent configuration file</param>
        public virtual void EditFile(string file, string server, string wldbFile, string saConfigFile)
        {
            try
            {
                ArrayList newFile = new ArrayList();
                string temps = server;
                server = temps.StartsWith("127") ? "127.0.0.1" : server;
                string temp = string.Empty;
                ArrayList rfile = IOHelper.ReadAllLines(file); // Read all lines in the file and pass to arraylist
                foreach (string line in rfile)
                {
                    // Here loop through all the lines in the file for processing
                    if (line.StartsWith("set var="))
                    {
                        string tempserv = line.Split('=')[1];
                        temp = line.Replace(tempserv, "\\\\" + server);
                        newFile.Add(temp);
                        continue;
                    }

                    if (line.StartsWith("set var2="))
                    {
                        string tempwldb = line.Split('=')[1];
                        wldbFile = wldbFile.Equals(string.Empty) ? Path.Combine(ApplicationUtility.PSToolsDirectory, "dummy.mdb") : wldbFile;
                        temp = line.Replace(tempwldb, wldbFile);
                        newFile.Add(temp);
                        continue;
                    }

                    if (line.StartsWith("set var3="))
                    {
                        string tempwldb = line.Split('=')[1];
                        saConfigFile = saConfigFile.Equals(string.Empty) ? Path.Combine(ApplicationUtility.PSToolsDirectory, "dummy.mdb") : saConfigFile;
                        temp = line.Replace(tempwldb, saConfigFile);
                        newFile.Add(temp);
                        continue;
                    }

                    newFile.Add(line);
                }

                WriteAllText(file, newFile);
            }
            catch (Exception ex)
            {
                MessageService.ShowError(ex.ToString(), "Edit File Error");
            }
        }

        /// <summary>
        /// Write all text
        /// </summary>
        /// <param name="file">file name</param>
        /// <param name="data">file data</param>
        public void WriteAllText(string file, ArrayList data)
        {
            using (TextWriter textWriter = new StreamWriter(file))
            {
                foreach (string dataValue in data)
                {
                    textWriter.WriteLine(dataValue);
                }
            }
        }

        /// <summary>
        /// Create setup directory
        /// </summary>
        private void CreateSetupDirectory()
        {
            string sscatTemp = @"Q:\temp\sscatTemp";
            string wldbBackup = @"C:\SSCAT\WLDB\Backup";
            try
            {
                // create sscat temp folder
                if (!System.IO.Directory.Exists(sscatTemp))
                {
                    System.IO.Directory.CreateDirectory(sscatTemp);
                }
            }
            catch
            {
            }

            try
            {
                // create backup folder where the updateDB is initiated and store the WLDB backup including the logs throught preupdatedb.bat
                if (!System.IO.Directory.Exists(wldbBackup))
                {
                    System.IO.Directory.CreateDirectory(wldbBackup);
                }
            }
            catch
            {
            }
        }
    }
}
