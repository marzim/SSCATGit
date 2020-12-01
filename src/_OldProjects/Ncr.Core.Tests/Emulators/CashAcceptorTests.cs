//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="apple_leo_derilo.chiong@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class CashAcceptorTests
	{
		CashAcceptor c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			
			c = new CashAcceptor();
		}
		
		[Test]
		public void TestEscrow100()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "100"));
			c.Escrow("100", 5000);
		}
		
		[Test]
		public void TestEscrow200()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "200"));
			c.Escrow("200", 5000);
		}
		
		[Test]
		public void TestEscrow500()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "500"));
			c.Escrow("500", 5000);
		}
		
		[Test]
		public void TestEscrow1000()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "1000"));
			c.Escrow("1000", 5000);
		}
		
		[Test]
		public void TestEscrow5000()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "5000"));
			c.Escrow("5000", 5000);
		}
		
		[Test]
		public void TestEscrow10000()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "10000"));
			c.Escrow("10000", 5000);
		}
		
		[Test]
		public void TestEscrowExpectException()
		{
//			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "100"));
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, new IntPtr(666), new IntPtr(666), "100"));
            Assert.That(() => c.Escrow("1000", 5000),
                Throws.TypeOf<EmulatorItemNotFoundException>());
		}
		
		[Test]
		public void TestEscrowEmpty()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), ""));
			c.Escrow("", 5000);
		}
	}
}
