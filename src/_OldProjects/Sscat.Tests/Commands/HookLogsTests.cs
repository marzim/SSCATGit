//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Commands;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands
{
	[TestFixture]
	public class HookLogsTests
	{
		HookLogs command;
		
		[SetUp]
		public void Setup()
		{
			LoggingService.DetachAll();
			DirectoryHelper.Attach(new DirectoryManagerStub());
			MessageService.Attach(new NoMessageProvider());
			command = new HookLogs(new string[] { "", "0:Psx" }, new LaneConfigurationRepositoryStub());
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
	}
}
