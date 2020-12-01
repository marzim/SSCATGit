//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@gmail.com"/>
//	</file>

using System;
using System.Collections.Generic;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Commands;
using Sscat.Core.Commands.LaunchPadPsx;
using Sscat.Core.Emulators;
using Sscat.Core.Log;
using Sscat.Core.Models;
using Sscat.Core.Parsers;
using Sscat.Tests.Config;

namespace Sscat.Tests.Commands
{
	[TestFixture]
	public class LaunchpadPsxEventCommandFactoryTests
	{
		SscatLane lane;
		Dictionary<string, IScotLogHook> hooks;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			lane = new SscatLane();
			lane.Configuration = new LaneConfigurationRepositoryStub().Read("");
			lane.Hooks = lane.Configuration.GetHooks();
			hooks = lane.Hooks;
		}
		
		[Test]
		public void TestChangeContext()
		{
			IPsxEvent e = new LaunchPadPsxEvent("1", "", "", "ChangeContext", "", "", 1);
			Assert.IsInstanceOf(typeof(LaunchPadPsxChangeContext), LaunchPadPsxEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}
		
		[Test]
		public void TestClick()
		{
			IPsxEvent e = new LaunchPadPsxEvent("1", "", "", "Click", "", "", 1);
			Assert.IsInstanceOf(typeof(LaunchPadPsxClick), LaunchPadPsxEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}
		
		[Test]
		public void TestChangeFocus()
		{
			IPsxEvent e = new LaunchPadPsxEvent("1", "", "", "ChangeFocus", "", "", 1);
			Assert.IsInstanceOf(typeof(LaunchPadPsxChangeFocus), LaunchPadPsxEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}
		
		[Test]
		public void TestNotSupportedEvent()
		{
			IPsxEvent e = new LaunchPadPsxEvent("1", "", "", "Qwerty", "", "", 1);
			LaunchPadPsxEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand();
		}
	}
}
