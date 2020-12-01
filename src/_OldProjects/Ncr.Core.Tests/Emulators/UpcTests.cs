//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="ac185120@ncr.com"/>
//	</file>

using System;
using Microsoft.Win32;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class UpcTests
	{
		Upc u;
		
//		[OneTimeSetUp]
//		public void OneTimeSetUp()
//		{
//			u = Upc.Decode("F4800011186924~4800011186924~104");
//		}
		
		[Test]
		public void TestCode128()
		{
			u = Upc.Decode("B3156515155688~156515155688~110~0");
			Assert.AreEqual("156515155688", u.GetTrimmedTag());
			Assert.AreEqual("Code 128", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
		}
		
		[Test]
		public void TestCode39()
		{
			// code = 108
			u = Upc.Decode("B1SCOT/23+873J$284-99/UNDER%13-201~SCOT/23+873J$284-99/UNDER%13-201~108~0");
			Assert.AreEqual("SCOT/23+873J$284-99/UNDER%13-201", u.GetTrimmedTag());
			Assert.AreEqual("Code 39", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
			
			// code = 109
			u = Upc.Decode("B1SCOT-123456789~SCOT-123456789~109~0");
			Assert.AreEqual("SCOT-123456789", u.GetTrimmedTag());
			Assert.AreEqual("Code 39", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
		}
						
		[Test]
		public void TestDatabarRSS()
		{
			u = Upc.Decode("0102001234567893~0102001234567893~131~0");
			Assert.AreEqual("0102001234567893", u.GetTrimmedTag());
			Assert.AreEqual("Databar/RSS", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
		}
		
		[Test]
		public void TestDatabarRSSExpanded()
		{
			u = Upc.Decode("0198898765432106320201234515991231~0198898765432106320201234515991231~132~0");
			Assert.AreEqual("0198898765432106320201234515991231", u.GetTrimmedTag());
			Assert.AreEqual("Databar/RSS Expanded", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
		}
		
		[Test]
		public void TestEAN13JAN13()
		{
			u = Upc.Decode("F9906711420254~9906711420254~104~0");
			Assert.AreEqual("990671142025", u.GetTrimmedTag());
			Assert.AreEqual("EAN-13/JAN-13", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
		}
		
		[Test]
		public void TestEAN13JAN13Supplement()
		{
			u = Upc.Decode("F123456789012112~123456789012112~119~0");
			Assert.AreEqual("123456789012+12", u.GetTrimmedTag());
			Assert.AreEqual("EAN-13/JAN-13 Supplement", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
		}
		
		[Test]
		public void TestEAN8JAN8()
		{
			u = Upc.Decode("FF20123451~20123451~103~0");
			Assert.AreEqual("2012345", u.GetTrimmedTag());
			Assert.AreEqual("EAN-8/JAN-8", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
		}
		
		[Test]
		public void TestUPCA()
		{
			u = Upc.Decode("A045566473318~045566473318~101~0");
			Assert.AreEqual("04556647331", u.GetTrimmedTag());
			Assert.AreEqual("UPC-A", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
		}
		
		[Test]
		public void TestUPCASupplement()
		{
			u = Upc.Decode("A07099300799760~07099300799760~111~0");
			Assert.AreEqual("07099300799+60", u.GetTrimmedTag());
			Assert.AreEqual("UPC-A Supplement", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
		}
		
		[Test]
		public void TestUPCE()
		{
			u = Upc.Decode("E0291032~0291032~102~0");
			Assert.AreEqual("0291032", u.GetTrimmedTag());
			Assert.AreEqual("UPC-E", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
		}
		
		[Test]
		public void TestUPCESupplement()
		{
			u = Upc.Decode("E034004155~034004155~112~0");
			Assert.AreEqual("0340041+55", u.GetTrimmedTag());
			Assert.AreEqual("UPC-E Supplement", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
		}
		
		[Test]
		public void TestCodeDefault()
		{
			u = Upc.Decode("E034004155860~034004155860~115~0");
			Assert.AreEqual("034004155860", u.GetTrimmedTag());
			Assert.AreEqual("Code 128", u.GetSymbology());
			Assert.IsNotEmpty(u.ToString());
		}
		
		[Test]
		public void TestItemName()
		{
			u = Upc.Decode("E034004155860~034004155860~115~0");
			RegistryHelper.Attach(new RegistryManagerStub(true, Registry.LocalMachine));
			Assert.AreEqual("CoolItem", u.ItemName);
		}
		
		[Test]
		public void TestItemNameInCADD()
		{
			u = Upc.Decode("E034004155860~034004155860~115~0");
//			RegistryHelper.Attach(new RegistryManagerStub(false, Registry.LocalMachine));
			RegistryHelper.Attach(new R());
			Assert.AreEqual("CoolItem", u.ItemName);
		}
		
		[Test]
		public void TestItemNameNotFound()
		{
			u = Upc.Decode("E034004155~034004155~112~0");
			RegistryHelper.Attach(new RegistryManagerStub(false, Registry.LocalMachine));
			Assert.AreEqual("SSCATTestItem", u.ItemName);
		}
		
		[Test]
		public void TestIsOperatorTrue()
		{
			Assert.AreEqual(true, Upc.IsOperator("F4120001345736~4120001345736~104~1"));
		}
		
		[Test]
		public void TestIsOperatorFalse()
		{
			Assert.AreEqual(false, Upc.IsOperator("F4120001345736~4120001345736~104~0"));
		}
		
		[Test]
		public void TestIsOperatorException()
		{
			Assert.AreEqual(false, Upc.IsOperator("F4120001345736"));
		}
//		[Test]
//		public void TestValues()
//		{
//			Assert.AreEqual("480001118692", u.GetTrimmedTag());
//			Assert.IsNotEmpty(u.ToString());
//		}
//		
//		[Test]
//		public void TestGetUPCASymbology()
//		{
//			u = Upc.Decode("A4800011186924~4800011186924~104");
//			Assert.AreEqual("UPC-A", u.GetSymbology());
//		}
//		
//		[Test]
//		public void TestGetCode128Symbology()
//		{
//			u = Upc.Decode("B4800011186924~4800011186924~104");
//			Assert.AreEqual("Code 128", u.GetSymbology());
//		}
//		
//		[Test]
//		public void TestGetUPCESymbology()
//		{
//			u = Upc.Decode("E4800011186924~4800011186924~104");
//			Assert.AreEqual("UPC-E", u.GetSymbology());
//		}
//		
//		[Test]
//		public void TestGetEAN13Symbology()
//		{
//			u = Upc.Decode("F4800011186924~4800011186924~104");
//			Assert.AreEqual("EAN-13/JAN-13", u.GetSymbology());
//		}
		
		class R : RegistryManagerStub
		{
			public override bool Exists(string key, RegistryKey subKey)
			{
				if (key.Contains("Emulator_Scanner")) {
					return true;
				} else {
					return false;
				}
			}
			
			public override string GetValue(string key, RegistryKey subKey)
			{
				return "CoolItem";
			}
		}
	}
}
