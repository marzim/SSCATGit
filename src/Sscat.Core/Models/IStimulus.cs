// <copyright file="IStimulus.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    /// <summary>
    /// Initializes a new instance of the IStimulus interface
    /// </summary>
    public interface IStimulus
    {
        /// <summary>
        /// Gets a value indicating whether event is a stimulus
        /// </summary>
        bool IsStimulus { get; }
    }
}
