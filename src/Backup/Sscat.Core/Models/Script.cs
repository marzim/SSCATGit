// <copyright file="Script.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the Script class
    /// </summary>
    [XmlRoot("Script"), Serializable()]
    public class Script : AbstractScript<Script>, IScript
    {
        /// <summary>
        /// Initializes a new instance of the Script class
        /// </summary>
        public Script()
        {
        }

        /// <summary>
        /// Gets or sets the script result
        /// </summary>
        [XmlElement("Result")]
        public override Result Result
        {
            get { return base.Result; }
            set { base.Result = value; }
        }
        
        /// <summary>
        /// Gets or sets the script index
        /// </summary>
        [XmlAttribute("Index")]
        public override int Index
        {
            get { return base.Index; }
            set { base.Index = value; }
        }

        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        [XmlAttribute("FileName")]
        public override string FileName
        {
            get { return base.FileName; }
            set { base.FileName = value; }
        }

        /// <summary>
        /// Gets or sets the script events
        /// </summary>
        [XmlElement("Events")]
        public override ScriptEvents Events
        {
            get { return base.Events; }
            set { base.Events = value; }
        }

        /// <summary>
        /// Gets or sets the SSCAT version
        /// </summary>
        [XmlAttribute("SscatVersion")]
        public override string SscatVersion
        {
            get { return base.SscatVersion; }
            set { base.SscatVersion = value; }
        }

        /// <summary>
        /// Gets or sets the SSCO version
        /// </summary>
        [XmlAttribute("SscoVersion")]
        public override string SscoVersion
        {
            get { return base.SscoVersion; }
            set { base.SscoVersion = value; }
        }

        /// <summary>
        /// Gets or sets the date time
        /// </summary>
        [XmlAttribute("DateTime")]
        public override string DateTime
        {
            get { return base.DateTime; }
            set { base.DateTime = value; }
        }

        /// <summary>
        /// Gets or sets the version
        /// </summary>
        [XmlAttribute("Version")]
        public override string Version
        {
            get { return base.Version; }
            set { base.Version = value; }
        }

        /// <summary>
        /// Gets or sets the script description
        /// </summary>
        [XmlAttribute("Description")]
        public override string Description
        {
            get { return base.Description; }
            set { base.Description = value; }
        }

        /// <summary>
        /// Gets or sets the script name
        /// </summary>
        [XmlAttribute("Name")]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        /// <summary>
        /// Deserializes the script
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the deserialized script</returns>
        public static new Script Deserialize(string filename)
        {
            Script script = Deserialize(new StreamReader(filename));
            script.FileName = filename;
            return script;
        }

        /// <summary>
        /// Deserializes the script
        /// </summary>
        /// <param name="reader">text reader</param>
        /// <returns>Returns the deserialized script</returns>
        public static new Script Deserialize(TextReader reader)
        {
            Script script = BaseSerializable<Script>.Deserialize(reader);
            return script;
        }
    }
}
