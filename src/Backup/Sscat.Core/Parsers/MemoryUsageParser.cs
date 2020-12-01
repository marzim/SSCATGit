// <copyright file="MemoryUsageParser.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using Ncr.Core.Util;
    using Sscat.Core.Models;
    using Sscat.Core.Models.ScriptModel;

    /// <summary>
    /// Initializes a new instance of the MemoryUsageParser class
    /// </summary>
    public class MemoryUsageParser : AbstractParser
    {
        /// <summary>
        /// Memory count
        /// </summary>
        private static int _count = 0;

        /// <summary>
        /// Initializes a new instance of the MemoryUsageParser class
        /// </summary>
        public MemoryUsageParser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the MemoryUsageParser class
        /// </summary>
        /// <param name="reader">text reader</param>
        public MemoryUsageParser(IExtendedTextReader reader)
            : base("Memory Usage", reader)
        {
        }

        /// <summary>
        /// Perform the parse
        /// </summary>
        /// <param name="reader">text reader</param>
        /// <returns>Returns the script event parsed out</returns>
        public override List<IScriptEvent> PerformParse(IExtendedTextReader reader)
        {
            List<IScriptEvent> list = new List<IScriptEvent>();
            string line = string.Empty;
            string psx = @"(?<month>\d{2})+/(?<day>\d{2})+ (?<hour>\d{2})+:(?<minute>\d{2})+:(?<second>\d{2})+;(?<ms>\d{10}).* SM-AttractBase@\d+  WSS=(?<wss>\d+), PWSS=(?<pwss>\d+), PFS=(?<pfs>\d+), PPFS=(?<ppfs>\d+), PFC=(?<pfc>\d+)";
            Match match;
            while ((line = reader.ReadLine()) != null)
            {
                if ((match = Regex.Match(line, psx, RegexOptions.IgnoreCase)).Success)
                {
                    MemoryUsage performance = new MemoryUsage(
                        ++_count,
                        new DateTime(
                            DateTime.Now.Year,
                            int.Parse(match.Groups["month"].Value),
                            int.Parse(match.Groups["day"].Value),
                            int.Parse(match.Groups["hour"].Value),
                            int.Parse(match.Groups["minute"].Value),
                            int.Parse(match.Groups["second"].Value)),
                        int.Parse(match.Groups["wss"].Value),
                        int.Parse(match.Groups["pwss"].Value),
                        int.Parse(match.Groups["pfs"].Value),
                        int.Parse(match.Groups["ppfs"].Value),
                        int.Parse(match.Groups["pfc"].Value));
                    list.Add(performance);
                }
            }

            return list;
        }

        /// <summary>
        /// Perform the binary parse
        /// </summary>
        /// <param name="stream">File stream</param>
        /// <returns>Returns the script event parsed out</returns>
        public override List<IScriptEvent> PerformBinaryParse(FileStream stream)
        {
            return null;
        }
    }
}
