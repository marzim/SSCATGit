// <copyright file="ShowScripts.cs" company="NCR">
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
    /// Initializes a new instance of the ShowScripts class
    /// </summary>
    public class ShowScripts : AbstractCommand
    {
        /// <summary>
        /// Lane controller
        /// </summary>
        private LaneController _controller;

        /// <summary>
        /// Initializes a new instance of the ShowScripts class
        /// </summary>
        public ShowScripts()
            : this((LaneController)ControllerBuilder.GetControllerFactory().CreateController("Lane", 1))
        {
        }

        /// <summary>
        /// Initializes a new instance of the ShowScripts class
        /// </summary>
        /// <param name="controller">lane controller</param>
        public ShowScripts(LaneController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Displays the scripts
        /// </summary>
        public override void Run()
        {
            try
            {
                WorkbenchSingleton.ShowView(_controller.Show());
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                MessageService.ShowError(ex.Message);
            }
        }
    }
}
