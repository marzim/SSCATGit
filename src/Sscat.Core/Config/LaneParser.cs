// <copyright file="LaneParser.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using Ncr.Core.Util;
    using Sscat.Core.Parsers;

    /// <summary>
    /// Initializes a new instance of the LaneParser class
    /// </summary>
    [XmlRoot("Parser")]
    public class LaneParser
    {
        /// <summary>
        /// Lane parser patterns
        /// </summary>
        private LaneParserPattern[] _patterns;

        /// <summary>
        /// Lane parser name
        /// </summary>
        private string _name;
        
        /// <summary>
        /// Lane parser file
        /// </summary>
        private string _file;

        /// <summary>
        /// Lane parser text
        /// </summary>
        private string _text;

        /// <summary>
        /// Lane parser condition
        /// </summary>
        private string _condition;

        /// <summary>
        /// Lane parser binary
        /// </summary>
        private bool _binary;

        /// <summary>
        /// Lane parser dynamic file name
        /// </summary>
        private string _dynamicFileName;

        /// <summary>
        /// Gets or sets the lane parser dynamic file name
        /// </summary>
        [XmlAttribute("DynamicFileName")]
        public string DynamicFileName
        {
            get { return _dynamicFileName; }
            set { _dynamicFileName = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the lane parser has a dynamic file name
        /// </summary>
        public bool HasDynamicFileName
        {
            get { return DynamicFileName != null && DynamicFileName != string.Empty; }
        }

        /// <summary>
        /// Gets a value indicating whether the lane parser has a condition
        /// </summary>
        public bool HasCondition
        {
            get
            {
                return Condition != null && Condition != string.Empty;
            }
        }

        /// <summary>
        /// Gets or sets the lane parser condition
        /// </summary>
        [XmlAttribute("Condition")]
        public string Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }

        /// <summary>
        /// Gets or sets the lane parser text
        /// </summary>
        [XmlAttribute("Text")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// Gets or sets the lane parser file
        /// </summary>
        [XmlAttribute("File")]
        public string File
        {
            get { return _file; }
            set { _file = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the lane parser is Binary
        /// </summary>
        [XmlAttribute("Binary")]
        public bool Binary
        {
            get { return _binary; }
            set { _binary = value; }
        }
        
        /// <summary>
        /// Gets a value indicating whether the lane parser has a file
        /// </summary>
        public bool HasFile
        {
            get { return File != null && !string.IsNullOrEmpty(File); }
        }

        /// <summary>
        /// Gets a value indicating whether the lane parser is binary
        /// </summary>
        public bool IsBinary
        {
            get { return Binary ? true : false; }
        }

        /// <summary>
        /// Gets or sets the lane parser patterns
        /// </summary>
        [XmlElement("Pattern")]
        public LaneParserPattern[] Patterns
        {
            get
            {
                if (_patterns != null)
                {
                    return _patterns;
                }

                return new LaneParserPattern[] { };
            }

            set
            {
                _patterns = value;
            }
        }

        /// <summary>
        /// Gets or sets the lane parser name
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Instantiates the lane parser
        /// </summary>
        /// <returns>Returns a null parser</returns>
        public IParser Instantiate()
        {
            return Instantiate(null);
        }

        /// <summary>
        /// Gets the file name
        /// </summary>
        /// <returns>Returns the file name</returns>
        public string GetFileName()
        {
            return GetFileName(string.Empty);
        }

        /// <summary>
        /// Gets the file name
        /// </summary>
        /// <param name="isGenerateFromDiag">whether script generation is from a diag</param>
        /// <returns>Returns the file name</returns>
        public string GetFileName(bool isGenerateFromDiag)
        {
            if (isGenerateFromDiag)
            {
                return GetFileName(Path.GetDirectoryName(File));
            }
            else
            {
                return GetFileName(string.Empty);
            }
        }

        /// <summary>
        /// Gets the file name
        /// </summary>
        /// <param name="dir">file directory</param>
        /// <returns>Returns the file name</returns>
        public string GetFileName(string dir)
        {
            if (HasDynamicFileName)
            {
                return InstantiateDynamicFileName(dir).FileName;
            }
            else
            {
                return File;
            }
        }

        /// <summary>
        /// Instantiates the parser
        /// </summary>
        /// <param name="reader">Extended text reader</param>
        /// <returns>Returns the parser</returns>
        public IParser Instantiate(IExtendedTextReader reader)
        {
            List<IParserPattern> pp = new List<IParserPattern>();
            foreach (LaneParserPattern p in Patterns)
            {
                if (p.Enabled && (!p.HasCondition || (p.HasCondition && p.InstantiateCondition().Check(string.Empty))))
                {
                    pp.Add(new ParserPattern(p.Value, p.EventValue, p.InstantiateAdder()));
                }

                if ((reader == null) && !p.Enabled && p.Error && (!p.HasCondition || (p.HasCondition && p.InstantiateCondition().Check(string.Empty))))
                {
                    pp.Add(new ParserPattern(p.Value, p.EventValue, p.InstantiateAdder()));
                }                
            }

            return new EventParser(Name, _file, reader, pp.ToArray());
        }

        /// <summary>
        /// Instantiates the binary parser
        /// </summary>
        /// <param name="stream">File stream</param>
        /// <returns>Returns the parser</returns>
        public IParser InstantiateBinary(FileStream stream)
        {
            return new EventParser(Name, stream);
        }

        /// <summary>
        /// Instantiates the dynamic file name
        /// </summary>
        /// <param name="dir">file directory</param>
        /// <returns>Returns the file</returns>
        public IDynamicFileName InstantiateDynamicFileName(string dir)
        {
            Type t = Type.GetType(DynamicFileName);
            if (t != null)
            {
                IDynamicFileName d = Activator.CreateInstance(t) as IDynamicFileName;
                d.Directory = dir;
                return d;
            }

            return null;
        }

        /// <summary>
        /// Instantiates the parser condition
        /// </summary>
        /// <param name="pathName">path name</param>
        /// <returns>Returns the condition</returns>
        public ICondition InstantiateCondition(string pathName)
        {
            Type t = Type.GetType(Condition);
            if (t != null)
            {
                ICondition condition = Activator.CreateInstance(t) as ICondition;
                IPath path = condition as IPath;
                if (path != null)
                {
                    path.PathName = pathName;
                }

                return condition;
            }

            return null;
        }

        /// <summary>
        /// Overrides the to string method with the lane parser name
        /// </summary>
        /// <returns>Returns parser name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
