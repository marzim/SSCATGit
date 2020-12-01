//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Views;
using NUnit.Framework;

namespace Ncr.Core.Tests.Views
{
	[TestFixture]
	public class WorkbenchSettingsTests
	{
		WorkbenchSettings s;
		
		[SetUp]
		public void Setup()
		{
			s = new WorkbenchSettings();
			s.Location = "4,4";
			s.Size = "100,100";
		}
		
		[Test]
		public void TestValues()
		{
			Assert.AreEqual("4,4", s.Location);
			Assert.AreEqual("100,100", s.Size);
		}
	}
}
