// <copyright file="WorkbenchLayout.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System;
    using System.Collections;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the WorkbenchLayout class
    /// </summary>
    public class WorkbenchLayout : AbstractWorkbenchLayout
    {
        /// <summary>
        /// Child form
        /// </summary>
        private Form _childForm;

        /// <summary>
        /// Workbench layout pads
        /// </summary>
        private Hashtable _pads = new Hashtable();

        /// <summary>
        /// Initializes a new instance of the WorkbenchLayout class
        /// </summary>
        public WorkbenchLayout()
        {
        }

        /// <summary>
        /// Show view
        /// </summary>
        /// <param name="view">view interface</param>
        public override void ShowView(IView view)
        {
            _childForm = view is Form ? view as Form : new WorkbenchWindow(view);
            _childForm.Text = view.GetTitle();
            _childForm.ShowDialog(Workbench as Form);
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
