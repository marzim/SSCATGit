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
	public class ConsoleGeneratorViewTests
	{
		ConsoleScriptGeneratorView v;
		
		[OneTimeSetUp]
		public void Setup()
		{
			v = new ConsoleScriptGeneratorView("test", "", "", true, @"C:\Projects\finger\trunk\tests", false, 0);
			v.Configuration = new GeneratorConfiguration();
			v.Generate += new EventHandler<GeneratorConfigurationEventArgs>(ViewGenerating);
			v.Stopping += new EventHandler(ViewStopping);
			v.Stop += new EventHandler(ViewStop);
		}
		
		[OneTimeTearDown]
		public void Teardown()
		{
			v.Generate -= new EventHandler<GeneratorConfigurationEventArgs>(ViewGenerating);
			v.Stopping -= new EventHandler(ViewStopping);
			v.Stop -= new EventHandler(ViewStop);
		}
		
		[Test]
		public void TestStopping()
		{
			v.PerformStopping();
		}
		
		[Test]
		public void TestConfigurationValue()
		{
			Assert.IsNotNull(v.Configuration);
		}
		
		[Test]
		public void TestShowView()
		{
			v.ShowView();
		}
		
		[Test]
		public void TestGenerate()
		{
			v.PerformGenerate();
		}
		
		[Test]
		public void TestStop()
		{
			v.PerformStop();
		}

		void ViewStop(object sender, EventArgs e)
		{
		}

		void ViewStopping(object sender, EventArgs e)
		{
		}

		void ViewGenerating(object sender, GeneratorConfigurationEventArgs e)
		{
		}
	}
}
