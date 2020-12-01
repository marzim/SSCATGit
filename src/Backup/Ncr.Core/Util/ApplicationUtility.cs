// <copyright file="ApplicationUtility.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Util
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the AbstractLogger class
    /// </summary>
    public static class ApplicationUtility
    {
        /// <summary>
        /// Application manager interface
        /// </summary>
        private static IApplicationManager _manager;

        /// <summary>
        /// Gets the process name
        /// </summary>
        public static string ProcessName
        {
            get
            {
                if (_manager == null)
                {
                    throw new ArgumentException("ApplicationManager");
                }

                return _manager.ProcessName;
            }
        }

        /// <summary>
        /// Gets the product version
        /// </summary>
        public static string ProductVersion
        {
            get
            {
                if (_manager == null)
                {
                    throw new ArgumentException("ApplicationManager");
                }

                return _manager.ProductVersion;
            }
        }

        /// <summary>
        /// Gets the location
        /// </summary>
        public static string Location
        {
            get
            {
                if (_manager == null)
                {
                    return Application.StartupPath;
                }

                return _manager.Location;
            }
        }

        /// <summary>
        /// Gets the installation directory
        /// </summary>
        public static string InstallationDirectory
        {
            get
            {
                return Path.GetFullPath(Path.Combine(Location, @"..\"));
            }
        }

        /// <summary>
        /// Gets the configuration directory
        /// </summary>
        public static string ConfigDirectory
        {
            get { return Path.Combine(InstallationDirectory, "config"); }
        }

        /// <summary>
        /// Gets the cache directory
        /// </summary>
        public static string CacheDirectory
        {
            get { return Path.Combine(InstallationDirectory, "cache"); }
        }

        /// <summary>
        /// Gets the documents directory
        /// </summary>
        public static string DocsDirectory
        {
            get { return Path.Combine(InstallationDirectory, "docs"); }
        }

        /// <summary>
        /// Gets the logs directory
        /// </summary>
        public static string LogsDirectory
        {
            get { return Path.Combine(InstallationDirectory, "logs"); }
        }

        /// <summary>
        /// Gets the plugins directory
        /// </summary>
        public static string PluginsDirectory
        {
            get { return Path.Combine(InstallationDirectory, "plugins"); }
        }

        /// <summary>
        /// Gets the playlists directory
        /// </summary>
        public static string PlaylistsDirectory
        {
            get { return Path.Combine(InstallationDirectory, "playlists"); }
        }

        /// <summary>
        /// Gets the reports directory
        /// </summary>
        public static string ReportsDirectory
        {
            get { return Path.Combine(InstallationDirectory, "reports"); }
        }

        /// <summary>
        /// Gets the tools directory
        /// </summary>
        public static string ToolsDirectory
        {
            get
            {
                return Path.Combine(InstallationDirectory, "tools");
            }
        }

        /// <summary>
        /// Gets the diagnostics directory
        /// </summary>
        public static string DiagsDirectory
        {
            get { return _manager.DiagsDirectory; }
        }

        /// <summary>
        /// Gets the SCOT memory usage directory
        /// </summary>
        public static string ScotMemUsageDirectory
        {
            get { return Path.Combine(ToolsDirectory, "ScotAppMemUsage"); }
        }

        /// <summary>
        /// Gets the clean security agent configuration directory
        /// </summary>
        public static string CleanSAConfigDirectory
        {
            get { return Path.Combine(PSToolsDirectory, "clean SAconfig"); }
        }

        /// <summary>
        /// Gets the clean weight learning database directory
        /// </summary>
        public static string CleanWldbDirectory
        {
            get { return Path.Combine(PSToolsDirectory, "clean wldb"); }
        }

        /// <summary>
        /// Gets the PS tools directory
        /// </summary>
        public static string PSToolsDirectory
        {
            get { return Path.Combine(ToolsDirectory, "pstools"); }
        }

        /// <summary>
        /// Gets the roots directory
        /// </summary>
        public static string RootDirectory
        {
            get { return Path.Combine(InstallationDirectory, "bin"); }
        }

        /// <summary>
        /// Gets the application product name
        /// </summary>
        public static string ProductName
        {
            get
            {
                if (_manager == null)
                {
                    throw new ArgumentException("ApplicationManager");
                }

                return _manager.ProductName;
            }
        }

        /// <summary>
        /// Gets the settings file name
        /// </summary>
        public static string SettingsFileName
        {
            get
            {
                if (_manager == null)
                {
                    throw new ArgumentException("ApplicationManager");
                }

                return _manager.SettingsFileName;
            }
        }

        /// <summary>
        /// Gets the SSCO startup path
        /// </summary>
        public static string SscoStartupPath
        {
            get
            {
                if (_manager == null)
                {
                    throw new ArgumentException("ApplicationManager");
                }

                return _manager.SscoStartupPath;
            }
        }

        /// <summary>
        /// Gets the product name and version
        /// </summary>
        public static string ProductNameAndVersion
        {
            get
            {
                return ProductName + " " + ProductVersion;
            }
        }

        /// <summary>
        /// Gets the client configuration default name
        /// </summary>
        public static string ClientConfigurationDefaultFileName
        {
            get
            {
                return Path.Combine(ConfigDirectory, "ClientConfiguration.default.xml");
            }
        }

        /// <summary>
        /// Gets the lane configuration file name
        /// </summary>
        public static string LaneConfigurationFileName
        {
            get
            {
                return Path.Combine(ConfigDirectory, "LaneConfiguration.xml");
            }
        }

        /// <summary>
        /// Get the client configuration file name
        /// </summary>
        /// <param name="serverIP">server IP</param>
        /// <returns>Returns the client configuration file name</returns>
        public static string ClientConfigurationFileName(string serverIP)
        {
            return Path.Combine(ConfigDirectory, string.Format("ClientConfiguration.{0}.xml", serverIP));
        }

        /// <summary>
        /// Attach the application manager
        /// </summary>
        /// <param name="manager">application manager</param>
        public static void Attach(IApplicationManager manager)
        {
            ApplicationUtility._manager = manager;
        }

        /// <summary>
        /// Runs the application form
        /// </summary>
        /// <param name="form">application form</param>
        public static void Run(Form form)
        {
            if (_manager == null)
            {
                throw new ArgumentException("ApplicationManager");
            }

            _manager.Run(form);
        }
    }
}
