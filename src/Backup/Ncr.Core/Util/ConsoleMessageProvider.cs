// <copyright file="ConsoleMessageProvider.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the ConsoleMessageProvider class
    /// </summary>
    public class ConsoleMessageProvider : IMessageProvider
    {
        /// <summary>
        /// Show information
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public virtual void ShowInfo(string message, string caption)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Show error
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public void ShowError(string message, string caption)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Show error on top
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public void ShowErrorOnTop(string message, string caption)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Show warning
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public void ShowWarning(string message, string caption)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Show warning on top
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public void ShowWarningOnTop(string message, string caption)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Show yes or no options
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        /// <returns>Returns true</returns>
        public virtual bool ShowYesNo(string message, string caption)
        {
            return true; // FIXME: Get console ReadLine
        }

        /// <summary>
        /// Show yes, no, or cancel options
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        /// <returns>Returns yes dialog result</returns>
        public virtual DialogResult ShowYesNoCancel(string message, string caption)
        {
            return DialogResult.Yes;
        }
    }
}