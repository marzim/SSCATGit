// <copyright file="ScriptEvents.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the ScriptEvents class
    /// </summary>
    [XmlRoot("Events"), Serializable()]
    public class ScriptEvents
    {
        /// <summary>
        /// Script events
        /// </summary>
        private ScriptEvent[] _events;

        /// <summary>
        /// Initializes a new instance of the ScriptEvents class
        /// </summary>
        public ScriptEvents()
        {
        }

        /// <summary>
        /// Gets or sets the script events
        /// </summary>
        [XmlElement("Event")]
        public ScriptEvent[] Events
        {
            get
            {
                if (_events == null)
                {
                    return new ScriptEvent[0];
                }

                return _events;
            }

            set
            {
                _events = value;
            }
        }

        /// <summary>
        /// Adds script events
        /// </summary>
        /// <param name="events">script events to add</param>
        public void AddEvents(SSCATScriptEvent[] events)
        {
            try
            {
                foreach (IScriptEvent e in events)
                {
                    AddEvent(e.ToEvent());
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(string.Format("Event Type is unknown. Please check for any mispelled event type(s) or make sure to have an event type. Check for any unclosed tags."));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Adds a script event
        /// </summary>
        /// <param name="scriptEvent">script event to add</param>
        public void AddEvent(IScriptEvent scriptEvent)
        {
            List<IScriptEvent> scriptEvents = new List<IScriptEvent>(Events);
            scriptEvents.Add(scriptEvent);
            _events = new ScriptEvent[scriptEvents.Count];
            scriptEvents.CopyTo(_events);
        }
    }
}
