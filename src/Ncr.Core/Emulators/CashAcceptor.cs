// <copyright file="CashAcceptor.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using System;
    using Ncr.Core.Util;
    
    /// <summary>
    /// Initializes a new instance of the CashAcceptor class
    /// </summary>
    public class CashAcceptor : Emulator, ICashAcceptor
    {
        /// <summary>
        /// Initializes a new instance of the CashAcceptor class
        /// </summary>
        public CashAcceptor()
            : base(Emulator.CashAcceptorCaption)
        {
            Controls.Add("CurrencyCode", 0x3fa);
            Controls.Add("Denomination", 0x3fb);
            Controls.Add("Status", 0x3fc);
            Controls.Add("Stack", 0x3f9);
            Controls.Add("Reject", 0x3f8);
            Controls.Add("Tease", 0x3f7);
            Controls.Add("Cheat", 0x3fe);
            Controls.Add("Reset", 0x404);
            Controls.Add("Fail", 0x405);
            Controls.Add("Jam", 0x406);
            Controls.Add("Ok", 0x407);
            Controls.Add("CassetteOut", 0x3fd);

            Controls.Add("CashRecyclerDialog", 0x000);
            Controls.Add("CashRecyclerInsert100", 0xc76);
            Controls.Add("CashRecyclerInsert200", 0xc78);
            Controls.Add("CashRecyclerInsert500", 0xc7a);
            Controls.Add("CashRecyclerInsert1000", 0xc7c);
            Controls.Add("CashRecyclerInsert2000", 0xc7d);
            Controls.Add("CashRecyclerInsert5000", 0xc7e);
            Controls.Add("CashRecyclerInsert10000", 0xc7f);
            Controls.Add("CashRecyclerInsertButton", 0xc51);
        }

        /// <summary>
        /// Cash acceptor escrow
        /// </summary>
        /// <param name="deviceValue">device value</param>
        /// <param name="timeout">timeout amount</param>
        public virtual void Escrow(string deviceValue, int timeout)
        {
            if (Caption.Contains("Emulator_NCRCashRecycler"))
            {
                InsertCashRecycler(deviceValue, timeout);
            }
            else
            {
                InsertCashAcceptor(deviceValue, timeout);
            }
        }

        /// <summary>
        /// Cash acceptor escrow
        /// </summary>
        /// <param name="deviceValue">device value</param>
        /// <param name="timeout">timeout amount</param>
        public virtual void InsertCashAcceptor(string deviceValue, int timeout)
        {
            bool match = false;
            do
            {
                OnEmulating(string.Format("Cash Acceptor escrow {0}", deviceValue));
                SelectIndex("Denomination", deviceValue, timeout);
                ThreadHelper.Sleep(100);
                match = CompareIndex2("Denomination", deviceValue, timeout);
            }
            while (!match);
            ClickButton("Stack", timeout);
        }

        /// <summary>
        /// Coin recycler inserting
        /// </summary>
        /// <param name="deviceValue">device value</param>
        /// <param name="timeout">timeout amount</param>
        public virtual void InsertCashRecycler(string deviceValue, int timeout)
        {
            bool match = false;
            string controlName = string.Empty;
            switch (deviceValue)
            {
                case "100":
                    controlName = "CashRecyclerInsert100";
                    break;
                case "200":
                    controlName = "CashRecyclerInsert200";
                    break;
                case "500":
                    controlName = "CashRecyclerInsert500";
                    break;
                case "1000":
                    controlName = "CashRecyclerInsert1000";
                    break;
                case "2000":
                    controlName = "CashRecyclerInsert2000";
                    break;
                case "5000":
                    controlName = "CashRecyclerInsert5000";
                    break;
                case "10000":
                    controlName = "CashRecyclerInsert10000";
                    break;
                default:
                    throw new EmulatorException(string.Format("{0} not valid", deviceValue));
            }

            do
            {
                OnEmulating(string.Format("Cash Recycler inserting {0}x1", deviceValue));
                SelectIndex("CashRecyclerDialog", controlName, "1", timeout);
                ThreadHelper.Sleep(100);
                match = CompareIndex2("CashRecyclerDialog", controlName, "1", timeout);
            }
            while (!match);

            ClickButton("CashRecyclerDialog", "CashRecyclerInsertButton", timeout);
        }

        /// <summary>
        /// Cash acceptor cassette out
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void CassetteOut(int timeout)
        {
            OnEmulating("Cash acceptor cassette out");
            ClickButton("CassetteOut", timeout);
            ThreadHelper.Sleep(100);
            ClickButton("Ok", timeout);
        }

        /// <summary>
        /// Cash acceptor resetting
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void Reset(int timeout)
        {
            OnEmulating("Cash acceptor resetting");
            ClickButton("Reset", timeout);
        }

        /// <summary>
        /// Cash acceptor jamming
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void Jam(int timeout)
        {
            OnEmulating("Cash acceptor jamming");
            ClickButton("Jam", timeout);
            ThreadHelper.Sleep(100);
            ClickButton("Ok", timeout);
        }

        /// <summary>
        /// Cash acceptor failing
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void Fail(int timeout)
        {
            OnEmulating("Cash acceptor failing");
            ClickButton("Fail", timeout);
            ThreadHelper.Sleep(100);
            ClickButton("Ok", timeout);
        }
    }
}
