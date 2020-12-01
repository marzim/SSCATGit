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
	public class StoreServerTests
	{
		StoreServer s;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			FileHelper.Attach(new FileManagerStub());
			DirectoryHelper.Attach(new DirectoryManagerStub());
			ProcessUtility.Attach(new ProcessManagerStub());
			s = new StoreServer();
		}
		
		[Test]
		public void TestExists()
		{
			Assert.AreEqual(s.Exists, FileHelper.Exists(s.FileName));
			Assert.AreEqual("java", s.ProcessName);
		}
		
		[Test]
		public void TestStart()
		{
			s.Start();
		}
		
		[Test]
		public void TestStop()
		{
			s.Kill();
		}
	}
}
