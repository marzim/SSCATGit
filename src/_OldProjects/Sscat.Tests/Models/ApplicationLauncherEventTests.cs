//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Finger;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class ApplicationLauncherEventTests
	{
		FingerApplicationLauncherEvent finger;
		ApplicationLauncherEvent evnt;

        [OneTimeSetUp]
        public void OneTimeSetUp()
		{
			evnt = ApplicationLauncherEvent.Deserialize(new StringReader(@"<ApplicationLauncherEvent Host='localhost' Path='dummyPath' SeqId='0'>
</ApplicationLauncherEvent>"));
			
			finger = FingerApplicationLauncherEvent.Deserialize(new StringReader(@"<ApplicationLauncherEventData>
</ApplicationLauncherEventData>"));
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("localhost", evnt.Host);
			Assert.AreEqual("dummyPath", evnt.ApplicationPath);
			Assert.AreEqual(0, evnt.SeqId);
			Assert.AreEqual("ApplicationLauncher", evnt.Type);
			Assert.AreEqual("localhost: dummyPath", evnt.ToString());
		}

        [Test]
        public void TestPathValue()
        {
            Assert.AreEqual("dummyPath", evnt.ApplicationPath);
        }

        [Test]
        public void TestSeqIdValue()
        {
            Assert.AreEqual(0, evnt.SeqId);
        }

        [Test]
        public void TestTypeValue()
        {
            Assert.AreEqual("ApplicationLauncher", evnt.Type);
        }

        [Test]
        public void TestEventNameValue()
        {
            Assert.AreEqual("localhost: dummyPath", evnt.ToString());
        }
		
		[Test]
		public void TestToEventItem()
		{
            IScriptEventItem item;
            Assert.That (() => item = evnt.ToEventItem(),
                Throws.TypeOf<NotImplementedException>());
		}
	}
}
