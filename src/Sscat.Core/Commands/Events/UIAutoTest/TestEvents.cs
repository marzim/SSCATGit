// <copyright file="TestEvents.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events.UIAutoTest
{   
    using System;
    using System.Threading;
    using Ncr.Core.Util;
    using TestAutomationCommon.Interfaces;

    /// <summary>
    /// Initializes a new instance of the TestEvents class
    /// </summary>
    internal class TestEvents : ITestEvents
    {
        /// <summary>
        /// Default context name at the start of a transaction
        /// </summary>
        private const string DEFAULT_CONTEXT = "Welcome";

        /// <summary>
        /// Current context name
        /// </summary>
        private static string __currentContext = DEFAULT_CONTEXT;

        /// <summary>
        /// Event handler for the update context event
        /// </summary>
        public event EventHandler<UpdateContextEventArgs> UpdateContext;

        /// <summary>
        /// Gets or sets the command failure message
        /// </summary>
        public static string CommandFailureMessage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the auto test event had a response
        /// </summary>
        public static bool AutoTestResponse { get; set; }

        /// <summary>
        /// Gets or sets the enter password ready event
        /// </summary>
        public static ManualResetEvent EnterPasswordReadyEvent { get; set; }

        /// <summary>
        /// Gets or sets the auto test responded event
        /// </summary>
        public static ManualResetEvent AutoTestRespondedEvent { get; set; }

        /// <summary>
        /// Gets or sets the current context name
        /// </summary>
        public static string CurrentContext
        {
            get { return __currentContext; }
            set { __currentContext = value; }
        }

        /// <summary>
        /// Waits for the given context to arrive from NGUI
        /// </summary>
        /// <param name="contextName">name of the context</param>
        public static void WaitForContext(string contextName)
        {
            if (CurrentContext.ToLower().Equals("storemodekeyboard") && contextName.Equals("OperatorKeyboard"))
            {
                contextName = "StoreModeKeyboard";
            }

            int count = 0;
            while (!ContextEquals(contextName, CurrentContext))
            {
                count++;
                if (count > 30)
                {
                    throw new TimeoutException(string.Format("Context {0} did not arrive. Current Context is {1}", contextName, CurrentContext));
                }

                Thread.Sleep(1000);
            }
        }
        
        /// <summary>
        /// Resets the current context to the default context
        /// </summary>
        public static void ResetContext()
        {
            __currentContext = DEFAULT_CONTEXT;
        }

        /// <summary>
        /// Checks to see if the given context is ready
        /// </summary>
        /// <param name="context">name of the context</param>
        public void ContextReady(string context)
        {
            CurrentContext = context;

            if (UpdateContext != null)
            {
                UpdateContextEventArgs eventArgs = new UpdateContextEventArgs() { ContextName = context };

                UpdateContext(this, eventArgs);
            }

            if (context.Equals("EnterPassword", StringComparison.OrdinalIgnoreCase))
            {
                EnterPasswordReadyEvent.Set();
            }
            else
            {
                EnterPasswordReadyEvent.Reset();
            }
        }

        /// <summary>
        /// Sets the automated test response status
        /// </summary>
        /// <param name="success">whether or not the automated test event succeeded</param>
        public void AutoTestResponded(bool success)
        {
            AutoTestResponse = success;

            AutoTestRespondedEvent.Set();

            LoggingService.Info("Received AutoTestResponse = {0}", success.ToString());
        }

        /// <summary>
        /// Checks if NGUI is in a welcome context
        /// </summary>
        /// <param name="contextName">name of the context</param>
        /// <returns>Returns true if in a welcome context state</returns>
        private static bool IsWelcome(string contextName)
        {
            return contextName.Equals(DEFAULT_CONTEXT) || contextName.Equals("AttractMultiLanguage") || contextName.Equals("Closed") || contextName.Equals("EnterUNav");
        }

        /// <summary>
        /// Checks to see if the current context matches the expected context
        /// </summary>
        /// <param name="expectedContext">context to check</param>
        /// <param name="currentContext">current context</param>
        /// <returns>Returns true if the context matches, false otherwise</returns>
        private static bool ContextEquals(string expectedContext, string currentContext)
        {
            if (IsWelcome(expectedContext) && IsWelcome(currentContext))
            {
                return true;
            }

            return expectedContext.Equals(currentContext);
        }
    }
}
