//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using Ncr.Core.Models;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands
{
	[TestFixture]
	public class AbstractEventCommandTests
	{
		A a;
		IScotLogHook hook;
		SscatLane lane;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			RegistryHelper.Attach(new RegistryManagerStub());
			
			lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			
			hook = MockRepository.GenerateMock<IScotLogHook>();
			a = new A(hook, new PsxEvent("1", "Attract", "CMButton1Lg", "Click", "", "", 0), lane, 5000, true);
			a.ConnectionAdding += new EventHandler<PsxWrapperEventArgs>(CommandConnectionAdding);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			a.ConnectionAdding -= new EventHandler<PsxWrapperEventArgs>(CommandConnectionAdding);
		}
		
		[Test]
		public void TestLogHookNull()
		{
            A a;
			Assert.That(() => a = new A(null, new PsxEvent("1", "Attract", "CMButton1Lg", "Click", "", "", 0), lane, 5000, true), 
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestEmptyConstructor()
		{
			A a = new A();
		}
		
		[Test]
		public void TestRunOnDisabledHook()
		{
			A a = new A(hook, new PsxEvent("1", "Attract", "CMButton1Lg", "Click", "", "", 0), lane, 5000, false);
			a.Run();
		}
		
		[Test]
		public void TestLaneValue()
		{
			Assert.IsNotNull(a.Lane);
		}
		
		[Test]
		public void TestPreRun()
		{
			a.PreRun();
		}
		
		[Test]
		public void TestRun()
		{
			a.Run();
			Assert.IsNull(a.Result);
		}
		
		[Test]
		public void TestRunWithHookChecking()
		{
			IScotLogHook h = new I(new TextWatcher(@""), lane.Configuration.GetParsers()[0]);
			A a = new A(h, new PsxEvent("1", "Attract", "CMButton1Lg", "Click", "", "", 0), lane, 5000, true);
			a.Run();
		}
		
		[Test]
		public void TestRunOnException()
		{
			IScotLogHook h = new H(new TextWatcher(@""), lane.Configuration.GetParsers()[0]);
			A a = new A(h, new PsxEvent("1", "Attract", "CMButton1Lg", "Click", "", "", 0), lane, 5000, true);
			Assert.That(() => a.Run(), Throws.TypeOf<NotImplementedException>());
		}

		void CommandConnectionAdding(object sender, PsxWrapperEventArgs e)
		{
		}
		
		class A : AbstractEventCommand
		{
			public A() : base()
			{
			}
			
			public A(IScotLogHook hook, IScriptEventItem item, SscatLane lane, int timeout, bool enableHook) : base(hook, item, lane, timeout, enableHook)
			{
			}
			
			public override void Run()
			{
				base.Run();
				OnConnectionAdding(new PsxWrapperEventArgs("localhost", "FastLaneRemoteServer", "AUTOMATION", 10));
			}
		}
		
		class H : ScotLogHook
		{
			public H(ITextWatcher watcher, IParser parser) : base(watcher, parser)
			{
			}
			
			public override Result Check(IScriptEvent evnt, int timeout)
			{
				throw new NotImplementedException();
			}
		}
		
		class I : H
		{
			public I(ITextWatcher watcher, IParser parser) : base(watcher, parser)
			{
			}
			
			public override Result Check(IScriptEvent evnt, int timeout)
			{
				OnChecking(new SscatEventArgs("Checking..."));
				return new Result(ResultType.Passed, "OK");
			}
		}
	}
}
