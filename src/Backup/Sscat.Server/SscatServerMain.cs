// <copyright file="SscatServerMain.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Server
{
    using System;
    using System.IO;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Sscat.Core;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Net;
    using Sscat.Core.Repositories.IO;
    using Sscat.Core.Repositories.Xml;
    using Sscat.Core.Services;

    /// <summary>
    /// Initializes a new instance of the SscatServerMain class
    /// </summary>
    public class SscatServerMain
    {
        /// <summary>
        /// Entry point for the SSCAT server application
        /// </summary>
        /// <param name="args">SSCAT server arguments</param>
        [STAThread]
        public static void Main(string[] args)
        {
            SscatContext.Lane = new SscatLane();
            SscatServerStartUp startup = new SscatServerStartUp(
                new ApplicationManager(),
                new DnsManager(),
                new Log4NetLogger(),
                new MessageBoxMessageProvider(),
                new SscatServer(30000, new XmlRequestParser(), SscatContext.Lane, new EasyServerEngine(30000, "SSCAT Server", new XmlRequestParser())),
                new LaneService(
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
                    null), 
                    new XmlPluginRepository());

            startup.Start();
        }
    }
}
