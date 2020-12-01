//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>z
//	</file>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ncr.Core.Util;
using Sscat.Core.Finger;
using Sscat.Core.Models;

namespace Sscat.Core.Parsers
{
	[Obsolete()]
    public class PosmParser : PsxParser
    {
        public PosmParser()
        {
        }

        public PosmParser(IExtendedTextReader reader) : base(reader)
        {
        }

        public override List<IScriptEvent> PerformParse(IExtendedTextReader reader)
        {
            List<IScriptEvent> events = new List<IScriptEvent>();
            string line = "";
//            POSM: 04/24 22:26:11   109,774,737 1818> StateMachine::CMessageParser::Parse.  Parsing input:  "    SWIPE SHOP. CARD                    ".
//            string linePattern = @"(?<month>\d{2})+/(?<day>\d{2})+ (?<hour>\d{2})+:(?<minute>\d{2})+:(?<second>\d{2})+   (?<ms>\d{3},\d{3},\d{3})+(?<event>.*)";
            string linePattern = @"(?<ms>\d{3},\d{3},\d{3})+(?<event>.*)";
            string msr = @"SWIPE SHOP. CARD";

            OnParse(new ProgressEventArgs("Parsing posm log...", 0, reader.Length));

            while ((line = reader.ReadLine()) != null)
            {
                Match lineMatch = Regex.Match(line, linePattern, RegexOptions.IgnoreCase);
                if (lineMatch.Success)
                {
                    OnParsing(new ProgressEventArgs("Parsing posm log...", reader.Position));

                    FingerScriptEvent evnt = new FingerScriptEvent();
                    FingerDeviceEvent item = new FingerDeviceEvent();
                    evnt.Item = item;
                    evnt.Type = "DeviceEventData";
                    evnt.Enabled = true;
                    
                    evnt.Time = int.Parse(lineMatch.Groups["ms"].Value.Replace(",", "").ToString());
                    string eventName = lineMatch.Groups["event"].Value;

                    Match eventMatch;
                    if ((eventMatch = Regex.Match(eventName, msr, RegexOptions.IgnoreCase)).Success) {
                        item.Id = "MSR";
                        item.Value = "WalmartMCXShoppingCard";
                        events.Add(evnt);
                    }
                }
            }
            OnParsed(new ProgressEventArgs("Done", reader.Length));
            return events;
        }
    }
}