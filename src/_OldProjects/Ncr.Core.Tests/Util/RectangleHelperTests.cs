//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using System.Drawing;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Util
{
	[TestFixture]
	public class RectangleHelperTests
	{
		[Test]
		public void TestGetRectangle()
		{
			Assert.AreEqual(100, RectangleHelper.GetRectangle(new string[] { "0", "0", "100", "100" }).Width);
		}
		
		[Test]
		public void TestGetRectangleCenterPoint()
		{
			Point p = RectangleHelper.GetRectangleCenterPoint(100, 100, 100, 100);
			Assert.AreEqual(150, p.X);
			Assert.AreEqual(150, p.Y);
		}
	}
}
