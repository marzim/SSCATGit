// <copyright file="PsxProperties.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.PsxDisplay
{
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the PsxProperties class
    /// </summary>
    public class PsxProperties
    {
        /// <summary>
        /// PSX property
        /// </summary>
        private PsxProperty[] _property;

        /// <summary>
        /// Gets or sets the properties
        /// </summary>
        [XmlElement("Property")]
        public PsxProperty[] Properties
        {
            get { return _property; }
            set { _property = value; }
        }

        /// <summary>
        /// Gets a property by name
        /// </summary>
        /// <param name="propertyName">property name</param>
        /// <returns>Returns property if found, null otherwise</returns>
        public PsxProperty GetProperty(string propertyName)
        {
            foreach (PsxProperty property in Properties)
            {
                if (property.Name.Equals(propertyName))
                {
                    return property;
                }
            }

            return null;
        }

        /// <summary>
        /// Sets a property by name
        /// </summary>
        /// <param name="propertyName">property name</param>
        /// <param name="propertyValue">property value</param>
        public void SetProperty(string propertyName, object propertyValue)
        {
            foreach (PsxProperty property in Properties)
            {
                if (property.Name.Equals(propertyName))
                {
                    property.Value = propertyValue.ToString();
                }
            }
        }
    }
}
