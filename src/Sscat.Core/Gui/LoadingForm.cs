// <copyright file="LoadingForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the LoadingForm class
    /// </summary>
    public partial class LoadingForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the LoadingForm class
        /// </summary>
        /// <param name="title">form title</param>
        /// <param name="message">form message</param>
        public LoadingForm(string title, string message)
        {
            InitializeComponent();

            Text = title;
            messageLabel.Text = message;
        }
    }
}