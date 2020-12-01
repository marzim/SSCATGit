// <copyright file="MessageForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using Ncr.Core.Gui;
    using Sscat.Core.Commands.Gui;

    /// <summary>
    /// Initializes a new instance of the MessageForm class
    /// </summary>
    public partial class MessageForm : BaseForm, IMessageView
    {
        /// <summary>
        /// Initializes a new instance of the MessageForm class
        /// </summary>
        public MessageForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Progress event handler delegate
        /// </summary>
        /// <param name="text">progress text</param>
        /// <param name="progress">progress amount</param>
        private delegate void ProgressEventHandler(string text, int progress);

        /// <summary>
        /// Test event handler delegate
        /// </summary>
        /// <param name="e">event arguments</param>
        private delegate void TestEventHandler(EventArgs e);

        /// <summary>
        /// Sets the progress
        /// </summary>
        /// <param name="text">progress text</param>
        /// <param name="progress">progress amount</param>
        public void SetProgress(string text, int progress)
        {
            if (InvokeRequired)
            {
                Invoke(new ProgressEventHandler(SetProgress), new object[] { text, progress });
            }
            else
            {
                labelMessage.Text = text;
                progressBar1.Value = progress;
            }
        }

        /// <summary>
        /// Checks if form is closed
        /// </summary>
        /// <returns>Returns true if disposed, false otherwise</returns>
        public bool IsClosed()
        {
            return IsDisposed;
        }

        /// <summary>
        /// Event for on closed
        /// </summary>
        /// <param name="e">event arguments</param>
        protected override void OnClosed(EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new TestEventHandler(OnClosed), new object[] { e });
            }
            else
            {
                base.OnClosed(e);
            }
        }
    }
}
