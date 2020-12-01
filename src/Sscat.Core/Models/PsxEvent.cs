// <copyright file="PsxEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Xml.Serialization;

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
        {
        }

        /// <summary>
        /// Initializes a new instance of the PsxEvent class
        /// </summary>
        /// <param name="id">event id</param>
        /// <param name="context">context name</param>
        /// <param name="control">control name</param>
        /// <param name="eventName">event name</param>
        /// <param name="param">event parameters</param>
        /// <param name="remoteConnection">remote connection name</param>
        /// <param name="seqId">sequence ID</param>
        public PsxEvent(string id, string context, string control, string eventName, string param, string remoteConnection, int seqId)
            : base(id, context, control, eventName, param, remoteConnection, seqId)
        {
        }

        /// <summary>
        /// Gets or sets the event ID
        /// </summary>
        [XmlAttribute("Id")]
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
        [XmlAttribute("RemoteConnection")]
        public override string RemoteConnection
        {
            get { return base.RemoteConnection; }
            set { base.RemoteConnection = value; }
        }

        /// <summary>
        /// Gets or sets the sequence ID
        /// </summary>
        [XmlAttribute("SeqId")]
        public override int SeqId
        {
            get { return base.SeqId; }
            set { base.SeqId = value; }
        }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        [XmlElement("Control")]
        public override string Control
        {
            get { return base.Control; }
            set { base.Control = value; }
        }

        /// <summary>
        /// Gets the type of event
        /// </summary>
        public override string Type
        {
            get { return "Psx"; }
        }

        /// <summary>
        /// Creates a string about the psx event
        /// </summary>
        /// <returns>Returns the psx event information</returns>
        public override IScriptEvent CreateEvent()
        {
            return CreateEvent(0, true);
        }

        /// <summary>
        /// Creates the psx event
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <returns>Returns the script event</returns>
        public override IScriptEvent CreateEvent(int time, bool enabled)
        {
            return new ScriptEvent(time, enabled, this);
        }

        /// <summary>
        /// Creates the psx event item
        /// </summary>
        /// <returns>Returns the script event</returns>
        public override IScriptEventItem ToEventItem()
        {
            throw new NotImplementedException();
        }
    }
}
