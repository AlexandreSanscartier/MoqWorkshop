namespace PokerMoqWorkshop
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using PokerMoqWorkshop.Entities;
    using PokerMoqWorkshop.Services;

    public class PokerGame
    {
        private IDeckGenerator deckGenerator;
        private List<Card> deckOfCards;

        public List<Player> Players { private set; get; } = new();
        public List<Card> CardsOnTable { private set; get; } = new();

        public PokerGame(IDeckGenerator deckGenerator)
        {
            this.deckGenerator = deckGenerator;
        }

        public void Start()
        {
            this.deckOfCards = (List<Card>)this.deckGenerator.GenerateDeck();
            this.Shuffle();
            this.dealCardsToPlayers();
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            this.deckOfCards =  this.deckOfCards.OrderBy(x => rnd.Next()).ToList();
        }

        public void Flop()
        {
            this.CardsOnTable.Add(this.draw());
            this.CardsOnTable.Add(this.draw());
            this.CardsOnTable.Add(this.draw());
        }

        public void Turn()
        {
            this.CardsOnTable.Add(this.draw());
        }

        public void River()
        {
            this.CardsOnTable.Add(this.draw());
        }

        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }

        public IEnumerable<Card> GetAvailableCardsForPlayerAtIndex(int index)
        {
            return this.Players[index].Hand.Concat(this.CardsOnTable);
        }

        private Card draw()
        {
            if (this.deckOfCards.Count() >= 1)
            {
                var drawnCard = this.deckOfCards[0];
                this.deckOfCards.RemoveAt(0);
                return drawnCard;
            }
            return null;
        }

        private void dealCardsToPlayers()
        {
            for (var i = 0; i < 2; i++)
            {
                foreach (var player in this.Players)
                {
                    player.AddCardToHand(this.draw());
                }
            }
        }
    }
}
