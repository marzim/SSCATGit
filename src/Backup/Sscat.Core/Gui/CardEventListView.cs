// <copyright file="CardEventListView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the CardEventListView class
    /// </summary>
    public class CardEventListView : ListView
    {
        /// <summary>
        /// Script events
        /// </summary>
        private List<IScriptEvent> _events;

        /// <summary>
        /// Initializes a new instance of the CardEventListView class
        /// </summary>
        public CardEventListView()
        {
            _events = new List<IScriptEvent>();
            SelectedIndexChanged += new EventHandler(ViewSelectedIndexChanged);
        }

        /// <summary>
        /// Finalizes an instance of the CardEventListView class
        /// </summary>
        ~CardEventListView()
        {
            SelectedIndexChanged -= new EventHandler(ViewSelectedIndexChanged);
        }

        /// <summary>
        /// Event handler for the selected script card event changed
        /// </summary>
        public event EventHandler<ScriptEventEventArgs> SelectedScriptCardEventChanged;

        /// <summary>
        /// Gets or sets the script events
        /// </summary>
        public List<IScriptEvent> ScriptEvents
        {
            get
            {
                if (_events == null)
                {
                    return new List<IScriptEvent>(0);
                }

                return _events;
            }

            set
            {
                if (value != null)
                {
                    _events = value;
                    Items.Clear();
                    foreach (IScriptEvent e in _events)
                    {
                        Items.Add(new CardEventListViewItem(e));
                    }
                }
            }
        }

        /// <summary>
        /// Gets the selected card event
        /// </summary>
        public IScriptEvent SelectedCardEvent
        {
            get
            {
                if (SelectedItems.Count > 0)
                {
                    return _events[SelectedItems[0].Index];
                }

                return null;
            }
        }

        /// <summary>
        /// Event for on selected script changed
        /// </summary>
        /// <param name="e">script event arguments</param>
        protected virtual void OnSelectedScriptChanged(ScriptEventEventArgs e)
        {
            if (SelectedScriptCardEventChanged != null)
            {
                SelectedScriptCardEventChanged(this, e);
            }
        }

        /// <summary>
        /// Event for view selected index changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedCardEvent != null)
            {
                OnSelectedScriptChanged(new ScriptEventEventArgs(SelectedCardEvent));
            }
        }
    }
}
