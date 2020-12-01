// <copyright file="UpdateWldbCommand.cs" company="NCR">
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
    /// Initializes a new instance of the UpdateWldbCommand class
    /// </summary>
    public class UpdateWldbCommand : AbstractCommand
    {
        /// <summary>
        /// Initializes a new instance of the UpdateWldbCommand class
        /// </summary>
        public UpdateWldbCommand()
        {
        }

        /// <summary>
        /// Run the update WLDB command
        /// </summary>
        public override void Run()
        {
            IWldbController controller = new WldbController(new SscatSecurityManager(), new UpdateWldbPane());
            IWldbManagerView wldbManagerView = controller.Manage() as IWldbManagerView;
            WorkbenchSingleton.ShowView(wldbManagerView);
        }
    }
}
