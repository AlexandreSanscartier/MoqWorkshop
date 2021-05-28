namespace PokerMoqWorkshop.Services
{
    using PokerMoqWorkshop.Entities;
    using PokerMoqWorkshop.Entities.Enum;
    using System;
    using System.Collections.Generic;

    // <inheritdoc>
    public class StandardDeckGenerator : IDeckGenerator
    {
        // <inheritdoc>
        public IEnumerable<Card> GenerateDeck()
        {
            var deck = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (var i = 2; i < 15; i++)
                {
                    deck.Add(new Card()
                    {
                        Suit = suit,
                        Rank = i
                    });
                }
            }
            return deck;
        }
    }
}
