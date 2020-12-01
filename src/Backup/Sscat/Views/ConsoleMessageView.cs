// <copyright file="ConsoleMessageView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Views
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Views;
    using Sscat.Core.Commands.Gui;

    /// <summary>
    /// Initializes a new instance of the ConsoleMessageView class
    /// </summary>
    public class ConsoleMessageView : BaseConsoleView, IMessageView
    {
        /// <summary>
        /// Displays the progress percentage
        /// </summary>
        /// <param name="text">text to display</param>
        /// <param name="progress">progress percentage</param>
        public void SetProgress(string text, int progress)
        {
            Console.WriteLine(text + "..." + progress + "%");
        }

        /// <summary>
        /// Close the console
        /// </summary>
        public void Close()
        {
        }

        /// <summary>
        /// Shows the dialog
        /// </summary>
        /// <returns>Returns the dialog result</returns>
        public DialogResult ShowDialog()
        {
            return DialogResult.OK;
        }

        /// <summary>
        /// Indicates if console is closed
        /// </summary>
        /// <returns>Returns true</returns>
        public bool IsClosed()
        {
            return true;
        }
    }
}
