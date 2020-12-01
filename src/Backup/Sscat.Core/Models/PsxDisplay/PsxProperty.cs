// <copyright file="PsxProperty.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.PsxDisplay
{
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the PsxProperty class
    /// </summary>
    public class PsxProperty
    {
        /// <summary>
        /// Property name
        /// </summary>
        private string _propertyName;

        /// <summary>
        /// Property value
        /// </summary>
        private string _propertyValue;

        /// <summary>
        /// Gets or sets the property name
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        /// <summary>
        /// Gets or sets the property value
        /// </summary>
        [XmlText]
        public string Value
        {
            get { return _propertyValue; }
            set { _propertyValue = value; }
        }
    }
}
