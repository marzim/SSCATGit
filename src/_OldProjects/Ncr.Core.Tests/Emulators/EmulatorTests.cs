//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Drawing;
using Microsoft.Win32;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NMock;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class EmulatorTests
	{
		EmulatorStub e;
		RegistryManager m;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			m = new RegistryManager();
			e = new EmulatorStub();
			
			ApiHelper.Attach(new ApiManagerStub());
			e.Emulating += new EventHandler<EmulatorEventArgs>(EmulatorEmulating);
		}
		
		[OneTimeTearDown]
        public void OneTimeTearDown()
		{
			e.Emulating -= new EventHandler<EmulatorEventArgs>(EmulatorEmulating);
		}
		
		[Test]
		public void TestCompareOnEmulatorItemNotFound()
		{
            Assert.That(() => e.Compare(),
              Throws.TypeOf<EmulatorItemNotFoundException>());
		}
		
		[Test]
		public void TestCompare()
		{
			E x = new E();
			x.Compare();
		}
		
		[Test]
		public void TestCaptions()
		{
            Assert.AreEqual(string.Format(@"Scale\{0}", RegistryHelper.GetValue("CADD_BagScale", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\Scale"), "BagScaleEmulator")), Emulator.BagScaleCaption);
            Assert.AreEqual(string.Format(@"CashAcceptor\{0}", RegistryHelper.GetValue("CADD_CashAcceptor", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\CashAcceptor"), "Emulator")), Emulator.CashAcceptorCaption);
            Assert.AreEqual(string.Format(@"CoinAcceptor\{0}", RegistryHelper.GetValue("CADD_CoinAcceptor", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\CoinAcceptor"), "Emulator")), Emulator.CoinAcceptorCaption);
            Assert.AreEqual(string.Format(@"MotionSensor\{0}", RegistryHelper.GetValue("CADD_Coupon", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\MotionSensor"), "Emulator - Coupon")), Emulator.MotionSensorCaption);
            Assert.AreEqual(string.Format(@"MSR\{0}", RegistryHelper.GetValue("CADD_MSR", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\MSR"), "Emulator")), Emulator.MsrCaption);
            Assert.AreEqual(string.Format(@"{0}", RegistryHelper.GetValue("CADD_SignatureCapture", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\SignatureCapture"), "PC Signature Capture")), Emulator.PCSignatureCaptureCaption);
            Assert.AreEqual(string.Format(@"{0}", RegistryHelper.GetValue("CADD_PinPad", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\PINPad"), "Pinpad Emulator")), Emulator.PinPadCaption);
            Assert.AreEqual(string.Format(@"POSPrinter\{0}", RegistryHelper.GetValue("CADD_RecPrinter", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\POSPrinter"), "Emulator - Receipt")), Emulator.PosPrinterCaption);
            Assert.AreEqual(string.Format(@"Scale\{0}", RegistryHelper.GetValue("CADD_ProduceScale", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\Scale"), "Emulator")), Emulator.ScaleCaption);
            Assert.AreEqual(string.Format(@"Scanner\{0}", RegistryHelper.GetValue("CADD_Scanner", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\Scanner"), "Emulator")), Emulator.ScannerCaption);
		}
		
		[Test]
		public void TestAvailableValue()
		{
			Assert.IsTrue(e.Available());
		}

        [Test]
        public void TestTypeValue()
        {
            Assert.IsTrue(e.Available());
        }

        [Test]
        public void TestProcessNameValue()
        {
            Assert.AreEqual(e.Caption, e.ProcessName);
        }
		
		[Test]
		public void TestFileName()
		{
            Assert.That(() => Assert.AreEqual("", e.FileName),
                Throws.TypeOf<NotImplementedException>());
		}
		
		[Test]
		public void TestSetTextWithIntegerParameter()
		{
			e.Text = "";
		}
		
		[Test]
		public void TestSetTextWithIntegerParameterOnEmulatorTimeout()
		{
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Text = "",
              Throws.TypeOf<EmulatorTimeoutException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestSetTextWithIntegerParameterOnEmulatorItemNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Text = "",
              Throws.TypeOf<NullReferenceException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestSetTextWithIntegerParameterOnEmulatorNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.That(() => e.Text = "",
              Throws.TypeOf<EmulatorNotFoundException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestSetTextWithStringParameter()
		{
			e.Title = "";
		}
		
		[Test]
		public void TestSetTextWithStringParameterOnEmulatorTimeout()
		{
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Title = "",
              Throws.TypeOf<EmulatorTimeoutException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestSetTextWithStringParameterOnEmulatorItemNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Title = "",
              Throws.TypeOf<EmulatorItemNotFoundException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestSetTextWithStringParameterOnEmulatorNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.That(() => e.Title = "",
              Throws.TypeOf<EmulatorNotFoundException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestGetText()
		{
			Assert.AreEqual("", e.Text);
		}
		
		[Test]
		public void TestGetTextOnEmulatorTimeout()
		{
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), new IntPtr(666), IntPtr.Zero));
            Assert.That(() => Assert.AreEqual("", e.Text),
              Throws.TypeOf<EmulatorTimeoutException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestGetTextOnEmulatorNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.That(() => Assert.AreEqual("", e.Text),
               Throws.TypeOf<EmulatorNotFoundException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestGetTextOnEmulatorItemNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, new IntPtr(666), IntPtr.Zero));
            Assert.That(() => Assert.AreEqual("", e.Text),
               Throws.TypeOf<NullReferenceException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestClickButtonWithIntegerParameter()
		{
			e.Click(1);
		}
		
		[Test]
		public void TestClickButtonWithIntegerParameterOnEmulatorTimeout()
		{
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Click(1),
               Throws.TypeOf<EmulatorTimeoutException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestClickButtonWithIntegerParameterOnEmulatorItemNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Click(1),
               Throws.TypeOf<NullReferenceException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestClickButtonWithIntegerParameterOnEmulatorNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.That(() => e.Click(1),
                Throws.TypeOf<EmulatorNotFoundException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestClickButtonWithPointParameter()
		{
			e.ClickAt(new Point(0, 0));
		}
		
		[Test]
		public void TestCheckBox()
		{
			e.Check();
		}
		
		[Test]
		public void TestCheckBoxOnEmulatorTimeout()
		{
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Check(),
                Throws.TypeOf<EmulatorTimeoutException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestCheckBoxOnEmulatorItemNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Check(),
                Throws.TypeOf<EmulatorItemNotFoundException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestCheckBoxOnEmulatorNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.That(() => e.Check(),
                Throws.TypeOf<EmulatorNotFoundException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestClickButtonWithStringParameter()
		{
			e.Click("&Button");
		}
		
		[Test]
		public void TestClickButtonWithStringParameterOnEmulatorItemNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Click("&Button"),
                Throws.TypeOf<EmulatorItemNotFoundException>());
            ApiHelper.Attach(new ApiManagerStub());

		}
		
		[Test]
		public void TestClickButtonWithStringParameterOnEmulatorNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.That(() => e.Click("&Button"),
                Throws.TypeOf<EmulatorNotFoundException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestSelectIndex()
		{
			e.Select();
		}
		
		[Test]
		public void TestSelectIndexOnEmulatorItemNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Select(),
                Throws.TypeOf<NullReferenceException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestSelectIndexOnEmulatorNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.That(() => e.Select(),
                Throws.TypeOf<EmulatorNotFoundException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestSelectIndexOnEmulatorTimeout()
		{
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Select(),
                Throws.TypeOf<EmulatorTimeoutException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestSelectIndexWithStringParameter()
		{
			e.Select("");
		}
		
		[Test]
		public void TestSelectIndexWithStringParameterOnEmulatorItemNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Select(""),
                Throws.TypeOf<NullReferenceException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestSelectIndexWithStringParameterOnEmulatorNotFound()
		{
			ApiHelper.Attach(new ApiManagerStub(666, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            Assert.That(() => e.Select(""),
                Throws.TypeOf<EmulatorNotFoundException>());
            ApiHelper.Attach(new ApiManagerStub());
		}
		
		[Test]
		public void TestSelectIndexWithStringParameterOnEmulatorTimeout()
		{
			ApiHelper.Attach(new ApiManagerStub(0, new IntPtr(666), new IntPtr(666), IntPtr.Zero));
            Assert.That(() => e.Select(""),
                Throws.TypeOf<EmulatorTimeoutException>());
            ApiHelper.Attach(new ApiManagerStub());
		}

		void EmulatorEmulating(object sender, EmulatorEventArgs e)
		{
		}
		
		class E : EmulatorStub
		{
			protected override string GetText(int controlId, int timeout)
			{
				return "test";
			}
		}
	}
}
