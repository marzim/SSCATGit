// <copyright file="OutputPane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Gui
{
    using System;
    using System.Windows.Forms;
    using Sscat.Core.Models;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the OutputPane class
    /// </summary>
    public partial class OutputPane : UserControl, IOutputView
    {
        /// <summary>
        /// Log for output pane
        /// </summary>
        private Log _log = new Log();

        /// <summary>
        /// Initializes a new instance of the OutputPane class
        /// </summary>
        public OutputPane()
        {
            InitializeComponent();
            _log.Changed += new EventHandler(LogChanged);

            richTextBoxOutput.TextChanged += new EventHandler(RichTextBoxTextChanged);
        }

        /// <summary>
        /// Sets a value indicating whether or not to word wrap
        /// </summary>
        public bool WordWrap
        {
            set
            {
                toolStripButtonWordWrap.Checked = value;
                ToolStripButtonWordWrapClick(this, null);
            }
        }

        /// <summary>
        /// Writes given text to log
        /// </summary>
        /// <param name="text">text to write</param>
        public void Write(string text)
        {
            _log.AppendLog(text);
        }

        /// <summary>
        /// Writes given text to log
        /// </summary>
        /// <param name="text">text to write</param>
        public void WriteLine(string text)
        {
            Write(text);
        }
        
        /// <summary>
        /// Show the dialog
        /// </summary>
        /// <returns>Returns the dialog result</returns>
        public DialogResult ShowDialog()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clicks the clear button
        /// </summary>
        public void Clear()
        {
            ToolStripButtonClearClick(this, null);
        }

        /// <summary>
        /// Event for rich text box text has changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        public void RichTextBoxTextChanged(object sender, EventArgs e)
        {
            richTextBoxOutput.SelectionLength = 0;
            richTextBoxOutput.SelectionStart = richTextBoxOutput.Text.Length;
            richTextBoxOutput.ScrollToCaret();
        }

        /// <summary>
        /// Event for log changed
        /// </summary>
        /// <param name="sender">Object sender</param>
        /// <param name="e">event arguments</param>
        private void LogChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(LogChanged), new object[] { sender, e });
            }
            else
            {
                richTextBoxOutput.Text = _log.ToString();
            }
        }

        /// <summary>
        /// Event for clicking the clear logs button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ToolStripButtonClearClick(object sender, EventArgs e)
        {
            _log.Clear();
        }

        /// <summary>
        /// Event for clicking the word wrap button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ToolStripButtonWordWrapClick(object sender, EventArgs e)
        {
            richTextBoxOutput.WordWrap = toolStripButtonWordWrap.Checked = !toolStripButtonWordWrap.Checked;
        }
    }
}
