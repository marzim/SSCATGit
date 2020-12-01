// <copyright file="ReportXmEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.Report
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the ReportXmEvent class
    /// </summary>
    [Serializable]
    public class ReportXmEvent
    {
        /// <summary>
        /// External mode Event ID
        /// </summary>
        private string _id;

        /// <summary>
        /// External mode Event values
        /// </summary>
        private string[] _values;

        /// <summary>
        /// Value count
        /// </summary>
        private int _valueCount;

        /// <summary>
        /// Initializes a new instance of the ReportXmEvent class
        /// </summary>
        public ReportXmEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ReportXmEvent class
        /// </summary>
        /// <param name="item">XM event item</param>
        public ReportXmEvent(IXmEvent item)
        {
            Id = item.Id;
            Values = item.Values;
            ValueCount = item.ValueCount;
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
        /// Gets or sets the value count
        /// </summary>
        [XmlAttribute("ValueCount")]
        public int ValueCount
        {
            get { return _valueCount; }
            set { _valueCount = value; }
        }

        /// <summary>
        /// Gets or sets the values
        /// </summary>
        [XmlAttribute("Values")]
        public string[] Values
        {
            get { return _values; }
            set { _values = value; }
        }
    }
}
