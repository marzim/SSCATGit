//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Core.Services;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands.Device
{
	[TestFixture]
	public class ScanCodeTests
	{
		ScanCode command;
		IScotLogHook hook;
		
		[SetUp]
		public void Setup()
		{
			ApiHelper.Attach(new ApiManagerStub());
			SscatLane lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			hook = lane.Hooks["Traces"];
			command = new ScanCode(new Scanner(), hook, new DeviceEvent("Scanner", "F4800011186924~4800011186924~104"), lane, 100, true);
		}
		
		[Test]
		public void TestConstructorWithNullScanner()
		{
			Assert.That(() => command = new ScanCode(null, hook, new DeviceEvent("Scanner", ""), new SscatLane(), 100, true),
                Throws.TypeOf<ArgumentNullException>()); 
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}
		
		[Test]
		public void TestRunWithEmulatorException()
		{
			command = new ScanCode(new A(), hook, new DeviceEvent("Scanner", "F4800011186924~4800011186924~104"), new SscatLane(), 100, true);
			command.Run();
		}
		
		[Test]
		public void TestRunWithException()
		{
			command = new ScanCode(new B(), hook, new DeviceEvent("Scanner", "F4800011186924~4800011186924~104"), new SscatLane(), 100, true);
			command.Run();
		}

		void CommandConnectionAdding(object sender, PsxWrapperEventArgs e)
		{
		}
		
		class A : Scanner, IScanner
		{
			public A()
			{
			}
			
			public override void Scan(string code, int timeout)
			{
				throw new EmulatorTimeoutException("");
			}
		}
		
		class B : Scanner, IScanner
		{
			public B()
			{
			}
			
			public override void Scan(string code, int timeout)
			{
				throw new Exception();
			}
		}
	}
}
