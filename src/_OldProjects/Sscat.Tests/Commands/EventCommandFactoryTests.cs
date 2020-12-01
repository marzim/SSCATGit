//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.Collections.Generic;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
using NUnit.Framework;
using Rhino.Mocks;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Util;
using Sscat.Tests.Util;
using Sscat.Core.Commands.Events;

namespace Sscat.Tests.Commands
{
    [TestFixture]
    public class EventCommandFactoryTests
    {
        SscatLane lane;
        Dictionary<string, IScotLogHook> hooks;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            lane = new SscatLane();

            lane.SecurityManager = MockRepository.GenerateMock<ISscatSecurityManager>();
            lane.PsxConnections = new PsxCollection();
            lane.ApplicationLauncher = new SscatApplicationLauncher();

            lane.AddEmulator(new BagScale());
            lane.AddEmulator(new Scale());

            hooks = new Dictionary<string, IScotLogHook>();
            hooks.Add(ScotLogHook.Psx, MockRepository.GenerateMock<IScotLogHook>());
            hooks.Add(ScotLogHook.LaunchPadPsx, MockRepository.GenerateMock<IScotLogHook>());
            hooks.Add(ScotLogHook.Traces, MockRepository.GenerateMock<IScotLogHook>());
            hooks.Add(ScotLogHook.SM, MockRepository.GenerateMock<IScotLogHook>());
            hooks.Add(ScotLogHook.Xmode, MockRepository.GenerateMock<IScotLogHook>());
        }

        [Test]
        public void TestGetCommandFactoryWithNullHooks()
        {
            IEventCommand e;
            Assert.That(() => e = EventCommandFactory.GetCommandFactory(new ScriptEvent(new PsxEvent("1", "Attract", "", "ChangeContext", "", "", 0)), lane, null, 100, true).CreateCommand(),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestNotSuppertedEventItem()
        {
            IEventCommand e;
            Assert.That(() => e = EventCommandFactory.GetCommandFactory(new ScriptEvent(new EventItemStub()), lane, hooks, 100, true).CreateCommand(),
                Throws.TypeOf<NotSupportedException>());
        }

        [Test]
        public void TestApplicationLauncherEvent()
        {
            IEventCommand e = EventCommandFactory.GetCommandFactory(new ScriptEvent(new ApplicationLauncherEvent()), lane, hooks, 100, true).CreateCommand();
        }

        [Test]
        public void TestLaunchPadPsxEvent()
        {
            IEventCommand e = EventCommandFactory.GetCommandFactory(new ScriptEvent(new LaunchPadPsxEvent("1", "", "", "ChangeContext", "", "", 0)), lane, hooks, 100, true).CreateCommand();
        }

        [Test]
        public void TestWldbEvent()
        {
            IEventCommand e = EventCommandFactory.GetCommandFactory(new ScriptEvent(new WldbEvent("Update", "g2lane-ian", "some.mdb", "some.mdb", "some.xml", "scot", "Q+1MwHiTNa4RB04/+wirFg==")), lane, hooks, 100, true).CreateCommand();
        }

        [Test]
        public void TestPsxEvent()
        {
            IEventCommand e = EventCommandFactory.GetCommandFactory(new ScriptEvent(new PsxEvent("1", "Attract", "", "ChangeContext", "", "", 0)), lane, hooks, 100, true).CreateCommand();
        }

        [Test]
        public void TestSMEvent()
        {
            IEventCommand e = EventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("BagScale", "500")), lane, hooks, 100, true).CreateCommand();
        }

        [Test]
        public void TestTraceEvent()
        {
            IEventCommand e = EventCommandFactory.GetCommandFactory(new ScriptEvent(new DeviceEvent("Scale", "500")), lane, hooks, 100, true).CreateCommand();
        }
        [Test]
        public void TestXmodeEvent()
        {
            IEventCommand e = EventCommandFactory.GetCommandFactory(new ScriptEvent(new XmEvent("XmCountChanges", 1, new string[] { "Value" })), lane, hooks, 100, true).CreateCommand();
        }

        [Test]
        public void TestReportEvent()
        {
            IEventCommand e = EventCommandFactory.GetCommandFactory(new ScriptEvent(new ReportEvent("ReportsMenu", "TestValue")), lane, hooks, 100, true).CreateCommand();
        }
    }

    public class EventItemStub : AbstractScriptEventItem<EventItemStub>, IScriptEventItem
    {
        public override string Type
        {
            get
            {
                return "EventItemStub";
            }
        }

        public override IScriptEvent CreateEvent()
        {
            throw new NotImplementedException();
        }

        public override IScriptEvent CreateEvent(int time, bool enabled)
        {
            throw new NotImplementedException();
        }

        public override IScriptEventItem ToEventItem()
        {
            throw new NotImplementedException();
        }

        public override bool IsSimilarEventItemWith(IScriptEventItem eventItemToCompareWith)
        {
            throw new NotImplementedException();
        }
    }
}
