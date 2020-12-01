//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class ScaleTests
	{
		Scale s;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			
			s = new Scale();
		}
		
		[Test]
		public void TestWeigh()
		{
			s.Weigh(400, 100);
		}
		
		[Test]
		public void TestWeighNegativeNumber()
		{
			s.Weigh(-12, 100);
		}
		
		[Test]
		public void TestTear()
		{
			s.Tear();
		}
		
		[Test]
		public void TestGetWeight()
		{
			Assert.AreEqual(0, s.Weight);
		}
	}
}
