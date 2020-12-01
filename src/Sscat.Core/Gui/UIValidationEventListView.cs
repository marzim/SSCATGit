// <copyright file="UIValidationEventListView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using System.Windows.Forms;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UIValidationEventListView class
    /// </summary>
    public class UIValidationEventListView : ListView
    {
        /// <summary>
        /// Interface for script events
        /// </summary>
        private IScriptEvent[] _scriptEvents;

        /// <summary>
        /// Initializes a new instance of the UIValidationEventListView class
        /// </summary>
        public UIValidationEventListView()
        {
        }

        /// <summary>
        /// Gets or sets the script events
        /// </summary>
        public IScriptEvent[] ScriptEvents
        {
            get
            {
                if (_scriptEvents == null)
                {
                    return new IScriptEvent[0];
                }

                return _scriptEvents;
            }

            set
            {
                if (value != null)
                {
                    _scriptEvents = value;
                    Items.Clear();
                    foreach (IScriptEvent e in _scriptEvents)
                    {
                        UIValidationEvents uiValEvents = e.Item as UIValidationEvents;

                        foreach (UIValidationEvent uiValEvent in uiValEvents.UIValidationEvnts)
                        {
                            Items.Add(new UIValidationEventListViewItem(e.SequenceID, uiValEvent));
                        }
                    }
                }
            }
        }
    }
}
