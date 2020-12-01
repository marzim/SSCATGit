// <copyright file="ISerializer.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the ISerializer class
    /// </summary>
    /// <typeparam name="T">Any object</typeparam>
    public interface ISerializer<T>
    {
        /// <summary>
        /// Serializes the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="obj">file object</param>
        void Serialize(string filename, T obj);

        /// <summary>
        /// Deserialize the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <returns>Returns the deserialized file</returns>
        T Deserialize(string filename);
    }
}
