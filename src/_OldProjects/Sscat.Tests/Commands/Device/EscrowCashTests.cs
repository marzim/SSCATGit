//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands;
using Sscat.Core.Finger;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Tests.Emulators;

namespace Sscat.Tests.Commands.Device
{
	[TestFixture]
	public class EscrowCashTests
	{
		AbstractEventCommand command;
		IScotLogHook hook;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			hook = MockRepository.GenerateMock<IScotLogHook>();
			command = new EscrowCash(new CashAcceptor(), hook, new FingerDeviceEvent(), new SscatLaneStub(), 5000, true);
			command.Running += new EventHandler<NcrEventArgs>(AcceptorRunning);
		}
		
		[TearDown]
		public void TearDown()
		{
			command.Running -= new EventHandler<NcrEventArgs>(AcceptorRunning);
		}
		
		[Test]
		public void TestWithNullCashAcceptor()
		{
			Assert.That(()=>command = new EscrowCash(null, hook, new FingerDeviceEvent(), new SscatLaneStub(), 5000, true), 
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestRunWithException()
		{
			command = new EscrowCash(new A(), hook, new FingerDeviceEvent(), new SscatLaneStub(), 5000, true);
			Assert.That(()=>command.Run(), Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}

		void AcceptorRunning(object sender, NcrEventArgs e)
		{
		}
		
		class A : CashAcceptor, ICashAcceptor
		{
			public override void Escrow(string deviceValue, int timeout)
			{
				throw new NotImplementedException();
			}
		}
	}
}
