// <copyright file="IThreadManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Threading;

    /// <summary>
    /// Initializes a new instance of the IThreadManager interface
    /// </summary>
    public interface IThreadManager
    {
        /// <summary>
        /// Sleep for given time
        /// </summary>
        /// <param name="time">time to sleep</param>
        void Sleep(int time);

        /// <summary>
        /// Start thread
        /// </summary>
        /// <param name="threadStart">thread start</param>
        void Start(ThreadStart threadStart);
    }
}
