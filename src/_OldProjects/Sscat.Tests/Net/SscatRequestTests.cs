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
	public class SscatRequestTests
	{
		[Test]
		public void TestConstructor()
		{
			SscatRequest r = new SscatRequest();
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("GENERATE_SCRIPTS", SscatRequest.GENERATE_SCRIPTS);
			Assert.AreEqual("PLAY_SCRIPT", SscatRequest.PLAY_SCRIPT);
			Assert.AreEqual("GET_CONFIG", SscatRequest.GET_CONFIG);
			Assert.AreEqual("LOAD_CONFIG", SscatRequest.LOAD_CONFIG);
			Assert.AreEqual("CHECK_CONFIG", SscatRequest.CHECK_CONFIG);
			Assert.AreEqual("UPDATE_WLDB", SscatRequest.UPDATE_WLDB);
			Assert.AreEqual("BACKUP_WLDB", SscatRequest.BACKUP_WLDB);
			Assert.AreEqual("STOP_PLAYER", SscatRequest.STOP_PLAYER);
		}
	}
}
