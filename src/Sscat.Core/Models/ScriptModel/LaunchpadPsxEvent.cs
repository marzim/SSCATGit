// <copyright file="LaunchPadPsxEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the LaunchPadPsxEvent class
    /// </summary>
    [XmlRoot("LaunchPadPsx"), Serializable()]
    public class LaunchPadPsxEvent : PsxEvent, ILaunchPadPsxEvent
    {
        /// <summary>
        /// Initializes a new instance of the LaunchPadPsxEvent class
        /// </summary>
        public LaunchPadPsxEvent()
            : this(string.Empty, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the LaunchPadPsxEvent class
        /// </summary>
        /// <param name="contextName">name of the context</param>
        /// <param name="controlName">name of the control</param>
        /// <param name="eventName">name of the event</param>
        public LaunchPadPsxEvent(string contextName, string controlName, string eventName)
            : base(contextName, controlName, eventName, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Gets the event type
        /// </summary>
        public override string Type
        {
            get { return "LaunchPadPsxEventData"; }
        }

        /// <summary>
        /// Creates a new launch pad psx event
        /// </summary>
        /// <returns>Returns the script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new LaunchPadPsxEvent(Context, Control, Event);
        }
    }
}