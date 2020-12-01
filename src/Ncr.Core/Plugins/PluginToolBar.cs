// <copyright file="PluginToolBar.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Plugins
{
    using System.Windows.Forms;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the PluginToolBar class
    /// </summary>
    public class PluginToolBar
    {
        /// <summary>
        /// Plugin tool bar buttons
        /// </summary>
        private PluginToolBarButton[] _buttons;

        /// <summary>
        /// Gets a value indicating whether or not the plugin tool bar has buttons
        /// </summary>
        [XmlIgnore]
        public bool HasButtons
        {
            get { return Buttons.Length > 0; }
        }

        /// <summary>
        /// Gets or sets the plugin tool bar buttons
        /// </summary>
        [XmlElement("ToolBarButton")]
        public PluginToolBarButton[] Buttons
        {
            get
            {
                if (_buttons == null)
                {
                    return new PluginToolBarButton[0];
                }

                return _buttons;
            }

            set
            {
                _buttons = value;
            }
        }

        /// <summary>
        /// Creates a tool strip
        /// </summary>
        /// <returns>Returns the new tool strip</returns>
        public ToolStrip Create()
        {
            ToolStrip bar = null;
            if (HasButtons)
            {
                bar = new ToolStrip();
                foreach (PluginToolBarButton button in Buttons)
                {
                    bar.Items.Add(button.Create());
                }
            }

            return bar;
        }
    }
}
