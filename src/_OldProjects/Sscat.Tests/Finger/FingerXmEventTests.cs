//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;

namespace Sscat.Tests.Finger
{
	[TestFixture]
	public class FingerXmEventTests
	{
		FingerXmEvent e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new FingerXmEvent("XmCountChanges", 2, new string[] {"1:15,5:3,25:2,100:1;100:6,200:0,500:2,1000:1,2000:0,5000:0,10000:0", "1:110,5:100,10:100,25:100;100:3000,500:1500,1000:750" });
		}
		
		[Test]
        public void TestTypeValue()
		{
			Assert.AreEqual("XmEventData", e.Type);
		}

        [Test]
        public void TestIdValue()
        {
            Assert.AreEqual("XmCountChanges", e.Id);
        }

        [Test]
        public void TestZeroValue()
        {
            Assert.AreEqual("1:15,5:3,25:2,100:1;100:6,200:0,500:2,1000:1,2000:0,5000:0,10000:0", e.Values[0]);			
        }

        [Test]
        public void TestOneValue()
        {
            Assert.AreEqual("1:110,5:100,10:100,25:100;100:3000,500:1500,1000:750", e.Values[1]);
        }

        [Test]
        public void TestSeqIdValue()
        {
            e.SeqId = 0;
            Assert.AreEqual(0, e.SeqId);
        }
		
		[Test]
		public void TestEmptyValues()
		{
			FingerXmEvent x = new FingerXmEvent();
			Assert.IsEmpty(x.Id);
			Assert.IsEmpty(x.Values);
		}
		
		[Test]
		public void TestCreateEvent()
		{
			IScriptEvent i = e.CreateEvent();
			Assert.IsInstanceOf(typeof(FingerScriptEvent), i);
		}
		
		[Test]
		public void TestToEventItem()
		{
			IScriptEventItem i = e.ToEventItem();
			Assert.IsInstanceOf(typeof(XmEvent), i);
		}
	}
}
