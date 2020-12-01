//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
using Ncr.Core.Net;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;

namespace Sscat.Tests.Commands.Psx
{
	[TestFixture]
	public class PsxConnectRemoteTests
	{
		PsxConnectRemote command;
		SscatLane lane;
		
		[SetUp]
		public void Setup()
		{
			DnsHelper.Attach(new DnsManagerStub());
			
			lane = new SscatLane();
			IScotLogHook hook = MockRepository.GenerateMock<IScotLogHook>();
			
			IPsxEvent item = new PsxEvent("1", "", "", "ConnectRemote", "HandheldRAP=0;", "RAP.g2lane-ian", 0);
			command = new PsxConnectRemote(hook, item, lane, 5000, true);
		}
		
		[Test]
		public void TestPreRun()
		{
			lane.Configuration = LaneConfiguration.Deserialize(new StringReader(@"<Configuration>
	<Player OverrideRapName='true' RapName='test'/>
</Configuration>"));
			command.PreRun();
		}
		
		[Test]
		public void TestPreRunThatHasRapConnection()
		{
			lane.Configuration = LaneConfiguration.Deserialize(new StringReader(@"<Configuration>
	<Player RapName='test'/>
</Configuration>"));
			command.PreRun();
		}
		
		[Test]
		public void TestHasConnection()
		{
			lane.PsxConnections.Add("RAP.g2lane-ian", MockRepository.GenerateMock<IPsx>());
			command.Run();
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
	}
}
