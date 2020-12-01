// <copyright file="ConsoleWorkbenchLayout.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the ConsoleWorkbenchLayout class
    /// </summary>
    public class ConsoleWorkbenchLayout : AbstractWorkbenchLayout
    {
        /// <summary>
        /// Show view
        /// </summary>
        /// <param name="view">view interface</param>
        public override void ShowView(IView view)
        {
            view.ShowView();
        }

        /// <summary>
        /// Show dialog view
        /// </summary>
        /// <param name="window">windows interface</param>
        /// <returns>Returns the dialog result</returns>
        public override DialogResult ShowDialogView(IWin32Window window)
        {
            return DialogResult.OK;
        }

        /// <summary>
        /// Close all windows
        /// </summary>
        public override void CloseAllWindows()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Close active window
        /// </summary>
        public override void CloseActiveWindow()
        {
            throw new NotImplementedException();
        }
    }
}
