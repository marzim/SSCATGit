// <copyright file="CustomScriptGenerator.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Commands
{
    using Ncr.Core.Commands;
    using Ncr.Core.Views;
    using Sscat.Core;
    using Sscat.Core.Controllers;
    using Sscat.Core.Emulators;
    using Sscat.Core.Services;
    using Sscat.Core.Views;
    using Sscat.Gui;

    /// <summary>
    /// Initializes a new instance of the CustomScriptGenerator class
    /// </summary>
    public class CustomScriptGenerator : AbstractCommand
    {
        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Lane Service
        /// </summary>
        private LaneService _service;

        /// <summary>
        /// Initializes a new instance of the CustomScriptGenerator class
        /// </summary>
        public CustomScriptGenerator()
            : this(SscatContext.Lane, SscatContext.LaneService)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CustomScriptGenerator class 
        /// </summary>
        /// <param name="lane">sscat lane</param>
        /// <param name="service">lane service</param>
        public CustomScriptGenerator(SscatLane lane, LaneService service)
        {
            _lane = lane;
            _service = service;
        }

        /// <summary>
        /// Run the custom script generator
        /// </summary>
        public override void Run()
        {
            LaneController controller = new LaneController(new CustomGeneratorPane(), _lane, _service);
            ICustomGeneratorView customGeneratorView = controller.CustomGenerate() as ICustomGeneratorView;
            WorkbenchSingleton.ShowView(customGeneratorView);
        }
    }
}
