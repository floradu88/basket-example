using Xunit;

namespace basket_example.tests
{
    public class OfferTests
    {
        private const string ProductName = "Butter";

        [Fact]
        public void should_be_able_to_create_an_offer()
        {
            var offer = new Offer
            {
                ProductName = ProductName,
                Percent = 0.25m,
                ItemsRequired = 2
            };

            Assert.NotNull(offer);
        }
    }
}