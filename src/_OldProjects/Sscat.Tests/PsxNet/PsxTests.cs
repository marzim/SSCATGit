//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using Ncr.Core.Models;
using Ncr.Core.Tests.Models;
using NUnit.Framework;
using PsxNet;

namespace Sscat.Tests.PsxNet
{
	[TestFixture]
	public class PsxTests
	{
		PsxCollection connections = new PsxCollection();
		IPsx psx;
		
		[SetUp]
		public void Setup()
		{
//			IApplicationContext context = ApplicationContext.GetContext();
//			connections.Added += delegate(object sender, PsxWrapperEventArgs e) { 
//				Console.WriteLine("Successfully connected to {0}@{1}", e.ConnectionName, e.HostName);
//			};
			connections.Add(new PsxStub("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000));
//			psx = context.GetObject("Psx") as IPsx;
			psx = new PsxStub();
		}
		
		[Test]
		public void TestConnectRemote()
		{
			psx.ConnectRemote("localhost", "FastLaneRemoteServer", "AUTOMATION", 5000);
		}
	}
}
