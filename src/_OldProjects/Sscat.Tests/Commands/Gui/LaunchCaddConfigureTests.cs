//	<file>
//		<license></license>
//		<owner name="Apple Leo Chiong" email="ac185120@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Models;
using Ncr.Core.Tests.Models;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Commands.Gui;
using Sscat.Core.Emulators;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class LaunchCaddConfigureTests
	{
		LaunchCaddConfigure command;
		SscatLane lane;
		
		[SetUp]
		public void Setup()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "SMAttract"));
			MessageService.Attach(new NoMessageProvider());
			
			lane = new SscatLane();
			SscatContext.Lane = lane;
			lane.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
			
			command = new LaunchCaddConfigure();
		}
		
		[TearDown]
		public void Teardown()
		{
			lane.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(LaneConnectionAdding);
		}
		
		[Test]
		public void TestCanRunADD()
		{
//			Assert.IsTrue(command.CanRun);
			FileHelper.Attach(new E());
			Assert.IsFalse(command.CanRun);
		}
		
		[Test]
		public void TestCanRunCADD()
		{
//			lane = new C();
			FileHelper.Attach(new D());
			command = new LaunchCaddConfigure(new C());
			Assert.IsTrue(command.CanRun);
		}
		
		[Test]
		public void TestRunStarted()
		{
			command.Run();
		}
		
		[Test]
		public void TestRunNotStarted()
		{
			ProcessUtility.Attach(new ProcessManagerStub(false));
			command.Run();
		}
		
		void LaneConnectionAdding(object sender, PsxWrapperEventArgs e)
		{
			lane.PsxConnections.Add(new PsxStub("localhost", "FastLaneRemoteServer", "AUTOMATION", 100));
		}
		
		class C : SscatLane
		{
			public override bool IsCADD {
				get { return true; }
			}
		}
		
		class D : FileManager
		{
			public override bool Exists(string path)
			{
				return true;
			}
		}
		
		class E : FileManager
		{
			public override bool Exists(string path)
			{
				return false;
			}
		}
	}
}
