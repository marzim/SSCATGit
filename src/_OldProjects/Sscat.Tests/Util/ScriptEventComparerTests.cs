//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Util;

namespace Sscat.Tests.Util
{
	[TestFixture]
	public class ScriptEventComparerTests
	{
		FingerScriptEvent e1;
		FingerScriptEvent e2;
		IComparer<IScriptEvent> comparer;
		
		[SetUp]
		public void Setup()
		{
			comparer = new ScriptEventComparer();
		}
		
		[Test]
		public void TestCompare()
		{
			e1 = FingerScriptEvent.Deserialize(new StringReader(@"<FingerEventData>
    <enable>true</enable>
    <eventTimeMS>171855685</eventTimeMS>
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
  </FingerEventData>"));
			e2 = FingerScriptEvent.Deserialize(new StringReader(@"<FingerEventData>
    <enable>true</enable>
    <eventTimeMS>171855264</eventTimeMS>
    <eventType>PsxEventData</eventType>
    <PsxEventData>
      <contextName>ThankYou</contextName>
      <controlName>Display</controlName>
      <eventName>ChangeContext</eventName>
      <param />
      <psxId>1</psxId>
      <remoteConnectionName />
      <seqId>2</seqId>
    </PsxEventData>
  </FingerEventData>"));
			Assert.AreEqual(1, comparer.Compare(e1, e2));
			
			e1 = e2;
			e2 = FingerScriptEvent.Deserialize(new StringReader(@"<FingerEventData>
    <enable>true</enable>
    <eventTimeMS>171855224</eventTimeMS>
    <eventType>DeviceEventData</eventType>
    <DeviceEventData>
      <deviceId>BagScale</deviceId>
      <deviceValue>0</deviceValue>
      <seqId>3</seqId>
    </DeviceEventData>
  </FingerEventData>"));
			Assert.AreEqual(1, comparer.Compare(e1, e2));
		}
		
		[Test]
		public void TestStimulus()
		{
			FingerScriptEvent evnt1 = new FingerScriptEvent(1, true, new PsxEvent("", "", "", "", "", "", 1));
			FingerScriptEvent evnt2 = new FingerScriptEvent(1, true, new PsxEvent("", "", "", "", "", "", 1));
			Assert.AreEqual(0, comparer.Compare(evnt1, evnt2));
			evnt1 = new FingerScriptEvent(1, true, new PsxEvent("", "", "", "Click", "", "", 1));
			evnt2 = new FingerScriptEvent(1, true, new PsxEvent("", "", "", "", "", "", 1));
			Assert.AreEqual(-1, comparer.Compare(evnt1, evnt2));
			Assert.AreEqual(1, comparer.Compare(evnt2, evnt1));
		}
	}
}
