//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using System.IO;
using NUnit.Framework;
using Sscat.Core.Config;

namespace Sscat.Tests.Config
{
	[TestFixture]
	public class MSRCardConfigurationTests
	{
		MSRCards config;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			//config = MSRCard.Deserialize(new StringReader(@"<Card Name='Default' Track1='4921190001020103' Track2='0812101171750000000000767000000' Track3='12345678901234=06051010000087524397'/>"));
			config = MSRCards.Deserialize(new StringReader(@"<MSRCards>
			<Card Name='Default' Track1='4921190001020103' Track2='0812101171750000000000767000000' Track3='12345678901234=06051010000087524397'/>
			<Card Name='WalmartMCXShoppingCard' Track1='B6010566912936155^WALMARTSHOPCARD^25010004000060013419' Track2='6010566912936155=25010004000060013419' Track3=''/>
			<Card Name='WalmartMCXMoneyCenterCard' Track1='B6032201000795248^REISSUE/TEST3^201270110000000001000169154107' Track2='6032201000795248=201270110000079' Track3=''/>
			<Card Name='WalmartMCXMoneyCenterCCPayment' Track1='B6011310002782537^PUBLIC/JOHN Q^1006101CBA812372459100234000009' Track2='6011310002782537=10061010000087524397' Track3='a960009686601131000278253700000000000001006101000000000000000000'/>
			</MSRCards>"));
		}
		
		[Test]
		public void TestCardsNameValue()
		{
			Assert.AreEqual("Default", config.Cards[0].Name);
		}
		
		[Test]
		public void TestClear()
		{
			config.Clear();
			int i = 0;
			foreach (MSRCard c in config.Cards) {
				i++;
			}
			Assert.AreEqual(0, i);
		}
		
		[Test]
		public void TestRemoveCard()
		{
            //config = MSRCard.Deserialize(new StringReader(@"<Card Name='Default' Track1='4921190001020103' Track2='0812101171750000000000767000000' Track3='12345678901234=06051010000087524397'/>"));
            config = MSRCards.Deserialize(new StringReader(@"<MSRCards>
			<Card Name='Default' Track1='4921190001020103' Track2='0812101171750000000000767000000' Track3='12345678901234=06051010000087524397'/>
			<Card Name='WalmartMCXShoppingCard' Track1='B6010566912936155^WALMARTSHOPCARD^25010004000060013419' Track2='6010566912936155=25010004000060013419' Track3=''/>
			<Card Name='WalmartMCXMoneyCenterCard' Track1='B6032201000795248^REISSUE/TEST3^201270110000000001000169154107' Track2='6032201000795248=201270110000079' Track3=''/>
			<Card Name='WalmartMCXMoneyCenterCCPayment' Track1='B6011310002782537^PUBLIC/JOHN Q^1006101CBA812372459100234000009' Track2='6011310002782537=10061010000087524397' Track3='a960009686601131000278253700000000000001006101000000000000000000'/>
			</MSRCards>"));

			MSRCard card = new MSRCard();
			card.Name = "WalmartMCXMoneyCenterCCPayment";
			foreach (MSRCard c in config.Cards) {
				if (c.Name == card.Name) {
					config.RemoveCard(c);
				}
			}
			
			int i = 0;
			foreach (MSRCard c in config.Cards) {
				i++;
			}
			Assert.AreEqual(3, i);
		}
		
		[Test]
		public void TestValidateAddedCardHasDuplicate()
		{
			MSRCard newCard = new MSRCard();
			newCard.Name = "Default";
			newCard.Track1 = "1";
			newCard.Track2 = "2";
			newCard.Track3 = "3";
			
			config.Validate();
			config.AddCard(newCard);
			
            //Assert.IsTrue(config.HasErrors);
            //Assert.AreEqual("Card name is already in use.", config.Errors.ToString());
		}
		
		[Test]
		public void TestValidateAddedCardNoError()
		{
			MSRCard newCard = new MSRCard();
			newCard.Name = "TescoUKCreditCard";
			newCard.Track1 = "1";
			newCard.Track2 = "2";
			newCard.Track3 = "3";
			
			config.Validate();
			config.AddCard(newCard);
			
			Assert.IsFalse(config.HasErrors);
		}
		
		[Test]
		public void TestValidateAddedCardMissingCardName()
		{
			MSRCard newCard = new MSRCard();
			newCard.Name = "";
			newCard.Track1 = "1";
			newCard.Track2 = "2";
			newCard.Track3 = "3";
			
			config.Validate();
			config.AddCard(newCard);
			
            //Assert.IsTrue(config.HasErrors);
            //Assert.AreEqual("Should have a card name.", config.Errors.ToString());
		}
		
		[Test]
		public void TestValidateAddedCardHasNoTrackDetails()
		{
			MSRCard newCard = new MSRCard();
			newCard.Name = "TescoUKDebitCard";
			newCard.Track1 = "";
			newCard.Track2 = "";
			newCard.Track3 = "";
			
			config.Validate();
			config.AddCard(newCard);
			
            //Assert.IsTrue(config.HasErrors);
            //Assert.AreEqual("Should contain at least one track details.", config.Errors.ToString());
		}
		
		[Test]
		public void TestValidateAddedCardHasAtLeastOneTrackDetails()
		{
			MSRCard newCard = new MSRCard();
			newCard.Name = "TescoUKDebitCard";
			newCard.Track1 = "";
			newCard.Track2 = "123456";
			newCard.Track3 = "";
			
			config.Validate();
			config.AddCard(newCard);
			
			Assert.IsFalse(config.HasErrors);
		}
		
		[Test]
		public void TestRemoveCardWithCardNameParam()
		{
			MSRCard card = new MSRCard();
			card.Name = "ASDFG";
			config.AddCard(card);
			config.RemoveCard("ASDFG");
			Assert.AreEqual(config.Contains("ASDFG"), false);
		}
		
		[Test]
		public void TestCardTrackValues()
		{
			MSRCard newCard = new MSRCard();
			newCard.Name = "SampleCard";
			newCard.Track1 = "123";
			newCard.Track2 = "456";
			newCard.Track3 = "789";
			
			Assert.AreEqual("123", newCard.Track1);
			Assert.AreEqual("456", newCard.Track2);
			Assert.AreEqual("789", newCard.Track3);
		}
		
		[Test]
		public void TestValidateCard()
		{
			MSRCard newCard = new MSRCard();
			newCard.Name = "SimpleCard";
			newCard.Track1 = "";
			newCard.Track2 = "";
			newCard.Track3 = "";
			
			newCard.Validate();
			config.AddCard(newCard);
			
			//Assert.IsTrue(config.HasErrors);			
			Assert.IsTrue(newCard.HasErrors);
		}		
//		
//		[Test]
//		public void TestValidateEditedCardWithNoErrors()
//		{
//			MSRCard newCard = new MSRCard();
//			newCard.Name = "TescoUKClubCard";
//			newCard.Track1 = "123";
//			newCard.Track2 = "456";
//			newCard.Track3 = "489";
//			
//			config.ValidateCard = newCard;
//			config.ValidateEditedCard();
//			
//			Assert.IsFalse(config.HasErrors);
//		}
//		
//		[Test]
//		public void TestValidateEditedCardHasNoTrackDetails()
//		{
//			MSRCard newCard = new MSRCard();
//			newCard.Name = "TescoUKClubCard";
//			newCard.Track1 = "";
//			newCard.Track2 = "";
//			newCard.Track3 = "";
//			
//			config.ValidateCard = newCard;
//			config.ValidateEditedCard();
//			
//			Assert.IsTrue(config.HasErrors);
//			Assert.AreEqual("- Should contain at least one track details.", config.Errors.ToString());
//		}
//		
//		[Test]
//		public void TestValidateEditedCardHasMissingCardName()
//		{
//			MSRCard newCard = new MSRCard();
//			newCard.Name = "";
//			newCard.Track1 = "";
//			newCard.Track2 = "";
//			newCard.Track3 = "489";
//			
//			config.ValidateCard = newCard;
//			config.ValidateEditedCard();
//			
//			Assert.IsTrue(config.HasErrors);
//			Assert.AreEqual("- Should have a card name.", config.Errors.ToString());
//		}
	}
}
