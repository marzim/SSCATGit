//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class XmlHelperTests
	{
		[Test]
		public void TestEscape()
		{
			Assert.AreEqual("&amp;", XmlHelper.Escape("&"));
		}
		
		[Test]
		public void TestUnescape()
		{
			Assert.AreEqual("&", XmlHelper.Unescape("&amp;"));
		}
	}
}
