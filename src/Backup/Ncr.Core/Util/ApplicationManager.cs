// <copyright file="ApplicationManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the ApplicationManager class
    /// </summary>
    public class ApplicationManager : AbstractApplicationManager
    {
        /// <summary>
        /// Gets the application product name
        /// </summary>
        public override string ProductName
        {
            get { return Application.ProductName; }
        }

        /// <summary>
        /// Gets the process name
        /// </summary>
        public override string ProcessName
        {
            get { return Path.GetFileNameWithoutExtension(Location); }
        }

        /// <summary>
        /// Gets the location
        /// </summary>
        public override string Location
        {
            get
            {
                Assembly exe = Assembly.GetCallingAssembly();
                return Path.GetDirectoryName(exe.Location);
            }
        }

        /// <summary>
        /// Gets the product version
        /// </summary>
        public override string ProductVersion
        {
            get
            {
                Version v = FileHelper.GetFileVersion(Path.Combine(Location, "Sscat.Core.dll"));
                return string.Format("{0}.{1}.{2}.{3}", v.Major, v.Minor, v.Build, v.Revision);
            }
        }

        /// <summary>
        /// Get the client configuration file name
        /// </summary>
        /// <param name="serverIP">server IP</param>
        /// <returns>Returns the client configuration file name</returns>
        public override string ClientConfigurationFileName(string serverIP)
        {
            return Path.Combine(ConfigDirectory, string.Format("ClientConfiguration.{0}.xml", serverIP));
        }

        /// <summary>
        /// Runs the application form
        /// </summary>
        /// <param name="form">application form</param>
        public override void Run(Form form)
        {
            Application.Run(form);
        }
    }
}
