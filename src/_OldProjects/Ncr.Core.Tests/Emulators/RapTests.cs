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
	public class RapTests
	{
		Rap rap;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ProcessUtility.Attach(new ProcessManagerStub(true, false, "RAP is active"));
			ThreadHelper.Attach(new ThreadManagerStub());
			rap = new Rap(50);
		}
		
		[Test]
		public void TestClickAt()
		{
			ThreadHelper.Attach(new ThreadManager());
			rap.ClickAt(RectangleHelper.GetRectangleCenterPoint(837, 696, 179, 71));
		}
		
		[Test]
		public void TestEmptyConstructor()
		{
			rap = new Rap();
		}
		
		[Test]
		public void TestStart()
		{
			rap.Start();
		}
		
		[Test]
		public void TestStartOnException()
		{
            ProcessUtility.Attach(new ProcessManagerStub(true, true, "RAP is all over the rainbow with unicorn."));
            rap = new Rap(10);
            Assert.That(() => rap.Start(true),
                Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestStartOnNotStarted()
		{
			ProcessUtility.Attach(new ProcessManagerStub(false, false, "RAP is active"));
			rap.Start();
		}
		
		[Test]
		public void TestExists()
		{
			Assert.AreEqual(rap.Exists, FileHelper.Exists(rap.FileName));
		}
		
		[Test]
		public void TestGetState()
		{
			Assert.AreEqual(RapState.Running, rap.GetState());
		}
		
		[Test]
		public void TestGetStateOnStop()
		{
			rap.Stop();
			Assert.AreEqual(RapState.NotRunning, rap.GetState());
		}
	}
}
