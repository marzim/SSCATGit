// <copyright file="UpdateContextEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events.UIAutoTest
{
    using System;

    /// <summary>
    /// Initializes a new instance of the UpdateContextEventArgs class
    /// </summary>
    internal class UpdateContextEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the name of the context
        /// </summary>
        public string ContextName { get; set; }
    }
}
