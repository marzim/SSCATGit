#if TEST

using System;
using NUnit.Framework;
using Sscat.Core.Config;

namespace Sscat.Tests.Config
{
	[TestFixture]
	public class MSRCardsTest
	{
		MSRCards objMSRCards;
		MSRCards objMSRCards2;
//	
		[Test]
		public void TestSuccessfulAddingOfMSCard()
		{
			MSRCard card = new MSRCard();
			card.Name = "TestCard";
			card.Track1 = "8437836778595";
			card.Track2 = "8437836778595";
			card.Track2 = "8437836778595";
			
			objMSRCards.AddCard(card);
			Assert.IsTrue(objMSRCards.Cards.Length == 1);
		}
		
		[Test]
		public void TestClearingTheListOfMSCards()
		{
			objMSRCards.Clear();
			Assert.IsTrue(objMSRCards.Cards.Length == 0);
		}
		
		[Test]
		public void TestSuccessfulSearchingOfMSCard()
		{
			MSRCard card = new MSRCard();
			card.Name = "TestCard";
			card.Track1 = "8437836778595";
			card.Track2 = "8437836778595";
			card.Track2 = "8437836778595";
			
			objMSRCards.AddCard(card);
			Assert.IsTrue(objMSRCards.Contains("TestCard"));
		}
		
		[Test]
		public void TestUnsuccessfulSearchingOfMSCard()
		{
			objMSRCards.Clear();
			Assert.IsFalse(objMSRCards.Contains("TestCard"));
		}
		
		[Test]
		public void TestSuccessfulRemovalOfAnMSCard()
		{
			MSRCard card = new MSRCard();
			card.Name = "TestCard";
			card.Track1 = "8437836778595";
			card.Track2 = "8437836778595";
			card.Track2 = "8437836778595";
			
			objMSRCards.RemoveCard("TestCard");
			Assert.IsFalse(objMSRCards.Contains("TestCard"));
		}
		
		[Test]
		public void TestRemoveCardWithCardParam()
		{
			objMSRCards.Clear();
			
			MSRCard card = new MSRCard();
			card.Name = "TestCard";
			card.Track1 = "8437836778595";
			card.Track2 = "8437836778595";
			card.Track2 = "8437836778595";
			
			objMSRCards.AddCard(card);
			Assert.AreEqual(1, objMSRCards.Cards.Length);
			objMSRCards.RemoveCard(card);
			Assert.AreEqual(0, objMSRCards.Cards.Length);
		}

		[Test]
		public void TestSetCard()
		{	
			objMSRCards2 = new MSRCards();
			MSRCard card = new MSRCard();
			card.Name = "TestCard";
			card.Track1 = "8437836778595";
			card.Track2 = "8437836778595";
			card.Track2 = "8437836778595";	
			
			objMSRCards2.Cards = new MSRCard[1];
			objMSRCards2.Cards[0] = card;

			Assert.AreEqual(1, objMSRCards2.Cards.Length);
		}			

		[Test]
		public void TestGetNullCard()
		{	
			objMSRCards2 = new MSRCards();
			Assert.AreEqual(new MSRCard[0], objMSRCards2.Cards);
		}		
		
		[TestFixtureSetUp]
		public void Init()
		{
			objMSRCards = new MSRCards();
		}
		
		[TestFixtureTearDown]
		public void Dispose()
		{
			objMSRCards = null;
		}
	}
}
#endif
