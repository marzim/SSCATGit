// <copyright file="ReportPsxEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.Report
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ReportPsxEvent class
    /// </summary>
    [Serializable]
    public class ReportPsxEvent
    {
        /// <summary>
        /// Context name
        /// </summary>
        private string _contextName;

        /// <summary>
        /// Control name
        /// </summary>
        private string _controlName;

        /// <summary>
        /// Event ID
        /// </summary>
        private string _id;

        /// <summary>
        /// Event name
        /// </summary>
        private string _eventName;

        /// <summary>
        /// Remote connection name
        /// </summary>
        private string _remoteConnection;

        /// <summary>
        /// Event parameters
        /// </summary>
        private string _param;

        /// <summary>
        /// Initializes a new instance of the ReportPsxEvent class
        /// </summary>
        public ReportPsxEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportPsxEvent class
        /// </summary>
        /// <param name="item">psx event item</param>
        public ReportPsxEvent(IPsxEvent item)
        {
            Id = item.Id;
            Context = item.Context;
            Control = item.Control;
            RemoteConnection = item.RemoteConnection;
            Event = item.Event;
        }

        /// <summary>
        /// Gets or sets the event parameters
        /// </summary>
        [XmlAttribute("Param")]
        public string Param
        {
            get { return _param; }
            set { _param = value; }
        }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        [XmlAttribute("Context")]
        public string Context
        {
            get { return _contextName; }
            set { _contextName = value; }
        }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        [XmlAttribute("Control")]
        public string Control
        {
            get { return _controlName; }
            set { _controlName = value; }
        }

        /// <summary>
        /// Gets or sets the event ID
        /// </summary>
        [XmlAttribute("Id")]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the event name
        /// </summary>
        [XmlAttribute("Event")]
        public string Event
        {
            get { return _eventName; }
            set { _eventName = value; }
        }

        /// <summary>
        /// Gets or sets the remote connection name
        /// </summary>
        [XmlAttribute("RemoteConnection")]
        public string RemoteConnection
        {
            get { return _remoteConnection; }
            set { _remoteConnection = value; }
        }
    }
}
