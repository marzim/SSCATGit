/*
 * Created by SharpDevelop.
 * User: scot
 * Date: 8/1/2013
 * Time: 8:11 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
#if TEST

using System;
using NUnit.Framework;
using Sscat.Core.Config;

namespace Sscat.Tests.Config
{
	[TestFixture]
	public class MSRCardTest
	{
		MSRCard objMSRCard;
		
		[Test]
		public void TestSuccessfulValidationOfMSCard()
		{
			objMSRCard.Validate();
			Assert.IsFalse(objMSRCard.HasErrors);
		}

		[Test]
		public void TestUnsuccessfulValidationOfMSCard()
		{
			MSRCard card = new MSRCard();
			card.Validate();
			Assert.IsTrue(objMSRCard.HasErrors);
		}
		
		[TestFixtureSetUp]
		public void Init()
		{
			objMSRCard = new MSRCard();
			objMSRCard.Name = "TestCard";
			objMSRCard.Track1 = "8437836778595";
			objMSRCard.Track2 = "8437836778595";
			objMSRCard.Track2 = "8437836778595";			
		}
		
		[TestFixtureTearDown]
		public void Dispose()
		{
			objMSRCard = null;
		}
	}
}
#endif
