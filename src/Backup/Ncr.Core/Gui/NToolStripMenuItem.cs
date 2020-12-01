// <copyright file="NToolStripMenuItem.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Gui
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the NToolStripMenuItem class
    /// </summary>
    public class NToolStripMenuItem : ToolStripMenuItem
    {
        /// <summary>
        /// Command interface
        /// </summary>
        private ICommand _command;

        /// <summary>
        /// Initializes a new instance of the NToolStripMenuItem class
        /// </summary>
        /// <param name="text">menu text</param>
        /// <param name="command">menu command</param>
        /// <param name="image">menu image</param>
        /// <param name="shortcut">menu shortcut</param>
        public NToolStripMenuItem(string text, ICommand command, string image, string shortcut)
        {
            Text = text;
            _command = command;
            if (command != null)
            {
                command.Owner = this;
                Enabled = command.CanRun;
            }

            if (shortcut != null && shortcut != string.Empty)
            {
                ShortcutKeys = (Keys)Enum.Parse(typeof(Keys), shortcut);
            }

            if (FileHelper.Exists(image))
            {
                Image = ImageHelper.FromFile(image);
            }
        }

        /// <summary>
        /// Event for on drop down show
        /// </summary>
        /// <param name="e">event arguments</param>
        protected override void OnDropDownShow(EventArgs e)
        {
            if (_command != null)
            {
                Checked = _command.Checked;
            }

            base.OnDropDownShow(e);
        }

        /// <summary>
        /// Event for on click
        /// </summary>
        /// <param name="e">event arguments</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (_command != null)
            {
                _command.Run();
            }
        }
    }
}
