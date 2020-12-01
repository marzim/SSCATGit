// <copyright file="ConsoleServerView.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Views
{
    using System;
    using Ncr.Core;
    using Ncr.Core.Net;
    using Ncr.Core.Util;
    using Ncr.Core.Views;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ConsoleServerView class
    /// </summary>
    public class ConsoleServerView : BaseConsoleView, IServerView
    {
        /// <summary>
        /// Interface for the server class
        /// </summary>
        private IServer _server;

        /// <summary>
        /// Initializes a new instance of the ConsoleServerView class
        /// </summary>
        /// <param name="server">the interface for the server</param>
        public ConsoleServerView(IServer server)
        {
            Server = server;
        }

        /// <summary>
        /// Gets or sets the server
        /// </summary>
        public IServer Server
        {
            get
            {
                return _server;
            }

            set
            {
                _server = value;
                _server.Serving += delegate(object sender, NcrEventArgs e)
                {
                    Console.Write(e.Message);
                };
            }
        }

        /// <summary>
        /// Gets the port
        /// </summary>
        public int Port
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Writes to the command console
        /// </summary>
        /// <param name="text">text to write</param>
        public void WriteLine(string text)
        {
            Console.WriteLine("{0} {1}", DateTimeUtility.Now(), text);
        }

        /// <summary>
        /// Writes to the command console
        /// </summary>
        /// <param name="text">text to write</param>
        public void Write(string text)
        {
            Console.Write("{0} {1}", DateTimeUtility.Now(), text);
        }

        /// <summary>
        /// Clears the logs
        /// </summary>
        public void ClearLogs()
        {
            throw new NotImplementedException();
        }
    }
}
