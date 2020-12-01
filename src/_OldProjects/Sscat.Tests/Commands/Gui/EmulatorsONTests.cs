//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="ac185120@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Microsoft.Win32;
using Ncr.Core.Models;
using Ncr.Core.Tests.Models;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Commands.Gui;
using Sscat.Core.Emulators;
using Sscat.Tests.Emulators;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class EmulatorsONTests
	{
		EmulatorsON command;
		SscatLane lane;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			MessageService.Attach(new NoMessageProvider());
			
			lane = new SscatLane();
			SscatContext.Lane = lane;
			lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
			
			command = new EmulatorsON();
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			lane.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
		}
		
		[Test]
		public void TestCanRun()
		{
			FileHelper.Attach(new H());
			Assert.IsTrue(command.CanRun);
		}
		
		[Test]
		public void TestCanRunCADD()
		{
			FileHelper.Attach(new F());
			command = new EmulatorsON(new G());
			Assert.IsFalse(command.CanRun);
		}
		
		[Test]
		public void TestRunOnYesReLaunch()
		{
			MessageService.Attach(new Y());
			command.Run();
		}
		
		[Test]
		public void TestRunOnNoReLaunch()
		{
			MessageService.Attach(new N());
			command.Run();
		}
		
		[Test]
		public void TestRunOnCancel()
		{
			MessageService.Attach(new C());
			command.Run();
		}
		
		[Test]
		public void TestRunOnNotStarted()
		{
			ProcessUtility.Attach(new ProcessManagerStub(false));
			command.Run();
		}
		
		[Test]
		public void TestRunOnException()
		{
//			lane = new E();
			MessageService.Attach(new E());
			command.Run();
		}
		
		void LaneConnectionAdding(object sender, PsxWrapperEventArgs e)
		{
			lane.PsxConnections.Add(new PsxStub("localhost", "FastLaneRemoteServer", "AUTOMATION", 100));
		}
		
		class Y : ConsoleMessageProvider
		{
			public override DialogResult ShowYesNoCancel(string message, string caption)
			{
				return DialogResult.Yes;
			}
		}
		
		class N : ConsoleMessageProvider
		{
			public override DialogResult ShowYesNoCancel(string message, string caption)
			{
				return DialogResult.No;
			}
		}
		
		class C : ConsoleMessageProvider
		{
			public override DialogResult ShowYesNoCancel(string message, string caption)
			{
				return DialogResult.Cancel;
			}
		}
		
//		class E : SscatLane
//		{
//			public override bool HasStarted {
//				get { throw new Exception(); }
//			}
//		}
//		
		class E : ConsoleMessageProvider
		{
			public override DialogResult ShowYesNoCancel(string message, string caption)
			{
				throw new Exception();
			}
		}
		
		class F : FileManager
		{
			public override bool Exists(string path)
			{
				return true;
			}
		}
		
		class H : FileManager
		{
			public override bool Exists(string path)
			{
				return false;
			}
		}
		
		class G : SscatLane
		{
			public override bool IsCADD {
				get { return true; }
			}
		}
	}
}
