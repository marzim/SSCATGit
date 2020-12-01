// <copyright file="ThreadHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Threading;

    /// <summary>
    /// Initializes static members of the ThreadHelper class
    /// </summary>
    public static class ThreadHelper
    {
        /// <summary>
        /// Thread manager interface
        /// </summary>
        private static IThreadManager _manager;

        /// <summary>
        /// Initializes static members of the ThreadHelper class
        /// </summary>
        static ThreadHelper()
        {
            Attach(new ThreadManager());
        }

        /// <summary>
        /// Attach thread manager
        /// </summary>
        /// <param name="manager">thread manager</param>
        public static void Attach(IThreadManager manager)
        {
            ThreadHelper._manager = manager;
        }

        /// <summary>
        /// Sleep for given time
        /// </summary>
        /// <param name="time">time to sleep</param>
        public static void Sleep(int time)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ThreadManager");
            }

            _manager.Sleep(time);
        }

        /// <summary>
        /// Start thread
        /// </summary>
        /// <param name="threadStart">thread start</param>
        public static void Start(ThreadStart threadStart)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("ThreadManager");
            }

            _manager.Start(threadStart);
        }
    }
}
