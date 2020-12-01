// <copyright file="PluginToolBarButton.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Plugins
{
    using System;
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Ncr.Core.Gui;

    /// <summary>
    /// Initializes a new instance of the PluginToolBarButton class
    /// </summary>
    public class PluginToolBarButton : PluginControl
    {
        /// <summary>
        /// Plugin tool bar button text
        /// </summary>
        private string _text;

        /// <summary>
        /// Plugin tool bar button image
        /// </summary>
        private string _image;

        /// <summary>
        /// Plugin tool bar button style
        /// </summary>
        private string _style;

        /// <summary>
        /// Gets or sets the style
        /// </summary>
        [XmlAttribute("Style")]
        public string Style
        {
            get { return _style; }
            set { _style = value; }
        }

        /// <summary>
        /// Gets or sets the image
        /// </summary>
        [XmlAttribute("Image")]
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }

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
        /// Create tool strip button
        /// </summary>
        /// <returns>Returns the tool strip button</returns>
        public ToolStripButton Create()
        {
            ToolStripItemDisplayStyle s = ToolStripItemDisplayStyle.ImageAndText;
            try
            {
                s = (ToolStripItemDisplayStyle)Enum.Parse(ToolStripItemDisplayStyle.ImageAndText.GetType(), Style);
            }
            catch
            {
            }

            return new NToolStripButton(_text, CreateCommand(), Image, s);
        }
    }
}
