// <copyright file="IEmulator.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;
    using System.Drawing;

    /// <summary>
    /// Initializes a new instance of the IEmulator interface
    /// </summary>
    public interface IEmulator : IApplication
    {
        /// <summary>
        /// Event handler for emulating
        /// </summary>
        event EventHandler<EmulatorEventArgs> Emulating;

        /// <summary>
        /// Gets or sets the caption
        /// </summary>
        string Caption { get; set; }

        /// <summary>
        /// Gets the handle
        /// </summary>
        IntPtr Handle { get; }

        /// <summary>
        /// Checks if handle is available
        /// </summary>
        /// <returns>Returns true if available, false otherwise</returns>
        bool Available();

        /// <summary>
        /// Click at given point
        /// </summary>
        /// <param name="point">point coordinates</param>
        void ClickAt(Point point);

        /// <summary>
        /// Click at given coordinates
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        void ClickAt(int x, int y);
    }
}
