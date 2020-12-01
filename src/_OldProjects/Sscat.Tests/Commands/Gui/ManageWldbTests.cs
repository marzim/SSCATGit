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

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class ManageWldbTests
	{
		ManageWldb c;
		
		[SetUp]
		public void Setup()
		{
			ApplicationUtility.Attach(new ApplicationManagerStub());
			WorkbenchSingleton.Attach(new ConsoleWorkbench(), new ConsoleWorkbenchLayout());
			
			c = new ManageWldb();
		}
		
		[Test]
		public void TestRun()
		{
			c.Run();
		}
	}
}
