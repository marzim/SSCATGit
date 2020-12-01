// <copyright file="AbstractWorkbenchLayout.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Views
{
    using System.Windows.Forms;
    
    /// <summary>
    /// Initializes a new instance of the IWorkbenchLayout class
    /// </summary>
    public abstract class AbstractWorkbenchLayout : IWorkbenchLayout
    {
        /// <summary>
        /// Workbench interface
        /// </summary>
        private IWorkbench _workbench;

        /// <summary>
        /// Gets or sets the workbench
        /// </summary>
        public virtual IWorkbench Workbench
        {
            protected get { return _workbench; }
            set { _workbench = value; }
        }

        /// <summary>
        /// Shows the view
        /// </summary>
        /// <param name="view">view interface</param>
        public abstract void ShowView(IView view);

        /// <summary>
        /// Closes all the windows
        /// </summary>
        public abstract void CloseAllWindows();

        /// <summary>
        /// Closes the active window
        /// </summary>
        public abstract void CloseActiveWindow();

        /// <summary>
        /// Show dialog view
        /// </summary>
        /// <param name="window">windows interface</param>
        /// <returns>Returns the dialog result</returns>
        public virtual DialogResult ShowDialogView(IWin32Window window)
        {
            Form f = window as Form;
            f.MaximizeBox = f.MinimizeBox = f.ShowInTaskbar = false;
            f.FormBorderStyle = FormBorderStyle.FixedDialog;
            f.StartPosition = FormStartPosition.CenterParent;
            f.KeyPreview = true;
            f.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    f.Close();
                }
            };
            return f.ShowDialog(Workbench as Form);
        }
    }
}
