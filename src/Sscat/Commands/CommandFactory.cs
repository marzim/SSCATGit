// <copyright file="CommandFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Commands
{
    using System;
    using Ncr.Core.Commands;
    using Sscat.Core;
    using Sscat.Core.Commands.Gui;
    using Sscat.Core.Repositories.Xml;
    using Sscat.Core.Util;
    using Sscat.Views;

    /// <summary>
    /// Initializes a new instance of the CommandFactory class
    /// </summary>
    public class CommandFactory : ICommandFactory
    {
        /// <summary>
        /// Command Factory arguments
        /// </summary>
        private string[] _args;

        /// <summary>
        /// Initializes a new instance of the CommandFactory class
        /// </summary>
        /// <param name="args">command factory arguments</param>
        public CommandFactory(string[] args)
        {
            _args = args;
        }

        /// <summary>
        /// Creates SSCAT console commands
        /// </summary>
        /// <param name="command">command to create</param>
        /// <returns>Returns a SSCAT command if supported</returns>
        public ICommand CreateCommand(string command)
        {
            switch (command)
            {
                case Constants.ConsoleCommand.HELP:
                    return new ShowHelp(new ConsoleHelp());
                case Constants.ConsoleCommand.KILL_SSCO:
                    return new KillSsco();
                case Constants.ConsoleCommand.LAUNCH_SSCO:
                    return new LaunchSsco(SscatContext.Lane, new ConsoleMessageView());
                case Constants.ConsoleCommand.SHOW_SSCO_VERSION:
                    return new ShowSscoVersion();
                case Constants.ConsoleCommand.DELETE_SCOT_LOGS:
                    return new DeleteScotLogs();
                case Constants.ConsoleCommand.HOOK_LOGS:
                    return new HookLogs(_args, new XmlLaneConfigurationRepository());
                case Constants.ConsoleCommand.LIST_LOGS:
                    return new ListFiles("*.log");
                case Constants.ConsoleCommand.LIST_SCRIPTS:
                    return new ListFiles("*.xml");
                case Constants.ConsoleCommand.GENERATE_SCRIPTS:
                    return new GenerateScripts();
                case Constants.ConsoleCommand.PLAY_SCRIPTS:
                    return new PlayScripts();
                case Constants.ConsoleCommand.SHOW_SCRIPTS:
                    return new ShowScripts();
                case Constants.ConsoleCommand.CONVERT_SCRIPTS:
                    return new ConvertScripts();

                default:
                    throw new NotSupportedException(string.Format("Command '{0}' not supported.", command));
            }
        }
    }
}
