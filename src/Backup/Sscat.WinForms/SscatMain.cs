// <copyright file="SscatMain.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using Ncr.Core.Models;
    using Ncr.Core.Plugins;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Core;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Repositories.IO;
    using Sscat.Core.Repositories.Xml;
    using Sscat.Core.Services;
    using Sscat.Core.Util;
    using Sscat.Gui;

    /// <summary>
    /// Initializes a new instance of the SscatMain class
    /// </summary>
    public class SscatMain
    {
        /// <summary>
        /// SSCAT lane
        /// </summary>
        private static SscatLane _lane;

        /// <summary>
        /// Lane service
        /// </summary>
        private static LaneService _service;

        /// <summary>
        /// Main entry point for SSCAT windows form
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomainUnhandledException);

                ApplicationUtility.Attach(new ApplicationManager());
                LoggingService.Attach(new Log4NetLogger());
                MessageService.Attach(new MessageBoxMessageProvider());
                DnsHelper.Attach(new DnsManager());
                _lane = new SscatLane(60000 * 10, false, false);
                _lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
                SscatContext.Lane = _lane;
                CpuAndMemoryLogger scotLogger = null;
                if (_lane.Exists)
                {
                    scotLogger = new CpuAndMemoryLogger(3000, new StreamWriterLogger(Path.Combine(ApplicationUtility.LogsDirectory, "scotprocess.log.csv"), new CsvLogFormatter()), SscatContext.Lane.ProcessName);
                }

                _service = new LaneService(
                    SscatContext.Lane,
                    new XmlSSCATScriptRepository(),
                    new IOConfigFileRepository(),
                    new IOConfigFilesRepository(),
                    new XmlPlayerConfigurationRepository(),
                    new XmlGeneratorConfigurationRepository(),
                    new XmlLaneConfigurationRepository(),
                    new XmlReportRepository(),
                    new XmlPsxDisplayRepository(),
                    new CpuAndMemoryLogger(3000, new StreamWriterLogger(Path.Combine(ApplicationUtility.LogsDirectory, "serverprocess.log.csv"), new CsvLogFormatter()), "Sscat.Server"),
                    scotLogger);

                _lane.Configuration = _service.ReadLaneConfiguration(ApplicationUtility.LaneConfigurationFileName);
                SscatContext.LaneService = _service;

                if (Process.GetProcessesByName("Sscat.WinForms").Length > 1)
                {
                    MessageService.ShowInfo(ResourceUtility.GetString("instance.running", "Another instance is running"));
                }
                else
                {
                    Plugin plugin = Plugin.Load(Path.Combine(ApplicationUtility.PluginsDirectory, "WorkbenchPlugin.xml"));
                    IWorkbench workbench = new MainForm();
                    try
                    {
                        workbench.Settings = WorkbenchSettings.Deserialize(Path.Combine(ApplicationUtility.ConfigDirectory, "Settings.xml"));
                    }
                    catch
                    {
                    }

                    workbench.SettingsSave += new EventHandler<WorkbenchSettingsEventArgs>(WorkbenchSettingsSave);
                    workbench.WorkbenchLayout = new SdiWorkbenchLayout();
                    workbench.StatusBar = plugin.CreateStatusBar();
                    workbench.ToolBar = plugin.CreateToolBar();
                    workbench.MainMenu = plugin.CreateMenu();

                    WorkbenchSingleton.Attach(workbench);

                    Application.Run(WorkbenchSingleton.MainForm);
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
            finally
            {
                _lane.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
                AppDomain.CurrentDomain.UnhandledException -= new UnhandledExceptionEventHandler(CurrentDomainUnhandledException);
            }
        }

        /// <summary>
        /// Event for lane connection adding
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">psx wrapper event arguments</param>
        private static void LaneConnectionAdding(object sender, PsxWrapperEventArgs e)
        {
            try
            {
                if (!_lane.PsxConnections.ContainsKey(e.ConnectionName))
                {
                    LoggingService.Info(string.Format("Connecting to PSX {0}@{1}", e.ConnectionName, e.HostName));
                    _lane.PsxConnections.Add(_service.CreatePsx(e.HostName, e.ServiceName, e.ConnectionName, e.Timeout));
                    LoggingService.Info(string.Format("Connected to PSX {0}@{1}", e.ConnectionName, e.HostName));
                }
                else
                {
                    LoggingService.Info("Connection {0}@{1} exists", e.ConnectionName, e.HostName);
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Event for saving the workbench settings
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">workbench settings event arguments</param>
        private static void WorkbenchSettingsSave(object sender, WorkbenchSettingsEventArgs e)
        {
            e.Settings.Serialize(Path.Combine(ApplicationUtility.ConfigDirectory, "Settings.xml"));
        }

        /// <summary>
        /// Event for current domain unhandled exception
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">unhandled exception event arguments</param>
        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageService.ShowErrorOnTop(string.Format("Oops! This is embarrassing.{0}SSCAT Client encountered an error, please restart the SSCAT Client and report this to SSCAT team.", Environment.NewLine));
            LoggingService.Error(e.ToString());
            Application.Exit();
        }
    }
}
