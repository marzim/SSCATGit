//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands.Device
{
	[TestFixture]
	public class EmulatorEventCommandTests
	{
		EmulatorEventCommand command;
		SscatLane lane;
		IScotLogHook hook;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			hook = lane.Hooks["Traces"];
			command = new EmulatorEventCommand(hook, new DeviceEvent(), new A(), lane, 10, true);
		}
		
		[Test]
		public void TestRun()
		{
			IScotLogHook h = new I(new TextWatcher(@""), lane.Configuration.GetParsers()[0]);
			command = new EmulatorEventCommand(h, new DeviceEvent(), new A(), lane, 10, true);
			command.Run();
		}
		
		[Test]
		public void TestRunOnNotExists()
		{
            command = null;
			Assert.That (() => command.Run(),
                Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestRunOnEmulatorNotStarted()
		{
			command = new EmulatorEventCommand(hook, new DeviceEvent(), new B(), lane, 10, true);
			Assert.That(() => command.Run(), Throws.TypeOf<EmulatorException>());
		}
		
		[Test]
		public void TestRunOnDisabledHook()
		{
			command = new EmulatorEventCommand(hook, new DeviceEvent(), new A(), lane, 10, false);
			command.Run();
		}
		
		[Test]
		public void TestRunWithEmulatorNotFoundException()
		{
			command = new EmulatorEventCommand(hook, new DeviceEvent(), new C(), lane, 10, false);
			command.Run();
		}
		
		[Test]
		public void TestRunWithEmulatorTimeoutException()
		{
			command = new EmulatorEventCommand(hook, new DeviceEvent(), new D(), lane, 10, false);
			command.Run();
		}
		
		[Test]
		public void TestRunWithEmulatorItemNotFoundException()
		{
			command = new EmulatorEventCommand(hook, new DeviceEvent(), new J(), lane, 10, false);
			command.Run();
		}		
		
		class A : Emulator
		{
			public A() : base("A")
			{
			}
			
			public override bool Available()
			{
				return true;
			}
		}
		
		class B : Emulator
		{
			public B() : base("B")
			{
			}
			
			public override bool Available()
			{
				return false;
			}
		}
		
		class C : Emulator
		{
			public C() : base("C")
			{
			}
			
			public override bool Available()
			{
				throw new EmulatorNotFoundException("C");
			}
		}
		
		class D : Emulator
		{
			public D() : base("D")
			{
			}
			
			public override bool Available()
			{
				throw new EmulatorTimeoutException("D");
			}
		}
		
		class H : ScotLogHook
		{
			public H(ITextWatcher watcher, IParser parser) : base(watcher, parser)
			{
			}
		}
		
		class I : ScotLogHook
		{
			public I(ITextWatcher watcher, IParser parser) : base(watcher, parser)
			{
			}
			
			public override bool Exists(IScriptEvent evnt, out IScriptEvent lastSimilarEvent, int timeout)
			{
				lastSimilarEvent = null;
				return true;
			}
		}
		
		class J : Emulator
		{
			public J() : base("J")
			{
			}
			
			public override bool Available()
			{
				throw new EmulatorItemNotFoundException("J", "J");
			}
		}		
	}
}
