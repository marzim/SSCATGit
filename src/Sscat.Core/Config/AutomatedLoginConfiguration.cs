// <copyright file="AutomatedLoginConfiguration.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the AutomatedLoginConfiguration class
    /// </summary>
    [XmlRoot("AutomatedLogin"), Serializable()]
    public class AutomatedLoginConfiguration : BaseModel<AutomatedLoginConfiguration>
    {
        /// <summary>
        /// Name of the key pad
        /// </summary>
        private string _name;

        /// <summary>
        /// Keypads for automated login
        /// </summary>
        private KeyPad[] _keyPads;

        /// <summary>
        /// Gets or sets the name of the key pad
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the key pads for automated login
        /// </summary>
        [XmlElement("KeyPad")]
        public KeyPad[] KeyPads
        {
            get
            {
                if (_keyPads == null)
                {
                    _keyPads = new KeyPad[0];
                }

                return _keyPads;
            }

            set
            {
                _keyPads = value;
            }
        }
    }    
}
