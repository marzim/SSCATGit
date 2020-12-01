// <copyright file="IBaseSerializable.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Models
{
    /// <summary>
    /// Initializes a new instance of the IBaseSerializable interface
    /// </summary>
    public interface IBaseSerializable
    {
        /// <summary>
        /// XML serializer
        /// </summary>
        /// <returns>Returns the serialized writer</returns>
        string Serialize();

        /// <summary>
        /// XML serializer for the file
        /// </summary>
        /// <param name="filename">file name</param>
        void Serialize(string filename);

        /// <summary>
        /// XML serializer for the file
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="text">text to write</param>
        void Serialize(string filename, string text);
    }
}
