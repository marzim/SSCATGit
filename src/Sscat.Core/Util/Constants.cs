// <copyright file="Constants.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the Constants class
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Initializes a new instance of the ConsoleCommand class
        /// </summary>
        public static class ConsoleCommand
        {
            /// <summary>
            /// Console Command constant for help
            /// </summary>
            public const string HELP = "help";

            /// <summary>
            /// Console Command constant for killing SSCO
            /// </summary>
            public const string KILL_SSCO = "lane.kill";

            /// <summary>
            /// Console Command constant for launching SSCO
            /// </summary>
            public const string LAUNCH_SSCO = "lane.start";

            /// <summary>
            /// Console Command constant for showing the SSCO version
            /// </summary>
            public const string SHOW_SSCO_VERSION = "lane.version";

            /// <summary>
            /// Console Command constant for deleting SCOT logs
            /// </summary>
            public const string DELETE_SCOT_LOGS = "logs.delete";

            /// <summary>
            /// Console Command constant for log hooks
            /// </summary>
            public const string HOOK_LOGS = "logs.hook";

            /// <summary>
            /// Console Command constant for listing logs
            /// </summary>
            public const string LIST_LOGS = "logs.list";

            /// <summary>
            /// Console Command constant for generating scripts
            /// </summary>
            public const string GENERATE_SCRIPTS = "scripts.generate";

            /// <summary>
            /// Console Command constant for listing scripts
            /// </summary>
            public const string LIST_SCRIPTS = "scripts.list";

            /// <summary>
            /// Console Command constant for playing scripts
            /// </summary>
            public const string PLAY_SCRIPTS = "scripts.play";

            /// <summary>
            /// Console Command constant for showing scripts
            /// </summary>
            public const string SHOW_SCRIPTS = "scripts.show";

            /// <summary>
            /// Console Command constant for converting scripts
            /// </summary>
            public const string CONVERT_SCRIPTS = "scripts.convert";
        }

        /// <summary>
        /// Initializes a new instance of the DeviceType class
        /// </summary>
        public static class DeviceType
        {
            /// <summary>
            /// Device type constant for scale
            /// </summary>
            public const string SCALE = "Scale";

            /// <summary>
            /// Device type constant for scanner
            /// </summary>
            public const string SCANNER = "Scanner";

            /// <summary>
            /// Device type constant for scanner error
            /// </summary>
            public const string SCANNER_ERROR = "ScannerError";

            /// <summary>
            /// Device type constant for receipt item
            /// </summary>
            public const string RECEIPT_ITEM = "ReceiptItem";

            /// <summary>
            /// Device type constant for MSR
            /// </summary>
            public const string MSR = "MSR";

            /// <summary>
            /// Device type constant for signature capture
            /// </summary>
            public const string SIGNATURE_CAPTURE = "SignatureCapture";

            /// <summary>
            /// Device type constant for signature capture error
            /// </summary>
            public const string SIGNATURE_CAPTURE_ERROR = "SignatureCaptureError";

            /// <summary>
            /// Device type constant for pin pad
            /// </summary>
            public const string PINPAD = "PinPad";

            /// <summary>
            /// Device type constant for coupon slip
            /// </summary>
            public const string COUPON_SLIP = "CouponSlip";

            /// <summary>
            /// Device type constant for amount tax due
            /// </summary>
            public const string AMOUNT_TAX_DUE = "AmountDue;TaxDue";

            /// <summary>
            /// Device type constant for change due and tender type
            /// </summary>
            public const string CHANGE_DUE_AND_TENDER_TYPE = "ChangeDueAndTenderType";

            /// <summary>
            /// Device type constant for bag scale
            /// </summary>
            public const string BAG_SCALE = "BagScale";

            /// <summary>
            /// Device type constant for cash acceptor
            /// </summary>
            public const string CASH_ACCEPTOR = "CashAcceptor";

            /// <summary>
            /// Device type constant for cash trough
            /// </summary>
            public const string CASH_TROUGH = "CashTrough";

            /// <summary>
            /// Device type constant for cash acceptor error
            /// </summary>
            public const string CASH_ACCEPTOR_ERROR = "CashAcceptorError";

            /// <summary>
            /// Device type constant for coin acceptor
            /// </summary>
            public const string COIN_ACCEPTOR = "CoinAcceptor";

            /// <summary>
            /// Device type constant for coin acceptor error
            /// </summary>
            public const string COIN_ACCEPTOR_ERROR = "CoinAcceptorError";

            /// <summary>
            /// Device type constant for tri color light
            /// </summary>
            public const string TRI_COLOR_LIGHT = "TriColorLight";

            /// <summary>
            /// Device type constant for say phrase
            /// </summary>
            public const string SAY_PHRASE = "SayPhrase";

            /// <summary>
            /// Device type constant for say amount
            /// </summary>
            public const string SAY_AMOUNT = "SayAmount";

            /// <summary>
            /// Device type constant for say security
            /// </summary>
            public const string SAY_SECURITY = "SaySecurity";

            /// <summary>
            /// Device type constant for CM dispenser capacity
            /// </summary>
            public const string CM_DISPENSER_CAPACITY = "CMDispenserCapacity";

            /// <summary>
            /// Device type constant for CM count percentage
            /// </summary>
            public const string CM_COUNT_PERCENTAGE = "CMCountPercentage";

            /// <summary>
            /// Device type constant for CM cash count
            /// </summary>
            public const string CM_CASH_COUNT = "CMCashCount";

            /// <summary>
            /// Device type constant for CM get error code
            /// </summary>
            public const string CM_GET_ERROR_CODE = "CMGetErrorCode";

            /// <summary>
            /// Device type constant for CM position
            /// </summary>
            public const string CM_POSITION = "CMPosition";

            /// <summary>
            /// Device type constant for CM position data
            /// </summary>
            public const string CM_POSITION_DATA = "CMPositionData";

            /// <summary>
            /// Device type constant for CM count after changes
            /// </summary>
            public const string CM_COUNT_AFTER_CHANGES = "CMCountAfterChanges";

            /// <summary>
            /// Device type constant for CM message
            /// </summary>
            public const string CM_MESSAGE = "CMMessage";

            /// <summary>
            /// Device type constant for TAB transport
            /// </summary>
            public const string TAB_TRANSPORT = "TABTransport";

            /// <summary>
            /// Device type constant for TAB smart scale
            /// </summary>
            public const string TAB_SMART_SCALE = "TABSmartScale";

            /// <summary>
            /// Device type constant for TAB reverse
            /// </summary>
            public const string TAB_REVERSE = "TABReverse";

            /// <summary>
            /// Device type constant for printer error
            /// </summary>
            public const string PRINTER_ERROR = "PrinterError";

            /// <summary>
            /// Device type constant for POS printer
            /// </summary>
            public const string POS_PRINTER = "POSPrinter";

            /// <summary>
            /// Device type constant for on automated login
            /// </summary>
            public const string ON_AUTOMATED_LOGIN = "OnAutomatedLogin";

            /// <summary>
            /// Device type constant for Scanner Part 1
            /// </summary>
            public const string SCANNER_PART1 = "ScannerPart1";

            /// <summary>
            /// Device type constant for Scanner Part 2
            /// </summary>
            public const string SCANNER_PART2 = "ScannerPart2";

            /// <summary>
            /// Device type constant for PLA Matching Item Response
            /// </summary>
            public const string PLA_MATCHING_ITEM_RESPONSE = "PLAMatchingItemResponse";

            /// <summary>
            /// Device type constant for PLA Verify Item Intervention
            /// </summary>
            public const string PLA_VERIFY_ITEM_INTERVENTION = "PLAVerifyItemIntervention";
            
            /// <summary>
            /// Device type constant for PLA Show Message
            /// </summary>
            public const string PLA_SHOW_MESSAGE = "PLAShowMessage";

            /// <summary>
            /// Device type constant for ESA Emulator
            /// </summary>
            public const string ESA_EMULATOR = "ESAEmulator";
        }

        /// <summary>
        /// Initializes a new instance of the CashAcceptorError class
        /// </summary>
        public static class CashAcceptorError
        {
            /// <summary>
            /// Cash acceptor error constant for reset
            /// </summary>
            public const string RESET = "4";

            /// <summary>
            /// Cash acceptor error constant for jam
            /// </summary>
            public const string JAM = "5";

            /// <summary>
            /// Cash acceptor error constant for fail
            /// </summary>
            public const string FAIL = "6";

            /// <summary>
            /// Cash acceptor error constant for cassette out
            /// </summary>
            public const string CASSETTE_OUT = "9"; // TODO: Or 10?

            /// <summary>
            /// Cash acceptor error constant for reset
            /// FIXME: This is from G2 log values
            /// </summary>
            public const string RESET_G2 = "64";

            /// <summary>
            /// Cash acceptor error constant for jam
            /// </summary>
            public const string JAM_G2 = "65";

            /// <summary>
            /// Cash acceptor error constant for fail
            /// </summary>
            public const string FAIL_G2 = "66";

            /// <summary>
            /// Cash acceptor error constant for cassette out
            /// </summary>
            public const string CASSETTE_OUT_G2 = "69"; // TODO: Or 70?
        }

        /// <summary>
        /// Initializes a new instance of the CoinAcceptorError class
        /// </summary>
        public static class CoinAcceptorError
        {
            /// <summary>
            /// Coin acceptor error constant for reset
            /// </summary>
            public const string RESET = "4";

            /// <summary>
            /// Coin acceptor error constant for jam
            /// </summary>
            public const string JAM = "5";

            /// <summary>
            /// Coin acceptor error constant for fail
            /// </summary>
            public const string FAIL = "6";

            /// <summary>
            /// Coin acceptor error constant for reset
            /// FIXME: This is from G2 log values
            /// </summary>
            public const string RESET_G2 = "84";

            /// <summary>
            /// Coin acceptor error constant for jam
            /// </summary>
            public const string JAM_G2 = "85";

            /// <summary>
            /// Coin acceptor error constant for fail
            /// </summary>
            public const string FAIL_G2 = "86";
        }

        /// <summary>
        /// Initializes a new instance of the SignatureCaptureError class
        /// </summary>
        public static class SignatureCaptureError
        {
            /// <summary>
            /// Signature capture error constant for failure
            /// </summary>
            public const string FAILURE = "111";

            /// <summary>
            /// Signature capture error constant for no hardware
            /// </summary>
            public const string NO_HARDWARE = "107";

            /// <summary>
            /// Signature capture error constant for being offline
            /// </summary>
            public const string OFFLINE = "108";
        }

        /// <summary>
        /// Initializes a new instance of the XMEvent class
        /// </summary>
        public static class XmEvent
        {
            /// <summary>
            /// XMEvent constant for XM print data
            /// </summary>
            public const string XM_PRINT_DATA = "XmPrintData";

            /// <summary>
            /// XMEvent constant for XM alert message
            /// </summary>
            public const string XM_ALERT_MESSAGE = "XmAlertMessage";

            /// <summary>
            /// XMEvent constant for XM count changes
            /// </summary>
            public const string XM_COUNT_CHANGES = "XmCountChanges";
        }

        /// <summary>
        /// Initializes a new instance of the PsxEvent class
        /// </summary>
        public static class PsxEvent
        {
            /// <summary>
            /// PSXEvent constant for change context
            /// </summary>
            public const string CHANGE_CONTEXT = "ChangeContext";

            /// <summary>
            /// PSXEvent constant for click
            /// </summary>
            public const string CLICK = "Click";

            /// <summary>
            /// PSXEvent constant for key press
            /// </summary>
            public const string KEY_PRESS = "KeyPress";

            /// <summary>
            /// PSXEvent constant for key down
            /// </summary>
            public const string KEY_DOWN = "KeyDown";

            /// <summary>
            /// PSXEvent constant for connecting remotely
            /// </summary>
            public const string CONNECT_REMOTE = "ConnectRemote";

            /// <summary>
            /// PSXEvent constant for change theme
            /// </summary>
            public const string CHANGE_THEME = "ChangeTheme";
        }

        /// <summary>
        /// Initializes a new instance of the WarningEvent class
        /// </summary>
        public static class WarningEvent
        {
            /// <summary>
            /// WarningEvent constant for clipped text
            /// </summary>
            public const string CLIPPED_TEXT = "ClippedText";

            /// <summary>
            /// WarningEvent constant for log mismatch
            /// </summary>
            public const string LOG_MISMATCH = "LogMismatch";

            /// <summary>
            /// WarningEvent constant for log not found
            /// </summary>
            public const string LOG_NOT_FOUND = "LogNotFound";

            /// <summary>
            /// WarningEvent constant for Receipt Item Exception
            /// </summary>
            public const string RECEIPT_ITEM_EXCEPTION = "ReceiptItemException";
            
            /// <summary>
            /// WarningEvent constant for Receipt Item Exception
            /// </summary>
            public const string APPLICATION_EVENT_FAILURE = "ApplicationEventFailure";
        }

        /// <summary>
        /// Initializes a new instance of the WarningEvent class
        /// </summary>
        public static class ErrorEvent
        {
            /// <summary>
            /// WarningEvent constant for clipped text
            /// </summary>
            public const string POS_OUT_OF_SYNCH = "POSOutOfSynch";
        }

        /// <summary>
        /// Initializes a new instance of the UIValidation class
        /// </summary>
        public static class UIValidationEvent
        {
            /// <summary>
            /// UIValidationEvent constant for property change
            /// </summary>
            public const string PROPERTY_CHANGE = "PropertyChange";
        }

        /// <summary>
        /// Initializes a new instance of the UIAutoTestEvent class
        /// </summary>
        public static class UIAutoTestEvent
        {
            /// <summary>
            /// UIAutoTestEvent constant for button click
            /// </summary>
            public const string BUTTON_CLICK = "ButtonClick";

            /// <summary>
            /// UIAutoTestEvent constant for keyboard button click
            /// </summary>
            public const string KEYBOARD_BUTTON_CLICK = "KeyboardButtonClick";

            /// <summary>
            /// UIAutoTestEvent constant for category button click
            /// </summary>
            public const string CATEGORY_CLICK = "CategoryClick";

            /// <summary>
            /// UIAutoTestEvent constant for sliding grid page button click
            /// </summary>
            public const string SLIDING_GRID_PAGE_CLICK = "SlidingGridPageClick";

            /// <summary>
            /// UIAutoTestEvent constant for list button click
            /// </summary>
            public const string LIST_BUTTON_CLICK = "ListButtonClick";

            /// <summary>
            /// UIAutoTestEvent constant for swipe left
            /// </summary>
            public const string SWIPE_LEFT = "SwipeLeft";

            /// <summary>
            /// UIAutoTestEvent constant for swipe right
            /// </summary>
            public const string SWIPE_RIGHT = "SwipeRight";

            /// <summary>
            /// UIAutoTestEvent constant for sign signature
            /// </summary>
            public const string SIGN_SIGNATURE = "SignSignature";

            /// <summary>
            /// UIAutoTestEvent constant for context changed
            /// </summary>
            public const string CONTEXT_CHANGED = "ContextChanged";

            /// <summary>
            /// UIAutoTestEvent constant for end of transaction
            /// </summary>
            public const string END_OF_TRANSACTION = "EndOfTransaction";

            /// <summary>
            /// UIAutoTestEvent constant for hardware uNav
            /// </summary>
            public const string HW_UNAV = "HWuNav";

            /// <summary>
            /// UIAutoTestEvent constant for automated login
            /// </summary>
            public const string AUTOMATED_LOGIN = "AutomatedLogin";

            /// <summary>
            /// UIAutoTestEvent constant for cart index changed
            /// </summary>
            public const string CART_INDEX_CHANGED = "CartIndexChanged";
        }

        /// <summary>
        /// Initializes a new instance of the UtilityEvent class
        /// </summary>
        public static class UtilityEvent
        {
            /// <summary>
            /// UtilityEvents constant for change context
            /// </summary>
            public const string UTILITY_SLEEP = "Sleep";
        }

        /// <summary>
        /// Initializes a new instance of the LaunchPadEvent class
        /// </summary>
        public static class LaunchPadEvent
        {
            /// <summary>
            /// LaunchPadEvent constant for change context
            /// </summary>
            public const string CHANGE_CONTEXT = "ChangeContext";

            /// <summary>
            /// LaunchPadEvent constant for change focus
            /// </summary>
            public const string CHANGE_FOCUS = "ChangeFocus";

            /// <summary>
            /// LaunchPadEvent constant for click
            /// </summary>
            public const string CLICK = "Click";
        }

        /// <summary>
        /// Initializes a new instance of the ReportEvent class
        /// </summary>
        public static class ReportEvent
        {
            /// <summary>
            /// ReportEvent constant for running reports
            /// </summary>
            public const string RUN_REPORTS = "RunReports";

            /// <summary>
            /// ReportEvent constant for reports menu
            /// </summary>
            public const string REPORTS_MENU = "ReportsMenu";
        }

        /// <summary>
        /// Initializes a new instance of the WldbEvent class
        /// </summary>
        public static class WldbEvent
        {
            /// <summary>
            /// WLDBEvent constant for updating
            /// </summary>
            public const string UPDATE = "Update";

            /// <summary>
            /// WLDBEvent constant for backup
            /// </summary>
            public const string BACKUP = "Backup";
        }

        /// <summary>
        /// Initializes a new instance of the MSCard class
        /// </summary>
        public static class MSCard
        {
            /// <summary>
            /// MSCard constant for name of default MS card
            /// </summary>
            public const string NAME_OF_DEFAULT_MS_CARD = "Default";
        }

        /// <summary>
        /// Initializes a new instance of the PrinterReceiptError class
        /// </summary>
        public static class PrinterReceiptError
        {
            /// <summary>
            /// PrinterReceiptError constant for cover opened
            /// </summary>
            public const string COVER_OPEN = "201";

            /// <summary>
            /// PrinterReceiptError constant for failure
            /// </summary>
            public const string FAILURE = "111";

            /// <summary>
            /// PrinterReceiptError constant for no hardware
            /// </summary>
            public const string NO_HARDWARE = "107";

            /// <summary>
            /// PrinterReceiptError constant for no paper
            /// </summary>
            public const string NO_PAPER = "203";

            /// <summary>
            /// PrinterReceiptError constant for offline
            /// </summary>
            public const string OFFLINE = "108";

            /// <summary>
            /// PrinterReceiptError constant for printer timeout
            /// </summary>
            public const string PRINTER_TIMEOUT = "112";
        }

        /// <summary>
        /// Initializes a new instance of the TriColorLight class
        /// </summary>
        public static class TriColorLight
        {
            /// <summary>
            /// TriColorLight constant for green
            /// </summary>
            public const int GREEN = 1;

            /// <summary>
            /// TriColorLight constant for yellow
            /// </summary>
            public const int YELLOW = 2;

            /// <summary>
            /// TriColorLight constant for red
            /// </summary>
            public const int RED = 3;
        }

        /// <summary>
        /// Initializes a new instance of the TriColorLightState class
        /// </summary>
        public static class TriColorLightState
        {
            /// <summary>
            /// TriColorLightState constant for off
            /// </summary>
            public const int OFF = 0;

            /// <summary>
            /// TriColorLightState constant for on
            /// </summary>
            public const int ON = 1;

            /// <summary>
            /// TriColorLightState constant for blink quarter hertz
            /// </summary>
            public const int BLINK_QUARTER_HERTZ = 2;

            /// <summary>
            /// TriColorLightState constant for blink half hertz
            /// </summary>
            public const int BLINK_HALF_HERTZ = 3;

            /// <summary>
            /// TriColorLightState constant for blink 1 hertz
            /// </summary>
            public const int BLINK_1_HERTZ = 4;

            /// <summary>
            /// TriColorLightState constant for blink 2 hertz
            /// </summary>
            public const int BLINK_2_HERTZ = 5;

            /// <summary>
            /// TriColorLightState constant for blink 4 hertz
            /// </summary>
            public const int BLINK_4_HERTZ = 6;
        }

        /// <summary>
        /// Initializes a new instance of the EventState class
        /// </summary>
        public static class EventState
        {
            /// <summary>
            /// EventState constant for clicking credentials
            /// </summary>
            public const string CLICKING_CREDENTIALS = "ClickingCredentials";

            /// <summary>
            /// EventState constant for clicking enter
            /// </summary>
            public const string CLICKING_ENTER = "ClickingEnter";

            /// <summary>
            /// EventState constant for clicking go back
            /// </summary>
            public const string CLICKING_GO_BACK = "ClickingGoBack";

            /// <summary>
            /// EventState constant for clicking store login
            /// </summary>
            public const string CLICKING_STORE_LOGIN = "ClickingStoreLogin";

            /// <summary>
            /// EventState constant for not PSX
            /// </summary>
            public const string NOT_PSX = "NotPsx";

            /// <summary>
            /// EventState constant for not login event
            /// </summary>
            public const string NOT_LOGIN_EVENT = "NotLoginEvent";

            /// <summary>
            /// EventState constant for displaying login
            /// </summary>
            public const string DISPLAYING_LOGIN = "DisplayingLogin";

            /// <summary>
            /// EventState constant for displaying screen before login
            /// </summary>
            public const string DISPLAYING_SCREEN_BEFORE_LOGIN = "DisplayScreenBeforeLogin";

            /// <summary>
            /// EventState constant for device event forgivable
            /// </summary>
            public const string DEVICE_EVENT_FORGIVABLE = "DeviceEventForgivable";

            /// <summary>
            /// EventState constant for scanner operator
            /// </summary>
            public const string SCANNER_OPERATOR = "ScannerOperator";

            /// <summary>
            /// EventState constant for invalid login
            /// </summary>
            public const string INVALID_LOGIN = "InvalidLogin";

            /// <summary>
            /// EventState constant for launch pad event
            /// </summary>
            public const string LAUNCH_PAD_EVENT = "LaunchPadEvent";
        }

        /// <summary>
        /// Registry constants class
        /// </summary>
        public static class RegistryConstants
        {
            /// <summary>
            /// Maximum packet size value of PipeServer constant
            /// </summary>
            public const string MaximumPacketSizeKeyValue = "10485760";

            /// <summary>
            /// PipeServer maximum packet size key
            /// </summary>
            public const string PipeServerMaxPacketSizeKey = "MaxPacketSize";
        }

    }
}