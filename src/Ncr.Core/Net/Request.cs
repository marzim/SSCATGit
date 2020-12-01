// <copyright file="Request.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the Request class
    /// </summary>
    [XmlRoot("Request"), Serializable]
    public class Request : BaseModel<Request>, IDisposable
    {
        /// <summary>
        /// Request type
        /// </summary>
        private string _type;

        /// <summary>
        /// Request client
        /// </summary>
        private string _client;

        /// <summary>
        /// Request content
        /// </summary>
        private IContent _content;

        /// <summary>
        /// Initializes a new instance of the Request class
        /// </summary>
        public Request()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Request class
        /// </summary>
        /// <param name="type">request type</param>
        /// <param name="content">request content</param>
        public Request(string type, IContent content)
        {
            Type = type;
            Content = content;
        }

        /// <summary>
        /// Gets or sets the content
        /// </summary>
        public IContent Content
        {
            get { return _content; }
            set { _content = value; }
        }

        /// <summary>
        /// Gets or sets the client
        /// </summary>
        [XmlAttribute("Client")]
        public string Client
        {
            get { return _client; }
            set { _client = value; }
        }
        
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        [XmlAttribute("Type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Create response
        /// </summary>
        /// <param name="type">response type</param>
        /// <param name="content">response content</param>
        /// <returns>Returns the response</returns>
        public Response CreateResponse(string type, string content)
        {
            return CreateResponse(type, content, string.Empty);
        }

        /// <summary>
        /// Create response
        /// </summary>
        /// <param name="type">response type</param>
        /// <param name="content">response content</param>
        /// <param name="notes">response notes</param>
        /// <returns>Returns the response</returns>
        public Response CreateResponse(string type, string content, string notes)
        {
            return CreateResponse(type, new MessageContent(content), notes);
        }

        /// <summary>
        /// Create response
        /// </summary>
        /// <param name="type">response type</param>
        /// <param name="content">response content</param>
        /// <param name="notes">response notes</param>
        /// <returns>Returns the response</returns>
        public Response CreateResponse(string type, IContent content, string notes)
        {
            Response r = new Response(type, content, notes);
            r.Client = _client;
            return r;
        }

        /// <summary>
        /// Create response
        /// </summary>
        /// <param name="type">response type</param>
        /// <param name="content">response content</param>
        /// <returns>Returns the response</returns>
        public Response CreateResponse(string type, IContent content)
        {
            return CreateResponse(type, content, string.Empty);
        }

        /// <summary>
        /// Clear the content
        /// </summary>
        public void Clear()
        {
            Content.Dispose();
        }

        /// <summary>
        /// Dispose of the content
        /// </summary>
        public override void Dispose()
        {
            Clear();
        }
    }
}
