// <copyright file="LaneHooks.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the LaneHooks class
    /// </summary>
    public class LaneHooks
    {
        /// <summary>
        /// Lane hooks
        /// </summary>
        private LaneHook[] _hooks;

        /// <summary>
        /// Gets or sets the lane hooks
        /// </summary>
        [XmlElement("Hook")]
        public LaneHook[] Hooks
        {
            get { return _hooks; }
            set { _hooks = value; }
        }
    }    
}
