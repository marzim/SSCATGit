// <copyright file="SdiWorkbenchLayout.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the SdiWorkbenchLayout class
    /// </summary>
    public class SdiWorkbenchLayout : AbstractWorkbenchLayout
    {
        /// <summary>
        /// Tab control
        /// </summary>
        private TabControl _tabControl = new TabControl();

        /// <summary>
        /// Initializes a new instance of the SdiWorkbenchLayout class
        /// </summary>
        public SdiWorkbenchLayout()
        {
            _tabControl.Font = new Font("Arial", 11, FontStyle.Bold);
        }

        /// <summary>
        /// Sets the workbench
        /// </summary>
        public override IWorkbench Workbench
        {
            set
            {
                if (value != null)
                {
                    base.Workbench = value;
                    _tabControl.Dock = DockStyle.Fill;
                    (value as Form).Controls.Add(_tabControl);
                }
            }
        }

        /// <summary>
        /// Closes all windows
        /// </summary>
        public override void CloseAllWindows()
        {
            foreach (TabPage p in _tabControl.TabPages)
            {
                (p as IWorkbenchWindow).View.CloseView();
            }
        }

        /// <summary>
        /// Closes active window
        /// </summary>
        public override void CloseActiveWindow()
        {
            TabPage p = _tabControl.SelectedTab;
            if (p != null)
            {
                (p as IWorkbenchWindow).View.CloseView();
            }
        }

        /// <summary>
        /// Show view
        /// </summary>
        /// <param name="view">view interface</param>
        public override void ShowView(IView view)
        {
            SdiWorkbenchWindow window = new SdiWorkbenchWindow(view);
            window.WindowClosing += new EventHandler(WindowClosing);
            _tabControl.TabPages.Add(window);
            _tabControl.SelectedTab = window;
        }

        /// <summary>
        /// Event on window closing
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void WindowClosing(object sender, EventArgs e)
        {
            _tabControl.TabPages.Remove(sender as TabPage);
        }
    }
}
