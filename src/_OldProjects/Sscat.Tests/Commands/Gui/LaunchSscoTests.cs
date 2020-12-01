//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands.Gui;
using Sscat.Core.Emulators;
using Sscat.Views;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class LaunchSscoTests
	{
		LaunchSsco command;
		
		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			MessageService.Attach(new NoMessageProvider());
			ProcessUtility.Attach(new ProcessManagerStub());
			FileHelper.Attach(new FileManagerStub());
			DirectoryHelper.Attach(new DirectoryManagerStub());
			RegistryHelper.Attach(new RegistryManagerStub());
            ThreadHelper.Attach(new ThreadManagerStub());
            command = new LaunchSsco(new SscatLane(100, true, true), new ConsoleMessageView());
		}

		[Test]
		public void TestEmptyConstructor()
		{
            command = new LaunchSsco();

            command = new LaunchSsco(new SscatLane(100, true, true), new ConsoleMessageView());
		}
		
		[Test]
		public void TestCanRun()
		{
			Assert.IsTrue(command.CanRun);
		}
		
		[Test]
		public void TestRunOnException()
		{
			command = new LaunchSsco(new L(), new ConsoleMessageView());
			command.Run();

            command = new LaunchSsco(new SscatLane(100, true, true), new ConsoleMessageView());
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
		
		[Test]
		public void TestRunOnStarted()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true, false));
			command.Run();
		}
		
		class L : SscatLane
		{
			public override bool HasStarted {
				get { throw new Exception(); }
			}
		}
	}
}
