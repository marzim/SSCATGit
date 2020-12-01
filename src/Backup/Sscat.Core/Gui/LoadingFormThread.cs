// <copyright file="LoadingFormThread.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Gui
{
    using System.Threading;

    /// <summary>
    /// Initializes a new instance of the LoadingFormThread class
    /// </summary>
    public class LoadingFormThread
    {
        /// <summary>
        /// Loading thread
        /// </summary>
        private Thread _loadingThread;

        /// <summary>
        /// Loading form
        /// </summary>
        private LoadingForm _loadingForm;

        /// <summary>
        /// Form title
        /// </summary>
        private string _title;

        /// <summary>
        /// Form message
        /// </summary>
        private string _message;

        /// <summary>
        /// Initializes a new instance of the LoadingFormThread class
        /// </summary>
        /// <param name="title">form title</param>
        /// <param name="message">form message</param>
        public LoadingFormThread(string title, string message)
        {
            _title = title;
            _message = message;
            _loadingThread = new Thread(new ThreadStart(Show));
        }

        /// <summary>
        /// Kills the loading thread
        /// </summary>
        public void Kill()
        {
            if ((_loadingThread != null) && _loadingThread.IsAlive)
            {
                _loadingThread.Interrupt();
                _loadingThread.Abort();
            }
        }

        /// <summary>
        /// Starts the loading thread
        /// </summary>
        public void Start()
        {
            _loadingThread.Start();
        }

        /// <summary>
        /// Shows the form
        /// </summary>
        private void Show()
        {
            _loadingForm = new LoadingForm(_title, _message);
            _loadingForm.ShowDialog();
        }
    }
}
