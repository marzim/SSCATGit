// <copyright file="LaneClickCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the LaneClickCommand class
    /// </summary>
    public class LaneClickCommand : LaneCommand
    {
        /// <summary>
        /// Lane control
        /// </summary>
        private string _control;

        /// <summary>
        /// Lane parameters
        /// </summary>
        private string _param;

        /// <summary>
        /// Initializes a new instance of the LaneClickCommand class
        /// </summary>
        /// <param name="control">lane control</param>
        /// <param name="param">lane parameters</param>
        public LaneClickCommand(string control, string param)
        {
            _control = control;
            _param = param;
        }

        /// <summary>
        /// Runs the lane click command
        /// </summary>
        public override void Run()
        {
            Lane.Click(_control, _param, 5000, false);
            ThreadHelper.Sleep(200);
        }
    }
}
