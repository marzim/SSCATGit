// <copyright file="MdiWorkbenchLayout.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the MdiWorkbenchLayout class
    /// </summary>
    public class MdiWorkbenchLayout : AbstractWorkbenchLayout
    {
        /// <summary>
        /// Initializes a new instance of the MdiWorkbenchLayout class
        /// </summary>
        public MdiWorkbenchLayout()
        {
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
                    Form form = value as Form;
                    form.IsMdiContainer = true;
                }
            }
        }

        /// <summary>
        /// Closes all windows
        /// </summary>
        public override void CloseAllWindows()
        {
            foreach (Form f in (Workbench as Form).MdiChildren)
            {
                (f as IWorkbenchWindow).View.CloseView();
            }
        }

        /// <summary>
        /// Closes active window
        /// </summary>
        public override void CloseActiveWindow()
        {
            Form f = (Workbench as Form).ActiveMdiChild;
            if (f != null)
            {
                (f as IWorkbenchWindow).View.CloseView();
            }
        }

        /// <summary>
        /// Show view
        /// </summary>
        /// <param name="view">view interface</param>
        public override void ShowView(IView view)
        {
            MdiWorkbenchWindow window = new MdiWorkbenchWindow(view);
            window.KeyPreview = true;
            window.KeyDown += new KeyEventHandler(WindowKeyDown);
            window.MdiParent = Workbench as Form;
            window.Show();
        }

        /// <summary>
        /// Event for window key down
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">key event arguments</param>
        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                (sender as IWorkbenchWindow).View.CloseView();
            }
        }
    }
}
