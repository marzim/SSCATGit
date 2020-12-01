// <copyright file="ConsoleControllerFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Commands
{
    using Ncr.Core.Controllers;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Controllers;
    using Sscat.Core.Emulators;
    using Sscat.Core.Services;
    using Sscat.Core.Util;
    using Sscat.Views;

    /// <summary>
    /// Initializes a new instance of the ConsoleControllerFactory class
    /// </summary>
    public class ConsoleControllerFactory : IControllerFactory
    {
        /// <summary>
        /// Console controller factory arguments
        /// </summary>
        private StringArray _args;

        /// <summary>
        /// Instance of the SscatLane class
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Instance of the LaneService class
        /// </summary>
        private LaneService _laneService;

        /// <summary>
        /// Initializes a new instance of the ConsoleControllerFactory class
        /// </summary>
        /// <param name="args">console controller factory arguments</param>
        /// <param name="lane">SSCAT lane</param>
        /// <param name="laneService">lane service</param>
        public ConsoleControllerFactory(string[] args, SscatLane lane, LaneService laneService)
        {
            _args = new StringArray(args);
            _lane = lane;
            _laneService = laneService;
        }

        /// <summary>
        /// Creates a lane controller
        /// </summary>
        /// <param name="controllerName">name of the controller</param>
        /// <param name="offset">length of the script</param>
        /// <returns>Returns a new lane controller for running scripts in SSCAT command console</returns>
        public IController CreateController(string controllerName, int offset)
        {
            if (controllerName == "Lane")
            {
                GeneratorConfiguration generatorConfig = _lane.Configuration.GeneratorConfiguration;

                // Check if a report file name is given for the second parameter after the command
                string reportFileName = string.Empty;
                if (_args[2].EndsWith(".csv"))
                {
                    // if report file name is given, make sure offset for the scripts array starts at the next index over
                    reportFileName = _args[2];
                    offset++;
                }

                ConsolePlayerView consolePlayerView = new ConsolePlayerView(
                            _laneService.GetScripts(_args.ToArray(), offset),
                            ConvertUtility.ToInt32(_args[1], 1),
                            reportFileName);

                ConsoleScriptGeneratorView consoleScriptGeneratorView = new ConsoleScriptGeneratorView(
                            _args[1],
                            _args[2],
                            _args[3],
                            generatorConfig.SegmentedScripts,
                            generatorConfig.ScriptOutputDirectory,
                            generatorConfig.GenerateLast,
                            generatorConfig.LastScriptsNumber);

                ConsoleScriptListView consoleScriptListView = new ConsoleScriptListView(
                            _laneService.GetScripts(_args.ToArray(), offset));

                return new LaneController(_lane, _laneService, consolePlayerView, consoleScriptGeneratorView, consoleScriptListView);
            }

            return null;
        }
    }
}
