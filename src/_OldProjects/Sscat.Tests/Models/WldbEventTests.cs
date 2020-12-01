//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Finger;
using Sscat.Core.Models;
using Sscat.Core.Util;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class WldbEventTests
	{
		FingerWldbEvent finger;
		WldbEvent evnt;
		
		[SetUp]
		public void Setup()
		{
			evnt = WldbEvent.Deserialize(new StringReader(@"<WldbEvent Host='localhost' SAConfigFile='some.config' WldbFile='some.wldb' Action='backup' SeqId='0'>
</WldbEvent>"));
			
			finger = FingerWldbEvent.Deserialize(new StringReader(@"<WldbEventData>
</WldbEventData>"));
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("localhost", evnt.Host);
			Assert.AreEqual("some.config", evnt.SAConfigFile);
			Assert.AreEqual("some.wldb", evnt.WldbFile);
			Assert.AreEqual("backup", evnt.Action);
			Assert.AreEqual(0, evnt.SeqId);
			Assert.AreEqual("Wldb", evnt.Type);
			Assert.AreEqual("some.wldb: localhost", evnt.ToString());
		}
		
		[Test]
		public void TestToEventItem()
		{
			IScriptEventItem item; 
            Assert.That(() => item = evnt.ToEventItem(),
                Throws.TypeOf<NotImplementedException>());
		}
	}
}
