// <copyright file="IWorkbenchWindow.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Views
{
    /// <summary>
    /// Initializes a new instance of the IWorkbenchWindow interface
    /// </summary>
    public interface IWorkbenchWindow
    {
        /// <summary>
        /// Gets or sets the view
        /// </summary>
        IView View { get; set; }
    }
}
