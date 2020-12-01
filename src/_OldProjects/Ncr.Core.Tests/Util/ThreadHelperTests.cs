//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Threading;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ThreadHelperTests
	{
		[SetUp]
		public void Setup()
		{
			ThreadHelper.Attach(new ThreadManager());
		}
		
		[Test]
		public void TestSleep()
		{
			ThreadHelper.Sleep(100);
		}
		
		[Test]
		public void TestSleepOnNullManager()
		{
			ThreadHelper.Attach(null);
            try {
                ThreadHelper.Sleep(100);
            } catch (ArgumentNullException ex) {
                Assert.AreEqual("ThreadManager", ex.ParamName);
            }
		}
		
		[Test]
		public void TestStart()
		{
			ThreadHelper.Start(D);
		}
		
		[Test]
		public void TestStartOnNullManager()
		{
			ThreadHelper.Attach(null);
            try {
                ThreadHelper.Start(D);
            } catch (ArgumentNullException ex) {
                Assert.AreEqual("ThreadManager", ex.ParamName);
            }
		}
		
		void D()
		{
		}
	}
}
