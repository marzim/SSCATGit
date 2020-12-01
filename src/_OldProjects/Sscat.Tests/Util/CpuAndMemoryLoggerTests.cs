//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Util
{
	[TestFixture]
	public class CpuAndMemoryLoggerTests
	{
		CpuAndMemoryLogger logger;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			logger = new CpuAndMemoryLogger(10, new Log4NetLogger(), "Sscat.WinForms");
		}
		
		//[Test]
        //TODO: Either remove or fix empty test
		public void TestMethod()
		{
		}
	}
	
	public class CpuAndMemoryLoggerStub : CpuAndMemoryLogger
	{
		public CpuAndMemoryLoggerStub() : base(10, new Log4NetLogger(), "")
		{
		}
		
		public override void Start()
		{
		}
		
		public override void Stop()
		{
		}
	}
	
	[TestFixture]
	public class CpuAndMemoryTests
	{
		CpuAndMemory c1;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			c1 = new CpuAndMemory(100, 100);
		}
		
		[Test]
		public void TestEmptyConstructor()
		{
			c1.Cpu = 100;
			c1.Memory = 100;
			Assert.AreEqual(100, c1.Cpu);
			Assert.AreEqual(100, c1.Memory);
			Assert.AreEqual("100, 100", c1.ToString());
		}
	}
}
