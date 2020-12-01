// <copyright file="AbstractScript.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models.ScriptModel
{
    using System;
    using System.Collections.Generic;
    using System.IO;
#if NET40
    using System.Linq;
#endif
    using System.Xml.Serialization;
    using Ncr.Core.Models;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the AbstractScript class
    /// </summary>
    /// <typeparam name="T">Base model</typeparam>
    [Serializable]
    public abstract class AbstractScript<T> : BaseModel<T>, IScript
    {
        /// <summary>
        /// Script events
        /// </summary>
        private ScriptEvents _events;

        /// <summary>
        /// Script result
        /// </summary>
        private Result _result;

        /// <summary>
        /// Script index
        /// </summary>
        private int _index;

        /// <summary>
        /// Script name
        /// </summary>
        private string _name;

        /// <summary>
        /// Script file name
        /// </summary>
        private string _fileName;

        /// <summary>
        /// Script description
        /// </summary>
        private string _description;

        /// <summary>
        /// Script date time
        /// </summary>
        private string _dateTime;

        /// <summary>
        /// Sscat version
        /// </summary>
        private string _sscatVersion;

        /// <summary>
        /// SSCO version
        /// </summary>
        private string _sscoVersion;

        /// <summary>
        /// Script version
        /// </summary>
        private string _version;

        /// <summary>
        /// Event handler for the result changed
        /// </summary>
        public event EventHandler<ResultEventArgs> ResultChanged;

        /// <summary>
        /// Gets or sets the version
        /// </summary>
        [XmlIgnore]
        public virtual string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        /// <summary>
        /// Gets or sets the SSCO version
        /// </summary>
        [XmlIgnore]
        public virtual string SscoVersion
        {
            get { return _sscoVersion; }
            set { _sscoVersion = value; }
        }

        /// <summary>
        /// Gets or sets the SSCAT version
        /// </summary>
        [XmlIgnore]
        public virtual string SscatVersion
        {
            get { return _sscatVersion; }
            set { _sscatVersion = value; }
        }

        /// <summary>
        /// Gets or sets the date time
        /// </summary>
        [XmlIgnore]
        public virtual string DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }

        /// <summary>
        /// Gets or sets the script description
        /// </summary>
        [XmlIgnore]
        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        [XmlIgnore]
        public virtual string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// <summary>
        /// Gets or sets the script name
        /// </summary>
        [XmlIgnore]
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the script index
        /// </summary>
        [XmlIgnore]
        public virtual int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        /// <summary>
        /// Gets or sets the script result
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
        /// Gets a value indicating whether or not the script has device events
        /// </summary>
        [XmlIgnore]
        public bool HasDeviceEvents
        {
            get
            {
                foreach (IScriptEvent e in Events.Events)
                {
                    if (e.Item is IDeviceEvent)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not the script is a round trip
        /// </summary>
        [XmlIgnore]
        public bool IsRoundTrip
        {
            get
            {
#if NET40
                foreach (IScriptEvent e in Events.Events)
                {
                    IUIAutoTestEvent autoTestEvent = e.Item as IUIAutoTestEvent;

                    if (autoTestEvent != null)
                    {
                        if (autoTestEvent.EventType.Equals(Constants.UIAutoTestEvent.END_OF_TRANSACTION))
                        {
                            return true;
                        }
                    }
                }

                return false;
#else
                return true;
#endif
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not the script is using MS cards
        /// </summary>
        [XmlIgnore]
        public bool IsUsingMSCards
        {
            get
            {
                foreach (IScriptEvent e in Events.Events)
                {
                    if (e.Item is IDeviceEvent)
                    {
                        if ((e.Item as IDeviceEvent).Id.Equals(Constants.DeviceType.MSR))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Gets or sets script events
        /// </summary>
        [XmlIgnore]
        public virtual ScriptEvents Events
        {
            get
            {
                if (_events == null)
                {
                    _events = new ScriptEvents();
                }

                return _events;
            }

            set
            {
                _events = value;
            }
        }

        /// <summary>
        /// Creates script name
        /// </summary>
        /// <param name="name">script name</param>
        /// <returns>Returns script name</returns>
        public static string CreateName(string name)
        {
            return string.Format("{0}", name);
        }

        /// <summary>
        /// Creates file name
        /// </summary>
        /// <param name="name">file name</param>
        /// <returns>Returns the file name</returns>
        public static string CreateFileName(string name)
        {
            // Zero and non-negative are considered valid filename suffix. To empty it, set count to negative values.
            return CreateFileName(name, -1);
        }

        /// <summary>
        /// Creates file name
        /// </summary>
        /// <param name="name">file name</param>
        /// <param name="count">script file count</param>
        /// <returns>Returns the file name</returns>
        public static string CreateFileName(string name, int count)
        {
            if (count >= 0)
            {
                return string.Format("{0}_{1}.xml", CreateName(name), count);
            }
            else
            {
                return string.Format("{0}.xml", CreateName(name));
            }
        }

        /// <summary>
        /// Creates a script
        /// </summary>
        /// <param name="name">script name</param>
        /// <param name="description">script description</param>
        /// <param name="path">script path</param>
        /// <param name="sscoBuild">ssco build</param>
        /// <param name="build">the build</param>
        /// <param name="defaultMSCard">default ms card</param>
        /// <param name="events">script events</param>
        /// <param name="segmented">whether or not to segment a script</param>
        /// <param name="generateLast">whether or not to generate last</param>
        /// <param name="lastScriptsNumber">last scripts number</param>
        /// <param name="uiValidation">whether UIValidation events are generated</param>
        /// <param name="storeModeKeyboard">boolean whether store mode keyboard is automated login</param>
        /// <returns>Returns the overall script</returns>
        public static List<IScript> CreateScripts(string name, string description, string path, string sscoBuild, string build, string defaultMSCard, List<IScriptEvent> events, bool segmented, bool generateLast, int lastScriptsNumber, bool uiValidation, bool storeModeKeyboard)
        {
#if NET40
            LoggingService.Info("Initial EventCount: " + events.Count);
            events = events.OrderBy(e => e.Time).ThenByDescending(e => ((IStimulus)e.Item).IsStimulus).ToList();

            //// uncomment after NXTUI-3576 is fixed
            //// events = events.OrderBy(e => e.DateAndTime).ThenBy(e => e.Time).ThenByDescending(e => ((IStimulus)e.Item).IsStimulus).ToList();

            IScriptEvent sEvt = events.Find(x => (x.Item is IDeviceEvent) && (!(x.Item as IDeviceEvent).Id.Equals(Constants.DeviceType.BAG_SCALE)));

            //// uncomment after NXTUI-3576 is fixed
            //// events.RemoveAll(x => x.DateAndTime < sEvt.DateAndTime);
#else
            events.Sort(new ScriptEventComparer());
#endif
            events = SortEvents(events);
            LoggingService.Info("SortEvents EventCount: " + events.Count);
            events = CleanEvents(events);
            LoggingService.Info("CleanEvents EventCount: " + events.Count);
#if NET40
            events = uiValidation ? GroupUIValidation(events) : RemoveUIValidation(events);
            events = CleanAutomateLoginEvents(events);
            LoggingService.Info("CleanAutomateLoginEvents EventCount: " + events.Count);

            if (storeModeKeyboard)
            {
                events = CleanStoreModeKeyboardEvents(events);
                LoggingService.Info("CleanStoreModeKeyboardEvents EventCount: " + events.Count);
            }
#endif
            List<IScript> scripts;
            if (!segmented)
            {
                events.RemoveAt(0);
#if NET40
                if (SSCOHelper.IsNGUI(sscoBuild))
                {
                    events = CleanUIEvents(events);
                    LoggingService.Info("CleanUIEvents EventCount: " + events.Count);
                }
#endif
                string filename = CreateFileName(name);
                scripts = new List<IScript>(new IScript[] { new SSCATScript(name, description, build, sscoBuild, Path.Combine(path, filename), events) });
                EliminateInvalidTransactions(scripts);
            }
            else
            {
                scripts = CreateSegmentedScripts(name, description, path, build, sscoBuild, events);
                EliminateInvalidTransactions(scripts);
                TruncateScriptsIf(scripts, generateLast, lastScriptsNumber);
            }

            ModifyNameAndSequenceId(scripts, path, name);

            foreach (IScript script in scripts)
            {
                script.ReviseAllMSCardsUsedTo(defaultMSCard);
            }

            return scripts;
        }

#if NET40
        /// <summary>
        /// Remove UI Validation Events
        /// </summary>
        /// <param name="events">list of events</param>
        /// <returns>list of events without UIValidation events</returns>
        public static List<IScriptEvent> RemoveUIValidation(List<IScriptEvent> events)
        {
            int i = 0;
            int max = events.Count;
            List<IScriptEvent> returnEvents = new List<IScriptEvent>();

            try
            {
                while (i < max)
                {
                    if (!(events[i].Item is UIValidationEvent))
                    {
                        returnEvents.Add(events[i]);
                    }

                    i++;
                }
            }
            catch (Exception ex)
            {
                LoggingService.Info(ex.ToString());
            }

            return returnEvents;
        }

        /// <summary>
        /// Groups UI Validation Events
        /// </summary>
        /// <param name="events">list of events</param>
        /// <returns>list of grouped events</returns>
        public static List<IScriptEvent> GroupUIValidation(List<IScriptEvent> events)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].Item is UIValidationEvent)
                {
                    List<UIValidationEvent> uiValidationEvents = new List<UIValidationEvent>();
                    IScriptEvent backEvent = events[i];

                    while ((i < events.Count) && (events[i].Item is UIValidationEvent))
                    {
                        uiValidationEvents.Add(events[i].Item as UIValidationEvent);
                        events.Remove(events[i]);
                    }

                    backEvent.Item = new UIValidationEvents(uiValidationEvents);
                    events.Insert(i, backEvent);
                }
            }

            return events;
        }

        /// <summary>
        /// Checks if the event is a username event
        /// </summary>
        /// <param name="uiEvent">UI auto test event</param>
        /// <returns>Returns true if the event corresponds with a username prompt event, false otherwise</returns>
        public static bool IsEnterUsernameEvent(IUIAutoTestEvent uiEvent)
        {
            if (uiEvent.EventType != Constants.UIAutoTestEvent.CONTEXT_CHANGED)
            {
                return false;
            }

            if (uiEvent.ContextName.Equals("EnterId", StringComparison.OrdinalIgnoreCase)
                        || uiEvent.ContextName.Equals("OperatorKeyboard", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Cleans the automated login events to remove any events in between start and end of a login
        /// </summary>
        /// <param name="events">script events</param>
        /// <returns>Returns the modified script events with automated login events cleaned</returns>
        public static List<IScriptEvent> CleanAutomateLoginEvents(List<IScriptEvent> events)
        {
            int i = events.Count - 1;

            // loops bottom to top from event list
            while (i >= 0)
            {
                IScriptEvent e = events[i];
                IDeviceEvent device = e.Item as IDeviceEvent;
                if (device != null && device.Id.ToLower().Equals("onautomatedlogin"))
                {
                    i--;
                    while (i >= 0)
                    {
                        e = events[i];

                        IUIAutoTestEvent ui = e.Item as IUIAutoTestEvent;
                        if (ui != null)
                        {
                            if (ui.EventType.Equals("ContextChanged") && (ui.ContextName.ToLower().Contains("operatorkeyboard") || ui.ContextName.ToLower().Contains("enterid")))
                            {
                                break;
                            }

                            events.RemoveAt(i);
                        }

                        i--;
                    }
                }
                
                i--;
            }

            return events;
        }

        /// <summary>
        /// Cleans all events after the last context change to welcome event
        /// </summary>
        /// <param name="events">script events</param>
        /// <returns>Returns the modified script events</returns>
        public static List<IScriptEvent> CleanUIEvents(List<IScriptEvent> events)
        {
            int i = events.Count - 1;

            // loops bottom to top from event list
            while (i >= 0)
            {
                IScriptEvent e = events[i];
                if (IsWelcomeEvent(e.Item))
                {
                    break;
                }
                else
                {
                    try
                    {
                        LoggingService.Info(string.Format("Removing {0}", e.ToString()));
                        events.RemoveAt(i);
                    }
                    catch (Exception ex)
                    {
                        LoggingService.Info(ex.ToString());
                    }
                }

                i--;
            }

            return events;
        }
#endif
        /// <summary>
        /// Cleans out any unwanted events
        /// </summary>
        /// <param name="events">script events</param>
        /// <returns>Returns the modified script events without the unwanted events</returns>
        public static List<IScriptEvent> CleanEvents(List<IScriptEvent> events)
        {
            int i = 0;
            bool exit = false;

            while ((i < events.Count) && !exit)
            {
                IScriptEvent e = events[i];
#if NET40
                if ((e.Item is IUIAutoTestEvent) &&
                    SSCOHelper.IsLaneStartScreen((e.Item as IUIAutoTestEvent).ContextName))
                {
                    if (SSCOHelper.IsSSCOType("Base") | (e.Item as IUIAutoTestEvent).ContextName.Contains("Attract"))
                    {
                        exit = true;
                        break;
                    }
                }
#endif
                IPsxEvent psx = e.Item as IPsxEvent;
                if ((psx != null) && SSCOHelper.IsLaneStartScreen(psx.Context))
                {
                    exit = true;
                    break;
                }

                events.RemoveAt(i);
            }

            return RemoveUnwantedEvents(events);
        }

        /// <summary>
        /// Sorts the script events based on tim and stimulus status
        /// </summary>
        /// <param name="events">script events</param>
        /// <returns>Returns sorted script events</returns>
        public static List<IScriptEvent> SortEvents(List<IScriptEvent> events)
        {
            int indexToInsert;
            int i = 0;
            try
            {
                while (i < events.Count)
                {
                    IScriptEvent e = events[i];
                    IStimulus item1 = events[i].Item as IStimulus;
                    indexToInsert = i;
                    if ((i + 1) >= events.Count)
                    {
                        break;
                    }

                    while (e.Time.Equals(events[++i].Time) && !item1.IsStimulus)
                    {
                        IStimulus item2 = events[i].Item as IStimulus;

                        if (item2.IsStimulus)
                        {
                            events.Insert(indexToInsert, events[i]);
                            events.RemoveAt(i);
                        }

                        if ((i + 1) >= events.Count)
                        {
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return events;
        }

#if NET40
        /// <summary>
        /// Segments the scripts by welcome events or certain psx events
        /// </summary>
        /// <param name="name">script name</param>
        /// <param name="description">script description</param>
        /// <param name="path">script path</param>
        /// <param name="build">script build</param>
        /// <param name="sscoBuild">ssco build</param>
        /// <param name="events">script events</param>
        /// <returns>Returns the segmented scripts</returns>
        public static List<IScript> CreateSegmentedScripts(string name, string description, string path, string build, string sscoBuild, List<IScriptEvent> events)
        {
            // For NGUI Scripts
            List<IScript> scripts = new List<IScript>();
            int i = 0;
            while (i < events.Count)
            {
                IScriptEvent e = events[i];
                IPsxEvent psx = e.Item as IPsxEvent;

                bool nextWelcomeFound = false;

                if (IsWelcomeEvent(e.Item))
                {
                    List<IScriptEvent> scriptEvents = new List<IScriptEvent>();

                    while (i < events.Count && !nextWelcomeFound)
                    {
                        i++;
                        if (i < events.Count)
                        {
                            e = events[i];
                            scriptEvents.Add(e);
                        }

                        nextWelcomeFound = IsWelcomeEvent(e.Item);
                    }

                    scripts.Add(new SSCATScript(name, description, build, sscoBuild, string.Empty, scriptEvents));
                }
                else if (psx != null && psx.Context.Contains("Attract") && psx.Control.Equals("Display") && psx.Event.Equals("ChangeContext"))
                {
                    List<IScriptEvent> scriptEvents = new List<IScriptEvent>();
                    string contextName = string.Empty;
                    string controlName = string.Empty;
                    string eventName = string.Empty;
                    do
                    {
                        scriptEvents.Add(e);
                        i++;

                        if (i < events.Count)
                        {
                            e = events[i];
                        }

                        if (e.Item is IPsxEvent)
                        {
                            psx = e.Item as IPsxEvent;
                            contextName = psx.Context;
                            controlName = psx.Control;
                            eventName = psx.Event;
                        }
                    }
                    while (i < events.Count && (!contextName.Contains("Attract") || !controlName.Equals("Display") || !eventName.Equals("ChangeContext")));

                    scripts.Add(new SSCATScript(name, description, build, sscoBuild, string.Empty, scriptEvents));
                }
                else
                {
                    i++;
                }
            }

            return scripts;
        }
#else
        /// <summary>
        /// Segments the scripts by certain psx events
        /// </summary>
        /// <param name="name">script name</param>
        /// <param name="description">script description</param>
        /// <param name="path">script path</param>
        /// <param name="build">script build</param>
        /// <param name="sscoBuild">ssco build</param>
        /// <param name="events">script events</param>
        /// <returns>Returns the segmented scripts</returns>
        public static List<IScript> CreateSegmentedScripts(string name, string description, string path, string build, string sscoBuild, List<IScriptEvent> events)
        {
            // For Classic SCO Scripts
            List<IScript> scripts = new List<IScript>();
            int i = 0;
            while (i < events.Count)
            {
                IScriptEvent e = events[i];
                IPsxEvent psx = e.Item as IPsxEvent;

                if (psx != null && psx.Context.Contains("Attract") && psx.Control.Equals("Display") && psx.Event.Equals("ChangeContext"))
                {
                    List<IScriptEvent> scriptEvents = new List<IScriptEvent>();
                    string contextName = string.Empty;
                    string controlName = string.Empty;
                    string eventName = string.Empty;

                    do
                    {
                        scriptEvents.Add(e);
                        i++;
                        if (i < events.Count)
                        {
                            e = events[i];
                        }

                        if (e.Item is IPsxEvent)
                        {
                            psx = e.Item as IPsxEvent;
                            contextName = psx.Context;
                            controlName = psx.Control;
                            eventName = psx.Event;
                        }

                    } 
                    while (i < events.Count && (!contextName.Contains("Attract") || !controlName.Equals("Display") || !eventName.Equals("ChangeContext")));

                    scripts.Add(new SSCATScript(name, description, build, sscoBuild, string.Empty, scriptEvents));
                }
                else
                {
                    i++;
                }
            }

            return scripts;
        }
#endif
        /// <summary>
        /// Revise all MS cards
        /// </summary>
        /// <param name="nameOfMSCardToUse">name of the MS cards to use</param>
        /// <returns>Returns true if successfully revised, false otherwise</returns>
        public bool ReviseAllMSCardsUsedTo(string nameOfMSCardToUse)
        {
            // PRECONDITION 1: An action that uses MS Card should be present in the script
            if (this.IsUsingMSCards == false)
            {
                LoggingService.Info("AbstractScript->ReviseAllMSCardsUsedTo(): " +
                                    "Ending this operation as there were no MS Cards found on the scripts.");
                return true;
            }

            // PROCESS 1: For all MS Cards used, change its value to use the param
            bool isOperationSuccessful = false;

            try
            {
                IScriptEvent[] scriptEvents = (this as SSCATScript).ScriptEvents as IScriptEvent[];

                foreach (IScriptEvent e in scriptEvents)
                {
                    if (e.Item is IDeviceEvent)
                    {
                        IDeviceEvent objDeviceEvent = e.Item as IDeviceEvent;
                        if (objDeviceEvent.Id.Equals(Constants.DeviceType.MSR))
                        {
                            objDeviceEvent.Value = nameOfMSCardToUse;
                        }
                    }
                }

                isOperationSuccessful = true;
                LoggingService.Info(string.Format("AbstractScript->ReviseAllMSCardsUsedTo(): Successfully revised all MS Cards to use new value [{0}].", nameOfMSCardToUse));
            }
            catch (Exception ex)
            {
                LoggingService.Error(string.Format("AbstractScript->ReviseAllMSCardsUsedTo(): Fatal error occurred while trying to revise all MS Card values to [{0}]. ", nameOfMSCardToUse) + ex.StackTrace);
            }

            return isOperationSuccessful;
        }

        /// <summary>
        /// Clear the event results
        /// </summary>
        public void ClearResults()
        {
            Result = new Result();

            foreach (IScriptEvent e in _events.Events)
            {
                e.Result = new Result();
            }
        }

        /// <summary>
        /// Retrieves the base string format
        /// </summary>
        /// <returns>Returns the base string format</returns>
        public override string ToString()
        {
            return base.ToString();
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

        /// <summary>
        /// Check if the event is a welcome event
        /// </summary>
        /// <param name="autoTestEventObject">auto test event object</param>
        /// <returns>Returns true if welcome event, false otherwise</returns>
        private static bool IsWelcomeEvent(object autoTestEventObject)
        {
#if NET40
            IUIAutoTestEvent autoTestEvent = autoTestEventObject as IUIAutoTestEvent;

            if (autoTestEvent != null)
            {
                string eventType = autoTestEvent.EventType;
                string contextName = autoTestEvent.ContextName;

                if (eventType.Equals("ContextChanged") && SSCOHelper.IsLaneStartScreen(contextName))
                {
                    if (SSCOHelper.IsSSCOType("Walmart") && eventType.Equals("ContextChanged") && contextName.Equals("Welcome"))
                    {
                        return false;
                    }

                    return true;
                }
            }
#endif
            return false;
        }

        /// <summary>
        /// Remove unwanted events
        /// </summary>
        /// <param name="events">script events</param>
        /// <returns>Returns the script events with the unwanted ones removed</returns>
        private static List<IScriptEvent> RemoveUnwantedEvents(List<IScriptEvent> events)
        {
            int i = 0;
            while (i < events.Count)
            {
                IScriptEvent e = events[i];
                IPsxEvent psx = e.Item as IPsxEvent;
                IPsxEvent psxTemp = psx;

                if (psx != null && psx.Context.Equals("FastLaneContext") && psx.Control.Equals("RebootSystemButton") && psx.Event.Equals("Click"))
                {
                    int tempCount = 0;
                    int itrack = i + tempCount;
                    while (tempCount < 3)
                    {
                        events.RemoveAt(itrack);
                        tempCount++;
                    }

                    i = itrack;
                    continue;
                }
                else if (psx != null && psx.Context.Equals("FastLaneContext") && psx.Control.Equals("RunADDButton") && psx.Event.Equals("Click"))
                {
                    int tempCount = 0;
                    int itrack = i + tempCount;
                    while (tempCount < 3)
                    {
                        events.RemoveAt(itrack);
                        tempCount++;
                    }

                    i = itrack;
                    continue;
                }
                else if (psx != null && psx.Context.Equals("FastLaneContext") && psx.Control.Equals("TerminalInfoButton") && psx.Event.Equals("Click"))
                {
                    events.RemoveAt(i);
                    continue;
                }

                i++;
            }

            return events;
        }

        /// <summary>
        /// Truncate the scripts
        /// </summary>
        /// <param name="scripts">list of scripts</param>
        /// <param name="generateLast">whether or not to generate last</param>
        /// <param name="lastScriptsNumber">last scripts number</param>
        private static void TruncateScriptsIf(IList<IScript> scripts, bool generateLast, int lastScriptsNumber)
        {
            if (generateLast)
            {
                IList<IScript> dummy = new List<IScript>(scripts);
                for (int i = 0; i < dummy.Count - lastScriptsNumber; i++)
                {
                    scripts.RemoveAt(0);
                }
            }
        }

        /// <summary>
        /// Eliminates the invalid transactions
        /// </summary>
        /// <param name="scripts">the scripts</param>
        private static void EliminateInvalidTransactions(List<IScript> scripts)
        {
            List<IScript> toBeRemoved = new List<IScript>();
            foreach (IScript s in scripts)
            {
                if (!IsKnownValidScript(s.Events.Events))
                {
                    toBeRemoved.Add(s);
                }
            }

            foreach (IScript s in toBeRemoved)
            {
                scripts.Remove(s);
            }
        }

        /// <summary>
        /// Check if script is a known valid script
        /// </summary>
        /// <param name="events">script events</param>
        /// <returns>Returns true if valid, false otherwise</returns>
        private static bool IsKnownValidScript(ScriptEvent[] events)
        {
            bool hasBagScale = false;

            if (events.OfType<ScriptEvent>().ToList().Find(x => (x.Item is IUIAutoTestEvent) && ((x.Item as IUIAutoTestEvent).ContextName.Equals("Disconnected") || (x.Item as IUIAutoTestEvent).ContextName.Equals("Startup"))) != null)
            {
                return false;
            }

            foreach (IScriptEvent e in events)
            {
                if ((e.Item is IDeviceEvent) && ((e.Item as IDeviceEvent).Id.Equals("Scanner") || (e.Item as IDeviceEvent).Id.Equals("Msr")))
                {
                    // if it is a device stimlus event and not scale
                    return true;
                }
                else if ((e.Item is IDeviceEvent) && (e.Item as IDeviceEvent).Id.Equals("BagScale"))
                {
                    hasBagScale = true;
                }
#if NET40
                else if (hasBagScale && (e.Item is IUIAutoTestEvent) && (e.Item as IUIAutoTestEvent).EventType.ToLower().Contains("contextchanged"))
                {
                    return true;
                }
                else if ((e.Item is IUIAutoTestEvent) && (e.Item as IUIAutoTestEvent).EventType.Equals("HwUnav", StringComparison.OrdinalIgnoreCase))
                {
                    // if it has unav hardware events
                    return true;
                }
                else if ((e.Item is IUIAutoTestEvent) && (e.Item as IUIAutoTestEvent).EventType.ToLower().Contains("click"))
                {
                    // if it has click events
                    return true;
                }
                else if (hasBagScale && (e.Item is IPsxEvent) && (e.Item as IPsxEvent).Event.ToLower().Contains("contextchanged"))
                {
                    // if it has psx click events
                    return true;
                }
                else if ((e.Item is IPsxEvent) && (e.Item as IPsxEvent).Event.ToLower().Contains("click"))
                {
                    // if it has psx click events
                    return true;
                }
#endif
            }
#if !NET40
            return hasBagScale;
#endif
            return false;
        }

        /// <summary>
        /// Modifies the name and sequence ID of the scripts
        /// </summary>
        /// <param name="scripts">the scripts</param>
        /// <param name="path">script path</param>
        /// <param name="name">script name</param>
        private static void ModifyNameAndSequenceId(List<IScript> scripts, string path, string name)
        {
            int i = 0;

            foreach (SSCATScript s in scripts)
            {
                int j = 0;
                s.FileName = Path.Combine(path, CreateFileName(name, i++));

                foreach (SSCATScriptEvent e in s.ScriptEvents)
                {
                    (e.Item as ISequential).SeqId = ++j;
                    e.SequenceID = j;
                }
            }
        }

        /// <summary>
        /// Cleans the automated login events to remove any events in between start and end of a login
        /// These events are from StoreModeKeyboard in which no indicator in traces.log can be found that it is a login event
        /// </summary>
        /// <param name="events">script events</param>
        /// <returns>Returns the modified script events with automated login events cleaned</returns>
        private static List<IScriptEvent> CleanStoreModeKeyboardEvents(List<IScriptEvent> events)
        {
            int ctr = events.Count - 1;

            // loops bottom to top from event list
            while (ctr >= 0)
            {
                IScriptEvent storeMode = events[ctr];
                IUIAutoTestEvent uievent = storeMode.Item as IUIAutoTestEvent;
                if (uievent != null)
                {
                    if (uievent.ContextName.Equals("StoreModeKeyboard") && uievent.ButtonName.Equals("EnterButton"))
                    {
                        int backupCtr = ctr;
                        int deletedEvents = 0;
                        bool isInvalidLogin = CheckInvalidPassword(events, ctr);

                        ctr--;
                        while (ctr >= 0)
                        {
                            storeMode = events[ctr];
                            IUIAutoTestEvent strui = storeMode.Item as IUIAutoTestEvent;

                            if (strui != null)
                            {
                                if (strui.EventType.Equals("ContextChanged") && uievent.ContextName.ToLower().Contains("storemodekeyboard"))
                                {
                                    break;
                                }

                                if (!isInvalidLogin)
                                {
                                    events.RemoveAt(ctr);
                                    deletedEvents++;
                                }
                            }

                            ctr--;
                        }

                        if (deletedEvents > 0)
                        {
                            int entButton = backupCtr - deletedEvents;
                            events[entButton].Item = new DeviceEvent(Constants.DeviceType.ON_AUTOMATED_LOGIN, "1"); ////deletedEvents counter was placed to know if any events were deleted so the enterkeyboard event can be overriden
                        }
                    }
                }

                ctr--;
            }

            return events;
        }

        /// <summary>
        /// Checks event after store mode keyboard is invalid 
        /// Store mode keyboard invalid password event has not yet been defined properly that's why have to resort to am_custom message and store button1
        /// </summary>
        /// <param name="events">script events</param>
        /// <param name="ctr">current event index</param>
        /// <returns>returns true if found an invalid password event false otherwise</returns>
        private static bool CheckInvalidPassword(List<IScriptEvent> events, int ctr)
        {
            for (int i = 0; i <= 5; i++)
            {
                ctr++;
                IScriptEvent storeMode = events[ctr];
                IUIAutoTestEvent uiAutotest = storeMode.Item as IUIAutoTestEvent;
                if (uiAutotest != null && (uiAutotest.ContextName.ToLower().Contains("am_custommessage") && uiAutotest.ButtonName.ToLower().Contains("storebutton1")))
                {
                    return true;
                }
            }

            return false;
        }
    }
}