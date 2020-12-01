//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core;
using Sscat.Core.Commands.Gui;
using Sscat.Core.Emulators;

namespace Sscat.Tests.Commands.Gui
{
	[TestFixture]
	public class KillSscoTests
	{
		KillSsco c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub(true));
			RegistryHelper.Attach(new RegistryManagerStub());
			MessageService.Attach(new NoMessageProvider());
			SscatContext.Lane = new SscatLane();
			
			c = new KillSsco();
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
		public void TestRunOnNotStarted()
		{
			ProcessUtility.Attach(new ProcessManagerStub(false));
			c.Run();
		}
		
		[Test]
		public void TestRunOnException()
		{
			c = new KillSsco(new L());
			c.Run();
		}
		
		class L : SscatLane
		{
			public override bool HasStarted {
				get { throw new Exception(); }
			}
		}
	}
}
