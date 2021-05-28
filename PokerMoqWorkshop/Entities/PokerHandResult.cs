using PokerMoqWorkshop.Entities.Enum;

namespace PokerMoqWorkshop.Entities
{
    public class PokerHandResult
    {
        /// <summary>
        /// Gets or sets the highest card for the hand.
        /// </summary>
        public int HighestCardRank { get; set; }

        /// <summary>
        /// Gets or sets the hand type.
        /// </summary>
        public HandType HandType { get; set; }

        /// <summary>
        /// Get or sets the hand's score.
        /// </summary>
        public int Score { get; set; }

        // <inheritdoc>
        public override int GetHashCode()
        {
            return this.HighestCardRank.GetHashCode() + this.HandType.GetHashCode();
        }

        // <inheritdoc>
        public override bool Equals(object obj)
        {
            var pokerHandResult = (PokerHandResult)obj;
            return this.HandType == pokerHandResult.HandType && this.HandType == pokerHandResult.HandType;
        }

        // <inheritdoc>
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", this.HandType, this.HighestCardRank, this.Score);
        }
    }
}
