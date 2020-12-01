// <copyright file="IConnectToServerView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Views
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Initializes a new instance of the IConnectToServerView interface
    /// </summary>
    public interface IConnectToServerView : IDisposable, IWin32Window
    {
        /// <summary>
        /// Event handler for connecting
        /// </summary>
        event EventHandler Connecting;

        /// <summary>
        /// Gets the server name
        /// </summary>
        string ServerName { get; }

        /// <summary>
        /// Show the dialog
        /// </summary>
        /// <returns>Returns the dialog result</returns>
        DialogResult ShowDialog();

        /// <summary>
        /// Show the dialog
        /// </summary>
        /// <param name="owner">windows 32 owner</param>
        /// <returns>Returns the dialog result</returns>
        DialogResult ShowDialog(IWin32Window owner);

        /// <summary>
        /// Close view
        /// </summary>
        void CloseView();

        /// <summary>
        /// Stop connection
        /// </summary>
        void Stop();
    }
}
