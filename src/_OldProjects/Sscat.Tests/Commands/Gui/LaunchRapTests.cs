//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands.Gui;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class LaunchRapTests
	{
		LaunchRap command;
		
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub());
			FileHelper.Attach(new FileManagerStub());
			MessageService.Attach(new NoMessageProvider());
			ThreadHelper.Attach(new ThreadManagerStub());
            DirectoryHelper.Attach(new DirectoryManagerStub());
            command = new LaunchRap(new Rap(100));
		}

		[Test]
		public void TestEmptyConstructor()
		{
            command = new LaunchRap();

            command = new LaunchRap(new Rap(100));
		}
		
		[Test]
		public void TestCanRun()
		{
			Assert.IsTrue(command.CanRun);
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
		
		[Test]
		public void TestRunOnException()
		{
			DirectoryHelper.Attach(new DirectoryManager());
            command.Run();

            command = new LaunchRap(new Rap(100));
		}
	}
}
