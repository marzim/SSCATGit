// <copyright file="AbstractApplicationManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the AbstractApplicationManager class
    /// </summary>
    public abstract class AbstractApplicationManager : IApplicationManager
    {
        /// <summary>
        /// Gets the application product name
        /// </summary>
        public abstract string ProductName { get; }

        /// <summary>
        /// Gets the product version
        /// </summary>
        public abstract string ProductVersion { get; }

        /// <summary>
        /// Gets the location
        /// </summary>
        public abstract string Location { get; }

        /// <summary>
        /// Gets the process name
        /// </summary>
        public abstract string ProcessName { get; }

        /// <summary>
        /// Gets the plugins directory
        /// </summary>
        public string PluginsDirectory
        {
            get { return Path.Combine(InstallationDirectory, "plugins"); }
        }

        /// <summary>
        /// Gets the reports directory
        /// </summary>
        public string ReportsDirectory
        {
            get { return Path.Combine(InstallationDirectory, "reports"); }
        }

        /// <summary>
        /// Gets the documents directory
        /// </summary>
        public string DocsDirectory
        {
            get { return Path.Combine(InstallationDirectory, "docs"); }
        }

        /// <summary>
        /// Gets the logs directory
        /// </summary>
        public string LogsDirectory
        {
            get { return Path.Combine(InstallationDirectory, "logs"); }
        }

        /// <summary>
        /// Gets the configuration directory
        /// </summary>
        public string ConfigDirectory
        {
            get { return Path.Combine(InstallationDirectory, "config"); }
        }

        /// <summary>
        /// Gets the roots directory
        /// </summary>
        public string RootDirectory
        {
            get { return Path.Combine(InstallationDirectory, "bin"); }
        }

        /// <summary>
        /// Gets the installation directory
        /// </summary>
        public string InstallationDirectory
        {
            get { return Path.GetFullPath(Path.Combine(Location, @"..\")); }
        }

        /// <summary>
        /// Gets the tools directory
        /// </summary>
        public string ToolsDirectory
        {
            get { return Path.Combine(InstallationDirectory, "tools"); }
        }

        /// <summary>
        /// Gets the diagnostics directory
        /// </summary>
        public string DiagsDirectory
        {
            get { return Path.Combine(InstallationDirectory, "Diags"); }
        }

        /// <summary>
        /// Gets the SCOT memory usage directory
        /// </summary>
        public string ScotMemUsageDirectory
        {
            get { return Path.Combine(ToolsDirectory, "ScotAppMemUsage"); }
        }

        /// <summary>
        /// Gets the PS tools directory
        /// </summary>
        public string PSToolsDirectory
        {
            get { return Path.Combine(ToolsDirectory, "pstools"); }
        }

        /// <summary>
        /// Gets the clean security agent configuration directory
        /// </summary>
        public string CleanSAConfigDirectory
        {
            get { return Path.Combine(PSToolsDirectory, "clean SAconfig"); }
        }

        /// <summary>
        /// Gets the clean weight learning database directory
        /// </summary>
        public string CleanWldbDirectory
        {
            get { return Path.Combine(PSToolsDirectory, "clean wldb"); }
        }

        /// <summary>
        /// Gets the product name and version
        /// </summary>
        public string ProductNameAndVersion
        {
            get { return ProductName + " " + ProductVersion; }
        }

        /// <summary>
        /// Gets the client configuration default name
        /// </summary>
        public string ClientConfigurationDefaultFileName
        {
            get { return Path.Combine(ConfigDirectory, "ClientConfiguration.default.xml"); }
        }

        /// <summary>
        /// Gets the lane configuration file name
        /// </summary>
        public string LaneConfigurationFileName
        {
            get { return Path.Combine(ConfigDirectory, "LaneConfiguration.xml"); }
        }

        /// <summary>
        /// Gets the settings file name
        /// </summary>
        public string SettingsFileName
        {
            get { return Path.Combine(ConfigDirectory, "Settings.ini"); }
        }

        /// <summary>
        /// Gets the SSCO startup path
        /// </summary>
        public string SscoStartupPath
        {
            get
            {
                string defaultPath = FileHelper.GetIniValue("SSCO Startup", "DefaultPath", SettingsFileName);
                string overridePath = FileHelper.GetIniValue("SSCO Startup", "OverridePath", SettingsFileName);
                string overrideDevPath = FileHelper.GetIniValue("SSCO Startup", "OverrideDevPath", SettingsFileName);

                if (IsSSCATDevImage() && FileHelper.Exists(overrideDevPath))
                {
                    return overrideDevPath;
                }
                else if (overridePath != string.Empty && FileHelper.Exists(overridePath))
                {
                    return overridePath;
                }
                else
                {
                    return defaultPath;
                }
            }
        }

        /// <summary>
        /// Get the client configuration file name
        /// </summary>
        /// <param name="serverIP">server IP</param>
        /// <returns>Returns the client configuration file name</returns>
        public abstract string ClientConfigurationFileName(string serverIP);

        /// <summary>
        /// Runs the application form
        /// </summary>
        /// <param name="form">application form</param>
        public abstract void Run(Form form);

        /// <summary>
        /// Checks if environment is a SSCAT development image
        /// </summary>
        /// <returns>Returns true if development image, false otherwise</returns>
        private bool IsSSCATDevImage()
        {
            try
            {
                return Environment.GetEnvironmentVariable("SSCATDevPC").Equals("Y", StringComparison.OrdinalIgnoreCase);
            }
            catch
            {
                return false;
            }
        }
    }
}
