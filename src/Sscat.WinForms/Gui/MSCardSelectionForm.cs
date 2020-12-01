// <copyright file="MSCardSelectionForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Sscat.Gui
{
    using System;
    using System.Windows.Forms;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Gui;
    using Sscat.Core.Repositories.Xml;

    /// <summary>
    /// Initializes a new instance of the MSCardSelectionForm class
    /// This form plainly displays a list of MS Cards that a user can use
    /// in his automation scripts. In this form, the user can:
    /// 1. Select an MS Card to use for whatever operation - the selected
    /// MS Card is exposed via NameOfSelectedCard property
    /// 2. Add new MS Card
    /// 3. Edit track values of existing MS Cards
    /// </summary>
    public partial class MSCardSelectionForm : Form
    {
        /// <summary>
        /// Name of selected card
        /// </summary>
        private string _nameOfSelectedCard;

        /// <summary>
        /// Lane configuration file
        /// </summary>
        private LaneConfiguration _laneConfigFile;

        /// <summary>
        /// Client configuration file
        /// </summary>
        private ClientConfiguration _clientConfigFile;

        /// <summary>
        /// Whether or not server is connected
        /// </summary>
        private bool _isConnectedToServer;

        /// <summary>
        /// Whether or not the card selection has changed
        /// </summary>
        private bool _hasCardSelectionChanged;

        /// <summary>
        /// Initializes a new instance of the MSCardSelectionForm class
        /// </summary>
        /// <param name="configFile">lane configuration file</param>
        public MSCardSelectionForm(LaneConfiguration configFile)
        {
            // PROCESS 1: Initialize UI Components
            InitializeComponent();

            // PROCESS: 2: Point reference variables to control changes to list of cards and current selection
            _laneConfigFile = configFile;
            _isConnectedToServer = false;
            _hasCardSelectionChanged = false;

            // PROCESS 3: Display the MS Cards found in the config file
            DisplayMSCardsAtListView();

            // PROCESS 4: Set initial selection to the first item in the list
            MSRCards cards = _laneConfigFile.PlayerConfiguration.WalmartCards;
            if (cards != null || cards.Cards != null)
            {
                listViewMSCards.Items[0].Selected = true;
            }
        }

        /// <summary>
        /// Initializes a new instance of the MSCardSelectionForm class
        /// </summary>
        /// <param name="configFile">client configuration file</param>
        public MSCardSelectionForm(ClientConfiguration configFile)
        {
            // PROCESS 1: Initialize UI Components
            InitializeComponent();

            // PROCESS: 2: Point reference variables to control changes to list of cards and current selection
            _clientConfigFile = configFile;
            _isConnectedToServer = true;
            _hasCardSelectionChanged = false;

            // PROCESS 3: Display the MS Cards found in the config file
            DisplayMSCardsAtListView();

            // PROCESS 4: Set initial selection to the first item in the list
            MSRCards cards = _clientConfigFile.PlayerConfiguration.WalmartCards;
            if (cards != null || cards.Cards != null)
            {
                listViewMSCards.Items[0].Selected = true;
            }
        }

        /// <summary>
        /// Column number
        /// </summary>
        private enum COLUMN_NUMBER
        {
            /// <summary>
            /// Card name
            /// </summary>
            CARD_NAME = 0,

            /// <summary>
            /// First track value
            /// </summary>
            TRACK_VALUE_1 = 1,

            /// <summary>
            /// Second track value
            /// </summary>
            TRACK_VALUE_2 = 2,

            /// <summary>
            /// Third track value
            /// </summary>
            TRACK_VALUE_3 = 3
        }

        /// <summary>
        /// Gets the name of the selected card
        /// </summary>
        public string NameOfSelectedCard
        {
            get { return _nameOfSelectedCard; }
        }

        /// <summary>
        /// Gets a value indicating whether the card selection has changed
        /// </summary>
        public bool HasCardSelectionChanged
        {
            get { return _hasCardSelectionChanged; }
        }

        /// <summary>
        /// Event for click the close button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonCloseWindowClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Display the MS cards at list view
        /// </summary>
        private void DisplayMSCardsAtListView()
        {
            // PRECONDITION 1: The cards shouldn't be null
            MSRCards cards = _isConnectedToServer ?
                _clientConfigFile.PlayerConfiguration.WalmartCards :
                _laneConfigFile.PlayerConfiguration.WalmartCards;
            if (cards == null || cards.Cards == null)
            {
                LoggingService.Error("MSCardSelectionForm-->DisplayMSCardsAtListView(): " +
                                    "An internal program error has occurred! " +
                                    "The variable that holds the list of MS Card is null. ");
                return;
            }

            // PRECONDITION 2: At least one MS Card should be found in the config file
            if (cards.Cards.Length < 1)
            {
                LoggingService.Info("MSCardSelectionForm-->DisplayMSCardsAtListView(): " +
                                    "There are no cards to display at the list view.");
                return;
            }

            // PROCESS 1: Make sure the list view is clear
            listViewMSCards.Items.Clear();

            // PROCESS 2: Update list view with the MS Cards found on the config file
            foreach (MSRCard card in cards.Cards)
            {
                ListViewItem listViewItemTempVar = listViewMSCards.Items.Add(card.Name);
                listViewItemTempVar.SubItems.Add(card.Track1);
                listViewItemTempVar.SubItems.Add(card.Track2);
                listViewItemTempVar.SubItems.Add(card.Track3);
            }
        }

        /// <summary>
        /// EVent for clicking the Add new MS card button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonAddNewMSCardClick(object sender, EventArgs e)
        {
            // PROCESS 1: Load the add new MS Card form to let the user enter card details
            CardForm formButtonAddNewMSCard = new CardForm(new MSRCard(), false, "Please enter the MS Card details.");
            DialogResult cardAddingResult = formButtonAddNewMSCard.ShowDialog(this);

            // POST CONDITION 1: User should have chosen OK Button to proceed
            if (cardAddingResult != DialogResult.OK)
            {
                LoggingService.Info("MSCardSelectionForm-->ButtonAddNewMSCardClick(): User decided to cancel adding of new MS Card.");
                return;
            }

            // POST CONDITION 2: The card entered should have valid details
            formButtonAddNewMSCard.Card.Validate();
            if (formButtonAddNewMSCard.Card.HasErrors)
            {
                MessageBox.Show("Some of the card details provided are invalid! " + formButtonAddNewMSCard.Card.Errors.ToString() + "Cannot save the new card entered.", "Adding New MS Card Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggingService.Error("MSCardSelectionForm-->ButtonAddNewMSCardClick(): Some of the card details provided are invalid! " + formButtonAddNewMSCard.Card.Errors.ToString() + "Cannot save the new card entered.");
                return;
            }

            // POST CONDITION 3: The card entered shouldn't be in the list of MS Cards yet
            MSRCards cards = _isConnectedToServer ?
                _clientConfigFile.PlayerConfiguration.WalmartCards :
                _laneConfigFile.PlayerConfiguration.WalmartCards;
            if (cards.Contains(formButtonAddNewMSCard.Card.Name))
            {
                MessageBox.Show("Card entered is already in the list!", "Adding New MS Card Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggingService.Error("MSCardSelectionForm-->ButtonAddNewMSCardClick(): Card entered is already in the list!");
                return;
            }

            // PROCESS 2: Include the new card in the list of cards
            cards.AddCard(formButtonAddNewMSCard.Card);
            ListViewItem listViewItemTempVar = listViewMSCards.Items.Add(formButtonAddNewMSCard.Card.Name);
            listViewItemTempVar.SubItems.Add(formButtonAddNewMSCard.Card.Track1);
            listViewItemTempVar.SubItems.Add(formButtonAddNewMSCard.Card.Track2);
            listViewItemTempVar.SubItems.Add(formButtonAddNewMSCard.Card.Track3);

            // PROCESS 3: Update the config file with the new card
            if (_isConnectedToServer)
            {
                XmlClientConfigurationRepository repository = new XmlClientConfigurationRepository();
                repository.Save(_clientConfigFile);
            }
            else
            {
                XmlLaneConfigurationRepository repository = new XmlLaneConfigurationRepository();
                repository.Save(_laneConfigFile);
            }

            LoggingService.Info("MSCardSelectionForm-->ButtonAddNewMSCardClick(): " +
                                "Successfully saved the new card " + formButtonAddNewMSCard.Card.Name);
        }

        /// <summary>
        /// Click the select MS card button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonSelectMSCardClick(object sender, EventArgs e)
        {
            // PRECONDITION 1: A card should have been selected
            if (listViewMSCards.SelectedItems.Count < 1)
            {
                MessageBox.Show("You have not selected a card! Please select one to continue with this operation.");
                LoggingService.Error("You have not selected a card! Please select one to continue with this operation.");
                return;
            }

            // PROCESS 1: Get the name of the selected card and save
            _nameOfSelectedCard = listViewMSCards.SelectedItems[0].SubItems[(int)COLUMN_NUMBER.CARD_NAME].Text;
            _hasCardSelectionChanged = true;
            LoggingService.Info("Successfully saved the selected card - " + _nameOfSelectedCard);

            Close();
        }

        /// <summary>
        /// Click the edit MS card button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonEditMSCardClick(object sender, EventArgs e)
        {
            // PRECONDITION 1: A card should have been selected
            if (listViewMSCards.SelectedItems.Count < 1)
            {
                MessageBox.Show("You have not selected a card! Please select one to continue with this operation.", "Edit MS Card Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggingService.Error("You have not selected a card! Please select one to continue with this operation.");
                return;
            }

            // PROCESS 1: Get selected card
            MSRCard selectedCard = new MSRCard();
            selectedCard.Name = listViewMSCards.SelectedItems[0].SubItems[(int)COLUMN_NUMBER.CARD_NAME].Text;
            selectedCard.Track1 = listViewMSCards.SelectedItems[0].SubItems[(int)COLUMN_NUMBER.TRACK_VALUE_1].Text;
            selectedCard.Track2 = listViewMSCards.SelectedItems[0].SubItems[(int)COLUMN_NUMBER.TRACK_VALUE_2].Text;
            selectedCard.Track3 = listViewMSCards.SelectedItems[0].SubItems[(int)COLUMN_NUMBER.TRACK_VALUE_3].Text;

            // PROCESS 2: Launch the MS Card editor window to let the user edit the track values
            CardForm formMSCardEditor = new CardForm(selectedCard, true, "You can only revise the track values at this point to avoid complications in the scripts.");
            DialogResult cardEdittingResult = formMSCardEditor.ShowDialog(this);

            // POST CONDITION 1: User should have chosen OK Button to proceed
            if (cardEdittingResult != DialogResult.OK)
            {
                LoggingService.Info("MSCardSelectionForm-->ButtonEditMSCardClick(): User decided to cancel the revisions made to the MS Card.");
                return;
            }

            // POST CONDITION 2: The revisions made to the track values should be valid
            formMSCardEditor.Card.Validate();
            if (formMSCardEditor.Card.HasErrors)
            {
                MessageBox.Show("Some of the card details provided are invalid! " + formMSCardEditor.Card.Errors.ToString() + "Cannot save the changes made to the MS Card.", "Edit New MS Card Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggingService.Error("MSCardSelectionForm-->ButtonEditMSCardClick(): Some of the card details provided are invalid! " + formMSCardEditor.Card.Errors.ToString() + "Cannot save the changes made to the MS Card.");
                return;
            }

            // PROCESS 3: Display the changes made to the MS Card at the list view
            listViewMSCards.SelectedItems[0].SubItems[(int)COLUMN_NUMBER.TRACK_VALUE_1].Text = formMSCardEditor.Card.Track1;
            listViewMSCards.SelectedItems[0].SubItems[(int)COLUMN_NUMBER.TRACK_VALUE_2].Text = formMSCardEditor.Card.Track2;
            listViewMSCards.SelectedItems[0].SubItems[(int)COLUMN_NUMBER.TRACK_VALUE_3].Text = formMSCardEditor.Card.Track3;

            // PROCESS 4: Save the changes made to the card into the config file
            if (_isConnectedToServer)
            {
                MSRCards cards = _clientConfigFile.PlayerConfiguration.WalmartCards;
                cards.RemoveCard(formMSCardEditor.Card.Name);
                cards.AddCard(formMSCardEditor.Card);
                XmlClientConfigurationRepository repository = new XmlClientConfigurationRepository();
                repository.Save(_clientConfigFile);
            }
            else
            {
                MSRCards cards = _laneConfigFile.PlayerConfiguration.WalmartCards;
                cards.RemoveCard(formMSCardEditor.Card.Name);
                cards.AddCard(formMSCardEditor.Card);
                XmlLaneConfigurationRepository repository = new XmlLaneConfigurationRepository();
                repository.Save(_laneConfigFile);
            }

            LoggingService.Info("MSCardSelectionForm-->ButtonEditMSCardClick(): Successfully saved the changes to the MS Card " + formMSCardEditor.Card.Name);
        }
    }
}
