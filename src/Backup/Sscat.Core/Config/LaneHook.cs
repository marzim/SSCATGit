// <copyright file="LaneHook.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using Sscat.Core.Parsers;

    /// <summary>
    /// Initializes a new instance of the LaneHook class
    /// </summary>
    public class LaneHook
    {
        /// <summary>
        /// Lane hook name
        /// </summary>
        private string _name;

        /// <summary>
        /// Lane hook file
        /// </summary>
        private string _file;

        /// <summary>
        /// Lane hook parser
        /// </summary>
        private string _parser;

        /// <summary>
        /// Lane hook text
        /// </summary>
        private string _text;

        /// <summary>
        /// Lane hook dynamic file name
        /// </summary>
        private string _dynamicFileName;

        /// <summary>
        /// Gets or sets the dynamic file name
        /// </summary>
        [XmlAttribute("DynamicFileName")]
        public string DynamicFileName
        {
            get { return _dynamicFileName; }
            set { _dynamicFileName = value; }
        }

        /// <summary>
        /// Gets or sets the lane hook text
        /// </summary>
        [XmlAttribute("Text")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// Gets or sets the lane hook parser
        /// </summary>
        [XmlAttribute("Parser")]
        public string Parser
        {
            get { return _parser; }
            set { _parser = value; }
        }

        /// <summary>
        /// Gets or sets the lane hook file
        /// </summary>
        [XmlAttribute("File")]
        public string File
        {
            get { return _file; }
            set { _file = value; }
        }

        /// <summary>
        /// Gets or sets the lane name 
        /// </summary>
        [XmlAttribute("Name")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the lane hook has a dynamic file name
        /// </summary>
        public bool HasDynamicFileName
        {
            get { return DynamicFileName != null && DynamicFileName != string.Empty; }
        }

        /// <summary>
        /// Gets a value indicating whether the lane hook has a file
        /// </summary>
        public bool HasFile
        {
            get { return File != null && !File.Equals(string.Empty); }
        }

        /// <summary>
        /// Gets the file name
        /// </summary>
        /// <returns>Returns the file name</returns>
        public string GetFileName()
        {
            if (HasDynamicFileName)
            {
                return InstantiateDynamicFileName().FileName;
            }
            else
            {
                return File;
            }
        }

        /// <summary>
        /// Instantiates the dynamic file name
        /// </summary>
        /// <returns>Returns the dynamic file name</returns>
        public IDynamicFileName InstantiateDynamicFileName()
        {
            Type t = Type.GetType(DynamicFileName);
            if (t != null)
            {
                return Activator.CreateInstance(t) as IDynamicFileName;
            }

            return null;
        }
    }
}
