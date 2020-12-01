// <copyright file="ResponseDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;

    /// <summary>
    /// Initializes a new instance of the ResponseDispatcher class
    /// </summary>
    public class ResponseDispatcher : IResponseDispatcher
    {
        /// <summary>
        /// Response dispatcher name
        /// </summary>
        private string _name;

        /// <summary>
        /// Initializes a new instance of the ResponseDispatcher class
        /// </summary>
        /// <param name="name">response dispatcher name</param>
        public ResponseDispatcher(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Event handler for dispatching
        /// </summary>
        public event EventHandler<NcrEventArgs> Dispatching;

        /// <summary>
        /// Event handler for error dispatched
        /// </summary>
        public event EventHandler ErrorDispatched;

        /// <summary>
        /// Gets the response dispatcher name
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Dispatch the response
        /// </summary>
        /// <param name="response">response to dispatch</param>
        public virtual void Dispatch(Response response)
        {
        }

        /// <summary>
        /// Event on error dispatched
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnErrorDispatched(EventArgs e)
        {
            if (ErrorDispatched != null)
            {
                ErrorDispatched(this, e);
            }
        }

        /// <summary>
        /// Dispatch event with message
        /// </summary>
        /// <param name="message">dispatch message</param>
        protected virtual void OnDispatching(string message)
        {
            OnDispatching(new NcrEventArgs(message));
        }

        /// <summary>
        /// Event on dispatching
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnDispatching(NcrEventArgs e)
        {
            if (Dispatching != null)
            {
                Dispatching(this, e);
            }
        }
    }
}
