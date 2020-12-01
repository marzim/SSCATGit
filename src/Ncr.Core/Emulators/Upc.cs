// <copyright file="Upc.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Ncr.Core.Emulators
{
    using Microsoft.Win32;
    using Ncr.Core.Util;

    /// <summary>
    /// Initializes a new instance of the Upc class
    /// </summary>
    public class Upc
    {
        /// <summary>
        /// UPC tag
        /// </summary>
        private string _tag;

        /// <summary>
        /// OPOS code
        /// </summary>
        private string _oposCode;

        /// <summary>
        /// Initializes a new instance of the Upc class
        /// </summary>
        public Upc()
        {
        }

        /// <summary>
        /// Gets or sets the tag
        /// </summary>
        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        /// <summary>
        /// Gets or sets the OPOS code
        /// </summary>
        public string OposCode
        {
            get { return _oposCode; }
            set { _oposCode = value; }
        }

        /// <summary>
        /// Gets the item name
        /// </summary>
        public string ItemName
        {
            get
            {
                string itemName = GetItemValue();
                if (itemName == null || itemName == string.Empty || itemName == string.Empty)
                {
                    return "SSCATTestItem";
                }

                return itemName;
            }
        }

        /// <summary>
        /// Decode the scan code
        /// </summary>
        /// <param name="code">scan code</param>
        /// <returns>Returns the decoded scan code</returns>
        public static Upc Decode(string code)
        {
            Upc u = new Upc();
            string[] splittedUpc = code.Split('~');
            u.Tag = splittedUpc[1].Trim();
            u.OposCode = splittedUpc[2].Trim();
            return u;
        }

        /// <summary>
        /// Checks whether the code is an operator
        /// </summary>
        /// <param name="code">scan code</param>
        /// <returns>Returns true if operator, false otherwise</returns>
        public static bool IsOperator(string code)
        {
            try
            {
                string[] splittedUpc = code.Split('~');
                if (splittedUpc[3].Equals("1"))
                {
                    return true;
                }
            }
            catch
            {
            }

            return false;
        }

        /// <summary>
        /// Get the trimmed tag
        /// </summary>
        /// <returns>Returns the trimmed tag</returns>
        public string GetTrimmedTag()
        {
            if (OposCode == "101" || OposCode == "103" || OposCode == "104")
            {
                return Tag.Substring(0, _tag.Length - 1);
            }
            else if (OposCode == "111")
            {
                return string.Format("{0}+{1}", Tag.Substring(0, 11), Tag.Substring(12, 2));
            }
            else if (OposCode == "112")
            {
                return string.Format("{0}+{1}", Tag.Substring(0, 7), Tag.Substring(7, 2));
            }
            else if (OposCode == "119")
            {
                return string.Format("{0}+{1}", Tag.Substring(0, 12), Tag.Substring(13, 2));
            }
            else
            {
                return Tag;
            }
        }

        /// <summary>
        /// Get the symbology
        /// </summary>
        /// <returns>Returns the symbology</returns>
        public string GetSymbology()
        {
            switch (OposCode)
            {
                case "101": return "UPC-A"; // tag.Length - 1
                case "102": return "UPC-E";
                case "103": return "EAN-8/JAN-8"; // tag.Length - 1
                case "104": return "EAN-13/JAN-13"; // tag.Length - 1
                case "108": return "Code 39"; // parsing should include /, $, %, -, alphanumeric, +
                case "109": return "Code 39"; // parsing should include /, $, %, -, alphanumeric, +
                case "110": return "Code 128";
                case "111": return "UPC-A Supplement";
                case "112": return "UPC-E Supplement";
                case "119": return "EAN-13/JAN-13 Supplement";
                case "131": return "Databar/RSS";
                case "132": return "Databar/RSS Expanded";
                default: return "Code 128";
            }
        }

        /// <summary>
        /// Formats string to include UPC information
        /// </summary>
        /// <returns>Returns the formatted string</returns>
        public override string ToString()
        {
            return string.Format("[Upc Tag={0}, OposCode={1}, TrimmedTag={2}, Symbology={3}]", _tag, _oposCode, GetTrimmedTag(), GetSymbology());
        }

        /// <summary>
        /// Get the item value
        /// </summary>
        /// <returns>Returns the item value</returns>
        private string GetItemValue()
        {
            string symbologiesKeyADD = string.Format(@"{0}{1}\Barcodes", GetSymbology(), RegistryAddress.SymbologiesKeyADD);
            string symbologiesKeyCADD = string.Format(@"{0}{1}\Barcodes", GetSymbology(), RegistryAddress.SymbologiesKeyCADD);
            if (RegistryHelper.Exists(symbologiesKeyADD, Registry.LocalMachine))
            {
                return RegistryHelper.GetValue(GetTrimmedTag(), Registry.LocalMachine.OpenSubKey(symbologiesKeyADD));
            }
            else if (RegistryHelper.Exists(symbologiesKeyCADD, Registry.LocalMachine))
            {
                return RegistryHelper.GetValue(GetTrimmedTag(), Registry.LocalMachine.OpenSubKey(symbologiesKeyCADD));
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
