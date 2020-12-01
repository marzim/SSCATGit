//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;

namespace Sscat.Tests.Finger
{
	[TestFixture]
	public class FingerDeviceEventTests
	{
		FingerDeviceEvent e;
		
		[SetUp]
		public void Setup()
		{
			e = new FingerDeviceEvent("BagScale", "300");
		}
		
		[Test]
		public void TestEmptyValues()
		{
			FingerDeviceEvent x = new FingerDeviceEvent();
			Assert.IsEmpty(x.Id);
			Assert.IsEmpty(x.Value);
		}
		
		[Test]
		public void TestToEventItem()
		{
			IScriptEventItem i = e.ToEventItem();
			Assert.IsInstanceOf(typeof(DeviceEvent), i);
		}
		
		[Test]
		public void TestCreateEvent()
		{
			IScriptEvent i = e.CreateEvent();
			Assert.IsInstanceOf(typeof(FingerScriptEvent), i);
		}
		
		[Test]
		public void TestIdValue()
		{
			Assert.AreEqual("BagScale", e.Id);
			
		}

        [Test]
        public void TestValue()
        {
            Assert.AreEqual("300", e.Value);

        }

        [Test]
        public void TestTypeValue()
        {
            Assert.AreEqual("DeviceEventData", e.Type);

        }

        [Test]
        public void TestSeqIdValue()
        {
            e.SeqId = 0;
            Assert.AreEqual(0, e.SeqId);

        }
	}
}
