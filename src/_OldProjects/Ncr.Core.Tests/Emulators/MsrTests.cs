//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class MsrTests
	{
		Msr m;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			
			m = new Msr();
		}
		
		[Test]
		public void TestSwipe()
		{
			m.Swipe("4921190001020103~0812101171750000000000767000000~12345678901234=06051010000087524397~a9600096861234567890123400000000000000605101000000000000000000", 5000);
		}
	}
}
