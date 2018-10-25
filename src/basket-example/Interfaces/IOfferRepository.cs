using System.Collections.Generic;

namespace basket_example.Interfaces
{
    public interface IOfferRepository
    {
        List<Offer> GetOffers();
    }
}
