//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using System.IO;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Finger;
using Sscat.Core.Gui;
using Sscat.Core.Models;
using Sscat.Core.Util;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class CardEventEditorTests
	{
		CardEventEditor objCardEventEditorForm1;
		CardEventEditor objCardEventEditorForm2;
		CardEventEditor objCardEventEditorForm3;
		List<IScriptEvent> eventsWithMSR;
		List<IScriptEvent> eventsWithoutMSR;
		List<IScriptEvent> eventsWithoutDeviceEvents;
		List<IScript> scriptsWithMSR;
		List<IScript> scriptsWithoutMSR;
		List<IScript> scriptsWithoutDeviceEvent;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			MessageService.Attach(new ConsoleMessageProvider());
			
			objCardEventEditorForm1 = new CardEventEditor();
			objCardEventEditorForm2 = new CardEventEditor("You are dreaming! Get out of here!");
			objCardEventEditorForm3 = new CardEventEditor("You are dreaming! Get out of here!", true);
			
			eventsWithMSR = new List<IScriptEvent>();
			eventsWithMSR.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerPsxEvent()));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerPsxEvent()));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerDeviceEvent(Constants.DeviceType.MSR, "WalmartMCXCard")));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerPsxEvent("ThankYou", "Display", "ChangeContext", "", "")));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerDeviceEvent("MSR", "Default")));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerPsxEvent("ScanAndBag", "Display", "ChangeContext", "", "")));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerDeviceEvent("MSR", "Walmart")));			
			eventsWithMSR.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerPsxEvent("ThankYou", "Display", "ChangeContext", "", "")));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			eventsWithMSR.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			
			eventsWithoutMSR = new List<IScriptEvent>();
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerPsxEvent()));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerPsxEvent()));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerPsxEvent()));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerPsxEvent("ThankYou", "Display", "ChangeContext", "", "")));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerDeviceEvent("MSR", "Default")));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerPsxEvent("ScanAndBag", "Display", "ChangeContext", "", "")));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerDeviceEvent("MSR", "Walmart")));			
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerPsxEvent("ThankYou", "Display", "ChangeContext", "", "")));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerDeviceEvent()));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			eventsWithoutMSR.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));

			eventsWithoutDeviceEvents = new List<IScriptEvent>();
			eventsWithoutDeviceEvents.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			eventsWithoutDeviceEvents.Add(new FingerScriptEvent(new FingerPsxEvent()));
			eventsWithoutDeviceEvents.Add(new FingerScriptEvent(new FingerPsxEvent()));
			eventsWithoutDeviceEvents.Add(new FingerScriptEvent(new FingerPsxEvent("ThankYou", "Display", "ChangeContext", "", "")));
			eventsWithoutDeviceEvents.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			eventsWithoutDeviceEvents.Add(new FingerScriptEvent(new FingerPsxEvent("ScanAndBag", "Display", "ChangeContext", "", "")));
			eventsWithoutDeviceEvents.Add(new FingerScriptEvent(new FingerPsxEvent("ThankYou", "Display", "ChangeContext", "", "")));
			eventsWithoutDeviceEvents.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			eventsWithoutDeviceEvents.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			eventsWithoutDeviceEvents.Add(new FingerScriptEvent(new FingerPsxEvent("Attract", "Display", "ChangeContext", "", "")));
			
			scriptsWithMSR = FingerScript.CreateScripts("test", "", @"C:\Projects\finger\trunk\tests", "3.4", "3.1", "default", eventsWithMSR, true, false, 0);
			scriptsWithoutMSR = FingerScript.CreateScripts("test", "", @"C:\Projects\finger\trunk\tests", "3.4", "3.1", "default", eventsWithoutMSR, true, false, 0);
			scriptsWithoutDeviceEvent = FingerScript.CreateScripts("test", "", @"C:\Projects\finger\trunk\tests", "3.4", "3.1", "defaults", eventsWithoutDeviceEvents, false, false, 0);
		}
		
		[Test]
		public void TestTriggeringAnExceptionDuringAddingOfLaneConfig() {
			try {
				LaneConfiguration conf = new LaneConfiguration();
				objCardEventEditorForm1.AddConfig(conf);
			} catch (Exception ex) {
				//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
				Assert.IsInstanceOf(ex.GetType(), ex, "CardEventEditorTests->TestTriggeringAnExceptionDuringAddingOfLaneConfig - method successfully threw an exception for improper Config parameter!");
			}
		}
		
		[Test]
		public void TestTriggeringAnExceptionDuringAddingOfClientConfig() {
			try{
				ClientConfiguration conf = new ClientConfiguration();
				objCardEventEditorForm1.AddConfig(conf);
			} catch (Exception ex) {
				//Deprecated in NUnit 3: changed from Assert.IsInstanceOfType to Assert.IsInstanceOf
				Assert.IsInstanceOf(ex.GetType(), ex, "CardEventEditorTests->TestTriggeringAnExceptionDuringAddingOfClientConfig - method successfully threw an exception for improper Config parameter!");
			}
		}
		
		[Test]
		public void TestSuccessfulAddingOfScriptsToScriptListView()
		{	
			List<IScript> scripts = FingerScript.CreateScripts("test", "", @"C:\Projects\finger\trunk\tests", "3.4", "3.1", "default", eventsWithMSR, true, false, 0);
			objCardEventEditorForm1.AddScriptsToScriptListView(scripts);
		}
		
		[Test]
		public void TestAddingOfNullScriptsToScriptListView()
		{	try {
				List<IScript> scripts = null;
				objCardEventEditorForm1.AddScriptsToScriptListView(scripts);
			} catch {
				// do nothing, this is just to test if an exception will be raised when passing a null list
			}
		}
		
		[Test]
		public void TestSuccessfulAddingOfScriptsUsingValidFilenames()
		{
			string[] filenames = {@"C:\Projects\Finger\trunk\scripts\test_0.xml", @"C:\Projects\Finger\trunk\scripts\test_1.xml" };
			objCardEventEditorForm1.AddScriptsToScriptListView(filenames);
		}
		
		[Test]
		public void TestAddingOfScriptsUsingAnEmptyListOfFilenames()
		{
			string[] filenames = { };
			objCardEventEditorForm1.AddScriptsToScriptListView(filenames);
		}

		[Test]
		public void TestSuccessfulIdentificationThatAScriptHasMSCard()
		{
//			Assert.IsTrue(CardEventEditor.ContainsMSCard(scriptsWithMSR.ToArray()[0]), "CardEventEditorTests->TestSuccessfulIdentificationThatAScriptHasMSCard - PASSED!");
			string[] filenames = {@"C:\Projects\Finger\trunk\scripts\SmokeTesting\SmokeTest1_0.xml", @"C:\Projects\Finger\trunk\scripts\SmokeTesting\SmokeTest1_1.xml" };
			Assert.IsTrue(CardEventEditor.ContainsMSCard(filenames), "CardEventEditorTests->TestSuccessfulIdentificationThatAScriptHasMSCard - PASSED!");
		}
		
		[Test]
		public void TestSuccessfulIdentificationThatANullScriptHasNoMSCard()
		{
			IScript script = null;
			Assert.IsFalse(CardEventEditor.ContainsMSCard(script), "CardEventEditorTests->TestSuccessfulIdentificationThatANullScriptHasNoMSCard - PASSED!");
		}

		[Test]
		public void TestSuccessfulIdentificationThatAScriptWithNoDeviceEventHasNoMSCard()
		{
			Assert.IsFalse(CardEventEditor.ContainsMSCard(scriptsWithoutDeviceEvent.ToArray()[0]), "CardEventEditorTests->TestSuccessfulIdentificationThatAScriptWithNoDeviceEventHasNoMSCard - PASSED!");
		}

		public void TestSuccessfulIdentificationThatEmptyListOfScriptsHasNoMSCard()
		{
			IScript[] scripts = null;
			Assert.IsFalse(CardEventEditor.ContainsMSCard(scripts), "CardEventEditorTests->TestSuccessfulIdentificationThatAScriptHasMSCard - PASSED!");
		}

		[Test]
		public void TestSuccessfulIdentificationThatListOfScriptsHasMSCardsUsingFilenames()
		{
			string[] filenames = {@"C:\Projects\Finger\trunk\scripts\test_0.xml", @"C:\Projects\Finger\trunk\scripts\test_1.xml" };
			Assert.IsFalse(CardEventEditor.ContainsMSCard(filenames), "CardEventEditorTests->TestSuccessfulAddingOfScriptsUsingFilenames - PASSED!");
		}

		[Test]
		public void TestSuccessfulIdentificationThatListOfScriptsHasNoMSCardsUsingEmptyListOfFilenames()
		{
			string[] filenames = new string[] { };
			Assert.IsFalse(CardEventEditor.ContainsMSCard(filenames), "CardEventEditorTests->TestSuccessfulIdentificationThatListOfScriptsHasNoMSCardsUsingEmptyListOfFilenames - PASSED!");
		}

		[Test]
		public void TestSuccessfulIdentificationOfScriptHavingMSCardsUsingFilename()
		{
			string[] filenames = {@"C:\Projects\Finger\trunk\scripts\test_0.xml", @"C:\Projects\Finger\trunk\scripts\test_1.xml" };
			Assert.IsFalse(CardEventEditor.ContainsMSCard(filenames), "CardEventEditorTests->TestSuccessfulIdentificationOfScriptHavingMSCardsUsingFilename - PASSED!");
		}

		[Test]
		public void TestSuccessfulIdentificationOfScriptHavingNoMSCardsDueToInvalidFilename()
		{
			string filename = string.Empty;
			Assert.IsFalse(CardEventEditor.ContainsMSCard(filename), "CardEventEditorTests->TestSuccessfulIdentificationOfScriptHavingMSCardsUsingFilename - PASSED!");
		}
		
		[Test]
		public void TestSuccessfulIdentificationOfScriptHavingNoMSCardsUsingFilename()
		{
			string[] filenames = {@"C:\Projects\Finger\trunk\scripts\test_0.xml", @"C:\Projects\Finger\trunk\scripts\test_1.xml" };
			Assert.IsFalse(CardEventEditor.ContainsMSCard(filenames), "CardEventEditorTests->TestSuccessfulIdentificationOfScriptHavingNoMSCardsUsingFilename - PASSED!");
		}
	}
}