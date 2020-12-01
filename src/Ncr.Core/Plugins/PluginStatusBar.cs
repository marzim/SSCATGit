// <copyright file="PluginStatusBar.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Plugins
{
    using System.Windows.Forms;
    using System.Xml.Serialization;
    using Ncr.Core.Gui;

    /// <summary>
    /// Initializes a new instance of the PluginStatusBar class
    /// </summary>
    public class PluginStatusBar
    {
        /// <summary>
        /// Plugin status bar labels
        /// </summary>
        private PluginStatusBarLabel[] _labels;

        /// <summary>
        /// Gets a value indicating whether or not the plugin has labels
        /// </summary>
        public bool HasLabels
        {
            get { return _labels != null && _labels.Length > 0; }
        }

        /// <summary>
        /// Gets or sets the plugin status bar label
        /// </summary>
        [XmlElement("StatusBarLabel")]
        public PluginStatusBarLabel[] Labels
        {
            get
            {
                if (_labels == null)
                {
                    return new PluginStatusBarLabel[0];
                }

                return _labels;
            }

            set
            {
                _labels = value;
            }
        }

        /// <summary>
        /// Create status strip
        /// </summary>
        /// <returns>Returns the status strip</returns>
        public StatusStrip Create()
        {
            StatusStrip bar = null;
            if (HasLabels)
            {
                bar = new NStatusStrip();
                foreach (PluginStatusBarLabel label in Labels)
                {
                    bar.Items.Add(label.Create());
                }
            }

            return bar;
        }
    }
}
