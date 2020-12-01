// <copyright file="WeighScale.cs" company="NCR">
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
    /// Initializes a new instance of the WeighScale class
    /// </summary>
    public class WeighScale : EmulatorEventCommand
    {
        /// <summary>
        /// Interface for the scale
        /// </summary>
        private IScale _scale;

        /// <summary>
        /// Initializes a new instance of the WeighScale class
        /// </summary>
        /// <param name="scale">interface for the scale</param>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public WeighScale(IScale scale, IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, scale, lane, timeout, enableHook)
        {
            if (scale == null)
            {
                throw new ArgumentNullException("Scale");
            }

            _scale = scale;
        }

        /// <summary>
        /// Runs the scale event
        /// </summary>
        public override void Run()
        {
            try
            {
                int weight = Convert.ToInt32(Item.Value);
                if (weight < 5 && weight == _scale.Weight)
                {
                    // HACK: SSCAT-846 Customer logs sometimes generates Scale 0 events in the middle of transactions.
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
