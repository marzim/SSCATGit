//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;

namespace Sscat.Tests.Finger
{
	[TestFixture]
	public class FingerWldbEventTests
	{
		FingerWldbEvent e;
		FingerWldbEvent xml;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new FingerWldbEvent("g2lane-ian", "some.mdb", "some.mdb", "scot", "Q+1MwHiTNa4RB04/+wirFg==");
			xml = FingerWldbEvent.Deserialize(new StringReader(@"<WldbEventData/>"));
		}
		
		[Test]
		public void TestCreateEvent()
		{
			IScriptEvent i = e.CreateEvent();
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(FingerScriptEvent), i);
		}
		
		[Test]
		public void TestToEventItem()
		{
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(WldbEvent), e.ToEventItem());
		}
		
		[Test]
		public void TestValidate()
		{
			e.ScriptFileName = "SampleScriptFileName.xml";
			e.Validate();
			
			Assert.IsTrue(e.HasErrors);
		}
		
		[Test]
        public void TestScriptFileNameNormalValue()
		{
			Assert.IsNull(xml.ScriptFileName);
		}

        [Test]
        public void TestHostValue()
        {
            Assert.AreEqual("g2lane-ian", e.Host);
        }

        [Test]
        public void TestTypeValue()
        {
            Assert.AreEqual("WLDBEventData", e.Type);
        }

        [Test]
        public void TestScriptFileNameNullValue()
        {
            e.ScriptFileName = "";
            Assert.IsEmpty(e.ScriptFileName);
        }

        [Test]
        public void TestSeqIdValue()
        {
            e.SeqId = 0;
            Assert.AreEqual(0, e.SeqId);
        }

        [Test]
        public void TestFingerWldbEventTestsValue()
        {
            Assert.AreEqual("some.mdb: g2lane-ian", e.ToString());
        }
	}
}
