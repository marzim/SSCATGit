// <copyright file="BackCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Emulators;

    /// <summary>
    /// Initializes a new instance of the BackCommand class
    /// </summary>
    public class BackCommand
    {
        /// <summary>
        /// Context for back command
        /// </summary>
        private string _context;

        /// <summary>
        /// Control for back command
        /// </summary>
        private string _control;

        /// <summary>
        /// Parameters for back command
        /// </summary>
        private string _param;

        /// <summary>
        /// Action for back command
        /// </summary>
        private string _action;
        
        /// <summary>
        /// Gets a value indicating whether the back command has an action
        /// </summary>
        public bool HasAction
        {
            get { return _action != null && _action != string.Empty; }
        }

        /// <summary>
        /// Gets or sets the back command action
        /// </summary>
        [XmlAttribute("Action")]
        public string Action
        {
            get { return _action; }
            set { _action = value; }
        }

        /// <summary>
        /// Gets or sets the back command parameter
        /// </summary>
        [XmlAttribute("Param")]
        public string Param
        {
            get { return _param; }
            set { _param = value; }
        }

        /// <summary>
        /// Gets or sets the back command control
        /// </summary>
        [XmlAttribute("Control")]
        public string Control
        {
            get { return _control; }
            set { _control = value; }
        }

        /// <summary>
        /// Gets or sets the back command context
        /// </summary>
        [XmlAttribute("Context")]
        public string Context
        {
            get { return _context; }
            set { _context = value; }
        }

        /// <summary>
        /// Instantiates the back command action
        /// </summary>
        /// <returns>Returns the lane command from the action</returns>
        public LaneCommand InstantiateAction()
        {
            Type t = Type.GetType(Action);
            if (t != null)
            {
                return Activator.CreateInstance(t) as LaneCommand;
            }

            return null;
        }
    }
}
