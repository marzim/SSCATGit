// <copyright file="BaseXmlRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories
{
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the BaseXmlRepository class
    /// </summary>
    /// <typeparam name="T">Base repository</typeparam>
    public class BaseXmlRepository<T> : BaseRepository, IXmlRepository
    {
        /// <summary>
        /// XML Serializer
        /// </summary>
        private XmlSerializer<T> _serializer;

        /// <summary>
        /// Initializes a new instance of the BaseXmlRepository class
        /// </summary>
        public BaseXmlRepository()
        {
            _serializer = new XmlSerializer<T>();
        }

        /// <summary>
        /// Gets or sets the serializer
        /// </summary>
        protected XmlSerializer<T> Serializer
        {
            get { return _serializer; }
            set { _serializer = value; }
        }

        /// <summary>
        /// Serializes the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="t">Base repository</param>
        public void Serialize(string filename, T t)
        {
            _serializer.Serialize(filename, t);
        }

        /// <summary>
        /// Serializes the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="text">text to serialize</param>
        /// <param name="t">Base repository</param>
        public void Serialize(string filename, string text, T t)
        {
            _serializer.Serialize(filename, text, t);
        }

        /// <summary>
        /// Deserializes the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the base repository</returns>
        public T Deserialize(string filename)
        {
            return _serializer.Deserialize(filename);
        }
    }
}
