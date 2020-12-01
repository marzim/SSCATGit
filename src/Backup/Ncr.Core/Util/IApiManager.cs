// <copyright file="IApiManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Drawing;
    using System.Text;

    /// <summary>
    /// Initializes a new instance of the IApiManager interface
    /// </summary>
    public interface IApiManager
    {
        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        IntPtr SendMessage(IntPtr handle, uint message, int wparam, int lparam);

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings. 
        /// This function does not search child windows. This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="className">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function.</param>
        /// <param name="windowName">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class name and window name.</returns>
        IntPtr FindWindow(string className, string windowName);

        /// <summary>
        /// Retrieves a handle to a control in the specified dialog box.
        /// </summary>
        /// <param name="handle">A handle to the dialog box that contains the control.</param>
        /// <param name="item">The identifier of the control to be retrieved.</param>
        /// <returns>If the function succeeds, the return value is the window handle of the specified control.</returns>
        IntPtr GetDlgItem(IntPtr handle, int item);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        int SendMessage(IntPtr handle, uint message, int wparam, string lparam);

        /// <summary>
        /// Sets the specified window's show state.
        /// </summary>
        /// <param name="handle">A handle to the window.</param>
        /// <param name="show">Controls how the window is to be shown.</param>
        /// <returns>If the window was previously visible, the return value is nonzero.</returns>
        bool ShowWindow(IntPtr handle, int show);

        /// <summary>
        /// Retrieves a handle to a window whose class name and window name match the specified strings.
        /// </summary>
        /// <param name="parentHandle">A handle to the parent window whose child windows are to be searched.</param>
        /// <param name="childAfter">A handle to a child window.</param>
        /// <param name="className">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function.</param>
        /// <param name="windowTitle">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class and window names.</returns>
        IntPtr FindWindowEx(IntPtr parentHandle, int childAfter, string className, string windowTitle);

        /// <summary>
        /// Determines the visibility state of the specified window.
        /// </summary>
        /// <param name="handle">A handle to the window to be tested.</param>
        /// <returns>If the specified window, its parent window, its parent's parent window, and so forth, have the WS_VISIBLE style, the return value is nonzero. 
        /// Otherwise, the return value is zero.</returns>
        int IsWindowVisible(IntPtr handle);

        /// <summary>
        /// Determines whether the specified window is enabled for mouse and keyboard input.
        /// </summary>
        /// <param name="handle">A handle to the window to be tested.</param>
        /// <returns>If the window is enabled, the return value is nonzero.</returns>
        int IsWindowEnabled(IntPtr handle);

        /// <summary>
        /// Brings the thread that created the specified window into the foreground and activates the window. Keyboard input is directed to the window, and various visual cues are changed for the user. 
        /// The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
        /// </summary>
        /// <param name="handle">A handle to the window that should be activated and brought to the foreground.</param>
        /// <returns>If the window was brought to the foreground, the return value is nonzero.</returns>
        bool SetForegroundWindow(IntPtr handle);

        /// <summary>
        /// Sends a message to the specified control in a dialog box.
        /// </summary>
        /// <param name="handle">A handle to the dialog box that contains the control.</param>
        /// <param name="id">The identifier of the control that receives the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="index">Message index</param>
        /// <param name="buffer">Additional message-specific information.</param>
        void SendDlgItemMessage(IntPtr handle, int id, uint message, int index, StringBuilder buffer);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        IntPtr SendMessage(IntPtr handle, uint message, int wparam, StringBuilder lparam);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        IntPtr SendMessage(IntPtr handle, uint message, IntPtr wparam, IntPtr lparam);

        /// <summary>
        /// Synthesizes a keystroke. 
        /// Note: This function has been superseded. Use SendInput instead.
        /// </summary>
        /// <param name="vk">A virtual-key code. The code must be a value in the range 1 to 254.</param>
        /// <param name="scan">A hardware scan code for the key.</param>
        /// <param name="flags">Controls various aspects of function operation.</param>
        /// <param name="extrainfo">An additional value associated with the key stroke.</param>
        void KeyboardEvent(int vk, byte scan, int flags, int extrainfo);

        /// <summary>
        /// Captures window of the given handle
        /// </summary>
        /// <param name="handle">window handle</param>
        /// <returns>Returns the image captured.</returns>
        Image CaptureImageWindow(IntPtr handle);

        /// <summary>
        /// Captures the desktop window
        /// </summary>
        /// <returns>Returns image of the desktop window</returns>
        Image CaptureImageDesktop();

        /// <summary>
        /// Sends the given keys to the active application, and then waits for the messages to be processed.
        /// </summary>
        /// <param name="command">The string of keystrokes to send.</param>
        void SendWait(string command);

        /// <summary>
        /// Determines which, if any, of the child windows belonging to a parent window contains the specified point. 
        /// </summary>
        /// <param name="handle">A handle to the parent window.</param>
        /// <param name="point">A structure that defines the client coordinates, relative to the parent, of the point to be checked.</param>
        /// <returns>The return value is a handle to the child window that contains the point, even if the child window is hidden or disabled.</returns>
        IntPtr ChiledWindowFromPoint(IntPtr handle, Point point);

        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window is a control, the text of the control is copied. 
        /// However, GetWindowText cannot retrieve the text of a control in another application.
        /// </summary>
        /// <param name="handle">A handle to the window or control containing the text.</param>
        /// <param name="text">The buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated with a null character.</param>
        /// <param name="maxCount">The maximum number of characters to copy to the buffer, including the null character. If the text exceeds this limit, it is truncated.</param>
        /// <returns>If the function succeeds, the return value is the length, in characters, of the copied string, not including the terminating null character. 
        /// If the window has no title bar or text, if the title bar is empty, or if the window or control handle is invalid, the return value is zero.</returns>
        int GetWindowText(IntPtr handle, StringBuilder text, int maxCount);

        /// <summary>
        /// Moves the cursor to the specified screen coordinates. If the new coordinates are not within the screen rectangle set by the most recent ClipCursor function call, 
        /// the system automatically adjusts the coordinates so that the cursor stays within the rectangle.
        /// </summary>
        /// <param name="pt">Cursor point</param>
        void SetCursorPosition(Point pt);
    }
}
