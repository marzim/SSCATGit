// <copyright file="SscatContext.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core
{
    using Sscat.Core.Emulators;
    using Sscat.Core.Services;

    /// <summary>
    /// Initializes a new instance of the SscatContext class
    /// </summary>
    public class SscatContext
    {
        /// <summary>
        /// Sscat lane
        /// </summary>
        private static SscatLane _lane;

        /// <summary>
        /// Lane service
        /// </summary>
        private static LaneService _service;

        /// <summary>
        /// Gets or sets the SSCAT lane
        /// </summary>
        public static SscatLane Lane
        {
            get { return _lane; }
            set { _lane = value; }
        }

        /// <summary>
        /// Gets or sets the lane service
        /// </summary>
        public static LaneService LaneService
        {
            get { return _service; }
            set { _service = value; }
        }
    }
}
