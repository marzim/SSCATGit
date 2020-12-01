//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ncr.Core.Emulators;
using Ncr.Core.PInvoke;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ApiManagerTests
	{
		Form1 f;
		string className;
		string caption;
		ApiManager m;
		IntPtr handle;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			m = new ApiManager();
			className = "WindowsForms10.Window.8.app.0.bf7771";
			caption = "Form1";
			f = new Form1();
			f.Show();
			
			handle = m.FindWindow(className, caption);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			f.Close();
		}
		
		[Test]
		public void TestSendDlgItemMessage()
		{
			m.SendDlgItemMessage(handle, 0, 0, 0, new StringBuilder());
		}
		
		[Test]
		public void TestSetSystemTime()
		{
			// FIXME: Temporary removed this test because it changes date and time of the system and will cause problem in our CI build server.
			// m.SetSystemTime(DateTime.Now);
		}
		
		[Test]
		public void TestGetDlgItem()
		{
			m.GetDlgItem(handle, 1);
		}
		
		[Test]
		public void TestKeyboardEvent()
		{
			Assert.IsNotNull(handle);
			m.KeyboardEvent(User32.VK_RETURN, 0x45, 0x1, 0);
		}
		
		[Test]
		public void TestCaptureImageWindow()
		{
			m.CaptureImageWindow(handle);
		}
		
		[Test]
		public void TestCaptureImageDesktop()
		{
			m.CaptureImageDesktop();
		}
		
		[Test]
		public void TestSendMessage()
		{
			m.SendMessage(handle, 1, 1, 1);
			m.SendMessage(handle, 1, IntPtr.Zero, IntPtr.Zero);
			m.SendMessage(handle, 1, 1, new StringBuilder());
			m.SendMessage(handle, 1, 1, "");
		}
		
		[Test]
		public void TestIsWindowVisible()
		{
			m.IsWindowVisible(handle);
		}
		
		[Test]
		public void TestGetWindowText()
		{
			m.GetWindowText(handle, new StringBuilder(), 1);
		}
		
		[Test]
		public void TestSendWait()
		{
			m.SendWait("");
		}
		
		[Test]
		public void TestIsWindowEnabled()
		{
			m.IsWindowEnabled(handle);
		}
		
		[Test]
		public void TestChiledWindowFromPoint()
		{
			m.ChiledWindowFromPoint(handle, new Point(0, 0));
		}
		
		[Test]
		public void TestSetForegroundWindow()
		{
			m.SetForegroundWindow(handle);
		}
		
		[Test]
		public void TestShowWindow()
		{
			m.ShowWindow(handle, 1);
		}
		
		[Test]
		public void TestFindWindowEx()
		{
			m.FindWindowEx(handle, 1, className, caption);
		}
	}
}
