// <copyright file="ILogHook.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Util
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Initializes a new instance of the ILogHook interface
    /// </summary>
    public interface ILogHook : IDisposable
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
        /// <param name="text">text to append</param>
        void AppendLog(string text);
    }
}
