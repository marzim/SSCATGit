// <copyright file="EmulatorEventArgs.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;

    /// <summary>
    /// Initializes a new instance of the EmulatorEventArgs class
    /// </summary>
    public class EmulatorEventArgs : EventArgs
    {
        /// <summary>
        /// Event emulator
        /// </summary>
        private Emulator _emulator;

        /// <summary>
        /// Emulator message
        /// </summary>
        private string _message;

        /// <summary>
        /// Initializes a new instance of the EmulatorEventArgs class
        /// </summary>
        /// <param name="message">event message</param>
        public EmulatorEventArgs(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the EmulatorEventArgs class
        /// </summary>
        /// <param name="emulator">event emulator</param>
        public EmulatorEventArgs(Emulator emulator)
        {
            Emulator = emulator;
        }

        /// <summary>
        /// Gets or sets the emulator
        /// </summary>
        public Emulator Emulator
        {
            get { return _emulator; }
            set { _emulator = value; }
        }

        /// <summary>
        /// Gets or sets the message
        /// </summary>
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
