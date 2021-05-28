namespace PokerMoqWorkshop.Entities
{
    using System.Collections.Generic;

    public class Player
    {
        /// <summary>
        /// Gets or sets the player's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the player's hand.
        /// </summary>
        public List<Card> Hand { get; private set; } = new();

        /// <summary>
        /// Adds the specified <see cref="Card"/> to the player's hand.
        /// </summary>
        /// <param name="card">The <see cref="Card"/> to add to the player's hand.</param>
        public void AddCardToHand(Card card)
        {
            this.Hand.Add(card);
        }
    }
}
