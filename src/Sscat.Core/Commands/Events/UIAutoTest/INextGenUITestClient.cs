// <copyright file="INextGenUITestClient.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Commands.Events.UIAutoTest
{
    using System;

    /// <summary>
    /// Interface for the NextGenUITestClient class
    /// </summary>
    public interface INextGenUITestClient
    {
        /// <summary>
        /// Event handler for the update context event
        /// </summary>
        event EventHandler<EventArgs> OnUpdateContext;

        /// <summary>
        /// Gets a value indicating whether the test client is connected
        /// </summary>
        bool Connected { get; }

        /// <summary>
        /// Gets or sets the value of the Current Context
        /// </summary>
        string CurrentContext { get; set; }

        /// <summary>
        /// Checks for connection to the server and determines if it needs to try to connect again
        /// </summary>
        void CheckConnection();

        /// <summary>
        /// Gets the value of the Current Context
        /// </summary>
        /// <returns>Returns the current context</returns>
        string GetCurrentContext();

        /// <summary>
        /// Normal button click event
        /// </summary>
        /// <param name="buttonName">name of the button</param>
        /// <param name="contextName">name of the context</param>
        /// <param name="buttonID">button ID</param>
        void ClickButton(string buttonName, string contextName, string buttonID = "");

        /// <summary>
        /// Normal button click event used in Smart Exit
        /// </summary>
        /// <param name="buttonName">name of the button</param>
        /// <param name="contextName">name of the context</param>
        /// <param name="buttonID">button ID</param>
        void SmartExitClickButton(string buttonName, string contextName, string buttonID = "");

        /// <summary>
        /// Category button click event
        /// </summary>
        /// <param name="controlName">name of the control</param>
        /// <param name="index">button index</param>
        /// <param name="contextName">name of the context</param>
        void ClickCategory(string controlName, string index, string contextName);

        /// <summary>
        /// Hardware UNAV click event
        /// </summary>
        /// <param name="buttonData">name of the button</param>
        /// <param name="buttonID">the button identifier</param>
        /// <param name="contextName">name of the context</param>
        void ClickHWuNav(string buttonData, string buttonID, string contextName);

        /// <summary>
        /// Keyboard button click event
        /// </summary>
        /// <param name="buttonName">name of the button</param>
        /// <param name="buttonData">button data</param>
        /// <param name="contextName">name of the context</param>
        void ClickKeyboardButton(string buttonName, string buttonData, string contextName);

        /// <summary>
        /// List button click event
        /// </summary>
        /// <param name="controlName">name of the control</param>
        /// <param name="buttonName">name of the button</param>
        /// <param name="index">button index</param>
        /// <param name="contextName">name of the context</param>
        void ClickListButton(string controlName, string buttonName, string index, string contextName);

        /// <summary>
        /// Sliding grid page button click
        /// </summary>
        /// <param name="controlName">name of the control</param>
        /// <param name="index">grid page item index</param>
        /// <param name="buttonData">button data</param>
        /// <param name="contextName">name of the context</param>
        void ClickSlidingGridPage(string controlName, string index, string buttonData, string contextName);

        /// <summary>
        /// Signature signing event
        /// </summary>
        /// <param name="controlName">name of the control</param>
        /// <param name="contextName">name of the context</param>
        void SignSignature(string controlName, string contextName);

        /// <summary>
        /// Left swipe event
        /// </summary>
        /// <param name="controlName">name of the control</param>
        /// <param name="contextName">name of the context</param>
        void SwipeLeft(string controlName, string contextName);

        /// <summary>
        /// Right swipe event
        /// </summary>
        /// <param name="controlName">name of the control</param>
        /// <param name="contextName">name of the context</param>
        void SwipeRight(string controlName, string contextName);
    }
}
