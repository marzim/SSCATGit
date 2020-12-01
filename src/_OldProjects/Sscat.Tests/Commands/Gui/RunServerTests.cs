//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands.Gui;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class RunServerTests
	{
		RunServer c;
		
		[SetUp]
		public void Setup()
		{
			ProcessUtility.Attach(new ProcessManagerStub());
			FileHelper.Attach(new FileManagerStub());
//			MessageService.Attach(new ConsoleMessageProvider());
			MessageService.Attach(new NoMessageProvider());
			
			c = new RunServer();
		}
		
		[Test]
		public void TestRun()
		{
			c.Run();
		}
		
		[Test]
		public void TestRunOnStarted()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true));
			c.Run();
		}
		
		[Test]
		public void TestRunOnException()
		{
			ProcessUtility.Attach(new ProcessManagerStub(false, true));
			c.Run();
		}
		
		[Test]
		public void TestCanRun()
		{
			Assert.IsTrue(c.CanRun);
		}
	}
}
