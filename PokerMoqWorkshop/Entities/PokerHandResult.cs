using PokerMoqWorkshop.Entities.Enum;

namespace PokerMoqWorkshop.Entities
{
    public class PokerHandResult
    {
        /// <summary>
        /// Gets or sets the highest card for the hand.
        /// </summary>
        public Card HighestCard { get; set; }

        /// <summary>
        /// Gets or sets the hand type.
        /// </summary>
        public HandType HandType { get; set; }

        // <inheritdoc>
        public override int GetHashCode()
        {
            return this.HighestCard.GetHashCode() + this.HandType.GetHashCode();
        }

        // <inheritdoc>
        public override bool Equals(object obj)
        {
            var pokerHandResult = (PokerHandResult)obj;
            return this.HandType == pokerHandResult.HandType && this.HandType == pokerHandResult.HandType;
        }
    }
}
