using Xunit;

namespace basket_example.tests
{
    public class ProductTests
    {
        private const string ProductName = "Butter";
        private const decimal ProductPrice = 0.80m;

        [Fact]
        public void should_be_able_to_create_a_product()
        {
            var product = new Product
            {
                Name = ProductName,
                Price = ProductPrice
            };

            Assert.NotNull(product);
        }
    }
}