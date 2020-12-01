// <copyright file="IMessageView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System.Windows.Forms;
    using Ncr.Core.Views;

    /// <summary>
    /// Interface for the message view
    /// </summary>
    public interface IMessageView : IView
    {
        /// <summary>
        /// Displays the progress percentage
        /// </summary>
        /// <param name="text">text to display</param>
        /// <param name="progress">progress percentage</param>
        void SetProgress(string text, int progress);

        /// <summary>
        /// Close the console
        /// </summary>
        void Close();

        /// <summary>
        /// Indicates if console is closed
        /// </summary>
        /// <returns>Returns true</returns>
        bool IsClosed();

        /// <summary>
        /// Shows the dialog
        /// </summary>
        /// <returns>Returns the dialog result</returns>
        DialogResult ShowDialog();
    }
}
