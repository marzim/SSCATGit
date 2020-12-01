//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands
{
	[TestFixture]
	public class WldbEventCommandFactoryTests
	{
		SscatLane lane;
		Dictionary<string, IScotLogHook> hooks;
		
		[SetUp]
		public void Setup()
		{
			lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			
			hooks = lane.Hooks;
		}
		
		[Test]
		public void TestUpdateWldb()
		{
			IWldbEvent e = new WldbEvent("Update", "", "", "", "", "", "");
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(UpdateWldb), WldbEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}

		[Test]
		public void TestNotSupportedEvent()
		{
			IWldbEvent e = new WldbEvent("Qwerty", "", "", "", "", "", "");
			Assert.That(() => WldbEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand(),
                Throws.TypeOf<NotSupportedException>());
		}
	}
}
