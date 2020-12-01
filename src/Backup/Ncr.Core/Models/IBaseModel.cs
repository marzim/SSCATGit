// <copyright file="IBaseModel.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Models
{
    /// <summary>
    /// Initializes a new instance of the IBaseModel interface
    /// </summary>
    public interface IBaseModel : IBaseSerializable
    {
        /// <summary>
        /// Gets the errors
        /// </summary>
        ErrorMessageCollection Errors { get; }

        /// <summary>
        /// Gets a value indicating whether or not there are errors
        /// </summary>
        bool HasErrors { get; }

        /// <summary>
        /// Clears the errors
        /// </summary>
        void Validate();

        /// <summary>
        /// Validates the models if condition is met
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="condition">validation condition</param>
        void AddErrorIf(string message, bool condition);

        /// <summary>
        /// Calls the ToString method on the base model
        /// </summary>
        /// <returns>Returns the formatted string</returns>
        string ToRepresentation();
    }
}
