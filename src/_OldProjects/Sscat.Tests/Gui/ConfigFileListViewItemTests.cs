//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ConfigFileListViewItemTests
	{
		ConfigFileListViewItem view;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			view = new ConfigFileListViewItem(ConfigFile.Deserialize(new StringReader(@"<File Name='Scotopts.dat' Host='test'/>")));
		}
		
		[Test]
		public void TestFile()
		{
			Assert.IsNotNull(view.File);
		}
	}
}
