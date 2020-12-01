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
	public class RunClientTests
	{
		RunClient c;
		
		[SetUp]
		public void Setup()
		{
			ProcessUtility.Attach(new ProcessManagerStub());
//			MessageService.Attach(new ConsoleMessageProvider());
			MessageService.Attach(new NoMessageProvider());
			
			c = new RunClient();
		}
		
		[Test]
		public void TestCanRun()
		{
			Assert.IsTrue(c.CanRun);
		}
		
		[Test]
		public void TestRun()
		{
			c.Run();
		}
		
		[Test]
		public void TestRunOnException()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true, true));
			c.Run();
		}
	}
}
