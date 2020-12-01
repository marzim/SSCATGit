//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class LoggingServiceTests
	{
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			LoggingService.Level = LogLevel.Info | LogLevel.Warning | LogLevel.Error | LogLevel.Create | LogLevel.Exists | LogLevel.Debug;
			LoggingService.ClearLoggers();
			LoggingService.Attach(new Log4NetLogger());
		}
		
		[Test]
		public void TestLogLevel()
		{
			LoggingService.Level = LogLevel.Create;
			Assert.AreEqual(LogLevel.Create, LoggingService.Level);
		}
		
		[Test]
		public void TestShow()
		{
			LoggingService.Info("Info...");
			LoggingService.Error("Error...");
			LoggingService.Create("Create...");
			LoggingService.Exists("Exists...");
			LoggingService.Warning("Warning...");
			LoggingService.Debug("Debug...");
		}
		
		[Test]
		public void TestBitwiseValue()
		{
			LogLevel l = LogLevel.Info;
			Assert.IsFalse(LogLevel.Exists == (l | LogLevel.Exists));
		}
	}
}
