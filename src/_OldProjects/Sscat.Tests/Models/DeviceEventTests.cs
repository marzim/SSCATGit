//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class DeviceEventTests
	{
		DeviceEvent bagScale;
		DeviceEvent scanner;
		DeviceEvent de;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			de = new DeviceEvent();
			
			bagScale = new DeviceEvent("BagScale", "500");
			scanner = new DeviceEvent("Scanner", "F4800011186924~4800011186924~104");
		}

        [Test]
        public void TestBagScaleIDValue()
        {
            Assert.AreEqual("BagScale", bagScale.Id);
        }

        [Test]
        public void TestBagScaleValue()
        {
            Assert.AreEqual("500", bagScale.Value);
        }

        [Test]
        public void TestBagScaleSeqIDValue()
        {
            Assert.AreEqual(0, bagScale.SeqId);
        }

        [Test]
        public void TestBagScaleTypeValue()
        {
            Assert.AreEqual("Device", bagScale.Type);
        }

        [Test]
        public void TestBagScaleIsForgivableValue()
        {
            Assert.AreEqual(false, bagScale.IsForgivable);
        }
		
		[Test]
		public void TestToString()
		{
			Assert.AreEqual("BagScale: 500", bagScale.ToString());
			Assert.AreEqual("Scanner: 4800011186924", scanner.ToString());
		}
		
		[Test]
		public void TestCreateEvent()
		{
			Assert.IsNotNull(bagScale.CreateEvent());
		}
		
		[Test]
		public void TestToEventItem()
		{
			Assert.IsNotNull(bagScale.ToEventItem());
		}
		
		[Test]
		public void TestGetEventDetail()
		{
			Assert.AreEqual("BagScale: 500", bagScale.ToString());
		}
		
		[Test]
		public void TestIsSimilarEventMethodForTwoSimilarEvents()
		{
			Assert.AreEqual(true, bagScale.IsSimilarEventItemWith(bagScale));
		}
		
		[Test]
		public void TestIsSimilarEventMethodForNullValues()
		{
			Assert.AreEqual(false, bagScale.IsSimilarEventItemWith(null));
		}
		
		[Test]
		public void TestIsSimilarEventMethodForTwoNotSimilarEvents()
		{
			Assert.AreEqual(false, bagScale.IsSimilarEventItemWith(scanner));
		}
	}
}
