// <copyright file="NXTUIClickCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using System;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the NXTUIClickCommand class
    /// </summary>
    public class NXTUIClickCommand : LaneCommand
    {
        /// <summary>
        /// Lane control
        /// </summary>
        private string _context;

        /// <summary>
        /// Lane control
        /// </summary>
        private string _control;

        /// <summary>
        /// Lane parameters
        /// </summary>
        private string _param;

        /// <summary>
        /// Initializes a new instance of the NXTUIClickCommand class
        /// </summary>
        /// <param name="control">lane control</param>
        /// <param name="context">lane context</param>
        /// <param name="param">lane parameters</param>
        public NXTUIClickCommand(string control, string context, string param)
        {
            _control = control;
            _context = context;
            _param = param;
        }

        /// <summary>
        /// Runs the lane click command
        /// </summary>
        public override void Run()
        {
            try
            {
                LoggingService.Info(string.Format("[SmartExit] Clicking {0} in {1}", _control, _context));
                Lane.NXTUIClick(_control, _context, _param);
                ThreadHelper.Sleep(200);
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
            }
        }
    }
}
