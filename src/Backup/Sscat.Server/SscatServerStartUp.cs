// <copyright file="SscatServerStartUp.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Server
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using Ncr.Core.Emulators;
    using Ncr.Core.Models;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Core.Controllers;
    using Sscat.Core.Emulators;
    using Sscat.Core.Net;
    using Sscat.Core.Repositories;
    using Sscat.Core.Repositories.IO;
    using Sscat.Core.Services;
    using Sscat.Core.Util;
    using Sscat.Server.Gui;

    /// <summary>
    /// Initializes a new instance of the SscatServerStartUp class
    /// </summary>
    public class SscatServerStartUp
    {
        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// SSCAT server
        /// </summary>
        private SscatServer _server;

        /// <summary>
        /// Play script request dispatcher
        /// </summary>
        private PlayScriptRequestDispatcher _playScriptRequestDispatcher;

        /// <summary>
        /// Lane service
        /// </summary>
        private LaneService _service;

        /// <summary>
        /// Interface for plugin repository
        /// </summary>
        private IPluginRepository _pluginRepository;

        /// <summary>
        /// Initializes a new instance of the SscatServerStartUp class
        /// </summary>
        /// <param name="appManager">application manager</param>
        /// <param name="dnsManager">domain name servers manager</param>
        /// <param name="logger">server logger</param>
        /// <param name="messageProvider">message provider</param>
        /// <param name="server">sscat server</param>
        /// <param name="service">lane service</param>
        /// <param name="pluginRepository">plugin repository</param>
        public SscatServerStartUp(IApplicationManager appManager, IDnsManager dnsManager, ILogger logger, IMessageProvider messageProvider, SscatServer server, LaneService service, IPluginRepository pluginRepository)
        {
            ApplicationUtility.Attach(appManager);
            DnsHelper.Attach(dnsManager);
            LoggingService.Attach(logger);
            MessageService.Attach(messageProvider);

            _server = server;
            _lane = server.Lane;
            _service = service;

            _pluginRepository = pluginRepository;
        }

        /// <summary>
        /// Start the SSCAT server
        /// </summary>
        public void Start()
        {
            ServerController controller = null;
            try
            {
                Application.EnableVisualStyles();
                controller = new ServerController(_server, _service, new ServerForm());
                IWorkbench workbench = controller.Index() as IWorkbench;
                WorkbenchSingleton.Attach(workbench, new SdiWorkbenchLayout(), _pluginRepository.Load(Path.Combine(ApplicationUtility.PluginsDirectory, "ServerWorkbenchPlugin.xml")));
                if (!HasServerStarted())
                {
                    _lane.SecurityManager = new SscatSecurityManager();
                    _lane.ApplicationLauncher = new SscatApplicationLauncher();
                    _lane.AddEmulator(new BagScale(), new CashAcceptor(), new CoinAcceptor(), new MotionSensorCoupon(), new Msr(), new PCSignatureCapture(), new PinPad(), new Scale(), new Scanner(), new CoinChanger(), new POSPrinter(), new CashTrough());

                    _lane.Configuration = _service.ReadLaneConfiguration(ApplicationUtility.LaneConfigurationFileName);
                    if (FileHelper.Exists(@"C:\scot\config\FastLane3.1.xml"))
                    {
                        _lane.Configuration.Display = _service.ReadPsxDisplay(@"C:\scot\config\FastLane3.1.xml");
                    }

                    _lane.LaunchPad = new SscatLaunchPad(new DefaultLaunchPadLauncher(), ApplicationFactory.GetApplication(_lane, new Rap()), new StoreServer());
                    _lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(ServerConnectionAdding);
                    if (_lane.LaunchPad.Exists)
                    {
                        _lane.LaunchPad.Start();
                        if (_lane.LaunchPad.Application is Lane)
                        {
                            if (!_lane.PsxConnections.ContainsKey("AUTOMATION"))
                            {
                                // HACK: Added Psx here because Psx API can't be instantiated inside a thread and server DataArrived event is inside a thread!
                                _lane.PsxConnections.Add(_service.CreatePsx("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000));
                            }
                        }
                    }

                    SscatClient serverClient = new SscatClient(new XmlResponseParser(), new EasyClientEngine());
                    serverClient.AddDispatcher(new ConfigResponseDispatcher());
                    serverClient.AddDispatcher(new ConfigCheckedResponseDispatcher());
                    serverClient.AddDispatcher(new ConfigLoadedResponseDispatcher());

                    _server.AddDispatcher(new GenerateScriptsRequestDispatcher(serverClient, new IOConfigFilesRepository()));
                    _server.AddDispatcher(new GetConfigRequestDispatcher(new IOConfigFileRepository()));
                    _playScriptRequestDispatcher = new PlayScriptRequestDispatcher(_service);
                    _server.AddDispatcher(_playScriptRequestDispatcher);
                    _server.AddDispatcher(new CheckConfigRequestDispatcher(new IOConfigFileRepository()));
                    _server.AddDispatcher(new LoadConfigRequestDispatcher(new IOConfigFileRepository(), _lane.LaunchPad));
                    _server.AddDispatcher(new StopPlayerRequestDispatcher());
                    _server.ClientInitialize += new EventHandler(ServerClientInitialize);

                    WorkbenchSingleton.MainForm.Closing += new CancelEventHandler(WorkbenchSingletonMainFormClosing);

                    _server.Listen();

                    ApplicationUtility.Run(WorkbenchSingleton.MainForm);
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
            finally
            {
                _lane.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(ServerConnectionAdding);
                _server.ClientInitialize -= new EventHandler(ServerClientInitialize);
                WorkbenchSingleton.MainForm.Closing -= new CancelEventHandler(WorkbenchSingletonMainFormClosing);
            }
        }

        /// <summary>
        /// Check if the SSCAT server has started
        /// </summary>
        /// <returns>Returns true if started, false otherwise</returns>
        private bool HasServerStarted()
        {
            if (ProcessUtility.HasStarted("Sscat.Server", true))
            {
                MessageService.ShowInfo(ResourceUtility.GetString("instance.running", "Another instance is running"));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Event for server connection adding
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">psx wrapper event arguments</param>
        private void ServerConnectionAdding(object sender, PsxWrapperEventArgs e)
        {
            try
            {
                if (!_server.Lane.PsxConnections.ContainsKey(e.ConnectionName))
                {
                    ConnectPsx(e.ConnectionName, e.HostName, e.ServiceName, e.Timeout);
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
        /// Connect PSX
        /// </summary>
        /// <param name="connectionName">connection name</param>
        /// <param name="hostName">host name</param>
        /// <param name="serviceName">service name</param>
        /// <param name="timeout">timeout amount</param>
        private void ConnectPsx(string connectionName, string hostName, string serviceName, int timeout)
        {
            LoggingService.Info(string.Format("Connecting to PSX {0}@{1}", connectionName, hostName));
            _server.Lane.PsxConnections.Add(_service.CreatePsx(hostName, serviceName, connectionName, timeout));
            LoggingService.Info(string.Format("Connected to PSX {0}@{1}", connectionName, hostName));
        }

        /// <summary>
        /// Event for server client initialize
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ServerClientInitialize(object sender, EventArgs e)
        {
            SscatClient client = new SscatClient(new XmlResponseParser(), new EasyClientEngine());
            client.AddDispatcher(new ConfigResponseDispatcher());
            client.AddDispatcher(new ConfigCheckedResponseDispatcher());
            client.AddDispatcher(new ConfigLoadedResponseDispatcher());
            _playScriptRequestDispatcher.Client = client;
        }

        /// <summary>
        /// Event for workbench singleton main form closing
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">cancel event arguments</param>
        private void WorkbenchSingletonMainFormClosing(object sender, CancelEventArgs e)
        {
            if (_lane.LaunchPad.HasApplication)
            {
                _lane.LaunchPad.Kill();
            }
        }
    }
}
