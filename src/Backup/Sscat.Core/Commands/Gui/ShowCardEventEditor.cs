// <copyright file="ShowCardEventEditor.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Gui
{
    using System.Windows.Forms;
    using Ncr.Core.Commands;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Gui;
    using Sscat.Core.Services;

    /// <summary>
    /// Initializes a new instance of the ShowCardEventEditor class
    /// </summary>
    public class ShowCardEventEditor : AbstractCommand
    {
        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Lane service
        /// </summary>
        private LaneService _service;
        
        /// <summary>
        /// Dialog for opening files
        /// </summary>
        private OpenFileDialog _openFileDialogLoadScripts;
       
        /// <summary>
        /// Card event editor form
        /// </summary>
        private CardEventEditor _cardEventEditorForm;

        /// <summary>
        /// Initializes a new instance of the ShowCardEventEditor class
        /// </summary>
        public ShowCardEventEditor()
            : this(SscatContext.Lane, SscatContext.LaneService)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ShowCardEventEditor class
        /// </summary>
        /// <param name="lane">sscat lane</param>
        /// <param name="service">lane service</param>
        public ShowCardEventEditor(SscatLane lane, LaneService service)
        {
            _lane = lane;
            _service = service;
            _openFileDialogLoadScripts = new OpenFileDialog();
            _cardEventEditorForm = new CardEventEditor("Please follow Step 1 and Step 2 to modify card events. Scripts will be overwritten after clicking <Done> button..", true);
        }

        /// <summary>
        /// Runs the show card event editor form
        /// </summary>
        public override void Run()
        {
            // PRECONDITION 1: The user should have chosen a script to open
            _openFileDialogLoadScripts.Filter = "Script Files (*.xml)|*.xml";
            _openFileDialogLoadScripts.FilterIndex = 1;
            _openFileDialogLoadScripts.Multiselect = true;
            _openFileDialogLoadScripts.InitialDirectory = @"C:\SSCAT\Scripts";
            if (!IsShowOpenFileDialog())
            {
                return;
            }

            // PRECONDITION 2: At least one MS Card should have been used in any of the scripts selected
            if (CardEventEditor.ContainsMSCard(_openFileDialogLoadScripts.FileNames) == false)
            {
                MessageService.ShowInfo("MS Card Editor Window will not show since no MS Cards were used in the script(s).", "MS Card Editor");
                return;
            }

            // PROCESS 2: Launch MS Card Editor Window
            CardEventEditor cardEventEditorForm = new CardEventEditor("Please follow Step 1 and Step 2 to modify card events. Scripts will be overwritten after clicking <Done> button..", true);
            cardEventEditorForm.AddScriptsToScriptListView(_openFileDialogLoadScripts.FileNames);
            _lane.Configuration.FileName = ApplicationUtility.LaneConfigurationFileName;
            cardEventEditorForm.AddConfig(_lane.Configuration);
            cardEventEditorForm.Show();

            // PROCESS 3: Save the changes made into the scripts
            _service.SaveScripts(cardEventEditorForm.ScriptsLoaded.ToArray());
        }

        /// <summary>
        /// Checks if the dialog is shown
        /// </summary>
        /// <returns>Returns true if dialog is shown, false otherwise</returns>
        public virtual bool IsShowOpenFileDialog()
        {
            if (_openFileDialogLoadScripts.ShowDialog() == DialogResult.OK)
            {
                return true;
            }

            return false;
        }
    }
}
