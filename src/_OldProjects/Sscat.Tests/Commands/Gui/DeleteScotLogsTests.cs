//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Ncr.Core.Models;
using Ncr.Core.Tests.Models;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core;
using Sscat.Core.Commands.Gui;
using Sscat.Core.Emulators;
using Sscat.Core.Services;
using Sscat.Tests.Config;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class DeleteScotLogsTests
	{
		DeleteScotLogs command;
		SscatLane lane;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManagerStub());
			MessageService.Attach(new NoMessageProvider());
			ProcessUtility.Attach(new ProcessManagerStub(true));
			RegistryHelper.Attach(new RegistryManagerStub());
			ThreadHelper.Attach(new ThreadManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			
			lane = new SscatLane();
			SscatContext.Lane = lane;
			lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
			
			command = new DeleteScotLogs();
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			lane.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
		
		[Test]
		public void TestRunOnNotStarted()
		{
			ProcessUtility.Attach(new ProcessManagerStub(false));
			command.Run();
		}
		
		[Test]
		public void TestCanRun()
		{
			Assert.IsTrue(command.CanRun);
		}
		
		[Test]
		public void TestRunOnError()
		{
			command = new DeleteScotLogs(new L());
			command.Run();
		}
		
		[Test]
		public void TestRunOnDiscontinue()
		{
			MessageService.Attach(new M());
			command.Run();
		}
		
		[Test]
		public void TestRunOnCancel()
		{
			MessageService.Attach(new N());
			command.Run();
		}

		void LaneConnectionAdding(object sender, PsxWrapperEventArgs e)
		{
			lane.PsxConnections.Add(new PsxStub("localhost", "FastLaneRemoteServer", "AUTOMATION", 100));
		}
		
		class M : NoMessageProvider
		{
			public override DialogResult ShowYesNoCancel(string message, string caption)
			{
				return DialogResult.No;
			}
		}
		
		class N : NoMessageProvider
		{
			public override DialogResult ShowYesNoCancel(string message, string caption)
			{
				return DialogResult.Cancel;
			}
		}
		
		class L : SscatLane
		{
			public override bool HasStarted {
				get { throw new Exception(); }
			}
		}
	}
}
