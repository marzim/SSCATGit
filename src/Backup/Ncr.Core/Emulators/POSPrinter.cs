// <copyright file="POSPrinter.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System.Threading;

    /// <summary>
    /// Initializes a new instance of the POSPrinter class
    /// </summary>
    public class POSPrinter : Emulator, IPosPrinter
    {
        /// <summary>
        /// Cover open
        /// </summary>
        private const string COVEROPEN = "COVER OPEN";

        /// <summary>
        /// Initializes a new instance of the POSPrinter class
        /// </summary>
        public POSPrinter()
            : base(Emulator.PosPrinterCaption)
        {
            Controls.Add("3", 0x417);
            Controls.Add("4", 0x413);
        }

        /// <summary>
        /// Printing receipt
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public virtual void Printing(int timeout)
        {
            OnEmulating(string.Format("Printing Receipt"));
        }

        /// <summary>
        /// Printer cover open
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void CoverOpen(int timeout)
        {
            ClickButton("4", timeout);
            Thread.Sleep(200);
            ClickButton("4", timeout);
        }
    }
}
