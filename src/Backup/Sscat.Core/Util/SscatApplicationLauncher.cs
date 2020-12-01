// <copyright file="SscatApplicationLauncher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    using System;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the SscatApplicationLauncher class
    /// </summary>
    public class SscatApplicationLauncher : ApplicationLauncher, ISscatApplicationLauncher
    {
        /// <summary>
        /// Initializes a new instance of the SscatApplicationLauncher class
        /// </summary>
        public SscatApplicationLauncher()
        {
        }

        /// <summary>
        /// Event handler for application launcher manage
        /// </summary>
        public event EventHandler<ApplicationLauncherEventArgs> ApplicationLauncherManage;

        /// <summary>
        /// Launch application
        /// </summary>
        /// <param name="item">application launcher event item</param>
        public void LaunchApplication(IApplicationLauncherEvent item)
        {
            LaunchApplication(item.Host, item.ApplicationPath);
        }

        /// <summary>
        /// Launch application
        /// </summary>
        /// <param name="host">host name</param>
        /// <param name="path">path name</param>
        public override void LaunchApplication(string host, string path)
        {
            if (RunApplication(host, path))
            {
                OnApplicationLauncherManage(new ApplicationLauncherEventArgs("Success running the application."));
            }
            else
            {
                OnApplicationLauncherManage(new ApplicationLauncherEventArgs("Failed running the application."));
            }
        }

        /// <summary>
        /// Create launch application
        /// </summary>
        /// <param name="item">application launcher event item</param>
        public void CreateLaunchApplication(IApplicationLauncherEvent item)
        {
            item.Validate();

            if (!item.HasErrors)
            {
                CreateApplicationLauncher(item.ScriptFileName, item.Host, item.ApplicationPath);
                OnApplicationLauncherManage(new ApplicationLauncherEventArgs(@"Successfully created application launcher script C:\SSCAT\Scripts\" + item.ScriptFileName.ToString() + ".xml"));
            }
            else
            {
                OnApplicationLauncherManage(new ApplicationLauncherEventArgs("Failed to create launch application script.\n" + item.Errors.ToString()));
            }
        }

        /// <summary>
        /// Create application launcher
        /// </summary>
        /// <param name="scriptFileName">script file name</param>
        /// <param name="host">host name</param>
        /// <param name="path">path name</param>
        public void CreateApplicationLauncher(string scriptFileName, string host, string path)
        {
            Lane lane = new Lane();
            SSCATScript s = new SSCATScript(
                scriptFileName,
                string.Empty,
                ApplicationUtility.ProductVersion,
                lane.ProductVersion,
                new SSCATScriptEvent(
                    new ApplicationLauncherEvent(host, path)));

            s.Serialize(@"C:\SSCAT\Scripts\" + scriptFileName.ToString() + ".xml");
        }

        /// <summary>
        /// Event for on application launcher manage
        /// </summary>
        /// <param name="e">application launcher event arguments</param>
        protected virtual void OnApplicationLauncherManage(ApplicationLauncherEventArgs e)
        {
            if (ApplicationLauncherManage != null)
            {
                ApplicationLauncherManage(this, e);
            }
        }
    }
}
