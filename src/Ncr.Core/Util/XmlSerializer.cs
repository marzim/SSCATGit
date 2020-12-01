// <copyright file="XmlSerializer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// Initializes a new instance of the AbstractLogger class
    /// </summary>
    /// <typeparam name="T">object to serialize or deserialize</typeparam>
    public class XmlSerializer<T>
    {
        /// <summary>
        /// Deserializes the XML document contained by the specified XMLReader.
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>The Object being deserialized.</returns>
        public T Deserialize(string filename)
        {
            return Deserialize(new StreamReader(filename));
        }

        /// <summary>
        /// Deserializes the XML document contained by the specified XMLReader.
        /// </summary>
        /// <param name="reader">The XMLReader that contains the XML document to deserialize.</param>
        /// <returns>The Object being deserialized.</returns>
        public T Deserialize(TextReader reader)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T type = (T)serializer.Deserialize(reader);
            reader.Close();
            return type;
        }

        /// <summary>
        /// Serializes the specified Object and writes the XML document to a file using the specified TextWriter and references the specified namespaces.
        /// </summary>
        /// <param name="t">The Object to serialize.</param>
        /// <returns>Returns serialized string</returns>
        public string Serialize(T t)
        {
            XmlSerializer serializer = new XmlSerializer(t.GetType());
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, t, CreateNamespace());
            return writer.ToString();
        }

        /// <summary>
        /// Serializes the specified Object and writes the XML document to a file using the specified TextWriter and references the specified namespaces.
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="t">The Object to serialize.</param>
        public void Serialize(string filename, T t)
        {
            DirectoryHelper.CreateDirectory(Path.GetDirectoryName(filename));

            XmlSerializer serializer = new XmlSerializer(t.GetType());
            using (XmlTextWriter writer = new XmlTextWriter(filename, Encoding.Unicode))
            {
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, t, CreateNamespace());
            }
        }

        /// <summary>
        /// Serializes the specified Object and writes the XML document to a file using the specified TextWriter and references the specified namespaces.
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="text">text to serialize</param>
        /// <param name="t">The Object to serialize.</param>
        public void Serialize(string filename, string text, T t)
        {
            DirectoryHelper.CreateDirectory(Path.GetDirectoryName(filename));

            XmlSerializer serializer = new XmlSerializer(t.GetType());
            using (XmlTextWriter writer = new XmlTextWriter(filename, Encoding.Unicode))
            {
                writer.Formatting = Formatting.Indented;
                writer.WriteProcessingInstruction("xml", "version='1.0' encoding='utf-16'");
                writer.WriteProcessingInstruction("xml-stylesheet", text);
                serializer.Serialize(writer, t, CreateNamespace());
                writer.Flush();
            }
        }

        /// <summary>
        /// Create namespace
        /// </summary>
        /// <returns>Returns XML serializer namespace</returns>
        private XmlSerializerNamespaces CreateNamespace()
        {
            XmlSerializerNamespaces serializerNamespaces = new XmlSerializerNamespaces();
            serializerNamespaces.Add(string.Empty, string.Empty);
            return serializerNamespaces;
        }
    }
}
