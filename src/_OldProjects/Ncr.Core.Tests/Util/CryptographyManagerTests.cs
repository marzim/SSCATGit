//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using System.Threading;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class CryptographyManagerTests
	{
		CryptographyManager m;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			m = new CryptographyManager();
		}
	
		[Test]
		public void TestEncrypt()
		{
			Assert.AreEqual("Q+1MwHiTNa4RB04/+wirFg==", m.Encrypt("scot", "scot"));
		}
		
		[Test]
		public void TestDecrypt()
		{
			Assert.AreEqual("scot", m.Decrypt("Q+1MwHiTNa4RB04/+wirFg==", "scot"));
		}		
	}
}