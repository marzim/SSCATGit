// <copyright file="WarningEventListViewItem.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using System.Windows.Forms;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the WarningEventListViewItem class
    /// </summary>
    public class WarningEventListViewItem : ListViewItem
    {
        /// <summary>
        /// Interface for the WarningEvent event
        /// </summary>
        private IWarningEvent _warningEvent;
        
        /// <summary>
        /// Initializes a new instance of the WarningEventListViewItem class
        /// </summary>
        /// <param name="sequenceId">sequence id</param>
        /// <param name="warningEvent">warning event</param>
        public WarningEventListViewItem(int sequenceId, IWarningEvent warningEvent)
        {
            Text = sequenceId.ToString();
            Event = warningEvent;
        }

        /// <summary>
        /// Gets or sets the WarningEvent event
        /// </summary>
        public virtual IWarningEvent Event
        {
            get
            {
                return _warningEvent;
            }

            set
            {
                _warningEvent = value;
                SubItems.Add(_warningEvent.EventType);
                SubItems.Add(_warningEvent.WarningNotes);
            }
        }
    }
}