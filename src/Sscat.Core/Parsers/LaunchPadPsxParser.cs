//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>z
//	</file>

using System;
using Ncr.Core.Util;
using Sscat.Core.Finger;
using Sscat.Core.Models;

namespace Sscat.Core.Parsers
{
	[Obsolete()]
	public class LaunchPadPsxParser : PsxParser
	{
		public LaunchPadPsxParser()
		{
		}
		
		public LaunchPadPsxParser(IExtendedTextReader reader) : base(reader)
		{
		}
		
		protected override IPsxEvent GetEvent()
		{
			return new FingerLaunchPadPsxEvent();
		}
		
		protected override IScriptEvent AddEvent(IPsxEvent item, int time)
		{
			return item.CreateEvent(time, true);
		}
		
		protected override void Initializing(IExtendedTextReader reader)
		{
			OnParse(new ProgressEventArgs("Parsing LaunchPad PSX log...", 0, reader.Length));
		}
	}
}
