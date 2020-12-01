// <copyright file="GenerateDiagnostics.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using System.IO;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Emulators;
    using Sscat.Core.Repositories;
    using Sscat.Core.Repositories.Xml;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the GenerateDiagnostics class
    /// </summary>
    public class GenerateDiagnostics : AbstractCommand
    {
        /// <summary>
        /// SSCAT Lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Interface for the lane configuration repository
        /// </summary>
        private ILaneConfigurationRepository _configRepository;
        
        /// <summary>
        /// Interface for the launch pad config repository
        /// </summary>
        private ILaunchPadConfigRepository _launchPadRepository;

        /// <summary>
        /// Initializes a new instance of the GenerateDiagnostics class
        /// </summary>
        public GenerateDiagnostics()
            : this(SscatContext.Lane, new XmlLaneConfigurationRepository(), new XmlLaunchPadConfigRepository())
        {
        }

        /// <summary>
        /// Initializes a new instance of the GenerateDiagnostics class
        /// </summary>
        /// <param name="lane">sscat lane</param>
        /// <param name="configRepository">lane configuration repository</param>
        /// <param name="launchPadRepository">launch pad repository</param>
        public GenerateDiagnostics(SscatLane lane, ILaneConfigurationRepository configRepository, ILaunchPadConfigRepository launchPadRepository)
        {
            _lane = lane;
            _configRepository = configRepository;
            _launchPadRepository = launchPadRepository;
        }

        /// <summary>
        /// Gets a value indicating whether the diag location exists
        /// </summary>
        public override bool CanRun
        {
            get
            {
                return FileHelper.Exists(new GetDiagLocation(@"C:\scot\config\LaunchPadConfig_XP.xml", _launchPadRepository).GetFilename());
            }
        }

        /// <summary>
        /// Gets a value indicating whether the generate diagnostics process has started
        /// </summary>
        private bool GenerateDiagsStarted
        {
            get
            {
                return ProcessUtility.HasStarted("GetDiagFiles") ||
                  ProcessUtility.HasStarted("GetDiagFilesU") ||
                  ApiHelper.FindWindow("#32770", "GetDiagFiles") != IntPtr.Zero;
            }
        }

        /// <summary>
        /// Starts generating diagnostic files
        /// </summary>
        public override void Run()
        {
            ThreadHelper.Sleep(5000);
            if (!GenerateDiagsStarted)
            {
                ThreadHelper.Start(GenDiags);
            }
            else
            {
                MessageService.ShowWarningOnTop("Generate diagnostics is currently running.");
            }
        }

        /// <summary>
        /// Generates the diagnostic files
        /// </summary>
        private void GenDiags()
        {
            string diagfolder = string.Format(@"C:\sscat\Diags\Diags{0}", DateTime.Now.ToString("_MMdd-hhmmss"));
            string configfile = Path.Combine(ApplicationUtility.ConfigDirectory, string.Format("ClientConfiguration.{0}.xml", DnsHelper.GetLocalIPAddress()));
            if (!FileHelper.Exists(configfile))
            {
                configfile = ApplicationUtility.LaneConfigurationFileName;
            }

            LaneConfiguration p = _configRepository.Read(configfile);
            string temp = p.PlayerConfiguration.DiagTempPath.ToString();
            if (temp.Equals(string.Empty) || !DirectoryHelper.Exists(temp))
            {
                MessageService.ShowError(string.Format("Unable to find GetDiag Temp Path. File {0} cannot be found. Please modify in Player Settings to continue.", temp));
                return;
            }

            try
            {
                DiagnosticsUtility gd = new DiagnosticsUtility();
                gd.GetDiag(diagfolder, temp);
                MessageService.ShowInfo(string.Format("Diags is now in {0}", diagfolder));
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
        }
    }
}
