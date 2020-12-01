// <copyright file="SwipeMsr.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands
{
    using System;
    using Ncr.Core.Emulators;
#if NET40
    using Sscat.Core.Commands.Events.UIAutoTest;
#endif
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the SwipeMsr class
    /// </summary>
    public class SwipeMsr : DeviceEventCommand
    {
        /// <summary>
        /// Interface for the magnetic stripe reader
        /// </summary>
        private IMsr _msr;

        /// <summary>
        /// Initializes a new instance of the SwipeMsr class
        /// </summary>
        /// <param name="msr">magnetic stripe reader</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public SwipeMsr(IMsr msr, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
            if (msr == null)
            {
                throw new ArgumentNullException("MSR");
            }

            _msr = msr;
        }

        /// <summary>
        /// Runs the MSR swipe event
        /// </summary>
        public override void Run()
        {
            try
            {
                _msr.Swipe(Item.Value, Timeout);
                base.Run();
            }
            catch
            {
                throw;
            }
            finally
            {
#if NET40
                NextGenUITestClient.Instance.CheckConnection();
#endif
            }
        }
    }
}
