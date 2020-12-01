// <copyright file="RequestDispatcher.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Net
{
    using System;

    /// <summary>
    /// Initializes a new instance of the RequestDispatcher class
    /// </summary>
    public class RequestDispatcher : IRequestDispatcher
    {
        /// <summary>
        /// Request dispatcher name
        /// </summary>
        private string _name;

        /// <summary>
        /// Request to dispatch
        /// </summary>
        private Request _request;

        /// <summary>
        /// Initializes a new instance of the RequestDispatcher class
        /// </summary>
        /// <param name="name">request dispatcher name</param>
        public RequestDispatcher(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Event handler for dispatched
        /// </summary>
        public event EventHandler<ResponseEventArgs> Dispatched;

        /// <summary>
        /// Event handler for dispatching
        /// </summary>
        public event EventHandler<NcrEventArgs> Dispatching;

        /// <summary>
        /// Gets or sets the request
        /// </summary>
        public Request Request
        {
            get { return _request; }
            set { _request = value; }
        }

        /// <summary>
        /// Gets the request dispatcher name
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Event on dispatching
        /// </summary>
        /// <param name="message">dispatch message</param>
        public virtual void OnDispatching(string message)
        {
            OnDispatching(new NcrEventArgs(message));
        }

        /// <summary>
        /// Dispatch the request
        /// </summary>
        /// <param name="request">request to dispatch</param>
        public virtual void Dispatch(Request request)
        {
            this.Request = request;
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

        /// <summary>
        /// Event on dispatched
        /// </summary>
        /// <param name="response">dispatch response</param>
        protected virtual void OnDispatched(Response response)
        {
            OnDispatched(new ResponseEventArgs(response));
        }

        /// <summary>
        /// Event on dispatched
        /// </summary>
        /// <param name="e">response event arguments</param>
        protected virtual void OnDispatched(ResponseEventArgs e)
        {
            if (Dispatched != null)
            {
                Dispatched(this, e);
            }
        }
    }
}
