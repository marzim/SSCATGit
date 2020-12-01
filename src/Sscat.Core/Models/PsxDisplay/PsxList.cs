// <copyright file="PsxList.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.PsxDisplay
{
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the PsxList class
    /// </summary>
    public class PsxList
    {
        /// <summary>
        /// PSX button
        /// </summary>
        private PsxButton[] _buttons;

        /// <summary>
        /// Gets or sets the PSX buttons
        /// </summary>
        [XmlElement("Button")]
        public PsxButton[] Buttons
        {
            get { return _buttons; }
            set { _buttons = value; }
        }

        /// <summary>
        /// Gets a button by ID
        /// </summary>
        /// <param name="buttonId">Button ID</param>
        /// <returns>Returns the button if found, null otherwise</returns>
        public PsxButton GetButton(string buttonId)
        {
            foreach (PsxButton button in Buttons)
            {
                if (buttonId == button.Id)
                {
                    return button;
                }
            }

            return null;
        }
    }
}
