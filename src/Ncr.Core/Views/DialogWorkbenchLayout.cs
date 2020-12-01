// <copyright file="DialogWorkbenchLayout.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the DialogWorkbenchLayout class
    /// </summary>
    public class DialogWorkbenchLayout : AbstractWorkbenchLayout
    {
        /// <summary>
        /// Initializes a new instance of the DialogWorkbenchLayout class
        /// </summary>
        public DialogWorkbenchLayout()
        {
        }

        /// <summary>
        /// Show view
        /// </summary>
        /// <param name="view">view interface</param>
        public override void ShowView(IView view)
        {
            new DialogWindow(view).ShowDialog();
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
