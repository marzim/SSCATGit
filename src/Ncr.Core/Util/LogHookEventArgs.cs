// <copyright file="LogHookEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the LogHookEventArgs class
    /// </summary>
    public class LogHookEventArgs : EventArgs
    {
        /// <summary>
        /// File changes
        /// </summary>
        private string _changes;

        /// <summary>
        /// Initializes a new instance of the LogHookEventArgs class
        /// </summary>
        /// <param name="changes">file changes</param>
        public LogHookEventArgs(string changes)
        {
            Changes = changes;
        }

        /// <summary>
        /// Gets or sets the changes
        /// </summary>
        public string Changes
        {
            get { return _changes; }
            set { _changes = value; }
        }
    }
}
