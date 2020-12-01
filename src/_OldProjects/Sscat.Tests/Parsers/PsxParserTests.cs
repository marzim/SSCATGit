//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Config;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Tests.Config;

namespace Sscat.Tests.Parsers
{
	[TestFixture]
	public class PsxParserTests
	{
		IParser parser;
		IExtendedTextReader log;
		
		[SetUp]
		public void Setup()
		{
			log = new ExtendedStringReader(@"PSX_ScotAppU:03/21 09:17:13       502,913 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:Startup, EventName:ChangeContext, Param:, Consumed:0, TimeFired:502913)
PSX_ScotAppU:03/21 09:17:36       526,527 0908> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:OutOfService2, EventName:ChangeContext, Param:, Consumed:0, TimeFired:526527)
PSX_ScotAppU:03/05 20:36:29    99,314,576 01D0> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:ScanAndBag, EventName:ChangeContext, Param:, Consumed:0, TimeFired:99314576)
PSX_ScotAppU:03/05 20:36:30    99,315,287 01D0> EventThreadProc queued events:1 - Handle event(PSXId:1, RemoteConnectionName:, ControlName:Display, ContextName:MultiSelectProduceFavorites, EventName:ChangeContext, Param:, Consumed:0, TimeFired:99315287)");
			
			LaneConfiguration config = new LaneConfigurationRepositoryStub().Read("");
			parser = config.Parsers.GetParser("Psx").Instantiate();
		}
		
		[Test]
		public void TestParse()
		{
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			List<IScriptEvent> events = parser.PerformParse(log);
			Assert.AreEqual(2, events.Count);
			Assert.IsInstanceOf(new FingerPsxEvent().GetType(), (events[0] as FingerScriptEvent).Item);
			Assert.IsInstanceOf(new FingerPsxEvent().GetType(), (events[1] as FingerScriptEvent).Item);
//			FingerPsxEvent e1 = (events[0] as FingerScriptEvent).Item as FingerPsxEvent;
//			Assert.AreEqual("Startup", e1.Context);
//			Assert.AreEqual("Display", e1.Control);
//			Assert.AreEqual("ChangeContext", e1.Event);
//			Assert.AreEqual("", e1.Param);
//			Assert.AreEqual("", e1.RemoteConnection);
//
//			FingerPsxEvent e2 = (events[1] as FingerScriptEvent).Item as FingerPsxEvent;
//			Assert.AreEqual("OutOfService2", e2.Context);
//			Assert.AreEqual("Display", e2.Control);
//			Assert.AreEqual("ChangeContext", e2.Event);
//			Assert.AreEqual("", e2.Param);
//			Assert.AreEqual("", e2.RemoteConnection);
//			
			FingerPsxEvent e1 = (events[0] as FingerScriptEvent).Item as FingerPsxEvent;
			Assert.AreEqual("ScanAndBag", e1.Context);
			Assert.AreEqual("Display", e1.Control);
			Assert.AreEqual("ChangeContext", e1.Event);
			Assert.AreEqual("", e1.Param);
			Assert.AreEqual("", e1.RemoteConnection);
			
			FingerPsxEvent e2 = (events[1] as FingerScriptEvent).Item as FingerPsxEvent;
			Assert.AreEqual("MultiSelectProduceFavorites", e2.Context);
			Assert.AreEqual("Display", e2.Control);
			Assert.AreEqual("ChangeContext", e2.Event);
			Assert.AreEqual("", e2.Param);
			Assert.AreEqual("", e2.RemoteConnection);
		}
	}
}
