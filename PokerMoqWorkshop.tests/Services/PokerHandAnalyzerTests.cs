namespace PokerMoqWorkshop.tests.Services
{
    using System.Linq;
    using PokerMoqWorkshop.Entities;
    using PokerMoqWorkshop.Entities.Enum;
    using PokerMoqWorkshop.Services;
    using System.Collections.Generic;
    using Xunit;
    public class PokerHandAnalyzerTests
    {
        private readonly IPokerHandAnalyzer pokerHandAnalyzer;

        public PokerHandAnalyzerTests()
        {
            this.pokerHandAnalyzer = new PokerHandAnalyzer();
        }

        [Theory]
        [InlineData(Suit.Clubs)]
        [InlineData(Suit.Diamonds)]
        [InlineData(Suit.Hearts)]
        [InlineData(Suit.Spades)]
        public void Analyze_Successfully_ReturnsRoyalFlush(Suit suit)
        {
            // Arrange
            var hand = this.generateRoyalFlush(suit);
            var expectedAnaylzerResult = new PokerHandResult()
            {
                HandType = HandType.RoyalFlush,
                HighestCard = hand.Where(x => x.Rank == 14).FirstOrDefault()
            };

            // Act
            var anaylzerResult = this.pokerHandAnalyzer.Analyze(hand);

            // Assert
            Assert.Equal(expectedAnaylzerResult, anaylzerResult);
        }

        [Theory]
        [InlineData(Suit.Clubs)]
        [InlineData(Suit.Diamonds)]
        [InlineData(Suit.Hearts)]
        [InlineData(Suit.Spades)]
        public void Analyze_Successfully_ReturnsStraightFlush(Suit suit)
        {
            // Arrange
            var hand = this.generateStraightFlush(suit);
            var expectedAnaylzerResult = new PokerHandResult()
            {
                HandType = HandType.StraightFlush,
                HighestCard = hand.Where(x => x.Rank == 6).FirstOrDefault()
            };

            // Act
            var anaylzerResult = this.pokerHandAnalyzer.Analyze(hand);

            // Assert
            Assert.Equal(expectedAnaylzerResult, anaylzerResult);
        }

        private List<Card> generateRoyalFlush(Suit suit) {
            return new List<Card>()
            {
                new Card() { Rank = 10, Suit = suit},
                new Card() { Rank = 11, Suit = suit},
                new Card() { Rank = 12, Suit = suit},
                new Card() { Rank = 13, Suit = suit},
                new Card() { Rank = 14, Suit = suit}
            };
        }

        private List<Card> generateStraightFlush(Suit suit)
        {
            return new List<Card>()
            {
                new Card() { Rank = 2, Suit = suit},
                new Card() { Rank = 3, Suit = suit},
                new Card() { Rank = 4, Suit = suit},
                new Card() { Rank = 5, Suit = suit},
                new Card() { Rank = 6, Suit = suit}
            };
        }
    }
}
