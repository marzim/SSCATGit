// <copyright file="IViewFactory.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Views
{
    /// <summary>
    /// Initializes a new instance of the IViewFactory interface
    /// </summary>
    public interface IViewFactory
    {
        /// <summary>
        /// Gets the view
        /// </summary>
        /// <param name="name">view name</param>
        /// <returns>Returns the view</returns>
        IView GetView(string name);
    }
}
