namespace PokerMoqWorkshop.Services
{
    using PokerMoqWorkshop.Entities;
    using System.Collections.Generic;

    /// <summary>
    /// Interface that defines a poker hand analyzer.
    /// </summary>
    public interface IPokerHandAnalyzer
    {
        /// <summary>
        /// Analyzes the list of cards to determine what the result is.
        /// </summary>
        /// <param name="Hand">The cards to analyze.</param>
        /// <returns>The poker hand result. <see cref="PokerHandResult"/></returns>
        public PokerHandResult Analyze(IEnumerable<Card> Hand);
    }
}
