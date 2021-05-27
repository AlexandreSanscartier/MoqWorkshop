namespace PokerMoqWorkshop.Services
{
    using PokerMoqWorkshop.Entities;
    using System.Collections.Generic;

    public interface IDeckGenerator
    {
        IEnumerable<Card> GenerateDeck();
    }
}
