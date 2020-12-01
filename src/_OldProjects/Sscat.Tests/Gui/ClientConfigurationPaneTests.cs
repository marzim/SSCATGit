//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Gui;
using Sscat.Tests.Config;
using Sscat.Tests.Repositories;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ClientConfigurationPaneTests
	{
		ClientConfigurationPane p;

        [OneTimeSetUp]
        public void OneTimeSetUp()
		{
			p = new ClientConfigurationPane();
			p.Configuration = new ClientConfigurationRepositoryStub().Read("");
			p.ConfigurationSave += new EventHandler<ClientConfigurationEventArgs>(ViewConfigurationSave);
			p.ConfigurationDefaultRestore += new EventHandler(ViewConfigurationDefaultRestore);
			p.ConfigurationChanged += new EventHandler<ClientConfigurationEventArgs>(ViewConfigurationChanged);
		}
		
		[TearDown]
		public void Teardown()
		{
			p.ConfigurationSave -= new EventHandler<ClientConfigurationEventArgs>(ViewConfigurationSave);
			p.ConfigurationDefaultRestore -= new EventHandler(ViewConfigurationDefaultRestore);
			p.ConfigurationChanged -= new EventHandler<ClientConfigurationEventArgs>(ViewConfigurationChanged);
		}
		
		[Test]
		public void TestConfigurationValue()
		{
			Assert.IsNotNull(p.Configuration);
		}

        [Test]
        public void TestSelectedConfigFileValue()
        {
            Assert.IsNull(p.SelectedConfigFile);
        }
		
        [Test]
        public void TestSelectedConfigFilesCountValue()
        {
            Assert.AreEqual(0, p.SelectedConfigFiles.Count);
        }

		[Test]
		public void TestSave()
		{
			p.Save();
		}
		
		[Test]
		public void TestRestore()
		{
			p.Restore();
		}
		
		void ViewConfigurationChanged(object sender, ClientConfigurationEventArgs e)
		{
		}

		void ViewConfigurationDefaultRestore(object sender, EventArgs e)
		{
		}

		void ViewConfigurationSave(object sender, ClientConfigurationEventArgs e)
		{
		}
	}
}
