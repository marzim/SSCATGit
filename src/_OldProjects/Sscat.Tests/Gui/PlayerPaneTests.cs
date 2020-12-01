//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using Ncr.Core.Util;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class PlayerPaneTests
	{
		PlayerPaneTestModel p;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			MessageService.Attach(new ConsoleMessageProvider());
			
			p = new PlayerPaneTestModel();
			p.AddScript(new string[] { @"C:\Projects\finger\trunk\tests\script.xml" });

			p.Stopping += new EventHandler(PlayerPaneStopping);
			p.Stop += new EventHandler(PlayerPaneStop);
			p.Play += new EventHandler<SscatLaneEventArgs>(PlayerPanePlay);
			p.Disable += new EventHandler(PlayerPaneDisable);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			p.Stopping -= new EventHandler(PlayerPaneStopping);
			p.Stop -= new EventHandler(PlayerPaneStop);
			p.Play -= new EventHandler<SscatLaneEventArgs>(PlayerPanePlay);
			p.Disable -= new EventHandler(PlayerPaneDisable);
		}
		
		[Test]
		public void TestPerformStopping()
		{
			p.PerformStopping();
		}
		
		[Test]
		public void TestUpdateScriptResult()
		{
            try
            {
                p.UpdateScriptResult(new Script());
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.That(() => p.UpdateScriptResult(new Script()),
                    Throws.TypeOf<ArgumentOutOfRangeException>());
            }
            catch (NullReferenceException)
            {
                Assert.That(() => p.UpdateScriptResult(new Script()),
                    Throws.TypeOf<NullReferenceException>());
            }
		}
		
		[Test]
		public void TestClearResults()
		{
			p.ClearResults();
		}
		
		[Test]
		public void TestInitializeCache()
		{
//			p.InitiateCache(new ScriptEventArgs(new ScriptFile(@"C:\Projects\finger\trunk\tests\test.xml")));
			p.InitiateCache(new ScriptEventArgs(new ScriptFile(@"C:\Projects\Finger\trunk\scripts\test_0.xml")));
		}
		
		[Test]
		public void TestAddScript()
		{
			p.AddScript(new List<string>(new string[] { @"C:\Projects\finger\trunk\tests\test.xml" }));
		}
		
		[Test]
		public void TestRemoveSelectedScript()
		{
			p.RemoveSelectedScript();
		}
		
		[Test]
		public void TestRemoveAllScripts()
		{
			p.RemoveAllScripts();
		}
		
		[Test]
		public void TestUpdateScriptEventResult()
		{
            try
            {
                p.UpdateEventResult(new ScriptEvent());
            }catch(System.IndexOutOfRangeException){
                Assert.That(() => p.UpdateEventResult(new ScriptEvent()),
                    Throws.TypeOf<IndexOutOfRangeException>());
            }catch (System.ArgumentOutOfRangeException){
                Assert.That(() => p.UpdateEventResult(new ScriptEvent()),
                    Throws.TypeOf<ArgumentOutOfRangeException>());
            }

		}
		
		[Test]
		public void TestStopPlayer()
		{
			p.StopPlayer();
		}
		
		[Test]
		public void TestSelectScript()
		{
			p.SelectScript(new ScriptFile(@"C:\Projects\Finger\trunk\scripts\test_0.xml"));
		}
		
		[Test]
		public void TestScriptFiles()
		{
			Assert.IsNotNull(p.ScriptFiles);
		}
		
		[Test]
		public void TestPerformPlay()
		{
			p.PerformPlay();
		}
		
		[Test]
		public void TestPerformPlaying()
		{
			p.PerformPlaying();
		}
		
		[Test]
		public void TestPerformStop()
		{
			p.PerformStop();
		}
		
		[Test]
		public void TestPerformDisable()
		{
			p.PerformDisable();
		}
		
		[Test]
		public void TestClearView()
		{
			p.ClearView();
		}
		
		[Test]
		public void TestDisplayTestResultInvalidOperationException()
		{
			p.SetRepetitionIndex(1);
			p.DisplayTestResult();
		}
		
		[Test]
		public void TestDisplayTestResult()
		{
			p.SetRepetitionIndex(1);
			p.PlaybackRepetition = 1;			
			p.DisplayTestResult();
		}
		
		[Test]
		public void TestUpdateIncreaseButton()
		{
			p.SetRepetitionIndex(1);
			p.PlaybackRepetition = 5;				
			p.UpdateIncreaseButton();
		}
		
		[Test]
		public void TestUpdateDecreaseButton()
		{
			p.SetRepetitionIndex(2);
			p.PlaybackRepetition = 1;	
			p.UpdateDecreaseButton();
		}		
		
		[Test]
		public void TestUpdateViewOnConnectionTimeout()
		{
            try
            {
                p.UpdateViewOnConnectionTimeout("");
            }catch(Exception){
                Assert.That(() => p.UpdateViewOnConnectionTimeout(""),
                   Throws.TypeOf<IndexOutOfRangeException>());
            }
		}

		void PlayerPanePlay(object sender, SscatLaneEventArgs e)
		{
		}

		void PlayerPaneStop(object sender, EventArgs e)
		{
		}

		void PlayerPaneStopping(object sender, EventArgs e)
		{
		}
		
		void PlayerPaneDisable(object sender, EventArgs e)
		{
		}
	}
	
	public class PlayerPaneTestModel : PlayerPane
	{
		int repIndex;
		
		public void SetRepetitionIndex(int index)
		{
			repIndex = index;
		}
			
		public override int GetRepetitionIndex()
		{
			return repIndex;
		}
	}
}
