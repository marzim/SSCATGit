// <copyright file="PsxControls.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.PsxDisplay
{
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the PsxControls class
    /// </summary>
    public class PsxControls
    {
        /// <summary>
        /// PSX Controls
        /// </summary>
        private PsxControl[] _controls;

        /// <summary>
        /// Gets or sets the PSX controls
        /// </summary>
        [XmlElement("Control")]
        public PsxControl[] Controls
        {
            get { return _controls; }
            set { _controls = value; }
        }

        /// <summary>
        /// Gets a control by name
        /// </summary>
        /// <param name="controlName">control name</param>
        /// <returns>Returns the control if found, null otherwise</returns>
        public PsxControl GetControl(string controlName)
        {
            foreach (PsxControl control in _controls)
            {
                if (control.Name == controlName)
                {
                    return control;
                }
            }

            return null;
        }
    }
}
