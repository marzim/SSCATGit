//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Tests.Emulators;

namespace Sscat.Tests.Commands.Device
{
	[TestFixture]
	public class SwipeMsrTests
	{
		SwipeMsr command;
		IScotLogHook hook;
		SscatLane lane;
		
		[SetUp]
		public void Setup()
		{
			ApiHelper.Attach(new ApiManagerStub());
			
			lane = new SscatLane();
			
			hook = MockRepository.GenerateMock<IScotLogHook>();
			command = new SwipeMsr(new Msr(), hook, new DeviceEvent("MSR", "4921190001020103~0812101171750000000000767000000~12345678901234=06051010000087524397~a9600096861234567890123400000000000000605101000000000000000000"), lane, 100, true);
			command.Running += new EventHandler<NcrEventArgs>(MsrRunning);
		}
		
		[TearDown]
		public void TearDown()
		{
			command.Running -= new EventHandler<NcrEventArgs>(MsrRunning);
		}
		
		[Test]
		public void TestConstructorWithNullMsr()
		{
			Assert.That(() => command = new SwipeMsr(null, hook, new DeviceEvent("MSR", "4921190001020103~0812101171750000000000767000000~12345678901234=06051010000087524397~a9600096861234567890123400000000000000605101000000000000000000"), new SscatLaneStub(), 100, true),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestRunWithException()
		{
			command = new SwipeMsr(new A(), hook, new DeviceEvent("MSR", "4921190001020103~0812101171750000000000767000000~12345678901234=06051010000087524397~a9600096861234567890123400000000000000605101000000000000000000"), new SscatLaneStub(), 100, true);
			Assert.That(() => command.Run(),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestPreRunDefault()
		{
			lane.Configuration = LaneConfiguration.Deserialize(new StringReader(@"<Configuration>
	<Player>
		<MSRCards>
			<Card Name='Default' Track1='4921190001020103' Track2='0812101171750000000000767000000' Track3='12345678901234=06051010000087524397'/>
		</MSRCards>
	</Player>
</Configuration>"));
			command = new SwipeMsr(new A(), hook, new DeviceEvent("MSR", "Default"), lane, 100, true);
			command.PreRun();
		}
		
		[Test]
		public void TestPreRun()
		{
			lane.Configuration = LaneConfiguration.Deserialize(new StringReader(@"<Configuration>
	<Player>
		<MSRCards>
			<Card Name='Default' Track1='4921190001020103' Track2='0812101171750000000000767000000' Track3='12345678901234=06051010000087524397'/>
		</MSRCards>
	</Player>
</Configuration>"));
			command = new SwipeMsr(new A(), hook, new DeviceEvent("MSR", "911"), lane, 100, true);
			command.PreRun();
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}

		void MsrRunning(object sender, NcrEventArgs e)
		{
		}
		
		class A : Emulator, IMsr
		{
			public A() : base("A")
			{
			}
			
			public void Swipe(string value, int timeout)
			{
				throw new NotImplementedException();
			}
		}
	}
}
