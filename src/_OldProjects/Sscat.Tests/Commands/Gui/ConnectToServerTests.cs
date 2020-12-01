//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core;
using Ncr.Core.Tests.Util;
using Ncr.Core.Tests.Views;
using Ncr.Core.Util;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Commands;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class ConnectToServerTests
	{
		ConnectToServer c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			MessageService.Attach(new NoMessageProvider());
			DnsHelper.Attach(new DnsManager());
			WorkbenchSingleton.Attach(new ConsoleWorkbench(), new ConsoleWorkbenchLayout());
			
			c = new ConnectToServer();
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

		void CommandRunning(object sender, NcrEventArgs e)
		{
		}
	}
}
