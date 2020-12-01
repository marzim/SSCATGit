// <copyright file="KeyPad.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the KeyPad class
    /// </summary>
    [XmlRoot("KeyPad"), Serializable()]
    public class KeyPad
    {
        /// <summary>
        /// Name of the key pad
        /// </summary>
        private string _name;

        /// <summary>
        /// Type of keypad
        /// </summary>
        private string _type;

        /// <summary>
        /// An invalid ID for invalid login
        /// </summary>
        private string _invalidId;

        /// <summary>
        /// An invalid Password for invalid login
        /// </summary>
        private string _invalidPassword;

        /// <summary>
        /// Name for enter key
        /// </summary>
        private string _enterKeyName;

        /// <summary>
        /// Automated login keys
        /// </summary>
        private Key[] _keys;

        /// <summary>
        /// Gets or sets the automated login keys
        /// </summary>
        [XmlElement("Key")]
        public Key[] Keys
        {
            get
            {
                if (_keys == null)
                {
                    _keys = new Key[0];
                }

                return _keys;
            }

            set
            {
                _keys = value;
            }
        }

        /// <summary>
        /// Gets or sets the key pad name
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the key pad type
        /// </summary>
        [XmlAttribute("Type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets the invalid ID for invalid login
        /// </summary>
        [XmlAttribute("InvalidId")]
        public string InvalidId
        {
            get { return _invalidId; }
            set { _invalidId = value; }
        }

        /// <summary>
        /// Gets or sets the invalid Password for invalid login
        /// </summary>
        [XmlAttribute("InvalidPassword")]
        public string InvalidPassword
        {
            get { return _invalidPassword; }
            set { _invalidPassword = value; }
        }

        /// <summary>
        /// Gets or sets the enter key name
        /// </summary>
        [XmlAttribute("EnterKeyName")]
        public string EnterKeyName
        {
            get { return _enterKeyName; }
            set { _enterKeyName = value; }
        }
    }
}
