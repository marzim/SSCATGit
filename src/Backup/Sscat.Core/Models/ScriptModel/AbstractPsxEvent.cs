// <copyright file="AbstractPsxEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Ncr.Core.Util;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the AbstractPsxEvent class
    /// </summary>
    /// <typeparam name="T">base model</typeparam>
    [Serializable]
    public abstract class AbstractPsxEvent<T> : BaseModel<T>, IPsxEvent, IStimulus
    {
        /// <summary>
        /// Remote connection name
        /// </summary>
        private string _remoteConnection;

        /// <summary>
        /// Event name
        /// </summary>
        private string _eventName;

        /// <summary>
        /// Event parameters
        /// </summary>
        private string _param;

        /// <summary>
        /// Control name
        /// </summary>
        private string _control;

        /// <summary>
        /// Context name
        /// </summary>
        private string _context;

        /// <summary>
        /// Event ID
        /// </summary>
        private string _id;

        /// <summary>
        /// Sequence ID
        /// </summary>
        private int _seqId;

        /// <summary>
        /// Whether or not event is forgivable
        /// </summary>
        private bool _isForgivable = false;

        /// <summary>
        /// Initializes a new instance of the AbstractPsxEvent class
        /// </summary>
        public AbstractPsxEvent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AbstractPsxEvent class
        /// </summary>
        /// <param name="id">event id</param>
        /// <param name="context">context name</param>
        /// <param name="control">control name</param>
        /// <param name="eventName">event name</param>
        /// <param name="param">event parameters</param>
        /// <param name="remoteConnection">remote connection name</param>
        /// <param name="seqId">sequence ID</param>
        public AbstractPsxEvent(string id, string context, string control, string eventName, string param, string remoteConnection, int seqId)
        {
            Id = id;
            Context = context;
            Control = control;
            Event = eventName;
            Param = param;
            RemoteConnection = remoteConnection;
            SeqId = seqId;

            switch (eventName)
            {
                case Constants.PsxEvent.CONNECT_REMOTE:
                    _isForgivable = true;
                    break;
                case Constants.PsxEvent.CHANGE_CONTEXT:
                case Constants.PsxEvent.CHANGE_THEME:
                case Constants.PsxEvent.CLICK:
                case Constants.PsxEvent.KEY_DOWN:
                case Constants.PsxEvent.KEY_PRESS:
                case Constants.LaunchPadEvent.CHANGE_FOCUS:
                default:
                    _isForgivable = false;
                    break;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the event is forgivable
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
        /// Gets or sets the event ID
        /// </summary>
        [XmlIgnore]
        public virtual string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the context name
        /// </summary>
        [XmlIgnore]
        public virtual string Context
        {
            get { return _context; }
            set { _context = value; }
        }

        /// <summary>
        /// Gets or sets the control name
        /// </summary>
        [XmlIgnore]
        public virtual string Control
        {
            get { return _control; }
            set { _control = value; }
        }

        /// <summary>
        /// Gets or sets the event parameters
        /// </summary>
        [XmlIgnore]
        public virtual string Param
        {
            get { return _param; }
            set { _param = value; }
        }

        /// <summary>
        /// Gets or sets the event name
        /// </summary>
        [XmlIgnore]
        public virtual string Event
        {
            get { return _eventName; }
            set { _eventName = value; }
        }

        /// <summary>
        /// Gets or sets the remote connection name
        /// </summary>
        [XmlIgnore]
        public virtual string RemoteConnection
        {
            get { return _remoteConnection; }
            set { _remoteConnection = value; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the event is a stimulus
        /// </summary>
        public bool IsStimulus
        {
            get
            {
                return Event == Constants.PsxEvent.CLICK || Event == Constants.PsxEvent.KEY_DOWN || Event == Constants.PsxEvent.KEY_PRESS;
            }
        }

        /// <summary>
        /// Gets a value indicating whether it is an exempted event
        /// </summary>
        public bool IsExempted
        {
            get
            {
                return Event.Equals("DisconnectRemote") ||
                    Event.Equals("RemoteData") ||
                    Event.Equals("KeyPress") ||
                    Context.Equals("Startup") ||
                    Context.Equals("OutOfService2") ||
                    (Event.Equals("KeyDown") && !IsValidKeyDown()) ||
                    ((Context.Equals("XMCashStatus") || Context.Equals("XMLockScreen")) &&
                    (Control.Equals("XMKeyBoardP4") || Control.Equals("SMButton1")));
            }
        }

        /// <summary>
        /// Gets a value indicating whether it is an exempted launch pad psx event
        /// </summary>
        public bool ExemptedLaunchPadPsxEvent
        {
            get
            {
                return IsValidLaunchPadPsxKey();
            }
        }

        /// <summary>
        /// Gets a value indicating whether it has a RAP connection
        /// </summary>
        public virtual bool HasRapConnection
        {
            get
            {
                return RemoteConnection.IndexOf("RAP") >= 0 && !RemoteConnection.Equals(string.Empty);
            }
        }

        /// <summary>
        /// Gets the type of event
        /// </summary>
        public abstract string Type { get; }

        /// <summary>
        /// Checks if the key is an invalid key press
        /// </summary>
        /// <returns>Returns true if invalid, false otherwise</returns>
        public bool InvalidKeyPress()
        {
            return Param.Equals("\b") || Param.Equals("\x1b") || Param.Equals("\x14");
        }

        /// <summary>
        /// Checks if the key is a valid down key
        /// </summary>
        /// <returns>Returns true if valid, false otherwise</returns>
        public bool IsValidKeyDown()
        {
            int key = ConvertUtility.ToInt32(Param);
            if (((key >= 96) && (key <= 105)) || // Numpads 0-9
                ((key >= 48) && (key <= 57)) || // keyboard 0-9
                ((key >= 65) && (key <= 90)) || // A - Z
                (key == 13) || (key == 27) || (key == 100) || (key == 190) || // 13 = Enter, 27 = ESC, 110 = ., 190 = .
                (key == 8) || (key == 32) || (key == 189))
            {
                // 8 = BACKSPACE, 32 = SPACEBAR, 189 = -
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if launch pad psx key is valid
        /// </summary>
        /// <returns>Returns true if valid, false otherwise</returns>
        public bool IsValidLaunchPadPsxKey()
        {
            if ((Control.Equals("Echo") && Context.Equals("EnterID") && Event.Equals("ChangeFocus")) ||
                (Control.Equals("Display") && Context.Equals("EnterID") && Event.Equals("ChangeContext")) ||
                (Control.Equals("Display") && Context.Equals("StartupContext") && Event.Equals("ChangeContext")) ||
                (Control.Equals("Display") && Context.Equals("FastLaneContext") && Event.Equals("ChangeContext")) ||
                (Event.Equals("KeyDown") && !IsValidKeyDown()))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Absolute connection name
        /// </summary>
        /// <returns>Returns the connection name</returns>
        public string AbsoluteConnectionName()
        {
            if (HasRapConnection)
            {
                if (SSCOHelper.IsNGUI())
                {
                    string retVal = string.Empty;
                    retVal = _remoteConnection.Replace(".RapNet", string.Empty);
                    retVal = retVal.Replace("RAP.", string.Empty);
                    return retVal;
                }
                else
                {
                    return _remoteConnection.Replace("RAP.", string.Empty);
                }
            }

            return _remoteConnection;
        }

        /// <summary>
        /// Creates a string about the psx event
        /// </summary>
        /// <returns>Returns the psx event information</returns>
        public override string ToString()
        {
            string p = HasRapConnection ? string.Empty : Param;
            string control = HasRapConnection && Control.Contains("RAPSingle") ? "RAPSingle" : Control;

            return string.Format("Context: {0}, Control: {1}, Event: {2}, Param: {3}", Context, control, Event, p);
        }

        /// <summary>
        /// Creates a string about the psx event
        /// </summary>
        /// <returns>Returns the psx event information</returns>
        public override string ToRepresentation()
        {
            switch (Event)
            {
                case Constants.PsxEvent.CHANGE_CONTEXT:
                    return string.Format("[PSX] Event=ChangeContext Screen={0}", Context);
                case Constants.PsxEvent.CHANGE_THEME:
                    return string.Format("[PSX] Event=ChangeTheme Screen={0}", Context);
                case Constants.PsxEvent.CLICK:
                    return string.Format("[PSX] Event=ButtonClick Control={0} Param={1} Screen={2}", Control, Param, Context);
                case Constants.PsxEvent.CONNECT_REMOTE:
                    return string.Format("[PSX] Event=ConnectRemote RemoteConnection={0}", RemoteConnection);
                case Constants.PsxEvent.KEY_DOWN:
                    return string.Format("[PSX] Event=KeyDown Param={0} Screen={1}", Param, Context);
                case Constants.PsxEvent.KEY_PRESS:
                    return string.Format("[PSX] Event=KeyPress Param={0} Screen={1}", Param, Context);
                case Constants.LaunchPadEvent.CHANGE_FOCUS:
                    return string.Format("[PSX] Event=ChangeFocus Screen={0}", Context);
                default:
                    return ToString();
            }
        }

        /// <summary>
        /// Checks if the event item given is same type as psx event
        /// </summary>
        /// <param name="eventItemToCompareWith">event item to compare with</param>
        /// <returns>Returns true if event item type is the same, false otherwise</returns>
        public bool IsSimilarEventItemWith(IScriptEventItem eventItemToCompareWith)
        {
            bool isSimilar = false;
            if (eventItemToCompareWith != null &&
                eventItemToCompareWith is IPsxEvent &&
                (eventItemToCompareWith as IPsxEvent).Event.Equals(this.Event))
            {
                isSimilar = true;
            }

            return isSimilar;
        }

        /// <summary>
        /// Creates the psx event
        /// </summary>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEvent CreateEvent();

        /// <summary>
        /// Creates the psx event
        /// </summary>
        /// <param name="time">time of the event</param>
        /// <param name="enabled">whether or not it is enabled</param>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEvent CreateEvent(long time, bool enabled);

        /// <summary>
        /// Creates the psx event item
        /// </summary>
        /// <returns>Returns the script event</returns>
        public abstract IScriptEventItem ToEventItem();
    }
}