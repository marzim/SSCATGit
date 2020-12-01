// <copyright file="ScaleEventAdder.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers.DeviceEvents
{
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ScaleEventAdder class
    /// </summary>
    public class ScaleEventAdder : DeviceEventAdder
    {
        /// <summary>
        /// Initializes a new instance of the ScaleEventAdder class
        /// </summary>
        public ScaleEventAdder()
            : base(Constants.DeviceType.SCALE)
        {
        }
    }
}
