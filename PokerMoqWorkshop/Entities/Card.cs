using PokerMoqWorkshop.Entities.Enum;

namespace PokerMoqWorkshop.Entities
{
    /// <summary>
    /// A playing card. with a Suit and Rank (example. 9 of diamonds)
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Gets or sets the card's suit.
        /// </summary>
        public Suit Suit { get; set; }

        /// <summary>
        /// Gets or sets the card's rank.
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// Gets the card's display name.
        /// </summary>
        public string DisplayName
        {
            get
            {
                if (Rank == 2) return string.Format("Two of {0}", this.SuitName);
                if (Rank == 3) return string.Format("Three of {0}", this.SuitName);
                if (Rank == 4) return string.Format("Four of {0}", this.SuitName);
                if (Rank == 5) return string.Format("Five of {0}", this.SuitName);
                if (Rank == 6) return string.Format("Six of {0}", this.SuitName);
                if (Rank == 7) return string.Format("Seven of {0}", this.SuitName);
                if (Rank == 8) return string.Format("Eight of {0}", this.SuitName);
                if (Rank == 9) return string.Format("Nine of {0}", this.SuitName);
                if (Rank == 10) return string.Format("Ten of {0}", this.SuitName);
                if (Rank == 11) return string.Format("Jack of {0}", this.SuitName);
                if (Rank == 12) return string.Format("Queen of {0}", this.SuitName);
                if (Rank == 13) return string.Format("King of {0}", this.SuitName);
                if (Rank == 14) return string.Format("Ace of {0}", this.SuitName);
                return string.Empty;
            }
        }

        public override string ToString()
        {
            return this.DisplayName;
        }

        private string SuitName
        {
            get
            {
                switch(this.Suit)
                {
                    case Suit.Clubs:
                        return "clubs";
                    case Suit.Diamonds:
                        return "diamonds";
                    case Suit.Hearts:
                        return "hearts";
                    case Suit.Spades:
                        return "spades";
                }
                return string.Empty;
            }
        }
    }
}
