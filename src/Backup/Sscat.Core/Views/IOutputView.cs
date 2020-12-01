// <copyright file="IOutputView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the IOutputView interface
    /// </summary>
    public interface IOutputView
    {
        /// <summary>
        /// Sets a value indicating whether or not to word wrap
        /// </summary>
        bool WordWrap { set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not to turn on visibility
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// Writes the given text
        /// </summary>
        /// <param name="text">text to write</param>
        void Write(string text);

        /// <summary>
        /// Writes the given text
        /// </summary>
        /// <param name="text">text to write</param>
        void WriteLine(string text);

        /// <summary>
        /// Shows the view
        /// </summary>
        void Show();

        /// <summary>
        /// Clears the view
        /// </summary>
        void Clear();

        /// <summary>
        /// Show the dialog
        /// </summary>
        /// <returns>Returns the dialog result</returns>
        DialogResult ShowDialog();
    }
}
