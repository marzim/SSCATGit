//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Commands;
using Ncr.Core.Tests.Views;
using Ncr.Core.Views;
using NUnit.Framework;

namespace Ncr.Core.Tests.Commands
{
	[TestFixture]
	public class ExitCommandTests
	{
		ExitCommand c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			WorkbenchSingleton.Attach(new WorkbenchStub(), new SdiWorkbenchLayout());
			
			c = new ExitCommand();
		}
		
		[Test]
		public void TestCanRun()
		{
			Assert.IsTrue(c.CanRun);
			c.Owner = null;
			Assert.IsNull(c.Owner);
		}
		
		[Test]
		public void TestRun()
		{
			c.Run();
		}
		
		[Test]
		public void TestRunOnNullWorkbench()
		{
			WorkbenchSingleton.Attach(null);
            Assert.That(() => c.Run(),
               Throws.TypeOf<ArgumentNullException>());
		}
	}
}
