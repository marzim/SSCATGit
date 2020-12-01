// <copyright file="EventParser.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models.ScriptModel;
    using Sscat.Core.Util;
    using UILogger;

    /// <summary>
    /// Initializes a new instance of the EventParser class
    /// </summary>
    public class EventParser : AbstractParser
    {
        /// <summary>
        /// Interface for parser patterns
        /// </summary>
        private List<IParserPattern> _patterns = new List<IParserPattern>();

        /// <summary>
        /// Interface for parser patterns
        /// </summary>
        private string _filename = string.Empty;

        /// <summary>
        /// Initializes a new instance of the EventParser class
        /// </summary>
        public EventParser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the EventParser class
        /// </summary>
        /// <param name="name">parser name</param>
        /// <param name="filename">file name</param>
        /// <param name="reader">text reader</param>
        /// <param name="patterns">parser pattern</param>
        public EventParser(string name, string filename, IExtendedTextReader reader, params IParserPattern[] patterns)
            : base(name, reader)
        {
            _filename = filename;
            AddPattern(patterns);
        }

        /// <summary>
        /// Initializes a new instance of the EventParser class
        /// </summary>
        /// <param name="name">parser name</param>
        /// <param name="stream">file stream</param>
        public EventParser(string name, FileStream stream)
            : base(name, stream)
        {
        }

        /// <summary>
        /// Gets the parser patterns
        /// </summary>
        public virtual List<IParserPattern> Patterns
        {
            get { return _patterns; }
        }

        /// <summary>
        /// Add patterns
        /// </summary>
        /// <param name="patterns">parser patterns</param>
        public void AddPattern(params IParserPattern[] patterns)
        {
            foreach (IParserPattern pattern in patterns)
            {
                Patterns.Add(pattern);
            }
        }

        /// <summary>
        /// Perform the parse
        /// </summary>
        /// <param name="reader">text reader</param>
        /// <returns>Returns the script event parsed out</returns>
        public override List<IScriptEvent> PerformParse(IExtendedTextReader reader)
        {
            List<IScriptEvent> events = new List<IScriptEvent>();
            string line = string.Empty;
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                if (HasStopped)
                {
                    OnParse(new ProgressEventArgs(string.Format("Stop parsing {0}...", Name)));
                    break;
                }

                foreach (IParserPattern p in Patterns)
                {
                    if (HasStopped)
                    {
                        break;
                    }

                    Match match = p.Match(line);

                    if (match.Success)
                    {
                        p.Add(line, match, reader, events, p.EventValue);
                        break;
                    }

                    if (i % 55347 == 0)
                    {
                        // HACK: SSCAT (55347 in I337 numbers). :)
                        string eventType = Name.Equals("Traces") ? "Device" : Name.Equals("SM") ? "Device Bag Scale" : Name;
                        OnParse(new ProgressEventArgs(string.Format("Parsing {0} for {1} Events", _filename, eventType)));
                     }

                    i++;
                }
            }

            return events;
        }

        /// <summary>
        /// Perform the binary parse
        /// </summary>
        /// <param name="stream">File stream</param>
        /// <returns>Returns the script event parsed out</returns>
        public override List<IScriptEvent> PerformBinaryParse(FileStream stream)
        {
            List<IScriptEvent> events = new List<IScriptEvent>();

            try
            {
                while (stream.Position < stream.Length)
                {
                    UILogEntry logEntry = new UILogEntry();
                    BinaryFormatter fm = new BinaryFormatter();
                    logEntry = (UILogEntry)fm.Deserialize(stream);

                    IUIValidationEvent item = new UIValidationEvent();
                    item.EventType = Constants.UIValidationEvent.PROPERTY_CHANGE;
                    item.ControlName = logEntry.ControlName;
                    item.ControlType = logEntry.ControlType;
                    item.Property = logEntry.PropertyName;
                    item.PropertyValue = logEntry.PropertyValue;

                    //// LoggingService.Info(item.ToString());

                    Match match = Regex.Match(logEntry.LogDate, @"(?<datetime>\d{2}/\d{2} \d{2}:\d{2}:\d{2}) (?<ms>(\d+,)+\d+)", RegexOptions.IgnoreCase);
                    long time = Convert.ToInt64(match.Groups["ms"].Value.Replace(",", string.Empty));
                    System.DateTime dateTime = System.DateTime.ParseExact(match.Groups["datetime"].Value, @"MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                    events.Add(item.CreateEvent(time, dateTime, true));
                }
            }
            catch (Exception ex)
            {
                LoggingService.Error(ex.ToString());
                throw;
            }
            finally
            {
                stream.Close();
            }

            return events;
        }
    }
}
