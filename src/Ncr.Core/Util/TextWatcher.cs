// <copyright file="TextWatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Text;

    /// <summary>
    /// Initializes a new instance of the TextWatcher class
    /// </summary>
    public class TextWatcher : ITextWatcher
    {
        /// <summary>
        /// Text changes
        /// </summary>
        private StringBuilder _changes = new StringBuilder();

        /// <summary>
        /// Initializes a new instance of the TextWatcher class
        /// </summary>
        /// <param name="text">text to watch</param>
        public TextWatcher(string text)
        {
            AppendLog(text);
        }

        /// <summary>
        /// Event handler for file changed
        /// </summary>
        public event EventHandler<LogHookEventArgs> Changed;

        /// <summary>
        /// Dispose of changes
        /// </summary>
        public virtual void Dispose()
        {
            ClearChanges();
        }

        /// <summary>
        /// Clear changes
        /// </summary>
        public void ClearChanges()
        {
            if (_changes.Length > 0)
            {
                _changes.Remove(0, _changes.Length);
            }

            OnChanged(new LogHookEventArgs(_changes.ToString()));
        }

        /// <summary>
        /// Append the log
        /// </summary>
        /// <param name="text">Text to append</param>
        public void AppendLog(string text)
        {
            _changes.Append(text);
            PerformChanged();
        }

        /// <summary>
        /// Perform the change
        /// </summary>
        public void PerformChanged()
        {
            OnChanged(new LogHookEventArgs(_changes.ToString()));
        }

        /// <summary>
        /// Event for on changed
        /// </summary>
        /// <param name="e">log hook event arguments</param>
        protected virtual void OnChanged(LogHookEventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }
    }
}
