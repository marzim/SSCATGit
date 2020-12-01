// <copyright file="IWorkbenchLayout.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the IWorkbenchLayout class
    /// </summary>
    public interface IWorkbenchLayout
    {
        /// <summary>
        /// Sets the workbench
        /// </summary>
        IWorkbench Workbench { set; }

        /// <summary>
        /// Show the view
        /// </summary>
        /// <param name="view">view interface</param>
        void ShowView(IView view);

        /// <summary>
        /// Show dialog view
        /// </summary>
        /// <param name="window">window interface</param>
        /// <returns>Returns the dialog result</returns>
        DialogResult ShowDialogView(IWin32Window window);

        /// <summary>
        /// Closes all windows
        /// </summary>
        void CloseAllWindows();

        /// <summary>
        /// Closes active window
        /// </summary>
        void CloseActiveWindow();
    }
}
