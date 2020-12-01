// <copyright file="BaseModel.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Models
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Util;
    
    /// <summary>
    /// Initializes a new instance of the BaseModel class
    /// </summary>
    /// <typeparam name="T">Base Serializable</typeparam>
    [Serializable]
    public class BaseModel<T> : BaseSerializable<T>, IBaseModel
    {
        /// <summary>
        /// Error message collection
        /// </summary>
        private ErrorMessageCollection _errors = new ErrorMessageCollection();

        /// <summary>
        /// Initializes a new instance of the BaseModel class
        /// </summary>
        public BaseModel()
        {
        }

        /// <summary>
        /// Gets a value indicating whether or not there are errors
        /// </summary>
        public bool HasErrors
        {
            get { return _errors.Count > 0; }
        }

        /// <summary>
        /// Gets the errors
        /// </summary>
        [XmlIgnoreAttribute]
        public ErrorMessageCollection Errors
        {
            get { return _errors; }
        }

        /// <summary>
        /// Clears the errors
        /// </summary>
        public virtual void Validate()
        {
            Errors.Clear();
        }

        /// <summary>
        /// Validates the models if condition is met
        /// </summary>
        /// <param name="model">base model</param>
        /// <param name="condition">validation condition</param>
        public virtual void ValidateIf(IBaseModel model, bool condition)
        {
            if (condition)
            {
                model.Validate();
                Errors.AddRange(model.Errors);
            }
        }

        /// <summary>
        /// Add error if condition is met
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="condition">validation condition</param>
        public void AddErrorIf(string message, bool condition)
        {
            if (condition)
            {
                Errors.Add(new ErrorMessage(message));
                LoggingService.Error(message);
            }
        }

        /// <summary>
        /// Calls the ToString method on the base model
        /// </summary>
        /// <returns>Returns the formatted string</returns>
        public virtual string ToRepresentation()
        {
            return ToString();
        }
    }
}
