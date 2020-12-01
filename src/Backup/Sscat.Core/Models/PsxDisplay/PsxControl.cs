// <copyright file="PsxControl.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.PsxDisplay
{
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the PsxControl class
    /// </summary>
    public class PsxControl
    {
        /// <summary>
        /// Control name
        /// </summary>
        private string _name;

        /// <summary>
        /// PSX Properties
        /// </summary>
        private PsxProperties _properties;

        /// <summary>
        /// Control type
        /// </summary>
        private string _type;

        /// <summary>
        /// PSX List
        /// </summary>
        private PsxList _list;

        /// <summary>
        /// Initializes a new instance of the PsxControl class
        /// </summary>
        public PsxControl()
        {
        }

        /// <summary>
        /// Gets or sets the PSX list
        /// </summary>
        [XmlElement("List")]
        public PsxList List
        {
            get { return _list; }
            set { _list = value; }
        }

        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [XmlAttribute("Type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets the psx properties
        /// </summary>
        [XmlElement("Properties")]
        public PsxProperties Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
