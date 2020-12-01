//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Collections;
using System.IO;

namespace Sscat.Core.Parsers
{
	public class CsvParser
	{
		public CsvParser()
		{
		}
		
		public ArrayList Parse(TextReader reader)
		{
			ArrayList list = new ArrayList();
			string line = "";
			while ((line = reader.ReadLine()) != null) {
				list.Add(new ArrayList(line.Split(new char[] { ',' })));
			}
			return list;
		}
	}
}
