//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Commands;
using Sscat.Gui;
using Sscat.Views;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class CleanLogsAndReportsTests
	{
		CleanLogsAndReports command;
		
		[SetUp]
		public void Setup()
		{
			ApplicationUtility.Attach(new ApplicationManagerStub());
			WorkbenchSingleton.Attach(new ConsoleWorkbench(), new ConsoleWorkbenchLayout());
			
			command = new CleanLogsAndReports(new ConsoleCleanFilesView());
		}
		
		[Test]
		public void TestEmptyConstructor()
		{
			command = new CleanLogsAndReports();
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
	}
}
