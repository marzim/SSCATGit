// <copyright file="CashValueList.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Tools.CashDenomination
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using Microsoft.Win32;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the CashValueList class
    /// </summary>
    public class CashValueList
    {
        /// <summary>
        /// SCOT opts coin list
        /// </summary>
        private List<string> _scotoptsCoinList = new List<string>();

        /// <summary>
        /// SCOT opts cash list
        /// </summary>
        private List<string> _scotoptsCashList = new List<string>();

        /// <summary>
        /// Current registry cash list
        /// </summary>
        private string _currentRegistryCashList;

        /// <summary>
        /// Current registry coin list
        /// </summary>
        private string _currentRegistryCoinList;

        /// <summary>
        /// New registry cash list
        /// </summary>
        private string _newRegistryCashList;

        /// <summary>
        /// New registry coin list
        /// </summary>
        private string _newRegistryCoinList;

        /// <summary>
        /// Current cash code list
        /// </summary>
        private string _currentCashCodeList;

        /// <summary>
        /// Current coin code list
        /// </summary>
        private string _currentCoinCodeList;

        /// <summary>
        /// New code list
        /// </summary>
        private string _newCodeList;

        /// <summary>
        /// Registry key cash acceptor
        /// </summary>
        private string _regKeyCashAcceptor;

        /// <summary>
        /// Registry key coin acceptor
        /// </summary>
        private string _regKeyCoinAcceptor;

        /// <summary>
        /// SCOT opts cash value list
        /// </summary>
        private string _scotoptsCashValueList;

        /// <summary>
        /// Cash list currency code
        /// </summary>
        private string _cashListCurrencyCode;

        /// <summary>
        /// Cash registry key
        /// </summary>
        private RegistryKey _cashKey;

        /// <summary>
        /// Coin registry key
        /// </summary>
        private RegistryKey _coinKey;

        /// <summary>
        /// Initializes a new instance of the CashValueList class
        /// </summary>
        public CashValueList()
        {
            try
            {
                _scotoptsCashValueList = GetScotoptsINIValue("Locale", "CashValueList");
                _newCodeList = GetCodeList();
                _cashListCurrencyCode = string.Concat(_newCodeList, "CashList");
                _regKeyCashAcceptor = RegistryAddress.CashAcceptorKey;
                _regKeyCoinAcceptor = RegistryAddress.CoinAcceptorKey;
                _cashKey = Registry.LocalMachine.OpenSubKey(_regKeyCashAcceptor, true);
                _coinKey = Registry.LocalMachine.OpenSubKey(_regKeyCoinAcceptor, true);
                _currentRegistryCashList = RegistryHelper.GetValue(_cashListCurrencyCode, _cashKey);
                _currentRegistryCoinList = RegistryHelper.GetValue(_cashListCurrencyCode, _coinKey);
                _currentCashCodeList = RegistryHelper.GetValue("CodeList", _cashKey);
                _currentCoinCodeList = RegistryHelper.GetValue("CodeList", _coinKey);
                SetCoinCashValueList();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the cash list currency code
        /// </summary>
        public string CashListCurrencyCode
        {
            get { return _cashListCurrencyCode; }
        }

        /// <summary>
        /// Gets the SCOT opts coin list
        /// </summary>
        public List<string> ScotoptsCoinList
        {
            get { return _scotoptsCoinList; }
        }

        /// <summary>
        /// Gets the SCOT opts cash list
        /// </summary>
        public List<string> ScotoptsCashList
        {
            get { return _scotoptsCashList; }
        }

        /// <summary>
        /// Gets the current registry cash list
        /// </summary>
        public string CurrentRegistryCashList
        {
            get { return RegistryHelper.GetValue(_cashListCurrencyCode, _cashKey); }
        }

        /// <summary>
        /// Gets the current registry coin list
        /// </summary>
        public string CurrentRegistryCoinList
        {
            get { return RegistryHelper.GetValue(_cashListCurrencyCode, _coinKey); }
        }

        /// <summary>
        /// Gets the new registry cash list
        /// </summary>
        public string NewRegistryCashList
        {
            get { return _newRegistryCashList; }
        }

        /// <summary>
        /// Gets the new registry coin list
        /// </summary>
        public string NewRegistryCoinList
        {
            get { return _newRegistryCoinList; }
        }

        /// <summary>
        /// Gets the cash acceptor registry location
        /// </summary>
        public string CashAcceptorRegistryLocation
        {
            get { return string.Format(@"{0}\{1} - '{2}'", Registry.LocalMachine, _regKeyCashAcceptor, _cashListCurrencyCode); }
        }

        /// <summary>
        /// Gets the coin acceptor registry location
        /// </summary>
        public string CoinAcceptorRegistryLocation
        {
            get { return string.Format(@"{0}\{1} - '{2}'", Registry.LocalMachine, _regKeyCoinAcceptor, _cashListCurrencyCode); }
        }

        /// <summary>
        /// Gets the SCOT opts cash value list
        /// </summary>
        public string ScotoptsCashValueList
        {
            get { return _scotoptsCashValueList; }
        }

        /// <summary>
        /// Gets the bag scale device key
        /// </summary>
        public string BagScaleDeviceKey
        {
            get { return GetBagScaleDeviceKey(); }
        }

        /// <summary>
        /// Gets the bag scale unit
        /// </summary>
        public string BagScaleUnit
        {
            get
            {
                string scaleUnit = GetScaleUnit();

                if (scaleUnit != null)
                {
                    return scaleUnit;
                }
                else
                {
                    return DefaultScaleUnit();
                }
            }
        }

        /// <summary>
        /// Gets the bag scale max weight
        /// </summary>
        public string BagScaleMaxWeight
        {
            get
            {
                string maxWeight = GetMaxWeight();

                if (maxWeight != null)
                {
                    return maxWeight;
                }
                else
                {
                    return DefaultMaxWeight();
                }
            }
        }

        /// <summary>
        /// Gets the bag scale emulator key
        /// </summary>
        public string BagScaleEmulatorKey
        {
            get { return GetBagScaleEmulatorKey(); }
        }

        /// <summary>
        /// Gets the produce scale emulator key
        /// </summary>
        public string ProduceScaleEmulatorKey
        {
            get { return GetProduceScaleEmulatorKey(); }
        }

        /// <summary>
        /// Gets the INI value
        /// </summary>
        /// <param name="filename">file name</param>
        /// <param name="section">section of the INI file</param>
        /// <param name="key">key of the INI file</param>
        /// <returns>Returns the information from the INI file</returns>
        public string GetINIValue(string filename, string section, string key)
        {
            if (!FileHelper.Exists(filename))
            {
                throw new Exception(string.Format("{0} not found", filename));
            }

            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, string.Empty, temp, 255, filename);
            return temp.ToString();
        }

        /// <summary>
        /// Gets the SCOT OPTS INI value
        /// </summary>
        /// <param name="section">section of the INI file</param>
        /// <param name="key">key of the INI file</param>
        /// <returns>Returns the information from the INI file</returns>
        public string GetScotoptsINIValue(string section, string key)
        {
            List<string> filenames = new List<string>();
            string terminalKey = @"SOFTWARE\NCR\SCOT\CurrentVersion\SCOTTB";
            string s1 = string.Empty;

            filenames.Add(@"c:\scot\config\scotopts." + RegistryHelper.GetValue("TerminalNumber", Registry.LocalMachine.OpenSubKey(terminalKey)));
            filenames.Add(@"c:\scot\config\scotopts.000");
            filenames.Add(@"c:\scot\config\scotopts.dat");

            foreach (string file in filenames)
            {
                try
                {
                    s1 = GetINIValue(file, section, key);
                    if (!s1.Equals(string.Empty))
                    {
                        return s1;
                    }
                }
                catch
                {
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Gets the code list
        /// </summary>
        /// <returns>Returns the code list</returns>
        public string GetCodeList()
        {
            List<string> code = new List<string>();
            code.Add(RegistryHelper.GetValue("CountryCode", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NCR\SCOT\Installation\Currency\")));
            code.Add(RegistryHelper.GetValue("CurrencyType", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\NCR\SCOT - Platform\ObservedOptions\")));

            foreach (string c in code)
            {
                if (c != null)
                {
                    return c;
                }
            }

            throw new Exception("Unidentified Currency Code");
        }

        /// <summary>
        /// Writes the cash list
        /// </summary>
        public void WriteCashList()
        {
            // 100,200,500,1000,2000,5000,10000; -> All valid denominations.
            // 1,5,10,25,100 -> All valid denominations.
            RegistryHelper.SetStringValue(_regKeyCashAcceptor, string.Concat(_cashListCurrencyCode, ".SSCAT.BackUp"), _currentRegistryCashList, false);
            RegistryHelper.SetStringValue(_regKeyCoinAcceptor, string.Concat(_cashListCurrencyCode, ".SSCAT.BackUp"), _currentRegistryCoinList, false);
            RegistryHelper.SetStringValue(_regKeyCashAcceptor, _cashListCurrencyCode, _newRegistryCashList, true);
            RegistryHelper.SetStringValue(_regKeyCoinAcceptor, _cashListCurrencyCode, _newRegistryCoinList, true);
        }

        /// <summary>
        /// Writes the code list
        /// </summary>
        public void WriteCodeList()
        {
            RegistryHelper.SetStringValue(_regKeyCashAcceptor, "CodeList.SSCAT.BackUp", _currentCashCodeList, false);
            RegistryHelper.SetStringValue(_regKeyCoinAcceptor, "CodeList.SSCAT.BackUp", _currentCoinCodeList, false);
            RegistryHelper.SetStringValue(_regKeyCashAcceptor, "CodeList", _newCodeList, true);
            RegistryHelper.SetStringValue(_regKeyCoinAcceptor, "CodeList", _newCodeList, true);
        }

        /// <summary>
        /// Writes the scale unit
        /// </summary>
        public void WriteScaleUnit()
        {
            RegistryHelper.SetStringValue(BagScaleEmulatorKey, "Units", BagScaleUnit, true);
            RegistryHelper.SetStringValue(ProduceScaleEmulatorKey, "Units", BagScaleUnit, true); // NOTE: Assumed that bag scale and produce scale has the same scale unit
        }

        /// <summary>
        /// Writes the scale max weight
        /// </summary>
        public void WriteScaleMaxWeight()
        {
            RegistryHelper.SetStringValue(BagScaleEmulatorKey, "MaxWeight", BagScaleMaxWeight, true);
            RegistryHelper.SetStringValue(ProduceScaleEmulatorKey, "MaxWeight", BagScaleMaxWeight, true);
        }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// Sets the coin cash value list
        /// </summary>
        private void SetCoinCashValueList()
        {
            string[] denominationList = _scotoptsCashValueList.Split(',');
            _newRegistryCashList = string.Empty;
            _newRegistryCoinList = string.Empty;

            foreach (string s in denominationList)
            {
                if (s.Contains("-"))
                {
                    _scotoptsCoinList.Add(s.Remove(0, 1));
                    _newRegistryCoinList += _newRegistryCoinList.Equals(string.Empty) ? s.Remove(0, 1) : "," + s.Remove(0, 1);
                }
                else
                {
                    _scotoptsCashList.Add(s);
                    _newRegistryCashList += _newRegistryCashList.Equals(string.Empty) ? s : "," + s;
                }
            }
        }

        /// <summary>
        /// Gets the bag scale device key
        /// </summary>
        /// <returns>Returns the bag scale device key</returns>
        private string GetBagScaleDeviceKey()
        {
            if (SSCOHelper.IsCADD())
            {
                return RegistryAddress.CADDBagScaleDeviceKey;
            }
            else
            {
                return RegistryAddress.ADDBagScaleDeviceKey;
            }
        }

        /// <summary>
        /// Get bag scale emulator key
        /// </summary>
        /// <returns>Returns the bag scale emulator key</returns>
        private string GetBagScaleEmulatorKey()
        {
            if (SSCOHelper.IsCADD())
            {
                return RegistryAddress.CADDBagScaleEmulatorKey;
            }
            else
            {
                return RegistryAddress.ADDBagScaleEmulatorKey;
            }
        }

        /// <summary>
        /// Get produce scale emulator key
        /// </summary>
        /// <returns>Returns the produce scale emulator key</returns>
        private string GetProduceScaleEmulatorKey()
        {
            if (SSCOHelper.IsCADD())
            {
                return RegistryAddress.CADDProduceScaleEmulatorKey;
            }
            else
            {
                return RegistryAddress.ADDProduceScaleEmulatorKey;
            }
        }

        /// <summary>
        /// Get scale unit
        /// </summary>
        /// <returns>Returns the scale unit</returns>
        private string GetScaleUnit()
        {
            if (RegistryHelper.Exists(BagScaleDeviceKey, Registry.LocalMachine))
            {
                return RegistryHelper.GetValue("ScaleUnit", Registry.LocalMachine.OpenSubKey(BagScaleDeviceKey));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get the default scale unit
        /// </summary>
        /// <returns>Returns the default scale unit</returns>
        private string DefaultScaleUnit()
        {
            if (GetCodeList().Equals("USD"))
            {
                return "4";
            }
            else
            {
                return "2";
            }
        }

        /// <summary>
        /// Get the max weight
        /// </summary>
        /// <returns>Returns the max weight</returns>
        private string GetMaxWeight()
        {
            if (RegistryHelper.Exists(BagScaleDeviceKey, Registry.LocalMachine))
            {
                return RegistryHelper.GetValue("MaxWeight", Registry.LocalMachine.OpenSubKey(BagScaleDeviceKey));
            }
            else
            {
                return null;
            }
        }
        
        /// <summary>
        /// Get the default max weight
        /// </summary>
        /// <returns>Returns the default max weight</returns>
        private string DefaultMaxWeight()
        {
            return "150";
        }
    }
}
