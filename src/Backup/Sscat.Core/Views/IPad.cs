// <copyright file="IPad.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using Ncr.Core.Views;

    /// <summary>
    /// Initializes a new instance of the IPad interface
    /// </summary>
    public interface IPad : IView
    {
        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        string Id { get; set; }
    }
}
