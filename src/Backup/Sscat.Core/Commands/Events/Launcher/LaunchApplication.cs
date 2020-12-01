// <copyright file="LaunchApplication.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events.Launcher
{
    using System;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the LaunchApplication class
    /// </summary>
    public class LaunchApplication : ApplicationLauncherEventCommand
    {
        /// <summary>
        /// Initializes a new instance of the LaunchApplication class
        /// </summary>
        /// <param name="item">application launcher event</param>
        /// <param name="applicationLauncher">application launcher</param>
        public LaunchApplication(IApplicationLauncherEvent item, ISscatApplicationLauncher applicationLauncher)
            : base(item, applicationLauncher)
        {
        }

        /// <summary>
        /// Runs the application launcher
        /// </summary>
        public override void Run()
        {
            try
            {
                ApplicationLauncher.ApplicationLauncherManage += new EventHandler<ApplicationLauncherEventArgs>(ApplicationLauncherManage);
                ApplicationLauncher.LaunchApplication(Item);
                Result = new Result(ResultType.Passed, "OK");
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                Result = new Result(ResultType.Failed, Regex.Replace(ex.Message, @"\t|\n|\r", "; "));
            }
            finally
            {
                ApplicationLauncher.ApplicationLauncherManage -= new EventHandler<ApplicationLauncherEventArgs>(ApplicationLauncherManage);
            }
        }

        /// <summary>
        /// Manages the application launcher event
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">application launcher event arguments</param>
        private void ApplicationLauncherManage(object sender, ApplicationLauncherEventArgs e)
        {
            OnRunning(e.StatusMessage);
        }
    }
}
