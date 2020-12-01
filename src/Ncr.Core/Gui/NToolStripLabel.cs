// <copyright file="NToolStripLabel.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Gui
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the NToolStripLabel class
    /// </summary>
    public class NToolStripLabel : ToolStripLabel
    {
        /// <summary>
        /// Initializes a new instance of the NToolStripLabel class
        /// </summary>
        /// <param name="text">label text</param>
        public NToolStripLabel(string text)
        {
            Text = text;
        }
    }
}
