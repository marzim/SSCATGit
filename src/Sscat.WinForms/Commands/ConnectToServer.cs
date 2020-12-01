// <copyright file="ConnectToServer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Commands
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Text.RegularExpressions;
    using Ncr.Core.Commands;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Core.Config;
    using Sscat.Core.Controllers;
    using Sscat.Core.Models;
    using Sscat.Core.Net;
    using Sscat.Core.Net.Dispatchers.Response;
    using Sscat.Core.Repositories.IO;
    using Sscat.Core.Repositories.Xml;
    using Sscat.Core.Services;
    using Sscat.Core.Views;
    using Sscat.Gui;

    /// <summary>
    /// Initializes a new instance of the ConnectToServer class
    /// </summary>
    public class ConnectToServer : AbstractCommand
    {
        /// <summary>
        /// Runs the connection to the server
        /// </summary>
        public override void Run()
        {
            try
            {
                IConnectToServerView connectToServerView = new ConnectToServerForm();
                IClientListView clientListView = WorkbenchSingleton.Workbench as IClientListView;

                SscatClient client = new SscatClient(new XmlResponseParser(), new EasyClientEngine());
                GeneratorPane objGeneratorPane = new GeneratorPane();
                connectToServerView.Connecting += delegate
                {
                    try
                    {
                        client.Server = connectToServerView.ServerName;
                        client.Validate();
                        if (!client.HasErrors)
                        {
                            if (!clientListView.Clients.Contains(client.Server))
                            {
                                client.Connect();
                                objGeneratorPane.ReflectDefaultSettingsAtUI(client.Server);
                            }
                            else
                            {
                                MessageService.ShowWarning("Cannot connect to the same server twice.");
                                connectToServerView.Stop();
                            }
                        }
                        else
                        {
                            MessageService.ShowWarning(client.Errors.ToString());
                            connectToServerView.Stop();
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        string[] lineNumber = Regex.Split(ex.Message, @"\D+");
                        string message = string.Format("Error Message: {0}Syntax error found in C:\\sscat\\config\\ClientConfiguration.xml at line {1} & column {2}{0}{0}Troubleshooting Tips: {0}Close SSCAT Client and Server along with SSCO(ScotApp & SSCOUI){0}Open C:\\sscat\\config\\ClientConfiguration.xml at line {1} & column {2}{0}Correct XML syntax error{0}{0}", Environment.NewLine, lineNumber[1], lineNumber[2]);
                        LoggingService.Error(message + ex.ToString());
                        MessageService.ShowError(message);
                        connectToServerView.Stop();
                    }
                    catch (Exception ex)
                    {
                        LoggingService.Error(ex.ToString());
                        MessageService.ShowError(ex.Message);
                        connectToServerView.Stop();
                    }
                };
                ClientService service = new ClientService(
                    new XmlClientConfigurationRepository(),
                    new IOConfigFilesRepository(),
                    new IOConfigFileRepository(),
                    new XmlSSCATScriptRepository(),
                    new CpuAndMemoryLogger(3000, new StreamWriterLogger(Path.Combine(ApplicationUtility.LogsDirectory, "sscatprocess.log.csv"), new CsvLogFormatter()), "Sscat.WinForms"));
                ClientController controller = new ClientController(
                    client,
                    service,
                    new ClientPane(
                        objGeneratorPane,
                        new PlayerPane(),
                        new ClientConfigurationPane()));
                controller.ScriptFileNameCheck += delegate(object sender, GeneratorConfigurationEventArgs e)
                {
                    try
                    {
                        // PROCESS 1: Remove the .xml extension if the user provided it
                        if (e.Config.ScriptName.EndsWith(".xml", true, CultureInfo.CurrentCulture))
                        {
                            e.Config.ScriptName = e.Config.ScriptName.Remove(e.Config.ScriptName.Length - 4);
                        }

                        // VALIDATION 1: Script filename should not be empty
                        e.Config.AddErrorIf("Script name provided is empty or blank! Please provide another script name.", e.Config.ScriptName.Trim().Equals(string.Empty));
                        if (e.Config.ScriptName.Trim().Equals(string.Empty))
                        {
                            LoggingService.Error("Script name provided is empty or blank! Please provide another script name.");
                        }

                        // VALIDATION 2: Script filename should not have been used yet
                        e.Config.AddErrorIf("Script name already exists.", DirectoryHelper.GetFiles(e.Config.ScriptOutputDirectory, e.Config.ScriptName + "_*.xml").Length > 0);
                        LoggingService.Exists(string.Format("the scriptname is {0} - {1}", Path.Combine(e.Config.ScriptOutputDirectory, e.Config.ScriptName), DirectoryHelper.GetFiles(e.Config.ScriptOutputDirectory, e.Config.ScriptName).Length > 0));

                        // VALIDATION 3: Script filename should not have been used to name a confi folder
                        e.Config.AddErrorIf(string.Format(@"{1}Script Name - {0}.xml {1}You may have used the same script name before and forgot to delete the corresponding {0} configuration folder where SSCAT saves all the important SSCO config files.{1}{1}Troubleshooting Tips : {1}Please delete/rename the folder or choose another script filename.", e.Config.ScriptName, Environment.NewLine), Directory.Exists(e.Config.ScriptOutputDirectory + "\\" + e.Config.ScriptName));
                    }
                    catch (Exception ex)
                    {
                        LoggingService.Warning(ex.ToString());
                        e.Config.Errors.Add(ex.Message);
                    }
                };
                IClientView clientView = null;
                controller.ClientConnected += delegate
                {
                    client.AddDispatcher(new ConfigResponseDispatcher());
                    client.AddDispatcher(new ScriptsResponseDispatcher(new IOConfigFileRepository(), new XmlSSCATScriptRepository(), client.Server));
                    client.AddDispatcher(new ScriptEventResponseDispatcher());
                    client.AddDispatcher(new ScriptWarningEventResponseDispatcher());
                    client.AddDispatcher(new ScriptResultResponseDispatcher());
                    client.AddDispatcher(new PlayerStoppedResponseDispatcher());
                    client.AddDispatcher(new ReportResponseDispatcher(new XmlReportRepository()));
                    client.AddDispatcher(new MessageResponseDispatcher());
                    client.AddDispatcher(new ErrorResponseDispatcher());
                    client.AddDispatcher(new StopResponseDispatcher());
                    clientListView.Clients.Add(client.Server, client);
                    connectToServerView.CloseView();
                    clientView = controller.Index() as IClientView;
                    WorkbenchSingleton.ShowView(clientView);
                };
                controller.ClientRejecting += delegate
                {
                    connectToServerView.Stop();
                };
                controller.ClientDisconnected += delegate
                {
                    clientListView.Clients.Remove(client.Server);
                };
                controller.ClientTimeout += delegate(object sender, NetworkEventArgs e)
                {
                    connectToServerView.Stop();
                };
                WorkbenchSingleton.ShowDialog(connectToServerView);
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
        }
    }
}
