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
	public class FingerPsxEventTests
	{
		FingerPsxEvent e;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			e = new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "");
		}
		
		[Test]
		public void TestContextValue()
		{
			Assert.AreEqual("Attract", e.Context);
		}

        [Test]
        public void TestControlValue()
        {
            Assert.AreEqual("Display", e.Control);
        }

        [Test]
        public void TestEventValue()
        {
            Assert.AreEqual("ChangeContext", e.Event);
        }

        [Test]
        public void TestRemoteConnectionValue()
        {
            Assert.IsEmpty(e.RemoteConnection);
        }

        [Test]
        public void TestParamValue()
        {
            Assert.IsEmpty(e.Param);
        }
		
		[Test]
		public void TestCreateEvent()
		{
			IScriptEvent i = e.CreateEvent();
			Assert.IsInstanceOf(typeof(FingerScriptEvent), i);
		}
	}
}
