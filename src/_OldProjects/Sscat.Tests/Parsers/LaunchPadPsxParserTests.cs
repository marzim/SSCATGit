//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Tests.Config;

namespace Sscat.Tests.Parsers
{
	[TestFixture]
	public class LaunchPadPsxParserTests
	{
		//IParser parserEmpty;
		IParser parser;
		IExtendedTextReader log;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			log = new ExtendedStringReader(@"PSX_LaunchPadNet:05/23 17:31:06       734,375 0B20> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:StartupContext, EventName:ChangeContext, Param:, Consumed:0, TimeFired:734375)
            PSX_LaunchPadNet:05/23 17:33:12       860,437 0B20> EventThreadProc queued events:2 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Echo, ContextName:EnterID, EventName:ChangeFocus, Param:, Consumed:0, TimeFired:860437)
            PSX_LaunchPadNet:05/23 17:33:12       860,437 0B20> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:ChangeContext, Param:, Consumed:0, TimeFired:860437)
            PSX_LaunchPadNet:05/23 17:34:22       929,781 0B20> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:KeyDown, Param:91, Consumed:0, TimeFired:929781)
            PSX_LaunchPadNet:05/23 17:35:51     1,018,687 0B20> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:KeyDown, Param:91, Consumed:0, TimeFired:1018687)
            PSX_LaunchPadNet:05/23 17:36:02     1,030,203 0B20> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:EnterID, EventName:Quit, Param:, Consumed:0, TimeFired:1030203)");

			LaneConfiguration config = new LaneConfigurationRepositoryStub().Read("");
			//parserEmpty = config.Parsers.GetParser("Traces").Instantiate();
			parser = config.Parsers.GetParser("LaunchPadPsx").Instantiate(log);
		}

		[Test]
		public void TestParse()
		{
			List<IScriptEvent> events = parser.PerformParse(log);
			Assert.AreEqual(1, events.Count);
		}
	}
}
