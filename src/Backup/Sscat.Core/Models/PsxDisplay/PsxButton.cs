// <copyright file="PsxButton.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.PsxDisplay
{
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the PsxButton class
    /// </summary>
    public class PsxButton
    {
        /// <summary>
        /// PSX button value
        /// </summary>
        private string _val;

        /// <summary>
        /// Gets or sets the button value
        /// </summary>
        [XmlText]
        public string Value
        {
            get { return _val; }
            set { _val = value; }
        }

        /// <summary>
        /// Gets the button ID
        /// </summary>
        public string Id
        {
            get { return Value.Split(',')[0]; }
        }

        /// <summary>
        /// Gets the button parameters
        /// </summary>
        public string Param
        {
            get { return Value.Split(',')[2].ToString(); }
        }
    }
}
