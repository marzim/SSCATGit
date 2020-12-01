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
	public class WorkbenchSettingsEventArgsTests
	{
		WorkbenchSettingsEventArgs w;
		
		[SetUp]
		public void Setup()
		{
			w = new WorkbenchSettingsEventArgs(new WorkbenchSettings());
		}
		
		[Test]
		public void TestValues()
		{
			Assert.IsNotNull(w.Settings);
		}
	}
}
