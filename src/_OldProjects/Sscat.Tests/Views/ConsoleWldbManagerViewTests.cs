//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Views;

namespace Sscat.Tests.Views
{
	[TestFixture]
	public class ConsoleWldbManagerViewTests
	{
		ConsoleWldbManagerView v;
		ConsoleWldbManagerView ve;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			v = new ConsoleWldbManagerView();
			v.ForUpdate = true;
			ve = new ConsoleWldbManagerView(new WldbEvent());
			
			v.Managing += new EventHandler<WldbEventArgs>(ViewManaging);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			v.Managing -= new EventHandler<WldbEventArgs>(ViewManaging);
		}
		
		[Test]
		public void TestWldbValue()
		{
			Assert.IsNotNull(ve.Wldb);
		}

        [Test]
        public void TestForUpdateValue()
        {
            Assert.IsTrue(v.ForUpdate);
        }
		
		[Test]
		public void TestManage()
		{
			v.Manage();
		}

		void ViewManaging(object sender, WldbEventArgs e)
		{
		}
	}
}
