// <copyright file="AboutForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using Ncr.Core.Gui;
    using Ncr.Core.Util;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the AboutForm class
    /// </summary>
    public partial class AboutForm : BaseForm, IAboutView
    {
        /// <summary>
        /// Initializes a new instance of the AboutForm class
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
            Text = "About " + ApplicationUtility.ProductName;
            LoadDependeciesInfo();
            label1.Text = string.Format(
                "{0}     Version {1}" + Environment.NewLine + "Copyright © 2017 By NCR Corporation Duluth, GA U.S.A. All Rights Reserved",
                ApplicationUtility.ProductName,
                ApplicationUtility.ProductVersion);

            label4.Text = FileHelper.ReadToEnd(Path.Combine(ApplicationUtility.DocsDirectory, "CONTRIBUTORS.txt"));
        }

        /// <summary>
        /// Load dependencies info
        /// </summary>
        private void LoadDependeciesInfo()
        {
            foreach (string file in Directory.GetFiles(ApplicationUtility.RootDirectory))
            {
                if (Path.GetExtension(file).Equals(".exe") || Path.GetExtension(file).Equals(".dll"))
                {
                    this.listBox1.Items.Add(Path.GetFileName(file) + "       Version " + FileVersionInfo.GetVersionInfo(file).FileVersion);
                }
            }
        }
    }
}
