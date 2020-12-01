//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Models;
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

namespace Sscat.Tests.Commands.Psx
{
	[TestFixture]
	public class PsxChangeContextTests
	{
		PsxChangeContext attract;
		PsxChangeContext hasRap;
		PsxChangeContext startUp;
		PsxChangeTheme changeTheme;
		PsxUnsupportedEvent unsupportedEvent;
		SscatLane lane;
		IScotLogHook hook;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			lane = new SscatLane();
			lane.PsxConnections.Add("AUTOMATION", MockRepository.GenerateMock<IPsx>());
			lane.PsxConnections.Add("RAP.g2lane-ian", MockRepository.GenerateMock<IPsx>());
			
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Parsers = lane.Configuration.GetParsers();
			lane.Hooks = lane.Configuration.GetHooks();
			hook = lane.Hooks["Psx"];
			attract = new PsxChangeContext(hook, new PsxEvent("1", "Attract", "Display", "ChangeContext", "", "", 0), lane, 5000, true);
			hasRap = new PsxChangeContext(hook, new PsxEvent("1", "", "", "ConnectRemote", "HandheldRAP=0;", "RAP.g2lane-ian", 0), lane, 5000, true);
			startUp = new PsxChangeContext(hook, new PsxEvent("1", "Startup", "Display", "ChangeContext", "", "", 0), lane, 5000, true);
			changeTheme = new PsxChangeTheme(hook, new PsxEvent("1", "Attract", "Display", "ChangeTheme", "", "", 0), lane, 5000, true);
			unsupportedEvent = new PsxUnsupportedEvent(hook, new PsxEvent("1", "Attract", "Display", "Quit", "", "", 0), lane, 5000, true);
		}

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            lane.PsxConnections.Clear();
        }
		
		[Test]
		public void TestRunOnDisabledHook()
		{
			attract = new PsxChangeContext(hook, new PsxEvent("1", "Attract", "Display", "ChangeContext", "", "", 0), lane, 5000, false);
			attract.Run();
		}
		
		[Test]
		public void TestRunWithHookChecking()
		{
			IScotLogHook h = new H(new TextWatcher(@""), lane.Parsers[0]);
			attract = new PsxChangeContext(h, new PsxEvent("1", "Attract", "Display", "ChangeContext", "", "", 0), lane, 5000, true);
			attract.Run();
		}
		
		[Test]
		public void TestHasRapWithoutPsxConnection()
		{
			lane.PsxConnections.Clear();
            Assert.That(() => hasRap.Run(),
               Throws.TypeOf<NoPsxAttachedException>());

            lane = new SscatLane();
            lane.PsxConnections.Add("AUTOMATION", MockRepository.GenerateMock<IPsx>());
            lane.PsxConnections.Add("RAP.g2lane-ian", MockRepository.GenerateMock<IPsx>());

            lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
            lane.Parsers = lane.Configuration.GetParsers();
            lane.Hooks = lane.Configuration.GetHooks();
            hook = lane.Hooks["Psx"];
            attract = new PsxChangeContext(hook, new PsxEvent("1", "Attract", "Display", "ChangeContext", "", "", 0), lane, 5000, true);
            hasRap = new PsxChangeContext(hook, new PsxEvent("1", "", "", "ConnectRemote", "HandheldRAP=0;", "RAP.g2lane-ian", 0), lane, 5000, true);
            startUp = new PsxChangeContext(hook, new PsxEvent("1", "Startup", "Display", "ChangeContext", "", "", 0), lane, 5000, true);
            changeTheme = new PsxChangeTheme(hook, new PsxEvent("1", "Attract", "Display", "ChangeTheme", "", "", 0), lane, 5000, true);
            unsupportedEvent = new PsxUnsupportedEvent(hook, new PsxEvent("1", "Attract", "Display", "Quit", "", "", 0), lane, 5000, true);
		}
		
		[Test]
		public void TestAttractWithoutPsxConnection()
		{
			lane.PsxConnections.Clear();
            Assert.That(() => attract.Run(),
               Throws.TypeOf<NoPsxAttachedException>());

            lane = new SscatLane();
            lane.PsxConnections.Add("AUTOMATION", MockRepository.GenerateMock<IPsx>());
            lane.PsxConnections.Add("RAP.g2lane-ian", MockRepository.GenerateMock<IPsx>());

            lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
            lane.Parsers = lane.Configuration.GetParsers();
            lane.Hooks = lane.Configuration.GetHooks();
            hook = lane.Hooks["Psx"];
            attract = new PsxChangeContext(hook, new PsxEvent("1", "Attract", "Display", "ChangeContext", "", "", 0), lane, 5000, true);
            hasRap = new PsxChangeContext(hook, new PsxEvent("1", "", "", "ConnectRemote", "HandheldRAP=0;", "RAP.g2lane-ian", 0), lane, 5000, true);
            startUp = new PsxChangeContext(hook, new PsxEvent("1", "Startup", "Display", "ChangeContext", "", "", 0), lane, 5000, true);
            changeTheme = new PsxChangeTheme(hook, new PsxEvent("1", "Attract", "Display", "ChangeTheme", "", "", 0), lane, 5000, true);
            unsupportedEvent = new PsxUnsupportedEvent(hook, new PsxEvent("1", "Attract", "Display", "Quit", "", "", 0), lane, 5000, true);
		}
		
		[Test]
		public void TestRunWithRap()
		{
			hasRap.Run();
		}
		
		[Test]
		public void TestRun()
		{
			attract.Run();
			Assert.AreEqual(ResultType.Failed, attract.Result.Type);
		}
		
		[Test]
		public void TestRunWithIsExemptedItem()
		{
			startUp.Run();
			Assert.AreEqual(ResultType.Skipped, startUp.Result.Type);
		}		
		
		[Test]
		public void TestRunChangeTheme()
		{
			changeTheme.Run();
			Assert.AreEqual(ResultType.Failed, changeTheme.Result.Type);
		}
		
		[Test]
		public void TestRunUnsupportedEvent()
		{
			unsupportedEvent.Run();
			Assert.AreEqual(ResultType.Skipped, unsupportedEvent.Result.Type);
		}		
		
		class H : ScotLogHook
		{
			public H(ITextWatcher watcher, IParser parser) : base(watcher, parser)
			{
			}
			
			public override bool Exists(IScriptEvent evnt, out IScriptEvent lastSimilarEvent, int timeout)
			{
				lastSimilarEvent = null;
				OnChecking(new SscatEventArgs("Checking..."));
				return true;
			}
		}
	}
}
