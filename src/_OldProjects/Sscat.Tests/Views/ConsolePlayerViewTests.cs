//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using NUnit.Framework;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Repositories;
using Sscat.Tests.Models;
using Sscat.Tests.Repositories;
using Sscat.Views;

namespace Sscat.Tests.Views
{
	[TestFixture]
	public class ConsolePlayerViewTests
	{
		ConsolePlayerView v;
		IScriptRepository r;
		
		[OneTimeSetUp]
		public void Setup()
		{
			r = new ScriptRepositoryStub();
			v = new ConsolePlayerView(r.GetScripts(new string[] { }), 1);
			v.Play += new EventHandler<SscatLaneEventArgs>(ViewPlay);
			v.Stop += new EventHandler(ViewStop);
			v.Stopping += new EventHandler(ViewStopping);
		}
		
		[OneTimeTearDown]
		public void Teardown()
		{
			v.Play -= new EventHandler<SscatLaneEventArgs>(ViewPlay);
			v.Stop -= new EventHandler(ViewStop);
			v.Stopping -= new EventHandler(ViewStopping);
		}
		
		[Test]
		public void TestEmptyConstructor()
		{
			v = new ConsolePlayerView();
		}
		
		[Test]
		public void TestClearResults()
		{
			v.ClearResults();
		}
		
		[Test]
		public void TestPlaying()
		{
			v.PerformPlaying();
		}
		
		[Test]
		public void TestInitializeCache()
		{
			v.InitiateCache(new ScriptEventArgs(new ScriptFile(@"")));
		}
		
		[Test]
		public void TestShow()
		{
			v.ShowView();
		}
		
		[Test]
		public void TestStopping()
		{
			v.PerformStopping();
		}
		
		[Test]
		public void TestStop()
		{
			v.PerformStop();
		}
		
		[Test]
		public void TestSelectScript()
		{
			Assert.That(() => v.SelectScript(new ScriptFile(@"")), Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestAddScript()
		{
			v.AddScript(new List<string>(new string[] { @"C:\Projects\finger\trunk\test\test.xml" }));
		}
		
		[Test]
		public void TestUpdateScriptResult()
		{
			v.UpdateScriptResult(new Script());
		}
		
		[Test]
		public void TestUpdateScriptEventResult()
		{
			v.UpdateEventResult(new ScriptEvent());
		}
		
		[Test]
		public void TestPlay()
		{
			v.PerformPlay();
		}

		void ViewStopping(object sender, EventArgs e)
		{
		}

		void ViewStop(object sender, EventArgs e)
		{
		}

		void ViewPlay(object sender, SscatLaneEventArgs e)
		{
		}
	}
}
