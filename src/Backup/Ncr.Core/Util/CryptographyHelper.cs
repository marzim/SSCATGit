// <copyright file="CryptographyHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    using System;

    /// <summary>
    /// Initializes a new instance of the CryptographyHelper class
    /// </summary>
    public class CryptographyHelper
    {
        /// <summary>
        /// Cryptography manager
        /// </summary>
        private static ICryptographyManager _manager;

        /// <summary>
        /// Initializes static members of the CryptographyHelper class
        /// </summary>
        static CryptographyHelper()
        {
            Attach(new CryptographyManager());
        }

        /// <summary>
        /// Attach cryptography manager
        /// </summary>
        /// <param name="manager">cryptography manager</param>
        public static void Attach(ICryptographyManager manager)
        {
            CryptographyHelper._manager = manager;
        }

        /// <summary>
        /// Encrypt the text
        /// </summary>
        /// <param name="plainText">plain text</param>
        /// <param name="passPhrase">pass phrase</param>
        /// <returns>Returns the encrypted text</returns>
        public static string Encrypt(string plainText, string passPhrase)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("Cryptography Manager");
            }

            return _manager.Encrypt(plainText, passPhrase);
        }

        /// <summary>
        /// Decrypt text
        /// </summary>
        /// <param name="cipherText">cipher text</param>
        /// <param name="passPhrase">pass phrase</param>
        /// <returns>Returns the decrypted text</returns>
        public static string Decrypt(string cipherText, string passPhrase)
        {
            if (_manager == null)
            {
                throw new ArgumentNullException("Cryptography Manager");
            }

            return _manager.Decrypt(cipherText, passPhrase);
        }
    }
}
