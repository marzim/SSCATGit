// <copyright file="PsxContext.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.PsxDisplay
{
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the PsxContext class
    /// </summary>
    public class PsxContext
    {
        /// <summary>
        /// Context name
        /// </summary>
        private string _name;

        /// <summary>
        /// PSX properties
        /// </summary>
        private PsxProperties _properties;

        /// <summary>
        /// PSX list
        /// </summary>
        private PsxList _list;

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
        /// Gets or sets the psx list
        /// </summary>
        [XmlElement("List")]
        public PsxList List
        {
            get { return _list; }
            set { _list = value; }
        }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
