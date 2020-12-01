// <copyright file="ScriptCardEventListViewItem.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using System.Windows.Forms;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptCardEventListViewItem class
    /// </summary>
    [Serializable]
    public class ScriptCardEventListViewItem : ListViewItem
    {
        /// <summary>
        /// Interface for the script event
        /// </summary>
        private IScriptEvent _scriptEvent;

        /// <summary>
        /// Initializes a new instance of the ScriptCardEventListViewItem class
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        public ScriptCardEventListViewItem(IScriptEvent scriptEvent)
        {
            Event = scriptEvent;
        }

        /// <summary>
        /// Gets or sets the script event
        /// </summary>
        public IScriptEvent Event
        {
            get
            {
                return _scriptEvent;
            }

            set
            {
                _scriptEvent = value;
                IScriptEventItem item = _scriptEvent.Item as IScriptEventItem;
                Text = _scriptEvent.SequenceID.ToString();
                SubItems.Add(item.ToRepresentation());
            }
        }
    }
}
