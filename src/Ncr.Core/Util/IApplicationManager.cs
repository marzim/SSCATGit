// <copyright file="IApplicationManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the IApplicationManager interface
    /// </summary>
    public interface IApplicationManager
    {
        /// <summary>
        /// Gets the product version
        /// </summary>
        string ProductVersion { get; }

        /// <summary>
        /// Gets the application product name
        /// </summary>
        string ProductName { get; }

        /// <summary>
        /// Gets the product name and version
        /// </summary>
        string ProductNameAndVersion { get; }

        /// <summary>
        /// Gets the process name
        /// </summary>
        string ProcessName { get; }

        /// <summary>
        /// Gets the location
        /// </summary>
        string Location { get; }

        /// <summary>
        /// Gets the tools directory
        /// </summary>
        string ToolsDirectory { get; }

        /// <summary>
        /// Gets the roots directory
        /// </summary>
        string RootDirectory { get; }

        /// <summary>
        /// Gets the configuration directory
        /// </summary>
        string ConfigDirectory { get; }

        /// <summary>
        /// Gets the documents directory
        /// </summary>
        string DocsDirectory { get; }

        /// <summary>
        /// Gets the logs directory
        /// </summary>
        string LogsDirectory { get; }

        /// <summary>
        /// Gets the diagnostics directory
        /// </summary>
        string DiagsDirectory { get; }

        /// <summary>
        /// Gets the PS tools directory
        /// </summary>
        string PSToolsDirectory { get; }

        /// <summary>
        /// Gets the plugins directory
        /// </summary>
        string PluginsDirectory { get; }

        /// <summary>
        /// Gets the installation directory
        /// </summary>
        string InstallationDirectory { get; }

        /// <summary>
        /// Gets the clean security agent configuration directory
        /// </summary>
        string CleanSAConfigDirectory { get; }

        /// <summary>
        /// Gets the clean weight learning database directory
        /// </summary>
        string CleanWldbDirectory { get; }

        /// <summary>
        /// Gets the SCOT memory usage directory
        /// </summary>
        string ScotMemUsageDirectory { get; }

        /// <summary>
        /// Gets the reports directory
        /// </summary>
        string ReportsDirectory { get; }

        /// <summary>
        /// Gets the client configuration default name
        /// </summary>
        string ClientConfigurationDefaultFileName { get; }

        /// <summary>
        /// Gets the lane configuration file name
        /// </summary>
        string LaneConfigurationFileName { get; }

        /// <summary>
        /// Gets the settings file name
        /// </summary>
        string SettingsFileName { get; }

        /// <summary>
        /// Gets the SSCO startup path
        /// </summary>
        string SscoStartupPath { get; }

        /// <summary>
        /// Get the client configuration file name
        /// </summary>
        /// <param name="serverIP">server IP</param>
        /// <returns>Returns the client configuration file name</returns>
        string ClientConfigurationFileName(string serverIP);

        /// <summary>
        /// Runs the application form
        /// </summary>
        /// <param name="form">application form</param>
        void Run(Form form);
    }
}
