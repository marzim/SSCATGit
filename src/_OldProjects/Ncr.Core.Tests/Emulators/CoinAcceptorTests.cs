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
	public class CoinAcceptorTests
	{
		CoinAcceptor c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			
			c = new CoinAcceptor();
		}
		
		[Test]
		public void TestInsert1()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "1"));
			c.Insert("1", 5000);
		}
		
		[Test]
		public void TestInsert5()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "5"));
			c.Insert("5", 5000);
		}
		
		[Test]
		public void TestInsert10()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "10"));
			c.Insert("10", 5000);
		}
		
		[Test]
		public void TestInsert25()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "25"));
			c.Insert("25", 5000);
		}
		
		[Test]
		public void TestInsert100()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "100"));
			c.Insert("100", 5000);
		}
		
		[Test]
		public void TestInsertException()
		{
//			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "1"));
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, new IntPtr(666), new IntPtr(666), "1"));
            Assert.That(() => c.Insert("100", 5000),
                Throws.TypeOf<EmulatorItemNotFoundException>());
		}
		
		[Test]
		public void TestInsertEmpty()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), ""));
			c.Insert("", 5000);
		}
		
//		[Test]
//		public void TestInsertEmptyValue()
//		{
//			c.Insert("", 5000);
//		}
//		
//		[Test]
//		public void TestInsertLessThan5()
//		{
//			c.Insert("1", 5000);
//		}
//		
//		[Test]
//		public void TestInsert5()
//		{
//			c.Insert("5", 5000);
//		}
//		
//		[Test]
//		public void TestInsertLessThan10ButGreaterThan5()
//		{
//			c.Insert("7", 5000);
//		}
//		
//		[Test]
//		public void TestInsert10()
//		{
//			c.Insert("10", 5000);
//		}
//		
//		[Test]
//		public void TestInsertLessThan25ButGreaterThan10()
//		{
//			c.Insert("16", 5000);
//		}
//		
//		[Test]
//		public void TestInsert25()
//		{
//			c.Insert("25", 5000);
//		}
//		
//		[Test]
//		public void TestInsertLessThan100ButGreaterThan25()
//		{
//			c.Insert("54", 5000);
//		}
//		
//		[Test]
//		public void TestInsert100()
//		{
//			c.Insert("100", 5000);
//		}
//		
//		[Test]
//		public void TestInsertGreaterThan100()
//		{
//			c.Insert("123", 5000);
//		}
	}
}
