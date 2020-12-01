//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Emulators;
using Ncr.Core.Net;
using NUnit.Framework;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Net;
using Sscat.Tests.Net;
using Sscat.Views;

namespace Sscat.Tests.Views
{
	[TestFixture]
	public class ConsoleServerViewTests
	{
		ConsoleServerView view;
		SscatServerStub server;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			server = new SscatServerStub(new XmlRequestParser(), new SscatLane(), new EasyServerEngine(30000, "SSCAT Server", new XmlRequestParser()));
			view = new ConsoleServerView(server);
		}
		
		[Test]
		public void TestReceiveRequest()
		{
			server.Listen();
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(view.Server);
		}
		
		[Test]
		public void TestPort()
		{
			//Assert.AreEqual(0, view.Port);
            Assert.That(() => view.Port, Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestWriteLine()
		{
			view.WriteLine("test...");
		}
		
		[Test]
		public void TestWrite()
		{
			view.Write("test...");
		}
		
		[Test]
		public void TstClearLogs()
		{
			Assert.That(() => view.ClearLogs(),Throws.TypeOf<NotImplementedException>());
		}
	}
}
