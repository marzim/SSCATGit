// <copyright file="MessageBoxMessageProvider.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Util
{
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the AbstractLogger class
    /// </summary>
    public class MessageBoxMessageProvider : IMessageProvider
    {
        /// <summary>
        /// Show information
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public void ShowInfo(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Show error
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public void ShowError(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Show error on top
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public void ShowErrorOnTop(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
        }

        /// <summary>
        /// Show warning
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public void ShowWarning(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Show warning on top
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        public void ShowWarningOnTop(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
        }

        /// <summary>
        /// Show yes or no options
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        /// <returns>Returns true</returns>
        public bool ShowYesNo(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Show yes, no, or cancel options
        /// </summary>
        /// <param name="message">message to write</param>
        /// <param name="caption">caption to provide</param>
        /// <returns>Returns yes dialog result</returns>
        public DialogResult ShowYesNoCancel(string message, string caption)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }
    }
}