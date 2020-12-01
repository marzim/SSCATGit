//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Net;
using NUnit.Framework;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Net;
using Sscat.Tests.Emulators;

namespace Sscat.Tests.Net
{
	[TestFixture]
	public class StopPlayerRequestDispatcherTests
	{
		StopPlayerRequestDispatcher dispatcher;
		SscatServer server;
		
		[SetUp]
		public void Setup()
		{
			SscatLane lane = new SscatLaneStub();
			server = new SscatServerStub(new XmlRequestParser(), lane, new EasyServerEngine(30000, "SSCAT Server", new XmlRequestParser()));
			
			dispatcher = new StopPlayerRequestDispatcher();
			dispatcher.Server = server;
		}
		
		[Test]
		public void TestDispatch()
		{
			dispatcher.Dispatch(new Request());
//			Assert.IsTrue(server.Lane.HasStopped);
		}
	}
}
