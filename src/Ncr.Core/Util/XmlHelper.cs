// <copyright file="XmlHelper.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>

namespace Ncr.Core.Util
{
    using System;
    using System.Xml;

    /// <summary>
    /// Initializes static members of the XmlHelper class
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Escape string
        /// </summary>
        /// <param name="unescaped">non escaped string</param>
        /// <returns>Returns the escaped string</returns>
        public static string Escape(string unescaped)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement node = doc.CreateElement("root");
            node.InnerText = unescaped;
            return node.InnerXml;
        }

        /// <summary>
        /// Non escaped string
        /// </summary>
        /// <param name="escaped">escaped string</param>
        /// <returns>Returns the non escaped string</returns>
        public static string Unescape(string escaped)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement node = doc.CreateElement("root");
            node.InnerXml = escaped;
            return node.InnerText;
        }
    }
}
