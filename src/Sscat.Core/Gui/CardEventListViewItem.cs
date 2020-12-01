// <copyright file="CardEventListViewItem.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using System.Windows.Forms;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the CardEventListViewItem class
    /// </summary>
    [Serializable]
    public class CardEventListViewItem : ListViewItem
    {
        /// <summary>
        /// Script event
        /// </summary>
        private IScriptEvent _scriptEvent;

        /// <summary>
        /// Initializes a new instance of the CardEventListViewItem class
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        public CardEventListViewItem(IScriptEvent scriptEvent)
        {
            Event = scriptEvent;
        }

        /// <summary>
        /// Finalizes an instance of the CardEventListViewItem class
        /// </summary>
        ~CardEventListViewItem()
        {
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
                if (_scriptEvent.Item != null)
                {
                    IScriptEventItem item = _scriptEvent.Item as IScriptEventItem;
                    Text = item.SeqId.ToString();
                    SubItems.Add((item as IDeviceEvent).Value);
                    SubItems.Add((_scriptEvent as IScriptEvent).NewItemValue);
                }
            }
        }
    }
}
