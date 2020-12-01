// <copyright file="ApiManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Ncr.Core.PInvoke;
    
    /// <summary>
    /// Initializes a new instance of the ApiManager class
    /// </summary>
    public class ApiManager : IApiManager
    {
        /// <summary>
        /// Sends a message to the specified control in a dialog box.
        /// </summary>
        /// <param name="handle">A handle to the dialog box that contains the control.</param>
        /// <param name="id">The identifier of the control that receives the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="index">Message index</param>
        /// <param name="buffer">Additional message-specific information.</param>
        public void SendDlgItemMessage(IntPtr handle, int id, uint message, int index, StringBuilder buffer)
        {
            User32.SendDlgItemMessage(handle, id, message, index, buffer);
        }

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        public IntPtr SendMessage(IntPtr handle, uint message, int wparam, int lparam)
        {
            return User32.SendMessage(handle, message, wparam, lparam);
        }

        /// <summary>
        /// Captures window of the given handle
        /// </summary>
        /// <param name="handle">window handle</param>
        /// <returns>Returns the image captured.</returns>
        public Image CaptureImageWindow(IntPtr handle)
        {
            return Gdi32.CaptureWindow(handle);
        }

        /// <summary>
        /// Captures the desktop window
        /// </summary>
        /// <returns>Returns image of the desktop window</returns>
        public Image CaptureImageDesktop()
        {
            return Gdi32.CaptureDesktop();
        }

        /// <summary>
        /// Synthesizes a keystroke. 
        /// Note: This function has been superseded. Use SendInput instead.
        /// </summary>
        /// <param name="vk">A virtual-key code. The code must be a value in the range 1 to 254.</param>
        /// <param name="scan">A hardware scan code for the key.</param>
        /// <param name="flags">Controls various aspects of function operation.</param>
        /// <param name="extrainfo">An additional value associated with the key stroke.</param>
        public void KeyboardEvent(int vk, byte scan, int flags, int extrainfo)
        {
            User32.keybd_event(vk, scan, flags, extrainfo);
        }

        /// <summary>
        /// Set the system time
        /// </summary>
        /// <param name="dateTime">date time</param>
        public void SetSystemTime(DateTime dateTime)
        {
            SYSTEMTIME time = new SYSTEMTIME();
            time.Year = (short)dateTime.Year;
            time.Month = (short)dateTime.Month;
            time.Day = (short)dateTime.Day;
            time.Hour = (short)dateTime.Hour;
            time.Minute = (short)dateTime.Minute;
            time.Second = (short)dateTime.Second;
            Kernel32.SetSystemTime(ref time);
        }

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings. 
        /// This function does not search child windows. This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="className">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function.</param>
        /// <param name="windowName">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class name and window name.</returns>
        public IntPtr FindWindow(string className, string windowName)
        {
            return User32.FindWindow(className, windowName);
        }

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        public IntPtr SendMessage(IntPtr handle, uint message, IntPtr wparam, IntPtr lparam)
        {
            return User32.SendMessage(handle, message, wparam, lparam);
        }

        /// <summary>
        /// Brings the thread that created the specified window into the foreground and activates the window. Keyboard input is directed to the window, and various visual cues are changed for the user. 
        /// The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
        /// </summary>
        /// <param name="handle">A handle to the window that should be activated and brought to the foreground.</param>
        /// <returns>If the window was brought to the foreground, the return value is nonzero.</returns>
        public bool SetForegroundWindow(IntPtr handle)
        {
            return User32.SetForegroundWindow(handle);
        }

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        public IntPtr SendMessage(IntPtr handle, uint message, int wparam, StringBuilder lparam)
        {
            return User32.SendMessage(handle, message, wparam, lparam);
        }

        /// <summary>
        /// Retrieves a handle to a control in the specified dialog box.
        /// </summary>
        /// <param name="handle">A handle to the dialog box that contains the control.</param>
        /// <param name="item">The identifier of the control to be retrieved.</param>
        /// <returns>If the function succeeds, the return value is the window handle of the specified control.</returns>
        public IntPtr GetDlgItem(IntPtr handle, int item)
        {
            return User32.GetDlgItem(handle, item);
        }

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        public int SendMessage(IntPtr handle, uint message, int wparam, string lparam)
        {
            return User32.SendMessage(handle, message, wparam, lparam);
        }

        /// <summary>
        /// Sets the specified window's show state.
        /// </summary>
        /// <param name="handle">A handle to the window.</param>
        /// <param name="show">Controls how the window is to be shown.</param>
        /// <returns>If the window was previously visible, the return value is nonzero.</returns>
        public bool ShowWindow(IntPtr handle, int show)
        {
            return User32.ShowWindow(handle, show);
        }

        /// <summary>
        /// Retrieves a handle to a window whose class name and window name match the specified strings.
        /// </summary>
        /// <param name="parentHandle">A handle to the parent window whose child windows are to be searched.</param>
        /// <param name="childAfter">A handle to a child window.</param>
        /// <param name="className">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function.</param>
        /// <param name="windowTitle">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class and window names.</returns>
        public IntPtr FindWindowEx(IntPtr parentHandle, int childAfter, string className, string windowTitle)
        {
            return User32.FindWindowEx(parentHandle, childAfter, className, windowTitle);
        }

        /// <summary>
        /// Determines which, if any, of the child windows belonging to a parent window contains the specified point. 
        /// </summary>
        /// <param name="handle">A handle to the parent window.</param>
        /// <param name="point">A structure that defines the client coordinates, relative to the parent, of the point to be checked.</param>
        /// <returns>The return value is a handle to the child window that contains the point, even if the child window is hidden or disabled.</returns>
        public IntPtr ChiledWindowFromPoint(IntPtr handle, Point point)
        {
            return User32.ChildWindowFromPoint(handle, point);
        }

        /// <summary>
        /// Determines the visibility state of the specified window.
        /// </summary>
        /// <param name="handle">A handle to the window to be tested.</param>
        /// <returns>If the specified window, its parent window, its parent's parent window, and so forth, have the WS_VISIBLE style, the return value is nonzero. 
        /// Otherwise, the return value is zero.</returns>
        public int IsWindowVisible(IntPtr handle)
        {
            return User32.IsWindowVisible(handle);
        }

        /// <summary>
        /// Determines whether the specified window is enabled for mouse and keyboard input.
        /// </summary>
        /// <param name="handle">A handle to the window to be tested.</param>
        /// <returns>If the window is enabled, the return value is nonzero.</returns>
        public int IsWindowEnabled(IntPtr handle)
        {
            return User32.IsWindowEnabled(handle);
        }

        /// <summary>
        /// Sends the given keys to the active application, and then waits for the messages to be processed.
        /// </summary>
        /// <param name="command">The string of keystrokes to send.</param>
        public void SendWait(string command)
        {
            SendKeys.SendWait(command);
        }

        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window is a control, the text of the control is copied. 
        /// However, GetWindowText cannot retrieve the text of a control in another application.
        /// </summary>
        /// <param name="handle">A handle to the window or control containing the text.</param>
        /// <param name="text">The buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated with a null character.</param>
        /// <param name="maxCount">The maximum number of characters to copy to the buffer, including the null character. If the text exceeds this limit, it is truncated.</param>
        /// <returns>If the function succeeds, the return value is the length, in characters, of the copied string, not including the terminating null character. 
        /// If the window has no title bar or text, if the title bar is empty, or if the window or control handle is invalid, the return value is zero.</returns>
        public int GetWindowText(IntPtr handle, StringBuilder text, int maxCount)
        {
            return User32.GetWindowText(handle, text, maxCount);
        }

        /// <summary>
        /// Moves the cursor to the specified screen coordinates. If the new coordinates are not within the screen rectangle set by the most recent ClipCursor function call, 
        /// the system automatically adjusts the coordinates so that the cursor stays within the rectangle.
        /// </summary>
        /// <param name="pt">Cursor point</param>
        public void SetCursorPosition(Point pt)
        {
            User32.SetCursorPos(pt.X, pt.Y);
        }
    }
}
