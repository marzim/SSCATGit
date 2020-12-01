// <copyright file="XmlPsxDisplayRepository.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Repositories.Xml
{
    using Sscat.Core.Models.PsxDisplay;

    /// <summary>
    /// Initializes a new instance of the XmlPsxDisplayRepository class
    /// </summary>
    public class XmlPsxDisplayRepository : BaseXmlRepository<PsxDisplay>, IPsxDisplayRepository
    {
        /// <summary>
        /// Initializes a new instance of the XmlPsxDisplayRepository class
        /// </summary>
        public XmlPsxDisplayRepository()
        {
        }

        /// <summary>
        /// Loads the context
        /// </summary>
        /// <param name="context">context name</param>
        /// <returns>Returns the PSX display</returns>
        public PsxDisplay Load(string context)
        {
            switch (context)
            {
                case "EnterAlphaNumericID":
                case "EnterID":
                case "EnterPassword":
                    return Deserialize(@"C:\scot\config\SharedFontsAndControls.xml");
                default:
                    return Deserialize(@"C:\scot\config\LaunchPadPSX.xml");
            }
        }

        /// <summary>
        /// Read the file
        /// </summary>
        /// <param name="file">file to read</param>
        /// <returns>Returns the psx display</returns>
        public PsxDisplay Read(string file)
        {
            return Deserialize(file);
        }
    }
}