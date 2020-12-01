// <copyright file="AbstractScriptEvent.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the AbstractScriptEvent class
    /// </summary>
    /// <typeparam name="T">Base model</typeparam>
    [Serializable]
    public abstract class AbstractScriptEvent<T> : BaseModel<T>, IScriptEvent
    {
        /// <summary>
        /// Script event item
        /// </summary>
        private object _item;

        /// <summary>
        /// Whether or not script is enabled
        /// </summary>
        private bool _enabled;

        /// <summary>
        /// Sequence ID
        /// </summary>
        private int _sequenceId;

        /// <summary>
        /// Script time
        /// </summary>
        private long _time;

        /// <summary>
        /// Script type
        /// </summary>
        private string _type;

        /// <summary>
        /// Screenshot link
        /// </summary>
        private string _screenshotLink;
        
        /// <summary>
        /// Screenshot link
        /// </summary>
        private DateTime _dateTime;

        /// <summary>
        /// Script event result
        /// </summary>
        private Result _result;

        /// <summary>
        /// The index
        /// </summary>
        private int _index;

        /// <summary>
        /// Script index
        /// </summary>
        private int _scriptIndex;

        /// <summary>
        /// Script file name
        /// </summary>
        private string _scriptFileName;

        /// <summary>
        /// New item value
        /// </summary>
        private string _newItemValue;

        /// <summary>
        /// Initializes a new instance of the AbstractScriptEvent class
        /// </summary>
        public AbstractScriptEvent()
        {
        }

        /// <summary>
        /// Event handler for result changed
        /// </summary>
        public event EventHandler<ResultEventArgs> ResultChanged;

        /// <summary>
        /// Gets or sets the event's sequence id
        /// </summary>
        [XmlIgnore]
        public virtual int SequenceID
        {
            get { return _sequenceId; }
            set { _sequenceId = value; }
        }

        /// <summary>
        /// Gets or sets the item
        /// </summary>
        [XmlIgnore]
        public virtual object Item
        {
            get { return _item; }
            set { _item = value; }
        }
        
        /// <summary>
        /// Gets or sets the DateTime
        /// </summary>
        [XmlIgnore]
        public virtual DateTime DateAndTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        /// <summary>
        /// Gets or sets the script index
        /// </summary>
        [XmlIgnore]
        public virtual int ScriptIndex
        {
            get { return _scriptIndex; }
            set { _scriptIndex = value; }
        }

        /// <summary>
        /// Gets or sets the index
        /// </summary>
        [XmlIgnore]
        public virtual int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        /// <summary>
        /// Gets or sets the screenshot link
        /// </summary>
        [XmlIgnore]
        public virtual string ScreenshotLink
        {
            get { return _screenshotLink; }
            set { _screenshotLink = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the script is enabled
        /// </summary>
        [XmlIgnore]
        public virtual bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        /// <summary>
        /// Gets or sets the script event time
        /// </summary>
        [XmlIgnore]
        public virtual long Time
        {
            get { return _time; }
            set { _time = value; }
        }

        /// <summary>
        /// Gets or sets the script event type
        /// </summary>
        [XmlIgnore]
        public virtual string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        /// <summary>
        /// Gets or sets the script event result
        /// </summary>
        [XmlIgnore]
        public virtual Result Result
        {
            get
            {
                return _result;
            }

            set
            {
                _result = value;
                OnResultChanged(new ResultEventArgs(_result));
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not the event has a RAP connection
        /// </summary>
        public bool HasRapConnection
        {
            get
            {
                if (_item is IPsxEvent)
                {
                    return (_item as IPsxEvent).HasRapConnection;
                }

                return false;
            }
        }

        /// <summary>
        /// Gets or sets the new item value
        /// </summary>
        [XmlIgnore]
        public string NewItemValue
        {
            get { return _newItemValue; }
            set { _newItemValue = value; }
        }

        /// <summary>
        /// Gets or sets the script file name
        /// </summary>
        [XmlIgnore]
        public string ScriptFileName
        {
            get { return _scriptFileName; }
            set { _scriptFileName = value; }
        }

        /// <summary>
        /// Gets the string format for the script event
        /// </summary>
        /// <returns>Returns the formatted string for the event</returns>
        public override string ToString()
        {
            return _item.ToString();
        }

        /// <summary>
        /// Gets the string format for the script event
        /// </summary>
        /// <returns>Returns the formatted string for the event</returns>
        public override string ToRepresentation()
        {
            return (_item as IScriptEventItem).ToRepresentation();
        }

        /// <summary>
        /// Creates the script event
        /// </summary>
        /// <returns>Returns the script event</returns>
        public virtual IScriptEvent ToEvent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Event for on result changed
        /// </summary>
        /// <param name="e">result event arguments</param>
        protected virtual void OnResultChanged(ResultEventArgs e)
        {
            if (ResultChanged != null)
            {
                ResultChanged(this, e);
            }
        }
    }
}
