// <copyright file="BaseConsoleView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System;

    /// <summary>
    /// Initializes a new instance of the BaseConsoleView class
    /// </summary>
    public class BaseConsoleView : IView
    {
        /// <summary>
        /// Console view title
        /// </summary>
        private string _title;

        /// <summary>
        /// Event handler for title changed
        /// </summary>
        public event EventHandler TitleChanged;

        /// <summary>
        /// Event handler for view close
        /// </summary>
        public event EventHandler ViewClose;

        /// <summary>
        /// Event handler for view show
        /// </summary>
        public event EventHandler ViewShow;

        /// <summary>
        /// Gets the title
        /// </summary>
        /// <returns>Returns the title</returns>
        public string GetTitle()
        {
            return _title;
        }
        
        /// <summary>
        /// Sets the title
        /// </summary>
        /// <param name="title">title to set</param>
        public void SetTitle(string title)
        {
            _title = title;
            OnTitleChanged(null);
        }

        /// <summary>
        /// Show view
        /// </summary>
        public virtual void ShowView()
        {
            OnViewShow(null);
        }

        /// <summary>
        /// Close view
        /// </summary>
        public void CloseView()
        {
            OnViewClose(null);
        }

        /// <summary>
        /// Event for on title changed
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
    }
}
