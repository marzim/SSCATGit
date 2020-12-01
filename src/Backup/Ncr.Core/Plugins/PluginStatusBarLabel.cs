// <copyright file="PluginStatusBarLabel.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Plugins
{
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Ncr.Core.Gui;

    /// <summary>
    /// Initializes a new instance of the PluginStatusBarLabel class
    /// </summary>
    public class PluginStatusBarLabel
    {
        /// <summary>
        /// Plugin status bar label text
        /// </summary>
        private string _text;

        /// <summary>
        /// Gets or sets the text
        /// </summary>
        [XmlAttribute("Text")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// Create the tool strip label
        /// </summary>
        /// <returns>Returns the new tool strip label</returns>
        public ToolStripLabel Create()
        {
            return new NToolStripLabel(_text);
        }
    }
}
