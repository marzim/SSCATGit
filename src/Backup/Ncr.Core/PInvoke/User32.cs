// <copyright file="User32.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.PInvoke
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Used by SendInput to store information for synthesizing input events such as keystrokes, mouse movement, and mouse clicks.
    /// </summary>
    public enum INPUT : uint
    {
        /// <summary>
        /// Mouse input
        /// </summary>
        INPUT_MOUSE = 0,

        /// <summary>
        /// Keyboard input
        /// </summary>
        INPUT_KEYBOARD = 1,

        /// <summary>
        /// Hardware input
        /// </summary>
        INPUT_HARDWARE = 2
    }

    /// <summary>
    /// MSDN library for mouse and keyboard actions as well as application handles.
    /// </summary>
    public static class User32
    {
        /// <summary>
        /// Simulates the user clicking a button.
        /// </summary>
        public const uint BM_CLICK = 0xf5;

        /// <summary>
        /// Gets the check state of a radio button or check box.
        /// </summary>
        public const uint BM_GETCHECK = 240;

        /// <summary>
        /// Retrieves a handle to the image (icon or bitmap) associated with the button.
        /// </summary>
        public const uint BM_GETIMAGE = 0xf6;

        /// <summary>
        /// Retrieves the state of a button or check box. You can send this message explicitly or use the Button_GetState macro.
        /// </summary>
        public const uint BM_GETSTATE = 0xf2;

        /// <summary>
        /// Sets the check state of a radio button or check box. You can send this message explicitly or by using the Button_SetCheck macro.
        /// </summary>
        public const uint BM_SETCHECK = 0xf1;

        /// <summary>
        /// Associates a new image (icon or bitmap) with the button.
        /// </summary>
        public const uint BM_SETIMAGE = 0xf7;

        /// <summary>
        /// Sets the highlight state of a button. The highlight state indicates whether the button is highlighted as if the user had pushed it. 
        /// You can send this message explicitly or use the Button_SetState macro.
        /// </summary>
        public const uint BM_SETSTATE = 0xf3;

        /// <summary>
        /// Sets the style of a button. You can send this message explicitly or use the Button_SetStyle macro.
        /// </summary>
        public const uint BM_SETSTYLE = 0xf4;

        /// <summary>
        /// Sets the button state to checked.
        /// </summary>
        public const uint BST_CHECKED = 1;

        /// <summary>
        /// The button has the keyboard focus.
        /// </summary>
        public const uint BST_FOCUS = 8;

        /// <summary>
        /// Sets the button state to grayed, indicating an indeterminate state. Use this value only if the button has the BS_3STATE or BS_AUTO3STATE style.
        /// </summary>
        public const uint BST_INDETERMINATE = 2;

        /// <summary>
        /// The button is being shown in the pushed state.
        /// </summary>
        public const uint BST_PUSHED = 4;

        /// <summary>
        /// Sets the button state to cleared.
        /// </summary>
        public const uint BST_UNCHECKED = 0;

        /// <summary>
        /// Gets the number of items in the list box of a combo box.
        /// </summary>
        public const uint CB_GETCOUNT = 0x146;

        /// <summary>
        /// An application sends a CB_GETITEMDATA message to a combo box to retrieve the application-supplied value associated with the specified item in the combo box.
        /// </summary>
        public const uint CB_GETITEMDATA = 0x150;

        /// <summary>
        /// Gets a string from the list of a combo box.
        /// </summary>
        public const uint CB_GETLBTEXT = 0x148;

        /// <summary>
        /// Gets the length, in characters, of a string in the list of a combo box.
        /// </summary>
        public const uint CB_GETLBTEXTLEN = 0x149;

        /// <summary>
        /// Searches the list of a combo box for an item that begins with the characters in a specified string. 
        /// If a matching item is found, it is selected and copied to the edit control.
        /// </summary>
        public const uint CB_SELECTSTRING = 0x14d;

        /// <summary>
        /// An application sends a CB_SETCURSEL message to select a string in the list of a combo box. 
        /// If necessary, the list scrolls the string into view. The text in the edit control of the combo box changes to reflect the new selection, and any previous selection in the list is removed.
        /// </summary>
        public const uint CB_SETCURSEL = 0x14e;

        /// <summary>
        /// An application sends a CB_SETITEMDATA message to set the value associated with the specified item in a combo box.
        /// </summary>
        public const uint CB_SETITEMDATA = 0x151;

        /// <summary>
        /// An application sends a CB_SHOWDROPDOWN message to show or hide the list box of a combo box that has the CBS_DROPDOWN or CBS_DROPDOWNLIST style.
        /// </summary>
        public const uint CB_SHOWDROPDOWN = 0x14f;

        /// <summary>
        /// The retrieved handle identifies the child window at the top of the Z order, if the specified window is a parent window; otherwise, the retrieved handle is NULL.
        /// </summary>
        public const int GW_CHILD = 5;

        /// <summary>
        /// The retrieved handle identifies the child window at the top of the Z order, if the specified window is a parent window; otherwise, the retrieved handle is NULL. 
        /// The function examines only child windows of the specified window. It does not examine descendant windows.
        /// </summary>
        public const int GW_ENABLEDPOPUP = 6;

        /// <summary>
        /// The retrieved handle identifies the window of the same type that is highest in the Z order.
        /// </summary>
        public const int GW_HWNDFIRST = 0;

        /// <summary>
        /// The retrieved handle identifies the window of the same type that is lowest in the Z order.
        /// </summary>
        public const int GW_HWNDLAST = 1;

        /// <summary>
        /// The retrieved handle identifies the window below the specified window in the Z order.
        /// </summary>
        public const int GW_HWNDNEXT = 2;

        /// <summary>
        /// The retrieved handle identifies the window above the specified window in the Z order.
        /// </summary>
        public const int GW_HWNDPREV = 3;

        /// <summary>
        /// The retrieved handle identifies the specified window's owner window, if any. For more information, see Owned Windows.
        /// </summary>
        public const int GW_OWNER = 4;

        /// <summary>
        /// Retrieves the window styles.
        /// </summary>
        public const int GW_STYLE = -16;

        /// <summary>
        /// The CTRL key is down.
        /// </summary>
        public const uint MK_CONTROL = 8;

        /// <summary>
        /// The left mouse button is down.
        /// </summary>
        public const uint MK_LBUTTON = 1;

        /// <summary>
        /// The middle mouse button is down.
        /// </summary>
        public const uint MK_MBUTTON = 0x10;

        /// <summary>
        /// The right mouse button is down.
        /// </summary>
        public const uint MK_RBUTTON = 2;

        /// <summary>
        /// The SHIFT key is down.
        /// </summary>
        public const uint MK_SHIFT = 4;

        /// <summary>
        /// Hides the window and activates another window.
        /// </summary>
        public const int SW_HIDE = 0;

        /// <summary>
        /// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. 
        /// An application should specify this flag when displaying the window for the first time.
        /// </summary>
        public const int SW_SHOWNORMAL = 1;

        /// <summary>
        /// Activates the window and displays it as a minimized window.
        /// </summary>
        public const int SW_SHOWMINIMIZED = 2;

        /// <summary>
        /// Activates the window and displays it in its current size and position.
        /// </summary>
        public const int SW_SHOW = 5;

        /// <summary>
        /// Minimizes the specified window and activates the next top-level window in the Z order.
        /// </summary>
        public const int SW_MINIMIZED = 6;

        /// <summary>
        /// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. 
        /// An application should specify this flag when restoring a minimized window.
        /// </summary>
        public const int SW_RESTORE = 9;

        /// <summary>
        /// Retains the current position (ignores X and Y parameters).
        /// </summary>
        public const uint SWP_NOMOVE = 2;

        /// <summary>
        /// Retains the current size (ignores the cx and cy parameters).
        /// </summary>
        public const uint SWP_NOSIZE = 1;

        /// <summary>
        /// Displays the window.
        /// </summary>
        public const uint SWP_SHOWWINDOW = 0x40;

        /// <summary>
        /// Sent to the window that is losing the mouse capture.
        /// </summary>
        public const uint WM_CAPTURECHANGED = 0x215;

        /// <summary>
        /// Sent when an application changes the enabled state of a window. It is sent to the window whose enabled state is changing. 
        /// This message is sent before the EnableWindow function returns, but after the enabled state (WS_DISABLED style bit) of the window has changed.
        /// </summary>
        public const uint WM_ENABLE = 10;

        /// <summary>
        /// Copies the text that corresponds to a window into a buffer provided by the caller.
        /// </summary>
        public const uint WM_GETTEXT = 13;

        /// <summary>
        /// Determines the length, in characters, of the text associated with a window.
        /// </summary>
        public const uint WM_GETTEXTLENGTH = 14;

        /// <summary>
        /// Sent to a window immediately before it loses the keyboard focus.
        /// </summary>
        public const uint WM_KILLFOCUS = 8;

        /// <summary>
        /// Posted when the user double-clicks the left mouse button while the cursor is in the client area of a window. 
        /// If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const uint WM_LBUTTONDBLCLK = 0x203;

        /// <summary>
        /// Posted when the user presses the left mouse button while the cursor is in the client area of a window. 
        /// If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const uint WM_LBUTTONDOWN = 0x201;

        /// <summary>
        /// Posted when the user releases the left mouse button while the cursor is in the client area of a window. 
        /// If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const uint WM_LBUTTONUP = 0x202;

        /// <summary>
        /// Posted when the user double-clicks the middle mouse button while the cursor is in the client area of a window. 
        /// If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const uint WM_MBUTTONDBLCLK = 0x209;

        /// <summary>
        /// Posted when the user presses the middle mouse button while the cursor is in the client area of a window. 
        /// If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const uint WM_MBUTTONDBDOWN = 0x207;

        /// <summary>
        /// Posted when the user releases the middle mouse button while the cursor is in the client area of a window. 
        /// If the mouse is not captured, the message is posted to the window beneath the cursor. Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const uint WM_MBUTTONUP = 520;

        /// <summary>
        /// Sent when the cursor is in an inactive window and the user presses a mouse button. 
        /// The parent window receives this message only if the child window passes it to the Define Window Process function.
        /// </summary>
        public const uint WM_MOUSEACTIVE = 0x21;

        /// <summary>
        /// Specify the first mouse message.
        /// </summary>
        public const uint WM_MOUSEFIRST = 0x200;

        /// <summary>
        /// Posted to a window when the cursor moves. If the mouse is not captured, the message is posted to the window that contains the cursor. 
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const uint WM_MOUSEMOVE = 0x200;

        /// <summary>
        /// Posted when the user double-clicks the right mouse button while the cursor is in the client area of a window. 
        /// If the mouse is not captured, the message is posted to the window beneath the cursor. 
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const uint WM_RBUTTONDBLCLK = 0x206;

        /// <summary>
        /// Posted when the user presses the right mouse button while the cursor is in the client area of a window. 
        /// If the mouse is not captured, the message is posted to the window beneath the cursor. 
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const uint WM_RBUTTONDOWN = 0x204;

        /// <summary>
        /// Posted when the user releases the right mouse button while the cursor is in the client area of a window. 
        /// If the mouse is not captured, the message is posted to the window beneath the cursor. 
        /// Otherwise, the message is posted to the window that has captured the mouse.
        /// </summary>
        public const uint WM_RBUTTONUP = 0x205;

        /// <summary>
        /// Sent to a window if the mouse causes the cursor to move within a window and mouse input is not captured.
        /// </summary>
        public const uint WM_SETCURSOR = 0x20;

        /// <summary>
        /// Sent to a window after it has gained the keyboard focus.
        /// </summary>
        public const uint WM_SETFOCUS = 7;

        /// <summary>
        /// An application sends the WM_SETREDRAW message to a window to allow changes in that window to be redrawn or to prevent changes in that window from being redrawn.
        /// </summary>
        public const uint WM_SETREDRAW = 11;

        /// <summary>
        /// Sets the text of a window.
        /// </summary>
        public const uint WM_SETTEXT = 0x000c;

        /// <summary>
        /// Posted to the window with the keyboard focus when a non system key is pressed. A non system key is a key that is pressed when the ALT key is not pressed.
        /// </summary>
        public const uint WM_KEYDOWN = 0x0100;

        /// <summary>
        /// The window has a thin-line border.
        /// </summary>
        public const long WS_BORDER = 0x800000L;

        /// <summary>
        /// Clips child windows relative to each other; that is, when a particular child window receives a WM_PAINT message, 
        /// the WS_CLIPSIBLINGS style clips all other overlapping child windows out of the region of the child window to be updated. 
        /// If WS_CLIPSIBLINGS is not specified and child windows overlap, it is possible, when drawing within the client area of a child window, 
        /// to draw within the client area of a neighboring child window.
        /// </summary>
        public const long WS_CLIPSIBLINGS = 0x4000000L;

        /// <summary>
        /// The window is the first control of a group of controls. The group consists of this first control and all controls defined after it, up to the next control with the WS_GROUP style.
        /// </summary>
        public const long WS_GROUP = 0x20000L;

        /// <summary>
        /// The window is initially minimized. Same as the WS_ICONIC style.
        /// </summary>
        public const long WS_MINIMIZE = 0x20000000L;

        /// <summary>
        /// The window is a control that can receive the keyboard focus when the user presses the TAB key. Pressing the TAB key changes the keyboard focus to the next control with the WS_TABSTOP style.
        /// </summary>
        public const long WS_TABSTOP = 0x10000L;

        /// <summary>
        /// The window has a sizing border. Same as the WS_SIZEBOX style.
        /// </summary>
        public const long WS_THICKFRAME = 0x40000L;

        /// <summary>
        /// The window is initially visible.
        /// </summary>
        public const long WS_VISIBLE = 0x10000000L;

        /// <summary>
        /// If specified, the key is being released. If not specified, the key is being pressed.
        /// </summary>
        public const int KEYEVENTF_KEYUP = 0x02;

        /// <summary>
        /// ENTER key
        /// </summary>
        public const int VK_RETURN = 0x0D;

        /// <summary>
        /// DOWN ARROW key
        /// </summary>
        public const int VK_DOWN = 0x28;

        /// <summary>
        /// A hardware scan code for the key.
        /// </summary>
        public const int BSCAN = 0x09C;

        /// <summary>
        /// Handle for application's top-level window.
        /// </summary>
        private static IntPtr _hwndTop = new IntPtr(0);

        /// <summary>
        /// An application-defined callback function used with the Enumeration Windows or Enumeration Desktop Windows function. It receives top-level window handles. 
        /// </summary>
        /// <param name="handle">A handle to a top-level window.</param>
        /// <param name="param">The application-defined value given in Enumeration Windows or Enumeration Desktop Windows.</param>
        /// <returns>To continue enumeration, the callback function must return TRUE; to stop enumeration, it must return FALSE.</returns>
        public delegate bool EnumWindowsProc(IntPtr handle, IntPtr param);

        /// <summary>
        /// Mouse event flags
        /// </summary>
        [Flags]
        public enum MouseEventFlags : uint
        {
            /// <summary>
            /// The x and y parameters contain normalized absolute coordinates.
            /// </summary>
            MOUSEEVENTF_ABSOLUTE = 0x8000,

            /// <summary>
            /// The left button is down.
            /// </summary>
            MOUSEEVENTF_LEFTDOWN = 0x0002,

            /// <summary>
            /// The left button is up.
            /// </summary>
            MOUSEEVENTF_LEFTUP = 0x0004,

            /// <summary>
            /// The middle button is down.
            /// </summary>
            MOUSEEVENTF_MIDDLEDOWN = 0x0020,

            /// <summary>
            /// The middle button is up.
            /// </summary>
            MOUSEEVENTF_MIDDLEUP = 0x0040,

            /// <summary>
            /// Movement occurred.
            /// </summary>
            MOUSEEVENTF_MOVE = 0x0001,

            /// <summary>
            /// The right button is down.
            /// </summary>
            MOUSEEVENTF_RIGHTDOWN = 0x0008,

            /// <summary>
            /// The right button is up.
            /// </summary>
            MOUSEEVENTF_RIGHTUP = 0x0010,

            /// <summary>
            /// The wheel has been moved, if the mouse has a wheel.
            /// </summary>
            MOUSEEVENTF_WHEEL = 0x0800,

            /// <summary>
            /// An X button was pressed.
            /// </summary>
            MOUSEEVENTF_XDOWN = 0x0080,

            /// <summary>
            /// An X button was released.
            /// </summary>
            MOUSEEVENTF_XUP = 0x0100,

            /// <summary>
            /// The wheel button is tilted.
            /// </summary>
            MOUSEEVENTF_HWHEEL = 0x1000,
        }

        /// <summary>
        /// Gets or sets the application's top-level window handle.
        /// </summary>
        public static IntPtr HwndTop
        {
            get { return User32._hwndTop; }
            set { User32._hwndTop = value; }
        }

        /// <summary>
        /// Blocks keyboard and mouse input events from reaching applications.
        /// </summary>
        /// <param name="block">If this parameter is TRUE, keyboard and mouse input events are blocked.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If input is already blocked, the return value is zero.</returns>
        [DllImport("user32.dll")]
        public static extern bool BlockInput(bool block);

        /// <summary>
        /// rings the specified window to the top of the Z order. If the window is a top-level window, it is activated. 
        /// If the window is a child window, the top-level parent window associated with the child window is activated.
        /// </summary>
        /// <param name="handle">A handle to the window to bring to the top of the Z order.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32.dll")]
        public static extern bool BringWindowToTop(IntPtr handle);

        /// <summary>
        /// Enumerates the child windows that belong to the specified parent window by passing the handle to each child window, in turn, to an application-defined callback function. 
        /// Enumeration Child Windows continues until the last child window is enumerated or the callback function returns FALSE.
        /// </summary>
        /// <param name="parentHandle">A handle to the parent window whose child windows are to be enumerated.</param>
        /// <param name="windowsProc">A pointer to an application-defined callback function.</param>
        /// <param name="param">An application-defined value to be passed to the callback function.</param>
        /// <returns>The return value is not used.</returns>
        [DllImport("user32.dll")]
        public static extern bool EnumChildWindows(IntPtr parentHandle, EnumWindowsProc windowsProc, IntPtr param);

        /// <summary>
        /// Enumerates all top-level windows on the screen by passing the handle to each window, in turn, to an application-defined callback function. 
        /// Enumeration Windows continues until the last top-level window is enumerated or the callback function returns FALSE.
        /// </summary>
        /// <param name="windowsProc">A pointer to an application-defined callback function. </param>
        /// <param name="param">An application-defined value to be passed to the callback function.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32")]
        public static extern bool EnumWindows(EnumWindowsProc windowsProc, IntPtr param);

        /// <summary>
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings. 
        /// This function does not search child windows. This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="className">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function.</param>
        /// <param name="windowName">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class name and window name.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string className, string windowName);

        /// <summary>
        /// Retrieves a handle to a window whose class name and window name match the specified strings.
        /// </summary>
        /// <param name="parentHandle">A handle to the parent window whose child windows are to be searched.</param>
        /// <param name="childAfter">A handle to a child window.</param>
        /// <param name="className">The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function.</param>
        /// <param name="windowTitle">The window name (the window's title). If this parameter is NULL, all window names match.</param>
        /// <returns>If the function succeeds, the return value is a handle to the window that has the specified class and window names.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, int childAfter, string className, string windowTitle);

        /// <summary>
        /// Retrieves the position of the mouse cursor, in screen coordinates.
        /// </summary>
        /// <param name="point">A pointer to a POINT structure that receives the screen coordinates of the cursor.</param>
        /// <returns>Returns nonzero if successful or zero otherwise.</returns>
        [DllImport("user32.dll")]
        public static extern long GetCursorPos(ref Point point);

        /// <summary>
        /// Retrieves the identifier of the specified control.
        /// </summary>
        /// <param name="handle">A handle to the control.</param>
        /// <returns>If the function succeeds, the return value is the identifier of the control.</returns>
        [DllImport("user32.dll")]
        public static extern int GetDlgCtrlID(IntPtr handle);

        /// <summary>
        /// Retrieves a handle to a control in the specified dialog box.
        /// </summary>
        /// <param name="handle">A handle to the dialog box that contains the control.</param>
        /// <param name="item">The identifier of the control to be retrieved.</param>
        /// <returns>If the function succeeds, the return value is the window handle of the specified control.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDlgItem(IntPtr handle, int item);

        /// <summary>
        /// Retrieves the title or text associated with a control in a dialog box.
        /// </summary>
        /// <param name="handle">A handle to the dialog box that contains the control.</param>
        /// <param name="item">The identifier of the control whose title or text is to be retrieved.</param>
        /// <param name="text">The buffer to receive the title or text.</param>
        /// <param name="maxCount">The maximum length, in characters, of the string to be copied to the buffer pointed to by lpString. 
        /// If the length of the string, including the null character, exceeds the limit, the string is truncated.</param>
        /// <returns>If the function succeeds, the return value specifies the number of characters copied to the buffer, not including the terminating null character.</returns>
        [DllImport("user32.dll")]
        public static extern uint GetDlgItemText(IntPtr handle, int item, [Out] StringBuilder text, int maxCount);

        /// <summary>
        /// Retrieves the handle to the window that has the keyboard focus, if the window is attached to the calling thread's message queue.
        /// </summary>
        /// <returns>The return value is the handle to the window with the keyboard focus. 
        /// If the calling thread's message queue does not have an associated window with the keyboard focus, the return value is NULL.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();

        /// <summary>
        /// Retrieves a handle to the specified window's parent or owner.
        /// </summary>
        /// <param name="handle">A handle to the window whose parent window handle is to be retrieved.</param>
        /// <returns>If the window is a child window, the return value is a handle to the parent window. If the window is a top-level window with the WS_POPUP style, 
        /// the return value is a handle to the owner window.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetParent(IntPtr handle);

        /// <summary>
        /// Retrieves a handle to a window that has the specified relationship (Z-Order or owner) to the specified window.
        /// </summary>
        /// <param name="handle">A handle to a window. The window handle retrieved is relative to this window, based on the value of the command parameter.</param>
        /// <param name="cmd">The relationship between the specified window and the window whose handle is to be retrieved.</param>
        /// <returns>If the function succeeds, the return value is a window handle. If no window exists with the specified relationship to the specified window, the return value is NULL.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr handle, uint cmd);

        /// <summary>
        /// Retrieves the device context (DC) for the entire window, including title bar, menus, and scroll bars. 
        /// A window device context permits painting anywhere in a window, because the origin of the device context is the upper-left corner of the window instead of the client area.
        /// </summary>
        /// <param name="handle">A handle to the window with a device context that is to be retrieved. If this value is NULL, GetWindowDC retrieves the device context for the entire screen.</param>
        /// <returns>If the function succeeds, the return value is a handle to a device context for the specified window.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr handle);

        /// <summary>
        /// Retrieves information about the specified window. The function also retrieves the 32-bit (DWORD) value at the specified offset into the extra window memory.
        /// </summary>
        /// <param name="handle">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="index">The zero-based offset to the value to be retrieved.</param>
        /// <returns>If the function succeeds, the return value is the requested value.</returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong32(IntPtr handle, int index);

        /// <summary>
        /// Retrieves information about the specified window. The function also retrieves the value at a specified offset into the extra window memory.
        /// </summary>
        /// <param name="handle">A handle to the window and, indirectly, the class to which the window belongs.</param>
        /// <param name="index">The zero-based offset to the value to be retrieved.</param>
        /// <returns>If the function succeeds, the return value is the requested value.</returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        public static extern IntPtr GetWindowLongPtr64(IntPtr handle, int index);

        /// <summary>
        /// Retrieves the dimensions of the bounding rectangle of the specified window. The dimensions are given in screen coordinates that are relative to the upper-left corner of the screen.
        /// </summary>
        /// <param name="handle">A handle to the window.</param>
        /// <param name="rect">A pointer to a RECT structure that receives the screen coordinates of the upper-left and lower-right corners of the window.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr handle, out PInvoke.RECT rect);

        /// <summary>
        /// Copies the text of the specified window's title bar (if it has one) into a buffer. If the specified window is a control, the text of the control is copied. 
        /// However, GetWindowText cannot retrieve the text of a control in another application.
        /// </summary>
        /// <param name="handle">A handle to the window or control containing the text.</param>
        /// <param name="text">The buffer that will receive the text. If the string is as long or longer than the buffer, the string is truncated and terminated with a null character.</param>
        /// <param name="maxCount">The maximum number of characters to copy to the buffer, including the null character. If the text exceeds this limit, it is truncated.</param>
        /// <returns>If the function succeeds, the return value is the length, in characters, of the copied string, not including the terminating null character. 
        /// If the window has no title bar or text, if the title bar is empty, or if the window or control handle is invalid, the return value is zero.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr handle, [Out] StringBuilder text, int maxCount);

        /// <summary>
        /// Retrieves the length, in characters, of the specified window's title bar text (if the window has a title bar). 
        /// If the specified window is a control, the function retrieves the length of the text within the control. 
        /// However, GetWindowTextLength cannot retrieve the length of the text of an edit control in another application.
        /// </summary>
        /// <param name="handle">A handle to the window or control.</param>
        /// <returns>If the function succeeds, the return value is the length, in characters, of the text. 
        /// Under certain conditions, this value may actually be greater than the length of the text.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowTextLength(IntPtr handle);

        /// <summary>
        /// Determines whether the specified window is enabled for mouse and keyboard input.
        /// </summary>
        /// <param name="handle">A handle to the window to be tested.</param>
        /// <returns>If the window is enabled, the return value is nonzero.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int IsWindowEnabled(IntPtr handle);

        /// <summary>
        /// Determines whether a button control is checked or whether a three-state button control is checked, unchecked, or indeterminate.
        /// </summary>
        /// <param name="handle">A handle to the dialog box that contains the button control.</param>
        /// <param name="controlId">The identifier of the button control.</param>
        /// <returns>The return value from a button created with the BS_AUTOCHECKBOX, BS_AUTORADIOBUTTON, BS_AUTO3STATE, BS_CHECKBOX, BS_RADIOBUTTON, or BS_3STATE styles can be one of the values in the table on MSDN.
        /// If the button has any other style, the return value is zero.</returns>
        [DllImport("user32.dll")]
        public static extern int IsDlgButtonChecked(IntPtr handle, int controlId);

        /// <summary>
        /// Determines the visibility state of the specified window.
        /// </summary>
        /// <param name="handle">A handle to the window to be tested.</param>
        /// <returns>If the specified window, its parent window, its parent's parent window, and so forth, have the WS_VISIBLE style, the return value is nonzero. 
        /// Otherwise, the return value is zero.</returns>
        [DllImport("user32.dll")]
        public static extern int IsWindowVisible(IntPtr handle);

        /// <summary>
        /// Changes the position and dimensions of the specified window. For a top-level window, the position and dimensions are relative to the upper-left corner of the screen. 
        /// For a child window, they are relative to the upper-left corner of the parent window's client area.
        /// </summary>
        /// <param name="handle">A handle to the window.</param>
        /// <param name="x">The new position of the left side of the window.</param>
        /// <param name="y">The new position of the top of the window.</param>
        /// <param name="width">The new width of the window.</param>
        /// <param name="height">The new height of the window.</param>
        /// <param name="repaint">Indicates whether the window is to be repainted. If this parameter is TRUE, the window receives a message. If the parameter is FALSE, no repainting of any kind occurs.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool repaint);

        /// <summary>
        /// Retrieves a string that specifies the window type.
        /// </summary>
        /// <param name="handle">A handle to the window whose type will be retrieved.</param>
        /// <param name="text">A pointer to a string that receives the window type.</param>
        /// <param name="type">The length, in characters, of the buffer pointed to by the zero-terminated PSZ parameter.</param>
        /// <returns>If the function succeeds, the return value is the number of characters copied to the specified buffer. If the function fails, the return value is zero.</returns>
        [DllImport("user32.dll")]
        public static extern uint RealGetWindowClass(IntPtr handle, [Out] StringBuilder text, uint type);

        /// <summary>
        ///  Releases a device context (DC), freeing it for use by other applications. 
        ///  The effect of the ReleaseDC function depends on the type of DC. It frees only common and window DCs. It has no effect on class or private DCs.
        /// </summary>
        /// <param name="handle">A handle to the window whose DC is to be released.</param>
        /// <param name="hdc">A handle to the DC to be released.</param>
        /// <returns>The return value indicates whether the DC was released. If the DC was released, the return value is 1.</returns>
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

        /// <summary>
        /// Sends a message to the specified control in a dialog box.
        /// </summary>
        /// <param name="handle">A handle to the dialog box that contains the control.</param>
        /// <param name="id">The identifier of the control that receives the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="index">Message index</param>
        /// <param name="buffer">Additional message-specific information.</param>
        [DllImport("user32.dll", EntryPoint = "SendDlgItemMessage")]
        public static extern void SendDlgItemMessage(IntPtr handle, int id, uint message, int index, StringBuilder buffer);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr handle, uint message, int wparam, int lparam);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr handle, uint message, int wparam, string lparam);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr handle, uint message, int wparam, StringBuilder lparam);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr handle, uint message, int wparam, ref StringBuilder lparam);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="rect">Rectangle pointer</param>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(IntPtr handle, uint message, IntPtr wparam, ref RECT rect);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr handle, uint message, IntPtr wparam, ref StringBuilder lparam);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr handle, uint message, IntPtr wparam, IntPtr lparam);

        /// <summary>
        /// Sends the specified message to a window or windows.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure will receive the message.</param>
        /// <param name="message">The message to be sent.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr handle, uint message, IntPtr wparam, string lparam);

        /// <summary>
        /// Places (posts) a message in the message queue associated with the thread that created the specified window and returns without waiting for the thread to process the message.
        /// </summary>
        /// <param name="handle">A handle to the window whose window procedure is to receive the message.</param>
        /// <param name="message">The message to be posted.</param>
        /// <param name="wparam">Additional message-specific information.</param>
        /// <param name="lparam">Additional message-specific information</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr handle, uint message, IntPtr wparam, IntPtr lparam);

        /// <summary>
        /// Activates a window. The window must be attached to the calling thread's message queue.
        /// </summary>
        /// <param name="handle">A handle to the top-level window to be activated.</param>
        /// <returns>If the function succeeds, the return value is the handle to the window that was previously active.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetActiveWindow(IntPtr handle);

        /// <summary>
        /// Sets the cursor shape.
        /// </summary>
        /// <param name="cursor">A handle to the cursor. The cursor must have been created by the CreateCursor function or loaded by the LoadCursor or LoadImage function. 
        /// If this parameter is NULL, the cursor is removed from the screen.</param>
        /// <returns>The return value is the handle to the previous cursor, if there was one.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetCursor(IntPtr cursor);

        /// <summary>
        /// Moves the cursor to the specified screen coordinates. If the new coordinates are not within the screen rectangle set by the most recent ClipCursor function call, 
        /// the system automatically adjusts the coordinates so that the cursor stays within the rectangle.
        /// </summary>
        /// <param name="x">The new x-coordinate of the cursor, in screen coordinates.</param>
        /// <param name="y">The new y-coordinate of the cursor, in screen coordinates.</param>
        /// <returns>Returns nonzero if successful or zero otherwise.</returns>
        [DllImport("user32.dll")]
        public static extern long SetCursorPos(int x, int y);

        /// <summary>
        /// Sets the keyboard focus to the specified window. The window must be attached to the calling thread's message queue.
        /// </summary>
        /// <param name="handle">A handle to the window that will receive the keyboard input. If this parameter is NULL, keystrokes are ignored.</param>
        /// <returns>If the function succeeds, the return value is the handle to the window that previously had the keyboard focus.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr handle);

        /// <summary>
        /// Brings the thread that created the specified window into the foreground and activates the window. Keyboard input is directed to the window, and various visual cues are changed for the user. 
        /// The system assigns a slightly higher priority to the thread that created the foreground window than it does to other threads.
        /// </summary>
        /// <param name="handle">A handle to the window that should be activated and brought to the foreground.</param>
        /// <returns>If the window was brought to the foreground, the return value is nonzero.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr handle);

        /// <summary>
        /// Changes the size, position, and Z order of a child, pop-up, or top-level window. These windows are ordered according to their appearance on the screen. 
        /// The topmost window receives the highest rank and is the first window in the Z order.
        /// </summary>
        /// <param name="handle">A handle to the window.</param>
        /// <param name="insertAfter">A handle to the window to precede the positioned window in the Z order. This parameter must be a window handle or one of the following values.</param>
        /// <param name="x">The new position of the left side of the window, in client coordinates.</param>
        /// <param name="y">The new position of the top of the window, in client coordinates.</param>
        /// <param name="cx">The new width of the window, in pixels.</param>
        /// <param name="cy">The new height of the window, in pixels.</param>
        /// <param name="flags">The window sizing and positioning flags.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr handle, IntPtr insertAfter, int x, int y, int cx, int cy, uint flags);

        /// <summary>
        /// Changes the text of the specified window's title bar (if it has one). If the specified window is a control, the text of the control is changed. However, SetWindowText cannot change the text of a control in another application.
        /// </summary>
        /// <param name="handle">A handle to the window or control whose text is to be changed.</param>
        /// <param name="text">The new title or control text.</param>
        /// <returns>If the function succeeds, the return value is nonzero.</returns>
        [DllImport("user32.dll")]
        public static extern bool SetWindowText(IntPtr handle, string text);

        /// <summary>
        /// Sets the specified window's show state.
        /// </summary>
        /// <param name="handle">A handle to the window.</param>
        /// <param name="show">Controls how the window is to be shown.</param>
        /// <returns>If the window was previously visible, the return value is nonzero.</returns>
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr handle, int show);

        /// <summary>
        /// Determines which, if any, of the child windows belonging to a parent window contains the specified point. 
        /// The search is restricted to immediate child windows. Grandchildren, and deeper descendant windows are not searched.
        /// </summary>
        /// <param name="parentHandle">A handle to the parent window.</param>
        /// <param name="point">A structure that defines the client coordinates, relative to the parent, of the point to be checked.</param>
        /// <returns>The return value is a handle to the child window that contains the point, even if the child window is hidden or disabled. 
        /// If the point lies outside the parent window, the return value is NULL. If the point is within the parent window but not within any child window, 
        /// the return value is a handle to the parent window.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr ChildWindowFromPoint(IntPtr parentHandle, Point point);

        /// <summary>
        /// Retrieves a handle to the desktop window. The desktop window covers the entire screen. The desktop window is the area on top of which other windows are painted.
        /// </summary>
        /// <returns>The return value is a handle to the desktop window.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// </summary>
        /// <param name="numberOfInputs">The number of structures in the input array.</param>
        /// <param name="inputs">An array of INPUT structures. Each structure represents an event to be inserted into the keyboard or mouse input stream.</param>
        /// <param name="sizeOfInputStructure">The size, in bytes, of an INPUT structure. If not the size of an INPUT structure, the function fails.</param>
        /// <returns>The function returns the number of events that it successfully inserted into the keyboard or mouse input stream. 
        /// If the function returns zero, the input was already blocked by another thread.</returns>
        [DllImport("user32.dll")]
        public static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

        /// <summary>
        /// Synthesizes a keystroke. 
        /// Note: This function has been superseded. Use SendInput instead.
        /// </summary>
        /// <param name="vk">A virtual-key code. The code must be a value in the range 1 to 254.</param>
        /// <param name="scan">A hardware scan code for the key.</param>
        /// <param name="flags">Controls various aspects of function operation.</param>
        /// <param name="extrainfo">An additional value associated with the key stroke.</param>
        [DllImport("user32.dll", EntryPoint = "keybd_event", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void keybd_event(byte vk, byte scan, int flags, int extrainfo);

        /// <summary>
        /// Synthesizes a keystroke. 
        /// Note: This function has been superseded. Use SendInput instead.
        /// </summary>
        /// <param name="vk">A virtual-key code. The code must be a value in the range 1 to 254.</param>
        /// <param name="scan">A hardware scan code for the key.</param>
        /// <param name="flags">Controls various aspects of function operation.</param>
        /// <param name="extrainfo">An additional value associated with the key stroke.</param>
        [DllImport("user32.dll", EntryPoint = "keybd_event", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void keybd_event(int vk, byte scan, int flags, int extrainfo);

        /// <summary>
        /// The mouse_event function synthesizes mouse motion and button clicks.
        /// Note: This function has been superseded. Use SendInput instead.
        /// </summary>
        /// <param name="flags">Controls various aspects of mouse motion and button clicking.</param>
        /// <param name="dx">The mouse's absolute position along the x-axis or its amount of motion since the last mouse event was generated, depending on the setting of MOUSEEVENTF_ABSOLUTE.</param>
        /// <param name="dy">The mouse's absolute position along the y-axis or its amount of motion since the last mouse event was generated, depending on the setting of MOUSEEVENTF_ABSOLUTE.</param>
        /// <param name="delta">Specifies data based on the flag. Check MSDN for more details.</param>
        /// <param name="extraInfo">An additional value associated with the mouse event.</param>
        [DllImport("user32.dll")]
        public static extern void mouse_event(MouseEventFlags flags, uint dx, uint dy, uint delta, IntPtr extraInfo);
    }
}
