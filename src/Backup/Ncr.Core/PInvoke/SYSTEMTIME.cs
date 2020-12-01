// <copyright file="SYSTEMTIME.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// System time structure
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        /// <summary>
        /// System time year
        /// </summary>
        public short Year;

        /// <summary>
        /// System time month
        /// </summary>
        public short Month;

        /// <summary>
        /// System time day of the week
        /// </summary>
        public short DayOfWeek;

        /// <summary>
        /// System time day
        /// </summary>
        public short Day;

        /// <summary>
        /// System time hour
        /// </summary>
        public short Hour;

        /// <summary>
        /// System time minute
        /// </summary>
        public short Minute;

        /// <summary>
        /// System time second
        /// </summary>
        public short Second;

        /// <summary>
        /// System time milliseconds
        /// </summary>
        public short Milliseconds;
    }
}
