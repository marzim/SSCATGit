// <copyright file="CoinAcceptor.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the CoinAcceptor class
    /// </summary>
    public class CoinAcceptor : Emulator, ICoinAcceptor
    {
        /// <summary>
        /// Initializes a new instance of the CoinAcceptor class
        /// </summary>
        public CoinAcceptor()
            : base(Emulator.CoinAcceptorCaption)
        {
            Controls.Add("CurrencyCode", 0x3fa);
            Controls.Add("Denomination", 0x3fb);
            Controls.Add("Status", 0x3fc);
            Controls.Add("Insert", 0x3f9);
            Controls.Add("Reject", 0x3f8);
            Controls.Add("CoinReturn", 0x3fe);
            Controls.Add("Reset", 0x404);
            Controls.Add("Fail", 0x405);
            Controls.Add("Jam", 0x406);
            Controls.Add("Ok", 0x407);
            Controls.Add("HopperOut", 0x3fd);

            Controls.Add("CoinRecyclerDialog", 0x000);
            Controls.Add("CoinRecyclerInsert1", 0xc14);
            Controls.Add("CoinRecyclerInsert5", 0xc15);
            Controls.Add("CoinRecyclerInsert10", 0xbc9);
            Controls.Add("CoinRecyclerInsert25", 0xbcb);
            Controls.Add("CoinRecyclerInsert50", 0xbcc);
            Controls.Add("CoinRecyclerInsert100", 0xbcd);
            Controls.Add("CoinRecyclerInsertButton", 0xbc2);
        }

        /// <summary>
        /// Coin acceptor inserting
        /// </summary>
        /// <param name="deviceValue">device value</param>
        /// <param name="timeout">timeout amount</param>
        public virtual void Insert(string deviceValue, int timeout)
        {
            if (Caption.Contains("Emulator_NCRCoinRecycler"))
            {
                InsertCoinRecycler(deviceValue, timeout);
            }
            else
            {
                InsertCoinAcceptor(deviceValue, timeout);
            }
        }

        /// <summary>
        /// Coin acceptor inserting
        /// </summary>
        /// <param name="deviceValue">device value</param>
        /// <param name="timeout">timeout amount</param>
        public virtual void InsertCoinAcceptor(string deviceValue, int timeout)
        {
            bool match = false;
            do
            {
                OnEmulating(string.Format("Coin acceptor inserting {0}", deviceValue));
                SelectIndex("Denomination", deviceValue, timeout);
                ThreadHelper.Sleep(100);
                match = CompareIndex2("Denomination", deviceValue, timeout);
            }
            while (!match);
            ClickButton("Insert", timeout);
        }

        /// <summary>
        /// Coin recycler inserting
        /// </summary>
        /// <param name="deviceValue">device value</param>
        /// <param name="timeout">timeout amount</param>
        public virtual void InsertCoinRecycler(string deviceValue, int timeout)
        {
            bool match = false;
            string controlName = string.Empty;
            switch (deviceValue)
            {
                case "1":
                    controlName = "CoinRecyclerInsert1";
                    break;
                case "5":
                    controlName = "CoinRecyclerInsert5";
                    break;
                case "10":
                    controlName = "CoinRecyclerInsert10";
                    break;
                case "25":
                    controlName = "CoinRecyclerInsert25";
                    break;
                case "50":
                    controlName = "CoinRecyclerInsert50";
                    break;
                case "100":
                    controlName = "CoinRecyclerInsert100";
                    break;
                default:
                    throw new EmulatorException(string.Format("{0} not valid", deviceValue));
            }
            
            do
            {
                OnEmulating(string.Format("Coin Recycler inserting {0}x1", deviceValue));
                SelectIndex("CoinRecyclerDialog", controlName, "1", timeout);
                ThreadHelper.Sleep(100);
                match = CompareIndex2("CoinRecyclerDialog", controlName, "1", timeout);
            }
            while (!match);

            ClickButton("CoinRecyclerDialog", "CoinRecyclerInsertButton", timeout);
        }

        /// <summary>
        /// Coin acceptor resetting
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void Reset(int timeout)
        {
            OnEmulating("Coin acceptor resetting");
            ClickButton("Reset", timeout);
            ThreadHelper.Sleep(100);
            ClickButton("Ok", timeout);
        }

        /// <summary>
        /// Coin acceptor failing
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void Fail(int timeout)
        {
            OnEmulating("Coin acceptor failing");
            ClickButton("Fail", timeout);
            ThreadHelper.Sleep(100);
            ClickButton("Ok", timeout);
        }

        /// <summary>
        /// Coin acceptor jamming
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void Jam(int timeout)
        {
            OnEmulating("Coin acceptor jamming");
            ClickButton("Jam", timeout);
            ThreadHelper.Sleep(100);
            ClickButton("Ok", timeout);
        }

        /// <summary>
        /// Coin acceptor hopper out
        /// </summary>
        /// <param name="timeout">timeout amount</param>
        public void HopperOut(int timeout)
        {
            OnEmulating("Coin acceptor hopper out");
            ClickButton("HopperOut", timeout);
            ThreadHelper.Sleep(100);
            ClickButton("Ok", timeout);
        }
    }
}
