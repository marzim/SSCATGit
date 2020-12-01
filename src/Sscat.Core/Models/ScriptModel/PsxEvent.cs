// <copyright file="PsxEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the PsxEvent class
    /// </summary>
    [XmlRoot("Psx"), Serializable()]
    public class PsxEvent : AbstractPsxEvent<PsxEvent>
    {
        /// <summary>
        /// Initializes a new instance of the PsxEvent class
        /// </summary>
        public PsxEvent()
            : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the PsxEvent class
        /// </summary>
        /// <param name="contextName">name of the context</param>
        /// <param name="controlName">name of the control</param>
        /// <param name="eventName">name of the event</param>
        /// <param name="param">event parameters</param>
        /// <param name="remoteConnectionName">remote connection name</param>
        public PsxEvent(string contextName, string controlName, string eventName, string param, string remoteConnectionName)
        {
            Context = contextName;
            Control = controlName;
            Event = eventName;
            Param = param;
            RemoteConnection = remoteConnectionName;
        }

        /// <summary>
        /// Gets or sets the PSX ID
        /// </summary>
        [XmlAttribute("PsxId")]
        public override string Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        [XmlAttribute("Context")]
        public override string Context
        {
            get { return base.Context; }
            set { base.Context = value; }
        }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        [XmlAttribute("Control")]
        public override string Control
        {
            get { return base.Control; }
            set { base.Control = value; }
        }

        /// <summary>
        /// Gets or sets the event name
        /// </summary>
        [XmlAttribute("Event")]
        public override string Event
        {
            get { return base.Event; }
            set { base.Event = value; }
        }

        /// <summary>
        /// Gets or sets the event parameters
        /// </summary>
        [XmlAttribute("Param")]
        public override string Param
        {
            get { return base.Param; }
            set { base.Param = value; }
        }

        /// <summary>
        /// Gets or sets the remote connection name
        /// </summary>
        [XmlAttribute("RemoteConnectionName")]
        public override string RemoteConnection
        {
            get { return base.RemoteConnection; }
            set { base.RemoteConnection = value; }
        }

        /// <summary>
        /// Gets or sets the sequence ID
        /// </summary>
        [XmlIgnore]
        public override int SeqId
        {
            get { return base.SeqId; }
            set { base.SeqId = value; }
        }

        /// <summary>
        /// Gets the event type
        /// </summary>
        public override string Type
        {
            get { return "PsxEventData"; }
        }

        /// <summary>
        /// Creates event
        /// </summary>
        /// <returns>Returns script event</returns>
        public override IScriptEvent CreateEvent()
        {
            return CreateEvent(0, true);
        }

        /// <summary>
        /// Create event
        /// </summary>
        /// <param name="time">event time</param>
        /// <param name="enabled">whether or not to enable</param>
        /// <returns>Returns the script event</returns>
        public override IScriptEvent CreateEvent(long time, bool enabled)
        {
            return new SSCATScriptEvent(time, enabled, this);
        }

        /// <summary>
        /// Creates the script event
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="dateTime">date and time</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <returns>Returns the script event</returns>
        public override IScriptEvent CreateEvent(long time, DateTime dateTime, bool enabled)
        {
            return new SSCATScriptEvent(time, dateTime, enabled, this);
        }

        /// <summary>
        /// Creates a new PSX event
        /// </summary>
        /// <returns>Returns the script event item</returns>
        public override IScriptEventItem ToEventItem()
        {
            return new PsxEvent(Context, Control, Event, Param, RemoteConnection);
        }

        /// <summary>
        /// ShouldSerialize* pattern for ContextName
        /// </summary>
        /// <returns>returns if ContextName is null or empty</returns>
        public bool ShouldSerializeContext()
        {
            return !string.IsNullOrEmpty(Context);
        }

        /// <summary>
        /// ShouldSerialize* pattern for ControlName
        /// </summary>
        /// <returns>returns if ControlName is null or empty</returns>
        public bool ShouldSerializeControl()
        {
            return !string.IsNullOrEmpty(Control);
        }

        /// <summary>
        /// ShouldSerialize* pattern for Event
        /// </summary>
        /// <returns>returns if Event is null or empty</returns>
        public bool ShouldSerializeEvent()
        {
            return !string.IsNullOrEmpty(Event);
        }

        /// <summary>
        /// ShouldSerialize* pattern for Param
        /// </summary>
        /// <returns>returns if Param is null or empty</returns>
        public bool ShouldSerializeParam()
        {
            return !string.IsNullOrEmpty(Param);
        }

        /// <summary>
        /// ShouldSerialize* pattern for RemoteConnection
        /// </summary>
        /// <returns>returns if RemoteConnection is null or empty</returns>
        public bool ShouldSerializeRemoteConnection()
        {
            return !string.IsNullOrEmpty(RemoteConnection);
        }
    }
}
