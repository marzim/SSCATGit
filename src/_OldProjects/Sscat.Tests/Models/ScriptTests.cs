//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.IO;

using Ncr.Core;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Repositories;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class ScriptTests
	{
		FingerScript f;
		Script s;
		string filename = @"C:\Projects\finger\trunk\tests\script.xml";
		List<IScriptEvent> events;
		
		[SetUp]
		public void Setup()
		{
            f = FingerScript.Deserialize(new StringReader(@"<FingerScript>
              <fingerBuild>2.2.0</fingerBuild>
              <scriptName>test</scriptName>
              <scriptDescription>test</scriptDescription>
              <flBuild>4.04.00.0.000.391</flBuild>
              <dateTime>8/16/2011 2:21:34 PM</dateTime>
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
              <FingerEventData>
                <enable>true</enable>
                <eventTimeMS>942962949</eventTimeMS>
                <eventType>DeviceEventData</eventType>
                <DeviceEventData>
                  <deviceId>Scale</deviceId>
                  <deviceValue>0</deviceValue>
                  <seqId>2</seqId>
                </DeviceEventData>
              </FingerEventData>
            </FingerScript>"));

            s = Script.Deserialize(new StringReader(@"<Script Name='SecurityMaintenance' 
	            Version='1.0' 
	            Description='' 
	            SscoVersion='4.5' 
	            SscatVersion='3.0'
	            DateTime='7/30/2011 12:57:10 PM'>
	            <Events>
		            <Event Type='Psx' Time='13576201' Enable='true' SeqId='1'>
			            <Psx Id='1' Context='Attract' Event='ChangeContext' Param='' RemoteConnection=''>
				            <Control>Display</Control>
			            </Psx>
		            </Event>
		            <Event Type='Device' SeqId='2'>
			            <Device Id='Scale' Value='0' />
		            </Event>
	            </Events>
            </Script>"));
			
			FileHelper.Attach(new FileManager());
			FileHelper.Create(filename, new Script().Serialize());
			
			events = new List<IScriptEvent>();
			events.Add(new FingerScriptEvent(new FingerPsxEvent()));
			events.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent()));
			events.Add(new FingerScriptEvent(new FingerPsxEvent()));
			events.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("ThankYou", "Display", "ChangeContext", "", "")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			events.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			events.Add(new FingerScriptEvent(new FingerDeviceEvent("MSR", "Default")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("ScanAndBag", "Display", "ChangeContext", "", "")));
			events.Add(new FingerScriptEvent(new FingerDeviceEvent("MSR", "Walmart")));			
			events.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("ThankYou", "Display", "ChangeContext", "", "")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			events.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("FastLaneContext", "RebootSystemButton", "Click", "", "")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("ConfirmationContext", "ConfirmYes", "Click", "", "")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("FastLaneContext", "Display", "ChangeContext", "", "")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("FastLaneContext", "Display", "", "", "")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("FastLaneContext", "TerminalInfoButton", "Click", "", "")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("FastLaneContext", "RunADDButton", "Click", "", "")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("ConfirmationContext", "ConfirmYes", "Click", "", "")));
			events.Add(new FingerScriptEvent(new FingerPsxEvent("FastLaneContext", "Display", "", "", "")));
			
			f.ResultChanged += new EventHandler<ResultEventArgs>(ScriptResultChanged);
		}
		
		[TearDown]
		public void Teardown()
		{
			f.ResultChanged -= new EventHandler<ResultEventArgs>(ScriptResultChanged);
			FileHelper.Delete(filename);
		}
		
		[Test]
		public void TestToString()
		{
			Assert.AreEqual("Sscat.Core.Models.Script", s.ToString());
		}
		
		[Test]
		public void TestDeserializeFromFile()
		{
			Script s = Script.Deserialize(filename);
		}
		
		[Test]
		public void TestDeserializeFromString()
		{
			Assert.AreEqual("test", f.Name);
			Assert.AreEqual(2, f.Events.Events.Length);
			
			Assert.IsNull(s.FileName);
			Assert.AreEqual("SecurityMaintenance", s.Name);
			Assert.AreEqual("", s.Description);
			Assert.AreEqual("4.5", s.SscoVersion);
			Assert.AreEqual("3.0", s.SscatVersion);
			Assert.AreEqual("1.0", s.Version);
			Assert.AreEqual("7/30/2011 12:57:10 PM", s.DateTime);
			Assert.AreEqual(0, s.Index);
			Assert.AreEqual(2, s.Events.Events.Length);
			Assert.IsNull(s.DiagnosticPath);
			Assert.IsNull(s.ScreenshotPath);
			Assert.IsNull(s.Result);
			
			IScriptEvent e = s.Events.Events[0];
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(PsxEvent), e.Item);
			PsxEvent p = e.Item as PsxEvent;
			Assert.AreEqual("1", p.Id);
			Assert.AreEqual("Attract", p.Context);
			Assert.AreEqual("ChangeContext", p.Event);
			Assert.AreEqual("", p.RemoteConnection);
			Assert.AreEqual("Display", p.Control);
			Assert.AreEqual("", p.Param);
			//e = s.Events.Events[1];
			
			//Assert.AreEqual("2", p.Id);
			//Assert.AreEqual("FastLaneContext", p.Context);
			//Assert.AreEqual("Click", p.Event);
			//Assert.AreEqual("", p.RemoteConnection);
			//Assert.AreEqual("RebootSystemButton", p.Control);
			//Assert.AreEqual("", p.Param);
//		
			e = s.Events.Events[1];
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(DeviceEvent), e.Item);
			DeviceEvent d = e.Item as DeviceEvent;
			Assert.AreEqual("Scale", d.Id);
			Assert.AreEqual("0", d.Value);
//			Console.WriteLine(s.Serialize());
		}
		
		[Test]
		public void TestClearResults()
		{
			f.ClearResults();
			Assert.AreEqual(ResultType.None, f.Events.Events[0].Result.Type);
		}
		
		[Test]
		public void TestCreateSegmentation()
		{
			List<IScript> scripts = FingerScript.CreateSegmentedScripts("test", "test", "", "1.0", "2.2", events);
//			List<IScript> scripts = FingerScript.CreateScripts("test", "test", @"C:\Projects\finger\trunk\test", "4.5", "3.1", events, true);
			Assert.AreEqual(5, scripts.Count);
			
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			FingerScript s = scripts[0] as FingerScript;
			Assert.AreEqual(5, s.ScriptEvents.Length);
			Assert.IsInstanceOf(typeof(FingerPsxEvent), s.ScriptEvents[0].Item);
			FingerPsxEvent p = s.ScriptEvents[0].Item as FingerPsxEvent;
			Assert.AreEqual("Attract", p.Context);
			Assert.AreEqual("Display", p.Control);
			Assert.IsInstanceOf(typeof(FingerPsxEvent), s.ScriptEvents[1].Item);
			Assert.IsInstanceOf(typeof(FingerPsxEvent), s.ScriptEvents[2].Item);
			Assert.IsInstanceOf(typeof(FingerDeviceEvent), s.ScriptEvents[3].Item);
			Assert.IsInstanceOf(typeof(FingerPsxEvent), s.ScriptEvents[4].Item);
			
			s = scripts[1] as FingerScript;
			Assert.AreEqual(7, s.ScriptEvents.Length);
			
			s = scripts[2] as FingerScript;
			Assert.AreEqual(6, s.ScriptEvents.Length);
			
			s = scripts[3] as FingerScript;
			Assert.AreEqual(2, s.ScriptEvents.Length);
			
			s = scripts[4] as FingerScript;
			Assert.AreEqual(4, s.ScriptEvents.Length);
		}
		
		[Test]
		public void TestCreateNonSegmentation()
		{
			List<IScript> scripts = FingerScript.CreateScripts("test", "test", @"C:\Projects\finger\trunk\test", "4.5", "3.1", "Default", events, false, false, 0);
			Assert.AreEqual(1, scripts.Count);
		}
		
		[Test]
		public void TestCleanEvents()
		{
			Assert.AreEqual(26, events.Count);
			List<IScriptEvent> events2 = FingerScript.CleanEvents(events);
			Assert.AreEqual(17, events.Count);
		}
		[Test]
		public void TestSortEvents()
		{
			FingerScript script = FingerScript.Deserialize(@"C:\projects\finger\trunk\scripts\test\test_4.xml");
			
			List<IScriptEvent> events2 = new List<IScriptEvent>();
			foreach (ScriptEvent e in script.Events.Events) {
				events2.Add(e as IScriptEvent);
			}
			
			Assert.IsFalse((events2[39].Item as IStimulus).IsStimulus);
			for (int i = 0; i < events2.Count; i++) {
				Console.WriteLine(string.Format("{0} - {1} - {2}", i, events2[i].Time, events2[i].ToString()));
			}
            //39 - 121644325 - TriColorLight: 3~1
            //40 - 121644325 - TriColorLight: 3~1
            //41 - 121644325 - TriColorLight: 3~1
            //42 - 121644325 - TriColorLight: 3~1
            //43 - 121644325 - Context: LaneClosed, Control: Display, Event: ChangeContext, Param: 
            //44 - 121644325 - Context: LaneClosed, Control: CMButton1StoreLogIn, Event: Click, Param: 
            //45 - 121644325 - TriColorLight: 3~1
            //46 - 121644325 - TriColorLight: 3~1
            //47 - 121644325 - TriColorLight: 3~1
            //48 - 121644325 - Context: LaneClosed, Control: Display, Event: ChangeContext, Param: 
            //49 - 121644325 - Context: LaneClosed, Control: CMButton1StoreLogIn, Event: Click, Param: 				
			int startTime = Environment.TickCount;
			events2 = FingerScript.SortEvents(events2);
			Assert.IsTrue((Environment.TickCount - startTime) < 500);
			Console.WriteLine(string.Format("it took {0} ms to execute SortEvents", Environment.TickCount - startTime));
			
			Assert.IsTrue((events2[39].Item as IStimulus).IsStimulus);
			Console.WriteLine("\n\n");
			for (int i = 0; i < events2.Count; i++) {
				Console.WriteLine(string.Format("{0} - {1} - {2}", i, events2[i].Time, events2[i].ToString()));
			}
            //39 - 121644325 - Context: LaneClosed, Control: CMButton1StoreLogIn, Event: Click, Param: 
            //40 - 121644325 - Context: LaneClosed, Control: CMButton1StoreLogIn, Event: Click, Param: 
            //41 - 121644325 - TriColorLight: 3~1
            //42 - 121644325 - TriColorLight: 3~1
            //43 - 121644325 - TriColorLight: 3~1
            //44 - 121644325 - TriColorLight: 3~1
            //45 - 121644325 - Context: LaneClosed, Control: CMButton1StoreLogIn, Event: Click, Param: 
            //46 - 121644325 - TriColorLight: 3~1
            //47 - 121644325 - TriColorLight: 3~1
            //48 - 121644325 - TriColorLight: 3~1
            //49 - 121644325 - Context: LaneClosed, Control: CMButton1StoreLogIn, Event: Click, Param: 			
		}
		
		[Test]
		public void TestFileNameCreator()
		{
			Assert.AreEqual(@"test.xml", AbstractScript<Script>.CreateFileName("test"));
		}

		void ScriptResultChanged(object sender, ResultEventArgs e)
		{
		}
	}
}
