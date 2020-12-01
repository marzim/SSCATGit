//	<file>
//		<license></license>
//		<owner name="Kristian Duray" email="kristian.duray@ncr.com"/>
//		<owner name="Apple Leo Chiong" email="Apple_Leo_Derilo.Chiong@ncr.com"/>
//	</file>

using System;
using NUnit.Framework;
using Sscat.Core.Config;
using Sscat.Core.Gui;
	
namespace Sscat.Tests.Gui
{
	[TestFixture]
	public class CardFormTests
	{
		MSRCard card;
		
		[SetUp]
		public void Setup()
		{
			card = new MSRCard();
			card.Name = "TestCard";
			card.Track1 = "123456";
			card.Track2 = "123456";
			card.Track3 = "123456";	
		}
		
		[Test]
		public void TestCardFormWithCardParameter()
		{	
			CardForm form = new CardForm(card);
			form.ClickOKButton();
			
			Assert.AreEqual("123456", card.Track1);
		}
		
		[Test]
		public void TestCardFormWithCardParameter2()
		{	
			CardForm form = new CardForm(card, true, "note");
		}		
	}
}
