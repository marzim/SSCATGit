// <copyright file="RegistryAddress.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using Microsoft.Win32;

    /// <summary>
    /// Initializes static members of the RegistryAddress class
    /// </summary>
    public static class RegistryAddress
    {
        /// <summary>
        /// Scanner Caption for Windows 32
        /// </summary>
        private static string scannerCaption32 = string.Format(@"Scanner\{0}", RegistryHelper.GetValue("CADD_Scanner", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\Scanner"), "Emulator"));
        
        /// <summary>
        /// Bag Scale Caption for Windows 32
        /// </summary>
        private static string bagScaleCaption32 = string.Format(@"Scale\{0}", RegistryHelper.GetValue("CADD_BagScale", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\Scale"), "BagScaleEmulator"));

        /// <summary>
        /// Scale Caption for Windows 32
        /// </summary>
        private static string scaleCaption32 = string.Format(@"Scale\{0}", RegistryHelper.GetValue("CADD_ProduceScale", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\Scale"), "Emulator"));

        /// <summary>
        /// Cash Acceptor Caption for Windows 32
        /// </summary>
        private static string cashAcceptorCaption32 = string.Format(@"CashAcceptor\{0}", RegistryHelper.GetValue("CADD_CashAcceptor", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\CashAcceptor"), "Emulator"));

        /// <summary>
        /// Cash Trough Caption for Windows 64
        /// </summary>
        private static string cashTroughCaption32 = string.Format(@"MotionSensor\{0}", RegistryHelper.GetValue("CADD_CashTrough", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\SOFTWARE\OLEforRetail\ServiceOPOS\MotionSensor"), "Emulator_NCRCashTrough"));

        /// <summary>
        /// Coin Acceptor Caption for Windows 32
        /// </summary>
        private static string coinAcceptorCaption32 = string.Format(@"CoinAcceptor\{0}", RegistryHelper.GetValue("CADD_CoinAcceptor", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\CoinAcceptor"), "Emulator"));

        /// <summary>
        /// Coin Changer Caption for Windows 32
        /// </summary>
        private static string coinChangerCaption32 = string.Format(@"CashChanger\{0}", RegistryHelper.GetValue("CADD_CashChanger_Coin", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger"), "EmulatorCoin"));

        /// <summary>
        /// Bill Changer Caption for Windows 32
        /// </summary>
        private static string billChangerCaption32 = string.Format(@"CashChanger\{0}", RegistryHelper.GetValue("CADD_CashChanger_Bill", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger"), "EmulatorBill"));

        /// <summary>
        /// MSR Caption for Windows 32
        /// </summary>
        private static string msrCaption32 = string.Format(@"MSR\{0}", RegistryHelper.GetValue("CADD_MSR", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\MSR"), "Emulator"));

        /// <summary>
        /// Pin Pad Caption for Windows 32
        /// </summary>
        private static string pinPadCaption32 = string.Format(@"{0}", RegistryHelper.GetValue("CADD_PinPad", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\PINPad"), "Pinpad Emulator"));

        /// <summary>
        /// PC Signature Capture Caption for Windows 32
        /// </summary>
        private static string pCSignatureCaptureCaption32 = string.Format(@"{0}", RegistryHelper.GetValue("CADD_SignatureCapture", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\SignatureCapture"), "PC Signature Capture"));

        /// <summary>
        /// POS Printer Caption for Windows 32
        /// </summary>
        private static string posPrinterCaption32 = string.Format(@"POSPrinter\{0}", RegistryHelper.GetValue("CADD_RecPrinter", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\POSPrinter"), "Emulator - Receipt"));

        /// <summary>
        /// Motion Sensor Caption for Windows 32
        /// </summary>
        private static string motionSensorCaption32 = string.Format(@"MotionSensor\{0}", RegistryHelper.GetValue("CADD_Coupon", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OLEForRetail\ServiceOPOS\MotionSensor"), "Emulator - Coupon"));

        /// <summary>
        /// Scanner Caption for Windows 64
        /// </summary>
        private static string scannerCaption64 = string.Format(@"Scanner\{0}", RegistryHelper.GetValue("CADD_Scanner", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\OLEForRetail\ServiceOPOS\Scanner"), "Emulator"));

        /// <summary>
        /// Bag Scale Caption for Windows 64
        /// </summary>
        private static string bagScaleCaption64 = string.Format(@"Scale\{0}", RegistryHelper.GetValue("CADD_BagScale", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\OLEForRetail\ServiceOPOS\Scale"), "BagScaleEmulator"));

        /// <summary>
        /// Scale Caption for Windows 64
        /// </summary>
        private static string scaleCaption64 = string.Format(@"Scale\{0}", RegistryHelper.GetValue("CADD_ProduceScale", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\OLEForRetail\ServiceOPOS\Scale"), "Emulator"));

        /// <summary>
        /// Cash Acceptor Caption for Windows 64
        /// </summary>
        private static string cashAcceptorCaption64 = string.Format(@"CashAcceptor\{0}", RegistryHelper.GetValue("CADD_CashAcceptor", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\OLEForRetail\ServiceOPOS\CashAcceptor"), "Emulator"));

        /// <summary>
        /// Cash Trough Caption for Windows 64
        /// </summary>
        private static string cashTroughCaption64 = string.Format(@"MotionSensor\{0}", RegistryHelper.GetValue("CADD_CashTrough", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\SOFTWARE\OLEforRetail\ServiceOPOS\MotionSensor"), "Emulator_NCRCashTrough"));

        /// <summary>
        /// Coin Acceptor Caption for Windows 64
        /// </summary>
        private static string coinAcceptorCaption64 = string.Format(@"CoinAcceptor\{0}", RegistryHelper.GetValue("CADD_CoinAcceptor", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\OLEForRetail\ServiceOPOS\CoinAcceptor"), "Emulator"));

        /// <summary>
        /// Coin Changer Caption for Windows 64
        /// </summary>
        private static string coinChangerCaption64 = string.Format(@"CashChanger\{0}", RegistryHelper.GetValue("CADD_CashChanger_Coin", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\OLEforRetail\ServiceOPOS\CashChanger"), "EmulatorCoin"));

        /// <summary>
        /// Bill Changer Caption for Windows 64
        /// </summary>
        private static string billChangerCaption64 = string.Format(@"CashChanger\{0}", RegistryHelper.GetValue("CADD_CashChanger_Bill", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\OLEforRetail\ServiceOPOS\CashChanger"), "EmulatorBill"));

        /// <summary>
        /// MSR Caption for Windows 64
        /// </summary>
        private static string msrCaption64 = string.Format(@"MSR\{0}", RegistryHelper.GetValue("CADD_MSR", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\OLEForRetail\ServiceOPOS\MSR"), "Emulator"));

        /// <summary>
        /// Pin Pad Caption for Windows 64
        /// </summary>
        private static string pinPadCaption64 = string.Format(@"{0}", RegistryHelper.GetValue("CADD_PinPad", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\OLEForRetail\ServiceOPOS\PINPad"), "Pinpad Emulator"));

        /// <summary>
        /// PC Signature Capture Caption for Windows 64
        /// </summary>
        private static string pCSignatureCaptureCaption64 = string.Format(@"{0}", RegistryHelper.GetValue("CADD_SignatureCapture", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\OLEForRetail\ServiceOPOS\SignatureCapture"), "PC Signature Capture"));

        /// <summary>
        /// POS Printer Caption for Windows 64
        /// </summary>
        private static string posPrinterCaption64 = string.Format(@"POSPrinter\{0}", RegistryHelper.GetValue("CADD_RecPrinter", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\OLEForRetail\ServiceOPOS\POSPrinter"), "Emulator - Receipt"));

        /// <summary>
        /// Motion Sensor Caption for Windows 64
        /// </summary>
        private static string motionSensorCaption64 = string.Format(@"MotionSensor\{0}", RegistryHelper.GetValue("CADD_Coupon", Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\OLEForRetail\ServiceOPOS\MotionSensor"), "Emulator - Coupon"));

        /// <summary>
        /// Bag Scale Emulator Key for Windows 32
        /// </summary>
        private static string bagScaleEmulatorKey32 = @"SOFTWARE\OLEForRetail\ServiceOPOS\Scale\BagScaleEmulator";

        /// <summary>
        /// Bag Emulator Key for Windows 32
        /// </summary>
        private static string bagEmulatorKey32 = @"SOFTWARE\OLEForRetail\ServiceOPOS\Scale\Emulator_Bag";

        /// <summary>
        /// CADD Emulator Coin Key for Windows 32
        /// </summary>
        private static string cADDEmulatorCoinKey32 = @"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\Emulator_CoinDispenser";

        /// <summary>
        /// CADD Emulator Bill Key for Windows 32
        /// </summary>
        private static string cADDEmulatorBillKey32 = @"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\Emulator_BillDispenser";

        /// <summary>
        /// ADD Emulator Coin Key for Windows 32
        /// </summary>
        private static string aDDEmulatorCoinKey32 = @"SOFTWARE\OLEforRetail\ServiceOPOS\CashChanger\EmulatorCoin";

        /// <summary>
        /// ADD Symbologies Key for Windows 32
        /// </summary>
        private static string symbologiesKeyADD32 = @"SOFTWARE\OLEforRetail\ServiceOPOS\Scanner\Emulator\Symbologies\";

        /// <summary>
        /// CADD Symbologies Key for Windows 32
        /// </summary>
        private static string symbologiesKeyCADD32 = @"SOFTWARE\OLEforRetail\ServiceOPOS\Scanner\Emulator_Scanner\Symbologies\";

        /// <summary>
        /// Current Version Key for Windows 32
        /// </summary>
        private static string currentVersionKey32 = @"SOFTWARE\NCR\SCOT\CurrentVersion\SCOTAPP";

        /// <summary>
        /// ADD Version Key for Windows 32
        /// </summary>
        private static string aDDVersionKey32 = @"SOFTWARE\NCR\ADD";

        /// <summary>
        /// Type for Windows 32
        /// </summary>
        private static string sSCOApplicationType32 = @"SOFTWARE\NCR\SCOT - Platform\ObservedOptions";

        /// <summary>
        /// SSCO Application Type for Windows 32
        /// </summary>
        private static string sSCOApplicationType2_32 = @"SOFTWARE\NCR\SCOT\Installation\ApplicationType";

        /// <summary>
        /// Terminal Number Key for Windows 32
        /// </summary>
        private static string terminalNumberKey32 = @"SOFTWARE\NCR\SCOT\CurrentVersion\SCOTTB";

        /// <summary>
        /// Country Code Key for Windows 32
        /// </summary>
        private static string countryCodeKey32 = @"SOFTWARE\NCR\SCOT\Installation\Currency";

        /// <summary>
        /// Currency Type Key for Windows 32
        /// </summary>
        private static string currencyTypeKey32 = @"SOFTWARE\NCR\SCOT - Platform\ObservedOptions";

        /// <summary>
        /// Cash Count Key for Windows 32
        /// </summary>
        private static string cashCountKey32 = @"SOFTWARE\NCR\XM\CashCount";

        /// <summary>
        /// Cash Acceptor Key for Windows 32
        /// </summary>
        private static string cashAcceptorKey32 = @"SOFTWARE\OLEForRetail\ServiceOPOS\CashAcceptor\Emulator\";

        /// <summary>
        /// Coin Acceptor Key for Windows 32
        /// </summary>
        private static string coinAcceptorKey32 = @"SOFTWARE\OLEForRetail\ServiceOPOS\CoinAcceptor\Emulator\";

        /// <summary>
        /// CADD Bag Scale Device Key for Windows 32
        /// </summary>
        private static string cADDBagScaleDeviceKey32 = @"Software\OleForRetail\ServiceOPOS\Scale\NCR_Bag";

        /// <summary>
        /// CADD Bag Scale Emulator Key for Windows 32
        /// </summary>
        private static string cADDBagScaleEmulatorKey32 = @"SOFTWARE\OLEforRetail\ServiceOPOS\Scale\Emulator_Bag";

        /// <summary>
        /// CADD Produce Scale Emulator Key for Windows 32
        /// </summary>
        private static string cADDProduceScaleEmulatorKey32 = @"SOFTWARE\OLEforRetail\ServiceOPOS\Scale\BagScaleEmulator";

        /// <summary>
        /// ADD Bag Scale Device Key for Windows 32
        /// </summary>
        private static string aDDBagScaleDeviceKey32 = @"SOFTWARE\OLEforRetail\ServiceOPOS\Scale\BagScaleFlintec";

        /// <summary>
        /// ADD Bag Scale Emulator Key for Windows 32
        /// </summary>
        private static string aDDBagScaleEmulatorKey32 = @"SOFTWARE\OLEforRetail\ServiceOPOS\Scale\BagScaleEmulator";

        /// <summary>
        /// ADD Produce Scale Emulator Key for Windows 32
        /// </summary>
        private static string aDDProduceScaleEmulatorKey32 = @"SOFTWARE\OLEforRetail\ServiceOPOS\Scale\Emulator";

        /// <summary>
        /// Gets the scanner caption
        /// </summary>
        public static string ScannerCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? scannerCaption32 : scannerCaption64; }
        }

        /// <summary>
        /// Gets the Bag Scale Caption
        /// </summary>
        public static string BagScaleCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? bagScaleCaption32 : bagScaleCaption64; }
        }

        /// <summary>
        /// Gets the Scale Caption
        /// </summary>
        public static string ScaleCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? scaleCaption32 : scaleCaption64; }
        }

        /// <summary>
        /// Gets the Cash Acceptor Caption
        /// </summary>
        public static string CashAcceptorCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? cashAcceptorCaption32 : cashAcceptorCaption64; }
        }

        /// <summary>
        /// Gets the Cash Trough Caption
        /// </summary>
        public static string CashTroughCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? cashTroughCaption32 : cashTroughCaption64; }
        }

        /// <summary>
        /// Gets the Coin Acceptor Caption
        /// </summary>
        public static string CoinAcceptorCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? coinAcceptorCaption32 : coinAcceptorCaption64; }
        }

        /// <summary>
        /// Gets the Coin Changer Caption
        /// </summary>
        public static string CoinChangerCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? coinChangerCaption32 : coinChangerCaption64; }
        }

        /// <summary>
        /// Gets the Bill Changer Caption
        /// </summary>
        public static string BillChangerCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? billChangerCaption32 : billChangerCaption64; }
        }

        /// <summary>
        /// Gets the MSR Caption
        /// </summary>
        public static string MsrCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? msrCaption32 : msrCaption64; }
        }

        /// <summary>
        /// Gets the Pin Pad Caption
        /// </summary>
        public static string PinPadCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? pinPadCaption32 : pinPadCaption64; }
        }

        /// <summary>
        /// Gets the PC Signature Capture Caption
        /// </summary>
        public static string PCSignatureCaptureCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? pCSignatureCaptureCaption32 : pCSignatureCaptureCaption64; }
        }

        /// <summary>
        /// Gets the Pos Printer Caption
        /// </summary>
        public static string PosPrinterCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? posPrinterCaption32 : posPrinterCaption64; }
        }

        /// <summary>
        /// Gets the Motion Sensor Caption
        /// </summary>
        public static string MotionSensorCaption
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? motionSensorCaption32 : motionSensorCaption64; }
        }

        /// <summary>
        /// Gets the Bag Scale Emulator Key
        /// </summary>
        public static string BagScaleEmulatorKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? bagScaleEmulatorKey32 : bagScaleEmulatorKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the Bag Emulator Key
        /// </summary>
        public static string BagEmulatorKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? bagEmulatorKey32 : bagEmulatorKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the CADD Emulator Coin Key
        /// </summary>
        public static string CADDEmulatorCoinKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? cADDEmulatorCoinKey32 : cADDEmulatorCoinKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the CADD Emulator Bill Key
        /// </summary>
        public static string CADDEmulatorBillKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? cADDEmulatorBillKey32 : cADDEmulatorBillKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the ADD Emulator Coin Key
        /// </summary>
        public static string ADDEmulatorCoinKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? aDDEmulatorCoinKey32 : aDDEmulatorCoinKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the Symbologies Key ADD
        /// </summary>
        public static string SymbologiesKeyADD
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? symbologiesKeyADD32 : symbologiesKeyADD32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the Symbologies Key CADD
        /// </summary>
        public static string SymbologiesKeyCADD
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? symbologiesKeyCADD32 : symbologiesKeyCADD32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the Current Version Key
        /// </summary>
        public static string CurrentVersionKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? currentVersionKey32 : currentVersionKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the ADD Version Key
        /// </summary>
        public static string ADDVersionKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? aDDVersionKey32 : aDDVersionKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the SSCO Application Type
        /// </summary>
        public static string SSCOApplicationType
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? sSCOApplicationType32 : sSCOApplicationType32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the SSCO Application Type 2
        /// </summary>
        public static string SSCOApplicationType2
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? sSCOApplicationType2_32 : sSCOApplicationType2_32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the Terminal Number Key
        /// </summary>
        public static string TerminalNumberKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? terminalNumberKey32 : terminalNumberKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the Country Code Key
        /// </summary>
        public static string CountryCodeKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? countryCodeKey32 : countryCodeKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the Currency Type Key
        /// </summary>
        public static string CurrencyTypeKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? currencyTypeKey32 : currencyTypeKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the Cash Count Key
        /// </summary>
        public static string CashCountKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? cashCountKey32 : cashCountKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the Cash Acceptor Key
        /// </summary>
        public static string CashAcceptorKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? cashAcceptorKey32 : cashAcceptorKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the Coin Acceptor Key
        /// </summary>
        public static string CoinAcceptorKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? coinAcceptorKey32 : coinAcceptorKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the CADD Bag Scale Device Key
        /// </summary>
        public static string CADDBagScaleDeviceKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? cADDBagScaleDeviceKey32 : cADDBagScaleDeviceKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the CADD Bag Scale Emulator Key
        /// </summary>
        public static string CADDBagScaleEmulatorKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? cADDBagScaleEmulatorKey32 : cADDBagScaleEmulatorKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the CADD Produce Scale Emulator Key
        /// </summary>
        public static string CADDProduceScaleEmulatorKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? cADDProduceScaleEmulatorKey32 : cADDProduceScaleEmulatorKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the ADD Bag Scale Device Key
        /// </summary>
        public static string ADDBagScaleDeviceKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? aDDBagScaleDeviceKey32 : aDDBagScaleDeviceKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the ADD Bag Scale Emulator Key
        /// </summary>
        public static string ADDBagScaleEmulatorKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? aDDBagScaleEmulatorKey32 : aDDBagScaleEmulatorKey32.Insert(9, "WOW6432Node\\"); }
        }

        /// <summary>
        /// Gets the ADD Produce Scale Emulator Key
        /// </summary>
        public static string ADDProduceScaleEmulatorKey
        {
            get { return !SSCOHelper.Is64BitOperatingSystem() ? aDDProduceScaleEmulatorKey32 : aDDProduceScaleEmulatorKey32.Insert(9, "WOW6432Node\\"); }
        }
    }
}
