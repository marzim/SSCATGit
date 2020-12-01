// <copyright file="SscatSecurityManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;
    using System.IO;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the SscatSecurityManager class
    /// </summary>
    public class SscatSecurityManager : SecurityManager, ISscatSecurityManager
    {
        /// <summary>
        /// Initializes a new instance of the SscatSecurityManager class
        /// </summary>
        public SscatSecurityManager()
        {
        }

        /// <summary>
        /// Event handler for WLDB manage
        /// </summary>
        public event EventHandler<WldbEventArgs> WldbManage;

        /// <summary>
        /// Update the WLDB
        /// </summary>
        /// <param name="item">WLDB event item</param>
        public void UpdateWldb(IWldbEvent item)
        {
            item.Validate();
            if (!item.HasErrors)
            {
                UpdateWldb(item.Host, item.WldbFile, item.SAConfigFile, item.User, item.Password);
            }
            else
            {
                OnWldbManage(new WldbEventArgs("Failed to update WLDB Files.\n" + item.Errors.ToString()));
            }
        }

        /// <summary>
        /// Update the WLDB
        /// </summary>
        /// <param name="server">server name</param>
        /// <param name="wldbFile">WLDB file</param>
        /// <param name="saConfigFile">security agent configuration file</param>
        /// <param name="user">user name</param>
        /// <param name="password">user password</param>
        public override void UpdateWldb(string server, string wldbFile, string saConfigFile, string user, string password)
        {
            try
            {
                if (DoTask(server, Path.Combine(ApplicationUtility.PSToolsDirectory, "preupdatedb.bat"), wldbFile, saConfigFile, user, password))
                {
                    OnWldbManage(new WldbEventArgs("Success in updating WLDB/SAConfig."));
                }
            }
            catch (SecurityManagerException ex)
            {
                LoggingService.Info("Failed in updating WLDB/SAConfig. " + ex.Message);
                OnWldbManage(new WldbEventArgs("Failed in updating WLDB/SAConfig. " + ex.Message));
                throw;
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.Message);
                MessageService.ShowInfo(ex.Message);
            }
        }

        /// <summary>
        /// Create the update script
        /// </summary>
        /// <param name="item">WLDB event item</param>
        public void CreateUpdateScript(IWldbEvent item)
        {
            item.Validate();
            if (!item.HasErrors)
            {
                CreateWLDBScript("Update", item.ScriptFileName, item.ScriptFileName, "Update WLDB Script", item.Host, item.WldbFile, item.SAConfigFile, item.User, item.Password);
                OnWldbManage(new WldbEventArgs(@"Successfully created update WLDB script C:\SSCAT\Scripts\" + item.ScriptFileName.ToString() + ".xml"));
            }
            else
            {
                OnWldbManage(new WldbEventArgs("Failed to create update WLDB Script.\n" + item.Errors.ToString()));
            }
        }

        /// <summary>
        /// Create the update script
        /// </summary>
        /// <param name="mode">action mode</param>
        /// <param name="scriptFileName">script file name</param>
        /// <param name="scriptName">script name</param>
        /// <param name="scriptDescription">script description</param>
        /// <param name="host">host name</param>
        /// <param name="wldbFile">WLDB file</param>
        /// <param name="saConfigFile">security agent configuration file</param>
        /// <param name="user">user name</param>
        /// <param name="password">user password</param>
        public void CreateWLDBScript(string mode, string scriptFileName, string scriptName, string scriptDescription, string host, string wldbFile, string saConfigFile, string user, string password)
        {
            SSCATScript s = new SSCATScript(
                scriptName,
                scriptDescription,
                ApplicationUtility.ProductVersion,
                string.Empty,
                new SSCATScriptEvent(
                    new WldbEvent(mode, host, wldbFile, saConfigFile, user, password)));

            s.Serialize(@"C:\SSCAT\Scripts\" + scriptFileName.ToString() + ".xml");
        }

        /// <summary>
        /// Event for on WLDB manage
        /// </summary>
        /// <param name="e">WLDB event arguments</param>
        protected virtual void OnWldbManage(WldbEventArgs e)
        {
            if (WldbManage != null)
            {
                WldbManage(this, e);
            }
        }
    }
}
