// <copyright file="MSRCardForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Gui
{
    using System;
    using Ncr.Core.Gui;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the MSRCardForm class
    /// </summary>
    public partial class MSRCardForm : BaseForm
    {
        /// <summary>
        /// MSR card
        /// </summary>
        private MSRCard _card;

        /// <summary>
        /// Initializes a new instance of the MSRCardForm class
        /// </summary>
        public MSRCardForm()
            : this(new MSRCard())
        {
        }

        /// <summary>
        /// Initializes a new instance of the MSRCardForm class
        /// </summary>
        /// <param name="card">MSR card</param>
        public MSRCardForm(MSRCard card)
        {
            InitializeComponent();
            Card = card;
        }

        /// <summary>
        /// Gets or sets the MSR card
        /// </summary>
        public MSRCard Card
        {
            get
            {
                return _card;
            }

            set
            {
                _card = value;
                textBoxName.Text = _card.Name;
                textBoxTrack1.Text = _card.Track1;
                textBoxTrack2.Text = _card.Track2;
                textBoxTrack3.Text = _card.Track3;
            }
        }

        /// <summary>
        /// Click the ok button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        public void ButtonOKClick(object sender, EventArgs e)
        {
            _card.Name = textBoxName.Text;
            _card.Track1 = textBoxTrack1.Text;
            _card.Track2 = textBoxTrack2.Text;
            _card.Track3 = textBoxTrack3.Text;
        }
    }
}
