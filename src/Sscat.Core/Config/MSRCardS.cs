// <copyright file="MSRCards.cs" company="NCR">
//     Copyright 2017 NCR Corporation. All rights reserved.
// </copyright>
namespace Sscat.Core.Config
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Ncr.Core.Models;

    /// <summary>
    /// Initializes a new instance of the MSRCards class
    /// </summary>
    [XmlRoot("MSRCards"), Serializable()]
    public class MSRCards : BaseModel<MSRCards>
    {
        /// <summary>
        /// MSR cards
        /// </summary>
        private MSRCard[] _cards;

        /// <summary>
        /// Initializes a new instance of the MSRCards class
        /// </summary>
        public MSRCards()
        {
        }

        /// <summary>
        /// Gets or sets the MSR cards
        /// </summary>
        [XmlElement("Card")]
        public MSRCard[] Cards
        {
            get
            {
                if (_cards == null)
                {
                    return new MSRCard[0];
                }

                return _cards;
            }

            set
            {
                _cards = value;
            }
        }

        /// <summary>
        /// Adds an MSR card
        /// </summary>
        /// <param name="card">MSR card</param>
        public void AddCard(MSRCard card)
        {
            List<MSRCard> c = new List<MSRCard>(Cards);
            c.Add(card);
            _cards = new MSRCard[c.Count];
            c.CopyTo(_cards);
        }

        /// <summary>
        /// Removes an MSR card
        /// </summary>
        /// <param name="card">MSR card</param>
        public void RemoveCard(MSRCard card)
        {
            List<MSRCard> c = new List<MSRCard>(Cards);
            c.Remove(card);
            _cards = new MSRCard[c.Count];
            c.CopyTo(_cards);
        }

        /// <summary>
        /// Adds an MSR card
        /// </summary>
        /// <param name="cardName">MSR card name</param>
        public void RemoveCard(string cardName)
        {
            List<MSRCard> listMSCards = new List<MSRCard>(Cards);
            bool isCardFound = false;
            foreach (MSRCard card in listMSCards)
            {
                if (card.Name.Trim().ToLower().Equals(cardName.Trim().ToLower()))
                {
                    listMSCards.Remove(card);
                    isCardFound = true;
                    break;
                }
            }

            if (isCardFound)
            {
                _cards = new MSRCard[listMSCards.Count];
                listMSCards.CopyTo(_cards);
            }
        }

        /// <summary>
        /// Clears the list of MSR cards
        /// </summary>
        public void Clear()
        {
            _cards = new MSRCard[0];
        }

        /// <summary>
        /// Checks to see if MSR card list contains the given card name
        /// </summary>
        /// <param name="cardName">name of the card</param>
        /// <returns>Returns true if found, false otherwise</returns>
        public bool Contains(string cardName)
        {
            bool retValue = false;
            List<MSRCard> msrCardList = new List<MSRCard>(_cards);
            MSRCard msrCardName = msrCardList.Find(delegate(MSRCard msrCard) { return msrCard.Name == cardName; });

            if (msrCardName != null)
            {
                retValue = true;
            }

            return retValue;
        }
    }    
}
