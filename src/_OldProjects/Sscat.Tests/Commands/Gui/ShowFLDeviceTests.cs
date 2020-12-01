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
	public class ShowFLDeviceTests
	{
		ShowFLDevice c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub());
			FileHelper.Attach(new FileManagerStub());
			
			c = new ShowFLDevice();
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
	}
}
