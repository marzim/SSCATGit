// <copyright file="BaseSerializable.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Models
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the BaseSerializable class
    /// </summary>
    /// <typeparam name="T">base serializable</typeparam>
    [Serializable]
    public class BaseSerializable<T> : IBaseSerializable, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the BaseSerializable class
        /// </summary>
        public BaseSerializable()
        {
        }

        /// <summary>
        /// Deserializes the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the deserialized file</returns>
        public static T Deserialize(string filename)
        {
            return Deserialize(new StreamReader(filename));
        }

        /// <summary>
        /// Deserializes the text reader
        /// </summary>
        /// <param name="reader">text reader</param>
        /// <returns>Returns the deserialized text reader</returns>
        public static T Deserialize(TextReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T type = (T)serializer.Deserialize(reader);
            reader.Close();
            return type;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public virtual void Dispose()
        {
        }

        /// <summary>
        /// XML serializer
        /// </summary>
        /// <returns>Returns the serialized writer</returns>
        public string Serialize()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, this, CreateNamespace());
            return writer.ToString();
        }

        /// <summary>
        /// XML serializer for the file
        /// </summary>
        /// <param name="filename">file name</param>
        public void Serialize(string filename)
        {
            DirectoryHelper.CreateDirectory(Path.GetDirectoryName(filename));

            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (XmlTextWriter writer = new XmlTextWriter(filename, Encoding.Unicode))
            {
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, this, CreateNamespace());
                writer.Flush();
            }
        }

        /// <summary>
        /// XML serializer for the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="text">text to write</param>
        public void Serialize(string filename, string text)
        {
            DirectoryHelper.CreateDirectory(Path.GetDirectoryName(filename));

            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (XmlTextWriter writer = new XmlTextWriter(filename, Encoding.Unicode))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteProcessingInstruction("xml", "version='1.0' encoding='utf-16'");
                writer.WriteProcessingInstruction("xml-stylesheet", text);
                serializer.Serialize(writer, this, CreateNamespace());
                writer.Flush();
            }
        }

        /// <summary>
        /// Create the XML serializer namespace
        /// </summary>
        /// <returns>Returns the xml serializer namespace</returns>
        private XmlSerializerNamespaces CreateNamespace()
        {
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);
            return xmlSerializerNamespaces;
        }
    }
}
