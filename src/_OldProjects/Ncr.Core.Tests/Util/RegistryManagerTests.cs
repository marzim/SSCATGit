//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using Microsoft.Win32;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class RegistryManagerTests
	{
		RegistryManager m;

		[SetUp]
		public void Setup()
		{
			m = new RegistryManager();
		}
		
		[TearDown]
		public void Teardown()
		{
			if (m.Exists(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorCoin\TestCoin", Registry.LocalMachine)) {
				m.DeleteSubKey(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorCoin\TestCoin");
			}
		}
		
		[Test]
		public void TestExists()
		{
			Assert.IsFalse(m.Exists("Qwerty", Registry.LocalMachine));
		}
		
		[Test]
		public void TestGetValue()
		{
			Assert.IsNull(m.GetValue("Qwerty", Registry.LocalMachine));
		}
		
		[Test]
		public void TestOpenSubKey()
		{
			Assert.IsNull(m.OpenSubKey(Registry.LocalMachine, "Qwerty"));
		}
		
		[Test]
		public void TestGetValueWithDefault()
		{
			Assert.AreEqual("Tyuiop", m.GetValue("Qwerty", Registry.LocalMachine, "Tyuiop"));
		}
		
		[Test]
		public void TestGetValueWithOutComments()
		{
			// TODO: Value return will differ on different machine or setup
            //Assert.AreEqual("1000", m.GetValue("CashCount", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorCoin\Coin1"), "", true)); //For ADD 2.3.X version
            Assert.AreEqual("1000", m.GetValue("CashCount", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\Emulator_CoinDispenser\Coin1"), "", true)); //For CADD 3.3.X version
		}
		
		[Test]
		public void TestGetSubKeyNamesEmulatorrCoin()
		{
			List<string> coinSubKeyNames = null;
            //coinSubKeyNames = m.GetSubKeyNames(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorCoin", "Coin"); //For ADD 2.3.X version
            coinSubKeyNames = m.GetSubKeyNames(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\Emulator_CoinDispenser", "Coin"); //For CADD 3.3.X version
			coinSubKeyNames.Sort();
			Assert.AreEqual("Coin1,Coin2,Coin3,Coin4", string.Join(",", coinSubKeyNames.ToArray()));
		}

        [Test]
        public void TestGetSubKeyNamesEmulatorBill()
        {
            List<string> billSubKeyNames = null;
            //billSubKeyNames = m.GetSubKeyNames(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorBill", "Bill"); //For ADD 2.3.X version
            billSubKeyNames = m.GetSubKeyNames(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\Emulator_BillDispenser", "Bill"); //For CADD 3.3.X version
            billSubKeyNames.Sort();
            Assert.AreEqual("Bill1,Bill2,Bill3,Bill4,Bill5", string.Join(",", billSubKeyNames.ToArray()));
        }
		
		[Test]
		public void TestSetStringValue()
		{
			m.SetStringValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorCoin\TestCoin", "TestName", "TestValue");
			Assert.AreEqual("TestValue", m.GetValue("TestName", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorCoin\TestCoin")));
			
//			Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorCoin\TestCoin");
			m.DeleteSubKey(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorCoin\TestCoin");
		}
		
		[Test]
		public void TestSetStringValueOverwrite()
		{
            Assert.That(() => m.SetStringValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorCoin\TestCoin", "TestName", "TestValue", false),
                Throws.TypeOf<NullReferenceException>());
		}		
	}
}
