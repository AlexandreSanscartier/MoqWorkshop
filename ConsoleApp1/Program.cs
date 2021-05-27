namespace PokerConsole
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using PokerMoqWorkshop.Entities;
    using PokerMoqWorkshop.Entities.Enum;
    using PokerMoqWorkshop.Services;

    class Program
    {
        static void Main(string[] args)
        {
            IDeckGenerator deckGenerator = new DeckGenerator();
            var fullDeck = deckGenerator.GenerateDeck();
            List<Card> cards = new();
            cards.Add(new Card() {Suit = Suit.Hearts, Rank = 14 });
            cards.Add(new Card() {Suit = Suit.Hearts, Rank = 13 });
            cards.Add(new Card() {Suit = Suit.Hearts, Rank = 12 });
            cards.Add(new Card() {Suit = Suit.Hearts, Rank = 11 });
            cards.Add(new Card() {Suit = Suit.Hearts, Rank = 10 });

            var arrayWithOnlyNumbers = cards.Select(x => x.Rank).OrderBy(x => x).ToArray();
            var isSequential = Enumerable.Range(0, arrayWithOnlyNumbers.Count()).All(x => arrayWithOnlyNumbers[x] == arrayWithOnlyNumbers[0] + x);
            var allSameSuits = cards.Select(x => x.Suit).Distinct().Count() == 1;

            foreach(var card in cards)
            {
                Console.WriteLine(card.DisplayName);
            }
        }
    }
}
