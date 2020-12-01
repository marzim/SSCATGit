//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="ac185120@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands.Report
{
	[TestFixture]
	public class CheckRunReportsTests
	{
		CheckRunReports command;

        [OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			ImageHelper.Attach(new ImageManagerStub());
			SscatLane lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			command = new CheckRunReports(lane.Hooks["Traces"], new ReportEvent(), lane, 500, true);
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
			Assert.AreEqual(ResultType.Failed, command.Result.Type);
		}
	}
}