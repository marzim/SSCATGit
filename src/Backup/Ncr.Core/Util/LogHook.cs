// <copyright file="LogHook.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Text;

    /// <summary>
    /// Initializes a new instance of the LogHook class
    /// </summary>
    public class LogHook : ILogHook
    {
        /// <summary>
        /// Text watcher interface
        /// </summary>
        private ITextWatcher _watcher;

        /// <summary>
        /// Initializes a new instance of the LogHook class
        /// </summary>
        /// <param name="filename">file name</param>
        public LogHook(string filename)
            : this(filename, Encoding.UTF8, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the LogHook class
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="encoding">file encoding</param>
        /// <param name="keepBuffer">whether or not to keep the buffer</param>
        public LogHook(string filename, Encoding encoding, bool keepBuffer)
            : this(new FileWatcher(filename, encoding, filename + ".bak", keepBuffer))
        {
        }

        /// <summary>
        /// Initializes a new instance of the LogHook class
        /// </summary>
        /// <param name="watcher">text watcher</param>
        public LogHook(ITextWatcher watcher)
        {
            _watcher = watcher;
            watcher.Changed += new EventHandler<LogHookEventArgs>(WatcherChanged);
        }

        /// <summary>
        /// Finalizes an instance of the LogHook class
        /// </summary>
        ~LogHook()
        {
            _watcher.Changed -= new EventHandler<LogHookEventArgs>(WatcherChanged);
        }

        /// <summary>
        /// Event handler for file changed
        /// </summary>
        public event EventHandler<LogHookEventArgs> Changed;

        /// <summary>
        /// Clear changes
        /// </summary>
        public void ClearChanges()
        {
            _watcher.ClearChanges();
        }

        /// <summary>
        /// Append log
        /// </summary>
        /// <param name="text">text to append</param>
        public void AppendLog(string text)
        {
            _watcher.AppendLog(text);
        }

        /// <summary>
        /// Perform changed
        /// </summary>
        public void PerformChanged()
        {
            _watcher.PerformChanged();
        }

        /// <summary>
        /// Dispose the text watcher
        /// </summary>
        public virtual void Dispose()
        {
            _watcher.Dispose();
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

        /// <summary>
        /// Event for watcher changed
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">log hook event arguments</param>
        private void WatcherChanged(object sender, LogHookEventArgs e)
        {
            OnChanged(e);
        }
    }
}
