// <copyright file="ConsoleAboutView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Views
{
    using System;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ConsoleAboutView class
    /// </summary>
    public class ConsoleAboutView : IAboutView
    {
        /// <summary>
        /// Initializes a new instance of the ConsoleAboutView class
        /// </summary>
        public ConsoleAboutView()
        {
            Console.WriteLine("SSCAT 3.0"); 
        }

        /// <summary>
        /// Gets the handle
        /// </summary>
        public IntPtr Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
