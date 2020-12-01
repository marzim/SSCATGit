// <copyright file="UIControlNotFoundException.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the UIControlNotFoundException class
    /// </summary>
    public class UIControlNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the UIControlNotFoundException class
        /// </summary>
        /// <param name="automationId">automation ID</param>
        public UIControlNotFoundException(string automationId)
            : base(string.Format("NGUI Button {0} Not Found.", automationId))
        {
        }
    }
}
