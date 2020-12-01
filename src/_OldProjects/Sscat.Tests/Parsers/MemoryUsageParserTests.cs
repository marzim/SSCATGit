//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections.Generic;
using Ncr.Core.Util;
using NUnit.Framework;
using Sscat.Core.Models;
using Sscat.Core.Parsers;

namespace Sscat.Tests.Parsers
{
	[TestFixture]
	public class MemoryUsageParserTests
	{
		MemoryUsageParser p;
		MemoryUsageParser pe;
		IExtendedTextReader l;
		string s;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			p = new MemoryUsageParser();
			s = @"2104) 04/10 13:43:50;0517329450 0EAC> SM-AttractBase@723  WSS=93831168, PWSS=93831168, PFS=75730944, PPFS=75833344, PFC=101345";
			l = new ExtendedStringReader(s);
			
			pe = new MemoryUsageParser(new ExtendedStringReader(@""));
		}
		
		[Test]
		public void TestParse()
		{
			List<IScriptEvent> events = p.PerformParse(l);
			Assert.AreEqual(1, events.Count);
		}
	}
}
