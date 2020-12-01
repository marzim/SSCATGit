//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Models;
using Sscat.Gui;

namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class MSRCardFormTests
	{
		MSRCardForm form;
		MSRCard card;
		
		[OneTimeSetUp]
        public void OneTimeSetUp()
		{
			card = new MSRCard();
			card.Track1 = "123";
			card.Track2 = "123";
			card.Track3 = "123";
			card.Name = "Card 123";			
		}
		
		[Test]
		public void TestEmptyContructor()
		{
			form = new MSRCardForm();
		}
		
		[Test]
		public void TestContructorWithCard()
		{
			form = new MSRCardForm(card);
		}		
		
		[Test]
		public void TestSetAndGetCard()
		{
			MSRCard card2 = new MSRCard();
			card2.Track1 = "1234";
			card2.Track2 = "1234";
			card2.Track3 = "1234";
			card2.Name = "Card 1234";			
			form = new MSRCardForm(card);
			form.Card = card2;
			Assert.AreEqual(card2, form.Card);
			Assert.AreEqual("1234", form.Card.Track1);
			Assert.AreEqual("1234", form.Card.Track2);
			Assert.AreEqual("1234", form.Card.Track3);
			Assert.AreEqual("Card 1234", form.Card.Name);
		}
		
		[Test]
		public void TestButtonOk()
		{
			form = new MSRCardForm(card);
			form.ButtonOKClick(new object(), new EventArgs());
		}		
		
		[Test]
		public void TestDispose()
		{
			form = new MSRCardForm(card);
			form.Dispose();
		}		
	}
}
