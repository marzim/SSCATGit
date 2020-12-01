// <copyright file="ESAIntervention.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events.Device
{
    using System;
    using System.Text.RegularExpressions;
    using Ncr.Core.Emulators;
    using Ncr.Core.Util;
#if NET40
    using Sscat.Core.Commands.Events.UIAutoTest;
#endif
    using Sscat.Core.Emulators;
    using Sscat.Core.Log;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    
    /// <summary>
    /// Initializes a new instance of the ESAIntervention class
    /// </summary>
    public class ESAIntervention : DeviceEventCommand
    {
        /// <summary>
        /// Interface for the ESA Emulator
        /// </summary>
        private IEsaEmulator _esaEmulator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ESAIntervention"/> class
        /// </summary>
        /// <param name="hook">scot log hook</param>
        /// <param name="item">device event</param>
        /// <param name="lane">sscat lane</param>
        /// <param name="timeout">the timeout</param>
        /// <param name="enableHook">whether or not hook is enabled</param>
        public ESAIntervention(IScotLogHook hook, IDeviceEvent item, SscatLane lane, int timeout, bool enableHook)
            : base(hook, item, lane, timeout, enableHook)
        {
            _esaEmulator = new ESAEmulator();
        }
        
        /// <summary>
        /// Runs the ESA intervention event
        /// </summary>
        public override void Run()
        {
            try
            {
                _esaEmulator.Intervene(Item.Value, Timeout);
                LoggingService.Info(string.Format("Item value : {0}", Item.Value));
                base.Run();
            }
            catch (EmulatorTimeoutException ex)
            {
                Result = new Result(ResultType.Failed, Regex.Replace(ex.Message, @"\t|\n|\r", "; "));
            }
            catch (Exception ex)
            {
                Result = new Result(ResultType.Failed, Regex.Replace(ex.Message, @"\t|\n|\r", "; "));
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
