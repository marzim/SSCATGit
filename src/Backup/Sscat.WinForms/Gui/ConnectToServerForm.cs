// <copyright file="ConnectToServerForm.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Gui
{
    using System;
    using Ncr.Core.Gui;
    using Ncr.Core.Util;
    using Sscat.Core.Util;
    using Sscat.Core.Views;

    /// <summary>
    /// Initializes a new instance of the ConnectToServerForm class
    /// </summary>
    public partial class ConnectToServerForm : BaseForm, IConnectToServerView
    {
        /// <summary>
        /// Initializes a new instance of the ConnectToServerForm class
        /// </summary>
        public ConnectToServerForm()
        {
            InitializeComponent();
            Text = ResourceUtility.GetString("server.connect.text", "Connect to Server");
            labelConnectToServer.Text = ResourceUtility.GetString("server.connect", "Enter IP address or server name to connect to");
            buttonOk.Text = ResourceUtility.GetString("button.ok", "OK");
            buttonCancel.Text = ResourceUtility.GetString("button.cancel", "Cancel");
            buttonConnectToLocalhost.Text = ResourceUtility.GetString("localhost.connect", "Connect to localhost");

            Connecting += new EventHandler(FormConnecting);
            Stopping += new EventHandler(FormStopping);
        }

        /// <summary>
        /// Delegate for empty event handler
        /// </summary>
        private delegate void EmptyEventHandler();

        /// <summary>
        /// Event handler for server connecting
        /// </summary>
        public event EventHandler Connecting;

        /// <summary>
        /// Event handler for stopping
        /// </summary>
        public event EventHandler Stopping;

        /// <summary>
        /// Gets the server name
        /// </summary>
        public string ServerName
        {
            get { return textBoxServerName.Text; }
        }

        /// <summary>
        /// Stops the connection
        /// </summary>
        public void Stop()
        {
            OnStopping(null);
        }

        /// <summary>
        /// Closes the view
        /// </summary>
        public override void CloseView()
        {
            if (InvokeRequired)
            {
                Invoke(new EmptyEventHandler(CloseView), new object[] { });
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// Click the connect button
        /// </summary>
        public void Connect()
        {
            ButtonOkClick(this, null);
        }

        /// <summary>
        /// Click the connect to local host button
        /// </summary>
        public void ConnectToLocalhost()
        {
            ButtonConnectToLocalhostClick(this, null);
        }

        /// <summary>
        /// Event for on stopping connection to server
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnStopping(EventArgs e)
        {
            if (Stopping != null)
            {
                Stopping(this, e);
            }
        }

        /// <summary>
        /// Event for on connecting
        /// </summary>
        /// <param name="e">event arguments</param>
        protected virtual void OnConnecting(EventArgs e)
        {
            if (Connecting != null)
            {
                Connecting(this, e);
            }
        }

        /// <summary>
        /// Event for the form stopping
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void FormStopping(object sender, EventArgs e)
        {
            LoggingService.Error("---------");

            if (this.InvokeRequired)
            {
                LoggingService.Error("InvokeRequired in FormStopping");
                this.BeginInvoke(new EventHandler(FormStopping));
            }
            else
            {
                if (this.IsDisposed || !this.IsHandleCreated)
                {
                    LoggingService.Error("Disposed or no Handle Created");
                    return;
                }

                LoggingService.Error("Control Changed");
                textBoxServerName.Enabled = buttonOk.Enabled = buttonCancel.Enabled = buttonConnectToLocalhost.Enabled = true;
            }
        }

        /// <summary>
        /// Event for the form connecting
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void FormConnecting(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                LoggingService.Error("Invoke required in FormConnecting");
                Invoke(new EventHandler(FormConnecting), new object[] { sender, e });
            }
            else
            {
                textBoxServerName.Enabled = buttonOk.Enabled = buttonCancel.Enabled = buttonConnectToLocalhost.Enabled = false;
            }
        }

        /// <summary>
        /// Event for clicking the connect to local host button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonConnectToLocalhostClick(object sender, EventArgs e)
        {
            textBoxServerName.Text = "localhost";
            buttonOk.PerformClick();
        }

        /// <summary>
        /// Event for clicking the connection button
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void ButtonOkClick(object sender, EventArgs e)
        {
            OnConnecting(e);
        }
    }
}
