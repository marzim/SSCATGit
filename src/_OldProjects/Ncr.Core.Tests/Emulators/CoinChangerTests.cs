//	<file>
//		<license></license>
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
	public class CoinChangerTests
	{
		CoinChanger c;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			
			c = new CoinChanger();
		}
		
		[Test]
		public void TestBinCount()
		{
			ApiHelper.Attach(new ApiManagerStub(666, new IntPtr(666), new IntPtr(666), new IntPtr(666), "100"));
			c.BinCount("100");
		}
	}
}
