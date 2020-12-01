// <copyright file="ISscatLaunchPad.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ISscatLaunchPad class
    /// </summary>
    public interface ISscatLaunchPad : ILaunchPad
    {
        /// <summary>
        /// Events beyond PSX Clicks
        /// - Checks if Generate Diagnostic Log Files is property working
        /// - Closes Volume Control
        /// - Closes Event Viewer
        /// - Closes Terminal Information
        /// </summary>
        /// <param name="item">PSX Event</param>
        void PerformLaunchPadEvent(IPsxEvent item);
    }
}
