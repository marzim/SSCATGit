// <copyright file="DialogWindow.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the DialogWindow class
    /// </summary>
    public class DialogWindow : Form, IWorkbenchWindow
    {
        /// <summary>
        /// View interface
        /// </summary>
        private IView _view;

        /// <summary>
        /// Initializes a new instance of the DialogWindow class
        /// </summary>
        /// <param name="view">view interface</param>
        public DialogWindow(IView view)
        {
            View = view;
            Control control = view as Control;
            control.Dock = DockStyle.Fill;
            Text = view.GetTitle();
            Size size = control.Size;
            ClientSize = new Size(size.Width, size.Height);
            Controls.Add(control);
            View.ViewClose += new EventHandler(ViewClose);
        }

        /// <summary>
        /// Finalizes an instance of the DialogWindow class
        /// </summary>
        ~DialogWindow()
        {
            View.ViewClose -= new EventHandler(ViewClose);
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
        /// Event on shown
        /// </summary>
        /// <param name="e">event arguments</param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            View.ShowView();
        }

        /// <summary>
        /// Event on view close
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ViewClose(object sender, EventArgs e)
        {
            Close();
        }
    }
}
