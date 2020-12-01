//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Models;
using Sscat.Gui;
using Sscat.Tests.Config;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class MSCardSelectionFormTests
	{
		MSCardSelectionForm form;
		LaneConfiguration config;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			config = new LaneConfigurationRepositoryStub().Read("");
		}
		
		[Test]
		public void TestContructor()
		{
			Assert.That(() => form = new MSCardSelectionForm(config),
                Throws.TypeOf<NullReferenceException>());
		}
	}
}
