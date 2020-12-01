//	<file>
//		<license></license>
//		<owner name="Ian Escarro" email="ian.escarro@ncr.com"/>
//	</file>

using System;
using Ncr.Core.Emulators;
using Ncr.Core.Tests.Util;
using Ncr.Core.Util;
using NUnit.Framework;

namespace Ncr.Core.Tests.Emulators
{
	[TestFixture]
	public class BagScaleTests
	{
		BagScale s;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			ApiHelper.Attach(new ApiManagerStub());
			RegistryHelper.Attach(new RegistryManagerStub());
			
			s = new BagScale();
		}
		
		[Test]
		public void Tear()
		{
			s.Tear();
		}
		
		[Test]
		public void TestWeigh()
		{
			s.Weigh(400, 5000);
		}
		
		[Test]
		public void TestGetWeight()
		{
			Assert.AreEqual(0, s.Weight);
		}
		
		[Test]
		public void TestBagScaleKilogramUnit()
		{
			s.Weigh(500, 5000);
		}
		
		[Test]
		public void TestWeighInGram()
		{
			BagScaleGram s = new BagScaleGram();
			s.Weigh(500, 500);
		}		
		
		[Test]
		public void TestConvertGram()
		{
			BagScaleGram s = new BagScaleGram();
			Assert.AreEqual(226796, s.ConvertToPounds(500));
		}
		
		[Test]
		public void TestConvertKiloGram()
		{
			BagScaleKiloGram s = new BagScaleKiloGram();
			Assert.AreEqual(226, s.ConvertToPounds(500));
		}

		[Test]
		public void TestConvertOunce()
		{
			BagScaleOunce s = new BagScaleOunce();
			Assert.AreEqual(8000, s.ConvertToPounds(500));		
		}
		
		[Test]
		public void TestConvertPound()
		{
			BagScalePound s = new BagScalePound();
			Assert.AreEqual(500, s.ConvertToPounds(500));	
		}
		
		[Test]
		public void TestConvertWithException()
		{
			BagScaleException s = new BagScaleException();
            Assert.That(() => s.ConvertToPounds(500),
                Throws.TypeOf<Exception>());
		}		
	}
	
	public class BagScaleGram : BagScale
	{
		public override string GetBagScaleUnit()
		{
			return "1";
		}
	}
	
	public class BagScaleKiloGram : BagScale
	{
		public override string GetBagScaleUnit()
		{
			return "2";
		}
	}
	
	public class BagScaleOunce : BagScale
	{
		public override string GetBagScaleUnit()
		{
			return "3";
		}
	}
	
	public class BagScalePound : BagScale
	{
		public override string GetBagScaleUnit()
		{
			return "4";
		}
	}
	
	public class BagScaleException : BagScale
	{
		public override string GetBagScaleUnit()
		{
			return "5";
		}
	}
}
