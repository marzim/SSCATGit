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
	public class RegistryManagerStub : IRegistryManager
	{
		bool exists;
		RegistryKey subKey;
		
		public RegistryManagerStub() : this(true, null)
		{
		}
		
		public RegistryManagerStub(bool exists, RegistryKey subKey)
		{
			this.exists = exists;
			this.subKey = subKey;
		}
		
		public virtual bool Exists(string key, RegistryKey subKey)
		{
			return exists;
		}
		
//		public string GetValue(string key, RegistryKey subKey)
		public virtual string GetValue(string key, RegistryKey subKey)
		{
			switch (key) {
				case "Configure":
					return "unicode";
				case "ApplicationType":
					return "unicode";
				case "ComponentVersion":
					return "4.5";
				case "Release Version":
					return "4.5";
				case "Units":
					return "4 -> SCAL_WU_GRAM = 1, SCAL_WU_KILOGRAM = 2,  SCAL_WU_OUNCE = 3, SCAL_WU_POUND = 4";
				case "TerminalNumber":
					return "001";
				case "DispenserCounts":
					return "1:0,5:0,10:0,25:0;100:100,500:200,1000:50,2000:10";
				case "CountryCode":
					return "USD";
				case "PackageVersion":
					return "2.03.00.41";
				case "034004155860": // UPC tests ItemName
					return "CoolItem";
				case "480001118692": // ScannerTests
					return "VeryCoolItem";
				case "81109482911323343423434231234567": // ScannerTests
					return "NotSoCoolItem";
				default:
					throw new NotSupportedException();
			}
		}
		
		public string GetValue(string key, RegistryKey subKey, string defaultValue)
		{
			return subKey == null ? defaultValue : key;
		}
		
		public string GetValue(string key, RegistryKey subKey, string defaultValue, bool disregardComments)
		{
			return subKey == null ? defaultValue : key; //TODO: This is not correct
		}
		
		public void SetStringValue(string keyName, string keyValueName, string keyValueData)
		{			
		}
		
		public void SetStringValue(string keyName, string keyValueName, string keyValueData, bool overwrite)
		{			
		}

		public void DeleteSubKey(string subKey)
		{
		}
		
		public string[] GetSubKeyNames(string key)
		{
			string[] subKeyNames = new string[] {"Coin2", "Bill2" };
			return subKeyNames;
		}
		
		public List<string> GetSubKeyNames(string key, string subKeyNameContains)
		{
			List<string> subKeyNames = new List<string>();
			subKeyNames.Add("Coin1");
			subKeyNames.Add("Bill1");
			return subKeyNames;
		}
		
		public RegistryKey OpenSubKey(RegistryKey key, string name)
		{
			return subKey;
		}
	}
}
