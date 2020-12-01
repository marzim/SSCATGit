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
	public class ShowSscoVersionTests
	{
		ShowSscoVersion c;
		
		[SetUp]
		public void Setup()
		{
			ApplicationUtility.Attach(new ApplicationManagerStub());
			MessageService.Attach(new NoMessageProvider());
			RegistryHelper.Attach(new RegistryManagerStub());
			c = new ShowSscoVersion();
		}
		
		[Test]
		public void TestRun()
		{
			c.Run();
		}
		
		[Test]
		public void TestRunOnInvalidRegistry()
		{
			MessageService.Attach(new M());
			c.Run();
		}
		
		class M : NoMessageProvider
		{
			public override void ShowInfo(string message, string caption)
			{
				throw new Exception();
			}
		}
	}
}
