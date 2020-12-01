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
	public class RegistryHelperTests
	{
		[SetUp]
		public void Setup()
		{
			RegistryHelper.Attach(new RegistryManagerStub());
		}
		
		[Test]
		public void TestExistsOnNullManager()
		{
			RegistryHelper.Attach(null);
            Assert.That(() => Assert.IsTrue(RegistryHelper.Exists("Configure", Registry.LocalMachine)),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestOpenSubKey()
		{
			Assert.IsNull(RegistryHelper.OpenSubKey(Registry.LocalMachine, "Configure"));
		}
		
		[Test]
		public void TestOpenSubKeyOnNullManager()
		{
			RegistryHelper.Attach(null);
            Assert.That(() => Assert.IsNull(RegistryHelper.OpenSubKey(Registry.LocalMachine, "Configure")),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestExists()
		{
			Assert.IsTrue(RegistryHelper.Exists("Configure", Registry.LocalMachine));
		}
		
		[Test]
		public void TestGetValueOnNullManager()
		{
			RegistryHelper.Attach(null);
            Assert.That(() => Assert.AreEqual("unicode", RegistryHelper.GetValue("Configure", Registry.LocalMachine)),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestGetValue()
		{
			Assert.AreEqual("unicode", RegistryHelper.GetValue("Configure", Registry.LocalMachine));
		}
		
		[Test]
		public void TesetGetValueWithDefaultOnNullManager()
		{
			RegistryHelper.Attach(null);
            Assert.That(() => Assert.AreEqual("world", RegistryHelper.GetValue("hello", null, "world")),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TesetGetValueWithDefault()
		{
			Assert.AreEqual("world", RegistryHelper.GetValue("hello", null, "world"));
			Assert.AreEqual("hello", RegistryHelper.GetValue("hello", Registry.LocalMachine, "world"));
		}
		
		[Test]
		public void TesetGetValueWithDefaultAndDisregardCommentsOnNullManager()
		{
			RegistryHelper.Attach(null);
            Assert.That(() => Assert.AreEqual("world", RegistryHelper.GetValue("hello", null, "world", true)),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TesetGetValueWithDefaultAndDisregardComments()
		{
			Assert.AreEqual("world", RegistryHelper.GetValue("hello", null, "world", true));
			Assert.AreEqual("hello", RegistryHelper.GetValue("hello", Registry.LocalMachine, "world", true));
		}
		
		[Test]
		public void TestSetStringValueOnNullManager()
		{
			RegistryHelper.Attach(null);
            Assert.That(() => RegistryHelper.SetStringValue("", "", ""),
               Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestSetStringValue()
		{
			RegistryHelper.SetStringValue("", "", "");
		}
		
		[Test]
		public void TestSetStringValueOverwrite()
		{
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"sscattemp", true);
			RegistryHelper.SetStringValue("test", "test", "testvalue", true);
		}
		
		[Test]
		public void TestSetStringValueOverwriteOnNullManager()
		{
			RegistryHelper.Attach(null);
			RegistryKey key = Registry.CurrentUser.OpenSubKey(@"sscattemp", true);			;
            Assert.That(() => RegistryHelper.SetStringValue("test", "test", "testvalue", true),
                Throws.TypeOf<ArgumentNullException>());
		}

		[Test]
		public void TestDeleteSubKey()
		{
			RegistryHelper.DeleteSubKey("");
		}
		
		[Test]
		public void TestDeleteSubKeyOnNullManager()
		{
			RegistryHelper.Attach(null);
            Assert.That(() => RegistryHelper.DeleteSubKey(""),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestGetSubKeyNamesArray()
		{
			string[] billSubKeyNames = null;
			billSubKeyNames = RegistryHelper.GetSubKeyNames(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorBill");
			Assert.AreEqual("Coin2,Bill2", string.Join(",", billSubKeyNames));
		}
		
		[Test]
		public void TestGetSubKeyNamesArrayOnNullManager()
		{
			RegistryHelper.Attach(null);
			string[] billSubKeyNames = null;
            Assert.That(() => billSubKeyNames = RegistryHelper.GetSubKeyNames(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorBill"),
                Throws.TypeOf<ArgumentNullException>());
		}
		
		[Test]
		public void TestGetSubKeyNamesList()
		{
			List<string> billSubKeyNames = null;
			billSubKeyNames = RegistryHelper.GetSubKeyNames(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorBill", "Bill");
			Assert.AreEqual("Coin1,Bill1", string.Join(",", billSubKeyNames.ToArray()));
		}
		
		[Test]
		public void TestGetSubKeyNamesListOnNullManager()
		{
			RegistryHelper.Attach(null);
			List<string> billSubKeyNames = null;
            Assert.That(() => billSubKeyNames = RegistryHelper.GetSubKeyNames(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorBill", "Bill"),
                Throws.TypeOf<ArgumentNullException>());
		}
	}
}
