// <copyright file="NextGenUITestClient.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events.UIAutoTest
{
    using System;
    using System.ServiceModel;
    using System.Threading;
    using Ncr.Core.Util;
    using TestAutomationCommon;
    using TestAutomationCommon.Interfaces;

    /// <summary>
    /// Creates a singleton NGUI test client
    /// </summary>
    internal class NextGenUITestClient : INextGenUITestClient
    {
        /// <summary>
        /// The singleton instance
        /// </summary>
        private static Lazy<INextGenUITestClient> __instance =
            new Lazy<INextGenUITestClient>(() => new NextGenUITestClient());

        /// <summary>
        /// Whether or not the SSCAT client is connected to NGUI test server
        /// </summary>
        private bool _connected = false;

        /// <summary>
        /// The test contract channel
        /// </summary>
        private ITestContract _channel;

        /// <summary>
        /// test events
        /// </summary>
        private TestEvents _testEvents = new TestEvents();

        /// <summary>
        /// current context
        /// </summary>
        private string _currentContext = string.Empty;

        /// <summary>
        /// Prevents a default instance of the NextGenUITestClient class from being created.
        /// </summary>
        private NextGenUITestClient()
        {
            _testEvents.UpdateContext += _testEvents_UpdateContext;

            TestEvents.AutoTestRespondedEvent = new ManualResetEvent(false);
            TestEvents.EnterPasswordReadyEvent = new ManualResetEvent(false);
        }

        /// <summary>
        /// Event handler for the update context event
        /// </summary>
        public event EventHandler<EventArgs> OnUpdateContext;

        /// <summary>
        /// Gets the singleton instance
        /// </summary>
        public static INextGenUITestClient Instance
        {
            get
            {
                return __instance.Value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the test client is connected
        /// </summary>
        public bool Connected
        {
            get
            {
                return _connected;
            }

            private set
            {
                _connected = value;

                if (!value)
                {
                    TestEvents.ResetContext();
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of the Current Context
        /// </summary>
        public string CurrentContext
        {
            get
            {
                return _currentContext;
            }

            set
            {
                _currentContext = value;
            }
        }

        /// <summary>
        /// Normal button click event
        /// </summary>
        /// <param name="buttonName">name of the button</param>
        /// <param name="contextName">name of the context</param>
        /// <param name="buttonID">button ID</param>
        public void ClickButton(string buttonName, string contextName, string buttonID = "")
        {
            CheckIfConnected();

            string exceptionMessage = string.Format("ClickButton: [{0}] Context: [{1}]", buttonName, TestEvents.CurrentContext);

            if (SSCOHelper.IsSSCOType("Walmart") && contextName.Equals("ChicoAttract"))
            {
                contextName = TestEvents.CurrentContext;
                LoggingService.Info("[Walmart Attract] [UI] ButtonClick: Button={0} Context={1}", buttonName, contextName);
            }

            CallTestFunction(() => { _channel.ClickButton(buttonName, buttonID); }, contextName, exceptionMessage);
        }

        /// <summary>
        /// Normal button click event
        /// </summary>
        /// <param name="buttonName">name of the button</param>
        /// <param name="contextName">name of the context</param>
        /// <param name="buttonID">button ID</param>
        public void SmartExitClickButton(string buttonName, string contextName, string buttonID = "")
        {
            CheckIfConnected();

            string exceptionMessage = string.Format("[SmartExit] ClickButton: [{0}] Context: [{1}]", buttonName, contextName);
            LoggingService.Info(exceptionMessage);

            CallTestFunction(() => { _channel.ClickButton(buttonName, buttonID); }, contextName, exceptionMessage);
        }

        /// <summary>
        /// Category button click event
        /// </summary>
        /// <param name="controlName">name of the control</param>
        /// <param name="index">button index</param>
        /// <param name="contextName">name of the context</param>
        public void ClickCategory(string controlName, string index, string contextName)
        {
            CheckIfConnected();

            int categoryIndex;

            if (!int.TryParse(index, out categoryIndex))
            {
                throw new ArgumentException(string.Format("Index: [{0}] must be a number", index), "index");
            }

            string exceptionMessage = string.Format("ClickCategory: [{0}] [{1}] Context: [{2}]", controlName, index, TestEvents.CurrentContext);

            CallTestFunction(() => { _channel.ClickCategory(controlName, categoryIndex); }, contextName, exceptionMessage);
        }

        /// <summary>
        /// Sliding grid page button click
        /// </summary>
        /// <param name="controlName">name of the control</param>
        /// <param name="index">grid page item index</param>
        /// <param name="buttonData">button data</param>
        /// <param name="contextName">name of the context</param>
        public void ClickSlidingGridPage(string controlName, string index, string buttonData, string contextName)
        {
            CheckIfConnected();

            int gridPageIndex;

            if (!int.TryParse(index, out gridPageIndex))
            {
                throw new ArgumentException(string.Format("Index: [{0}] must be a number", index), "index");
            }

            string exceptionMessage = string.Format("ClickSlidingGridPage: [{0}] [{1}] Context: [{2}]", controlName, index, TestEvents.CurrentContext);

            CallTestFunction(() => { _channel.ClickSlidingGridPage(controlName, gridPageIndex, buttonData); }, contextName, exceptionMessage);
        }

        /// <summary>
        /// Checks to see if test client is still connected
        /// </summary>
        public void CheckConnection()
        {
            CheckIfConnected();
        }

        /// <summary>
        /// Keyboard button click event
        /// </summary>
        /// <param name="buttonName">name of the button</param>
        /// <param name="buttonData">button data</param>
        /// <param name="contextName">name of the context</param>
        public void ClickKeyboardButton(string buttonName, string buttonData, string contextName)
        {
            CheckIfConnected();

            string exceptionMessage = string.Format("ClickKeyboardButton: [{0}] [{1}] Context: [{2}]", buttonName, buttonData, TestEvents.CurrentContext);

            CallTestFunction(() => { _channel.ClickKeyboardButton(buttonName, buttonData); }, contextName, exceptionMessage);
        }

        /// <summary>
        /// List button click event
        /// </summary>
        /// <param name="controlName">name of the control</param>
        /// <param name="buttonName">name of the button</param>
        /// <param name="index">button index</param>
        /// <param name="contextName">name of the context</param>
        public void ClickListButton(string controlName, string buttonName, string index, string contextName)
        {
            CheckIfConnected();

            int indexInt;
            if (!int.TryParse(index, out indexInt))
            {
                throw new InvalidCastException("Index needs to be an int");
            }

            string exceptionMessage = string.Format("ClickListButton: [{0}] [{1}] [{2}] Context: [{3}]", controlName, buttonName, index, TestEvents.CurrentContext);

            CallTestFunction(() => { _channel.ClickListButton(controlName, buttonName, indexInt); }, contextName, exceptionMessage);
        }

        /// <summary>
        /// Signature signing event
        /// </summary>
        /// <param name="controlName">name of the control</param>
        /// <param name="contextName">name of the context</param>
        public void SignSignature(string controlName, string contextName)
        {
            CheckIfConnected();

            string exceptionMessage = string.Format("SignSignature: [{0}] Context: [{1}]", controlName, TestEvents.CurrentContext);

            CallTestFunction(() => { _channel.Sign(controlName); }, contextName, exceptionMessage);
        }

        /// <summary>
        /// Left swipe event
        /// </summary>
        /// <param name="controlName">name of the control</param>
        /// <param name="contextName">name of the context</param>
        public void SwipeLeft(string controlName, string contextName)
        {
            CheckIfConnected();

            string exceptionMessage = string.Format("SwipeLeft: [{0}] Context: [{1}]", controlName, TestEvents.CurrentContext);

            CallTestFunction(() => { _channel.SwipeLeft(controlName); }, contextName, exceptionMessage);
        }

        /// <summary>
        /// Right swipe event
        /// </summary>
        /// <param name="controlName">name of the control</param>
        /// <param name="contextName">name of the context</param>
        public void SwipeRight(string controlName, string contextName)
        {
            CheckIfConnected();

            string exceptionMessage = string.Format("SwipeRight: [{0}] Context: [{1}]", controlName, TestEvents.CurrentContext);

            CallTestFunction(() => { _channel.SwipeRight(controlName); }, contextName, exceptionMessage);
        }

        /// <summary>
        /// Hardware UNAV click event
        /// </summary>
        /// <param name="buttonData">name of the button</param>
        /// <param name="buttonID">the button identifier</param>
        /// <param name="contextName">name of the context</param>
        public void ClickHWuNav(string buttonData, string buttonID, string contextName)
        {
            CheckIfConnected();
            
            Constants.UNavOperation operation = Constants.UNavOperation.None;

            switch (buttonData)
            {
                case "Left":
                    operation = Constants.UNavOperation.Left;
                    break;
                case "Up":
                    operation = Constants.UNavOperation.Up;
                    break;
                case "Right":
                    operation = Constants.UNavOperation.Right;
                    break;
                case "Down":
                    operation = Constants.UNavOperation.Down;
                    break;
                case "Select":
                    operation = Constants.UNavOperation.Select;
                    break;
            }

            string exceptionMessage = string.Format("ClickHWuNav: [{0}] with Button ID:[{1}] on Context: [{2}]", buttonData, buttonID, TestEvents.CurrentContext);

            CallTestFunction(() => { _channel.SimulateUNav(operation, buttonID); }, contextName, exceptionMessage);
        }

        /// <summary>
        /// Get Current Context
        /// </summary>
        /// <returns>the name of the current context</returns>
        public string GetCurrentContext()
        {
            CheckIfConnected();

            _currentContext = _channel.GetContext();

            return _currentContext;
        }

        /// <summary>
        /// Waits for a response from NGUI
        /// </summary>
        /// <param name="message">failure message for the event if response is not received</param>
        /// <returns>Returns true if a response was received, otherwise false</returns>
        private static bool WaitForResponse(string message)
        {
            TestEvents.CommandFailureMessage = message;

            bool isSignal = TestEvents.AutoTestRespondedEvent.WaitOne(10000);

            if (!isSignal)
            {
                throw new TimeoutException(string.Format("A response was not received for an auto test command: {0}", message));
            }

            return TestEvents.AutoTestResponse;
        }

        /// <summary>
        /// Updates the context as it changes from NGUI
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void _testEvents_UpdateContext(object sender, EventArgs e)
        {
            UpdateContextEventArgs args = e as UpdateContextEventArgs;

            if (args == null)
            {
                return;
            }

            _currentContext = args.ContextName;

            LoggingService.Info("Now in context " + args.ContextName);

            try
            {
                OnUpdateContext(sender, e);
            }
            catch (NullReferenceException ex)
            {
                LoggingService.Error(ex.ToString());
            }            
        }

        /// <summary>
        /// Connects to the automation test server
        /// </summary>
        private void ConnectToServer()
        {
            LoggingService.Info("NextGenUITestClient: Connect To Server.");
            bool isNetTCP = SSCOHelper.IsNetTCP();
            
            string netPipeAddress = "net.pipe://localhost/fastlane/testautomation";
            
            try
            {
                if (isNetTCP)
                {
                    string portCOnfig = FileHelper.GetIniValue("NGUINetTCP", "port", ApplicationUtility.SettingsFileName);
                    string address = FileHelper.GetIniValue("NGUINetTCP", "address", ApplicationUtility.SettingsFileName);
                    if (!SSCOHelper.IsValidHostNameOrIpaddress(address) && !SSCOHelper.IsValidPort(portCOnfig))
                    {
                        throw new Exception();
                    }
                    string netTCPAddress = string.Format("net.tcp://{0}:{1}", address, portCOnfig);
                    //// In compatiblity with NextGenUI_v1.2.1_B177_Hotfix_v2
                    LoggingService.Info("Connecting to " + netTCPAddress);
                    NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
                    EndpointAddress endpoint = new EndpointAddress(netTCPAddress);
                    InstanceContext instanceContext = new InstanceContext(_testEvents);
                    _channel = DuplexChannelFactory<ITestContract>.CreateChannel(instanceContext, binding, endpoint);
                }
                else
                {
                    //// In compatiblity with NextGenUI_v1.2.0_b167
                    LoggingService.Info("Connecting to " + netPipeAddress);
                    NetNamedPipeBinding binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                    EndpointAddress endpoint = new EndpointAddress(netPipeAddress);
                    InstanceContext instanceContext = new InstanceContext(_testEvents);
                    _channel = DuplexChannelFactory<ITestContract>.CreateChannel(instanceContext, binding, endpoint);
                }
                
                ((IClientChannel)_channel).Faulted += NextGenUITestClient_Faulted;
                ((IClientChannel)_channel).Closed += NextGenUITestClient_Closed;
                _channel.SubscribeEvents();
                Connected = true;
                LoggingService.Info("NextGenUITestClient: Connected.");
            }
            catch (EndpointNotFoundException ex)
            {
                string message = string.Format("{0}Failed,{1}{0}Troubleshooting tips:{0}NGUI must have been terminated.{0} Check if SSCO is terminated{0} Generate Diags in SSCO and investigate the cause of the termination{0} After Diags are generated, escalate the issue to SSCAT Team or NGUI Team", Environment.NewLine, ex.Message);
                message += string.Format(@"{0}{0}If NGUI is running,{0} Check c:\sscat\config\settings.ini{0} Under [NGUIConnection] Section, ", Environment.NewLine);

                string netTCPMsg = string.Format(@"Modify 'NetworkBinding=NetPipe'.{0} You might be using NextGenUI v1.2.0 and below", Environment.NewLine);
                string netPipeMsg = string.Format(@"Modify 'NetworkBinding=NetTCP'.{0} You might be using NextGenUI v1.2.1 and above", Environment.NewLine);

                message += isNetTCP ? netTCPMsg : netPipeMsg;
                EndpointNotFoundException exc = new EndpointNotFoundException(message);
                throw exc;
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
                throw;
            }
        }

        

        /// <summary>
        /// Event for if the connection for the test client closes
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void NextGenUITestClient_Closed(object sender, EventArgs e)
        {
            LoggingService.Info("NextGenUITestClient_Faulted");
            Connected = false;
        }

        /// <summary>
        /// Event for if the connection for the test client reaches a faulted state
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arguments</param>
        private void NextGenUITestClient_Faulted(object sender, EventArgs e)
        {
            LoggingService.Info("NextGenUITestClient_Faulted"); 
            Connected = false;
        }

        /// <summary>
        /// Attempts the automation event multiple times and waits for a response until it succeeds or exceeds maximum tries
        /// </summary>
        /// <param name="testFunc">test method for the event</param>
        /// <param name="contextName">name of the context</param>
        /// <param name="exceptionMessage">exception message</param>
        private void CallTestFunction(Action testFunc, string contextName, string exceptionMessage)
        {
            TestEvents.WaitForContext(contextName);

            bool successful = false;

            for (int i = 0; i < 20 && !successful; i++)
            {
                TestEvents.AutoTestRespondedEvent.Reset();
                testFunc();
                successful = WaitForResponse(exceptionMessage);

                if (!successful)
                {
                    Thread.Sleep(100);
                }
            }

            if (!successful)
            {
                throw new AutoTestException("No successful auto test result received after 20 tries.");
            }
        }

        /// <summary>
        /// Checks for connection to the server and determines if it needs to try to connect again
        /// </summary>
        private void CheckIfConnected()
        {
            if (!Connected)
            {
                ConnectToServer();
            }
        }
    }
}
