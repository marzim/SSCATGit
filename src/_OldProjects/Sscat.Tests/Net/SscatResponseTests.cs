//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Net;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class SscatResponseTests
	{
		[Test]
		public void TestConstructor()
		{
			SscatResponse r = new SscatResponse();
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("SCRIPTS", SscatResponse.SCRIPTS);
			Assert.AreEqual("EVENT_RESULT", SscatResponse.EVENT_RESULT);
			Assert.AreEqual("CONFIGS", SscatResponse.CONFIGS);
			Assert.AreEqual("CONFIG", SscatResponse.CONFIG);
			Assert.AreEqual("MESSAGE", SscatResponse.MESSAGE);
			Assert.AreEqual("ERROR", SscatResponse.ERROR);
			Assert.AreEqual("SCRIPT_RESULT", SscatResponse.SCRIPT_RESULT);
			Assert.AreEqual("PLAYBACK", SscatResponse.PLAYBACK);
			Assert.AreEqual("PLAYER_STOPPED", SscatResponse.PLAYER_STOPPED);
			Assert.AreEqual("CONFIG_LOADED", SscatResponse.CONFIG_LOADED);
			Assert.AreEqual("CONFIG_CHECKED", SscatResponse.CONFIG_CHECKED);
			Assert.AreEqual("STOPPED", SscatResponse.STOPPED);
		}
	}
}
