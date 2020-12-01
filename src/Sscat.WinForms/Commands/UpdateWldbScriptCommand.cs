// <copyright file="UpdateWldbScriptCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Commands
{
    using System;
    using Ncr.Core.Commands;
    using Ncr.Core.Views;
    using Sscat.Core.Controllers;
    using Sscat.Core.Util;
    using Sscat.Core.Views;
    using Sscat.Gui;

    /// <summary>
    /// Initializes a new instance of the UpdateWldbScriptCommand class
    /// </summary>
    public class UpdateWldbScriptCommand : AbstractCommand
    {
        /// <summary>
        /// Initializes a new instance of the UpdateWldbScriptCommand class
        /// </summary>
        public UpdateWldbScriptCommand()
        {
        }

        /// <summary>
        /// Runs the update WLDB script command
        /// </summary>
        public override void Run()
        {
            IWldbController controller = new WldbController(new SscatSecurityManager(), new UpdateWldbScriptPane());
            IWldbManagerView wldbManagerView = controller.Manage() as IWldbManagerView;
            WorkbenchSingleton.ShowView(wldbManagerView);
        }
    }
}
