// <copyright file="ScriptCardEventListView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System.Windows.Forms;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptCardEventListView class
    /// </summary>
    public class ScriptCardEventListView : ListView
    {
        /// <summary>
        /// Script events
        /// </summary>
        private IScriptEvent[] _events;
        
        /// <summary>
        /// Initializes a new instance of the ScriptCardEventListView class
        /// </summary>
        public ScriptCardEventListView()
        {
        }

        /// <summary>
        /// Gets or sets the script events
        /// </summary>
        public IScriptEvent[] ScriptEvents
        {
            get
            {
                if (_events == null)
                {
                    return new IScriptEvent[0];
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
                        Items.Add(new ScriptCardEventListViewItem(e));
                    }
                }
            }
        }
    }
}
