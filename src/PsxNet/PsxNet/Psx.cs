using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace PsxNet
{
    public class Psx : IWin32Window
    {
        #region Initial Constant
        public const string ActionChangeContext = "ChangeContext";
        public const string ActionChangeState = "ChangeState";
        public const string ActionChangeVisible = "ChangeVisible";
        public const string ActionInputText = "InputText";
        public const string ActionScroll = "Scroll";
        public const ushort AltKeyMask = 4;
        public const string CommandCanScroll = "CanScroll";
        public const string CommandCapturePicture = "CapturePicture";
        public const string CommandFindItem = "FindItem";
        public const string CommandGetButtonData = "GetButtonData";
        public const string CommandGetButtonDataList = "GetButtonDataList";
        public const string CommandGetButtonLogo = "GetButtonLogo";
        public const string CommandGetButtonLogoList = "GetButtonLogoList";
        public const string CommandGetButtonPosition = "GetButtonPosition";
        public const string CommandGetButtonState = "GetButtonState";
        public const string CommandGetButtonStateList = "GetButtonStateList";
        public const string CommandGetButtonText = "GetButtonText";
        public const string CommandGetButtonTextList = "GetButtonTextList";
        public const string CommandGetButtonVisible = "GetButtonVisible";
        public const string CommandGetCount = "GetCount";
        public const string CommandGetCurSel = "GetCurSel";
        public const string CommandGetItemHeight = "GetItemHeight";
        public const string CommandGetItemPosition = "GetItemPosition";
        public const string CommandGetItemText = "GetItemText";
        public const string CommandGetSubItemCount = "GetSubItemCount";
        public const string CommandGetSubItemText = "GetSubItemText";
        public const string CommandInsertItem = "InsertItem";
        public const string CommandInsertSubItem = "InsertSubItem";
        public const string CommandPlay = "Play";
        public const string CommandRemoveAllItems = "RemoveAllItems";
        public const string CommandRemoveCachedImage = "RemoveCachedImage";
        public const string CommandRemoveItem = "RemoveItem";
        public const string CommandRemoveSubItem = "RemoveSubItem";
        public const string CommandScroll = "Scroll";
        public const string CommandScrollSelection = "ScrollSelection";
        public const string CommandSetButtonData = "SetButtonData";
        public const string CommandSetButtonDataList = "SetButtonDataList";
        public const string CommandSetButtonLogoList = "SetButtonLogoList";
        public const string CommandSetButtonState = "SetButtonState";
        public const string CommandSetButtonStateList = "SetButtonStateList";
        public const string CommandSetButtonText = "SetButtonText";
        public const string CommandSetButtonTextList = "SetButtonTextList";
        public const string CommandSetButtonVisible = "SetButtonVisible";
        public const string CommandSetColumns = "SetColumns";
        public const string CommandSetCurSel = "SetCurSel";
        public const string CommandSetItem = "SetItem";
        public const string CommandSetSubItem = "SetSubItem";
        public const string CommandStop = "Stop";
        public const string CommandUpdateWindow = "UpdateWindow";
        public const string ControlDisplay = "Display";
        public const ushort ControlKeyMask = 2;
        public const string ControlTypeButton = "Button";
        public const string ControlTypeButtonList = "ButtonList";
        public const string ControlTypeEdit = "Edit";
        public const string ControlTypeFlash = "Flash";
        public const string ControlTypeFlashWndless = "FlashWndless";
        public const string ControlTypeFrame = "Frame";
        public const string ControlTypeLiveVideo = "LiveVideo";
        public const string ControlTypeReceipt = "Receipt";
        public const string ControlTypeStatic = "Static";
        public const string ControlTypeVideo = "Video";
        public const string ControlTypeWindow = "Window";
        public const uint DisplayAll = uint.MaxValue;
        public const uint DisplayAlternate1 = 2;
        public const uint DisplayAlternate2 = 4;
        public const uint DisplayAlternate3 = 8;
        public const uint DisplayAlternate4 = 0x10;
        public const uint DisplayAlternate5 = 0x20;
        public const uint DisplayAlternate6 = 0x40;
        public const uint DisplayAlternate7 = 0x80;
        public const uint DisplayAlternate8 = 0x100;
        public const uint DisplayAlternate9 = 0x200;
        public const uint DisplayStandard = 1;
        public const string EventChangeContext = "ChangeContext";
        public const string EventChangeFocus = "ChangeFocus";
        public const string EventClick = "Click";
        public const string EventConnectRemote = "ConnectRemote";
        public const string EventDisconnectRemote = "DisconnectRemote";
        public const string EventKeyDown = "KeyDown";
        public const string EventKeyPress = "KeyPress";
        public const string EventQuit = "Quit";
        private static uint instanceCount = 0;
        public const uint InterruptAll = uint.MaxValue;
        public const uint Interruptible = uint.MaxValue;
        public const uint InterruptNone = 0;
        private bool isDisposed = false;
        private PSXEventHandler myPSXEventHandler = null;
        public const uint NotInterruptible = 0;
        public const string PropertyAction = "Action";
        public const string PropertyAudio = "Audio";
        public const string PropertyBackgroundColor = "BackgroundColor";
        public const string PropertyButtonCount = "ButtonCount";
        public const string PropertyButtonHeight = "ButtonHeight";
        public const string PropertyButtonHorizontalSpacing = "ButtonHorizontalSpacing";
        public const string PropertyButtonVerticalSpacing = "ButtonVerticalSpacing";
        public const string PropertyButtonWidth = "ButtonWidth";
        public const string PropertyChangeFocusEvent = "ChangeFocusEvent";
        public const string PropertyChangeScrollEvent = "ChangeScrollEvent";
        public const string PropertyChangeTextEvent = "ChangeTextEvent";
        public const string PropertyClickEvent = "ClickEvent";
        public const string PropertyClickMove = "ClickMove";
        public const string PropertyControlType = "ControlType";
        public const string PropertyCursor = "Cursor";
        public const string PropertyData = "Data";
        public const string PropertyDeferPosition = "DeferPosition";
        public const string PropertyDisableUserInput = "DisableUserInput";
        public const string PropertyEcho = "Echo";
        public const string PropertyFillStyle = "FillStyle";
        public const string PropertyFlash = "Flash";
        public const string PropertyFocus = "Focus";
        public const string PropertyFont = "Font";
        public const string PropertyHwnd = "HWND";
        public const string PropertyKeyDownEvent = "KeyDownEvent";
        public const string PropertyKeyPressEvent = "KeyPressEvent";
        public const string PropertyLogo = "Logo";
        public const string PropertyLogoPosition = "LogoPosition";
        public const string PropertyPassword = "Password";
        public const string PropertyPicture = "Picture";
        public const string PropertyPictureTransparentColor = "PictureTransparentColor";
        public const string PropertyPosition = "Position";
        public const string PropertyQuitEvent = "QuitEvent";
        public const string PropertyRadio = "Radio";
        public const string PropertyRedraw = "Redraw";
        public const string PropertyResetURL = "ResetURL";
        public const string PropertySelectionBackgroundColor = "SelectionBackgroundColor";
        public const string PropertySelectionFont = "SelectionFont";
        public const string PropertySelectionForegroundColor = "SelectionForegroundColor";
        public const string PropertyShowScrollBars = "ShowScrollBars";
        public const string PropertyShowSelection = "ShowSelection";
        public const string PropertySize = "Size";
        public const string PropertyState = "State";
        public const string PropertyText = "Text";
        public const string PropertyTextAlignment = "TextAlignment";
        public const string PropertyTextColor = "TextColor";
        public const string PropertyTextColorDisabled = "TextColorDisabled";
        public const string PropertyTextFormat = "TextFormat";
        public const string PropertyTextLength = "TextLength";
        public const string PropertyTextLineAlignment = "TextLineAlignment";
        public const string PropertyTextPosition = "TextPosition";
        public const string PropertyToggle = "Toggle";
        public const string PropertyTopMost = "TopMost";
        public const string PropertyUrl = "URL";
        public const string PropertyUserInput = "UserInput";
        public const string PropertyVariable = "Variable";
        public const string PropertyVideo = "Video";
        public const string PropertyVisible = "Visible";
        public const string PropertyWindowless = "Windowless";
        public const string PropertyZOrder = "Z-Order";
        private const string PsxApiDll = "PSXU.dll";
        private int psxId;
        public const ushort ShiftKetMask = 1;
        public const uint SoundImmediate = 1;
        public const uint SoundInterrupt = 2;
        private const string userDll = "user32.dll";
        #endregion

        string connectionName;
        string hostName;

        public string HostName
        {
            get { return hostName; }
        }

        public string ConnectionName
        {
            get { return connectionName; }
        }

        public event PsxEventHandler PsxEvent;

        public Psx(string host, string service, string name, uint timeout)
        {
            Initialize();
            object param = "";
            InitializeConnection(host, service, name, ref param, timeout);
        }

        public Psx(string host, string service, string name, ref object param, uint timeout)
        {
            Initialize();
            InitializeConnection(host, service, name, ref param, timeout);
        }

        public Psx()
        {
            Initialize();
        }

        public bool ContextEquals(string contextName)
        {
            return GetContext(1).Equals(contextName);
        }

        void InitializeConnection(string host, string service, string name, ref object param, uint timeout)
        {
            int now = Environment.TickCount;
            while ((Environment.TickCount - now) < timeout)
            {
                ConnectRemote(host, service, name, ref param, timeout);
                break;
            }
        }

        void Initialize()
        {
            PsxError notInitialized = PsxError.NotInitialized;
            if (instanceCount == 0)
            {
                notInitialized = PSXInitialize();
                if (PsxException.IsError(notInitialized))
                {
                    throw new PsxException(notInitialized);
                }
            }
            this.psxId = 0;
            this.myPSXEventHandler = new PSXEventHandler(this.internalEventHandler);
            notInitialized = PSXCreate(this.myPSXEventHandler, ref this.psxId);
            if (PsxException.IsError(notInitialized))
            {
                throw new PsxException(notInitialized);
            }
            instanceCount++;
        }

        public void AcceptConnection(string connectionName, object param, bool accept)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((connectionName == null) || (param == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXAcceptConnection(this.psxId, connectionName, param, accept);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void BringToFront()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (IntPtr.Zero == this.Handle)
            {
                throw new PsxException(PsxError.NotInitialized);
            }
            BringWindowToTop(this.Handle);
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern bool BringWindowToTop(IntPtr hWnd);
        public void ClearAll()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            PsxError err = PSXClearAll(this.psxId);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void ClearReceipt(string sourceName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (sourceName == null)
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXClearReceipt(this.psxId, sourceName);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void ClearReceiptItemVariables(string sourceName, string itemId, bool recursive)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((sourceName == null) || (itemId == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXClearReceiptItemVariables(this.psxId, sourceName, itemId, recursive);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void ClearTransactionVariables()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            PsxError err = PSXClearTransactionVariables(this.psxId);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void ConnectRemote(string hostName, string serviceName, string connectionName, ref object param, uint timeout)
        {
            this.connectionName = connectionName;
            this.hostName = hostName;
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((hostName == null) || (serviceName == null)) || ((connectionName == null) || (param == null)))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXConnectRemote(this.psxId, hostName, serviceName, connectionName, ref param, timeout);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void CreateChildDisplay(Rectangle rectPosition, Psx owner)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (owner == null)
            {
                throw new ArgumentNullException();
            }
            RECT rect = new RECT(rectPosition.Left, rectPosition.Top, rectPosition.Right, rectPosition.Bottom);
            PsxError err = PSXCreateDisplay(this.psxId, ref rect, owner.psxId, IntPtr.Zero);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void CreateDisplay(Rectangle rectPosition)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            RECT rect = new RECT(rectPosition.Left, rectPosition.Top, rectPosition.Right, rectPosition.Bottom);
            PsxError err = PSXCreateDisplay(this.psxId, ref rect, 0, IntPtr.Zero);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void CreateDisplay(Rectangle rectPosition, IWin32Window owner)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (owner == null)
            {
                throw new ArgumentNullException();
            }
            RECT rect = new RECT(rectPosition.Left, rectPosition.Top, rectPosition.Right, rectPosition.Bottom);
            PsxError err = PSXCreateDisplay(this.psxId, ref rect, 0, owner.Handle);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void CreateReceiptItem(string sourceName, string itemId)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((sourceName == null) || (itemId == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXCreateReceiptItem(this.psxId, sourceName, itemId, null, null);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void CreateReceiptItem(string sourceName, string itemId, string nextItemId)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((sourceName == null) || (itemId == null)) || (nextItemId == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXCreateReceiptItem(this.psxId, sourceName, itemId, null, nextItemId);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void CreateReceiptItemChild(string sourceName, string itemId, string parentItemId)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((sourceName == null) || (itemId == null)) || (parentItemId == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXCreateReceiptItem(this.psxId, sourceName, itemId, parentItemId, null);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void CreateReceiptItemChild(string sourceName, string itemId, string parentItemId, string nextItemId)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((sourceName == null) || (itemId == null)) || ((parentItemId == null) || (nextItemId == null)))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXCreateReceiptItem(this.psxId, sourceName, itemId, parentItemId, nextItemId);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void DestroyDisplay()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            PsxError err = PSXDestroyDisplay(this.psxId);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void DisconnectRemote()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            PsxError err = PSXDisconnectRemote(this.psxId, null);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void DisconnectRemote(string connectionName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (connectionName == null)
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXDisconnectRemote(this.psxId, connectionName);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public virtual void Dispose()
        {
            if (!this.isDisposed)
            {
                this.isDisposed = true;
                if (this.psxId != 0)
                {
                    PSXDestroy(this.psxId);
                }
                instanceCount--;
                if (instanceCount == 0)
                {
                    PSXUninitialize();
                }
                GC.SuppressFinalize(this);
            }
        }

        ~Psx()
        {
            this.Dispose();
        }

        public string[] FindReceiptItemChildren(string sourceName, string parentItemId)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((sourceName == null) || (parentItemId == null))
            {
                throw new ArgumentNullException();
            }
            string[] strArray = new string[0];
            int count = 0;
            object receiptVarValue = new object();
            PsxError err = PSXFindReceiptItems(this.psxId, sourceName, null, ref count, parentItemId, null, receiptVarValue);
            if (!PsxException.IsError(err) && (count > 0))
            {
                StringBuilder varValue = null;
                do
                {
                    varValue = new StringBuilder(count);
                    err = PSXFindReceiptItems(this.psxId, sourceName, varValue, ref count, parentItemId, null, receiptVarValue);
                } while (PsxError.InvalidParam == err);
                if (!PsxException.IsError(err))
                {
                    strArray = varValue.ToString().Split(new char[] { ',' });
                }
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return strArray;
        }

        public string[] FindReceiptItems(string sourceName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (sourceName == null)
            {
                throw new ArgumentNullException();
            }
            string[] strArray = new string[0];
            int count = 0;
            object receiptVarValue = new object();
            PsxError err = PSXFindReceiptItems(this.psxId, sourceName, null, ref count, null, null, receiptVarValue);
            if (!PsxException.IsError(err) && (count > 0))
            {
                StringBuilder varValue = null;
                do
                {
                    varValue = new StringBuilder(count);
                    err = PSXFindReceiptItems(this.psxId, sourceName, varValue, ref count, null, null, receiptVarValue);
                } while (PsxError.InvalidParam == err);
                if (!PsxException.IsError(err))
                {
                    strArray = varValue.ToString().Split(new char[] { ',' });
                }
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return strArray;
        }

        public string[] FindReceiptItems(string sourceName, string varName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((sourceName == null) || (varName == null))
            {
                throw new ArgumentNullException();
            }
            string[] strArray = new string[0];
            int count = 0;
            object receiptVarValue = new object();
            PsxError err = PSXFindReceiptItems(this.psxId, sourceName, null, ref count, null, varName, receiptVarValue);
            if (!PsxException.IsError(err) && (count > 0))
            {
                StringBuilder varValue = null;
                do
                {
                    varValue = new StringBuilder(count);
                    err = PSXFindReceiptItems(this.psxId, sourceName, varValue, ref count, null, varName, receiptVarValue);
                } while (PsxError.InvalidParam == err);
                if (!PsxException.IsError(err))
                {
                    strArray = varValue.ToString().Split(new char[] { ',' });
                }
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return strArray;
        }

        public string[] FindReceiptItems(string sourceName, string varName, object varValue)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((sourceName == null) || (varName == null)) || (varValue == null))
            {
                throw new ArgumentNullException();
            }
            string[] strArray = new string[0];
            int count = 0;
            PsxError err = PSXFindReceiptItems(this.psxId, sourceName, null, ref count, null, varName, varValue);
            if (!PsxException.IsError(err) && (count > 0))
            {
                StringBuilder builder = null;
                do
                {
                    builder = new StringBuilder(count);
                    err = PSXFindReceiptItems(this.psxId, sourceName, builder, ref count, null, varName, varValue);
                } while (PsxError.InvalidParam == err);
                if (!PsxException.IsError(err) && (count > 0))
                {
                    strArray = builder.ToString().Split(new char[] { ',' });
                }
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return strArray;
        }

        public string[] FindReceiptItemsChildren(string sourceName, string parentItemId, string varName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((sourceName == null) || (parentItemId == null)) || (varName == null))
            {
                throw new ArgumentNullException();
            }
            string[] strArray = new string[0];
            int count = 0;
            object receiptVarValue = new object();
            PsxError err = PSXFindReceiptItems(this.psxId, sourceName, null, ref count, parentItemId, varName, receiptVarValue);
            if (!PsxException.IsError(err) && (count > 0))
            {
                StringBuilder varValue = null;
                do
                {
                    varValue = new StringBuilder(count);
                    err = PSXFindReceiptItems(this.psxId, sourceName, varValue, ref count, parentItemId, varName, receiptVarValue);
                } while (PsxError.InvalidParam == err);
                if (!PsxException.IsError(err))
                {
                    strArray = varValue.ToString().Split(new char[] { ',' });
                }
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return strArray;
        }

        public string[] FindReceiptItemsChildren(string sourceName, string parentItemId, string varName, object varValue)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((sourceName == null) || (parentItemId == null)) || ((varName == null) || (varValue == null)))
            {
                throw new ArgumentNullException();
            }
            string[] strArray = new string[0];
            int count = 0;
            PsxError err = PSXFindReceiptItems(this.psxId, sourceName, null, ref count, parentItemId, varName, varValue);
            if (!PsxException.IsError(err) && (count > 0))
            {
                StringBuilder builder = null;
                do
                {
                    builder = new StringBuilder(count);
                    err = PSXFindReceiptItems(this.psxId, sourceName, builder, ref count, parentItemId, varName, varValue);
                } while (PsxError.InvalidParam == err);
                if (!PsxException.IsError(err))
                {
                    strArray = builder.ToString().Split(new char[] { ',' });
                }
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return strArray;
        }

        public void GenerateEvent(string controlName, string contextName, string eventName, object param)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((controlName == null) || (contextName == null)) || ((eventName == null) || (param == null)))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXGenerateEvent(this.psxId, controlName, contextName, eventName, param, null);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void GenerateEvent(string connectionName, string controlName, string contextName, string eventName, object param)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((connectionName == null) || (controlName == null)) || (((contextName == null) || (eventName == null)) || (param == null)))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXGenerateEvent(this.psxId, controlName, contextName, eventName, param, connectionName);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public object GetConfigColor(string colorName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (colorName == null)
            {
                throw new ArgumentNullException();
            }
            object colorValue = new object();
            PsxError err = PSXGetConfigColor(this.psxId, colorName, ref colorValue);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return colorValue;
        }

        public object GetConfigFont(string fontName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (fontName == null)
            {
                throw new ArgumentNullException();
            }
            object fontValue = new object();
            PsxError err = PSXGetConfigFont(this.psxId, fontName, ref fontValue);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return fontValue;
        }

        public object GetConfigProperty(string controlName, string contextName, string propertyName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((controlName == null) || (contextName == null)) || (propertyName == null))
            {
                throw new ArgumentNullException();
            }
            object propertyValue = new object();
            PsxError err = PSXGetConfigProperty(this.psxId, controlName, contextName, propertyName, out propertyValue);
            //marv debug
            //MessageBox.Show("GetConfigProperty:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return propertyValue;
        }

        public string GetContext(uint displayTarget)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            StringBuilder varValue = new StringBuilder(250);
            int capacity = varValue.Capacity;
            PsxError err = PSXGetContext(this.psxId, varValue, ref capacity, displayTarget);
            //marv debug
            //MessageBox.Show("GetContext:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return varValue.ToString();
        }

        public object GetContextConfigProperty(string contextName, string propertyName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((contextName == null) || (propertyName == null))
            {
                throw new ArgumentNullException();
            }
            object propertyValue = new object();
            PsxError err = PSXGetConfigProperty(this.psxId, null, contextName, propertyName, out propertyValue);
            //marv debug
            //MessageBox.Show("GetContextConfigProperty:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return propertyValue;
        }

        public string GetContextCustomDataVariable(string varName, string contextName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((varName == null) || (contextName == null))
            {
                throw new ArgumentNullException();
            }
            StringBuilder varValue = new StringBuilder(250);
            int capacity = varValue.Capacity;
            PsxError err = PSXGetCustomDataVar(this.psxId, varName, varValue, ref capacity, null, contextName);
            //marv debug
            //MessageBox.Show("GetContextCustomDataVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return varValue.ToString();
        }

        public string[] GetContextNameList()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            string[] strArray = new string[0];
            int count = 0;
            PsxError err = PSXGetContextNameList(this.psxId, null, ref count);
            if (!PsxException.IsError(err) && (count > 0))
            {
                StringBuilder varValue = null;
                do
                {
                    varValue = new StringBuilder(count);
                    err = PSXGetContextNameList(this.psxId, varValue, ref count);
                } while (PsxError.InvalidParam == err);
                if (!PsxException.IsError(err))
                {
                    strArray = varValue.ToString().Split(new char[] { ',' });
                }
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return strArray;
        }

        public object GetControlConfigProperty(string controlName, string propertyName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((controlName == null) || (propertyName == null))
            {
                throw new ArgumentNullException();
            }
            object propertyValue = new object();
            PsxError err = PSXGetConfigProperty(this.psxId, controlName, null, propertyName, out propertyValue);
            //marv debug
            //MessageBox.Show("GetControlConfigProperty:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return propertyValue;
        }

        public string GetControlCustomDataVariable(string varName, string controlName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((varName == null) || (controlName == null))
            {
                throw new ArgumentNullException();
            }
            StringBuilder varValue = new StringBuilder(250);
            int capacity = varValue.Capacity;
            PsxError err = PSXGetCustomDataVar(this.psxId, varName, varValue, ref capacity, controlName, null);
            //marv debug
            //MessageBox.Show("GetControlCustomDataVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return varValue.ToString();
        }

        public string[] GetControlNameList()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            string[] strArray = new string[0];
            int count = 0;
            PsxError err = PSXGetControlNameList(this.psxId, null, ref count, null);
            if (!PsxException.IsError(err) && (count > 0))
            {
                StringBuilder varValue = null;
                do
                {
                    varValue = new StringBuilder(count);
                    err = PSXGetControlNameList(this.psxId, varValue, ref count, null);
                } while (PsxError.InvalidParam == err);
                if (!PsxException.IsError(err))
                {
                    strArray = varValue.ToString().Split(new char[] { ',' });
                }
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return strArray;
        }

        public string[] GetControlNameList(string contextName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (contextName == null)
            {
                throw new ArgumentNullException();
            }
            string[] strArray = new string[0];
            int count = 0;
            PsxError err = PSXGetControlNameList(this.psxId, null, ref count, contextName);
            if (!PsxException.IsError(err) && (count > 0))
            {
                StringBuilder varValue = null;
                do
                {
                    varValue = new StringBuilder(count);
                    err = PSXGetControlNameList(this.psxId, varValue, ref count, contextName);
                } while (PsxError.InvalidParam == err);
                if (!PsxException.IsError(err))
                {
                    strArray = varValue.ToString().Split(new char[] { ',' });
                }
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return strArray;
        }

        public object GetControlProperty(string controlName, string propertyName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((controlName == null) || (propertyName == null))
            {
                throw new ArgumentNullException();
            }
            object propertyValue = new object();
            PsxError err = PSXGetControlProperty(this.psxId, controlName, propertyName, out propertyValue);
            //marv debug
            //MessageBox.Show("GetControlProperty:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return propertyValue;
        }

        public string GetCustomDataVariable(string varName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (varName == null)
            {
                throw new ArgumentNullException();
            }
            StringBuilder varValue = new StringBuilder(250);
            int capacity = varValue.Capacity;
            PsxError err = PSXGetCustomDataVar(this.psxId, varName, varValue, ref capacity, null, null);
            //marv debug
            //MessageBox.Show("GetCustomDataVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return varValue.ToString();
        }

        public string GetCustomDataVariable(string varName, string controlName, string contextName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((varName == null) || (controlName == null)) || (contextName == null))
            {
                throw new ArgumentNullException();
            }
            StringBuilder varValue = new StringBuilder(250);
            int capacity = varValue.Capacity;
            PsxError err = PSXGetCustomDataVar(this.psxId, varName, varValue, ref capacity, controlName, contextName);
            //marv debug
            //MessageBox.Show("GetCustomDataVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return varValue.ToString();
        }

        public static string GetEnvironmentVariable(string varName)
        {
            if (varName == null)
            {
                throw new ArgumentNullException();
            }
            StringBuilder varValue = new StringBuilder(250);
            if (instanceCount == 0)
            {
                throw new PsxException(PsxError.NotInitialized);
            }
            int capacity = varValue.Capacity;
            PsxError err = PSXGetEnvironmentVariable(varName, varValue, ref capacity);
            //marv debug
            //MessageBox.Show("GetEnvironmentVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return varValue.ToString();
        }

        public uint[] GetLanguageList()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            uint[] lcids = new uint[0];
            int count = 0;
            PsxError err = PSXGetLanguageList(this.psxId, ref count, null);
            if (!PsxException.IsError(err) && (count > 0))
            {
                lcids = null;
                do
                {
                    lcids = new uint[count];
                    err = PSXGetLanguageList(this.psxId, ref count, lcids);
                } while (PsxError.InvalidParam == err);
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return lcids;
        }

        public string GetReceiptItemParent(string sourceName, string itemId)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((sourceName == null) || (itemId == null))
            {
                throw new ArgumentNullException();
            }
            StringBuilder varValue = new StringBuilder(250);
            int capacity = varValue.Capacity;
            PsxError err = PSXGetReceiptItemParent(this.psxId, sourceName, itemId, varValue, ref capacity);
            //marv debug
            //MessageBox.Show("GetReceiptItemParent:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return varValue.ToString();
        }

        public object GetReceiptItemVariable(string sourceName, string itemId, string varName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((sourceName == null) || (itemId == null)) || (varName == null))
            {
                throw new ArgumentNullException();
            }
            object varValue = new object();
            PsxError err = PSXGetReceiptItemVariable(this.psxId, sourceName, itemId, varName, ref varValue);
            //marv debug
            //MessageBox.Show("GetReceiptItemVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return varValue;
        }

        public string[] GetReceiptItemVariableList(string sourceName, string itemId)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((sourceName == null) || (itemId == null))
            {
                throw new ArgumentNullException();
            }
            string[] strArray = new string[0];
            int count = 0;
            PsxError err = PSXGetReceiptItemVariableList(this.psxId, sourceName, itemId, null, ref count);
            if (!PsxException.IsError(err) && (count > 0))
            {
                StringBuilder varValue = null;
                do
                {
                    varValue = new StringBuilder(count);
                    err = PSXGetReceiptItemVariableList(this.psxId, sourceName, itemId, varValue, ref count);
                } while (PsxError.InvalidParam == err);
                if (!PsxException.IsError(err))
                {
                    strArray = varValue.ToString().Split(new char[] { ',' });
                }
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return strArray;
        }

        public string[] GetReceiptSourceList()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            string[] strArray = new string[0];
            int count = 0;
            PsxError err = PSXGetReceiptSourceList(this.psxId, null, ref count);
            if (!PsxException.IsError(err) && (count > 0))
            {
                StringBuilder varValue = null;
                do
                {
                    varValue = new StringBuilder(count);
                    err = PSXGetReceiptSourceList(this.psxId, varValue, ref count);
                } while (PsxError.InvalidParam == err);
                if (!PsxException.IsError(err))
                {
                    strArray = varValue.ToString().Split(new char[] { ',' });
                }
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return strArray;
        }

        public string GetSelectedReceiptItem(string controlName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (controlName == null)
            {
                throw new ArgumentNullException();
            }
            StringBuilder varValue = new StringBuilder(250);
            int capacity = varValue.Capacity;
            PsxError err = PSXGetSelectedReceiptItem(this.psxId, controlName, varValue, ref capacity);
            //marv debug
            //MessageBox.Show("GetSelectedReceiptItem:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return varValue.ToString();
        }

        public string GetString(string id)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            StringBuilder stringValue = new StringBuilder(250);
            int capacity = stringValue.Capacity;
            PsxError err = PSXGetString(this.psxId, id, stringValue, ref capacity, 0);
            //marv debug
            //MessageBox.Show("GetString:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return stringValue.ToString();
        }

        public string GetString(string id, int length)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            StringBuilder stringValue = new StringBuilder(length);
            int capacity = stringValue.Capacity;
            PsxError err = PSXGetString(this.psxId, id, stringValue, ref capacity, 0);
            //marv debug
            //MessageBox.Show("GetString:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return stringValue.ToString();
        }

        public string GetString(string id, uint lcid)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            StringBuilder stringValue = new StringBuilder(250);
            int capacity = stringValue.Capacity;
            PsxError err = PSXGetString(this.psxId, id, stringValue, ref capacity, lcid);
            //marv debug
            //MessageBox.Show("GetString:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return stringValue.ToString();
        }

        public string GetString(string id, int length, uint lcid)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            StringBuilder stringValue = new StringBuilder(length);
            int capacity = stringValue.Capacity;
            PsxError err = PSXGetString(this.psxId, id, stringValue, ref capacity, lcid);
            //marv debug
            //MessageBox.Show("GetString:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return stringValue.ToString();
        }

        public object GetTransactionVariable(string varName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (varName == null)
            {
                throw new ArgumentNullException();
            }
            object varValue = new object();
            PsxError err = PSXGetTransactionVariable(this.psxId, varName, ref varValue);
            //marv debug
            //MessageBox.Show("GetTransactionVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return varValue;
        }

        public string[] GetTransactionVariableList()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            string[] strArray = new string[0];
            int count = 0;
            PsxError err = PSXGetTransactionVariableList(this.psxId, null, ref count);
            if (!PsxException.IsError(err) && (count > 0))
            {
                StringBuilder varValue = null;
                do
                {
                    varValue = new StringBuilder(count);
                    err = PSXGetTransactionVariableList(this.psxId, varValue, ref count);
                } while (PsxError.InvalidParam == err);
                if (!PsxException.IsError(err))
                {
                    strArray = varValue.ToString().Split(new char[] { ',' });
                }
            }
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return strArray;
        }

        public static void GetVolume(out int leftVolume, out int rightVolume)
        {
            leftVolume = 0;
            rightVolume = 0;
            PsxError err = PSXGetVolume(ref leftVolume, ref rightVolume);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        private void internalEventHandler(int psxId, string connectionName, string controlName, string contextName, string eventName, object param)
        {
            if (this.PsxEvent != null)
            {
                this.PsxEvent(this, new PsxEventArgs(connectionName, controlName, contextName, eventName, param));
            }
        }

        public void Load(byte[] data)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXLoad(this.psxId, data, data.Length);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void LoadConfigFile(string configFile)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (configFile == null)
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXLoadConfigFile(this.psxId, configFile, null);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void LoadConfigFile(string configFile, string mergeConfigFile)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((configFile == null) || (mergeConfigFile == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXLoadConfigFile(this.psxId, configFile, mergeConfigFile);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public static Keys ObjectToKeys(object o)
        {
            if (o == null)
            {
                throw new ArgumentNullException();
            }
            return (((Keys)Convert.ToInt32(o)) & Keys.KeyCode);
        }

        public static Rectangle ObjectToRectangle(object o)
        {
            if (o == null)
            {
                throw new ArgumentNullException();
            }
            Rectangle rectangle = new Rectangle(0, 0, 0, 0);
            string[] strArray = o.ToString().Split(new char[] { ',' });
            if (4 == strArray.Length)
            {
                rectangle.X = Convert.ToInt32(strArray[0]);
                rectangle.Y = Convert.ToInt32(strArray[1]);
                rectangle.Width = Convert.ToInt32(strArray[2]);
                rectangle.Height = Convert.ToInt32(strArray[3]);
            }
            return rectangle;
        }

        public void PlaySound(string sound)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (sound == null)
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXPlaySound2(this.psxId, sound, true, 0, uint.MaxValue, uint.MaxValue, 0);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void PlaySound(string sound, uint soundFlags, uint displayTargetMask)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (sound == null)
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXPlaySound2(this.psxId, sound, 1 == (soundFlags & 1), (2 == (soundFlags & 2)) ? uint.MaxValue : 0, uint.MaxValue, displayTargetMask, 0);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void PlaySound(string sound, bool immediate, bool interrupt, uint displayTargetMask)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (sound == null)
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXPlaySound2(this.psxId, sound, immediate, interrupt ? uint.MaxValue : 0, uint.MaxValue, displayTargetMask, 0);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void PlaySound(string sound, bool immediate, uint interruptMask, uint interruptibleMask, uint displayTargetMask)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (sound == null)
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXPlaySound2(this.psxId, sound, immediate, interruptMask, interruptibleMask, displayTargetMask, 0);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void PlaySound(string sound, bool immediate, uint interruptMask, uint interruptibleMask, uint displayTargetMask, uint lcid)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (sound == null)
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXPlaySound2(this.psxId, sound, immediate, interruptMask, interruptibleMask, displayTargetMask, lcid);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXAcceptConnection(int nPsxId, string connectionName, object param, bool accept);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXClearAll(int nPsxId);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXClearReceipt(int nPsxId, string sourceName);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXClearReceiptItemVariables(int nPsxId, string sourceName, string itemId, bool recursive);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXClearTransactionVariables(int psxId);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern PsxError PSXConnectRemote(int nPsxId, string hostName, string serviceName, string connectionName, [MarshalAs(UnmanagedType.Struct)]
ref object param, uint timeout);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern PsxError PSXCreate(PSXEventHandler eventHandler, ref int psxId);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXCreateDisplay(int psxId, ref RECT rectPosition, int parentPsxId, IntPtr wndParent);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXCreateReceiptItem(int nPsxId, string sourceName, string itemId, string parentItemId, string nextItemId);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern PsxError PSXDestroy(int psxId);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXDestroyDisplay(int psxId);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXDisconnectRemote(int psxId, string connectionName);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXFindReceiptItems(int psxId, string sourceName, StringBuilder varValue, ref int count, string parentItemId, string varName, object receiptVarValue);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGenerateEvent(int psxId, string controlName, string contextName, string eventName, [MarshalAs(UnmanagedType.Struct)]
object param, string remoteConnectionName);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern PsxError PSXGetActiveConnections(int psxId, StringBuilder varValue, ref int count);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetConfigColor(int psxId, string colorName, ref object colorValue);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetConfigFont(int psxId, string fontName, ref object fontValue);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetConfigProperty(int psxId, string controlName, string contextName, string propertyName, [MarshalAs(UnmanagedType.Struct)]
out object propertyValue);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern PsxError PSXGetContext(int psxId, StringBuilder varValue, ref int count, uint displayTarget);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetContextNameList(int psxId, StringBuilder varValue, ref int count);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetControlNameList(int psxId, StringBuilder varValue, ref int count, string contextName);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern PsxError PSXGetControlProperty(int psxId, string controlName, string propertyName, [MarshalAs(UnmanagedType.Struct)]
out object propertyValue);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetCustomDataVar(int psxId, string varName, StringBuilder varValue, ref int count, string controlName, string contextName);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetDisplayView(int psxId, ref uint displayView);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetEnvironmentVariable(string varName, StringBuilder varValue, ref int count);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetLanguage(int psxId, ref uint lcid);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetLanguageList(int psxId, ref int count, [Out()]
uint[] lcids);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetReceiptItemParent(int psxId, string sourceName, string itemId, StringBuilder varValue, ref int count);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetReceiptItemVariable(int psxId, string sourceName, string itemId, string varName, ref object varValue);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetReceiptItemVariableList(int psxId, string sourceName, string itemId, StringBuilder varValue, ref int count);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetReceiptSourceList(int psxId, StringBuilder varValue, ref int count);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetSelectedReceiptItem(int psxId, string controlName, StringBuilder varValue, ref int count);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetString(int psxId, string id, StringBuilder stringValue, ref int count, uint lcid);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetTransactionVariable(int psxId, string varName, ref object varValue);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetTransactionVariableList(int psxId, StringBuilder varValue, ref int count);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXGetVolume(ref int leftVolume, ref int rightVolume);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXInitialize();
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXIsServer(int psxId, ref bool server, StringBuilder stringValue, ref int count);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXLoad(int nPSXId, byte[] data, int count);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXLoadConfigFile(int nPSXId, string configFile, string mergeConfigFile);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXPlaySound2(int psxId, string sound, bool immediate, uint interruptMask, uint interruptibleMask, uint displayTargetMask, uint lcid);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXRemoveReceiptItem(int psxId, string sourceName, string itemId);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXRemoveReceiptItemVariable(int psxId, string sourceName, string itemId, string varName, bool recursive);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSave(int nPSXId, byte[] data, ref int count, bool synchronize);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSendControlCommand(int psxId, string controlName, string command, [MarshalAs(UnmanagedType.Struct)]
out object returnValue, int noParams, [In(), MarshalAs(UnmanagedType.LPArray)]
object[] commandParams);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSetConfigProperty(int psxId, string controlName, string contextName, string propertyName, [MarshalAs(UnmanagedType.Struct)]
object propertyValue);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSetContext(int psxId, string context, uint displayTargetMask, bool wait);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSetControlProperty(int psxId, string controlName, string propertyName, [MarshalAs(UnmanagedType.Struct)]
object propertyValue);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSetCustomDataVar(int psxId, string varName, string varValue, string controlName, string contextName);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSetDisplayView(int psxId, uint displayView);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSetEnvironmentVariable(string varName, string varValue);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSetLanguage(int psxId, uint lcid);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSetReceiptItemVariable(int psxId, string sourceName, string itemId, string varName, object varValue, bool recursive);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSetResolution(int pixelWidth, int pixelHeight);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSetSelectedReceiptItem(int psxId, string controlName, string itemId);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSetTransactionVariable(int psxId, string varName, [MarshalAs(UnmanagedType.Struct)]
object varValue);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXSetVolume(int leftVolume, int rightVolume);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXStartServer(int psxId, string serviceName);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXStopServer(int psxId);
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXUninitialize();
        [DllImport("PSXU.dll", CharSet = CharSet.Unicode)]
        private static extern PsxError PSXUpdateReceiptControls(int psxId, string sourceName);
        public static object RectangleToObject(Rectangle rect)
        {
            return (rect.X.ToString() + "," + rect.Y.ToString() + "," + rect.Width.ToString() + "," + rect.Height.ToString());
        }

        public void RemoveReceiptItem(string sourceName, string itemId)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((sourceName == null) || (itemId == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXRemoveReceiptItem(this.psxId, sourceName, itemId);
            //marv debug
            //MessageBox.Show("RemoveReceiptItem:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void RemoveReceiptItemVariable(string sourceName, string itemId, string varName, bool recursive)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((sourceName == null) || (itemId == null)) || (varName == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXRemoveReceiptItemVariable(this.psxId, sourceName, itemId, varName, recursive);
            //marv debug
            //MessageBox.Show("RemoveReceiptItemVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public byte[] Save(bool synchronize)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            byte[] data = new byte[0];
            int count = 0;
            PsxError err = PSXSave(this.psxId, null, ref count, synchronize);
            if (!PsxException.IsError(err) && (count > 0))
            {
                do
                {
                    data = new byte[count];
                    err = PSXSave(this.psxId, data, ref count, synchronize);
                } while (PsxError.InvalidParam == err);
            }
            //marv debug
            //MessageBox.Show("Save:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return data;
        }

        public object SendControlCommand(string controlName, string command)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((controlName == null) || (command == null))
            {
                throw new ArgumentNullException();
            }
            object returnValue = new object();
            PsxError err = PSXSendControlCommand(this.psxId, controlName, command, out returnValue, 0, new object[1]);
            //marv debug
            //MessageBox.Show("SendControlCommand:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return returnValue;
        }

        public object SendControlCommand(string controlName, string command, int noParams, [In()]
object[] commandParams)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((controlName == null) || (command == null)) || (commandParams == null))
            {
                throw new ArgumentNullException();
            }
            object returnValue = new object();
            PsxError err = PSXSendControlCommand(this.psxId, controlName, command, out returnValue, noParams, commandParams);
            //marv debug
            //MessageBox.Show("SendControlCommand:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
            return returnValue;
        }

        public void SetConfigProperty(string controlName, string contextName, string propertyName, object propertyValue)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((controlName == null) || (contextName == null)) || ((propertyName == null) || (propertyValue == null)))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXSetConfigProperty(this.psxId, controlName, contextName, propertyName, propertyValue);
            //marv debug
            //MessageBox.Show("SetConfigProperty:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void SetContext(string context, uint displayTargetMask, bool wait)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (context == null)
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXSetContext(this.psxId, context, displayTargetMask, wait);
            //marv debug
            //MessageBox.Show("SetContext:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void SetContextConfigProperty(string contextName, string propertyName, object propertyValue)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((contextName == null) || (propertyName == null)) || (propertyValue == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXSetConfigProperty(this.psxId, null, contextName, propertyName, propertyValue);
            //marv debug
            //MessageBox.Show("SetContextConfigProperty:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void SetContextCustomDataVariable(string varName, string varValue, string contextName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((varName == null) || (varValue == null)) || (contextName == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXSetCustomDataVar(this.psxId, varName, varValue, null, contextName);
            //marv debug
            //MessageBox.Show("SetContextCustomDataVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void SetControlConfigProperty(string controlName, string propertyName, object propertyValue)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((controlName == null) || (propertyName == null)) || (propertyValue == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXSetConfigProperty(this.psxId, controlName, null, propertyName, propertyValue);
            //marv debug
            //MessageBox.Show("SetControlConfigProperty:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void SetControlCustomDataVariable(string varName, string varValue, string controlName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((varName == null) || (varValue == null)) || (controlName == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXSetCustomDataVar(this.psxId, varName, varValue, controlName, null);

            //marv debug
            //MessageBox.Show("SetControlCustomDataVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void SetControlProperty(string controlName, string propertyName, object propertyValue)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((controlName == null) || (propertyName == null)) || (propertyValue == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXSetControlProperty(this.psxId, controlName, propertyName, propertyValue);

            //marv debug
            //MessageBox.Show("SetControlProperty:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void SetCustomDataVariable(string varName, string varValue)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((varName == null) || (varValue == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXSetCustomDataVar(this.psxId, varName, varValue, null, null);
            //marv debug
            //MessageBox.Show("SetCustomDataVariable" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void SetCustomDataVariable(string varName, string varValue, string controlName, string contextName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((varName == null) || (varValue == null)) || ((controlName == null) || (contextName == null)))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXSetCustomDataVar(this.psxId, varName, varValue, controlName, contextName);
            //marv debug
            //MessageBox.Show("SetCustomDataVariable" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public static void SetEnvironmentVariable(string varName, string varValue)
        {
            if ((varName == null) || (varValue == null))
            {
                throw new ArgumentNullException();
            }
            if (instanceCount == 0)
            {
                throw new PsxException(PsxError.NotInitialized);
            }
            PsxError err = PSXSetEnvironmentVariable(varName, varValue);
            //marv debug
            //MessageBox.Show("SetEnvironmentVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void SetReceiptItemVariable(string sourceName, string itemId, string varName, object varValue, bool recursive)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (((sourceName == null) || (itemId == null)) || ((varName == null) || (varValue == null)))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXSetReceiptItemVariable(this.psxId, sourceName, itemId, varName, varValue, recursive);
            //marv debug
            //MessageBox.Show("SetReceiptItemVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public static void SetResolution(int pixelWidth, int pixelHeight)
        {
            PsxError err = PSXSetResolution(pixelWidth, pixelHeight);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void SetSelectedReceiptItem(string controlName, string itemId)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((controlName == null) || (itemId == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXSetSelectedReceiptItem(this.psxId, controlName, itemId);
            //marv debug
            //MessageBox.Show("SetSelectedReceiptItem:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void SetTransactionVariable(string varName, object varValue)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if ((varName == null) || (varValue == null))
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXSetTransactionVariable(this.psxId, varName, varValue);
            //marv debug
            //MessageBox.Show("SetTransactionVariable:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public static void SetVolume(int leftVolume, int rightVolume)
        {
            PsxError err = PSXSetVolume(leftVolume, rightVolume);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void StartServer(string serviceName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (serviceName == null)
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXStartServer(this.psxId, serviceName);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void StopServer()
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            PsxError err = PSXStopServer(this.psxId);
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public void UpdateReceiptControls(string sourceName)
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(this.ToString());
            }
            if (sourceName == null)
            {
                throw new ArgumentNullException();
            }
            PsxError err = PSXUpdateReceiptControls(this.psxId, sourceName);
            //marv debug
            //MessageBox.Show("UpdateReceiptControls:" + err.ToString());
            //end
            if (PsxException.IsError(err))
            {
                throw new PsxException(err);
            }
        }

        public Rectangle Bounds
        {
            get { return ObjectToRectangle(this.GetControlProperty("Display", "Position")); }
            set { this.SetControlProperty("Display", "Position", RectangleToObject(value)); }
        }

        public uint DisplayView
        {
            get
            {
                if (this.isDisposed)
                {
                    throw new ObjectDisposedException(this.ToString());
                }
                uint displayView = 0;
                PsxError err = PSXGetDisplayView(this.psxId, ref displayView);
                if (PsxException.IsError(err))
                {
                    throw new PsxException(err);
                }
                return displayView;
            }
            set
            {
                if (this.isDisposed)
                {
                    throw new ObjectDisposedException(this.ToString());
                }
                PsxError err = PSXSetDisplayView(this.psxId, value);
                if (PsxException.IsError(err))
                {
                    throw new PsxException(err);
                }
            }
        }

        public bool Enabled
        {
            get { return Convert.ToBoolean(this.GetControlProperty("Display", "UserInput")); }
            set { this.SetControlProperty("Display", "UserInput", value); }
        }

        public IntPtr Handle
        {
            get { return (IntPtr)Convert.ToInt32(this.GetControlProperty("Display", "HWND")); }
        }

        public bool IsServer
        {
            get
            {
                if (this.isDisposed)
                {
                    throw new ObjectDisposedException(this.ToString());
                }
                bool server = false;
                int count = 0;
                PsxError err = PSXIsServer(this.psxId, ref server, null, ref count);
                if (PsxException.IsError(err))
                {
                    throw new PsxException(err);
                }
                return server;
            }
        }

        public uint Language
        {
            get
            {
                if (this.isDisposed)
                {
                    throw new ObjectDisposedException(this.ToString());
                }
                uint lcid = 0;
                PsxError err = PSXGetLanguage(this.psxId, ref lcid);
                if (PsxException.IsError(err))
                {
                    throw new PsxException(err);
                }
                return lcid;
            }
            set
            {
                if (this.isDisposed)
                {
                    throw new ObjectDisposedException(this.ToString());
                }
                PsxError err = PSXSetLanguage(this.psxId, value);
                if (PsxException.IsError(err))
                {
                    throw new PsxException(err);
                }
            }
        }

        public Point Location
        {
            get { return ObjectToRectangle(this.GetControlProperty("Display", "Position")).Location; }
            set
            {
                Rectangle rect = ObjectToRectangle(this.GetControlProperty("Display", "Position"));
                rect.X = value.X;
                rect.Y = value.Y;
                this.SetControlProperty("Display", "Position", RectangleToObject(rect));
            }
        }

        public string[] RemoteConnections
        {
            get
            {
                if (this.isDisposed)
                {
                    throw new ObjectDisposedException(this.ToString());
                }
                string[] strArray = new string[0];
                int count = 0;
                PsxError err = PSXGetActiveConnections(this.psxId, null, ref count);
                if (!PsxException.IsError(err) && (count > 0))
                {
                    StringBuilder varValue = null;
                    do
                    {
                        varValue = new StringBuilder(count);
                        err = PSXGetActiveConnections(this.psxId, varValue, ref count);
                    } while (PsxError.InvalidParam == err);
                    if (!PsxException.IsError(err) && (count > 0))
                    {
                        strArray = varValue.ToString().Split(new char[] { ',' });
                    }
                }
                if (PsxException.IsError(err))
                {
                    throw new PsxException(err);
                }
                return strArray;
            }
        }

        public string ServiceName
        {
            get
            {
                if (this.isDisposed)
                {
                    throw new ObjectDisposedException(this.ToString());
                }
                bool server = false;
                StringBuilder stringValue = new StringBuilder(250);
                int capacity = stringValue.Capacity;
                PsxError err = PSXIsServer(this.psxId, ref server, stringValue, ref capacity);
                if (PsxException.IsError(err))
                {
                    throw new PsxException(err);
                }
                return stringValue.ToString();
            }
        }

        public string Text
        {
            get { return Convert.ToString(this.GetControlProperty("Display", "Text")); }
            set { this.SetControlProperty("Display", "Text", value); }
        }

        public bool TopMost
        {
            get { return Convert.ToBoolean(this.GetControlProperty("Display", "TopMost")); }
            set { this.SetControlProperty("Display", "TopMost", value); }
        }

        public bool Visible
        {
            get { return Convert.ToBoolean(this.GetControlProperty("Display", "Visible")); }
            set { this.SetControlProperty("Display", "Visible", value); }
        }

        public enum FillStyle
        {
            UpDown,
            DownUp
        }

        private delegate void PSXEventHandler(int psxId, [MarshalAs(UnmanagedType.LPWStr)]
string connectionName, [MarshalAs(UnmanagedType.LPWStr)]
string controlName, [MarshalAs(UnmanagedType.LPWStr)]
string contextName, [MarshalAs(UnmanagedType.LPWStr)]
string eventName, [MarshalAs(UnmanagedType.Struct)]
object param);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }
        }

        public enum ScrollType
        {
            StepDown,
            StepUp,
            PageDown,
            PageUp,
            ScrollBottom,
            ScrollTop
        }

        public enum State
        {
            Normal,
            Pushed,
            Disabled,
            Highlighted
        }
    }
}