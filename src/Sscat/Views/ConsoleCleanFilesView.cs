// <copyright file="ConsoleCleanFilesView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Views
{
    using System;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ConsoleCleanFilesView class
    /// </summary>
    public class ConsoleCleanFilesView : ICleanFilesView
    {
        /// <summary>
        /// Initializes a new instance of the ConsoleCleanFilesView class
        /// </summary>
        public ConsoleCleanFilesView()
        {
        }

        /// <summary>
        /// Gets the handle
        /// </summary>
        public IntPtr Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
