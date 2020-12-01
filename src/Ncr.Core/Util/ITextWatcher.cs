// <copyright file="ITextWatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ITextWatcher class
    /// </summary>
    public interface ITextWatcher : IDisposable
    {
        /// <summary>
        /// Event handler for file changed
        /// </summary>
        event EventHandler<LogHookEventArgs> Changed;

        /// <summary>
        /// Perform the change
        /// </summary>
        void PerformChanged();

        /// <summary>
        /// Append the log
        /// </summary>
        /// <param name="text">Text to append</param>
        void AppendLog(string text);

        /// <summary>
        /// Clear changes
        /// </summary>
        void ClearChanges();
    }
}
