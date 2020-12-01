// <copyright file="Response.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the Response class
    /// </summary>
    [XmlRoot("Response"), Serializable()]
    public class Response : BaseModel<Response>, IDisposable
    {
        /// <summary>
        /// Response type
        /// </summary>
        private string _type;

        /// <summary>
        /// Response notes
        /// </summary>
        private string _notes;

        /// <summary>
        /// Response client
        /// </summary>
        private string _client;

        /// <summary>
        /// Response content
        /// </summary>
        private IContent _content;

        /// <summary>
        /// Initializes a new instance of the Response class
        /// </summary>
        public Response()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Response class
        /// </summary>
        /// <param name="type">response type</param>
        /// <param name="content">response content</param>
        public Response(string type, IContent content)
            : this(type, content, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Response class
        /// </summary>
        /// <param name="type">response type</param>
        /// <param name="content">response content</param>
        /// <param name="notes">response notes</param>
        public Response(string type, IContent content, string notes)
        {
            Type = type;
            Content = content;
            Notes = notes;
        }

        /// <summary>
        /// Gets or sets the response content
        /// </summary>
        public IContent Content
        {
            get { return _content; }
            set { _content = value; }
        }

        /// <summary>
        /// Gets or sets the response client
        /// </summary>
        [XmlIgnore]
        public string Client
        {
            get { return _client; }
            set { _client = value; }
        }

        /// <summary>
        /// Gets or sets the response  notes
        /// </summary>
        [XmlElement("Notes")]
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        /// <summary>
        /// Gets or sets the response type
        /// </summary>
        [XmlAttribute("Type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Clears the response content
        /// </summary>
        public void Clear()
        {
            Content.Dispose();
        }

        /// <summary>
        /// Disposes of the response content
        /// </summary>
        public override void Dispose()
        {
            Clear();
        }

        /// <summary>
        /// Validate the response type and content
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            AddErrorIf("Response type should not be null", _type == null);
            AddErrorIf("Content should not be null", _content == null);
        }
    }
}
