// <copyright file="NToolStripButton.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Gui
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the NToolStripButton class
    /// </summary>
    public class NToolStripButton : ToolStripButton
    {
        /// <summary>
        /// Command interface
        /// </summary>
        private ICommand _command;

        /// <summary>
        /// Initializes a new instance of the NToolStripButton class
        /// </summary>
        /// <param name="text">text to display</param>
        /// <param name="command">command interface</param>
        /// <param name="imageFile">image file</param>
        /// <param name="style">display style</param>
        public NToolStripButton(string text, ICommand command, string imageFile, ToolStripItemDisplayStyle style)
        {
            Text = text;
            _command = command;

            if (command != null)
            {
                command.Owner = this;
            }

            DisplayStyle = style;
            if (FileHelper.Exists(imageFile))
            {
                Image = ImageHelper.FromFile(imageFile);
            }
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
