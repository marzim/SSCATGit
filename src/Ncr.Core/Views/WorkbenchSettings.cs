// <copyright file="WorkbenchSettings.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Views
{
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the WorkbenchSettings class
    /// </summary>
    [XmlRoot("Settings")]
    public class WorkbenchSettings : BaseSerializable<WorkbenchSettings>
    {
        /// <summary>
        /// Workbench settings size
        /// </summary>
        private string _size;

        /// <summary>
        /// Workbench settings location
        /// </summary>
        private string _location;

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        [XmlAttribute("Location")]
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        [XmlAttribute("Size")]
        public string Size
        {
            get { return _size; }
            set { _size = value; }
        }
    }
}
