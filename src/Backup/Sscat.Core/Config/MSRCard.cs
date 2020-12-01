// <copyright file="MSRCard.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the MSRCard class
    /// </summary>
    [XmlRoot("Card"), Serializable()]
    public class MSRCard : BaseModel<MSRCard>
    {
        /// <summary>
        /// MSR Card name
        /// </summary>
        private string _name;
        
        /// <summary>
        /// MSR Card track 1
        /// </summary>
        private string _track1;

        /// <summary>
        /// MSR Card track 2
        /// </summary>
        private string _track2;

        /// <summary>
        /// MSR Card track 3
        /// </summary>
        private string _track3;

        /// <summary>
        /// Initializes a new instance of the MSRCard class
        /// </summary>
        public MSRCard()
        {
        }

        /// <summary>
        /// Gets or sets the MSR card card name
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the MSR card track 1
        /// </summary>
        [XmlAttribute("Track1")]
        public string Track1
        {
            get { return _track1; }
            set { _track1 = value; }
        }

        /// <summary>
        /// Gets or sets the MSR card track 2
        /// </summary>
        [XmlAttribute("Track2")]
        public string Track2
        {
            get { return _track2; }
            set { _track2 = value; }
        }

        /// <summary>
        /// Gets or sets the MSR card track 3
        /// </summary>
        [XmlAttribute("Track3")]
        public string Track3
        {
            get { return _track3; }
            set { _track3 = value; }
        }

        /// <summary>
        /// Validates that the MSR card has a name and at least one track value
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            AddErrorIf("The card should have a name. ", _name == string.Empty);
            AddErrorIf("The card should contain at least one track value. ", _track1 == string.Empty && _track2 == string.Empty && _track3 == string.Empty);
        }
    }
}
