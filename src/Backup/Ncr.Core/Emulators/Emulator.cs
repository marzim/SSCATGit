// <copyright file="Emulator.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Threading;
    using Ncr.Core.PInvoke;
    using Ncr.Core.Util;
    
    /// <summary>
    /// Initializes a new instance of the Emulator class
    /// </summary>
    public abstract class Emulator : AbstractApplication, IEmulator
    {
        // CADD V30.3.0.194E Support

        /// <summary>
        /// Scanner caption
        /// </summary>
        public static readonly string ScannerCaption = RegistryAddress.ScannerCaption;

        /// <summary>
        /// Bag scale caption
        /// </summary>
        public static readonly string BagScaleCaption = RegistryAddress.BagScaleCaption;

        /// <summary>
        /// Scale caption
        /// </summary>
        public static readonly string ScaleCaption = RegistryAddress.ScaleCaption;

        /// <summary>
        /// Cash acceptor caption
        /// </summary>
        public static readonly string CashAcceptorCaption = RegistryAddress.CashAcceptorCaption;

        /// <summary>
        /// Cash trough caption
        /// </summary>
        public static readonly string CashTroughCaption = RegistryAddress.CashTroughCaption;

        /// <summary>
        /// Coin acceptor caption
        /// </summary>
        public static readonly string CoinAcceptorCaption = RegistryAddress.CoinAcceptorCaption;

        /// <summary>
        /// Coin changer caption
        /// </summary>
        public static readonly string CoinChangerCaption = RegistryAddress.CoinChangerCaption;

        /// <summary>
        /// Bill changer caption
        /// </summary>
        public static readonly string BillChangerCaption = RegistryAddress.BillChangerCaption;

        /// <summary>
        /// MSR caption
        /// </summary>
        public static readonly string MsrCaption = RegistryAddress.MsrCaption;

        /// <summary>
        /// Pin pad caption
        /// </summary>
        public static readonly string PinPadCaption = RegistryAddress.PinPadCaption;

        /// <summary>
        /// PC signature capture caption
        /// </summary>
        public static readonly string PCSignatureCaptureCaption = RegistryAddress.PCSignatureCaptureCaption;

        /// <summary>
        /// POS printer caption
        /// </summary>
        public static readonly string PosPrinterCaption = RegistryAddress.PosPrinterCaption;

        /// <summary>
        /// Motion sensor caption
        /// </summary>
        public static readonly string MotionSensorCaption = RegistryAddress.MotionSensorCaption;

        /// <summary>
        /// Lane class name
        /// </summary>
        public static readonly string LaneClassName = "UIControlWindowClass";

        /// <summary>
        /// Lane caption
        /// </summary>
        public static readonly string LaneCaption = "NCR SCOT";

        /// <summary>
        /// Next gen UI caption
        /// </summary>
        public static readonly string NextGenUICaption = "NCR NEXTGENUI";

        /// <summary>
        /// Next gen UI class name
        /// </summary>
        public static readonly string NextGenUIClassName = "Window";

        /// <summary>
        /// Launch pad net caption
        /// </summary>
        public static readonly string LaunchPadNetCaption = "LaunchPadNet";

        /// <summary>
        /// RAP caption
        /// </summary>
        public static readonly string RapCaption = "RAP.NET";

        /// <summary>
        /// Emulator items
        /// </summary>
        private Dictionary<string, int> _controls;        

        /// <summary>
        /// Emulator type
        /// </summary>
        private string _type;

        /// <summary>
        /// Initializes a new instance of the Emulator class
        /// </summary>
        /// <param name="caption">caption text</param>
        public Emulator(string caption)
            : this("#32770", caption)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Emulator class
        /// </summary>
        /// <param name="type">emulator type</param>
        /// <param name="caption">caption text</param>
        public Emulator(string type, string caption)
            : base(caption)
        {
            Type = type;
            Controls = new Dictionary<string, int>();
        }

        /// <summary>
        /// Event handler for emulating
        /// </summary>
        public event EventHandler<EmulatorEventArgs> Emulating;

        /// <summary>
        /// Gets the file name
        /// </summary>
        public override string FileName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the process name
        /// </summary>
        public override string ProcessName
        {
            get { return Caption; }
        }

        /// <summary>
        /// Gets the handle
        /// </summary>
        public virtual IntPtr Handle
        {
            get { return ApiHelper.FindWindow(_type, Caption); }
        }

        /// <summary>
        /// Gets the NGUI handle
        /// </summary>
        public IntPtr NGUIHandle
        {
            get { return ApiHelper.FindWindow(_type, Caption); }
        }

        /// <summary>
        /// Gets or sets controls
        /// </summary>
        public Dictionary<string, int> Controls
        {
            get { return _controls; }
            set { _controls = value; }
        }
        
        /// <summary>
        /// Gets or sets the type
        /// </summary>
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Checks if handle is available
        /// </summary>
        /// <returns>Returns true if available, false otherwise</returns>
        public virtual bool Available()
        {
            return Handle != IntPtr.Zero;
        }

        /// <summary>
        /// Click at given point
        /// </summary>
        /// <param name="point">point coordinates</param>
        public virtual void ClickAt(Point point)
        {
            ClickAt(point.X, point.Y);
        }

        /// <summary>
        /// Click at given coordinates
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        public virtual void ClickAt(int x, int y)
        {
            if (Handle != IntPtr.Zero)
            {
                int param = (y * 0x10000) + x;
                ApiHelper.SetForegroundWindow(Handle);
                ApiHelper.SendMessage(Handle, User32.WM_MOUSEACTIVE, 0, 0);
                ApiHelper.SendMessage(Handle, User32.WM_LBUTTONDOWN, 0, param);
                Thread.Sleep(10);
                ApiHelper.SendMessage(Handle, User32.WM_LBUTTONUP, 0, param);
            }
        }

        /// <summary>
        /// Click button with given control ID
        /// </summary>
        /// <param name="controlKey">control key</param>
        /// <param name="timeout">timeout amount</param>
        protected virtual void ClickButton(string controlKey, int timeout)
        {
            ClickButton(string.Empty, controlKey, timeout);
        }

        /// <summary>
        /// Click button with given control ID
        /// </summary>
        /// <param name="dialogControlKey">dialog control key</param>
        /// <param name="controlKey">control key</param>
        /// <param name="timeout">timeout amount</param>
        protected virtual void ClickButton(string dialogControlKey, string controlKey, int timeout)
        {
            try
            {
                if (!Available())
                {
                    throw new EmulatorNotFoundException(Caption);
                }

                IntPtr parentHandle = Handle;
                if (!dialogControlKey.Equals(string.Empty))
                {
                    parentHandle = ApiHelper.GetDlgItem(Handle, Convert.ToInt32(Controls[dialogControlKey]));
                    if (parentHandle == IntPtr.Zero)
                    {
                        throw new EmulatorItemNotFoundException(Caption, Controls[dialogControlKey].ToString());
                    }
                }

                IntPtr itemHandle = ApiHelper.GetDlgItem(parentHandle, Convert.ToInt32(Controls[controlKey]));
                if (itemHandle == IntPtr.Zero)
                {
                    throw new EmulatorItemNotFoundException(Caption, Controls[controlKey].ToString());
                }

                if (!Available(itemHandle, timeout))
                {
                    throw new EmulatorTimeoutException(Caption);
                }

                Activate();
                SetFocus(itemHandle);
                ApiHelper.SendMessage(itemHandle, User32.WM_MOUSEACTIVE, 0, 0);
                if ((Convert.ToInt32(Controls[controlKey]) == 0x3f4) || (Convert.ToInt32(Controls[controlKey]) == 0x3ef))
                {
                    ApiHelper.ShowWindow(Handle, User32.SW_SHOWNORMAL);
                }

                ApiHelper.SendMessage(itemHandle, User32.WM_LBUTTONDOWN, 0, 0);
                ApiHelper.SendMessage(itemHandle, User32.WM_LBUTTONUP, 0, 0);
                if ((Convert.ToInt32(Controls[controlKey]) == 0x3f4) || (Convert.ToInt32(Controls[controlKey]) == 0x3ef))
                {
                    ApiHelper.ShowWindow(Handle, User32.SW_SHOWMINIMIZED);
                }

                LeaveFocus(itemHandle);
            }
            catch
            {
                throw;
            }
            finally
            {
                Minimize();
            }
        }

        /// <summary>
        /// Check box
        /// </summary>
        /// <param name="controlKey">control key</param>
        /// <param name="timeout">timeout amount</param>
        protected virtual void CheckBox(string controlKey, int timeout)
        {
            try
            {
                if (!Available())
                {
                    throw new EmulatorNotFoundException(Caption);
                }

                IntPtr itemHandle = ApiHelper.GetDlgItem(Handle, Convert.ToInt32(Controls[controlKey]));
                ApiHelper.SendDlgItemMessage(Handle, Convert.ToInt32(Controls[controlKey]), User32.BM_SETCHECK, Convert.ToInt32(User32.BST_UNCHECKED), null);
                if (itemHandle == IntPtr.Zero)
                {
                    throw new EmulatorItemNotFoundException(Caption, Controls[controlKey].ToString());
                }

                if (!Available(itemHandle, timeout))
                {
                    throw new EmulatorTimeoutException(Caption);
                }

                Activate();
                SetFocus(itemHandle);
                ApiHelper.SendMessage(itemHandle, User32.WM_MOUSEACTIVE, 0, 0);
                ApiHelper.SendMessage(itemHandle, User32.WM_LBUTTONDOWN, 0, 0);
                ApiHelper.SendMessage(itemHandle, User32.WM_LBUTTONUP, 0, 0);
                LeaveFocus(itemHandle);
            }
            catch
            {
                throw;
            }
            finally
            {
                Minimize();
            }
        }

        /// <summary>
        /// Get text
        /// </summary>
        /// <param name="controlKey">Control Key</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns the text</returns>
        protected virtual string GetText(string controlKey, int timeout)
        {
            return GetText(string.Empty, controlKey, timeout);
        }

        /// <summary>
        /// Get text
        /// </summary>
        /// <param name="dialogControlKey">dialog control key</param>
        /// <param name="controlKey">control Key</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns the text</returns>
        protected virtual string GetText(string dialogControlKey, string controlKey, int timeout)
        {
            if (!Available())
            {
                throw new EmulatorNotFoundException(Caption);
            }

            IntPtr parentHandle = Handle;
            if (!dialogControlKey.Equals(string.Empty))
            {
                parentHandle = ApiHelper.GetDlgItem(Handle, Convert.ToInt32(Controls[dialogControlKey]));
                if (parentHandle == IntPtr.Zero)
                {
                    throw new EmulatorItemNotFoundException(Caption, Controls[dialogControlKey].ToString());
                }
            }

            IntPtr itemHandle = ApiHelper.GetDlgItem(parentHandle, Convert.ToInt32(Controls[controlKey]));
            if (itemHandle == IntPtr.Zero)
            {
                throw new EmulatorItemNotFoundException(Caption, Controls[controlKey].ToString());
            }

            if (!Available(itemHandle, timeout))
            {
                throw new EmulatorTimeoutException(Caption);
            }

            int capacity = (int)ApiHelper.SendMessage(itemHandle, User32.WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero);
            StringBuilder sb = new StringBuilder();
            sb.EnsureCapacity(capacity);
            ApiHelper.SendMessage(itemHandle, User32.WM_GETTEXT, capacity + 1, sb);
            return sb.ToString();
        }

        /// <summary>
        /// Select index
        /// </summary>
        /// <param name="controlKey">Control Key</param>
        /// <param name="index">selected index</param>
        /// <param name="timeout">timeout amount</param>
        protected virtual void SelectIndex(string controlKey, int index, int timeout)
        {
            SelectIndex(string.Empty, controlKey, index, timeout);
        }

        /// <summary>
        /// Select index
        /// </summary>
        /// <param name="dialogControlKey">parent dialog control key</param>
        /// <param name="controlKey">control Key</param>
        /// <param name="index">selected index</param>
        /// <param name="timeout">timeout amount</param>
        protected virtual void SelectIndex(string dialogControlKey, string controlKey, int index, int timeout)
        {
            try
            {
                if (!Available())
                {
                    throw new EmulatorNotFoundException(Caption);
                }

                IntPtr parentHandle = Handle;
                if (!dialogControlKey.Equals(string.Empty))
                {
                    parentHandle = ApiHelper.GetDlgItem(Handle, Convert.ToInt32(Controls[dialogControlKey]));
                    if (parentHandle == IntPtr.Zero)
                    {
                        throw new EmulatorItemNotFoundException(Caption, Controls[dialogControlKey].ToString());
                    }
                }

                IntPtr itemHandle = ApiHelper.GetDlgItem(parentHandle, Convert.ToInt32(Controls[controlKey]));
                if (itemHandle == IntPtr.Zero)
                {
                    throw new EmulatorItemNotFoundException(Caption, Controls[controlKey].ToString());
                }

                if (!Available(itemHandle, timeout))
                {
                    throw new EmulatorTimeoutException(Caption);
                }

                Activate();
                SetFocus(itemHandle);
                ApiHelper.SendMessage(itemHandle, User32.CB_SHOWDROPDOWN, 1, 0);
                ApiHelper.SendMessage(itemHandle, User32.WM_KEYDOWN, User32.VK_DOWN, 0);
                ApiHelper.SendMessage(itemHandle, User32.CB_SETCURSEL, index, 0);
                ApiHelper.SendMessage(itemHandle, User32.WM_LBUTTONDOWN, 1, -1);
                ApiHelper.SendMessage(itemHandle, User32.WM_LBUTTONUP, 1, -1);
                ApiHelper.SendMessage(itemHandle, User32.CB_SHOWDROPDOWN, 0, 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                Minimize();
            }
        }

        /// <summary>
        /// Select index
        /// </summary>
        /// <param name="controlKey">Control Key</param>
        /// <param name="text">selected index text</param>
        /// <param name="timeout">timeout amount</param>
        protected virtual void SelectIndex(string controlKey, string text, int timeout)
        {
            SelectIndex(string.Empty, controlKey, text, timeout);
        }

        /// <summary>
        /// Select index
        /// </summary>
        /// <param name="dialogControlKey">dialog control key</param>
        /// <param name="controlKey">Control Key</param>
        /// <param name="text">selected index text</param>
        /// <param name="timeout">timeout amount</param>
        protected virtual void SelectIndex(string dialogControlKey, string controlKey, string text, int timeout)
        {
            int index = GetComboBoxIndex(dialogControlKey, controlKey, text, timeout);
            if (index.Equals(-1))
            {
                throw new EmulatorItemNotFoundException(Caption, Controls[controlKey].ToString());
            }

            SelectIndex(dialogControlKey, controlKey, index, timeout);
        }

        /// <summary>
        /// Set text 2
        /// </summary>
        /// <param name="controlKey">Control Key</param>
        /// <param name="text">text to set</param>
        /// <param name="timeout">timeout amount</param>
        protected virtual void SetText(string controlKey, string text, int timeout)
        {
            try
            {
                if (!Available())
                {
                    throw new EmulatorNotFoundException(Caption);
                }

                IntPtr itemHandle = ApiHelper.GetDlgItem(Handle, Convert.ToInt32(Controls[controlKey]));
                if (itemHandle == IntPtr.Zero)
                {
                    throw new EmulatorItemNotFoundException(Caption, Controls[controlKey].ToString());
                }

                if (!Available(itemHandle, timeout))
                {
                    throw new EmulatorTimeoutException(Caption);
                }

                Activate();
                SetFocus(itemHandle);
                ApiHelper.SendMessage(itemHandle, User32.WM_SETTEXT, (int)(text.Length + 1), text);
                LeaveFocus(itemHandle);
            }
            catch
            {
                throw;
            }
            finally
            {
                Minimize();
            }
        }

        /// <summary>
        /// Checks if handle is available
        /// </summary>
        /// <param name="handle">application handle</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns true if available, false otherwise</returns>
        protected virtual bool Available(IntPtr handle, int timeout)
        {
            int now = Environment.TickCount;
            int i = 0;
            while ((Environment.TickCount - now) < timeout)
            {
                if (i++ % (42 * 3) == 5)
                {
                    OnEmulating("Checking emulator's availability...");
                }

                if ((ApiHelper.IsWindowVisible(handle) > 0) && (ApiHelper.IsWindowEnabled(handle) > 0))
                {
                    return true;
                }

                ThreadHelper.Sleep(100);
            }

            return false;
        }

        /// <summary>
        /// Emulate and pass given message
        /// </summary>
        /// <param name="message">emulator message</param>
        protected virtual void OnEmulating(string message)
        {
            OnEmulating(new EmulatorEventArgs(message));
        }

        /// <summary>
        /// Event on emulating
        /// </summary>
        /// <param name="e">emulator event arguments</param>
        protected virtual void OnEmulating(EmulatorEventArgs e)
        {
            if (Emulating != null)
            {
                Emulating(this, e);
            }
        }

        /// <summary>
        /// Compare index
        /// </summary>
        /// <param name="controlKey">control key</param>
        /// <param name="text">text of selected index</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns true if index is found, false otherwise</returns>
        protected virtual bool CompareIndex2(string controlKey, string text, int timeout)
        {
            return CompareIndex2(string.Empty, controlKey, text, timeout);
        }
        
        /// <summary>
        /// Compare index
        /// </summary>
        /// <param name="dialogControlKey">dialog control key</param>
        /// <param name="controlKey">control key</param>
        /// <param name="text">text of selected index</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns true if index is found, false otherwise</returns>
        protected virtual bool CompareIndex2(string dialogControlKey, string controlKey, string text, int timeout)
        {
            string selectedIndex = GetText(dialogControlKey, controlKey, timeout);
            return HasIndex(text, selectedIndex);
        }

        /// <summary>
        /// Checks if the text has the index
        /// </summary>
        /// <param name="text">text to check</param>
        /// <param name="selectedIndex">selected index</param>
        /// <returns>Returns true if index found, false otherwise</returns>
        private bool HasIndex(string text, string selectedIndex)
        {
            return string.Equals(text, selectedIndex);
        }

        /// <summary>
        /// Get combo box index
        /// </summary>
        /// <param name="dialogControlKey">Dialog Control Key</param>
        /// <param name="controlKey">Control Key</param>
        /// <param name="text">text to set</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns the combo box index</returns>
        private int GetComboBoxIndex(string dialogControlKey, string controlKey, string text, int timeout)
        {
            try
            {
                if (!Available())
                {
                    throw new EmulatorNotFoundException(Caption);
                }

                IntPtr parentHandle = Handle;
                if (!dialogControlKey.Equals(string.Empty))
                {
                    parentHandle = ApiHelper.GetDlgItem(Handle, Convert.ToInt32(Controls[dialogControlKey]));
                    if (parentHandle == IntPtr.Zero)
                    {
                        throw new EmulatorItemNotFoundException(Caption, Controls[dialogControlKey].ToString());
                    }
                }

                IntPtr itemHandle = ApiHelper.GetDlgItem(parentHandle, Convert.ToInt32(Controls[controlKey]));
                if (itemHandle == IntPtr.Zero)
                {
                    throw new EmulatorItemNotFoundException(Caption, Controls[controlKey].ToString());
                }

                if (!Available(itemHandle, timeout))
                {
                    throw new EmulatorTimeoutException(Caption);
                }

                SetFocus(itemHandle);
                IntPtr handle = ApiHelper.SendMessage(itemHandle, User32.CB_SELECTSTRING, -1, new StringBuilder(text));
                LeaveFocus(itemHandle);
                return handle.ToInt32();
            }
            catch
            {
                throw;
            }
            finally
            {
                Minimize();
            }
        }
                
        /// <summary>
        /// Set application focus
        /// </summary>
        /// <param name="handle">application handle</param>
        private void SetFocus(IntPtr handle)
        {
            ApiHelper.SendMessage(handle, User32.WM_SETFOCUS, 0, 0);
        }

        /// <summary>
        /// Leave focus
        /// </summary>
        /// <param name="handle">application handle</param>
        private void LeaveFocus(IntPtr handle)
        {
            ApiHelper.SendMessage(handle, User32.WM_KILLFOCUS, 0, 0);
        }

        /// <summary>
        /// Activate the handle
        /// </summary>
        private void Activate()
        {
            ApiHelper.SetForegroundWindow(Handle);
        }

        /// <summary>
        /// Minimize the handle
        /// </summary>
        private void Minimize()
        {
            ApiHelper.ShowWindow(Handle, User32.SW_MINIMIZED);
        }
    }
}
