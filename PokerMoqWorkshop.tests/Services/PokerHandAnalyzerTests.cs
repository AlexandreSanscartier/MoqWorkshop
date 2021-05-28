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
                HighestCardRank = hand.Max(x => x.Rank)
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
                HighestCardRank = hand.Max(x => x.Rank)
            };

            // Act
            var anaylzerResult = this.pokerHandAnalyzer.Analyze(hand);

            // Assert
            Assert.Equal(expectedAnaylzerResult, anaylzerResult);
        }

        [Theory]
        [MemberData(nameof(fourOfAKindHands))]
        public void Analyze_Successfully_ReturnsFourOfAKind(List<Card> hand)
        {
            // Arrange
            var expectedAnaylzerResult = new PokerHandResult()
            {
                HandType = HandType.FourOfAKind,
                HighestCardRank = hand.Max(x => x.Rank)
            };

            // Act
            var analyzerResult = this.pokerHandAnalyzer.Analyze(hand);

            // Assert
            Assert.Equal(expectedAnaylzerResult, analyzerResult);
        }

        [Theory]
        [MemberData(nameof(fullHouseHands))]
        public void Analyze_Successfully_ReturnsFullHouse(List<Card> hand)
        {
            // Arrange
            var expectedAnaylzerResult = new PokerHandResult()
            {
                HandType = HandType.FullHouse,
                HighestCardRank = hand.Max(x => x.Rank)
            };

            // Act
            var analyzerResult = this.pokerHandAnalyzer.Analyze(hand);

            // Assert
            Assert.Equal(expectedAnaylzerResult, analyzerResult);
        }

        [Theory]
        [InlineData(Suit.Clubs)]
        [InlineData(Suit.Diamonds)]
        [InlineData(Suit.Hearts)]
        [InlineData(Suit.Spades)]
        public void Analyze_Successfully_ReturnsFlush(Suit suit)
        {
            // Arrange
            var hand = this.generateFlush(suit);
            var expectedAnaylzerResult = new PokerHandResult()
            {
                HandType = HandType.Flush,
                HighestCardRank = hand.Max(x => x.Rank)
            };

            // Act
            var anaylzerResult = this.pokerHandAnalyzer.Analyze(hand);

            // Assert
            Assert.Equal(expectedAnaylzerResult, anaylzerResult);
        }

        [Fact]
        public void Analyze_Successfully_ReturnsStraight()
        {
            // Arrange
            var hand = this.generateStraight();
            var expectedAnaylzerResult = new PokerHandResult()
            {
                HandType = HandType.Straight,
                HighestCardRank = hand.Max(x => x.Rank)
            };

            // Act
            var anaylzerResult = this.pokerHandAnalyzer.Analyze(hand);

            // Assert
            Assert.Equal(expectedAnaylzerResult, anaylzerResult);
        }

        [Fact]
        public void Analyze_Successfully_ReturnsThreeOfAKind()
        {
            // Arrange
            var hand = this.generateThreeOfAKind();
            var expectedAnaylzerResult = new PokerHandResult()
            {
                HandType = HandType.ThreeOfAKind,
                HighestCardRank = hand.Max(x => x.Rank)
            };

            // Act
            var anaylzerResult = this.pokerHandAnalyzer.Analyze(hand);

            // Assert
            Assert.Equal(expectedAnaylzerResult, anaylzerResult);
        }

        [Fact]
        public void Analyze_Successfully_ReturnsTwoPair()
        {
            // Arrange
            var hand = this.generateTwoPair();
            var expectedAnaylzerResult = new PokerHandResult()
            {
                HandType = HandType.TwoPair,
                HighestCardRank = hand.Max(x => x.Rank)
            };

            // Act
            var anaylzerResult = this.pokerHandAnalyzer.Analyze(hand);

            // Assert
            Assert.Equal(expectedAnaylzerResult, anaylzerResult);
        }

        [Fact]
        public void Analyze_Successfully_ReturnsPair()
        {
            // Arrange
            var hand = this.generatePair();
            var expectedAnaylzerResult = new PokerHandResult()
            {
                HandType = HandType.Pair,
                HighestCardRank = hand.Max(x => x.Rank)
            };

            // Act
            var anaylzerResult = this.pokerHandAnalyzer.Analyze(hand);

            // Assert
            Assert.Equal(expectedAnaylzerResult, anaylzerResult);
        }

        [Fact]
        public void Analyze_Successfully_ReturnsHighCard()
        {
            // Arrange
            var hand = this.generateHighCard();
            var expectedAnaylzerResult = new PokerHandResult()
            {
                HandType = HandType.HighCard,
                HighestCardRank = hand.Max(x => x.Rank)
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

        private List<Card> generateFlush(Suit suit)
        {
            return new List<Card>()
            {
                new Card() { Rank = 2, Suit = suit},
                new Card() { Rank = 4, Suit = suit},
                new Card() { Rank = 7, Suit = suit},
                new Card() { Rank = 8, Suit = suit},
                new Card() { Rank = 11, Suit = suit}
            };
        }

        private List<Card> generateStraight()
        {
            return new List<Card>()
            {
                new Card() { Rank = 4, Suit = Suit.Clubs},
                new Card() { Rank = 5, Suit = Suit.Diamonds},
                new Card() { Rank = 6, Suit = Suit.Hearts},
                new Card() { Rank = 7, Suit = Suit.Diamonds},
                new Card() { Rank = 8, Suit = Suit.Clubs}
            };
        }

        private List<Card> generateThreeOfAKind()
        {
            return new List<Card>()
            {
                new Card() { Rank = 4, Suit = Suit.Clubs},
                new Card() { Rank = 4, Suit = Suit.Diamonds},
                new Card() { Rank = 4, Suit = Suit.Hearts},
                new Card() { Rank = 7, Suit = Suit.Diamonds},
                new Card() { Rank = 8, Suit = Suit.Clubs}
            };
        }

        private List<Card> generateTwoPair()
        {
            return new List<Card>()
            {
                new Card() { Rank = 4, Suit = Suit.Clubs},
                new Card() { Rank = 4, Suit = Suit.Diamonds},
                new Card() { Rank = 7, Suit = Suit.Hearts},
                new Card() { Rank = 7, Suit = Suit.Diamonds},
                new Card() { Rank = 8, Suit = Suit.Clubs}
            };
        }

        private List<Card> generatePair()
        {
            return new List<Card>()
            {
                new Card() { Rank = 4, Suit = Suit.Clubs},
                new Card() { Rank = 4, Suit = Suit.Diamonds},
                new Card() { Rank = 9, Suit = Suit.Hearts},
                new Card() { Rank = 7, Suit = Suit.Diamonds},
                new Card() { Rank = 8, Suit = Suit.Clubs}
            };
        }

        private List<Card> generateHighCard()
        {
            return new List<Card>()
            {
                new Card() { Rank = 7, Suit = Suit.Clubs},
                new Card() { Rank = 9, Suit = Suit.Diamonds},
                new Card() { Rank = 10, Suit = Suit.Hearts},
                new Card() { Rank = 12, Suit = Suit.Diamonds},
                new Card() { Rank = 13, Suit = Suit.Clubs}
            };
        }

        public static IEnumerable<object[]> fourOfAKindHands
        {
            get {
                List<List<Card>> hands = new List<List<Card>>();
                for(var i = 2; i < 15; i++)
                {
                    List<Card> hand = new List<Card>()
                    {
                        new Card() { Rank = i, Suit = Suit.Clubs },
                        new Card() { Rank = i, Suit = Suit.Diamonds },
                        new Card() { Rank = i, Suit = Suit.Hearts },
                        new Card() { Rank = i, Suit = Suit.Spades },
                        new Card() { Rank = ((i % 11) + 2), Suit = Suit.Clubs }
                    };
                    yield return new object[] { hand };
                } 
            }
        }

        public static IEnumerable<object[]> fullHouseHands
        {
            get
            {
                List<List<Card>> hands = new List<List<Card>>();
                for (var i = 2; i < 15; i++)
                {
                    List<Card> hand = new List<Card>()
                    {
                        new Card() { Rank = i, Suit = Suit.Clubs },
                        new Card() { Rank = i, Suit = Suit.Diamonds },
                        new Card() { Rank = i, Suit = Suit.Hearts },
                        new Card() { Rank = (i % 11) + 2, Suit = Suit.Spades },
                        new Card() { Rank = (i % 11) + 2, Suit = Suit.Clubs }
                    };
                    yield return new object[] { hand };
                }
            }
        }
    }
}
