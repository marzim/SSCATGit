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
	public class CloseActiveWindowTests
	{
		CloseActiveWindow c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			WorkbenchSingleton.Attach(new WorkbenchStub(), new SdiWorkbenchLayout());
			
			c = new CloseActiveWindow();
			c.Running += new EventHandler<NcrEventArgs>(CommandRunning);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			c.Running -= new EventHandler<NcrEventArgs>(CommandRunning);
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

		void CommandRunning(object sender, NcrEventArgs e)
		{
		}
	}
}
