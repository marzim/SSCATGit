// <copyright file="LaneParsers.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the LaneParsers class
    /// </summary>
    public class LaneParsers
    {
        /// <summary>
        /// Lane parsers
        /// </summary>
        private LaneParser[] _parsers;

        /// <summary>
        /// Gets or sets the lane parsers
        /// </summary>
        [XmlElement("Parser")]
        public LaneParser[] Parsers
        {
            get { return _parsers; }
            set { _parsers = value; }
        }

        /// <summary>
        /// Gets a parser by name
        /// </summary>
        /// <param name="name">name of parser</param>
        /// <returns>Returns the parser</returns>
        public LaneParser GetParser(string name)
        {
            foreach (LaneParser parser in Parsers)
            {
                if (parser.Name == name)
                {
                    return parser;
                }
            }

            return null;
        }
    }
}
