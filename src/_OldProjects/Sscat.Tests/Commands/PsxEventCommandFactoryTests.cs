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
	public class PsxEventCommandFactoryTests
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
		public void TestOnNullPsxConnections()
		{
			lane.PsxConnections = null;
			IPsxEvent e = new PsxEvent("1", "", "", "Click", "", "", 1);
			Assert.That(() => PsxEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand(),
                Throws.TypeOf<Exception>());
		}
		
		[Test]
		public void TestChangeContext()
		{
			IPsxEvent e = new PsxEvent("1", "", "", "ChangeContext", "", "", 1);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(PsxChangeContext), PsxEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}
		
		[Test]
		public void TestChangeTheme()
		{
			IPsxEvent e = new PsxEvent("1", "", "", "ChangeTheme", "", "", 1);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(PsxChangeTheme), PsxEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}		
		
		[Test]
		public void TestKeyDown()
		{
			IPsxEvent e = new PsxEvent("1", "", "", "KeyDown", "", "", 1);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(PsxKeyDown), PsxEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}
		
		[Test]
		public void TestConnectRemote()
		{
			IPsxEvent e = new PsxEvent("1", "", "", "ConnectRemote", "", "", 1);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(PsxConnectRemote), PsxEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}
		
		[Test]
		//Deprecated in NUnit 3 
		//[ExpectedException(typeof(NotSupportedException))]
		public void TestNotSupportedEvent()
		{
			IPsxEvent e = new PsxEvent("1", "", "", "Qwerty", "", "", 1);
			PsxEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand();
		}
		
		[Test]
		public void TestKeyPress()
		{
			IPsxEvent e = new PsxEvent("1", "", "", "KeyPress", "", "", 1);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(PsxKeyPress), PsxEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}
		
		[Test]
		public void TestClick()
		{
			IPsxEvent e = new PsxEvent("1", "", "", "Click", "", "", 1);
			//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
			Assert.IsInstanceOf(typeof(PsxClick), PsxEventCommandFactory.GetCommandFactory(new ScriptEvent(e), lane, hooks, 500, true).CreateCommand());
		}
	}
}
