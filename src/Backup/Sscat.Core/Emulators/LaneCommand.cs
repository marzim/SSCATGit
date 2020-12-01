// <copyright file="LaneCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Emulators
{
    using Ncr.Core.Commands;

    /// <summary>
    /// Initializes a new instance of the LaneCommand class
    /// </summary>
    public abstract class LaneCommand : AbstractCommand
    {
        /// <summary>
        /// SSCAT lane
        /// </summary>
        private SscatLane _lane;

        /// <summary>
        /// Gets or sets the sscat lane
        /// </summary>
        public SscatLane Lane
        {
            get { return _lane; }
            set { _lane = value; }
        }
    }
}
