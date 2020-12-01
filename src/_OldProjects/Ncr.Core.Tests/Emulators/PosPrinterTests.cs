//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class PosPrinterTests
	{
		POSPrinter p;
		
		[OneTimeSetUp]
		public void Setup()
		{	
			p = new POSPrinter();
		}
		
		[Test]
		public void TestPrinting()
		{
			p.Printing(5000);
		}

		[Test]
		public void TestCoverOpen()
		{
			p.CoverOpen(5000);
		}
	}
}
