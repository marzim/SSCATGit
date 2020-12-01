// <copyright file="IView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System;

    /// <summary>
    /// Initializes a new instance of the IView interface
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Event handler for title changed
        /// </summary>
        event EventHandler TitleChanged;

        /// <summary>
        /// Event handler for view close
        /// </summary>
        event EventHandler ViewClose;

        /// <summary>
        /// Event handler for view show
        /// </summary>
        event EventHandler ViewShow;

        /// <summary>
        /// Show view
        /// </summary>
        void ShowView();

        /// <summary>
        /// Close view
        /// </summary>
        void CloseView();

        /// <summary>
        /// Sets the title
        /// </summary>
        /// <param name="title">title to set</param>
        void SetTitle(string title);

        /// <summary>
        /// Gets the title
        /// </summary>
        /// <returns>Returns the title</returns>
        string GetTitle();
    }
}
