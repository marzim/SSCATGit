// <copyright file="ConsoleWldbManagerView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Views
{
    using System;
    using Ncr.Core.Views;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ConsoleWldbManagerView class
    /// </summary>
    public class ConsoleWldbManagerView : BaseConsoleView, IWldbManagerView
    {
        /// <summary>
        /// Interface for the weight learning database event class
        /// </summary>
        private IWldbEvent _wldb;

        /// <summary>
        /// Indicates whether or not it is for update
        /// </summary>
        private bool _forUpdate;

        /// <summary>
        /// Initializes a new instance of the ConsoleWldbManagerView class
        /// </summary>
        public ConsoleWldbManagerView()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ConsoleWldbManagerView class
        /// </summary>
        /// <param name="wldbEvent">interface for weight learning database event</param>
        public ConsoleWldbManagerView(IWldbEvent wldbEvent)
        {
            Wldb = wldbEvent;
        }

        /// <summary>
        /// Event handler for managing the wldb
        /// </summary>
        public event EventHandler<WldbEventArgs> Managing;

        /// <summary>
        /// Gets or sets a value indicating whether it is for updating the wldb
        /// </summary>
        public bool ForUpdate
        {
            get { return _forUpdate; }
            set { _forUpdate = value; }
        }

        /// <summary>
        /// Gets or sets the weight learning database event
        /// </summary>
        public IWldbEvent Wldb
        {
            get { return _wldb; }
            set { _wldb = value; }
        }

        /// <summary>
        /// Manages the weight learning database
        /// </summary>
        public void Manage()
        {
            OnManaging(new WldbEventArgs(Wldb, ForUpdate));
        }

        /// <summary>
        /// Event for managing the weight learning database event
        /// </summary>
        /// <param name="e">weight learning database event arguments</param>
        protected virtual void OnManaging(WldbEventArgs e)
        {
            if (Managing != null)
            {
                Managing(this, e);
            }
        }
    }
}
