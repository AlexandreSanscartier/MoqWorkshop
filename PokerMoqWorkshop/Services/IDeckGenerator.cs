namespace PokerMoqWorkshop.Services
{
    using PokerMoqWorkshop.Entities;
    using System.Collections.Generic;

    /// <summary>
    /// Interface that defines a deck generator.
    /// </summary>
    public interface IDeckGenerator
    {
        /// <summary>
        /// Generates a List of <see cref="Card"/>.
        /// </summary>
        /// <returns>A list of <see cref="Card"/>s.</returns>
        IEnumerable<Card> GenerateDeck();
    }
}
