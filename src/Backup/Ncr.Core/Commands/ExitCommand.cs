// <copyright file="ExitCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Commands
{
    using Ncr.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ExitCommand class
    /// </summary>
    public class ExitCommand : AbstractCommand
    {
        /// <summary>
        /// Run exit command action
        /// </summary>
        public override void Run()
        {
            WorkbenchSingleton.MainForm.Close();
        }
    }
}
