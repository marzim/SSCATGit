// <copyright file="PlayScripts.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System;
    using Ncr.Core.Commands;
    using Ncr.Core.Controllers;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Core.Controllers;

    /// <summary>
    /// Initializes a new instance of the PlayScripts class
    /// </summary>
    public class PlayScripts : AbstractCommand
    {
        /// <summary>
        /// Lane controller
        /// </summary>
        private LaneController _controller;

        /// <summary>
        /// Initializes a new instance of the PlayScripts class
        /// </summary>
        public PlayScripts()
            : this((LaneController)ControllerBuilder.GetControllerFactory().CreateController("Lane", 2))
        {
        }

        /// <summary>
        /// Initializes a new instance of the PlayScripts class
        /// </summary>
        /// <param name="controller">lane controller</param>
        public PlayScripts(LaneController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Plays the scripts
        /// </summary>
        public override void Run()
        {
            try
            {
                WorkbenchSingleton.ShowView(_controller.Play());
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
        }
    }
}
