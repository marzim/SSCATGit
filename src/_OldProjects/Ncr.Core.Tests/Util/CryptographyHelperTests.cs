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
	public class CryptographyHelperTests
	{
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			CryptographyHelper.Attach(new CryptographyManager());
		}
	
		[Test]
		public void TestEncrypt()
		{
			CryptographyHelper.Attach(new CryptographyManager());
			Assert.AreEqual("Q+1MwHiTNa4RB04/+wirFg==", CryptographyHelper.Encrypt("scot", "scot"));
		}
		
		[Test]
		public void TestEncryptNull()
		{
			CryptographyHelper.Attach(null);
            Assert.That(() => Assert.AreEqual("Q+1MwHiTNa4RB04/+wirFg==", CryptographyHelper.Encrypt("scot", "scot")),
                Throws.TypeOf<ArgumentNullException>());
		}		
		
		[Test]
		public void TestDecrypt()
		{
			CryptographyHelper.Attach(new CryptographyManager());
			Assert.AreEqual("scot", CryptographyHelper.Decrypt("Q+1MwHiTNa4RB04/+wirFg==", "scot"));
		}
		
		[Test]
		public void TestDecryptNull()
		{
			CryptographyHelper.Attach(null);
            Assert.That(() => Assert.AreEqual("scot", CryptographyHelper.Decrypt("Q+1MwHiTNa4RB04/+wirFg==", "scot")),
                Throws.TypeOf<ArgumentNullException>());
		}		
	}
}