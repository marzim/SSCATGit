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
	public class CloseAllWindowsTests
	{
		CloseAllWindows c;

        [OneTimeSetUp]
        public void OneTimeSetUp()
		{
			WorkbenchSingleton.Attach(new WorkbenchStub(), new SdiWorkbenchLayout());
			
			c = new CloseAllWindows();
		}
		
		[Test]
		public void TestRun()
		{
			c.Running += delegate(object sender, NcrEventArgs e) { 
				Assert.AreEqual("Closing all windows...", e.Message);
			};
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
