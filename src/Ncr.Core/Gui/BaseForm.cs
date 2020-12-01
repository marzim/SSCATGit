// <copyright file="BaseForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Gui
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Views;

    /// <summary>
    /// Initializes a new instance of the BaseForm class
    /// </summary>
    public partial class BaseForm : Form, IView
    {
        /// <summary>
        /// Initializes a new instance of the BaseForm class
        /// </summary>
        public BaseForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Delegate for string event handler
        /// </summary>
        /// <param name="text">event text</param>
        private delegate void StringEventHandler(string text);

        /// <summary>
        /// Event handler for title being changed
        /// </summary>
        public event EventHandler TitleChanged;

        /// <summary>
        /// Event handler for view being closed
        /// </summary>
        public event EventHandler ViewClose;

        /// <summary>
        /// Event handler for view being shown
        /// </summary>
        public event EventHandler ViewShow;

        /// <summary>
        /// Show the view
        /// </summary>
        public void ShowView()
        {
            OnViewShow(null);
        }

        /// <summary>
        /// Close the view
        /// </summary>
        public virtual void CloseView()
        {
            OnViewClose(null);
        }

        /// <summary>
        /// Set the title
        /// </summary>
        /// <param name="title">title text</param>
        public void SetTitle(string title)
        {
            if (InvokeRequired)
            {
                Invoke(new StringEventHandler(SetTitle), new object[] { title });
            }
            else
            {
                Text = title;
                OnTitleChanged(null);
            }
        }

        /// <summary>
        /// Get the title
        /// </summary>
        /// <returns>Returns the title</returns>
        public string GetTitle()
        {
            return Text;
        }

        /// <summary>
        /// Event for on view show
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnViewShow(EventArgs e)
        {
            if (ViewShow != null)
            {
                ViewShow(this, e);
            }
        }

        /// <summary>
        /// Event for title changed
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnTitleChanged(EventArgs e)
        {
            if (TitleChanged != null)
            {
                TitleChanged(this, e);
            }
        }

        /// <summary>
        /// Event for on view close
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnViewClose(EventArgs e)
        {
            if (ViewClose != null)
            {
                ViewClose(this, e);
            }
        }
    }
}
