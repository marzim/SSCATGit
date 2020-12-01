//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Views;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class GeneratorPaneTests
	{
		GeneratorPane p;
		
		[SetUp]
		public void Setup()
		{
			p = new GeneratorPane();
			p.Configuration = new GeneratorConfiguration();
		}
		
//		[Test]
//		public void TestGenerate()
//		{
//			p.PerformGenerate();
//		}
	}
}
