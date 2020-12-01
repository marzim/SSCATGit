// <copyright file="ConsoleOutputView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Views
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Views;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ConsoleOutputView class
    /// </summary>
    public class ConsoleOutputView : BaseConsoleView, IOutputView
    {
        /// <summary>
        /// Visibility of the console output
        /// </summary>
        private bool _visible = true;

        /// <summary>
        /// Gets or sets a value indicating whether the console output is visible
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        /// <summary>
        /// Sets a value indicating whether word wrapping is enabled
        /// </summary>
        public bool WordWrap
        {
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Writes to the console
        /// </summary>
        /// <param name="text">text to write</param>
        public void Write(string text)
        {
            Console.Write(text);
        }

        /// <summary>
        /// Writes to the console
        /// </summary>
        /// <param name="text">text to write</param>
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Shows the console
        /// </summary>
        public void Show()
        {
        }

        /// <summary>
        /// Shows the dialog
        /// </summary>
        /// <returns>Returns a dialog result</returns>
        public DialogResult ShowDialog()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clears the command console
        /// </summary>
        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
