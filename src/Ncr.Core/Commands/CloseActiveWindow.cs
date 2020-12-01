// <copyright file="CloseActiveWindow.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Commands
{
    using Ncr.Core.Views;

    /// <summary>
    /// Initializes a new instance of the CloseActiveWindow class
    /// </summary>
    public class CloseActiveWindow : AbstractCommand
    {
        /// <summary>
        /// Run close active window action
        /// </summary>
        public override void Run()
        {
            WorkbenchSingleton.CloseActiveWindow();
        }
    }
}
