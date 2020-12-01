// <copyright file="ProgressEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ProgressEventArgs class
    /// </summary>
    public class ProgressEventArgs : EventArgs
    {
        /// <summary>
        /// Progress message
        /// </summary>
        private string _message;

        /// <summary>
        /// Progress minimum
        /// </summary>
        private long _minimum;

        /// <summary>
        /// Progress maximum
        /// </summary>
        private long _maximum;

        /// <summary>
        /// Progress amount
        /// </summary>
        private long _progress;

        /// <summary>
        /// Initializes a new instance of the ProgressEventArgs class
        /// </summary>
        /// <param name="message">progress message</param>
        public ProgressEventArgs(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the ProgressEventArgs class
        /// </summary>
        /// <param name="message">progress message</param>
        /// <param name="progress">progress amount</param>
        public ProgressEventArgs(string message, long progress)
        {
            Message = message;
            Progress = progress;
        }

        /// <summary>
        /// Initializes a new instance of the ProgressEventArgs class
        /// </summary>
        /// <param name="message">progress message</param>
        /// <param name="minimum">progress minimum</param>
        /// <param name="maximum">progress maximum</param>
        public ProgressEventArgs(string message, long minimum, long maximum)
        {
            Message = message;
            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>
        /// Gets or sets the progress message
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        /// <summary>
        /// Gets or sets the progress minimum
        /// </summary>
        public long Minimum
        {
            get { return _minimum; }
            set { _minimum = value; }
        }

        /// <summary>
        /// Gets or sets the progress maximum
        /// </summary>
        public long Maximum
        {
            get { return _maximum; }
            set { _maximum = value; }
        }

        /// <summary>
        /// Sets the progress
        /// </summary>
        public long Progress
        {
            set { _progress = value; }
        }
    }
}
