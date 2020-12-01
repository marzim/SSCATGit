// <copyright file="WarningEventListView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the WarningEventListView class
    /// </summary>
    public class WarningEventListView : ListView
    {
        /// <summary>
        /// Interface for script events
        /// </summary>
        private IWarningEvent[] _warningEvents;

        /// <summary>
        /// Initializes a new instance of the WarningEventListView class
        /// </summary>
        public WarningEventListView()
        {
        }

        /// <summary>
        /// Gets or sets the warning events
        /// </summary>
        public IWarningEvent[] WarningEvents
        {
            get
            {
                if (_warningEvents == null)
                {
                    return new IWarningEvent[0];
                }

                return _warningEvents;
            }

            set
            {
                if (value != null)
                {
                    _warningEvents = value;
                    Items.Clear();
                    int i = 0;
                    foreach (IWarningEvent e in _warningEvents)
                    {
                        Items.Add(new WarningEventListViewItem(++i, e));
                    }
                }
            }
        }
    }
}
