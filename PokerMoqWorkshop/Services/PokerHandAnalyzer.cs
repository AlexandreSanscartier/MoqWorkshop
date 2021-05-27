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
                HighestCard = highestCard
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
            return containsRoyalFlushNumbers && this.isSuitAllTheSame(hand);
        }

        private bool isStraightFlush(IEnumerable<Card> hand)
        {
            var cardRanks = hand.Select(x => x.Rank).OrderBy(x => x).ToArray();
            var isSequential = Enumerable.Range(0, cardRanks.Count()).All(x => cardRanks[x] == cardRanks[0] + x);
            return isSequential && this.isSuitAllTheSame(hand);
        }

        private bool isFourOfAKind(IEnumerable<Card> hand)
        {
            return false;
        }

        private bool isFullHouse(IEnumerable<Card> hand)
        {
            return false;
        }

        private bool isFlush(IEnumerable<Card> hand)
        {
            return false;
        }

        private bool isStraight(IEnumerable<Card> hand)
        {
            return false;
        }

        private bool isThreeOfAKind(IEnumerable<Card> hand)
        {
            return false;
        }
        private bool isTwoPair(IEnumerable<Card> hand)
        {
            return false;
        }
        private bool  isPair(IEnumerable<Card> hand)
        {
            return false;
        }

        private bool isSuitAllTheSame(IEnumerable<Card> hand)
        {
            return hand.Select(x => x.Suit).Distinct().Count() == 1; 
        }
    }
}
