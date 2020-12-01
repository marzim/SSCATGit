//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using Microsoft.Win32;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Commands.Gui;
using Sscat.Core.Emulators;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class ToggleEmulatorsTests
	{
		ToggleEmulators c;
		
		[SetUp]
		public void Setup()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true, false));
			FileHelper.Attach(new FileManagerStub());
			RegistryHelper.Attach(new RegistryManagerStub(true, Registry.LocalMachine));
			MessageService.Attach(new NoMessageProvider());
			SscatContext.Lane = new SscatLane();
			
			c = new ToggleEmulators();
		}
		
		[Test]
		public void TestCanRun()
		{
			Assert.IsTrue(c.CanRun);
		}
		
		[Test]
		public void TestRunWithOwner()
		{
			c.Owner = new ToolStripMenuItem();
			c.Run();
		}
		
		[Test]
		public void TestRunWithOwnerAndKeyNull()
		{
			c.Owner = new ToolStripMenuItem();
			RegistryHelper.Attach(new RegistryManagerStub(true, null));
			c.Run();
		}
		
		[Test]
		public void TestRun()
		{
			c.Run();
		}
		
		[Test]
		public void TestRunWithException()
		{
			SscatContext.Lane = new L();
			c.Run();
		}
		
		class L : SscatLane
		{
			public override bool HasStarted {
				get { throw new Exception(); }
			}
		}
	}
}
