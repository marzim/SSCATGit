//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands.Gui;
using Sscat.Views;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class ShowHelpTests
	{
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApplicationUtility.Attach(new ApplicationManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub());
		}
		
		[Test]
		public void TestRunConsoleHelp()
		{
			ShowHelp c = new ShowHelp(new V());
			c.Run();
		}
		
		[Test]
		public void TestRunChmHelp()
		{
			ShowHelp c = new ShowHelp();
			c.Run();
		}
		
		class V : IHelp
		{
			public void Show()
			{
			}
		}
	}
}
