//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Diagnostics;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ProcessUtilityTests
	{
		[SetUp]
		public void Setup()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true));
		}
		
		[Test]
		public void TestGetProcessesByName()
		{
			Assert.IsNotNull(ProcessUtility.GetProcessesByName("ChuckNorris"));
		}
		
		[Test]
		public void TestGetProcessesByNameOnNullManager()
		{
			ProcessUtility.Attach(null);
            Assert.That(() => ProcessUtility.GetProcessesByName("ChuckNorris"),
                Throws.TypeOf<ArgumentNullException>());
		}
			
		[Test]
		public void TestGetCurrentProcess()
		{
			Assert.IsNotNull(ProcessUtility.GetCurrentProcess());
		}
				
		[Test]
		public void TestGetCurrentProcessOnNullManager()
		{
			ProcessUtility.Attach(null);
            Assert.That(() => ProcessUtility.GetCurrentProcess(),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestKillOnNullManager()
		{
			ProcessUtility.Attach(null);
            Assert.That(() => ProcessUtility.Kill("test", true),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestHasStartedAndIncludeMe()
		{
			Assert.IsTrue(ProcessUtility.HasStarted("ChuckNorris", true));
		}
		
		[Test]
		public void TestHasStartedAndIncludeMeOnNullManager()
		{
			ProcessUtility.Attach(null);
            Assert.That(() => Assert.IsTrue(ProcessUtility.HasStarted("ChuckNorris", true)),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestHasStarted()
		{
			Assert.IsTrue(ProcessUtility.HasStarted("ChuckNorris"));
		}
		
		[Test]
		public void TestHasStartedOnNullManager()
		{
			ProcessUtility.Attach(null);
            Assert.That(() => Assert.IsTrue(ProcessUtility.HasStarted("ChuckNorris")),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestKill()
		{
			ProcessUtility.Kill("test");
		}
		
		[Test]
		public void TestKillAndWait()
		{
			ProcessUtility.Kill("test", true);
		}
		
		[Test]
		public void TestCanPingOnNullManager()
		{
			ProcessUtility.Attach(null);
            Assert.That(() => Assert.IsTrue(ProcessUtility.CanPing("localhost")),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestGetStandardOutputOnNullManager()
		{
			ProcessUtility.Attach(null);
            Assert.That(() => ProcessUtility.GetStandardOutput(@"C:\Projects\finger\trunk\tets\some.exe", "holy"),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestGetStandardOutput()
		{
			ProcessUtility.GetStandardOutput(@"C:\Projects\finger\trunk\tets\some.exe", "holy");
		}
		
		[Test]
		
		public void TestStartOnNullManager()
		{
			ProcessUtility.Attach(null);
            Assert.That(() => ProcessUtility.Start(new ProcessStartInfo(@"C:\Projects\finger\trunk\tests\some.exe")),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestStart()
		{
			ProcessUtility.Start(new ProcessStartInfo(@"C:\Projects\finger\trunk\tests\some.exe"));
		}
		
		[Test]
		public void TestStartCrazy()
		{
			ProcessUtility.Start(@"some.exe", "", ProcessWindowStyle.Normal, false);
		}
		
		[Test]
		public void TestStartCrazyOnNullManager()
		{
			ProcessUtility.Attach(null);
            Assert.That(() => ProcessUtility.Start(@"some.exe", "", ProcessWindowStyle.Normal, false),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestCanPing()
		{
			Assert.IsTrue(ProcessUtility.CanPing("localhost"));
		}
		
		[Test]
		public void TestStartWithFileNameOnNullManager()
		{
			ProcessUtility.Attach(null);
            Assert.That(() => ProcessUtility.Start(@"C:\Projects\finger\trunk\tests\some.exe"),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestStartWithFileName()
		{
			ProcessUtility.Start(@"C:\Projects\finger\trunk\tests\some.exe");
		}
		
		[Test]
		public void TestStartWithFileNameAndWaitForAMoment()
		{
			ProcessUtility.Start(@"C:\Projects\finger\trunk\tests\some.exe", true, 100);
		}
		
		[Test]
		public void TestStartWithFileNameAndWaitForAMomentOnNullManager()
		{
			ProcessUtility.Attach(null);
            Assert.That(() => ProcessUtility.Start(@"C:\Projects\finger\trunk\tests\some.exe", true, 100),
                Throws.TypeOf<ArgumentNullException>());
		}
	}
}
