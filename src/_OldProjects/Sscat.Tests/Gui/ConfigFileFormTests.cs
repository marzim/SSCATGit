//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ConfigFileFormTests
	{
		ConfigFileForm f;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			f = new ConfigFileForm();
			f.ConfigSave += new EventHandler<ConfigFileEventArgs>(FormConfigSave);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			f.ConfigSave -= new EventHandler<ConfigFileEventArgs>(FormConfigSave);
		}
		
		[Test]
		public void TestSave()
		{
			f.Save();
		}

		void FormConfigSave(object sender, ConfigFileEventArgs e)
		{
		}
	}
}
