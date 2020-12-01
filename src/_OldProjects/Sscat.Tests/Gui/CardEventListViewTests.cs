//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Gui;
using Sscat.Core.Models;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class CardEventListViewTests
	{
		CardEventListView v;
		FingerScript script;
		List<IScriptEvent> events;
		
		[SetUp]
		public void Setup()
		{
			script = FingerScript.Deserialize(new StringReader(@"<FingerScript>
	            <FileName>C:\sscat\scripts\test.xml</FileName>
	            <scriptName>test</scriptName>
	            <FingerEventData>
	                <enable>true</enable>
	                <eventTimeMS>13377105</eventTimeMS>
	                <eventType>DeviceEventData</eventType>
	                <DeviceEventData>
	                  <IsForgivable>false</IsForgivable>
	                  <deviceId>MSR</deviceId>
	                  <deviceValue>TescoDebitCard</deviceValue>
	                  <seqId>28</seqId>
	                </DeviceEventData>		
	            </FingerEventData>
            </FingerScript>"));
			v = new CardEventListView();
			events = new List<IScriptEvent>();
			foreach (FingerScriptEvent s in script.ScriptEvents) {
				events.Add(new ScriptEvent(s.Item as IScriptEventItem));
			}
			v.ScriptEvents = events;
		}
		
		[Test]
		public void TestScriptEvents()
		{
//			Assert.AreEqual(1, v.ScriptEvents.Length);
			Assert.AreEqual(1, v.ScriptEvents.Count);
		}
		
		[Test]
		public void TestNullScriptEvents()
		{
			v.ScriptEvents = new List<IScriptEvent>();
			Assert.AreEqual(0, v.ScriptEvents.Count);
		}
		
		[Test]
		public void TestSelectedCardEvent()
		{
			v.Items[0].Selected = true;
			Assert.AreEqual(0, v.SelectedItems.Count);
//			Assert.AreEqual("",v.SelectedCardEvent);
		}

		void ViewScriptEventChanged(object sender, ScriptEventEventArgs e)
		{
		}
	}
}
