//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Commands.Gui;
using Sscat.Core.Config;
using Sscat.Core.Util;
using Sscat.Tests.Config;
using Sscat.Tests.Util;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class GenerateDiagnosticsTests
	{
		GenerateDiagnostics command;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub());
			FileHelper.Attach(new FileManagerStub());
			DirectoryHelper.Attach(new DirectoryManagerStub());
			MessageService.Attach(new NoMessageProvider());
			WindowAppHelper.Attach(new WindowAppManagerStub());
			ThreadHelper.Attach(new ThreadManagerStub());
			
			command = new GenerateDiagnostics(SscatContext.Lane, new LaneConfigurationRepositoryStub(), new LaunchPadConfigRepositoryStub());
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
		
		[Test]
		public void TestRunOnException()
		{
			MessageService.Attach(new M());
			command.Run();
		}
		
		[Test]
		public void TestCanRun()
		{
			Assert.IsTrue(command.CanRun);
		}
		
		class M : NoMessageProvider
		{
			public override void ShowInfo(string message, string caption)
			{
				throw new Exception();
			}
		}
	}
}
