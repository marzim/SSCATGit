//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.IO;

using NUnit.Framework;
using Sscat.Core.Parsers;
using Sscat.Core.Util;

namespace Sscat.Tests.Parsers
{
	[TestFixture]
	public class CsvParserTests
	{
		string csv;
		CsvParser parser;
		
		[SetUp]
		public void Setup()
		{
			csv = "1,2,4,5,6,7";
			parser = new CsvParser();
		}
		
		[Test]
		public void TestParse()
		{
			ArrayList lines = parser.Parse(new StringReader(csv));
			Assert.AreEqual(1, lines.Count);
			Assert.IsInstanceOfType(new ArrayList().GetType(), lines[0]);
			ArrayList cols = lines[0] as ArrayList;
			Assert.AreEqual(6, cols.Count);
		}
	}
}
