// <copyright file="CloseAllWindows.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Commands
{
    using Ncr.Core.Views;

    /// <summary>
    /// Initializes a new instance of the CloseAllWindows class
    /// </summary>
    public class CloseAllWindows : AbstractCommand
    {
        /// <summary>
        /// RUn closing all windows command
        /// </summary>
        public override void Run()
        {
            OnRunning("Closing all windows...");
            WorkbenchSingleton.CloseAllWindows();
        }
    }
}
