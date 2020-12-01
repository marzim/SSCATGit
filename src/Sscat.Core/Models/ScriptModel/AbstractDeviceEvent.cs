// <copyright file="AbstractDeviceEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the AbstractDeviceEvent class
    /// </summary>
    /// <typeparam name="T">Base model</typeparam>
    [Serializable]
    public abstract class AbstractDeviceEvent<T> : BaseModel<T>, IDeviceEvent, IStimulus
    {
        /// <summary>
        /// Event ID
        /// </summary>
        private string _id;

        /// <summary>
        /// Event value
        /// </summary>
        private string _val;

        /// <summary>
        /// Event sequence ID
        /// </summary>
        private int _seqId;

        /// <summary>
        /// Whether or not event is forgivable 
        /// </summary>
        private bool _isForgivable = false;

        /// <summary>
        /// Whether or not event is exempted
        /// </summary>
        private bool _isExempted = false;

        /// <summary>
        /// Initializes a new instance of the AbstractDeviceEvent class
        /// </summary>
        /// <param name="id">event id</param>
        /// <param name="val">event value</param>
        /// <param name="seqId">sequence id</param>
        public AbstractDeviceEvent(string id, string val, int seqId)
        {
            Id = id;
            Value = val;
            SeqId = seqId;

            switch (id)
            {
                case Constants.DeviceType.RECEIPT_ITEM:
                case Constants.DeviceType.AMOUNT_TAX_DUE:
                case Constants.DeviceType.CHANGE_DUE_AND_TENDER_TYPE:
                case Constants.DeviceType.TRI_COLOR_LIGHT:
                case Constants.DeviceType.SAY_PHRASE:
                case Constants.DeviceType.SAY_AMOUNT:
                case Constants.DeviceType.SAY_SECURITY:
                case Constants.DeviceType.CM_COUNT_AFTER_CHANGES:
                case Constants.DeviceType.CM_COUNT_PERCENTAGE:
                case Constants.DeviceType.CM_DISPENSER_CAPACITY:
                case Constants.DeviceType.CM_GET_ERROR_CODE:
                case Constants.DeviceType.CM_POSITION:
                case Constants.DeviceType.CM_POSITION_DATA:
                case Constants.DeviceType.CM_MESSAGE:
                case Constants.DeviceType.TAB_REVERSE:
                case Constants.DeviceType.TAB_TRANSPORT:
                    _isForgivable = true;
                    break;
            }

            switch (id)
            {
                case Constants.DeviceType.TRI_COLOR_LIGHT:
                case Constants.DeviceType.SAY_PHRASE:
                case Constants.DeviceType.SAY_AMOUNT:
                case Constants.DeviceType.SAY_SECURITY:
                    _isExempted = true;
                    break;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the event is exempted
        /// </summary>
        public bool IsExempted
        {
            get { return _isExempted || ExemptedAudioEvents(); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the event is forgivable
        /// </summary>
        [XmlIgnore]
        public bool IsForgivable
        {
            get { return _isForgivable; }
            set { _isForgivable = value; }
        }

        /// <summary>
        /// Gets or sets the sequence ID
        /// </summary>
        [XmlIgnore]
        public virtual int SeqId
        {
            get { return _seqId; }
            set { _seqId = value; }
        }

        /// <summary>
        /// Gets or sets the event value
        /// </summary>
        [XmlIgnore]
        public virtual string Value
        {
            get { return _val; }
            set { _val = value; }
        }

        /// <summary>
        /// Gets or sets the event ID
        /// </summary>
        [XmlIgnore]
        public virtual string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the event is a stimulus
        /// </summary>
        public bool IsStimulus
        {
            get
            {
                return Id != Constants.DeviceType.AMOUNT_TAX_DUE
                    && Id != Constants.DeviceType.CHANGE_DUE_AND_TENDER_TYPE
                    && Id != Constants.DeviceType.RECEIPT_ITEM
                    && Id != Constants.DeviceType.TRI_COLOR_LIGHT
                    && Id != Constants.DeviceType.SAY_AMOUNT
                    && Id != Constants.DeviceType.SAY_PHRASE
                    && Id != Constants.DeviceType.SAY_SECURITY;
            }
        }

        /// <summary>
        /// Gets the type of event
        /// </summary>
        public abstract string Type { get; }

        /// <summary>
        /// Creates the device event
        /// </summary>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEvent CreateEvent();

        /// <summary>
        /// Creates the device event
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEvent CreateEvent(long time, bool enabled);

        /// <summary>
        /// Creates the script event
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="dateTime">date and time</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEvent CreateEvent(long time, DateTime dateTime, bool enabled);

        /// <summary>
        /// Creates the device event item
        /// </summary>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEventItem ToEventItem();

        /// <summary>
        /// Checks if the event is an exempted audio event
        /// </summary>
        /// <returns>Returns true if it is one of the exempted events, false otherwise</returns>
        public bool ExemptedAudioEvents()
        {
            return Value.Equals("blank.wav") || Value.Equals("30") || Value.Equals("31");
        }

        /// <summary>
        /// Creates a string about the device event
        /// </summary>
        /// <returns>Returns the device event information</returns>
        public override string ToString()
        {
            string eventValue = string.Empty;
            if (Id.Equals("CashAcceptorError") && Value == "0")
            {
                return "CashAcceptor: OK";
            }
            else if (_id.Equals("CoinAcceptorError") && Value == "0")
            {
                return "CoinAcceptor: OK";
            }
            else if (Id.Equals("Scanner"))
            {
                string[] values = Value.Split('~');
                eventValue = values[1];
            }
            else if (Id.Equals("MSR"))
            {
                eventValue = string.Empty;
            }
            else
            {
                eventValue = Value;
            }

            return string.Format("{0}: {1}", Id, eventValue);
        }

        /// <summary>
        /// Creates a string about the device event
        /// </summary>
        /// <returns>Returns the device event information</returns>
        public override string ToRepresentation()
        {
            string prefix = string.Empty;
            try
            {
                switch (Id)
                {
                    case Constants.DeviceType.AMOUNT_TAX_DUE:
                        string[] av = Value.Split(';');
                        return string.Format("{0}[Device] AmountTaxDue: AmountDue={1} TaxDue={2}", prefix, av[0].Trim(), av[1].Trim());
                    case Constants.DeviceType.CHANGE_DUE_AND_TENDER_TYPE:
                        string[] cd = Value.Split(';');
                        return string.Format("{0}[Device] ChangeDue: AmountPaid={1} ChangeDue={2} TenderType={3}", prefix, cd[0].Trim(), cd[2].Trim(), cd[3].Trim());
                    case Constants.DeviceType.RECEIPT_ITEM:
                        return string.Format("{0}[Device] ReceiptItem: Value={1}", prefix, Value.Replace("\t", " "));
                    case Constants.DeviceType.TRI_COLOR_LIGHT:
                        return TriColorLightFactory.GetString(this);
                    case Constants.DeviceType.SAY_PHRASE:
                        return string.Format("{0}[Device] SayPhrase: Value={1}", prefix, Value);
                    case Constants.DeviceType.SAY_AMOUNT:
                        string[] sa = Value.Split('~');
                        return string.Format("{0}[Device] SayAmount: Value={1}", prefix, sa[0]);
                    case Constants.DeviceType.SAY_SECURITY:
                        string[] ss = Value.Split('~');
                        return string.Format("{0}[Device] SaySecurity: Value={1}", prefix, ss[0]);
                    case Constants.DeviceType.CM_COUNT_PERCENTAGE:
                        return string.Format("{0}[Device] CMCountPercentage:", prefix);
                    case Constants.DeviceType.CM_CASH_COUNT:
                        string[] cc = Value.Split(';');
                        return string.Format("{0}[Device] CMCashCount: CoinCount={1} BillCount={2}", prefix, cc[0], cc[1]);
                    case Constants.DeviceType.SCALE:
                        return string.Format("{0}[Device] ProduceScale: Value={1}", prefix, Value);
                    case Constants.DeviceType.BAG_SCALE:
                        return string.Format("{0}[Device] BagScale: Value={1}", prefix, Value);
                    case Constants.DeviceType.CASH_ACCEPTOR:
                        return string.Format("{0}[Device] CashAcceptor: Value={1}", prefix, Value);
                    case Constants.DeviceType.COIN_ACCEPTOR:
                        return string.Format("{0}[Device] CoinAcceptor: Value={1}", prefix, Value);
                    case Constants.DeviceType.COUPON_SLIP:
                        return string.Format("{0}[Device] CouponSlip:", prefix);
                    case Constants.DeviceType.MSR:
                        return string.Format("{0}[Device] MSR: Value={1}", prefix, Value);
                    case Constants.DeviceType.PINPAD:
                        return string.Format("{0}[Device] Pinpad: Value={1}", prefix, Value);
                    case Constants.DeviceType.SIGNATURE_CAPTURE:
                        return string.Format("{0}[Device] SignatureCapture:", prefix);
                    case Constants.DeviceType.SCANNER:
                        string[] v = Value.Split('~');
                        return string.Format("{0}[Device] Scanner: BarcodeData={1} SymbologyCode={2}", prefix, v[1], v[2]);
                    case Constants.DeviceType.CASH_ACCEPTOR_ERROR:
                        return string.Format("{0}[Device] CashAcceptorError: Value={1}", prefix, CashAcceptorErrorStatus(Value));
                    case Constants.DeviceType.COIN_ACCEPTOR_ERROR:
                        return string.Format("{0}[Device] CoinAcceptorError: Value={1}", prefix, CoinAcceptorErrorStatus(Value));
                    case Constants.DeviceType.SCANNER_ERROR:
                        return string.Format("{0}[Device] ScannerError:", prefix);
                    case Constants.DeviceType.SIGNATURE_CAPTURE_ERROR:
                        return string.Format("{0}[Device] SignatureCaptureError:", prefix);
                    case Constants.DeviceType.TAB_TRANSPORT:
                        return string.Format("{0}[Device] TabTransport:", prefix);
                    case Constants.DeviceType.TAB_SMART_SCALE:
                        return string.Format("{0}[Device] TabSmartScale:", prefix);
                    case Constants.DeviceType.TAB_REVERSE:
                        return string.Format("{0}[Device] TabReverse:", prefix);
                    case Constants.DeviceType.POS_PRINTER:
                        return string.Format("{0}[Device] POSPrinter: Status={1}", prefix, PrinterErrorStatus(Value));
                    case Constants.DeviceType.ON_AUTOMATED_LOGIN:
                        return string.Format("{0}[Device] AutomatedLogin: Value={1}", prefix, Value == "1" ? "Valid" : "Invalidd");
                    case Constants.DeviceType.PLA_MATCHING_ITEM_RESPONSE:
                        return string.Format("{0}[Device] PLAMatchingItemResponse: Value={1}", prefix, Value);
                    case Constants.DeviceType.PLA_VERIFY_ITEM_INTERVENTION:
                        return string.Format("{0}[Device] PLAVerifyItemIntervention: Value={1}", prefix, Value);
                    case Constants.DeviceType.PLA_SHOW_MESSAGE:
                        return string.Format("{0}[Device] PLAShowMessage: Value={1}", prefix, Value);
                    case Constants.DeviceType.ESA_EMULATOR:
                        return string.Format("{0}[Device] ESAEmulator: Value={1}", prefix, Value);
                    case Constants.DeviceType.CASH_TROUGH:
                        return string.Format("{0}[Device] CashTrough: Value={1}", prefix, Value);
                    default:
                        throw new NullReferenceException();
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(string.Format("Event type {0} not found, please check for any mispelled events.", Id));
            }
        }

        /// <summary>
        /// Checks if the event item given is same type as device event
        /// </summary>
        /// <param name="eventItemToCompareWith">event item to compare with</param>
        /// <returns>Returns true if event item type is the same, false otherwise</returns>
        public virtual bool IsSimilarEventItemWith(IScriptEventItem eventItemToCompareWith)
        {
            bool isSimilar = false;
            if (eventItemToCompareWith != null &&
                eventItemToCompareWith is IDeviceEvent &&
                (eventItemToCompareWith as IDeviceEvent).Id.Equals(this.Id))
            {
                isSimilar = true;
            }

            return isSimilar;
        }

        /// <summary>
        /// Cash acceptor error status
        /// </summary>
        /// <param name="value">error value</param>
        /// <returns>Returns the error status</returns>
        private string CashAcceptorErrorStatus(string value)
        {
            if (value == Constants.CashAcceptorError.CASSETTE_OUT || value == Constants.CashAcceptorError.CASSETTE_OUT_G2)
            {
                return "Cassette Out";
            }
            else if (value == Constants.CashAcceptorError.FAIL || value == Constants.CashAcceptorError.FAIL_G2)
            {
                return "Fail";
            }
            else if (value == Constants.CashAcceptorError.JAM || value == Constants.CashAcceptorError.JAM_G2)
            {
                return "Jam";
            }
            else if (value == Constants.CashAcceptorError.RESET || value == Constants.CashAcceptorError.RESET_G2)
            {
                return "Reset";
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Coin accepter error status
        /// </summary>
        /// <param name="value">error value</param>
        /// <returns>Returns error status</returns>
        private string CoinAcceptorErrorStatus(string value)
        {
            if (value == Constants.CoinAcceptorError.FAIL || value == Constants.CoinAcceptorError.FAIL_G2)
            {
                return "Fail";
            }
            else if (value == Constants.CoinAcceptorError.JAM || value == Constants.CoinAcceptorError.JAM_G2)
            {
                return "Jam";
            }
            else if (value == Constants.CoinAcceptorError.RESET || value == Constants.CoinAcceptorError.RESET_G2)
            {
                return "Reset";
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Signature capture error status
        /// </summary>
        /// <param name="value">error value</param>
        /// <returns>Returns the error status</returns>
        private string SignatureCaptureErrorStatus(string value)
        {
            if (value == Constants.SignatureCaptureError.FAILURE)
            {
                return "Failure";
            }
            else if (value == Constants.SignatureCaptureError.NO_HARDWARE)
            {
                return "No Hardware";
            }
            else if (value == Constants.SignatureCaptureError.OFFLINE)
            {
                return "Offline";
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Printer error status
        /// </summary>
        /// <param name="value">error value</param>
        /// <returns>Returns the status</returns>
        private string PrinterErrorStatus(string value)
        {
            if (value == Constants.PrinterReceiptError.COVER_OPEN || value == "-99")
            {
                return "Cover Open";
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
}
