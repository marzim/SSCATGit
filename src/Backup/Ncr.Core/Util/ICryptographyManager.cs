// <copyright file="ICryptographyManager.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Util
{
    /// <summary>
    /// Initializes a new instance of the ICryptographyManager interface
    /// </summary>
    public interface ICryptographyManager
    {
        /// <summary>
        /// Encrypt the text
        /// </summary>
        /// <param name="plainText">plain text</param>
        /// <param name="passPhrase">pass phrase</param>
        /// <returns>Returns the encrypted text</returns>
        string Encrypt(string plainText, string passPhrase);

        /// <summary>
        /// Decrypt text
        /// </summary>
        /// <param name="cipherText">cipher text</param>
        /// <param name="passPhrase">pass phrase</param>
        /// <returns>Returns the decrypted text</returns>
        string Decrypt(string cipherText, string passPhrase);
    }
}
