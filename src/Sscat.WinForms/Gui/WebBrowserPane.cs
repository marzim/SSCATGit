// <copyright file="WebBrowserPane.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Gui
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the WebBrowserPane class
    /// </summary>
    public partial class WebBrowserPane : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the WebBrowserPane class
        /// </summary>
        public WebBrowserPane()
        {
            InitializeComponent();
            toolStripButtonRefresh.Click += delegate { webBrowser1.Refresh(); };
            webBrowser1.Navigating += delegate(object sender, WebBrowserNavigatingEventArgs e)
            {
                OnNavigating(e);
            };
        }

        /// <summary>
        /// Event handle for navigating the web browser
        /// </summary>
        public event WebBrowserNavigatingEventHandler Navigating;

        /// <summary>
        /// Navigate to the given url
        /// </summary>
        /// <param name="url">url to navigate to</param>
        public void Navigate(string url)
        {
            webBrowser1.Navigate(url);
        }

        /// <summary>
        /// Event for on navigating in the web browser
        /// </summary>
        /// <param name="e">web browser navigating event arguments</param>
        protected virtual void OnNavigating(WebBrowserNavigatingEventArgs e)
        {
            if (Navigating != null)
            {
                Navigating(this, e);
            }
        }
    }
}
