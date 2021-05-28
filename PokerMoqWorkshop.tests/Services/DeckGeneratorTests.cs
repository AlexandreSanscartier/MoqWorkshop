namespace PokerMoqWorkshop.tests
{
    using System.Collections.Generic;
    using System.Linq;
    using PokerMoqWorkshop.Entities.Enum;
    using PokerMoqWorkshop.Services;
    using Xunit;

    public class DeckGeneratorTests
    {
        private readonly IDeckGenerator deckGenerator;

        public DeckGeneratorTests()
        {
            this.deckGenerator = new StandardDeckGenerator();
        }

        [Fact]
        public void GenerateDeck_Successfully_Contains52Cards()
        {
            // Arrange
            var expectedDeckSize = 52;

            // Act
            var deck = this.deckGenerator.GenerateDeck();
            var deckSize = deck.Count();

            // Assert
            Assert.Equal(expectedDeckSize, deckSize);
        }

        [Theory]
        [InlineData(Suit.Clubs)]
        [InlineData(Suit.Diamonds)]
        [InlineData(Suit.Hearts)]
        [InlineData(Suit.Spades)]
        public void GenerateDeck_Successfully_Contains13OfEachSuit(Suit suit)
        {
            // Arrange
            var expectedSuitCount = 13;

            // Act
            var deck = this.deckGenerator.GenerateDeck();
            var suitCount = deck.Where(x => x.Suit == suit).Count();

            // Assert
            Assert.Equal(expectedSuitCount, suitCount);
        }

        [Theory]
        [InlineData(Suit.Clubs)]
        [InlineData(Suit.Diamonds)]
        [InlineData(Suit.Hearts)]
        [InlineData(Suit.Spades)]
        public void GenerateDeck_Successfully_ContainsCorrecttNumbersForSuit(Suit suit)
        {
            // Arrange
            var expectedNumbers = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            // Act
            var deck = this.deckGenerator.GenerateDeck();
            var numbers = deck.Where(x => x.Suit == suit).Select(x => x.Rank).OrderBy(x => x);

            // Assert
            Assert.Equal(expectedNumbers, numbers);
        }
    }
}
