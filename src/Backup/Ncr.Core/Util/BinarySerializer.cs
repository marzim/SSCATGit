// <copyright file="BinarySerializer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Util
{
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Initializes a new instance of the BinarySerializer class
    /// </summary>
    /// <typeparam name="T">Serializer interface</typeparam>
    public class BinarySerializer<T> : ISerializer<T>
    {
        /// <summary>
        /// Serializes the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="obj">file object</param>
        public void Serialize(string filename, T obj)
        {
            DirectoryHelper.CreateDirectory(Path.GetDirectoryName(filename));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, obj);
            }
        }

        /// <summary>
        /// Deserialize the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the deserialized file</returns>
        public T Deserialize(string filename)
        {
            T t = default(T);
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                t = (T)formatter.Deserialize(fs);
            }

            return t;
        }
    }
}
