// <copyright file="CardForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using Ncr.Core.Gui;
    using Sscat.Core.Config;

    /// <summary>
    /// Initializes a new instance of the CardForm class
    /// </summary>
    public partial class CardForm : BaseForm
    {
        /// <summary>
        /// MSR card
        /// </summary>
        private MSRCard _card;
        
        /// <summary>
        /// Initializes a new instance of the CardForm class
        /// </summary>
        /// <param name="card">MSR card</param>
        /// <param name="disableCardName">whether or not to disable the card name</param>
        /// <param name="note">note label</param>
        public CardForm(MSRCard card, bool disableCardName, string note)
            : this(new MSRCard())
        {
            Card = card;
            textBoxName.Enabled = !disableCardName;
            labelNote.Text = note;
        }

        /// <summary>
        /// Initializes a new instance of the CardForm class
        /// </summary>
        /// <param name="card">MSR card</param>
        public CardForm(MSRCard card)
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
        /// Clicks the OK button
        /// </summary>
        public void ClickOKButton()
        {
            ButtonOKClick(this, null);
        }

        /// <summary>
        /// Event to click the OK button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonOKClick(object sender, EventArgs e)
        {
            _card.Name = textBoxName.Text;
            _card.Track1 = textBoxTrack1.Text;
            _card.Track2 = textBoxTrack2.Text;
            _card.Track3 = textBoxTrack3.Text;
        }
    }
}
