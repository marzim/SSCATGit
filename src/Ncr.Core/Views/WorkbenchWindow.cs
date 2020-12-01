// <copyright file="WorkbenchWindow.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the WorkbenchWindow class
    /// </summary>
    public class WorkbenchWindow : Form, IWorkbenchWindow
    {
        /// <summary>
        /// View interface
        /// </summary>
        private IView _view;

        /// <summary>
        /// Initializes a new instance of the WorkbenchWindow class
        /// </summary>
        /// <param name="view">View interface</param>
        public WorkbenchWindow(IView view)
        {
            View = view;
            view.ViewClose += delegate { Close(); };

            UserControl control = view as UserControl;
            Size size = control.Size;
            ClientSize = new Size(size.Width, size.Height);
            Controls.Add(control);
            ShowInTaskbar = MinimizeBox = MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Gets or sets the view
        /// </summary>
        public IView View
        {
            get { return _view; }
            set { _view = value; }
        }

        /// <summary>
        /// Close window
        /// </summary>
        public void CloseWindow()
        {
            _view.CloseView();
        }

        /// <summary>
        /// Event on shown
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            View.ShowView();
        }
    }
}
