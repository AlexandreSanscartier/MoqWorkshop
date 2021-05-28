namespace PokerMoqWorkshop.Services
{
    using System.Linq;
    using System.Collections.Generic;
    using PokerMoqWorkshop.Entities;
    using PokerMoqWorkshop.Entities.Enum;

    // <inheritdoc>
    public class PokerHandAnalyzer : IPokerHandAnalyzer
    {
        // <inheritdoc>
        public PokerHandResult Analyze(IEnumerable<Card> hand)
        {
            var highestCard = this.getHighestCard(hand);
            var handType = this.getHandType(hand);
            return new PokerHandResult()
            {
                HandType = handType,
                HighestCardRank = highestCard.Rank
            };
        }

        private Card getHighestCard(IEnumerable<Card> hand)
        {
            return hand.Aggregate((x, y) => x.Rank > y.Rank ? x : y);
        }

        private HandType getHandType(IEnumerable<Card> hand)
        {
            if (this.isRoyalFlush(hand)) return HandType.RoyalFlush;
            if (this.isStraightFlush(hand)) return HandType.StraightFlush;
            if (this.isFourOfAKind(hand)) return HandType.FourOfAKind;
            if (this.isFullHouse(hand)) return HandType.FullHouse;
            if (this.isFlush(hand)) return HandType.Flush;
            if (this.isStraight(hand)) return HandType.Straight;
            if (this.isThreeOfAKind(hand)) return HandType.ThreeOfAKind;
            if (this.isTwoPair(hand)) return HandType.TwoPair;
            if (this.isPair(hand)) return HandType.Pair;
            return HandType.HighCard;
        }

        private bool isRoyalFlush(IEnumerable<Card> hand)
        {
            var royalFlush = new List<int>() { 14, 13, 12, 11, 10 };
            var containsRoyalFlushNumbers = hand.Select(x => x.Rank).All(royalFlush.Contains);
            return containsRoyalFlushNumbers && this.areSuitsAllSame(hand);
        }

        private bool isStraightFlush(IEnumerable<Card> hand)
        {
            return this.areCardsSequential(hand) && this.areSuitsAllSame(hand);
        }

        private bool isFourOfAKind(IEnumerable<Card> hand)
        {
             return hand.GroupBy(x => x.Rank).Any(x => x.Count() >= 4);
        }

        private bool isFullHouse(IEnumerable<Card> hand)
        {
            var cardGroups = hand.GroupBy(x => x.Rank);
            return cardGroups.Where(x => x.Count() >= 2).Count() >= 2 && cardGroups.Where(x => x.Count() >= 3).Count() >= 1;
        }

        private bool isFlush(IEnumerable<Card> hand)
        {
            return this.areSuitsAllSame(hand);
        }

        private bool isStraight(IEnumerable<Card> hand)
        {
            return this.areCardsSequential(hand);
        }

        private bool isThreeOfAKind(IEnumerable<Card> hand)
        {
            return hand.GroupBy(x => x.Rank).Any(x => x.Count() >= 3);
        }
        private bool isTwoPair(IEnumerable<Card> hand)
        {
            return hand.GroupBy(x => x.Rank).Where(x => x.Count() >= 2).Count() >= 2;
        }
        private bool isPair(IEnumerable<Card> hand)
        {
            return hand.GroupBy(x => x.Rank).Any(x => x.Count() == 2);
        }

        private bool areSuitsAllSame(IEnumerable<Card> hand)
        {
            return hand.Select(x => x.Suit).Distinct().Count() == 1; 
        }

        private bool areCardsSequential(IEnumerable<Card> hand)
        {
            var cardRanks = hand.Select(x => x.Rank).Distinct().OrderBy(x => x).ToArray();
            var sequentialCount = 0;
            for(var i = 1; i < cardRanks.Length; i++) 
            {
                var previousCardRank = cardRanks[i - 1];
                var currentCardRank = cardRanks[i];
                if(currentCardRank - previousCardRank == 1)
                {
                    sequentialCount++;
                } else
                {
                    sequentialCount = 0;
                }
            }
            return sequentialCount >= 4;
            //return Enumerable.Range(0, cardRanks.Count()).All(x => cardRanks[x] == cardRanks[0] + x);
        }
    }
}
