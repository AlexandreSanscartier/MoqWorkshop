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
            var score = this.getPokerHandScore(hand);
            return new PokerHandResult()
            {
                HandType = handType,
                HighestCardRank = highestCard.Rank,
                Score = score
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

        private int getPokerHandScore(IEnumerable<Card> hand)
        {
            if (this.isRoyalFlush(hand)) return this.getRoyalFlushScore(hand);
            if (this.isStraightFlush(hand)) return this.getStraightFlushScore(hand);
            if (this.isFourOfAKind(hand)) return this.getFourOfAKindScore(hand);
            if (this.isFullHouse(hand)) return this.getFullHouseScore(hand);
            if (this.isFlush(hand)) return this.getFlushScore(hand);
            if (this.isStraight(hand)) return this.getStraightScore(hand);
            if (this.isThreeOfAKind(hand)) return this.getThreeOfAKindScore(hand);
            if (this.isTwoPair(hand)) return this.getTwoPairScore(hand);
            if (this.isPair(hand)) return this.getPairScore(hand);
            return this.getHighCardScore(hand);
        }

        private bool isRoyalFlush(IEnumerable<Card> hand)
        {
            var royalFlush = new List<int>() { 14, 13, 12, 11, 10 };
            var containsRoyalFlushNumbers = hand.Select(x => x.Rank).All(royalFlush.Contains);
            return containsRoyalFlushNumbers && this.areSuitsAllSame(hand);
        }

        private int getRoyalFlushScore(IEnumerable<Card> hand)
        {
            return 0;
        }

        private bool isStraightFlush(IEnumerable<Card> hand)
        {
            return this.areCardsSequential(hand) && this.areSuitsAllSame(hand);
        }

        private int getStraightFlushScore(IEnumerable<Card> hand)
        {
            var cardRanks = hand.Select(x => x.Rank).Distinct().OrderBy(x => x).ToArray();
            var sequentialCount = 0;
            var maxRank = int.MinValue;
            for (var i = 1; i < cardRanks.Length; i++)
            {
                var previousCardRank = cardRanks[i - 1];
                var currentCardRank = cardRanks[i];
                if (currentCardRank - previousCardRank == 1)
                {
                    sequentialCount++;
                    maxRank = currentCardRank;
                }
                else
                {
                    sequentialCount = 0;
                    if(sequentialCount <= 4)
                    {
                        maxRank = int.MinValue;
                    }
                }
            }
            return maxRank;
        }

        private bool isFourOfAKind(IEnumerable<Card> hand)
        {
             return hand.GroupBy(x => x.Rank).Any(x => x.Count() >= 4);
        }

        private int getFourOfAKindScore(IEnumerable<Card> hand)
        {
            return hand.GroupBy(x => x.Rank).Where(x => x.Count() >= 4).Select(x => x.Key).FirstOrDefault();
        }

        private bool isFullHouse(IEnumerable<Card> hand)
        {
            var cardGroups = hand.GroupBy(x => x.Rank);
            return cardGroups.Where(x => x.Count() >= 2).Count() >= 2 && cardGroups.Where(x => x.Count() >= 3).Count() >= 1;
        }

        private int getFullHouseScore(IEnumerable<Card> hand)
        {
            var cardGroups = hand.GroupBy(x => x.Rank);
            var cardThrees = cardGroups.Where(x => x.Count() >= 3).Max(x => x.Key);
            var cardPairs = cardGroups.Where(x => x.Key != cardThrees).Where(x => x.Count() >= 2).Max(x => x.Key);
            var sum = int.Parse(string.Format("{0}{1}", cardThrees, cardPairs));
            return sum;
        }

        private bool isFlush(IEnumerable<Card> hand)
        {
            return this.areSuitsAllSame(hand);
        }

        private int getFlushScore(IEnumerable<Card> hand)
        {
            var cardRanks = hand.Select(x => x.Rank).Distinct().OrderBy(x => x).ToArray();
            var sequentialCount = 0;
            var maxRank = int.MinValue;
            for (var i = 1; i < cardRanks.Length; i++)
            {
                var previousCardRank = cardRanks[i - 1];
                var currentCardRank = cardRanks[i];
                if (currentCardRank - previousCardRank == 1)
                {
                    sequentialCount++;
                    maxRank = currentCardRank;
                }
                else
                {
                    sequentialCount = 0;
                    if (sequentialCount <= 4)
                    {
                        maxRank = int.MinValue;
                    }
                }
            }
            return maxRank;
        }

        private bool isStraight(IEnumerable<Card> hand)
        {
            return this.areCardsSequential(hand);
        }

        private int getStraightScore(IEnumerable<Card> hand)
        {
            var cardRanks = hand.Select(x => x.Rank).Distinct().OrderBy(x => x).ToArray();
            var sequentialCount = 0;
            var maxRank = int.MinValue;
            for (var i = 1; i < cardRanks.Length; i++)
            {
                var previousCardRank = cardRanks[i - 1];
                var currentCardRank = cardRanks[i];
                if (currentCardRank - previousCardRank == 1)
                {
                    sequentialCount++;
                    maxRank = currentCardRank;
                }
                else
                {
                    sequentialCount = 0;
                    if (sequentialCount <= 4)
                    {
                        maxRank = int.MinValue;
                    }
                }
            }
            return maxRank;
        }

        private bool isThreeOfAKind(IEnumerable<Card> hand)
        {
            return hand.GroupBy(x => x.Rank).Any(x => x.Count() >= 3);
        }

        private int getThreeOfAKindScore(IEnumerable<Card> hand)
        {
            return hand.GroupBy(x => x.Rank).Where(x => x.Count() >= 3).Max(x => x.Key);
        }

        private bool isTwoPair(IEnumerable<Card> hand)
        {
            return hand.GroupBy(x => x.Rank).Where(x => x.Count() >= 2).Count() >= 2;
        }

        private int getTwoPairScore(IEnumerable<Card> hand)
        {
            var orderedPairs = hand.GroupBy(x => x.Rank).Where(x => x.Count() >= 2).OrderByDescending(x => x.Key);
            var largestPair = orderedPairs.Select(x => x.Key).First();
            var secondLargestPair = orderedPairs.Select(x => x.Key).Skip(1).First();
            var sum = int.Parse(string.Format("{0}{1}", largestPair, secondLargestPair));
            return sum;
        }

        private bool isPair(IEnumerable<Card> hand)
        {
            return hand.GroupBy(x => x.Rank).Any(x => x.Count() == 2);
        }

        private int getPairScore(IEnumerable<Card> hand)
        {
            var orderedPairs = hand.GroupBy(x => x.Rank).Where(x => x.Count() == 2).OrderBy(x => x.Key);
            return orderedPairs.Select(x => x.Key).First();
        }

        private int getHighCardScore(IEnumerable<Card> hand)
        {
            return hand.Max(x => x.Rank);
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
        }
    }
}
