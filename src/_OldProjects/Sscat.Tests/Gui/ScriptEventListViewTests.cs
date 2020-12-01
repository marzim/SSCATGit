//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Gui;
using Sscat.Core.Models;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ScriptEventListViewTests
	{
		ScriptEventListView v;
		FingerScript script;
		
		[SetUp]
		public void Setup()
		{
			script = script = FingerScript.Deserialize(new StringReader(@"<FingerScript>
	<FileName>C:\sscat\scripts\test.xml</FileName>
	<scriptName>test</scriptName>
	<FingerEventData>
		<enable>true</enable>
		<eventTimeMS>942962708</eventTimeMS>
		<eventType>PsxEventData</eventType>
		<PsxEventData>
			<contextName>Attract</contextName>
			<controlName>Display</controlName>
			<eventName>ChangeContext</eventName>
			<param />
			<psxId>1</psxId>
			<remoteConnectionName />
			<seqId>1</seqId>
		</PsxEventData>
	</FingerEventData>
</FingerScript>"));
			v = new ScriptEventListView();
			v.ScriptEvents = script.ScriptEvents;
		}
		
		[Test]
		public void TestScriptEvents()
		{
			Assert.AreEqual(1, v.ScriptEvents.Length);
		}

		void ViewScriptEventChanged(object sender, ScriptEventEventArgs e)
		{
		}
	}
}
