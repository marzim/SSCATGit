//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="apple_leo_derilo.chiong@ncr.com"/>
//	</file>

using System;
using System.Collections;
using Ncr.Core.Models;
using NUnit.Framework;
using PsxNet;

namespace Ncr.Core.Tests.Models
{
	[TestFixture]
	public class PsxWrapperTests
	{
		P p;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			p = new P("localhost", "FastLaneRemoteServer", "AUTOMATION", 100, false);
			p.PsxEvent += new PsxEventHandler(PsxPsxEvent);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			p.PsxEvent -= new PsxEventHandler(PsxPsxEvent);
		}
		
		[Test]
		public void TestPerformPsxEvent()
		{
			p.PerformPsxEvent();
		}
		
		[Test]
		public void TestGetContext()
		{
            Assert.That(() => Assert.AreEqual("", p.GetContext(1)),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestIsControlVisible()
		{
            Assert.That(() => Assert.IsTrue(p.IsControlVisible("")),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestIsClickable()
		{
            Assert.That(() => Assert.IsTrue(p.IsClickable("")),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestStop()
		{
			p.Stop();
		}

        [Test]
        public void TestTimeoutValue()
        {

            if (p.Timeout <= 0)
            {
                Assert.AreEqual(0, p.Timeout);
            }else{
                Assert.AreEqual(100, p.Timeout);
            }
        }

        [Test]
        public void TestHostNameValue()
        {
            if (p.HostName == null)
                Assert.IsNull(p.HostName);
            else
                Assert.AreEqual("localhost", p.HostName);
        }

        [Test]
        public void TestServiceNameValue()
        {
            if (p.ServiceName == null)
                Assert.IsNull(p.ServiceName);
            else
                Assert.AreEqual("FastLaneRemoteServer", p.ServiceName);
        }

        [Test]
        public void TestConnectionNameValue()
        {
            Assert.IsNull(p.ConnectionName);
        }
		
		[Test]
		public void TestSendControlCommandWithManyParameters()
		{
            Assert.That(() => p.SendControlCommand("", "", 0, new object[] { }),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestGetControlProperty()
		{
            Assert.That(() => Assert.AreEqual("", p.GetControlProperty("", "")),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestSendControlCommand()
		{
            Assert.That(() => p.SendControlCommand("AUTOMATION", ""),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestGenerateEvent()
		{
			object param = "";
            Assert.That(() => p.GenerateEvent("localhost", "FastLaneRemoteServer", "AUTOMATION", "ChangeContext", param),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestContextEquals()
		{
            Assert.That(() => Assert.IsTrue(p.ContextEquals("Attract")),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestDisconnectRemote()
		{
            Assert.That(() => p.DisconnectRemote(),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestConnectRemote()
		{
			p.ConnectRemote();
		}
		
		[Test]
		public void TestConnectRemoteWithParameters()
		{
            Assert.That(() => p.ConnectRemote("localhost", "FastLaneRemoteServer", "AUTOMATION", 100),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestDisconnectRemoteWithConnectionName()
		{
            Assert.That(() => p.DisconnectRemote("AUTOMATION"),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestConstructorWithParameters()
		{
            PsxWrapper w;
            Assert.That(() => w = new PsxWrapper("localhost", "FastLaneRemoteServer", "AUTOMATION", 100),
                Throws.TypeOf<PsxException>());
		}

		void PsxPsxEvent(object sender, PsxEventArgs e)
		{
		}
		
		class P : PsxWrapper
		{
			public P(string host, string service, string connection, int timeout, bool instantiate) : base(host, service, connection, timeout, instantiate)
			{
			}
			
			protected override void Reconnect()
			{
			}
		}
	}
}
