// <copyright file="WeighBagScale.cs" company="NCR">
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
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the WeighBagScale class
    /// </summary>
    public class WeighBagScale : EmulatorEventCommand
    {
        /// <summary>
        /// Interface for the bag scale
        /// </summary>
        private IBagScale _scale;

        /// <summary>
        /// Initializes a new instance of the WeighBagScale class
        /// </summary>
        /// <param name="scale">bag scale</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public WeighBagScale(IBagScale scale, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, scale, lane, timeout, enableHook)
        {
            if (scale == null)
            {
                throw new ArgumentNullException("BagScale");
            }

            _scale = scale;
        }

        /// <summary>
        /// Runs the bag scale
        /// </summary>
        public override void Run()
        {
            try
            {
                int weight = Convert.ToInt32(Item.Value);
                if (weight < 35 || weight == _scale.Weight)
                {
                    // HACK: This is a freaking hack, emulators mysteriously behaves on values lesser than 35.
                    _scale.Weigh(weight, Timeout);
                    Result = new Result(ResultType.Passed, "OK");
                }
                else
                {
                    _scale.Weigh(weight, Timeout);
                    base.Run();
                }
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
