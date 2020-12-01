// <copyright file="RECT.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Rectangle structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        /// <summary>
        /// Left of rectangle
        /// </summary>
        public int Left;

        /// <summary>
        /// Top of rectangle
        /// </summary>
        public int Top;

        /// <summary>
        /// Right of rectangle
        /// </summary>
        public int Right;

        /// <summary>
        /// Bottom of rectangle
        /// </summary>
        public int Bottom;
    }
}
