// <copyright file="CardEventEditor.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using Ncr.Core;
    using Ncr.Core.Util;
    using Sscat.Core.Config;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Repositories.Xml;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the CardEventEditor class
    /// </summary>
    public partial class CardEventEditor : Form
    {
        /// <summary>
        /// Update lock
        /// </summary>
        private readonly object _updateLock = new object();

        /// <summary>
        /// Scripts loaded
        /// </summary>
        private List<IScript> _scriptsLoaded = new List<IScript>();

        /// <summary>
        /// Card script events
        /// </summary>
        private List<IScriptEvent> _cardScriptEvents;

        /// <summary>
        /// Player configuration
        /// </summary>
        private PlayerConfiguration _playConfig;

        /// <summary>
        /// Client configuration
        /// </summary>
        private ClientConfiguration _clientConfig;

        /// <summary>
        /// Lane configuration
        /// </summary>
        private LaneConfiguration _laneConfig;

        /// <summary>
        /// Script result list view index
        /// </summary>
        private int _scriptResultListViewIndex;

        /// <summary>
        /// Script event list view index
        /// </summary>
        private int _scriptEventListViewIndex;

        /// <summary>
        /// Card event list view index
        /// </summary>
        private int _cardEventListViewIndex;

        /// <summary>
        /// Whether or not an MS card was changed
        /// </summary>
        private bool _wasAnMSCardChanged;

        /// <summary>
        /// Whether or not a client is connected
        /// </summary>
        private bool _isClientConnected;

        /// <summary>
        /// Whether or not is is invoked from the tools menu
        /// </summary>
        private bool _isInvokedFromToolsMenu;

        /// <summary>
        /// Perform run thread
        /// </summary>
        private Thread _performRunThread;

        /// <summary>
        /// Initializes a new instance of the CardEventEditor class
        /// </summary>
        /// <param name="labelInformation">label information</param>
        public CardEventEditor(string labelInformation)
            : this()
        {
            _labelInformation.Text = labelInformation;
        }

        /// <summary>
        /// Initializes a new instance of the CardEventEditor class
        /// </summary>
        /// <param name="labelInformation">label information</param>
        /// <param name="isInvokedFromToolsMenu">whether or not it is invoked from the tools menu</param>
        public CardEventEditor(string labelInformation, bool isInvokedFromToolsMenu)
            : this()
        {
            _labelInformation.Text = labelInformation;
            _isInvokedFromToolsMenu = isInvokedFromToolsMenu;
        }

        /// <summary>
        /// Initializes a new instance of the CardEventEditor class
        /// </summary>
        public CardEventEditor()
        {
            InitializeComponent();

            _scriptResultListViewIndex = 0;
            _scriptEventListViewIndex = 0;
            _cardEventListViewIndex = 0;
            _wasAnMSCardChanged = false;
            _isClientConnected = false;
            _laneConfig = new LaneConfiguration();
            _clientConfig = new ClientConfiguration();
            _buttonUndoAllChanges.Enabled = false;
            _cardScriptEvents = new List<IScriptEvent>();
            _isInvokedFromToolsMenu = false;

            _buttonUndoChange.Enabled = false;
            _buttonUndoAllChanges.Enabled = false;
            try
            {
                _performRunThread = new Thread(new ThreadStart(PerformOnRunningMessenger));
                _performRunThread.Start();
                scriptResultListView.SelectedScriptChanged += new EventHandler<ScriptEventArgs>(ScriptResultListViewSelectedScriptChanged);
                cardEventListView.SelectedScriptCardEventChanged += new EventHandler<ScriptEventEventArgs>(CardEventListViewSelectedEventChanged);
                cardConfigListView.Click += new EventHandler(CardConfigListViewClicked);
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                Close();
            }
        }

        /// <summary>
        /// Finalizes an instance of the CardEventEditor class
        /// </summary>
        ~CardEventEditor()
        {
            scriptResultListView.SelectedScriptChanged -= new EventHandler<ScriptEventArgs>(ScriptResultListViewSelectedScriptChanged);
            cardEventListView.SelectedScriptCardEventChanged -= new EventHandler<ScriptEventEventArgs>(CardEventListViewSelectedEventChanged);
            cardConfigListView.Click -= new EventHandler(CardConfigListViewClicked);
        }

        /// <summary>
        /// Event handler for running
        /// </summary>
        public event EventHandler<NcrEventArgs> Running;

        /// <summary>
        /// Event handler for configuration changed
        /// </summary>
        public event EventHandler ConfigurationChanged;

        /// <summary>
        /// Gets or sets the loaded scripts
        /// </summary>
        public List<IScript> ScriptsLoaded
        {
            get { return _scriptsLoaded; }
            set { _scriptsLoaded = value; }
        }

        /// <summary>
        /// Gets the selected MSR card
        /// </summary>
        private MSRCard SelectedMSRCard
        {
            get
            {
                if (cardConfigListView.SelectedItems.Count > 0)
                {
                    return _playConfig.WalmartCards.Cards[cardConfigListView.SelectedItems[0].Index];
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the selected MSR cards
        /// </summary>
        private List<MSRCard> SelectedMSRCards
        {
            get
            {
                List<MSRCard> cards = new List<MSRCard>();
                foreach (ListViewItem li in cardConfigListView.SelectedItems)
                {
                    cards.Add(_playConfig.WalmartCards.Cards[li.Index]);
                }

                return cards;
            }
        }

        /// <summary>
        /// Checks if script contains an MS card
        /// </summary>
        /// <param name="script">script to check</param>
        /// <returns>Returns true if found, false otherwise</returns>
        public static bool ContainsMSCard(IScript script)
        {
            // PRECONDITION 1: The script shouldn't be null
            if (script == null)
            {
                return false;
            }

            // PRECONDITION 2: The script should contain at least one device event
            if (script.HasDeviceEvents == false)
            {
                return false;
            }

            // PROCESS 1: Traverse through the events under the script to see if an MS Card was used
            bool hasMSCard = false;
            foreach (ScriptEvent scriptEvent in script.Events.Events)
            {
                if (scriptEvent.Item is IDeviceEvent)
                {
                    IDeviceEvent deviceEvent = scriptEvent.Item as IDeviceEvent;
                    if (deviceEvent.Id.Equals(Constants.DeviceType.MSR))
                    {
                        hasMSCard = true;
                        break;
                    }
                }
            }

            return hasMSCard;
        }

        /// <summary>
        /// Checks if scripts contains an MS card
        /// </summary>
        /// <param name="scripts">scripts to check</param>
        /// <returns>Returns true if found, false otherwise</returns>
        public static bool ContainsMSCard(IScript[] scripts)
        {
            // PRECONDITION 1: At least one script should be there to check
            if (scripts == null || scripts.Length == 0)
            {
                LoggingService.Error("CardEventEditor->ContainsMSCard(): Scripts passed are invalid! " +
                                     "Can't identify if an MS Card was used in them.");
                return false;
            }

            // PROCESS 1: Traverse through the scripts and see if an MS Card was used
            bool hasMSCard = false;
            int scriptIndex = 0;
            while (scriptIndex < scripts.Length && hasMSCard == false)
            {
                IScript script = scripts[scriptIndex];
                hasMSCard = ContainsMSCard(script);
                scriptIndex++;
            }

            // PROCESS 2: Log the result
            if (hasMSCard)
            {
                LoggingService.Info("CardEventEditor->ContainsMSCard(): The script(s) contain(s) MS Card(s)!");
            }
            else
            {
                LoggingService.Info("CardEventEditor->ContainsMSCard(): No MS Card(s) was/were found on the script(s)! " +
                                    "The MS Card Editor will not be shown.");
            }

            return hasMSCard;
        }

        /// <summary>
        /// Checks if script contains an MS card
        /// </summary>
        /// <param name="scriptFileNames">scripts file names</param>
        /// <returns>Returns true if found, false otherwise</returns>
        public static bool ContainsMSCard(string[] scriptFileNames)
        {
            // PRECONDITION 1: There should be at least one script file to open
            if (scriptFileNames.Length == 0)
            {
                return false;
            }

            // PROCESS 1: Read the script files
            SSCATScript cacheScript;
            List<IScript> scripts = new List<IScript>();
            foreach (string scriptFilename in scriptFileNames)
            {
                cacheScript = SSCATScript.Deserialize(scriptFilename);
                scripts.Add(cacheScript);
            }

            // PROCESS 2: Traverse through the scripts to see if an MS Card was used
            bool hasMSCard = false;
            hasMSCard = ContainsMSCard(scripts.ToArray());

            return hasMSCard;
        }

        /// <summary>
        /// Checks if script contains an MS card
        /// </summary>
        /// <param name="scriptFileName">script file names</param>
        /// <returns>Returns true if found, false otherwise</returns>
        public static bool ContainsMSCard(string scriptFileName)
        {
            // PRECONDITION 1: Filename should not be an empty string
            if (scriptFileName.Equals(string.Empty))
            {
                return false;
            }

            // PROCESS 1: Read the script file
            SSCATScript script;
            script = SSCATScript.Deserialize(scriptFileName);

            // PROCESS 2: See if an MS Card was used
            bool hasMSCard = false;
            hasMSCard = ContainsMSCard(script);

            return hasMSCard;
        }

        /// <summary>
        /// Add scripts to script list view
        /// </summary>
        /// <param name="filenames">file names</param>
        public void AddScriptsToScriptListView(string[] filenames)
        {
            try
            {
                // PRECONDITION 1: There should be at least one script file to open
                if (filenames.Length == 0)
                {
                    LoggingService.Error("CardEventEditor-->AddScriptsToScriptListView(): No files to open, script list view can not be populated.");
                    return;
                }

                // PROCESS 1: Make sure the files are properly sorted
                List<string> listScriptFilenames = new List<string>(filenames);
                listScriptFilenames.Sort(new FileNameComparer());

                // PROCESS 2: Read the script files
                SSCATScript cacheScript;
                foreach (string scriptFilename in listScriptFilenames)
                {
                    cacheScript = SSCATScript.Deserialize(scriptFilename);
                    ScriptsLoaded.Add(cacheScript);
                }

                // PROCESS 3: Display the files red to the script list view component
                scriptResultListView.AddScript(ScriptsLoaded);

                // PROCESS 4: Update the list view that outlines the MS Cards used in all scripts red
                // UNDONE: Why is this here?
                DisplayMSCardsAtCardEventListView();
            }
            catch (Exception ex)
            {
                LoggingService.Info("CardEventEditor-->AddScriptsToScriptListView(): " + ex.Message + "\n" + ex.StackTrace);
                throw ex;
            }
        }

        /// <summary>
        /// Add scripts to the script list view
        /// </summary>
        /// <param name="scripts">scripts to add</param>
        public void AddScriptsToScriptListView(List<IScript> scripts)
        {
            try
            {
                ScriptsLoaded = scripts;
                scriptResultListView.AddScript(ScriptsLoaded);
                DisplayMSCardsAtCardEventListView();
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Add configuration
        /// </summary>
        /// <param name="clientConfiguration">client configuration</param>
        public void AddConfig(ClientConfiguration clientConfiguration)
        {
            try
            {
                _clientConfig = clientConfiguration;
                _playConfig = clientConfiguration.PlayerConfiguration;
                _isClientConnected = true;
                DisplayCardConfigList();
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Add configuration
        /// </summary>
        /// <param name="laneConfiguration">lane configuration</param>
        public void AddConfig(LaneConfiguration laneConfiguration)
        {
            try
            {
                _laneConfig = laneConfiguration;
                _playConfig = laneConfiguration.PlayerConfiguration;
                DisplayCardConfigList();
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// Event for on running
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnRunning(NcrEventArgs e)
        {
            if (Running != null)
            {
                Running(this, e);
            }
        }

        /// <summary>
        /// Event for on configuration changed
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConfigurationChanged(EventArgs e)
        {
            if (ConfigurationChanged != null)
            {
                ConfigurationChanged(this, e);
            }
        }

        /// <summary>
        /// Display MS cards at card event list view
        /// </summary>
        private void DisplayMSCardsAtCardEventListView()
        {
            // PRECONDITION 1: At least one MS Card should have been found in the scripts
            IScript[] arrayOfLoadedScripts = _scriptsLoaded.ToArray();
            if (ContainsMSCard(arrayOfLoadedScripts) == false)
            {
                MessageService.ShowInfo("MS Card Editor Window will not show since no MS Cards were used in the script(s).", "MS Card Editor");
                Close();
                return;
            }

            // PROCESS 1: Find all MS Cards used in the scripts
            for (int scriptIndex = 0; scriptIndex < arrayOfLoadedScripts.Length; scriptIndex++)
            {
                IScript script = arrayOfLoadedScripts[scriptIndex];
                IScriptEvent[] scriptEvents = null;

                scriptEvents = (script as SSCATScript).ScriptEvents as IScriptEvent[];

                foreach (IScriptEvent scriptEvent in scriptEvents)
                {
                    if (scriptEvent.Item is IDeviceEvent)
                    {
                        IDeviceEvent deviceEvent = scriptEvent.Item as IDeviceEvent;
                        if (deviceEvent.Id.Equals(Constants.DeviceType.MSR))
                        {
                            scriptEvent.ScriptFileName = _scriptsLoaded.ToString();
                            scriptEvent.NewItemValue = string.Empty;
                            scriptEvent.ScriptIndex = scriptIndex;
                            _cardScriptEvents.Add(scriptEvent);
                        }
                    }
                }
            }

            // PROCESS 2: Display MS Cards found at the scripts in the Card Event List View
            cardEventListView.ScriptEvents = _cardScriptEvents;

            // PROCESS 3: Set default selection to the first MS Card found
            cardEventListView.Items[0].Selected = true;
            LoggingService.Info("CardEventEditor-->DisplayMSCardsAtCardEventListView(): All MS Cards found are now displayed at Card Event Listview component.", "MS Card Editor");
        }

        /// <summary>
        /// Perform on running messenger
        /// </summary>
        private void PerformOnRunningMessenger()
        {
            while (!IsDisposed)
            {
                ThreadHelper.Sleep(1000);
                OnRunning(new NcrEventArgs("Card Event Editor is still running..."));
                ThreadHelper.Sleep(9000);
            }
        }

        /// <summary>
        /// Save the MSR configuration
        /// </summary>
        private void SaveMSRConfiguration()
        {
            try
            {
                if (_isClientConnected)
                {
                    _clientConfig.PlayerConfiguration = _playConfig;
                    new XmlClientConfigurationRepository().Save(_clientConfig);
                }
                else
                {
                    _laneConfig.PlayerConfiguration = _playConfig;
                    new XmlLaneConfigurationRepository().Save(_laneConfig);
                }

                OnConfigurationChanged(new EventArgs());
            }
            catch (Exception ex)
            {
                MessageService.ShowError(ex.ToString());
            }
        }

        /// <summary>
        /// Display the card configuration list
        /// </summary>
        private void DisplayCardConfigList()
        {
            cardConfigListView.Items.Clear();
            foreach (MSRCard c in _playConfig.WalmartCards.Cards)
            {
                ListViewItem li = cardConfigListView.Items.Add(c.Name);
                li.SubItems.Add(c.Track1);
                li.SubItems.Add(c.Track2);
                li.SubItems.Add(c.Track3);
            }
        }

        /// <summary>
        /// Event for the card event list view selected event changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void CardEventListViewSelectedEventChanged(object sender, ScriptEventEventArgs e)
        {
            lock (_updateLock)
            {
                _scriptResultListViewIndex = e.Event.ScriptIndex;
                _scriptEventListViewIndex = (e.Event.Item as IScriptEventItem).SeqId - 1;
                scriptResultListView.Items[_scriptResultListViewIndex].Selected = true;
                scriptResultListView.TopItem = scriptResultListView.Items[_scriptResultListViewIndex];
                _cardEventListViewIndex = cardEventListView.SelectedIndices[0];

                string newValue = _cardScriptEvents[_cardEventListViewIndex].NewItemValue.ToString();
                if (newValue != string.Empty)
                {
                    _buttonUndoChange.Enabled = true;
                }
                else
                {
                    _buttonUndoChange.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Event for script result list view selected script changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">script event arguments</param>
        private void ScriptResultListViewSelectedScriptChanged(object sender, ScriptEventArgs e)
        {
            // PRECONDITION 1: At least a filename for the selected script should have been provided
            if (e.ScriptFile == null)
            {
                LoggingService.Error("CardEventEditor-->ScriptResultListViewSelectedScriptChanged(): This function cannot operate as there was no script filename provided.", "MS Card Editor");
                return;
            }

            // PROCESS 1: From the script filename, find its script contents from the list of loaded scripts
            string strFileName = e.ScriptFile.File;
            IScript[] loadedScripts = ScriptsLoaded.ToArray();
            IScript scriptToDisplay = null;
            foreach (IScript script in loadedScripts)
            {
                if (script.FileName.Equals(strFileName))
                {
                    scriptToDisplay = script;
                    break;
                }
            }

            // POST CONDITION 1: The script should have been found
            if (scriptToDisplay == null)
            {
                LoggingService.Error("CardEventEditor-->ScriptResultListViewSelectedScriptChanged(): Ending operation as the script selected can't be found.", "MS Card Editor");
                return;
            }

            // PROCESS 2: Update Script's Event Details column with the script contents
            SSCATScript tempVar = scriptToDisplay as SSCATScript;
            scriptEventListView.ScriptEvents = tempVar.ScriptEvents as IScriptEvent[];

            // PROCESS 3: Set the Script's Event Details column so that the selected MS Card is on its top
            if (_scriptEventListViewIndex < scriptEventListView.Items.Count && _scriptEventListViewIndex > -1)
            { // UNDONE: Why would it reach to a point where index value is -1?
                scriptEventListView.Items[_scriptEventListViewIndex].Selected = true;
                scriptEventListView.TopItem = scriptEventListView.Items[_scriptEventListViewIndex];
            }
            else
            {
                scriptEventListView.TopItem = scriptEventListView.Items[0];
            }

            // PROCESS 4: Set a different background on all rows that has MS Card in it
            foreach (ListViewItem s in scriptEventListView.Items)
            {
                if (s.SubItems[1].Text.Contains("MSR"))
                {
                    scriptEventListView.Items[s.Index].BackColor = Color.PeachPuff;
                }
            }

            // PROCESS 5: Reset index flagging for the next selection
            _scriptResultListViewIndex = 0;
            _scriptEventListViewIndex = 0;
        }

        /// <summary>
        /// Event for card configuration list view clicked
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">Event arguments</param>
        private void CardConfigListViewClicked(object sender, EventArgs e)
        {
            try
            {
                cardEventListView.Items[_cardEventListViewIndex].Selected = true;
                if (cardConfigListView.SelectedItems.Count == 1)
                {
                    _cardScriptEvents[_cardEventListViewIndex].NewItemValue = cardConfigListView.SelectedItems[0].SubItems[0].Text;
                    _wasAnMSCardChanged = true;
                    LoggingService.Info(string.Format("CardEventEditor-->CardSelectedIndexChanged(): MS Card value {0} is changed to {1}.", (_cardScriptEvents[_cardEventListViewIndex].Item as IDeviceEvent).Value, cardConfigListView.SelectedItems[0].SubItems[0].Text));
                }

                cardEventListView.ScriptEvents = _cardScriptEvents;
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                MessageService.ShowError(ex.ToString());
            }

            if (_wasAnMSCardChanged)
            {
                _buttonUndoAllChanges.Enabled = true;
            }

            _buttonUndoChange.Enabled = false;
        }

        /// <summary>
        /// Event for add MSR card click button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonAddMSRCardClick(object sender, EventArgs e)
        {
            using (CardForm f = new CardForm(new MSRCard(), false, "Please enter the MS Card details."))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    f.Card.Validate();
                    if (f.Card.HasErrors == false && _playConfig.WalmartCards.Contains(f.Card.Name) == false)
                    {
                        _playConfig.WalmartCards.AddCard(f.Card);
                        SaveMSRConfiguration();
                        DisplayCardConfigList();
                    }
                    else
                    {
                        MessageService.ShowWarning(f.Card.Errors.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// Event for edit MSR card click button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonEditMSRCardClick(object sender, EventArgs e)
        {
            if (SelectedMSRCard != null)
            {
                MSRCard selectedMSRCard = new MSRCard();
                selectedMSRCard.Name = SelectedMSRCard.Name;
                selectedMSRCard.Track1 = SelectedMSRCard.Track1;
                selectedMSRCard.Track2 = SelectedMSRCard.Track2;
                selectedMSRCard.Track3 = SelectedMSRCard.Track3;

                using (CardForm f = new CardForm(SelectedMSRCard, true, "Note: Can only edit track values."))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        foreach (MSRCard c in SelectedMSRCards)
                        {
                            _playConfig.WalmartCards.RemoveCard(c);
                        }

                        f.Card.Validate();
                        if (!f.Card.HasErrors && _playConfig.WalmartCards.Contains(f.Card.Name) == false)
                        {
                            _playConfig.WalmartCards.AddCard(f.Card);
                        }
                        else
                        {
                            _playConfig.WalmartCards.AddCard(selectedMSRCard);
                            MessageService.ShowWarning(f.Card.Errors.ToString());
                        }

                        SaveMSRConfiguration();
                        DisplayCardConfigList();
                    }
                }
            }
        }

        /// <summary>
        /// Event for click button done
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonDoneClick(object sender, EventArgs e)
        {
            try
            {
                if (cardEventListView.ScriptEvents.Count == 0)
                {
                    // PRECONDITION 1: At least one MS Cards should be in the script(s)
                    LoggingService.Error("CardEventEditor-->ButtonDoneClick(): No update needed as there's no MS Cards found in the scripts.");
                }
                else if (_wasAnMSCardChanged == false)
                {
                    // PRECONDITION 2: At least one MS Card should have been customized
                    LoggingService.Error("CardEventEditor-->ButtonDoneClick(): No update needed as there was no customization made to the MS Card(s).");
                }
                else
                {
                    // PROCESS 1: For all customized MS Cards, update the script objects where they belong
                    IScriptEvent[] currentMSCardsEvents = cardEventListView.ScriptEvents.ToArray();
                    IScriptEvent[] eventsFromScriptsThatNeedUpdatedMSCards = null;
                    IScript[] scriptsThatNeedUpdatedMSCards = ScriptsLoaded.ToArray();
                    int scriptEventIndex = 0;

                    foreach (IScriptEvent msrEvent in currentMSCardsEvents)
                    {
                        if (scriptsThatNeedUpdatedMSCards[msrEvent.ScriptIndex] is SSCATScript)
                        {
                            eventsFromScriptsThatNeedUpdatedMSCards = (scriptsThatNeedUpdatedMSCards[msrEvent.ScriptIndex] as SSCATScript).ScriptEvents;
                        }
                        else
                        {
                            eventsFromScriptsThatNeedUpdatedMSCards = scriptsThatNeedUpdatedMSCards[msrEvent.ScriptIndex].Events.Events;
                        }

                        // script sequence starts at 1 but array index starts at 0
                        scriptEventIndex = (msrEvent.Item as IDeviceEvent).SeqId - 1;

                        if (msrEvent.NewItemValue.Equals(string.Empty) == false)
                        {
                            IDeviceEvent msrEventToBeUpdated = eventsFromScriptsThatNeedUpdatedMSCards[scriptEventIndex].Item as IDeviceEvent;
                            msrEventToBeUpdated.Value = msrEvent.NewItemValue;
                        }
                    }

                    LoggingService.Info("CardEventEditor-->ButtonDoneClick(): All customization made to the MS Card(s) are now saved into the script instance(s).");

                    // PROCESS 2: If this was invoked from Tools menu, save the changes immediately into the script files
                    if (_isInvokedFromToolsMenu)
                    {
                        XmlSSCATScriptRepository scriptFileUpdater = new XmlSSCATScriptRepository();
                        scriptFileUpdater.Save(scriptsThatNeedUpdatedMSCards);
                        LoggingService.Info("CardEventEditor-->ButtonDoneClick(): All customization made to the MS Card(s) are now saved into the script file(s).");
                    }
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(string.Format("CardEventEditor-->ButtonDoneClick(): Failed to save all customization made to the MS Card(s) due to a FATAL ERROR! ERROR MESSAGE: {0} ERROR STACK TRACE: {1}", ex.Message, ex.StackTrace));
                throw ex;
            }
            finally
            {
                // FINAL PROCESS: Close the form to direct focus on Script Generation Tab
                Close();
            }
        }

        /// <summary>
        /// Event for undo all changes button click
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonUndoAllChangesClick(object sender, EventArgs e)
        {
            // PRECONDITION 1: At least one MS Card should have been customized
            if (_wasAnMSCardChanged == false)
            {
                MessageService.ShowInfo("Cannot undo changes as there was no customization made to the MS Card(s).");
                LoggingService.Error("CardEventEditor-->ButtonUndoAllChangesClick(): No update needed as there was no customization made to the MS Card(s).");
                return;
            }

            // PRECONDITION 2: The user should really want to do this action
            bool confirmUndoAllChanges = MessageService.ShowYesNo("Are you sure you want to undo all changes?", "Confirm Undo All Changes");
            if (confirmUndoAllChanges == false)
            {
                return;
            }

            // PROCESS 1: Reset flag that tells if MS Cards were customized to false
            _wasAnMSCardChanged = false;

            // PROCESS 2: Tranverse through the MS Cards and change their new value back to empty string
            foreach (IScriptEvent msrEvent in _cardScriptEvents)
            {
                msrEvent.NewItemValue = string.Empty;
            }

            // PROCESS 3: Update UI with the changes made
            cardEventListView.ScriptEvents = _cardScriptEvents;
            cardEventListView.Items[0].Selected = true;
            _buttonUndoAllChanges.Enabled = false;

            LoggingService.Info("CardEventEditor-->ButtonUndoAllChangesClick(): All MS Card(s) are back to default value.");
        }

        /// <summary>
        /// Event for undo single change button click
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonUndoChangeClick(object sender, EventArgs e)
        {
            _cardScriptEvents[_cardEventListViewIndex].NewItemValue = string.Empty;
            cardEventListView.ScriptEvents = _cardScriptEvents;
            cardEventListView.Items[_cardEventListViewIndex].Selected = true;

            if (HasChangeCardToValue())
            {
                _wasAnMSCardChanged = true;
            }
            else
            {
                _wasAnMSCardChanged = false;
                _buttonUndoChange.Enabled = false;
                _buttonUndoAllChanges.Enabled = false;
            }
        }

        /// <summary>
        /// Checks if the card changed
        /// </summary>
        /// <returns>True if changed, false otherwise</returns>
        private bool HasChangeCardToValue()
        {
            foreach (ListViewItem item in cardEventListView.Items)
            {
                if (!item.SubItems[2].Text.Equals(string.Empty))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
