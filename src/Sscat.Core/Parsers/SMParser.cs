//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ncr.Core.Util;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Util;

namespace Sscat.Core.Parsers
{
	[Obsolete()]
	public class SMParser : AbstractParser
	{
		public SMParser()
		{
		}
		
		public SMParser(IExtendedTextReader reader) : base(reader)
		{
		}
		
		public override List<IScriptEvent> PerformParse(IExtendedTextReader reader)
		{
			List<IScriptEvent> events = new List<IScriptEvent>();
			string line = "";
			string pat = @"(?<=.*m_wLastWeight:[ ]+).*";
			OnParse(new ProgressEventArgs("Parsing SM log...", 0, reader.Length));
			while ((line = reader.ReadLine()) != null) {
				if (line.StartsWith("SM:")) {
					OnParsing(new ProgressEventArgs("Parsing SM log...", reader.Position));
					string[] lines = line.Split(new char[] { ' ' }, 4)[3].Trim().Split(new char[] { ' ' }, 3);
					FingerScriptEvent evnt = new FingerScriptEvent(Convert.ToInt32(lines[0].Replace(",", "").Trim()), true);
					if (lines.Length == 3) {
						string keyValue = lines[2].Trim();
						if (keyValue.StartsWith("lCurrentTotalWeight=")) {
							int weight = Convert.ToInt32(keyValue.Split('=')[1].Trim());
							weight = weight < 0 ? 0 : weight;
//							evnt.Item = new FingerDeviceEvent("BagScale", weight.ToString());
							evnt.Item = new FingerDeviceEvent(Constants.DeviceType.BagScale, weight.ToString());
							events.Add(evnt);
						} else if (keyValue.StartsWith("Sending message:  Zero Wt")) {
							evnt.Item = new FingerDeviceEvent("BagScale", 0.ToString());
							events.Add(evnt);
						} else if (keyValue.StartsWith("m_wLastWeight:")) {
							Match m = Regex.Match(line, pat);
							if (m.Success) {
								int weight = Convert.ToInt32(m.Value.Trim());
								if (weight > -1000) {
									weight = weight < 0 ? 0 : weight;
//									evnt.Item = new FingerDeviceEvent("BagScale", weight.ToString());
									evnt.Item = new FingerDeviceEvent(Constants.DeviceType.BagScale, weight.ToString());
									events.Add(evnt);
								}
							}
						}
					}
				}
			}
			OnParsed(new ProgressEventArgs("Done", reader.Length));
			return events;
		}
	}
}
