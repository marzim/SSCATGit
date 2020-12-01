//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class ScriptEventTests
	{
		FingerScriptEvent fingerPsxEvent;
		FingerScriptEvent fingerPsxAttract;
		FingerScriptEvent fingerPsxClick;
		FingerScriptEvent fingerBagScale;
		ScriptEvent psxEvent;
		
		[SetUpAttribute]
		public void Setup()
		{
			fingerPsxEvent = FingerScriptEvent.Deserialize(new StringReader(@"<FingerEventData>
    <enable>true</enable>
    <eventTimeMS>27537847</eventTimeMS>
    <eventType>PsxEventData</eventType>
    <PsxEventData>
      <contextName>Startup</contextName>
      <controlName>Display</controlName>
      <eventName>ChangeContext</eventName>
      <param />
      <psxId>1</psxId>
      <remoteConnectionName>RAP.test.com</remoteConnectionName>
      <seqId>3</seqId>
    </PsxEventData>
  </FingerEventData>"));
			fingerPsxAttract = new FingerScriptEvent(27537847, true, new FingerPsxEvent("Startup", "Display", "ChangeContext", "", ""));
			fingerPsxClick = new FingerScriptEvent(28108988, true, new FingerPsxEvent("Attract", "CMButton1Lg", "Click", "", ""));
			fingerBagScale = new FingerScriptEvent(0, true, new FingerDeviceEvent("BagScale", "400"));
			
			psxEvent = new ScriptEvent(9000, true, new PsxEvent("1", "Startup", "Display", "ChangeContext", "", "", 1));
		}
		
		[Test]
		public void TestResultChange()
		{
			fingerBagScale.ResultChanged += delegate(object sender, ResultEventArgs e) { 
				Assert.AreEqual(e.Result.Type, ResultType.Passed);
			};
			fingerBagScale.Result = new Result(ResultType.Passed, "OK");
		}
		
		[Test]
		public void TestToString()
		{
			Assert.IsNotNull(psxEvent.ToString());
		}
		
		[Test]
		public void TestToEvent()
		{
			Assert.IsNotNull(psxEvent.ToEvent());
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsFalse(fingerBagScale.HasRapConnection);
			
			Assert.IsTrue(fingerPsxEvent.Enabled);
			Assert.IsTrue(fingerPsxEvent.HasRapConnection);
			Assert.AreEqual(27537847, fingerPsxEvent.Time);
			Assert.AreEqual("PsxEventData", fingerPsxEvent.Type);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(new FingerPsxEvent().GetType(), fingerPsxEvent.Item);
			
			IPsxEvent item = fingerPsxEvent.Item as IPsxEvent;
//			Assert.IsFalse(item.Exempted);
			Assert.IsTrue(item.IsExempted);
			Assert.AreEqual("Startup", item.Context);
			Assert.AreEqual("Display", item.Control);
			Assert.AreEqual("ChangeContext", item.Event);
			Assert.AreEqual("", item.Param);
			Assert.AreEqual("RAP.test.com", item.RemoteConnection);
			Assert.IsTrue(item.HasRapConnection);
			Assert.AreEqual("1", item.Id);
			Assert.AreEqual(3, item.SeqId);
			Assert.AreEqual("test.com", item.AbsoluteConnectionName());

			Assert.IsTrue(fingerPsxAttract.Enabled);
			Assert.AreEqual(27537847, fingerPsxAttract.Time);
			Assert.AreEqual("PsxEventData", fingerPsxAttract.Type);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(new FingerPsxEvent().GetType(), fingerPsxAttract.Item);
			item = fingerPsxAttract.Item as FingerPsxEvent;
			Assert.AreEqual("Startup", item.Context);
			Assert.AreEqual("Display", item.Control);
			Assert.AreEqual("ChangeContext", item.Event);
			Assert.AreEqual("", item.Param);
			Assert.AreEqual("", item.RemoteConnection);

			Assert.IsTrue(fingerPsxClick.Enabled);
			Assert.AreEqual(28108988, fingerPsxClick.Time);
			Assert.AreEqual("PsxEventData", fingerPsxClick.Type);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(new FingerPsxEvent().GetType(), fingerPsxClick.Item);
			
			item = fingerPsxClick.Item as FingerPsxEvent;
			Assert.AreEqual("Attract", item.Context);
			Assert.AreEqual("CMButton1Lg", item.Control);
			Assert.AreEqual("Click", item.Event);
			Assert.AreEqual("", item.Param);
			Assert.AreEqual("", item.RemoteConnection);
			Assert.AreEqual("", item.AbsoluteConnectionName());
			
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(FingerScriptEvent), item.CreateEvent());
			Assert.IsInstanceOf(typeof(PsxEvent), item.ToEventItem());
			
			Assert.AreEqual("Context: Attract, Control: CMButton1Lg, Event: Click, Param: ", item.ToString());
			
			item = psxEvent.Item as IPsxEvent;
//			Assert.IsFalse(item.Exempted);
			Assert.IsTrue(item.IsExempted);
		}
	}
}
