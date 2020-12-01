//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Views;

namespace Sscat.Tests.Views
{
	[TestFixture]
	public class ConsoleClientConfigurationViewTests
	{
		ConsoleClientConfigurationView v;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			v = new ConsoleClientConfigurationView();
			
			v.ConfigurationSave += new EventHandler<ClientConfigurationEventArgs>(ViewConfigurationSave);
			v.ConfigurationDefaultRestore += new EventHandler(ViewConfigurationDefaultRestore);
			v.ConfigurationChanged += new EventHandler<ClientConfigurationEventArgs>(ViewConfigurationChanged);

			v.Configuration = new ClientConfiguration();
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			v.ConfigurationSave -= new EventHandler<ClientConfigurationEventArgs>(ViewConfigurationSave);
			v.ConfigurationDefaultRestore -= new EventHandler(ViewConfigurationDefaultRestore);
			v.ConfigurationChanged -= new EventHandler<ClientConfigurationEventArgs>(ViewConfigurationChanged);
		}
		
		[Test]
		public void TestConfigurationValue()
		{
			Assert.IsNotNull(v.Configuration);
		}
		
		[Test]
		public void TestRestore()
		{
			v.Restore();
		}
		
		[Test]
		public void TestSave()
		{
			v.Save();
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
