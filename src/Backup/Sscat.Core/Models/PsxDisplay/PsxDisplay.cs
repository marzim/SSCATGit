// <copyright file="PsxDisplay.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.PsxDisplay
{
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the PsxDisplay class
    /// </summary>
    [XmlRoot("Display")]
    public class PsxDisplay : BaseSerializable<PsxDisplay>
    {
        /// <summary>
        /// PSX Controls
        /// </summary>
        private PsxControls _controls;

        /// <summary>
        /// PSX Contexts
        /// </summary>
        private PsxContexts _contexts;

        /// <summary>
        /// Gets or sets the PSX contexts
        /// </summary>
        [XmlElement("Contexts")]
        public PsxContexts Contexts
        {
            get { return _contexts; }
            set { _contexts = value; }
        }

        /// <summary>
        /// Gets or sets the PSX controls
        /// </summary>
        [XmlElement("Controls")]
        public PsxControls Controls
        {
            get { return _controls; }
            set { _controls = value; }
        }
    }
}
