// <copyright file="SscatConsoleMain.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat
{
    using System;
    using System.IO;
    using Ncr.Core.Commands;
    using Ncr.Core.Controllers;
    using Ncr.Core.Emulators;
    using Ncr.Core.Models;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Commands;
    using Sscat.Core;
    using Sscat.Core.Commands.Gui;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Repositories.IO;
    using Sscat.Core.Repositories.Xml;
    using Sscat.Core.Services;
    using Sscat.Core.Util;
    using Sscat.Views;

    /// <summary>
    /// Initializes a new instance of the ConsoleCleanFilesView class.
    /// </summary>
    public static class SscatConsoleMain
    {
        /// <summary>
        /// Lane service
        /// </summary>
        private static LaneService _service;
        
        /// <summary>
        /// SSCAT lane
        /// </summary>
        private static SscatLane _lane;

        /// <summary>
        /// Main entry point for SSCAT command console mode.
        /// </summary>
        /// <param name="args">Arguments for SSCAT commands</param>
        [STAThread]
        public static void Main(string[] args)
        {
#if DEBUG
            // Sets arguments through a command console read after program has started instead when in Developer Mode.
            Console.WriteLine("Developer Mode activated. Type desired argument here:");
            string arguments = Console.ReadLine();
            args = arguments.Split(' ');
#endif
            _lane = GetLane();
            _service = new LaneService(
                _lane,
                new XmlSSCATScriptRepository(),
                new IOConfigFileRepository(),
                new IOConfigFilesRepository(),
                new XmlPlayerConfigurationRepository(),
                new XmlGeneratorConfigurationRepository(),
                new XmlLaneConfigurationRepository(),
                new XmlReportRepository(),
                new XmlPsxDisplayRepository(),
                new CpuAndMemoryLogger(3000, new StreamWriterLogger(Path.Combine(ApplicationUtility.LogsDirectory, "serverprocess.log.csv"), new CsvLogFormatter()), "Sscat"),
                new CpuAndMemoryLogger(3000, new StreamWriterLogger(Path.Combine(ApplicationUtility.LogsDirectory, "scotprocess.log.csv"), new CsvLogFormatter()), _lane.ProcessName));

            Run(
                args,
                new ApplicationManager(),
                new ConsoleMessageProvider(),
                new Log4NetLogger(),
                new ConsoleWorkbench(),
                new ConsoleWorkbenchLayout(),
                _lane,
                new SscatSecurityManager(),
                _service);
            
#if DEBUG
            // Prompts for user input before exiting command console window in Developer Mode. 
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
#endif
        }

        /// <summary>
        /// Creates a new SSCAT Lane with emulators, security manager, and launch pad.
        /// </summary>
        /// <returns>Returns the new lane.</returns>
        public static SscatLane GetLane()
        {
            _lane = new SscatLane(60000 * 5, true, true);
            SscatContext.Lane = _lane;
            _lane.SecurityManager = new SscatSecurityManager();
            _lane.ApplicationLauncher = new SscatApplicationLauncher();
            _lane.LaunchPad = new SscatLaunchPad(new DefaultLaunchPadLauncher(), ApplicationFactory.GetApplication(_lane, new Rap()), new StoreServer());
            _lane.AddEmulator(new BagScale(), new CashAcceptor(), new CoinAcceptor(), new MotionSensorCoupon(), new Msr(), new PCSignatureCapture(), new PinPad(), new Scale(), new Scanner(), new CoinChanger(), new POSPrinter(), new CashTrough());
            return _lane;
        }

        /// <summary>
        /// Runs the SSCAT commands from command console.
        /// </summary>
        /// <param name="args">command console arguments</param>
        /// <param name="appManager">interface for the application manager</param>
        /// <param name="messageProvider">interface for the message provider</param>
        /// <param name="logger">interface for the logger</param>
        /// <param name="workbench">interface for the workbench</param>
        /// <param name="workbenchLayout">interface for the workbench layout</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="securityManager">interface for the sscat security manager</param>
        /// <param name="service">lane service</param>
        public static void Run(string[] args, IApplicationManager appManager, IMessageProvider messageProvider, ILogger logger, IWorkbench workbench, IWorkbenchLayout workbenchLayout, SscatLane lane, ISscatSecurityManager securityManager, LaneService service)
        {
            ApplicationUtility.Attach(appManager);
            MessageService.Attach(messageProvider);

            CommandBuilder.CommandFactory = new CommandFactory(args);

            LoggingService.Attach(logger);
            try
            {
                if (args.Length > 0)
                {
                    WorkbenchSingleton.Attach(workbench, workbenchLayout);

                    lane.SecurityManager = securityManager;

                    // FIXME: Why not assign these configurations inside the service
                    lane.Configuration = service.ReadLaneConfiguration(Path.Combine(ApplicationUtility.ConfigDirectory, "LaneConfiguration.xml"));
                    if (FileHelper.Exists(@"C:\scot\config\FastLane3.1.xml"))
                    {
                        lane.Configuration.Display = service.ReadPsxDisplay(@"C:\scot\config\FastLane3.1.xml");
                    }

                    lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);

                    ControllerBuilder.SetControllerFactory(new ConsoleControllerFactory(args, lane, service));

                    ICommand cmd = CommandBuilder.CommandFactory.CreateCommand(args[0]);
                    cmd.Run();
                }
                else
                {
                    new ShowHelp(new ConsoleHelp()).Run();
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Connects the lane with psx
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
                    IPsx psx = _service.CreatePsx(e.HostName, e.ServiceName, e.ConnectionName, e.Timeout);
                    _lane.PsxConnections.Add(psx);
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
    }
}