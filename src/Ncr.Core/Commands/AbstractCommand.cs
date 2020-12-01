// <copyright file="AbstractCommand.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Commands
{
    using System;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the AbstractCommand class
    /// </summary>
    public abstract class AbstractCommand : BaseModel<AbstractCommand>, ICommand
    {
        /// <summary>
        /// Command owner
        /// </summary>
        private object _owner;

        /// <summary>
        /// Initializes a new instance of the AbstractCommand class
        /// </summary>
        public AbstractCommand()
        {
        }

        /// <summary>
        /// Event handler for running command
        /// </summary>
        public event EventHandler<NcrEventArgs> Running;

        /// <summary>
        /// Gets a value indicating whether or not command is checked
        /// </summary>
        public virtual bool Checked
        {
            get { return false; }
        }

        /// <summary>
        /// Gets a value indicating whether or not command can run
        /// </summary>
        public virtual bool CanRun
        {
            get { return true; }
        }

        /// <summary>
        /// Gets or sets the command owner
        /// </summary>
        public object Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        /// <summary>
        /// Run the command
        /// </summary>
        public abstract void Run();

        /// <summary>
        /// On running command
        /// </summary>
        /// <param name="message">message to send</param>
        protected virtual void OnRunning(string message)
        {
            OnRunning(new NcrEventArgs(message));
        }

        /// <summary>
        /// Event for on running command
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnRunning(NcrEventArgs e)
        {
            if (Running != null)
            {
                Running(this, e);
            }
        }
    }
}
