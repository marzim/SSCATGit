// <copyright file="MessageService.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes static members of the MessageService class
    /// </summary>
    public static class MessageService
    {
        /// <summary>
        /// Message provider interface
        /// </summary>
        private static IMessageProvider _provider;

        /// <summary>
        /// Attach message provider
        /// </summary>
        /// <param name="provider">message provider</param>
        public static void Attach(IMessageProvider provider)
        {
            MessageService._provider = provider;
        }

        /// <summary>
        /// Show information
        /// </summary>
        /// <param name="message">message to write</param>
        public static void ShowInfo(string message)
        {
            ShowInfo(message, "Information");
        }

        /// <summary>
        /// Show information
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public static void ShowInfo(string message, string caption)
        {
            if (_provider == null)
            {
                throw new ArgumentNullException("MessageProvider");
            }

            _provider.ShowInfo(message, caption);
        }

        /// <summary>
        /// Show error
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public static void ShowError(string message, string caption)
        {
            if (_provider == null)
            {
                throw new ArgumentNullException("MessageProvider");
            }

            _provider.ShowError(message, caption);
        }

        /// <summary>
        /// Show error on top
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public static void ShowErrorOnTop(string message, string caption)
        {
            if (_provider == null)
            {
                throw new ArgumentNullException("MessageProvider");
            }

            _provider.ShowErrorOnTop(message, caption);
        }

        /// <summary>
        /// Show error
        /// </summary>
        /// <param name="message">message to write</param>
        public static void ShowError(string message)
        {
            ShowError(message, "Error");
        }

        /// <summary>
        /// Show error on top
        /// </summary>
        /// <param name="message">message to write</param>
        public static void ShowErrorOnTop(string message)
        {
            ShowErrorOnTop(message, "Error");
        }

        /// <summary>
        /// Show warning
        /// </summary>
        /// <param name="message">message to write</param>
        public static void ShowWarning(string message)
        {
            ShowWarning(message, "Warning");
        }

        /// <summary>
        /// Show warning on top
        /// </summary>
        /// <param name="message">message to write</param>
        public static void ShowWarningOnTop(string message)
        {
            ShowWarningOnTop(message, "Warning");
        }

        /// <summary>
        /// Show warning
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public static void ShowWarning(string message, string caption)
        {
            if (_provider == null)
            {
                throw new ArgumentNullException("MessageProvider");
            }

            _provider.ShowWarning(message, caption);
        }

        /// <summary>
        /// Show warning on top
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public static void ShowWarningOnTop(string message, string caption)
        {
            if (_provider == null)
            {
                throw new ArgumentNullException("MessageProvider");
            }

            _provider.ShowWarningOnTop(message, caption);
        }

        /// <summary>
        /// Show yes or no options
        /// </summary>
        /// <param name="message">message to write</param>
        /// <returns>Returns true</returns>
        public static bool ShowYesNo(string message)
        {
            return ShowYesNo(message, "Question");
        }

        /// <summary>
        /// Show yes or no options
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        /// <returns>Returns true</returns>
        public static bool ShowYesNo(string message, string caption)
        {
            if (_provider == null)
            {
                throw new ArgumentNullException("MessageProvider");
            }

            return _provider.ShowYesNo(message, caption);
        }

        /// <summary>
        /// Show yes, no, or cancel options
        /// </summary>
        /// <param name="message">message to write</param>
        /// <returns>Returns yes dialog result</returns>
        public static DialogResult ShowYesNoCancel(string message)
        {
            return ShowYesNoCancel(message, "Question");
        }

        /// <summary>
        /// Show yes, no, or cancel options
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        /// <returns>Returns yes dialog result</returns>
        public static DialogResult ShowYesNoCancel(string message, string caption)
        {
            if (_provider == null)
            {
                throw new ArgumentNullException("MessageProvider");
            }

            return _provider.ShowYesNoCancel(message, caption);
        }
    }
}