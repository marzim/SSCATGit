// <copyright file="ScotLogHook.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Log
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using Ncr.Core.Util;
    using Sscat.Core.Emulators;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Parsers;
    using Sscat.Core.Util;

    /// <summary>
    /// Initializes a new instance of the ScotLogHook class
    /// </summary>
    public class ScotLogHook : LogHook, IScotLogHook
    {
        /// <summary>
        /// PSX event
        /// </summary>
        public static readonly string Psx = "Psx";

        /// <summary>
        /// Launch Pad Psx event
        /// </summary>
        public static readonly string LaunchPadPsx = "LaunchPadPsx";

        /// <summary>
        /// Traces event
        /// </summary>
        public static readonly string Traces = "Traces";

        /// <summary>
        /// SM event
        /// </summary>
        public static readonly string SM = "SM";

        /// <summary>
        /// External mode event
        /// </summary>
        public static readonly string Xmode = "Xmode";

        /// <summary>
        /// Takeaway belt event
        /// </summary>
        public static readonly string TAB = "TAB";
        
        /// <summary>
        /// UI Auto Test event
        /// </summary>
        public static readonly string UIAutoTest = "UIAutoTest";

        /// <summary>
        /// UI Validation event
        /// </summary>
        public static readonly string UIValidation = "UIValidation";
        
        /// <summary>
        /// Events locker
        /// </summary>
        private readonly object _eventsLocker = new object();

        /// <summary>
        /// Whether or not event has stopped
        /// </summary>
        private volatile bool _hasStopped = false;

        /// <summary>
        /// Whether or not Error event is triggered
        /// </summary>
        private bool _hasError = false;

        /// <summary>
        /// Whether or not Error event is triggered
        /// </summary>
        private string _errorMessage = string.Empty;

        /// <summary>
        /// Whether or not Error event is triggered
        /// </summary>
        private bool _isLogHookBusy = false;

        /// <summary>
        /// Interface for the parser
        /// </summary>
        private IParser _parser;

        /// <summary>
        /// Script events
        /// </summary>
        private List<IScriptEvent> _events = new List<IScriptEvent>();

        /// <summary>
        /// Warning events
        /// </summary>
        private List<IWarningEvent> _warningevnts = new List<IWarningEvent>();

#if NET40
        /// <summary>
        /// Error events
        /// </summary>
        private List<IErrorEvent> _errorevnts = new List<IErrorEvent>();
#endif

        /// <summary>
        /// Whether or not to force a performance change
        /// </summary>
        private bool _forcePerformChange;

        /// <summary>
        /// Initializes a new instance of the ScotLogHook class
        /// </summary>
        /// <param name="watcher">text watcher</param>
        /// <param name="parser">parser interface</param>
        public ScotLogHook(ITextWatcher watcher, IParser parser)
            : this(watcher, parser, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScotLogHook class
        /// </summary>
        /// <param name="watcher">text watcher</param>
        /// <param name="parser">parser interface</param>
        /// <param name="forcePerformChange">whether or not to force a performance change</param>
        public ScotLogHook(ITextWatcher watcher, IParser parser, bool forcePerformChange)
            : base(watcher)
        {
            _parser = parser;
            _forcePerformChange = forcePerformChange;
        }

        /// <summary>
        /// Initializes a new instance of the ScotLogHook class
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="parser">parser interface</param>
        public ScotLogHook(string filename, IParser parser)
            : this(filename, parser, true, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScotLogHook class
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="parser">parser interface</param>
        /// <param name="forcePerformChange">whether or not to force a performance change</param>
        /// <param name="keepBuffer">whether or not to keep buffer</param>
        public ScotLogHook(string filename, IParser parser, bool forcePerformChange, bool keepBuffer)
            : this(filename, EncodingUtility.GetFileEncoding(filename), parser, forcePerformChange, keepBuffer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ScotLogHook class
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="encoding">the encoding</param>
        /// <param name="parser">parser interface</param>
        /// <param name="forcePerformChange">whether or not to force a performance change</param>
        /// <param name="keepBuffer">whether or not to keep buffer</param>
        public ScotLogHook(string filename, Encoding encoding, IParser parser, bool forcePerformChange, bool keepBuffer)
            : this(new FileWatcher(filename, encoding, filename + ".bak", keepBuffer), parser, forcePerformChange)
        {
        }

        /// <summary>
        /// Event handler for events changed
        /// </summary>
        public event EventHandler<ScotLogHookEventArgs> EventsChanged;

        /// <summary>
        /// Event handler for checking
        /// </summary>
        public event EventHandler<SscatEventArgs> Checking;

        /// <summary>
        /// Event handler for warning found
        /// </summary>
        public event EventHandler<WarningEventArgs> WarningEventFound;

        /// <summary>
        /// Gets the script events
        /// </summary>
        public List<IScriptEvent> Events
        {
            get { return _events; }
        }

        /// <summary>
        /// Gets the warning events
        /// </summary>
        public List<IWarningEvent> WarningEvents
        {
            get { return _warningevnts; }
        }

        /// <summary>
        /// Stops the hook
        /// </summary>
        public void Stop()
        {
            _hasStopped = true;
        }

        /// <summary>
        /// Checks the script event
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns the result</returns>
        public virtual Result Check(IScriptEvent scriptEvent, int timeout)
        {
            if (scriptEvent == null)
            {
                return null;
            }

            string notfound = string.Format("Event Details = Event{0}:{1}; ErrorMessage = SSCAT Verification is done. SSCAT did not find the event activity logged in {2}", scriptEvent.SequenceID, scriptEvent.ToRepresentation(), _parser.Name);
            try
            {
                IScriptEvent lastSimilarEvent = null;
                if (Exists(scriptEvent, out lastSimilarEvent, timeout))
                {
                    return new Result(ResultType.Passed, string.Format("EventDetails = Event{0}:{1}", scriptEvent.SequenceID, scriptEvent.ToRepresentation()));
                }
                else if ((scriptEvent.Item as IScriptEventItem).IsForgivable && (lastSimilarEvent != null))
                {
                    IWarningEvent evnt = new WarningEvent(Constants.WarningEvent.LOG_MISMATCH, string.Format("Expected: {0}; Actual: {1}", scriptEvent.Item.ToString(), lastSimilarEvent.Item.ToString()));
                    _warningevnts.Add(evnt);
                    OnWarningFound(new WarningEventArgs(evnt));
                    return new Result(ResultType.Warning, scriptEvent.Item.ToString(), lastSimilarEvent.Item.ToString(), "Log mismatch");
                }
                else if ((scriptEvent.Item as IScriptEventItem).IsForgivable)
                {
                    IWarningEvent evnt = new WarningEvent(Constants.WarningEvent.LOG_NOT_FOUND, string.Format("Expected: {0}", scriptEvent.Item.ToString()));
                    _warningevnts.Add(evnt);
                    OnWarningFound(new WarningEventArgs(evnt));
                    return new Result(ResultType.Warning, scriptEvent.Item.ToString(), notfound, notfound);
                }
                else if ((scriptEvent.Item as IScriptEventItem).IsExempted)
                {
                    return new Result(ResultType.Skipped, "Skipped");
                }
            }
            catch (ReceiptItemException e)
            {
                IWarningEvent evnt = new WarningEvent(Constants.WarningEvent.RECEIPT_ITEM_EXCEPTION, string.Format("ScriptEvent: {0}, {1}", scriptEvent.Item.ToString(), e.Message));
                _warningevnts.Add(evnt);
                OnWarningFound(new WarningEventArgs(evnt));
                return new Result(ResultType.Warning, scriptEvent.Item.ToString(), "Exception occured", e.Message);
            }
            catch (Exception e)
            {
                LoggingService.Error(e.ToString());
                string s = Regex.Replace(e.Message, @"\t|\n|\r", "; ");
                return new Result(ResultType.Exception, s);
            }

            foreach (IScriptEvent evt in _events)
            {
                LoggingService.Info("ScotLogHook contains: " + evt.ToString());
            }

#if NET40
            if (_errorevnts.Count > 0)
            {
                return new Result(ResultType.Error, _errorMessage);
            }
#endif

            return new Result(ResultType.Failed, notfound);
        }

        /// <summary>
        /// Checks if script exists
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        /// <param name="lastSimilarEvent">last similar event</param>
        /// <param name="timeout">timeout amount</param>
        /// <returns>Returns true if exists, false otherwise</returns>
        public virtual bool Exists(IScriptEvent scriptEvent, out IScriptEvent lastSimilarEvent, int timeout)
        {
            int now = Environment.TickCount;
            bool found = false;
            lastSimilarEvent = null;
            int ctr = 0;
            while ((Environment.TickCount - now) < timeout && !found)
            {
                if (_hasStopped)
                {
                    break;
                }

                try
                {
                    Monitor.Enter(_eventsLocker);
                    int i = 0;
                    while (i < _events.Count && !found)
                    {
                        if (_hasStopped)
                        {
                            break;
                        }
                        
                        IScriptEvent e = _events[i];
                        if (scriptEvent.Item.ToString().Contains("ReceiptItem") && e.Item.ToString().Contains("ReceiptItem"))
                        {
                            found = CompareReceiptItem(scriptEvent.Item.ToString(), e.Item.ToString());
                        }
                        else
                        {
                            found = e.Item.ToString().Equals(scriptEvent.Item.ToString());
                        }

                        if (found)
                        {
                            break;
                        }

                        i++;

                        try
                        {
                            if ((scriptEvent.Item as IScriptEventItem).IsSimilarEventItemWith(e.Item as IScriptEventItem))
                            {
                                lastSimilarEvent = e;
                            }
                        }
                        catch (Exception ex)
                        {
                            LoggingService.Error(ex.Message + ex.StackTrace);
                        }
                    }

                    if (found)
                    {
                        LoggingService.Info(string.Format("[{0}]: LogHookData: Removing Event: {1}", _parser.Name, _events[i].ToEvent()));
                        _events.RemoveAt(i);
                    }
                }
                finally
                {
                    Monitor.Exit(_eventsLocker);
                }

                if (!found && _forcePerformChange)
                {
                    string parserName = _parser.Name.Trim() == "UIAutoTest" ? "SSCOUI" : _parser.Name;
                    OnChecking(new SscatEventArgs(string.Format("Verifying validity of event in {0} Log...", parserName)));
#if NET40                    
                    FindLostScannerEventPair();
#endif
                    ThreadHelper.Sleep(200);
                    while (_isLogHookBusy)
                    {
                        LoggingService.Info(string.Format("[{0}]: LogHookData: ScotLogHook OnChanged. LogHook is Busy. Queueing OnChanged", _parser.Name));
                        ThreadHelper.Sleep(200);
                    }

                    PerformChanged();
                    ctr++;
                }

                if (!found && scriptEvent.Item.ToString().Contains("OnAutomatedLogin: 1") && ctr > 3)
                {
                    LoggingService.Info("ByPassing Automated Login");
                    found = true;
                }
            }
            
            return found;
        }

        /// <summary>
        /// Clears Warning Events
        /// </summary>
        public virtual void ClearWarningEvents()
        {
            _warningevnts.Clear();
        }

#if NET40
        /// <summary>
        /// Clears Warning Events
        /// </summary>
        public virtual void ClearErrorEvents()
        {
            _errorevnts.Clear();
        }
#endif

        /// <summary>
        /// Event for On Events Changed
        /// </summary>
        /// <param name="e">scot log hook event arguments</param>
        public virtual void OnEventsChanged(ScotLogHookEventArgs e)
        {
            if (EventsChanged != null)
            {
                EventsChanged(this, e);
            }
        }

        /// <summary>
        /// Event for On Warning Event Found
        /// </summary>
        /// <param name="e">scot log hook event arguments</param>
        public virtual void OnWarningFound(WarningEventArgs e)
        {
            if (WarningEventFound != null)
            {
                WarningEventFound(this, e);
            }
        }

        /// <summary>
        /// Compares the receipt items
        /// </summary>
        /// <param name="scriptEvent">script event</param>
        /// <param name="e">event arguments</param>
        /// <returns>Returns true if found, false otherwise</returns>
        public bool CompareReceiptItem(string scriptEvent, string e)
        {
            try
            {
                string eventPrice = scriptEvent.Substring(scriptEvent.LastIndexOf('\t') + 1);
                string price = e.Substring(e.LastIndexOf('\t') + 1);

                if (eventPrice.Contains("."))
                {
                    price = price.Replace(",", ".");
                }
                else if (eventPrice.Contains(","))
                {
                    price = price.Replace(".", ",");
                }

                decimal eventCurrency;
                string evntReceiptItem = string.Empty;
                if (decimal.TryParse(eventPrice, out eventCurrency))
                {
                    evntReceiptItem = eventPrice.Replace(eventPrice, string.Format("{0:C}", eventCurrency));
                }

                decimal currency;
                string receiptItem = string.Empty;
                if (decimal.TryParse(price, out currency))
                {
                    receiptItem = price.Replace(price, string.Format("{0:C}", currency));
                }

                bool found = false;
                return found = evntReceiptItem.Equals(receiptItem);
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                throw new ReceiptItemException(ex.Message);
            }
        }

        /// <summary>
        /// Event for on checking
        /// </summary>
        /// <param name="e">sscat event arguments</param>
        protected virtual void OnChecking(SscatEventArgs e)
        {
            if (Checking != null)
            {
                Checking(this, e);
            }
        }

        /// <summary>
        /// Event for on changed
        /// </summary>
        /// <param name="e">log hook event arguments</param>
        protected override void OnChanged(LogHookEventArgs e)
        {
            _isLogHookBusy = true;

            base.OnChanged(e);
            List<IScriptEvent> evnts = _parser.PerformParse(new ExtendedStringReader(e.Changes));

            try
            {
                Monitor.Enter(_eventsLocker);
                if (evnts.Count > 0)
                {
                    _events.AddRange(evnts);
                    ClearChanges();
                    OnEventsChanged(new ScotLogHookEventArgs(evnts));
                }
            }
            catch (Exception ex)
            {
                MessageService.ShowError(ex.Message);
            }
            finally
            {
                Monitor.Exit(_eventsLocker);
            }

            LogEventsAdded(evnts);

            _isLogHookBusy = false;
        }

        /// <summary>
        /// Logs event added to log hook
        /// </summary>
        /// <param name="evnts">list of events</param>
        private void LogEventsAdded(List<IScriptEvent> evnts)
        {
            foreach (IScriptEvent evnt in evnts)
            {
                LoggingService.Info(string.Format("[{0}]: LogHookData: Adding Event: {1}", _parser.Name, evnt.ToEvent()));
#if NET40
                if (evnt.Item is IWarningEvent)
                {
                    _warningevnts.Add(evnt.Item as IWarningEvent);
                    OnWarningFound(new WarningEventArgs(evnt.Item as IWarningEvent));
                }

                if (evnt.Item is IErrorEvent)
                {
                    _errorevnts.Add(evnt.Item as IErrorEvent);
                    _errorMessage = (evnt.Item as IErrorEvent).ErrorNotes;
                    _warningevnts.Add(new WarningEvent("Error", _errorMessage));
                }
#endif
            }
        }

#if NET40
        /// <summary>
        /// Find Lost Scanner Event Pair
        /// </summary>
        private void FindLostScannerEventPair()
        {
            try
            {
                Monitor.Enter(_eventsLocker);
                if (_events.Exists(x => x.Item is IDeviceEvent && (x.Item as IDeviceEvent).Id == Constants.DeviceType.SCANNER_PART1) &&
                    _events.Exists(x => x.Item is IDeviceEvent && (x.Item as IDeviceEvent).Id == Constants.DeviceType.SCANNER_PART2))
                {
                    LoggingService.Info("ScotLogHook: ScannerPart1 & ScannerPart2 Found!");

                    IScriptEvent evt = _events.Find(x => x.Item is IDeviceEvent && (x.Item as IDeviceEvent).Id == Constants.DeviceType.SCANNER_PART1);
                    IScriptEvent evt2 = _events.Find(x => x.Item is IDeviceEvent && (x.Item as IDeviceEvent).Id == Constants.DeviceType.SCANNER_PART2);

                    (evt.Item as IDeviceEvent).Id = Constants.DeviceType.SCANNER;
                    (evt.Item as IDeviceEvent).Value = string.Format("{0}~{1}", (evt.Item as IDeviceEvent).Value, (evt2.Item as IDeviceEvent).Value);
                    _events.Add(evt);

                    LoggingService.Info(string.Format("Adding {0}", evt.ToString()));
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
            }
            finally
            {
                Monitor.Exit(_eventsLocker);
            }
        }
#endif
    }
}
