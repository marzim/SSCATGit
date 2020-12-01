//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Net;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Emulators;
using Sscat.Core.Models;
using Sscat.Core.Views;
using Sscat.Gui;
using Sscat.Tests.Config;
using Sscat.Tests.Net;
using Sscat.Tests.Repositories;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ClientPaneTests
	{
		ClientPane clientPane;
		GeneratorPane generatorPane;
		PlayerPane playerPane;
		ClientConfigurationPane configPane;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			generatorPane = new GeneratorPane();
			generatorPane.Configuration = new GeneratorConfiguration();
			
			playerPane = new PlayerPane();
			
			configPane = new ClientConfigurationPane();
			configPane.Configuration = new ClientConfigurationRepositoryStub().Read("");
			
			clientPane = new ClientPane(generatorPane, playerPane, configPane);
			clientPane.Client = new SscatClientStub(new XmlResponseParser(), new EasyClientEngine());
			
			clientPane.Generate += new EventHandler<GeneratorConfigurationEventArgs>(PaneGenerating);
			clientPane.Play += new EventHandler<SscatLaneEventArgs>(PanePlay);
			clientPane.ConfigurationRestore += new EventHandler(PaneConfigurationRestore);
			clientPane.ConfigurationSave += new EventHandler<ClientConfigurationEventArgs>(PaneConfigurationSave);
			clientPane.Stop += new EventHandler(ClientPaneStop);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			clientPane.Generate -= new EventHandler<GeneratorConfigurationEventArgs>(PaneGenerating);
			clientPane.Play -= new EventHandler<SscatLaneEventArgs>(PanePlay);
			clientPane.ConfigurationRestore -= new EventHandler(PaneConfigurationRestore);
			clientPane.ConfigurationSave -= new EventHandler<ClientConfigurationEventArgs>(PaneConfigurationSave);
			clientPane.Stop -= new EventHandler(ClientPaneStop);
		}
		
		[Test]
		public void TestConfigurationSave()
		{
			configPane.Save();
		}
		
//		[Test]
//		public void TestGeneratorGenerate()
//		{
//			generatorPane.PerformGenerate();
//		}		
		[Test]
		public void TestPlayerStop()
		{
			playerPane.StopPlayer();
		}
		
		[Test]
		public void TestPlayerPerformPlay()
		{
			playerPane.PerformPlay();
		}
		
		[Test]
		public void TestPlayerStopping()
		{
			playerPane.PerformStopping();
		}
		
		[Test]
		public void TestInitiateCache()
		{
//			clientPane.InitiateCache(new ScriptEventArgs(new ScriptFile(@"C:\Projects\finger\trunk\tests\script.xml")));
			clientPane.InitiateCache(new ScriptEventArgs(new ScriptFile(@"C:\Projects\Finger\trunk\scripts\test_0.xml")));
		}
		
		[Test]
		public void TestSelectScript()
		{
			clientPane.SelectScript(new ScriptFile(@"C:\Projects\Finger\trunk\scripts\test_0.xml"));
		}
		
		[Test]
		public void TestGenerate()
		{
            Assert.That(() => clientPane.PerformGenerate(), Throws.TypeOf<NullReferenceException>());
		}
		
		[Test]
		public void TestGenerating()
		{
			clientPane.PerformGenerating();
		}
		
		[Test]
		public void TestClientValue()
		{
			Assert.IsNotNull(clientPane.Client);
		}
		
		[Test]
		public void TestConfigPaneRestore()
		{
			configPane.Restore();
		}
		
		[Test]
		public void TestClearResults()
		{
			clientPane.ClearResults();
		}
		
		[Test]
		public void TestWriteLine()
		{
			clientPane.WriteLine("test...");
		}
		
		[Test]
		public void TestUpdateScriptResult()
		{
			Assert.That(() => clientPane.UpdateResult(new Script()), Throws.TypeOf<ArgumentOutOfRangeException>());
		}
		
		[Test]
		public void TestUpdateScriptEventResult()
		{
			Assert.That(() => clientPane.UpdateResult(new ScriptEvent()), Throws.TypeOf<ArgumentOutOfRangeException>());
		}
		
		[Test]
		public void TestUpdateViewOnConnectionTimeout()
		{
			ScriptFile s = new ScriptFile(@"C:\Projects\Finger\trunk\scripts\test_0.xml");
			playerPane.ScriptFiles.Add(s);
			Assert.That(() => clientPane.UpdateViewOnConnectionTimeout("ConnectionTimeoutError"), Throws.TypeOf<IndexOutOfRangeException>());
		}
		
		[Test]
		public void TestPerformPlaying()
		{
			clientPane.PerformPlaying();
		}
		
		[Test]
		public void TestStop()
		{
			clientPane.PerformStopping();
		}
		
		[Test]
		public void TestPerformDisable()
		{
			clientPane.PerformDisable();
		}
		
		[Test]
		public void TestCloseView()
		{
			clientPane.CloseView();
		}
		
		[Test]
		public void TestClearView()
		{
			clientPane.ClearView();
		}
		
		[Test]
		public void TestAddToPanel()
		{
			clientPane.AddToPanel(new GeneratorPane());
		}

		void ClientPaneStop(object sender, EventArgs e)
		{
		}

		void PaneConfigurationSave(object sender, ClientConfigurationEventArgs e)
		{
		}

		void PaneConfigurationRestore(object sender, EventArgs e)
		{
		}

		void PanePlay(object sender, SscatLaneEventArgs e)
		{
		}

		void PaneGenerating(object sender, GeneratorConfigurationEventArgs e)
		{
		}

		void PaneStopping(object sender, EventArgs e)
		{
		}

		void PanePlayerStopping(object sender, EventArgs e)
		{
		}
	}
}
