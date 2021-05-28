namespace PokerConsole
{
    using System;
    using System.Collections.Generic;
    using PokerMoqWorkshop.Entities;
    using PokerMoqWorkshop.Services;
    using PokerMoqWorkshop;

    class Program
    {
        static void Main(string[] args)
        {
            var playerOne = new Player()
            {
                Name = "John Wick"
            };
            var playerTwo = new Player()
            {
                Name = "John Oliver"
            };

            var deckGenerator = new StandardDeckGenerator();
            var pokerGame = new PokerGame(deckGenerator);

            pokerGame.AddPlayer(playerOne);
            pokerGame.AddPlayer(playerTwo);

            pokerGame.Start();
            pokerGame.Flop();
            pokerGame.Turn();
            pokerGame.River();

            var pokerHandAnalyzer = new PokerHandAnalyzer();

            var playersCards = new List<IEnumerable<Card>>();
            var playerHandResult = new List<PokerHandResult>();
            for (var i = 0; i < pokerGame.Players.Count; i++)
            {
                playersCards.Add(pokerGame.GetAvailableCardsForPlayerAtIndex(i));
                playerHandResult.Add(pokerHandAnalyzer.Analyze(playersCards[i]));
            }

            for (var i = 0; i < pokerGame.Players.Count; i++)
            {
                var playerAvailableCards = playersCards[i];
                Console.WriteLine(playerHandResult[i]);
                Console.WriteLine(string.Join(", ", playerAvailableCards));
            }
        }
    }
}
