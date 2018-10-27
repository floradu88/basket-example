using System.Collections.Generic;
using System.Linq;
using basket_example.Interfaces;

namespace basket_example.Service
{
    public class BasketService : IBasketService
    {
        private readonly IOfferRepository _offerRepository;

        public BasketService(IOfferRepository offerRepository)
        {
            this._offerRepository = offerRepository;
        }

        public void ApplyOffers(Basket basket)
        {
            var offers = _offerRepository.GetOffers();
            var alreadyAppliedOffers = new List<Offer>();

            foreach (var item in basket.Items)
            {
                var offer = offers.FirstOrDefault(x =>
                    x.ProductName == item.Product.Name && item.Count >= x.ItemsRequired);

                if (offer != null)
                {
                    var itemInOffer = basket.Items.FirstOrDefault(x =>
                        x.Product.Name == offer.AppliedForProduct && x.Count >= offer.NumberOfItems);

                    if (itemInOffer != null && alreadyAppliedOffers.All(o => o.Id != offer.Id))
                    {
                        itemInOffer.Offer = offer;
                        itemInOffer.ApplyOfferCount = item.Count / offer.ItemsRequired;
                        alreadyAppliedOffers.Add(offer);
                    }
                }
            }
        }
    }
}
