// <copyright file="ThreadManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.Threading;

    /// <summary>
    /// Initializes a new instance of the ThreadManager class
    /// </summary>
    public class ThreadManager : IThreadManager
    {
        /// <summary>
        /// Sleep for given time
        /// </summary>
        /// <param name="time">time to sleep</param>
        public void Sleep(int time)
        {
            Thread.Sleep(time);
        }

        /// <summary>
        /// Start thread
        /// </summary>
        /// <param name="threadStart">thread start</param>
        public void Start(ThreadStart threadStart)
        {
            new Thread(new ThreadStart(threadStart)).Start();
        }
    }
}
