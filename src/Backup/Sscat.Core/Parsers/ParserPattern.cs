// <copyright file="ParserPattern.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ParserPattern class
    /// </summary>
    public class ParserPattern : IParserPattern
    {
        /// <summary>
        /// Parser pattern
        /// </summary>
        private string _pattern;

        /// <summary>
        /// Event value
        /// </summary>
        private string _eventValue;

        /// <summary>
        /// Event adder
        /// </summary>
        private IEventAdder _eventAdder;

        /// <summary>
        /// Initializes a new instance of the ParserPattern class
        /// </summary>
        /// <param name="pattern">parser pattern</param>
        /// <param name="adder">event adder</param>
        public ParserPattern(string pattern, IEventAdder adder)
        {
            Pattern = pattern;
            _eventAdder = adder;
        }

        /// <summary>
        /// Initializes a new instance of the ParserPattern class
        /// </summary>
        /// <param name="pattern">parser pattern</param>
        /// <param name="eventValue">event value</param>
        /// <param name="adder">event adder</param>
        public ParserPattern(string pattern, string eventValue, IEventAdder adder)
        {
            Pattern = pattern;
            _eventAdder = adder;
            EventValue = eventValue;
        }

        /// <summary>
        /// Gets or sets the pattern
        /// </summary>
        public string Pattern
        {
            get { return _pattern; }
            set { _pattern = value; }
        }

        /// <summary>
        /// Gets the event value
        /// </summary>
        public string EventValue
        {
            get
            {
                return _eventValue;
            }

            private set
            {
                _eventValue = value;
            }
        }

        /// <summary>
        /// Checks match by the given line
        /// </summary>
        /// <param name="line">line to check</param>
        /// <returns>Returns match if found</returns>
        public Match Match(string line)
        {
            return Regex.Match(line, Pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Adds the event
        /// </summary>
        /// <param name="line">line to check</param>
        /// <param name="match">match to check</param>
        /// <param name="reader">extended text reader</param>
        /// <param name="events">script events</param>
        /// <param name="eventValue">event value</param>
        public void Add(string line, Match match, IExtendedTextReader reader, List<IScriptEvent> events, string eventValue)
        {
            _eventAdder.Add(line, match, reader, events, eventValue);
        }

        /// <summary>
        /// Formats ToString method for the parser patterns to include pattern and event adder
        /// </summary>
        /// <returns>Returns the formatted string</returns>
        public override string ToString()
        {
            return string.Format("[Pattern={0}, Adder={1}]", Pattern, _eventAdder);
        }
    }
}
