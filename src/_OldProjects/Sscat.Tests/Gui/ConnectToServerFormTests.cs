//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class ConnectToServerFormTests
	{
		ConnectToServerForm f;
		
		[OneTimeSetUp]
		public void Setup()
		{
			f = new ConnectToServerForm();
			f.Connecting += new EventHandler(FormConnecting);
			f.Stopping += new EventHandler(FormStopping);
		}
		
		[OneTimeTearDown]
		public void Teardown()
		{
			f.Connecting -= new EventHandler(FormConnecting);
			f.Stopping -= new EventHandler(FormStopping);
		}
		
		[Test]
		public void TestServerNameValue()
		{
            if (f.ServerName != "")
            {
                Assert.AreEqual("localhost", f.ServerName);
            }else{
                Assert.IsEmpty(f.ServerName);
            }
		}
		
		[Test]
		public void TestCloseView()
		{
			f.CloseView();
		}
		
		[Test]
		public void TestStop()
		{
			f.Stop();
		}
		
		[Test]
		public void TestConnect()
		{
			f.Connect();
		}
		
		[Test]
		public void TestConnectToLocalhost()
		{
			f.ConnectToLocalhost();
		}

		void FormStopping(object sender, EventArgs e)
		{
		}

		void FormConnecting(object sender, EventArgs e)
		{
		}
	}
}
