// <copyright file="Program.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Tools.CashDenomination
{
    using System;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the CashValueList class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Cash Value List
        /// </summary>
        private static CashValueList _cashValueList = new CashValueList();

        /// <summary>
        /// Entry point for SSCAT tools cash denomination application
        /// </summary>
        /// <param name="args">application arguments</param>
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("CodeList: " + _cashValueList.GetCodeList() + "\n\n");

                _cashValueList.WriteCodeList();

                Console.WriteLine(":: Current ::");
                Console.WriteLine(_cashValueList.CoinAcceptorRegistryLocation + ":\n" + _cashValueList.CurrentRegistryCoinList);
                Console.WriteLine(_cashValueList.CashAcceptorRegistryLocation + ":\n" + _cashValueList.CurrentRegistryCashList);
                Console.WriteLine();

                _cashValueList.WriteCashList();

                Console.WriteLine(":: New ::");
                Console.WriteLine(_cashValueList.CoinAcceptorRegistryLocation + ":\n" + _cashValueList.CurrentRegistryCoinList);
                Console.WriteLine(_cashValueList.CashAcceptorRegistryLocation + ":\n" + _cashValueList.CurrentRegistryCashList);
                Console.WriteLine();

                Console.WriteLine("Successfully synchronized Scotopts' CashValueList to the CashAcceptor and CoinAcceptor's Emulator's \'" + _cashValueList.CashListCurrencyCode + "\'");
                ThreadHelper.Sleep(3000);

                _cashValueList.WriteScaleUnit();
                _cashValueList.WriteScaleMaxWeight();
                ThreadHelper.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ThreadHelper.Sleep(3000);
            }
            finally
            {
                Console.WriteLine();
                ThreadHelper.Sleep(1000);
            }
        }
    }
}