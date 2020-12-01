// <copyright file="FingerPsxEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.OldModel
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the FingerPsxEvent class
    /// </summary>
    [XmlRoot("PsxEventData"), Serializable()]
    public class FingerPsxEvent
    {
        /// <summary>
        /// Event sequence ID
        /// </summary>
        private int _seqId;

        /// <summary>
        /// Whether or not event is forgivable 
        /// </summary>
        private bool _isForgivable = false;

        /// <summary>
        /// Remote connection name
        /// </summary>
        private string _remoteConnection;

        /// <summary>
        /// Event name
        /// </summary>
        private string _eventName;

        /// <summary>
        /// Event parameters
        /// </summary>
        private string _param;

        /// <summary>
        /// Control name
        /// </summary>
        private string _control;

        /// <summary>
        /// Context name
        /// </summary>
        private string _context;

        /// <summary>
        /// Event ID
        /// </summary>
        private string _id;

        /// <summary>
        /// Initializes a new instance of the FingerPsxEvent class
        /// </summary>
        public FingerPsxEvent()
        {
        }

        /// <summary>
        /// Gets or sets the sequence ID
        /// </summary>
        [XmlElement("seqId")]
        public int SeqId
        {
            get { return _seqId; }
            set { _seqId = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the event is forgivable
        /// </summary>
        [XmlElement("IsForgivable")]
        public bool IsForgivable
        {
            get { return _isForgivable; }
            set { _isForgivable = value; }
        }

        /// <summary>
        /// Gets or sets the PSX ID
        /// </summary>
        [XmlElement("psxId")]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        [XmlElement("contextName")]
        public string Context
        {
            get { return _context; }
            set { _context = value; }
        }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        [XmlElement("controlName")]
        public string Control
        {
            get { return _control; }
            set { _control = value; }
        }

        /// <summary>
        /// Gets or sets the event name
        /// </summary>
        [XmlElement("eventName")]
        public string Event
        {
            get { return _eventName; }
            set { _eventName = value; }
        }

        /// <summary>
        /// Gets or sets the event parameters
        /// </summary>
        [XmlElement("param")]
        public string Param
        {
            get { return _param; }
            set { _param = value; }
        }

        /// <summary>
        /// Gets or sets the remote connection name
        /// </summary>
        [XmlElement("remoteConnectionName")]
        public string RemoteConnection
        {
            get { return _remoteConnection; }
            set { _remoteConnection = value; }
        }
    }
}
