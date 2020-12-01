// <copyright file="GenerateScripts.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using Ncr.Core.Commands;
    using Ncr.Core.Controllers;
    using Ncr.Core.Views;
    using Sscat.Core.Controllers;

    /// <summary>
    /// Initializes a new instance of the GenerateScripts class
    /// </summary>
    public class GenerateScripts : AbstractCommand
    {
        /// <summary>
        /// Lane Controller
        /// </summary>
        private LaneController _controller;

        /// <summary>
        ///  Initializes a new instance of the GenerateScripts class
        /// </summary>
        public GenerateScripts()
            : this((LaneController)ControllerBuilder.GetControllerFactory().CreateController("Lane", 2))
        {
        }

        /// <summary>
        /// Initializes a new instance of the GenerateScripts class
        /// </summary>
        /// <param name="controller">lane controller</param>
        public GenerateScripts(LaneController controller)
        {
            _controller = controller;
        }

        /// <summary>
        /// Runs script generator
        /// </summary>
        public override void Run()
        {
            try
            {
                WorkbenchSingleton.ShowView(_controller.Generate());
            }
            catch
            {
                throw;
            }
        }
    }
}
