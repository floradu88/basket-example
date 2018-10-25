using System.Collections.Generic;
using basket_example.Interfaces;
using basket_example.Service;
using Moq;
using Xunit;

namespace basket_example.tests
{
    public class BasketServiceTests
    {
        [Fact]
        public void should_be_able_to_create_a_basket_service_with_offer_provider()
        {
            var offerRepositoryMock = new Mock<IOfferRepository>();
            var basketService = new BasketService(offerRepositoryMock.Object);

            Assert.NotNull(basketService);
        }

        [Fact]
        public void should_be_able_to_create_a_basket_and_apply_offers()
        {
            var offerRepositoryMock = new Mock<IOfferRepository>();
            offerRepositoryMock.Setup(x => x.GetOffers()).Returns(new List<Offer>
            {
                new Offer()
                {
                    ProductName = "Butter",
                    ItemsRequired = 2,
                    Percent = 0.50m,
                    NumberOfItems = 1,
                    AppliedForProduct ="Bread"
                },
                new Offer()
                {
                    ProductName = "Milk",
                    ItemsRequired = 3,
                    NumberOfItems = 1,
                    Percent = 1,
                    AppliedForProduct = "Milk"
                }
            });
            var basketService = new BasketService(offerRepositoryMock.Object);

            var basket = new Basket();
            basket.AddItem(new Product()
            {
                Price = 0.80m,
                Name = "Butter"
            }, 2);
            basket.AddItem(new Product()
            {
                Price = 1m,
                Name = "Bread"
            }, 1);

            basketService.ApplyOffers(basket);
            Assert.Equal(2.10m, basket.Total);
        }
    }
}
