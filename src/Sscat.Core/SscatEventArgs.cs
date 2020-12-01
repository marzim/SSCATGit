// <copyright file="SscatEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core
{
    using Ncr.Core;

    /// <summary>
    /// Initializes a new instance of the SscatEventArgs class
    /// </summary>
    public class SscatEventArgs : NcrEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the SscatEventArgs class
        /// </summary>
        /// <param name="message">message to display</param>
        public SscatEventArgs(string message)
            : base(message)
        {
        }
    }
}
