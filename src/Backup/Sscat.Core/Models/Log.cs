// <copyright file="Log.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Text;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the Log class
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Changes locker
        /// </summary>
        private readonly object _changesLocker = new object();

        /// <summary>
        /// The logs
        /// </summary>
        private StringBuilder _logs = new StringBuilder();

        /// <summary>
        /// Max lines
        /// </summary>
        private int _maxLines;

        /// <summary>
        /// Initializes a new instance of the Log class
        /// </summary>
        public Log()
            : this(1500)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Log class
        /// </summary>
        /// <param name="maxLines">max lines</param>
        public Log(int maxLines)
        {
            _maxLines = maxLines;
        }

        /// <summary>
        /// Event handler for changed
        /// </summary>
        public event EventHandler Changed;

        /// <summary>
        /// Gets the lines
        /// </summary>
        private string[] Lines
        {
            get { return _logs.ToString().Split('\n'); }
        }

        /// <summary>
        /// Clear the logs
        /// </summary>
        public void Clear()
        {
            _logs = new StringBuilder();
            OnChanged(null);
        }

        /// <summary>
        /// Append the log
        /// </summary>
        /// <param name="log">log to append</param>
        public void AppendLog(string log)
        {
            try
            {
                if (Lines.Length > _maxLines)
                {
                    _logs = new StringBuilder();
                }

                lock (_changesLocker)
                {
                    _logs.Append(log + Environment.NewLine);
                }

                OnChanged(null);
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                LoggingService.Error(log);
            }
        }

        /// <summary>
        /// Formats the log string
        /// </summary>
        /// <returns>Returns the formatted log string</returns>
        public override string ToString()
        {
            return _logs.ToString();
        }

        /// <summary>
        /// Event for on changed
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }
    }
}
