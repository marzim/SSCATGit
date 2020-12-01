// <copyright file="SdiWorkbenchWindow.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the SdiWorkbenchWindow class
    /// </summary>
    public class SdiWorkbenchWindow : TabPage, IWorkbenchWindow
    {
        /// <summary>
        /// View interface
        /// </summary>
        private IView _view;

        /// <summary>
        /// Initializes a new instance of the SdiWorkbenchWindow class
        /// </summary>
        /// <param name="view">view interface</param>
        public SdiWorkbenchWindow(IView view)
        {
            View = view;
            Text = View.GetTitle();
            Control control = view as Control;
            control.Dock = DockStyle.Fill;
            Controls.Add(control);
            view.ViewClose += new EventHandler(ViewClose);
            view.TitleChanged += new EventHandler(ViewTitleChanged);
            Font = control.Font;
        }

        /// <summary>
        /// Event handler for window closing
        /// </summary>
        public event EventHandler WindowClosing;

        /// <summary>
        /// Gets or sets the view
        /// </summary>
        public IView View
        {
            get { return _view; }
            set { _view = value; }
        }

        /// <summary>
        /// Event on window closing
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnWindowClosing(EventArgs e)
        {
            if (WindowClosing != null)
            {
                WindowClosing(this, e);
            }
        }

        /// <summary>
        /// Event on view title changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ViewTitleChanged(object sender, EventArgs e)
        {
            Text = View.GetTitle();
        }

        /// <summary>
        /// Event on view close
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ViewClose(object sender, EventArgs e)
        {
            OnWindowClosing(e);
        }
    }
}
