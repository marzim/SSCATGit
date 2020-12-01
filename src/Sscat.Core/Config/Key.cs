// <copyright file="Key.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the Key class
    /// </summary>
    [XmlRoot("Key"), Serializable()]
    public class Key
    {
        /// <summary>
        /// Key name
        /// </summary>
        private string _name;
        
        /// <summary>
        /// Button name
        /// </summary>
        private string _buttonName;
        
        /// <summary>
        /// Button data
        /// </summary>
        private string _buttonData;

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        /// <summary>
        /// Gets or sets the button name
        /// </summary>
        [XmlAttribute("ButtonName")]
        public string ButtonName
        {
            get { return _buttonName; }
            set { _buttonName = value; }
        }

        /// <summary>
        /// Gets or sets the button data
        /// </summary>
        [XmlAttribute("ButtonData")]
        public string ButtonData
        {
            get { return _buttonData; }
            set { _buttonData = value; }
        }
    }
}
