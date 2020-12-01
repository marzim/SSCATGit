// <copyright file="IMessageProvider.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Util
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the IMessageProvider interface
    /// </summary>
    public interface IMessageProvider
    {
        /// <summary>
        /// Show information
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        void ShowInfo(string message, string caption);

        /// <summary>
        /// Show error
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        void ShowError(string message, string caption);

        /// <summary>
        /// Show error on top
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        void ShowErrorOnTop(string message, string caption);

        /// <summary>
        /// Show warning
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        void ShowWarning(string message, string caption);

        /// <summary>
        /// Show warning on top
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        void ShowWarningOnTop(string message, string caption);

        /// <summary>
        /// Show yes or no options
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        /// <returns>Returns true</returns>
        bool ShowYesNo(string message, string caption);

        /// <summary>
        /// Show yes, no, or cancel options
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        /// <returns>Returns yes dialog result</returns>
        DialogResult ShowYesNoCancel(string message, string caption);
    }
}
