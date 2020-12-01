// <copyright file="PROCESS_BASIC_INFORMATION.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.PInvoke
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Process basic information structure from MSDN Process Invoker
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESS_BASIC_INFORMATION
    {
        /// <summary>
        /// Exit status
        /// </summary>
        public int ExitStatus;

        /// <summary>
        /// Process environment block base address
        /// </summary>
        public int PebBaseAddress;

        /// <summary>
        /// Affinity mask
        /// </summary>
        public int AffinityMask;

        /// <summary>
        /// Base priority
        /// </summary>
        public int BasePriority;

        /// <summary>
        /// Unique process ID
        /// </summary>
        public int UniqueProcessId;

        /// <summary>
        /// Inherited from unique process ID
        /// </summary>
        public int InheritedFromUniqueProcessId;

        /// <summary>
        /// Gets the size
        /// </summary>
        public int Size
        {
            get { return 6 * 4; }
        }
    }
}
