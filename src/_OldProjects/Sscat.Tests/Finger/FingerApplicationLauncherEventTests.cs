//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;

namespace Sscat.Tests.Finger
{
	[TestFixture]
	public class FingerApplicationLauncherEventTests
	{
		FingerApplicationLauncherEvent e;

		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new FingerApplicationLauncherEvent("localhost", @"C:\Projects\finger\trunk\tests");
		}
		
		[Test]
		public void TestEmptyConstructor()
		{
			e = new FingerApplicationLauncherEvent();
            e = new FingerApplicationLauncherEvent("localhost", @"C:\Projects\finger\trunk\tests");
		}
		
		[Test]
		public void TestValidate()
		{
			e.Validate();
			Assert.IsFalse(e.HasErrors);
		}
		
		[Test]
		public void TestTypeValue()
		{		
			Assert.AreEqual("ApplicationLauncherEventData", e.Type);
		}

        [Test]
        public void TestLocalHostValue()
        {
            Assert.AreEqual("localhost", e.Host);
        }

        [Test]
        public void TestPathValue()
        {
            Assert.AreEqual(@"C:\Projects\finger\trunk\tests", e.ApplicationPath);
        }

        [Test]
        public void TestSeqIdValue()
        {
            e.SeqId = 1;	
            Assert.AreEqual(1, e.SeqId);
        }

        [Test]
        public void TestGetEventDetailsValue()
        {
            Assert.AreEqual(@"localhost; C:\Projects\finger\trunk\tests", e.GetEventDetails());
        }
		
		[Test]
		public void TestToEventItem()
		{
			Assert.IsInstanceOf(typeof(ApplicationLauncherEvent), e.ToEventItem());
		}
		
		[Test]
		public void TestCreateEvent()
		{
			Assert.IsInstanceOf(typeof(FingerScriptEvent), e.CreateEvent());
		}
		
		[Test]
		public void TestIsSimilarEventItemWith()
		{
			Assert.IsTrue(e.IsSimilarEventItemWith(e));
		}		
	}
}
