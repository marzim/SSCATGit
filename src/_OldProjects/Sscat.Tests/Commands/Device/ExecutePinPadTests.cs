//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core;
using Ncr.Core.Emulators;
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
	public class ExecutePinPadTests
	{
		ExecutePinPad command;
		IScotLogHook hook;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			SscatLane lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			hook = lane.Hooks["Traces"];
			command = new ExecutePinPad(new PinPad(), hook, new DeviceEvent("", ""), lane, 500, true);
			command.Running += new EventHandler<NcrEventArgs>(CommandRunning);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			command.Running -= new EventHandler<NcrEventArgs>(CommandRunning);
		}
		
		[Test]
		public void TestRunWithException()
		{
			command = new ExecutePinPad(new A(), hook, new DeviceEvent("", ""), new SscatLane(), 500, true);
			Assert.That(()=>command.Run(), Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestConstructorWithNullPinPad()
		{
			Assert.That(()=> command = new ExecutePinPad(null, hook, new DeviceEvent("", ""), new SscatLane(), 500, true), 
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestRun()
		{
			command.Run();
		}

		void CommandRunning(object sender, NcrEventArgs e)
		{
		}
		
		class A : Emulator, IPinPad
		{
			public A() : base("A")
			{
			}
			
			public void Execute(string value, int timeout)
			{
				throw new NotImplementedException();
			}
		}
	}
}
