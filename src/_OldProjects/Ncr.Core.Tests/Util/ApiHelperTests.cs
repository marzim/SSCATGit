//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class ApiHelperTests
	{
		[SetUp]
		public void Setup()
		{
			ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestSendMessageZeroPointerValue()
		{
			Assert.AreEqual(new IntPtr(666), ApiHelper.SendMessage(IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero));
		}

        [Test]
        public void TestSendMessageStringBuilderValue()
        {
            Assert.AreEqual(new IntPtr(666), ApiHelper.SendMessage(IntPtr.Zero, 0, 0, new StringBuilder()));
        }

        [Test]
        public void TestSendMessageIntValue()
        {
            Assert.AreEqual(new IntPtr(666), ApiHelper.SendMessage(IntPtr.Zero, 0, 0, 0));
        }

        [Test]
        public void TestSendMessageStringValue()
        {
            Assert.AreEqual(666, ApiHelper.SendMessage(IntPtr.Zero, 0, 0, ""));
        }

        [Test]
        public void TestSetForegroundWindowValue()
        {
			ApiHelper.KeyboardEvent(0, 0, 0, 0);
            Assert.IsTrue(ApiHelper.SetForegroundWindow(IntPtr.Zero));
        }

        [Test]
        public void TestIsWindowEnabledValue()
        {
            Assert.AreEqual(666, ApiHelper.IsWindowEnabled(IntPtr.Zero));
        }

        [Test]
        public void TestIsWindowVisibleValue()
        {
            Assert.AreEqual(666, ApiHelper.IsWindowVisible(IntPtr.Zero));
        }

        [Test]
        public void TestFindWindowValue()
        {
            Assert.AreEqual(new IntPtr(666), ApiHelper.FindWindow("", ""));
        }

        [Test]
        public void TestGetDlgItemValue()
        {
            Assert.AreEqual(new IntPtr(666), ApiHelper.GetDlgItem(IntPtr.Zero, 0));
        }

        [Test]
        public void TestShowWindowValue()
        {
            Assert.IsTrue(ApiHelper.ShowWindow(IntPtr.Zero, 0));
        }

        [Test]
        public void TestFindWindowExValue()
        {
            Assert.AreEqual(new IntPtr(666), ApiHelper.FindWindowEx(IntPtr.Zero, 0, "", ""));
        }
		
		[Test]
		public void TestGetWindowText()
		{
			ApiHelper.GetWindowText(new IntPtr(666), new StringBuilder(), 666);
		}
		
		[Test]
		public void TestGetWindowTextOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => ApiHelper.GetWindowText(new IntPtr(666), new StringBuilder(), 666),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestChiledWindowFromPoint()
		{
			ApiHelper.ChiledWindowFromPoint(new IntPtr(666), new Point(0, 0));
		}
		
		[Test]
		public void TestChiledWindowFromPointOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => ApiHelper.ChiledWindowFromPoint(new IntPtr(666), new Point(0, 0)),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestSendWait()
		{
			ApiHelper.SendWait("");
		}
		
		[Test]
		public void TestSendWaitOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => ApiHelper.SendWait(""),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestCaptureImageWindow()
		{
			ApiHelper.CaptureImageWindow(new IntPtr(666));
		}
		
		[Test]
		public void TestCaptureImageWindowOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => ApiHelper.CaptureImageWindow(new IntPtr(666)),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestCaptureImageDesktop()
		{
			ApiHelper.CaptureImageDesktop();
		}
		
		[Test]
		public void TestCaptureImageDesktopOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => ApiHelper.CaptureImageDesktop(),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestSendMessage4OnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => Assert.AreEqual(666, ApiHelper.SendMessage(IntPtr.Zero, 0, 0, "")),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestSendDlgItemMessage()
		{
			ApiHelper.SendDlgItemMessage(IntPtr.Zero, 0, 0, 0, new StringBuilder());
		}
		
		[Test]
		public void TestSendDlgItemMessageOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => ApiHelper.SendDlgItemMessage(IntPtr.Zero, 0, 0, 0, new StringBuilder()),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestSendMessage3OnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => Assert.AreEqual(new IntPtr(666), ApiHelper.SendMessage(IntPtr.Zero, 0, 0, 0)),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestSendMessage2OnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => Assert.AreEqual(new IntPtr(666), ApiHelper.SendMessage(IntPtr.Zero, 0, 0, new StringBuilder())),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestSendMessage1OnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => Assert.AreEqual(new IntPtr(666), ApiHelper.SendMessage(IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero)),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestFindWindowExOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => Assert.AreEqual(new IntPtr(666), ApiHelper.FindWindowEx(IntPtr.Zero, 0, "", "")),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestShowWindowOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => Assert.IsTrue(ApiHelper.ShowWindow(IntPtr.Zero, 0)),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestGetDlgItemOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => Assert.AreEqual(new IntPtr(666), ApiHelper.GetDlgItem(IntPtr.Zero, 0)),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestFindWindowOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => Assert.AreEqual(new IntPtr(666), ApiHelper.FindWindow("", "")),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestIsWindowVisibleOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => Assert.AreEqual(666, ApiHelper.IsWindowVisible(IntPtr.Zero)),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void Testkeybd_eventOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => ApiHelper.KeyboardEvent(0, 0, 0, 0),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestSetForegroundWindowonNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => Assert.IsTrue(ApiHelper.SetForegroundWindow(IntPtr.Zero)),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestIsWindowEnabledOnNullManager()
		{
			ApiHelper.Attach(null);
            Assert.That(() => Assert.AreEqual(666, ApiHelper.IsWindowEnabled(IntPtr.Zero)),
                Throws.TypeOf<ArgumentNullException>());
		}
	}
}
