//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Windows.Forms;
using NUnit.Framework;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class WebBrowserPaneTests
	{
		WebBrowserPane p;
		
		[SetUp]
		public void Setup()
		{
			p = new WebBrowserPane();
			p.Navigating += new WebBrowserNavigatingEventHandler(PaneNavigating);
		}
		
		[TearDown]
		public void Teardown()
		{
			p.Navigating -= new WebBrowserNavigatingEventHandler(PaneNavigating);
		}
		
		[Test]
		[Ignore("Navigate triggers ActiveX error with TeamCity.")]
		public void TestNavigate()
		{
			p.Navigate("http://www.google.com");
		}

		void PaneNavigating(object sender, WebBrowserNavigatingEventArgs e)
		{
		}
	}
}
