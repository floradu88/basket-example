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
            BasketService basketService = BasketServiceSetup();

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

        [Theory]
        [InlineData(1, 1, 1, 2.95)]
        [InlineData(2, 2, 0, 3.10)]
        [InlineData(0, 0, 4, 3.45)]
        [InlineData(2, 1, 8, 9)]
        [InlineData(0, 0, 8, 6.9)]
        [InlineData(2, 1, 0, 2.10)]
        public void should_be_able_to_create_a_basket_and_apply_offers_scenarios(int numberOfButter, int numberOfBread, int numberOfMilk, decimal total)
        {
            BasketService basketService = BasketServiceSetup();

            var basket = new Basket();
            basket.AddItem(new Product()
            {
                Price = 0.80m,
                Name = "Butter"
            }, numberOfButter);
            basket.AddItem(new Product()
            {
                Price = 1m,
                Name = "Bread"
            }, numberOfBread);
            basket.AddItem(new Product()
            {
                Price = 1.15m,
                Name = "Milk"
            }, numberOfMilk);

            basketService.ApplyOffers(basket);
            Assert.Equal(total, basket.Total);
        }

        private static BasketService BasketServiceSetup()
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
                    AppliedForProduct ="Bread",
                    Id = 1
                },
                new Offer()
                {
                    ProductName = "Milk",
                    ItemsRequired = 3,
                    NumberOfItems = 1,
                    Percent = 0,
                    AppliedForProduct = "Milk",
                    Id = 2
                }
            });
            var basketService = new BasketService(offerRepositoryMock.Object);
            return basketService;
        }
    }
}
