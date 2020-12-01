// <copyright file="UIValidationEventListViewItem.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using System.Windows.Forms;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the UIValidationEventListViewItem class
    /// </summary>
    public class UIValidationEventListViewItem : ListViewItem
    {
        /// <summary>
        /// Interface for the _uiValEvent
        /// </summary>
        private UIValidationEvent _uiValEvent;
        
        /// <summary>
        /// Initializes a new instance of the UIValidationEventListViewItem class
        /// </summary>
        /// <param name="sequenceId">sequence id</param>
        /// <param name="uiValidationEvent">ui validation event</param>
        public UIValidationEventListViewItem(int sequenceId, UIValidationEvent uiValidationEvent)
        {
            Text = sequenceId.ToString();
            Event = uiValidationEvent;
        }

        /// <summary>
        /// Gets or sets the event
        /// </summary>
        public virtual UIValidationEvent Event
        {
            get
            {
                return _uiValEvent;
            }

            set
            {
                _uiValEvent = value;
                SubItems.Add("Skipped");
                SubItems.Add(string.Format("Type={0}, Control={1}, Property={2}, Value={3}", _uiValEvent.EventType, _uiValEvent.ControlName, _uiValEvent.Property, _uiValEvent.PropertyValue));
            }
        }
    }
}