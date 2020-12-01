//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Models;

namespace Sscat.Tests.Models
{
	[TestFixture]
	public class ReportEventArgsTests
	{
		ReportEventArgs e;
		
		[SetUp]
		public void Setup()
		{
			e = new ReportEventArgs(new Report());
		}
		
		[Test]
		public void TestReport()
		{
			Assert.IsNotNull(e.Report);
		}
	}
}
