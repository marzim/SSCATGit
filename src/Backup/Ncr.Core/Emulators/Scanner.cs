// <copyright file="Scanner.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the Scanner class
    /// </summary>
    public class Scanner : Emulator, IScanner
    {
        /// <summary>
        /// Initializes a new instance of the Scanner class
        /// </summary>
        public Scanner()
            : base(Emulator.ScannerCaption)
        {
            Controls.Add("Symbology", 0x3eb);
            Controls.Add("TagDataComboBox", 0x3e8);
            Controls.Add("DescriptionComboBox", 0x429);
            Controls.Add("Scan", 0x3e9);
        }

        /// <summary>
        /// Scans the code
        /// </summary>
        /// <param name="code">scan code</param>
        /// <param name="timeout">timeout amount</param>
        public virtual void Scan(string code, int timeout)
        {
            Upc u = Upc.Decode(code);
            SelectIndex("Symbology", u.GetSymbology(), timeout);
            ThreadHelper.Sleep(50);
            SetText("DescriptionComboBox", u.ItemName, timeout);
            ThreadHelper.Sleep(50);
            SetText("TagDataComboBox", u.GetTrimmedTag(), timeout);
            ThreadHelper.Sleep(50);
            ClickButton("Scan", timeout);
        }

        /// <summary>
        /// Scanner invoking error
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public virtual void Error(int timeout)
        {
            OnEmulating("Scanner invoking error");
            ClickButton("Scan", timeout);
        }
    }
}
