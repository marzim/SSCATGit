// <copyright file="LaneParserPattern.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Xml.Serialization;
    using Sscat.Core.Parsers;

    /// <summary>
    /// Initializes a new instance of the LaneParserPattern class
    /// </summary>
    public class LaneParserPattern
    {
        /// <summary>
        /// Parser adder
        /// </summary>
        private string _adder;

        /// <summary>
        /// Parser Value
        /// </summary>
        private string _val;

        /// <summary>
        /// Parser Value
        /// </summary>
        private string _notes;
        
        /// <summary>
        /// Parser enabled
        /// </summary>
        private bool _enabled;

        /// <summary>
        /// whether parser pattern is a warning
        /// </summary>
        private bool _error;

        /// <summary>
        /// Parser event value
        /// </summary>
        private string _eventValue;

        /// <summary>
        /// Parser condition
        /// </summary>
        private string _condition;

        /// <summary>
        /// Gets or sets the parser value
        /// </summary>
        [XmlTextAttribute]
        public string Value
        {
            get { return _val; }
            set { _val = value; }
        }

        /// <summary>
        /// Gets or sets the parser adder
        /// </summary>
        [XmlAttribute("Adder")]
        public string Adder
        {
            get { return _adder; }
            set { _adder = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether enabled
        /// </summary>
        [XmlAttribute("Enabled")]
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether enabled
        /// </summary>
        [XmlAttribute("Error")]
        public bool Error
        {
            get { return _error; }
            set { _error = value; }
        }
        
        /// <summary>
        /// Gets or sets the event value
        /// </summary>
        [XmlAttribute("EventValue")]
        public string EventValue
        {
            get { return _eventValue; }
            set { _eventValue = value; }
        }

        /// <summary>
        /// Gets or sets the parser condition
        /// </summary>
        [XmlAttribute("Condition")]
        public string Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        /// <summary>
        /// Gets or sets the Notes
        /// </summary>
        [XmlAttribute("Notes")]
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the parser pattern has a condition
        /// </summary>
        public bool HasCondition
        {
            get
            {
                return Condition != null && Condition != string.Empty;
            }
        }

        /// <summary>
        /// Instantiates the event adder for the parser
        /// </summary>
        /// <returns>Returns the event adder</returns>
        public IEventAdder InstantiateAdder()
        {
            if (Adder != null && !Adder.Equals(string.Empty))
            {
                Type t = Type.GetType(Adder);
                if (t != null)
                {
                    return Activator.CreateInstance(t) as IEventAdder;
                }
            }

            return null;
        }

        /// <summary>
        /// Instantiates the condition for the parser
        /// </summary>
        /// <returns>Returns the condition</returns>
        public ICondition InstantiateCondition()
        {
            Type t = Type.GetType(Condition);
            if (t != null)
            {
                ICondition condition = Activator.CreateInstance(t) as ICondition;
                return condition;
            }

            return null;
        }
    }
}
